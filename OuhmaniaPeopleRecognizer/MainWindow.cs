using OuhmaniaPeopleRecognizer.Commands;
using OuhmaniaPeopleRecognizer.Commands.Abstraction;
using OuhmaniaPeopleRecognizer.Models;
using OuhmaniaPeopleRecognizer.Properties;
using OuhmaniaPeopleRecognizer.Services;
using OuhmaniaPeopleRecognizer.Services.Interfaces;
using OuhmaniaPeopleRecognizer.ViewManager;
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
        public DataModel _model;
        private bool projectLoaded = false;

        public List<string> PeopleToDisplay = new List<string>();

        private BindingSource peopleBindingSource;

        private DispatcherTimer AutoSaveTimer;

        private IFileService _fileService;
        private INotificationService _notificationService;
        private TreeViewManager _treeViewManager;

        private MainWindowViewModel _mainWindowViewModel;
        private ICommandFactory _commandFactory;

        public MainWindow()
        {
            InitializeComponent();

            Trace.Listeners["textWriterListener"].Attributes["initializeData"] =
                AppDomain.CurrentDomain.BaseDirectory + "\\" + DateTime.Now + ".log";
            pictureBox1.Image = new Bitmap(20, 20);

            InitializeContext();
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
            _model = new DataModel
            {
                IsAutoSaveActive = true,
                AutoSaveIntervalInMinutes = 5,
                DirectoryPath = AppDomain.CurrentDomain.BaseDirectory
            };

            // jak z tego zrobić binding source?
            Text = _model.GetFormTitle();

            peopleBindingSource = new BindingSource { DataSource = PeopleToDisplay };
            peopleCheckBoxList.DataSource = peopleBindingSource;

            _commandFactory = new CommandFactory(_fileService, _model, _mainWindowViewModel);

            if (_model.IsAutoSaveActive)
                SetTimer();

            _treeViewManager = new TreeViewManager(_mainWindowViewModel, _model, _commandFactory);
            _treeViewManager.SubscribeOnEvents();
        }

        #region model management
        public void SaveModel()
        {
            _commandFactory.Get(Command.SaveDataModel).Execute(null, null);
        }

        public bool LoadModel()
        {
            var loadedModel = _fileService.LoadModel(AppDomain.CurrentDomain.BaseDirectory);
            if (loadedModel != null)
            {
                _model = loadedModel;
                Text = _model.GetFormTitle();
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
            var success = _fileService.Autosave(_model);
            if (success)
            {
                //unsavedChanges = false;
                autosaveToolStripStatusLabel.Text = GetAutosaveLabel(true);
            }
        }

        private string GetAutosaveLabel(bool autosaved = false)
        {
            var autosave = _model.IsAutoSaveActive ? Resources.MainWindow_Autosave_On : Resources.MainWindow_Autosave_Off;
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
            _commandFactory.Get(Command.LoadCurrentImage).Execute(null, null);
            _commandFactory.Get(Command.UpdateCategoryCheckboxes).Execute(null, null);
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
                var state = currentPictureSelectedPeople.Contains(personName) ? CheckState.Checked : CheckState.Unchecked;
                peopleCheckBoxList.SetItemCheckState(i, state);
            }
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
            _commandFactory.Get(Command.SaveCurrentPictureSelections).Execute(null, null);
            var bookCreator = new BookCreator(_model, _notificationService, _fileService)
            {
                Visible = true,
            };
        }

        private void loadProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (projectLoaded)
                _commandFactory.Get(Command.SaveCurrentPictureSelections).Execute(null, null);

            CheckUnsavedChangesDialog();

            // user clicked cancel button during file opening
            if (!LoadModel())
                return;


            PeopleToDisplay = _model.PersonAndIndex.Keys.ToList();
            peopleBindingSource.ResetBindings(true);
            peopleBindingSource.DataSource = PeopleToDisplay;
            if (_model.IsAutoSaveActive)
            {
                AutoSaveTimer.Stop();
                SetTimer();
                autosaveToolStripStatusLabel.Text = GetAutosaveLabel();
            }
            //////// IO section
            CheckMissingFiles();
            /////////////

            _treeViewManager.LoadTreeViewFromModel();
            UpdateFileCountersAndLoadedFileList();
            LoadCurrentPathImage();
            UpdatePeopleCheckboxes();

            Text = _model.GetFormTitle(); // przenieść do komendy UpdateFormTitle
            loadedFilesCounttoolStripStatusLabel.Visible = true;
            projectLoaded = true;
        }



        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _commandFactory.Get(Command.SaveCurrentPictureSelections).Execute(null, null);
            _commandFactory.Get(Command.SaveDataModel).Execute(null, null);
            SaveModel();
        }

        private void loadPhotosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _commandFactory.Get(Command.LoadImages).Execute(sender, e);
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
                _commandFactory.Get(Command.SaveCurrentPictureSelections).Execute(null, null);

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
