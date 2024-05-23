using OuhmaniaPeopleRecognizer.Services.Interfaces;
using System;

namespace OuhmaniaPeopleRecognizer.Commands
{
    public class SaveDataModelCommand : ICommand
    {
        private readonly IFileService _fileService;
        private readonly DataModel _model;
        private readonly MainWindowViewModel _mainWindowViewModel;

        public SaveDataModelCommand(IFileService fileService,
            DataModel dataModel,
            MainWindowViewModel viewModel)
        {
            _fileService = fileService;
            _model = dataModel;
            _mainWindowViewModel = viewModel;
        }

        public void Execute(object sender, EventArgs args)
        {
            if (!_fileService.SaveProject(_model))
                return;

            // TODO: this won't update form title. Find another way to do that
            _mainWindowViewModel.FormTitle = _model.GetFormTitle();
        }
    }
}
