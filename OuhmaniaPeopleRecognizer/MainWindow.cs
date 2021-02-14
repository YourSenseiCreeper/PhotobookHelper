using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Windows.Threading;
using OuhmaniaPeopleRecognizer.Properties;
using WebPWrapper;

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

        private WebP webpWrapper;

        private string GetFormTitle()
        {
            var basicTitle = $"{PROGRAM_NAME} v{VERSION} ";
            if (_model.ProjectPath != null)
                basicTitle += $"({_model.ProjectPath})";
            return basicTitle;
        }

        public MainWindow()
        {
            peopleBindingSource = new BindingSource();
            // loadedPicturesBindingSource = new BindingSource();
            _model = new OuhmaniaModel
            {
                Version = VERSION,
                SupportedFileExtensions = supportedExtensions,
                PicturesWithPeople = new Dictionary<string, List<string>>(),
                AllPeople = new List<string>
                {
                    "Thomas Kowalski", "Amanda Turner"
                },
                AutoSave = true,
                AutoSaveIntervalInMins = 5,
                DirectoryPath = AppDomain.CurrentDomain.BaseDirectory,
                CurrentPicturePath = ""
            };
            peopleBindingSource.DataSource = _model.AllPeople;
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
            var autosave = _model.AutoSave ? "Włączony" : "Wyłączony";
            var datetime = autosaved ? DateTime.Now.ToShortTimeString() : "brak";
            return $"Autozapis: {autosave}, ostatni: {datetime}";
        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            // Hook up the Elapsed event for the timer. 
            AutoSaveTimer = new DispatcherTimer(DispatcherPriority.SystemIdle);
            AutoSaveTimer.Tick += OnAutosave;
            AutoSaveTimer.Interval = TimeSpan.FromMilliseconds(_model.AutoSaveIntervalInMins * 1000 * 60);
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
            var personName = AddPersonDialog.ShowDialog("Dodaj osobę", "Wpisz imię i nazwisko");
            
            // var personName = Prompt.ShowDialog("Wpisz imię i nazwisko osoby", "asdf");
            if (personName == null)
                return;
            
            _model.AllPeople.Add(personName);
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

        private string GetCurrentPicturePath()
        {
            return "";
            // return $"{_model.DirectoryPath}\\{loadedPicturesList.SelectedItem}";
        }

        private void LoadCurrentPathImage()
        {
            var fullPath = _model.DirectoryPath + _model.CurrentPicturePath;
            if (!File.Exists(fullPath))
            {
                pictureBox1.Image = new Bitmap(20, 20);
                return;
            }

            if (_model.CurrentPicturePath.EndsWith(".webp"))
            {
                pictureBox1.Image = webpWrapper.Load(fullPath);
            }
            else
            {
                using (var stream = File.OpenRead(fullPath))
                {
                    var loadedImage = Image.FromStream(stream);
                    loadedImage.RotateFlip(RotateFlipType.Rotate90FlipXY);
                    pictureBox1.Image = Image.FromStream(stream);

                }
            }
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
            var missingFiles = new List<string>();
            foreach (var file in _model.PicturesWithPeople.Keys)
            {
                if (!File.Exists(file))
                    missingFiles.Add(file);
            }

            if (missingFiles.Count != 0)
            {
                var message = $"Nie znaleziono {missingFiles.Count} plików. Czy chcesz je usunąć z projektu? \n" +
                              string.Join("\n", missingFiles);
                var result = MessageBox.Show(message, "Brakujące pliki", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    foreach (var missingFile in missingFiles)
                    {
                        _model.PicturesWithPeople.Remove(missingFile);
                    }
                }
            }
        }

        private void UpdateFileCountersAndLoadedFileList()
        {
            var allFilesCount = new List<string>(Directory.GetFiles(_model.DirectoryPath, "*.*", SearchOption.AllDirectories)).Count;
            allFilesCounttoolStripStatusLabel.Text = "All files: " + allFilesCount;
            var onlyFileNames = _model.GetOnlyFileNames();
            // loadedPicturesBindingSource.DataSource = onlyFileNames;
            loadedFilesCounttoolStripStatusLabel.Text = "Loaded files: " + onlyFileNames.Count;
            folderPathtoolStripStatusLabel.Text = _model.DirectoryPath;
        }

        /// <summary>
        /// "Masz niezapisane zmiany w projekcie!" {details}
        /// </summary>
        /// <param name="details"></param>
        /// <param name="yesAction"></param>
        /// <param name="noAction"></param>
        private void CheckUnsavedChangesDialog(string details, Action yesAction = null, Action noAction = null)
        {
            if (unsavedChanges)
            {
                var result = MessageBox.Show("Masz niezapisane zmiany w projekcie! " + details, "Niezapisane zmiany",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No && noAction != null)
                    noAction();
                else if (result == DialogResult.Yes & yesAction != null)
                    yesAction();
            }
        }

        private void beforeClose(object sender, FormClosingEventArgs e)
        {
            CheckUnsavedChangesDialog("Czy chcesz je zapisać?", SaveModel);
        }

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
                var writer = new StreamWriter(saveFileDialog.OpenFile());
                _model.ProjectPath = saveFileDialog.FileName;
                writer.WriteLine(new JavaScriptSerializer().Serialize(_model));
                writer.Dispose();
                writer.Close();
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

            var reader = new StreamReader(openFileDialog.OpenFile());
            _model = new JavaScriptSerializer().Deserialize<OuhmaniaModel>(reader.ReadLine() ?? string.Empty);
            reader.Dispose();
            reader.Close();
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

            CheckUnsavedChangesDialog("Czy chcesz je zapisać?", SaveModel);

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
            var data = e.Data;
            var filepaths = (string[]) e.Data.GetData(DataFormats.FileDrop);
            if (filepaths.Length != 0)
            {
                _model.DirectoryPath = filepaths[0];
                ListDirectory(treeView1, filepaths[0]);
                UpdateFileCountersAndLoadedFileList();
            }
            

        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            var datatype = e.Data.GetFormats();
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
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
                _model.AllPeople.Remove(personToDelete);
                peopleBindingSource.ResetBindings(true);
            }
        }
    }
}
