using OuhmaniaPeopleRecognizer.Commands;
using OuhmaniaPeopleRecognizer.Models;
using OuhmaniaPeopleRecognizer.Properties;
using OuhmaniaPeopleRecognizer.Services;
using OuhmaniaPeopleRecognizer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;

[assembly: NeutralResourcesLanguage("en-US")]
namespace OuhmaniaPeopleRecognizer
{
    public partial class MainWindow : Form
    {
        private const string VERSION = "1.0";
        private const string PROGRAM_NAME = "OuhmaniaPeopleRecognizer";
        private const string FILES_FILTER = "Ouhmania reco files (*.opr)|*.opr|All files (*.*)|*.*";

        public OuhmaniaModel _model;
        private bool projectLoaded = false;
        private bool unsavedChanges = false;
        private string[] supportedExtensions = { "*.jpg", "*.png", "*.bmp" };

        public List<string> PeopleToDisplay = new List<string>();

        private BindingSource peopleBindingSource;

        private DispatcherTimer AutoSaveTimer;


        private IFileService _fileService;
        private INotificationService _notificationService;
        //private IDialogService _dialogService;

        private MainWindowViewModel _mainWindowViewModel;
        private ICommandFactory _commandFactory;

        private string GetFormTitle()
        {
            return $"{PROGRAM_NAME} v{VERSION} " + (_model.ProjectPath != null ? $"({_model.ProjectPath})" : "");
        }

        public MainWindow()
        {
            InitializeComponent();

            Trace.Listeners["textWriterListener"].Attributes["initializeData"] =
                AppDomain.CurrentDomain.BaseDirectory + "\\" + DateTime.Now + ".log";
            pictureBox1.Image = new Bitmap(20, 20);

            InitializeContext();
            Text = GetFormTitle();
            CenterToScreen();
        }

        private void InitializeContext()
        {
            var newCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;

            _mainWindowViewModel = new MainWindowViewModel
            {
                TreeView1 = treeView1,
                AllFilesCounttoolStripStatusLabel = allFilesCounttoolStripStatusLabel,
                LoadedFilesCounttoolStripStatusLabel = loadedFilesCounttoolStripStatusLabel,
                FolderPathtoolStripStatusLabel = folderPathtoolStripStatusLabel,
                PictureBox1 = pictureBox1,
                PeopleCheckBoxList = peopleCheckBoxList,
            };

            _notificationService = new NotificationService();
            _fileService = new FileService(_notificationService);
            _model = new OuhmaniaModel(VERSION, supportedExtensions, true, 5, AppDomain.CurrentDomain.BaseDirectory);

            peopleBindingSource = new BindingSource { DataSource = PeopleToDisplay };
            peopleCheckBoxList.DataSource = peopleBindingSource;

            _commandFactory = new CommandFactory(_fileService, _model, _mainWindowViewModel);
            //_loadImagesCommand = new LoadImagesCommand(_fileService, _model, _mainWindowViewModel);
            //_loadCurrentImageCommand = new LoadCurrentImageCommand(_fileService, _model, _mainWindowViewModel);
            //_updateCategoryCheckboxesCommand = new UpdateCategoryCheckboxesCommand(_model, _mainWindowViewModel);

            if (_model.AutoSave)
                SetTimer();
        }

        #region model management
        public void SaveModel()
        {
            if (_fileService.SaveProject(FILES_FILTER, _model))
            {
                Text = GetFormTitle();
                unsavedChanges = false;
            }
        }

        public bool LoadModel()
        {
            var loadedModel = _fileService.LoadModel(FILES_FILTER, AppDomain.CurrentDomain.BaseDirectory);
            if (loadedModel != null)
            {
                _model = loadedModel;
                Text = GetFormTitle();
                return true;
            }
            return false;
        }
        #endregion

        #region autosave
        private void SetTimer()
        {
            AutoSaveTimer = new DispatcherTimer(DispatcherPriority.SystemIdle);
            AutoSaveTimer.Tick += OnAutosave;
            AutoSaveTimer.Interval = TimeSpan.FromMilliseconds(_model.AutoSaveIntervalInMinutes * 1000 * 60);
            AutoSaveTimer.Start();
        }

        private void OnAutosave(object source, EventArgs e)
        {
            var success = _fileService.Autosave(FILES_FILTER, _model);
            if (success)
            {
                unsavedChanges = false;
                autosaveToolStripStatusLabel.Text = GetAutosaveLabel(true);
            }
        }

        private string GetAutosaveLabel(bool autosaved = false)
        {
            var autosave = _model.AutoSave ? Resources.MainWindow_Autosave_On : Resources.MainWindow_Autosave_Off;
            return autosaved ? string.Format(Resources.MainWindow_Autosave_Status, autosave, DateTime.Now.ToShortTimeString()) : autosave;
        }
        #endregion

        private void treeView1_Enter(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                treeView1.SelectedNode.BackColor = Color.Empty;
                treeView1.SelectedNode.ForeColor = Color.Empty;
            }
        }

