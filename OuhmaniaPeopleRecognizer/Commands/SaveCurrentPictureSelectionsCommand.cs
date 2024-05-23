using OuhmaniaPeopleRecognizer.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace OuhmaniaPeopleRecognizer.Commands
{
    public class SaveCurrentPictureSelectionsCommand : ICommand
    {
        private readonly IFileService _fileService;
        private readonly DataModel _model;
        private readonly MainWindowViewModel _mainWindowViewModel;

        public SaveCurrentPictureSelectionsCommand(IFileService fileService,
            DataModel dataModel,
            MainWindowViewModel viewModel)
        {
            _fileService = fileService;
            _model = dataModel;
            _mainWindowViewModel = viewModel;
        }

        public void Execute(object sender, EventArgs args)
        {
            var selectedPeople = new List<string>();
            foreach (var selectedPerson in _mainWindowViewModel.PeopleCheckBoxList.CheckedItems)
            {
                selectedPeople.Add(selectedPerson.ToString());
            }

            var hasBeenChanged = _model.SetSelectedPeopleForCurrentPicture(selectedPeople);
        }
    }
}
