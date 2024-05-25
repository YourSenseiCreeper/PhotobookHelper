using OuhmaniaPeopleRecognizer.Models;
using OuhmaniaPeopleRecognizer.Properties;
using OuhmaniaPeopleRecognizer.Services.Interfaces;
using PhotoCategorizer.i18N;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OuhmaniaPeopleRecognizer.Commands
{
    public class LoadImagesCommand : ICommand
    {
        private readonly IFileService _fileService;
        private readonly DataModel _model;
        private readonly MainWindowViewModel _mainWindowViewModel;
        private readonly ICommandFactory _commandFactory;

        public LoadImagesCommand(IFileService fileService,
            DataModel dataModel,
            MainWindowViewModel viewModel, ICommandFactory commandFactory)
        {
            _fileService = fileService;
            _model = dataModel;
            _mainWindowViewModel = viewModel;
            _commandFactory = commandFactory;
        }

        public void Execute(object sender, EventArgs args)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _fileService.LoadDirectory(_mainWindowViewModel.TreeView1, _model, dialog.SelectedPath);
                    UpdateFileCountersAndLoadedFileList();
                    LoadInitialPicture();
                    //unsavedChanges = true;
                }
            }
        }

        private void UpdateFileCountersAndLoadedFileList()
        {
            var loadedFilesCount = _model.Batches.Sum(b => b.PicturePeople.Count);
            var allFilesCount = _model.Batches.Sum(b => Directory.GetFiles(b.DirectoryPath, "*.*", SearchOption.TopDirectoryOnly).Length);

            _mainWindowViewModel.AllFilesCounttoolStripStatusLabel.Text = string.Format(Resources.AllFiles, allFilesCount);
            _mainWindowViewModel.LoadedFilesCounttoolStripStatusLabel.Text = string.Format(Resources.LoadedFilesLabel, loadedFilesCount);
            _mainWindowViewModel.FolderPathtoolStripStatusLabel.Text = _model.ProjectPath;
        }

        private void LoadInitialPicture()
        {
            var batch = _model.Batches.FirstOrDefault(b => b.PicturePeople.Count > 0);
            _model.LastUserSelection = new LastUserSelection
            {
                BatchId = batch?.Id,
                ImageName = batch?.PicturePeople.FirstOrDefault().Key
            };
            _commandFactory.Get<LoadCurrentImageCommand>().Execute(null, null);
            _commandFactory.Get<UpdateCategoryCheckboxesCommand>().Execute(null, null);
        }
    }
}
