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

        public ICommand Get<T>() where T : class, ICommand
        {
            var commandName = typeof(T).Name;
            switch (commandName)
            {
                case LoadCurrentImage: return new LoadCurrentImageCommand(_fileService, _model, _mainWindowViewModel);
                case LoadImages: return new LoadImagesCommand(_fileService, _model, _mainWindowViewModel, this);
                case UpdateCategoryCheckboxes: return new UpdateCategoryCheckboxesCommand(_model, _mainWindowViewModel);
                case SaveDataModel: return new SaveDataModelCommand(_fileService, _model, _mainWindowViewModel);
                case SaveCurrentPictureSelections: return new SaveCurrentPictureSelectionsCommand(_fileService, _model, _mainWindowViewModel);
                default:
                    throw new ArgumentException($"Command '{commandName}' is not registered!");
            }
        }

        private const string LoadCurrentImage = nameof(LoadCurrentImageCommand);
        private const string LoadImages = nameof(LoadImagesCommand);
        private const string UpdateCategoryCheckboxes = nameof(UpdateCategoryCheckboxesCommand);
        private const string SaveDataModel = nameof(SaveDataModelCommand);
        private const string SaveCurrentPictureSelections = nameof(SaveCurrentPictureSelectionsCommand);
    }
}
