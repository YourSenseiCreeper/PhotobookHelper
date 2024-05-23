using OuhmaniaPeopleRecognizer.Services.Interfaces;
using System;

namespace OuhmaniaPeopleRecognizer.Commands
{
    public class CommandNames
    {
        public const string LoadCurrentImageCommand = nameof(Commands.LoadCurrentImageCommand);
        public const string LoadImagesCommand = nameof(Commands.LoadImagesCommand);
        public const string UpdateCategoryCheckboxesCommand = nameof(Commands.UpdateCategoryCheckboxesCommand);
    }

    public enum Commands
    {
        LoadCurrentImageCommand,
        LoadImagesCommand,
        UpdateCategoryCheckboxesCommand,
    }

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

        public ICommand Get(Commands command)
        {
            ICommand result = null;
            switch (command)
            {
                case Commands.LoadCurrentImageCommand: result = new LoadCurrentImageCommand(_fileService, _model, _mainWindowViewModel); break;
                case Commands.LoadImagesCommand: result = new LoadImagesCommand(_fileService, _model, _mainWindowViewModel, this); break;
                case Commands.UpdateCategoryCheckboxesCommand: result = new UpdateCategoryCheckboxesCommand(_model, _mainWindowViewModel); break;
                default:
                    throw new ArgumentException($"Command '{command}' is not registered!");
            }

            return result;
        }
    }
}
