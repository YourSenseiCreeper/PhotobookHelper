using System;
using System.Windows.Forms;

namespace OuhmaniaPeopleRecognizer.Commands
{
    public class UpdateCategoryCheckboxesCommand : ICommand
    {
        private readonly DataModel _model;
        private readonly MainWindowViewModel _mainWindowViewModel;

        public UpdateCategoryCheckboxesCommand(
            DataModel dataModel,
            MainWindowViewModel viewModel)
        {
            _model = dataModel;
            _mainWindowViewModel = viewModel;
        }

        public void Execute(object sender, EventArgs args)
        {
            var currentPictureSelectedPeople = _model.GetSelectedCategoriesForCurrentPicture();
            var items = _mainWindowViewModel.PeopleCheckBoxList.Items;
            for (var i = 0; i < items.Count; i++)
            {
                var personName = items[i].ToString();
                var state = currentPictureSelectedPeople.Contains(personName) ? CheckState.Checked : CheckState.Unchecked;
                _mainWindowViewModel.PeopleCheckBoxList.SetItemCheckState(i, state);
            }
        }
    }
}
