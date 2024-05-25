using OuhmaniaPeopleRecognizer.Commands;
using OuhmaniaPeopleRecognizer.Commands.Abstraction;
using OuhmaniaPeopleRecognizer.Services;
using OuhmaniaPeopleRecognizer.Services.Interfaces;
using OuhmaniaPeopleRecognizer.ViewManager;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

[assembly: NeutralResourcesLanguage("en-US")]
namespace OuhmaniaPeopleRecognizer
{
    public partial class MainWindow : Form
    {
        public DataModel _model;

        private IFileService _fileService;
        private INotificationService _notificationService;
        private TreeViewManager _treeViewManager;

        private MainWindowViewModel _mainWindowViewModel;
        private FormMenuViewManager _formMenuViewManager;
        private AutosaveManager _autosaveManager;
        private CategoryManager _categoryManager;
        private PictureBoxManager _pictureBoxManager;

        private ICommandFactory _commandFactory;

        public MainWindow()
        {
            InitializeComponent();

            Trace.Listeners["textWriterListener"].Attributes["initializeData"] =
                $"{AppDomain.CurrentDomain.BaseDirectory}\\{DateTime.Now}.log";

            InitializeContext();
            CenterToScreen();
        }

        private void InitializeContext()
        {
            var newCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;

            _model = new DataModel
            {
                IsAutoSaveActive = true,
                AutoSaveIntervalInMinutes = 5,
                DirectoryPath = AppDomain.CurrentDomain.BaseDirectory
            };
            _mainWindowViewModel = LoadFromMainWindow();
            _notificationService = new NotificationService();
            _fileService = new FileService(_notificationService);

            // jak z tego zrobić binding source?
            Text = _model.GetFormTitle();

            _commandFactory = new CommandFactory(_fileService, _model, _mainWindowViewModel);
            _autosaveManager = new AutosaveManager(_fileService, _mainWindowViewModel, _model);

            if (_model.IsAutoSaveActive)
                _autosaveManager.SetTimer();

            _treeViewManager = new TreeViewManager(_mainWindowViewModel, _model, _commandFactory);
            _treeViewManager.SubscribeOnEvents();

            _formMenuViewManager = new FormMenuViewManager(_fileService, _notificationService, _commandFactory, _mainWindowViewModel, _model, _treeViewManager);
            _formMenuViewManager.SubscribeOnEvents();

            _categoryManager = new CategoryManager(_notificationService, _mainWindowViewModel, _model);
            _categoryManager.SubscriveOnEvents();

            _pictureBoxManager = new PictureBoxManager(_mainWindowViewModel);
            _pictureBoxManager.SubscriveOnEvents();
        }

        private void beforeClose(object sender, FormClosingEventArgs e)
        {
            if (_model.Dirty && _notificationService.ShowUnsavedFilesDialog() == DialogResult.Yes)
            {
                _commandFactory.Get(Command.SaveDataModel).Execute(null, null);
            }
        }

        private void closeProgramToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        private MainWindowViewModel LoadFromMainWindow()
        {
            // TODO: refactor
            var bindingSource = new BindingSource { DataSource = _model.PeopleToDisplay };
            peopleCheckBoxList.DataSource = bindingSource;
            pictureBox1.Image = new Bitmap(20, 20);

            return new MainWindowViewModel
            {
                CategoryBindingSource = bindingSource,
                TreeView1 = treeView1,
                AddPersonToolStripContextMenuItem = addPersonToolStripContextMenuItem,
                AddPersonToolStripMenuItem = addPersonToolStripMenuItem,
                AutosaveToolStripStatusLabel = autosaveToolStripStatusLabel,
                CloseProgramToolStripMenuItem = closeProgramToolStripMenuItem,
                DeletePersonToolStripContextMenuItem = deletePersonToolStripContextMenuItem,
                ExportFilesToolStripMenuItem = exportFilesToolStripMenuItem,
                FileToolStripMenuItem = fileToolStripMenuItem,
                LoadPhotosToolStripMenuItem = loadPhotosToolStripMenuItem,
                LoadProjectToolStripMenuItem = loadProjectToolStripMenuItem,
                MenuStrip1 = menuStrip1,
                PeopleListMenuStrip = peopleListMenuStrip,
                NowyProjektToolStripMenuItem = nowyProjektToolStripMenuItem,
                PersonToolStripMenuItem = personToolStripMenuItem,
                PhotosToolStripMenuItem = photosToolStripMenuItem,
                PictureMenuStrip = pictureMenuStrip,
                RemovePersonToolStripMenuItem = removePersonToolStripMenuItem,
                RescanDirectoryToolStripMenuItem = rescanDirectoryToolStripMenuItem,
                RotateRightToolStripMenuItem = rotateRightToolStripMenuItem,
                RotateLeftToolStripMenuItem = rotateLeftToolStripMenuItem,
                SaveProjectToolStripMenuItem = saveProjectToolStripMenuItem,
                SplitContainer1 = splitContainer1,
                SplitContainer2 = splitContainer2,
                StatusStrip1 = statusStrip1,
                ToolStripSeparator1 = toolStripSeparator1,
                AllFilesCounttoolStripStatusLabel = allFilesCounttoolStripStatusLabel,
                LoadedFilesCounttoolStripStatusLabel = loadedFilesCounttoolStripStatusLabel,
                FolderPathtoolStripStatusLabel = folderPathtoolStripStatusLabel,
                PictureBox1 = pictureBox1,
                PeopleCheckBoxList = peopleCheckBoxList,
            };
        }
    }
}
