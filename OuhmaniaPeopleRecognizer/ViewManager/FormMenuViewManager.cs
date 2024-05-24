using OuhmaniaPeopleRecognizer.Commands;
using OuhmaniaPeopleRecognizer.Commands.Abstraction;
using OuhmaniaPeopleRecognizer.Properties;
using OuhmaniaPeopleRecognizer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace OuhmaniaPeopleRecognizer.ViewManager
{
    public class FormMenuViewManager
    {
        private readonly IFileService _fileService;
        private readonly INotificationService _notificationService;
        private readonly ICommandFactory _commandFactory;
        private readonly MainWindowViewModel _viewModel;
        private readonly DataModel _model;

        public FormMenuViewManager(
            IFileService fileService,
            INotificationService notificationService,
            ICommandFactory commandFactory,
            MainWindowViewModel viewModel,
            DataModel dataModel
        )
        {
            _fileService = fileService;
            _notificationService = notificationService;
            _commandFactory = commandFactory;
            _viewModel = viewModel;
            _model = dataModel;
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
            _commandFactory.Get(Command.SaveCurrentPictureSelections).Execute(null, null);
            var bookCreator = new BookCreator(_model, _notificationService, _fileService)
            {
                Visible = true,
            };
        }

        private void SaveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _commandFactory.Get(Command.SaveCurrentPictureSelections).Execute(null, null);
            _commandFactory.Get(Command.SaveDataModel).Execute(null, null);
        }

        private void LoadPhotosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _commandFactory.Get(Command.LoadImages).Execute(sender, e);
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
            if (projectLoaded)
                _commandFactory.Get(Command.SaveCurrentPictureSelections).Execute(null, null);

            CheckUnsavedChangesDialog();

            // user clicked cancel button during file opening
            if (!LoadModel())
                return;


            //PeopleToDisplay = _model.PersonAndIndex.Keys.ToList();
            _viewModel.CategoryBindingSource.ResetBindings(true);
            _viewModel.CategoryBindingSource.DataSource = _model.PersonAndIndex.Keys.ToList();
            
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

            //Text = _model.GetFormTitle(); // przenieść do komendy UpdateFormTitle
            _viewModel.LoadedFilesCounttoolStripStatusLabel.Visible = true;
            //projectLoaded = true;
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
                _commandFactory.Get(Command.SaveDataModel).Execute(null, null);
            }
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

        private void UpdateFileCountersAndLoadedFileList()
        {
            var loadedFilesCount = _model.Batches.Sum(b => b.PicturePeople.Count);
            var allFilesCount = _model.Batches.Sum(b => Directory.GetFiles(b.DirectoryPath, "*.*", SearchOption.TopDirectoryOnly).Length);

            _viewModel.AllFilesCounttoolStripStatusLabel.Text = string.Format(Resources.MainWindow_allFilesCounttoolStripStatusLabel, allFilesCount);
            _viewModel.LoadedFilesCounttoolStripStatusLabel.Text = string.Format(Resources.MainWindow_loadedFilesCounttoolStripStatusLabel, loadedFilesCount);
            _viewModel.FolderPathtoolStripStatusLabel.Text = _model.ProjectPath;
        }
    }
}
