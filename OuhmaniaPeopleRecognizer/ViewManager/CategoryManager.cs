using OuhmaniaPeopleRecognizer.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OuhmaniaPeopleRecognizer.ViewManager
{
    public class CategoryManager
    {
        private readonly MainWindowViewModel _viewModel;
        private readonly DataModel _model;

        public CategoryManager(
            MainWindowViewModel viewModel,
            DataModel dataModel)
        {
            _viewModel = viewModel;
            _model = dataModel;
        }

        public void SubscriveOnEvents()
        {
            _viewModel.AddPersonToolStripContextMenuItem.Click += addPersonToolStripContextMenuItem_Click;
            _viewModel.DeletePersonToolStripContextMenuItem.Click += deletePersonToolStripContextMenuItem_Click;
        }

        private void addPersonToolStripContextMenuItem_Click(object sender, EventArgs e)
        {
            var personName = AddPersonDialog.ShowDialog(Resources.MainWindow_addPerson_Title, Resources.MainWindow_addPerson_Caption);

            if (string.IsNullOrWhiteSpace(personName))
                return;

            _model.AddPerson(personName);
            PeopleToDisplay.Add(personName);
            peopleBindingSource.ResetBindings(true);
        }

        private void deletePersonToolStripContextMenuItem_Click(object sender, EventArgs e)
        {
            var personToDelete = _viewModel.PeopleCheckBoxList.SelectedItem.ToString();
            //if (_dialogService.ShowDeletePerson(personToDelete))
            //{
            //    _model.RemovePerson(personToDelete);
            //    PeopleToDisplay.Remove(personToDelete);
            //    peopleBindingSource.ResetBindings(true);
            //}

        }
    }
}