        private void treeView1_Leave(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                treeView1.SelectedNode.BackColor = Color.Blue;
                treeView1.SelectedNode.ForeColor = Color.White;
            }
        }

        private void LoadInitialPicture()
        {
            var batch = _model.Batches.FirstOrDefault(b => b.PicturePeople.Count > 0);
            _model.LastUserSelection = new LastUserSelection
            {
                BatchId = batch?.Id,
                ImageName = batch?.PicturePeople.FirstOrDefault().Key
            };
            //LoadCurrentPathImage();
            _commandFactory.GetCommand(CommandNames.LoadCurrentImageCommand).Execute(null, null);
            _commandFactory.GetCommand(CommandNames.UpdateCategoryCheckboxesCommand).Execute(null, null);
            //UpdatePeopleCheckboxes();
        }

        private void LoadCurrentPathImage()
        {
            var path = _model.GetSelectedImagePath();
            pictureBox1.Image = _fileService.LoadImage(path);
        }

        private void UpdatePeopleCheckboxes()
        {
            var currentPictureSelectedPeople = _model.GetSelectedPeopleForCurrentPicture();
            for (var i = 0; i < peopleCheckBoxList.Items.Count; i++)
            {
                var personName = peopleCheckBoxList.Items[i].ToString();
                if (!currentPictureSelectedPeople.Contains(personName))
                {
                    peopleCheckBoxList.SetItemCheckState(i, CheckState.Unchecked);
                }
                else
                {
                    peopleCheckBoxList.SetItemCheckState(i, CheckState.Checked);
                }
            }
        }

        private void SaveCurrentPictureState(bool beforeSaveAction = false)
        {
            var selectedPeople = new List<string>();
            foreach (var selectedPerson in peopleCheckBoxList.CheckedItems)
            {
                selectedPeople.Add(selectedPerson.ToString());
            }

            var hasBeenChanged = _model.SetSelectedPeopleForCurrentPicture(selectedPeople);
            unsavedChanges = hasBeenChanged;
        }

        private void CheckMissingFiles()
        {
            foreach (var batch in _model.Batches)
            {
                _fileService.CheckMissingFilesForBatch(batch);
            }
        }

        private void UpdateFileCountersAndLoadedFileList()
        {
            var loadedFilesCount = _model.Batches.Sum(b => b.PicturePeople.Count);
            var allFilesCount = _model.Batches.Sum(b => Directory.GetFiles(b.DirectoryPath, "*.*", SearchOption.TopDirectoryOnly).Length);

            allFilesCounttoolStripStatusLabel.Text = string.Format(Resources.MainWindow_allFilesCounttoolStripStatusLabel, allFilesCount);
            loadedFilesCounttoolStripStatusLabel.Text = string.Format(Resources.MainWindow_loadedFilesCounttoolStripStatusLabel, loadedFilesCount);
            folderPathtoolStripStatusLabel.Text = _model.ProjectPath;
        }

        private void CheckUnsavedChangesDialog()
        {
            if (_model.Dirty && _notificationService.ShowUnsavedFilesDialog() == DialogResult.Yes)
            {
                SaveModel();
            }
        }

        private void beforeClose(object sender, FormClosingEventArgs e) => CheckUnsavedChangesDialog();





        #region topbar menu
        private void closeProgramToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void exportFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCurrentPictureState();
            var bookCreator = new BookCreator(_model, _notificationService, _fileService)
            {
                Visible = true,
            };
        }

        private void loadProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (projectLoaded)
                SaveCurrentPictureState();

            CheckUnsavedChangesDialog();

            // user clicked cancel button during file opening
            if (!LoadModel())
                return;


            PeopleToDisplay = _model.PersonAndIndex.Keys.ToList();
            peopleBindingSource.ResetBindings(true);
            peopleBindingSource.DataSource = PeopleToDisplay;
            if (_model.AutoSave)
            {
                AutoSaveTimer.Stop();
                SetTimer();
                autosaveToolStripStatusLabel.Text = GetAutosaveLabel();
            }
            //////// IO section
            CheckMissingFiles();
            /////////////

            LoadTreeViewFromModel();
            UpdateFileCountersAndLoadedFileList();
            LoadCurrentPathImage();
            UpdatePeopleCheckboxes();

            Text = GetFormTitle();
            loadedFilesCounttoolStripStatusLabel.Visible = true;
            unsavedChanges = false;
            projectLoaded = true;
        }

        private void LoadTreeViewFromModel()
        {
            // scan for unique paths (shortest, then add longest that is extension to this node)
            // 
            // albo stworzyć drzewko guidów i w zależności od tego drzewka wczytywać wszystko
            var rootBatches = new List<Batch>();

            // podejście 2
            // grupujemy po ilości ukośników
            // pierwsza grupa z najmniejszą ilością \ to foldery główne
            // pozostałe to podrzędne które należy dobrze dopasować do istniejących folderów głównych


            // C:\\zdjecia
            // C:\\wakacje
            // C:\\zdjecia\morze
            // D:\\rodzinne\pamiatki
            // D:\\rodzinne\babcia


            // podejście 3 - odsiewowe
            // biorę pierwszego batcha i jego DirectoryPath
            // splituję po \\ i szukam ile batchy zaczyna się od tego fragmentu
            // jeżeli wszystkie za pierwszym razem zapisuję ten początek do zmiennej startPath
            // jeżeli znowu wszystkie - dodaję to do startPath i zapisuję nazwę tego Node'a
            // jeżeli już mniej tworzę tamtego Node'a i istniejące w tej grupie Nody (odcinając początek i dalszą część (tylko do nazwy obecnego noda)
            // iteruję dalej i powtarzam operację
            // jeżeli liczba istniejących tak samo zaczyznających się nodów  jest równa 1 (tylko ten node) to dodaj zawartość noda i przejdź do kolejnego

            
            // wystarczy wyszukać unikalne root node'y i dodać je. Następnie przeiterować po wszystkich batchach i dodawać brakujące nody i pliki

            treeView1.Nodes.Clear();
            var directoryPathBatch = _model.Batches.ToDictionary(b => b.DirectoryPath, b => b);
            foreach (var batch in _model.Batches)
            {
                // zakładamy, że ścieżka C:\pliki\podfolder jest bardziej nadrzędna od C:\pliki\podfolder\zdjecia
                // jeżeli jest częścią ścieżki już dodanej. W drugą stronę to nie zadziała
                var moreRootBatch = rootBatches.FirstOrDefault(b => batch.DirectoryPath.Contains(b.DirectoryPath));
                if (moreRootBatch != null)
                {
                    rootBatches.Remove(moreRootBatch);
                    rootBatches.Add(batch);
                }
                else
                {
                    rootBatches.Add(batch);
                    // dodaj
                }
            }
        }

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCurrentPictureState(true);
            SaveModel();
        }

        private void loadPhotosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _commandFactory.GetCommand(CommandNames.LoadImagesCommand).Execute(sender, e);
        }

        private void rescanDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // dyskusyjne które directory path xd
            _fileService.LoadDirectory(treeView1, _model, _model.DirectoryPath);

            // refresh pictures list
            // it can be anywhere
            UpdateFileCountersAndLoadedFileList();
        }

        private void rotateRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currentImage = pictureBox1.Image;
            currentImage.RotateFlip(RotateFlipType.Rotate270FlipXY);
            pictureBox1.Image = currentImage;
        }

        private void rotateLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currentImage = pictureBox1.Image;
            currentImage.RotateFlip(RotateFlipType.Rotate90FlipXY);
            pictureBox1.Image = currentImage;
        }

        private void nowyProjektToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Check if there are any changes in current project
            // TODO: Clear all data
        }
        #endregion

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            // Move the dragged node when the left mouse button is used.
            var filepaths = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (filepaths.Length != 0)
            {
                _fileService.LoadDirectory(treeView1, _model, filepaths[0]);
                UpdateFileCountersAndLoadedFileList();
                LoadInitialPicture();
            }
        }

        #region treeview
        private void treeViewSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Nodes.Count == 0)
            {
                peopleCheckBoxList.Enabled = true;
                SaveCurrentPictureState();

                // disposing
                GC.Collect();
                pictureBox1.Image.Dispose();

                // load new picture
                var allNodes = treeView1.Nodes;
                var rootNode = allNodes[0];
                var selectedNode = treeView1.SelectedNode;
                var batchPath = selectedNode.FullPath.Replace($"\\{selectedNode.Text}", "");
                var selectedBatch = _model.Batches.First(b => b.DirectoryPath.EndsWith(batchPath));
                _model.LastUserSelection.BatchId = selectedBatch.Id;
                _model.LastUserSelection.ImageName = $"\\{selectedNode.Text}";
                LoadCurrentPathImage();
                UpdatePeopleCheckboxes();
            }
            else
            {
                pictureBox1.Image = new Bitmap(20, 20);
                peopleCheckBoxList.Enabled = false;
            }
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }
        #endregion



        private void addPersonToolStripContextMenuItem_Click(object sender, EventArgs e)
        {
            var personName = AddPersonDialog.ShowDialog(Resources.MainWindow_addPerson_Title, Resources.MainWindow_addPerson_Caption);

            if (string.IsNullOrWhiteSpace(personName))
                return;

            _model.AddPerson(personName);
            PeopleToDisplay.Add(personName);
            peopleBindingSource.ResetBindings(true);
        }

        private void deletePersonToolStripContextMenuItem_Click(object sender, EventArgs e)
        {
            var personToDelete = peopleCheckBoxList.SelectedItem.ToString();
            //if (_dialogService.ShowDeletePerson(personToDelete))
            //{
            //    _model.RemovePerson(personToDelete);
            //    PeopleToDisplay.Remove(personToDelete);
            //    peopleBindingSource.ResetBindings(true);
            //}

        }


    }
}
