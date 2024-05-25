using OuhmaniaPeopleRecognizer.Commands;
using OuhmaniaPeopleRecognizer.Properties;
using OuhmaniaPeopleRecognizer.Services.Interfaces;
using PhotoCategorizer.i18N;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OuhmaniaPeopleRecognizer.ViewManager
{
    public class FormMenuViewManager
    {
        private readonly IFileService _fileService;
        private readonly INotificationService _notificationService;
        private readonly ICommandFactory _commandFactory;
        private readonly MainWindowViewModel _viewModel;
        private readonly DataModel _model;
        private readonly TreeViewManager _treeViewManager;

        public FormMenuViewManager(
            IFileService fileService,
            INotificationService notificationService,
            ICommandFactory commandFactory,
            MainWindowViewModel viewModel,
            DataModel dataModel,
            TreeViewManager treeViewManager
        )
        {
            _fileService = fileService;
            _notificationService = notificationService;
            _commandFactory = commandFactory;
            _viewModel = viewModel;
            _model = dataModel;
            _treeViewManager = treeViewManager;
        }

        public void SubscribeOnEvents()
        {
            _viewModel.ExportFilesToolStripMenuItem.Click += ExportFilesToolStripMenuItem_Click;
            _viewModel.SaveProjectToolStripMenuItem.Click += SaveProjectToolStripMenuItem_Click;
            _viewModel.LoadPhotosToolStripMenuItem.Click += LoadPhotosToolStripMenuItem_Click;
            _viewModel.NowyProjektToolStripMenuItem.Click += nowyProjektToolStripMenuItem_Click;
            _viewModel.RescanDirectoryToolStripMenuItem.Click += rescanDirectoryToolStripMenuItem_Click;
            _viewModel.LoadProjectToolStripMenuItem.Click += loadProjectToolStripMenuItem_Click;
        }

        private void ExportFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _commandFactory.Get<SaveCurrentPictureSelectionsCommand>().Execute(null, null);
            var bookCreator = new BookCreator(_model, _notificationService, _fileService)
            {
                Visible = true,
            };
        }

        private void SaveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _commandFactory.Get<SaveCurrentPictureSelectionsCommand>().Execute(null, null);
            _commandFactory.Get<SaveDataModelCommand>().Execute(null, null);
        }

        private void LoadPhotosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _commandFactory.Get<LoadImagesCommand>().Execute(sender, e);
        }

        private void nowyProjektToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Check if there are any changes in current project
            // TODO: Clear all data
        }

        private void rescanDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // dyskusyjne które directory path xd
            _fileService.LoadDirectory(_viewModel.TreeView1, _model, _model.DirectoryPath);

            // refresh pictures list
            // it can be anywhere
            UpdateFileCountersAndLoadedFileList();
        }

        private void loadProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // move variable to Model
            if (_model.IsProjectLoaded)
                _commandFactory.Get<SaveCurrentPictureSelectionsCommand>().Execute(null, null);

            CheckUnsavedChangesDialog();

            // user clicked cancel button during file opening
            if (!LoadModel())
                return;


            //PeopleToDisplay = _model.PersonAndIndex.Keys.ToList();
            _viewModel.CategoryBindingSource.ResetBindings(true);
            _viewModel.CategoryBindingSource.DataSource = _model.CategoryAndIndex.Keys.ToList();
            

            //if (_model.IsAutoSaveActive)
            //{
            //    AutoSaveTimer.Stop();
            //    SetTimer();
            //    _viewModel.AutosaveToolStripStatusLabel.Text = GetAutosaveLabel();
            //}

            //////// IO section
            CheckMissingFiles();
            /////////////

            _treeViewManager.LoadTreeViewFromModel();
            UpdateFileCountersAndLoadedFileList();
            LoadCurrentPathImage();
            UpdatePeopleCheckboxes();

            //Text = _model.GetFormTitle(); // przenieść do komendy UpdateFormTitle
            _viewModel.LoadedFilesCounttoolStripStatusLabel.Visible = true;
            _model.IsProjectLoaded = true;
        }

        public bool LoadModel()
        {
            var loadedModel = _fileService.LoadModel(AppDomain.CurrentDomain.BaseDirectory);
            if (loadedModel != null)
            {
                // TODO: another way to reload model
                //_model = loadedModel;
                //Text = _model.GetFormTitle();
                return true;
            }
            return false;
        }

        private void CheckMissingFiles()
        {
            foreach (var batch in _model.Batches)
            {
                _fileService.CheckMissingFilesForBatch(batch);
            }
        }
        private void CheckUnsavedChangesDialog()
        {
            if (_model.Dirty && _notificationService.ShowUnsavedFilesDialog() == DialogResult.Yes)
            {
                _commandFactory.Get<SaveDataModelCommand>().Execute(null, null);
            }
        }

        private void LoadCurrentPathImage()
        {
            var path = _model.GetSelectedImagePath();
            _viewModel.PictureBox1.Image = _fileService.LoadImage(path);
        }

        private void UpdatePeopleCheckboxes()
        {
            var categoryBoxList = _viewModel.PeopleCheckBoxList;
            var currentPictureSelectedPeople = _model.GetSelectedCategoriesForCurrentPicture();
            for (var i = 0; i < categoryBoxList.Items.Count; i++)
            {
                var personName = categoryBoxList.Items[i].ToString();
                var state = currentPictureSelectedPeople.Contains(personName) ? CheckState.Checked : CheckState.Unchecked;
                categoryBoxList.SetItemCheckState(i, state);
            }
        }

        private void UpdateFileCountersAndLoadedFileList()
        {
            var loadedFilesCount = _model.Batches.Sum(b => b.PicturePeople.Count);
            var allFilesCount = _model.Batches.Sum(b => Directory.GetFiles(b.DirectoryPath, "*.*", SearchOption.TopDirectoryOnly).Length);

            _viewModel.AllFilesCounttoolStripStatusLabel.Text = string.Format(Resources.AllFiles, allFilesCount);
            _viewModel.LoadedFilesCounttoolStripStatusLabel.Text = string.Format(Resources.LoadedFilesLabel, loadedFilesCount);
            _viewModel.FolderPathtoolStripStatusLabel.Text = _model.ProjectPath;
        }
    }
}
