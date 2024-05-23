using OuhmaniaPeopleRecognizer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OuhmaniaPeopleRecognizer
{
    public partial class BookCreator : Form
    {
        private readonly OuhmaniaModel _model;
        private readonly INotificationService _notificationService;
        private readonly IFileService _fileService;

        private List<string> _peopleToExport;

        public BookCreator(OuhmaniaModel model, INotificationService notificationService, IFileService fileService)
        {
            _model = model;
            _notificationService = notificationService;
            _fileService = fileService;
            _peopleToExport = model.PersonAndIndex.Keys.ToList();

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
            var selectedPeople = peopleChechboxList.CheckedItems;

            if (selectedPeople.Count == 0)
            {
                _notificationService.Warning("Nie zaznaczono żadnej osoby, której chcesz utworzyć książkę.", "Czekaj, czekaj...");
                return;
            }

            var exportedFilesCount = 0;
            foreach (var person in selectedPeople)
            {
                var personName = person as string;
                exportedFilesCount += ExportPerson(_model.ExportPath, personName);
            }

            _notificationService.Info($"Wyeksportowano ogółem {exportedFilesCount} zdjęć dla {selectedPeople.Count} osób", "Eksport");
        }

        private int ExportPerson(string exportPath, string personName)
        {
            var exportImagePaths = new List<string>();
            var personIndex = _model.PersonAndIndex[personName];

            foreach(var batch in _model.Batches)
            {
                foreach(var imageAndPeople in batch.PicturePeople)
                {
                    if (imageAndPeople.Value.Contains(personIndex))
                    {
                        exportImagePaths.Add(batch.DirectoryPath + imageAndPeople.Key);
                    }
                }
            }

            _fileService.CopyFilesForPerson(exportPath, personName, exportImagePaths);
            return exportImagePaths.Count;
        }

    }
}
