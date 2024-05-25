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
            var personName = AddPersonDialog.ShowDialog(Resources.MainWindow_addPerson_Title, Resources.MainWindow_addPerson_Caption);

            if (string.IsNullOrWhiteSpace(personName))
                return;

            _model.AddCategory(personName);
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
