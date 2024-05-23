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

    public class CommandFactory : ICommandFactory
    {
        private readonly IFileService _fileService;
        private readonly OuhmaniaModel _model;
        private readonly MainWindowViewModel _mainWindowViewModel;

        public CommandFactory(
            IFileService fileService,
            OuhmaniaModel model,
            MainWindowViewModel mainWindowViewModel)
        {
            _fileService = fileService;
            _model = model;
            _mainWindowViewModel = mainWindowViewModel;
        }

        public ICommand GetCommand(string name)
        {
            ICommand result = null;
            switch (name)
            {
                case CommandNames.LoadCurrentImageCommand: result = new LoadCurrentImageCommand(_fileService, _model, _mainWindowViewModel); break;
                case CommandNames.LoadImagesCommand: result = new LoadImagesCommand(_fileService, _model, _mainWindowViewModel, this); break;
                case CommandNames.UpdateCategoryCheckboxesCommand: result = new UpdateCategoryCheckboxesCommand(_model, _mainWindowViewModel); break;
                default:
                    throw new ArgumentException($"Command '{name}' is not registered!");
            }

            return result;
        }
    }
}
