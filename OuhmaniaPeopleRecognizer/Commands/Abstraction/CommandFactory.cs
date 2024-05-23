using OuhmaniaPeopleRecognizer.Services.Interfaces;
using System;

namespace OuhmaniaPeopleRecognizer.Commands.Abstraction
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IFileService _fileService;
        private readonly DataModel _model;
        private readonly MainWindowViewModel _mainWindowViewModel;

        public CommandFactory(
            IFileService fileService,
            DataModel model,
            MainWindowViewModel mainWindowViewModel)
        {
            _fileService = fileService;
            _model = model;
            _mainWindowViewModel = mainWindowViewModel;
        }

        public ICommand Get(Command command)
        {
            ICommand result;
            switch (command)
            {
                case Command.LoadCurrentImage: result = new LoadCurrentImageCommand(_fileService, _model, _mainWindowViewModel); break;
                case Command.LoadImages: result = new LoadImagesCommand(_fileService, _model, _mainWindowViewModel, this); break;
                case Command.UpdateCategoryCheckboxes: result = new UpdateCategoryCheckboxesCommand(_model, _mainWindowViewModel); break;
                case Command.SaveDataModel: result = new SaveDataModelCommand(_fileService, _model, _mainWindowViewModel); break;
                case Command.SaveCurrentPictureSelections: result = new SaveCurrentPictureSelectionsCommand(_fileService, _model, _mainWindowViewModel); break;
                default:
                    throw new ArgumentException($"Command '{command}' is not registered!");
            }

            return result;
        }
    }
}
