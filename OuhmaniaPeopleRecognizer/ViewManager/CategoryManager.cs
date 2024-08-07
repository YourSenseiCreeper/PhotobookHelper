﻿using OuhmaniaPeopleRecognizer.Services.Interfaces;
using OuhmaniaPeopleRecognizer.ViewManager.Interfaces;
using System;

namespace OuhmaniaPeopleRecognizer.ViewManager
{
    public class CategoryManager : IHasSubscribeOnEvents
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

        public void SubscribeOnEvents()
        {
            _viewModel.AddPersonToolStripContextMenuItem.Click += AddPersonToolStripContextMenuItem_Click;
            _viewModel.DeletePersonToolStripContextMenuItem.Click += DeletePersonToolStripContextMenuItem_Click;
            _viewModel.EditPersonToolStripContextMenuItem.Click += EditPersonToolStripContextMenuItem_Click;
        }

        private void EditPersonToolStripContextMenuItem_Click(object sender, EventArgs e)
        {
            // take index of currently selected item
            // get info about it
            // pass it to constructor
            var existingCategory = _model.CategoryAndIndex["Liście"];
            var dialog = new AddCategoryDialog("Liście", null);

            //var result = dialog.ShowDialog(Resources.AddCategoryDialog_Title, Resources.AddCategoryDialog_Text);
            var result = dialog.ShowCategoryDialog();

            // cancel
            if (result == null)
                return;

            //
            _model.EditCategory(result.CategoryName, result.CategoryName + "A", result.AssignedKey);
            _viewModel.CategoryBindingSource.ResetBindings(true);
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
