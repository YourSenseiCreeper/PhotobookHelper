using OuhmaniaPeopleRecognizer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OuhmaniaPeopleRecognizer
{
    public partial class Exporter : Form
    {
        private readonly DataModel _model;
        private readonly INotificationService _notificationService;
        private readonly IFileService _fileService;

        private List<string> _peopleToExport;

        public Exporter(DataModel model, INotificationService notificationService, IFileService fileService)
        {
            _model = model;
            _notificationService = notificationService;
            _fileService = fileService;
            _peopleToExport = model.CategoryAndIndex.Keys.ToList();

            InitializeComponent();

            peopleChechboxList.DataSource = new BindingSource
            {
                DataSource = _peopleToExport,
            };
            pathOrErrorLabel.DataBindings.Add(new Binding("Text", _model, "ExportPath"));
            if (_model.ExportPath != null)
                exportButton.Enabled = true;

            CenterToParent();
        }

        private void pickDirectoryButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _model.ExportPath = dialog.SelectedPath;
                    exportButton.Enabled = true;
                }
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            var selectedCategories = peopleChechboxList.CheckedItems;

            if (selectedCategories.Count == 0)
            {
                _notificationService.Warning("Nie zaznaczono żadnej kategorii.", "Czekaj, czekaj...");
                return;
            }

            var exportedFilesCount = 0;
            foreach (var category in selectedCategories)
            {
                exportedFilesCount += ExportCategory(_model.ExportPath, category as string);
            }

            _notificationService.Info("Eksport", $"Wyeksportowano ogółem {exportedFilesCount} zdjęć w ramach {selectedCategories.Count} kategorii");
        }

        private int ExportCategory(string exportPath, string categoryName)
        {
            var exportImagePaths = new List<string>();
            var categoryIndex = _model.CategoryAndIndex[categoryName];

            foreach(var batch in _model.Batches)
            {
                foreach(var imageAndPeople in batch.PicturePeople)
                {
                    if (!imageAndPeople.Value.Contains(categoryIndex))
                        continue;

                    exportImagePaths.Add(batch.DirectoryPath + imageAndPeople.Key);
                }
            }

            _fileService.CopyFilesForCategory(exportPath, categoryName, exportImagePaths);
            return exportImagePaths.Count;
        }
    }
}
