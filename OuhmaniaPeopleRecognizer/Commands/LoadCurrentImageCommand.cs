using OuhmaniaPeopleRecognizer.Services.Interfaces;
using System;

namespace OuhmaniaPeopleRecognizer.Commands
{
    public class LoadCurrentImageCommand : ICommand
    {
        private readonly IFileService _fileService;
        private readonly DataModel _model;
        private readonly MainWindowViewModel _mainWindowViewModel;

        public LoadCurrentImageCommand(IFileService fileService,
            DataModel dataModel,
            MainWindowViewModel viewModel)
        {
            _fileService = fileService;
            _model = dataModel;
            _mainWindowViewModel = viewModel;
        }

        public void Execute(object sender, EventArgs args)
        {
            var path = _model.GetSelectedImagePath();
            _mainWindowViewModel.PictureBox1.Image = _fileService.LoadImage(path);
        }
    }
}
