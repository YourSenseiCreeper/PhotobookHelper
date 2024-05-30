using OuhmaniaPeopleRecognizer.Properties;
using OuhmaniaPeopleRecognizer.Services.Interfaces;
using System;

namespace OuhmaniaPeopleRecognizer.ViewManager
{
    public class CategoryManager
    {
        private readonly MainWindowViewModel _viewModel;
        private readonly DataModel _model;
        private readonly INotificationService _notificationService;

        public CategoryManager(
            INotificationService notificationService,
            MainWindowViewModel viewModel,
            DataModel dataModel)
        {
            _notificationService = notificationService;
            _viewModel = viewModel;
            _model = dataModel;
        }

        public void SubscriveOnEvents()
        {
            _viewModel.AddPersonToolStripContextMenuItem.Click += AddPersonToolStripContextMenuItem_Click;
            _viewModel.DeletePersonToolStripContextMenuItem.Click += DeletePersonToolStripContextMenuItem_Click;
        }

        private void AddPersonToolStripContextMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new AddCategoryDialog();

            //var result = dialog.ShowDialog(Resources.AddCategoryDialog_Title, Resources.AddCategoryDialog_Text);
            var result = dialog.ShowCategoryDialog();

            if (result == null)
                return;

            _model.AddCategory(result.CategoryName, result.AssignedKey);
            _viewModel.CategoryBindingSource.ResetBindings(true);
        }

        private void DeletePersonToolStripContextMenuItem_Click(object sender, EventArgs e)
        {
            var personToDelete = _viewModel.PeopleCheckBoxList.SelectedItem.ToString();
            if (_notificationService.ShowDeletePerson(personToDelete))
            {
                _model.RemoveCategory(personToDelete);
                _viewModel.CategoryBindingSource.ResetBindings(true); //TODO: pilnować aby to działało
            }

        }
    }
}
