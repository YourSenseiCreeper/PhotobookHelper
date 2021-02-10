using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OuhmaniaPeopleRecognizer
{
    public partial class BookCreator : Form
    {
        private int _exportedFiles;
        // private string _importPath;
        private readonly OuhmaniaModel _model;

        public BookCreator(OuhmaniaModel model)
        {
            _model = model;
            var peopleBindingSource = new BindingSource();
            peopleBindingSource.DataSource = model.AllPeople;

            InitializeComponent();

            peopleChechboxList.DataSource = peopleBindingSource;
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
            if (peopleChechboxList.CheckedItems.Count == 0)
            {
                MessageBox.Show("Nie zaznaczono żadnej osoby, której chcesz utworzyć książkę.", "Czekaj, czekaj...",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var exportPeoplesPictures = new Dictionary<string, List<string>>();
            var selectedPeople = new List<string>();
            foreach (var person in peopleChechboxList.CheckedItems)
            {
                selectedPeople.Add(person.ToString());
                exportPeoplesPictures.Add(person.ToString(), new List<string>());
            }
            
            foreach (var keyValue in _model.PicturesWithPeople)
            {
                foreach (var person in selectedPeople)
                {
                    if (keyValue.Value.Contains(person))
                    {
                        exportPeoplesPictures[person].Add(keyValue.Key);
                    }
                }
            }

            _exportedFiles = 0;
            foreach (var keyValue in exportPeoplesPictures)
            {
                CopyFilesForPerson(keyValue.Key, keyValue.Value);
            }

            var exportedPicturesCount = exportPeoplesPictures.Values.Select(pictures => pictures.Count).Sum();
            MessageBox.Show($"Wyeksportowano ogółem {_exportedFiles} zdjęć dla {exportPeoplesPictures.Count} osób", "Eksport",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CopyFilesForPerson(string person, List<string> files)
        {
            var folderPath = _model.ExportPath + "\\Fotoksiążka_" + person.Replace(" ", "_");
            // it's better to not overwrite
            if (Directory.Exists(folderPath))
                Directory.Delete(folderPath, true);
            
            Directory.CreateDirectory(folderPath);

            long allSize = 0;
            files.ForEach(f => allSize += new FileInfo(f).Length);
            var currentDriveLetter = _model.ExportPath.Substring(0, 3);
            var currentDrive = DriveInfo.GetDrives().FirstOrDefault(d => d.Name == currentDriveLetter);
            // let's have at least 5mb more free space
            if (allSize + 1000000*5 >= currentDrive.AvailableFreeSpace)
            {
                MessageBox.Show($"Nie masz już więcej wolnego miejsca w folderze, do którego chcesz eksportować zdjęcia ({folderPath})", "Brak wolnego miejsca!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var file in files)
            {
                var filename = file.Replace(_model.DirectoryPath, "");
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);

                var filepath = folderPath + "\\" + filename;
                if (File.Exists(filepath))
                {
                    MessageBox.Show($"Znaleziono powtórkę zdjęcia ({filepath}). Nie zostanie wyeksportowane.", "Powtórzony plik!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    File.Copy(file, filepath);
                    _exportedFiles++;
                }

            }
        }
    }
}
