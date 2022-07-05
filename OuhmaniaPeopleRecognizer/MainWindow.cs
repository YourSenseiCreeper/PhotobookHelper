using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Windows.Threading;
using Newtonsoft.Json;
using OuhmaniaPeopleRecognizer.Properties;
using OuhmaniaPeopleRecognizer.Services;
using OuhmaniaPeopleRecognizer.Services.Interfaces;

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
        private string[] supportedExtensions = { "*.jpg", "*.png", "*.bmp"};

        private readonly BindingSource peopleBindingSource;
        private bool programLoaded = false;

        private DispatcherTimer AutoSaveTimer;

        
        private IFileService _fileService;
        private INotificationService _notificationService;

        private string GetFormTitle()
        {
            var basicTitle = $"{PROGRAM_NAME} v{VERSION} ";
            if (_model.ProjectPath != null)
                basicTitle += $"({_model.ProjectPath})";
            return basicTitle;
        }

        public MainWindow()
        {
            var newCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;
            _notificationService = new NotificationService();
            _fileService = new FileService(_notificationService);

            _model = new OuhmaniaModel
            {
                Version = VERSION,
                SupportedFileExtensions = supportedExtensions,
                PicturesWithPeople = new Dictionary<string, List<string>>(),
                AllPeople = new List<string>(),
                AutoSave = true,
                AutoSaveIntervalInMinutes = 5,
                DirectoryPath = AppDomain.CurrentDomain.BaseDirectory,
                CurrentPicturePath = ""
            };
            _model.Dirty = false;

            peopleBindingSource = new BindingSource {DataSource = _model.AllPeople};
            InitializeComponent();
            Text = GetFormTitle();
            CenterToScreen();

            peopleCheckBoxList.DataSource = peopleBindingSource;

            Trace.Listeners["textWriterListener"].Attributes["initializeData"] =
                AppDomain.CurrentDomain.BaseDirectory + "\\" + DateTime.Now + ".log";
            programLoaded = true;
            pictureBox1.Image = new Bitmap(20, 20);
            if (_model.AutoSave)
                SetTimer();
        }

        private string GetAutosaveLabel(bool autosaved=false)
        {
            var autosave = _model.AutoSave ? Resources.MainWindow_Autosave_On : Resources.MainWindow_Autosave_Off;
            return autosaved ? string.Format(Resources.MainWindow_Autosave_Status, autosave, DateTime.Now.ToShortTimeString()) : autosave;
        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            // Hook up the Elapsed event for the timer. 
            AutoSaveTimer = new DispatcherTimer(DispatcherPriority.SystemIdle);
            AutoSaveTimer.Tick += OnAutosave;
            AutoSaveTimer.Interval = TimeSpan.FromMilliseconds(_model.AutoSaveIntervalInMinutes * 1000 * 60);
            AutoSaveTimer.Start();
        }

        private void OnAutosave(object source, EventArgs e)
        {
            if (_model.ProjectPath == null)
                return;

            try
            {
                var writer = new StreamWriter(_model.ProjectPath);
                writer.WriteLine(new JavaScriptSerializer().Serialize(_model));
                writer.Dispose();
                writer.Close();
                unsavedChanges = false;
                autosaveToolStripStatusLabel.Text = GetAutosaveLabel(true);
            }
            catch (IOException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void AddPersonAction()
        {
            var personName = AddPersonDialog.ShowDialog(Resources.MainWindow_addPerson_Title, Resources.MainWindow_addPerson_Caption);
            
            if (personName == null)
                return;
            
            _model.AddPerson(personName);
            peopleBindingSource.ResetBindings(true);
        }

        private void LoadInitialPicture()
        {
            // load first picture
            _model.CurrentPicturePath = _model.PicturesWithPeople.First().Key;
            LoadCurrentPathImage();
            UpdatePeopleCheckboxes();
        }

        private void SaveCurrentPictureState(bool beforeSaveAction = false)
        {
            var selectedPeople = new List<string>();
            foreach (var selectedPerson in peopleCheckBoxList.CheckedItems)
            {
                selectedPeople.Add(selectedPerson.ToString());
            }

            if (selectedPeople == _model.GetSelectedPeopleForCurrentPicture()) 
                return;

            _model.SetSelectedPeopleForCurrentPicture(selectedPeople);
            unsavedChanges = !beforeSaveAction;
        }

        private void LoadCurrentPathImage()
        {
            var path = _model.GetSelectedImagePath();
            pictureBox1.Image = _fileService.LoadImage(path);
        }

        private void UpdatePeopleCheckboxes()
        {
            // uncheck all
            for (var i = 0; i < peopleCheckBoxList.Items.Count; i++)
                peopleCheckBoxList.SetItemCheckState(i, CheckState.Unchecked);

            foreach (var selectedPerson in _model.GetSelectedPeopleForCurrentPicture())
            {
                peopleCheckBoxList.SetItemCheckState(peopleCheckBoxList.Items.IndexOf(selectedPerson), CheckState.Checked);
            }
        }

        private void CheckMissingFiles()
        {
            foreach(var batch in _model.Batches)
            {
                _fileService.CheckMissingFilesForBatch(batch);
            }
        }

        private void UpdateFileCountersAndLoadedFileList()
        {
            var allFilesCount = new List<string>(Directory.GetFiles(_model.DirectoryPath, "*.*", SearchOption.AllDirectories)).Count;
            allFilesCounttoolStripStatusLabel.Text =
                string.Format(Resources.MainWindow_allFilesCounttoolStripStatusLabel, allFilesCount);
            var onlyFileNames = _model.GetOnlyFileNames();
            loadedFilesCounttoolStripStatusLabel.Text = string.Format(Resources.MainWindow_loadedFilesCounttoolStripStatusLabel, onlyFileNames.Count);
            folderPathtoolStripStatusLabel.Text = _model.DirectoryPath;
        }

        private void CheckUnsavedChangesDialog()
        {
            if (_model.Dirty)
            {
                var result = MessageBox.Show(
                    Resources.MainWindow_CheckUnsavedChangesDialog_Caption,
                    Resources.MainWindow_CheckUnsavedChangesDialog_Title,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                    SaveModel();
            }
        }

        private void beforeClose(object sender, FormClosingEventArgs e) => CheckUnsavedChangesDialog();

        private void ListDirectory(TreeView treeView, string path)
        {
            treeView.Nodes.Clear();

            var stack = new Stack<TreeNode>();
            var rootDirectory = new DirectoryInfo(path);
            var node = new TreeNode(rootDirectory.Name) { Tag = rootDirectory };
            stack.Push(node);

            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();
                var directoryInfo = (DirectoryInfo)currentNode.Tag;
                foreach (var directory in directoryInfo.GetDirectories())
                {
                    var childDirectoryNode = new TreeNode(directory.Name) { Tag = directory };
                    currentNode.Nodes.Add(childDirectoryNode);
                    stack.Push(childDirectoryNode);
                }

                foreach (var file in directoryInfo.GetFiles())
                {
                    var extension = "*" + file.Name.Substring(file.Name.LastIndexOf("."));
                    var shortPath = file.FullName.Replace(path, "");
                    if (_model.SupportedFileExtensions.Contains(extension))
                    {
                        currentNode.Nodes.Add(new TreeNode(file.Name));
                        if (!_model.PicturesWithPeople.ContainsKey(shortPath))
                            _model.PicturesWithPeople.Add(shortPath, new List<string>());
                    }
                }
            }

            treeView.Nodes.Add(node);
        }

        public void SaveModel()
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = FILES_FILTER,
                InitialDirectory = _model.DirectoryPath
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _model.ProjectPath = saveFileDialog.FileName;
                var serialized = JsonConvert.SerializeObject(_model);
                File.WriteAllText(saveFileDialog.FileName, serialized);
                Text = GetFormTitle();
            }
            unsavedChanges = false;
        }

        public bool LoadModel()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = FILES_FILTER,
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory
            };
            if (openFileDialog.ShowDialog() != DialogResult.OK) 
                return false;

            var text = File.ReadAllText(openFileDialog.FileName);
            _model = JsonConvert.DeserializeObject<OuhmaniaModel>(text);
            Text = GetFormTitle();
            return true;
        }

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
                var selectedNodePath = treeView1.SelectedNode.FullPath;
                _model.CurrentPicturePath = $"{selectedNodePath.Replace(rootNode.FullPath, "")}";

                LoadCurrentPathImage();
                UpdatePeopleCheckboxes();
            }
            else
            {
                pictureBox1.Image = new Bitmap(20, 20);
                peopleCheckBoxList.Enabled = false;
            }
        }

        private void closeProgramToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private void exportFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // save current picture first
            SaveCurrentPictureState();
            var bookCreator = new BookCreator(_model)
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

            peopleBindingSource.ResetBindings(true);
            peopleBindingSource.DataSource = _model.AllPeople;
            if (_model.AutoSave)
            {
                AutoSaveTimer.Stop();
                SetTimer();
                autosaveToolStripStatusLabel.Text = GetAutosaveLabel();
            }
            //////// IO section
            CheckMissingFiles();
            /////////////

            UpdateFileCountersAndLoadedFileList();
            LoadCurrentPathImage();
            UpdatePeopleCheckboxes();

            Text = GetFormTitle();
            loadedFilesCounttoolStripStatusLabel.Visible = true;
            unsavedChanges = false;
            projectLoaded = true;
        }

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCurrentPictureState(true);
            SaveModel();
        }

        private void loadPhotosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _model.DirectoryPath = dialog.SelectedPath;
                    ListDirectory(treeView1, dialog.SelectedPath);
                    UpdateFileCountersAndLoadedFileList();
                    LoadInitialPicture();
                    unsavedChanges = true;
                }
            }
        }

        private void rescanDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListDirectory(treeView1, _model.DirectoryPath);

            // refresh pictures list
            // it can be anywhere
            UpdateFileCountersAndLoadedFileList();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            // Move the dragged node when the left mouse button is used.
            var filepaths = (string[]) e.Data.GetData(DataFormats.FileDrop);
            if (filepaths.Length != 0)
            {
                _model.DirectoryPath = filepaths[0];
                ListDirectory(treeView1, filepaths[0]);
                UpdateFileCountersAndLoadedFileList();
                LoadInitialPicture();
            }
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
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

        private void addPersonToolStripContextMenuItem_Click(object sender, EventArgs e) => AddPersonAction();

        private void deletePersonToolStripContextMenuItem_Click(object sender, EventArgs e)
        {
            var personToDelete = peopleCheckBoxList.SelectedItem.ToString();

            //TODO: Check if person was added to pictures

            var dialogInfo = string.Format(Resources.MainWindow_deletePersonToolStripContextMenuItem_Confirm, personToDelete);
            var dialogTitle = Resources.MainWindow_deletePersonToolStripContextMenuItem_ConfirmTitle;
            if (MessageBox.Show(dialogInfo, dialogTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _model.RemovePerson(personToDelete);
                peopleBindingSource.ResetBindings(true);
            }
        }

        private void nowyProjektToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Check if there are any changes in current project
            // TODO: Clear all data
        }
    }
}
