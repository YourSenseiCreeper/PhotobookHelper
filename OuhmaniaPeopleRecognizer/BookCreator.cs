using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OuhmaniaPeopleRecognizer
{
    public partial class BookCreator : Form
    {
        private string exportPath;
        private string _importPath;
        private readonly Dictionary<string, List<string>> _picturesWithPeople;
        public BookCreator(string importPath, List<string> peopleList, Dictionary<string, List<string>> picturesWithPeople)
        {
            InitializeComponent();
            peopleChechboxList.Items.Clear();
            peopleChechboxList.Items.AddRange(peopleList.ToArray());
            _picturesWithPeople = picturesWithPeople;
            _importPath = importPath;
            CenterToParent();
        }

        private void pickDirectoryButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    exportPath = dialog.SelectedPath;
                    pathOrErrorLabel.Text = exportPath;
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
            
            foreach (var keyValue in _picturesWithPeople)
            {
                foreach (var person in selectedPeople)
                {
                    if (keyValue.Value.Contains(person))
                    {
                        exportPeoplesPictures[person].Add(keyValue.Key);
                    }
                }
            }

            foreach (var keyValue in exportPeoplesPictures)
            {
                CopyFilesForPerson(keyValue.Key, keyValue.Value);
            }

            var exportedPicturesCount = exportPeoplesPictures.Values.Select(pictures => pictures.Count).Sum();
            MessageBox.Show($"Wyeksportowano ogółem {exportedPicturesCount} zdjęć dla {exportPeoplesPictures.Count} osób", "Eksport",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CopyFilesForPerson(string person, List<string> files)
        {
            var folderPath = exportPath + "\\Fotoksiążka_" + person.Replace(" ", "_");
            // it's better to not overwrite
            if (Directory.Exists(folderPath))
                Directory.Delete(folderPath, true);
            
            Directory.CreateDirectory(folderPath);

            long allSize = 0;
            files.ForEach(f => allSize += new FileInfo(f).Length);
            var currentDriveLetter = exportPath.Substring(0, 3);
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
                // sprawdzić czy podfolder dla zdjęcia istnieje
                var filename = file.Replace(_importPath, "");
                if (filename.Contains("\\"))
                {
                    filename = filename.Substring(filename.LastIndexOf("\\") + 1);
                }

                var filepath = folderPath + "\\" + filename;
                if (File.Exists(filepath))
                    filepath += "_1";

                File.Copy(file, filepath);
            }
        }
    }
}
