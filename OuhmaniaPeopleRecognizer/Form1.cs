using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OuhmaniaPeopleRecognizer
{
    public partial class Form1 : Form
    {
        private Dictionary<string, List<string>> picturesWithPeople;
        private List<string> allPeople;
        private string currentPicturePath;
        private string directoryPath;
        private bool unsavedChanges = false;

        public Form1()
        {
            InitializeComponent();
            picturesWithPeople = new Dictionary<string, List<string>>();
            allPeople = new List<string>
            {
                "Feliks Wawrzyniak",
                "Ryszard Kaczmarek",
                "Zofia Rydzińska",
                "Małgorzata Bednarek",
                "Rafaela Brodziak",
                "Janina Bala",
                "Genowefa Frąckowiak",
                "Maria Grabowska",
                "Lilianna Korzeniewska",
                "Janina Brzozowska",
                "Agnieszka Bryk",
                "Marta Bryk",
                "Jolanta Grabowska",
                "Paulina Jagieła-Śliwińska",
                "Janina Markowicz",
                "Jan Dunajko",
                "Marian Fieduk",
                "Zygmunt Toboła",
                "Marian Kuncewicz",
                "Stanisław Przybyszewski",
                "Edmund Pujanek",
                "Mirosława Orłowska",
                "Wanda Rejtan",
                "Ilona Skoneczna-Kupś",
                "Halina Strzelecka",
                "Janina Szews",
                "Zofia Śliperska",
                "Marianna Wieczorek",
                "Jadwiga Prętka",
                "Helena Nowak",
                "Agnieszka Szkuciak",
                "Dominika Szkuciak",
                "Patryk Sawiński",
                "Marian Zapała",
                "Alina Wereszczyńska",
                "Grażyna Borowik"
            };
            CenterToScreen();
            Trace.Listeners["textWriterListener"].Attributes["initializeData"] =
                AppDomain.CurrentDomain.BaseDirectory + "\\" + DateTime.Now + ".log";
            // Trace.Listeners.Add(new TextWriterTraceListener());
            // Trace.AutoFlush = true;
            // Trace.Indent();
        }

        private void LoadPicturesClick(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadPictures(dialog.SelectedPath);
                    dictionaryPathLabel.Text = dialog.SelectedPath;
                    directoryPath = dialog.SelectedPath;
                    LoadInitialPicture();
                    unsavedChanges = true;
                }
            }
        }

        private void AddPersonClicked(object sender, EventArgs e)
        {
            peopleCheckBoxList.Items.AddRange(allPeople.ToArray());
        }

        private void LoadPictures(string folderPath)
        {
            var supportedExtensions = new[] {"*.jpg", "*.png", "*.bmp"};
            var loadedPictures = new Dictionary<string, List<string>>();
            var allLoadedPicturesPaths = new List<string>();
            var onlyFilenames = new List<string>();

            foreach (var extension in supportedExtensions)
            {
                var loadedFilesForExtension =
                    new List<string>(Directory.GetFiles(folderPath, extension, SearchOption.AllDirectories));
                loadedPictures.Add(extension, loadedFilesForExtension);
                foreach (var filename in loadedFilesForExtension)
                {
                    onlyFilenames.Add(filename.Replace($"{folderPath}\\", ""));
                }
                allLoadedPicturesPaths.AddRange(loadedFilesForExtension);
            }

            loadedPicturesList.Items.Clear();
            loadedPicturesList.Items.AddRange(onlyFilenames.ToArray());
            var allFilesCount = new List<string>(Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories)).Count;
            var loadedPicturesCount = loadedPictures.Values.Select(pictures => pictures.Count).Sum();
            allFilesCountLabel.Text = "Plików w folderze: " + allFilesCount;
            loadedFilesCountLabel.Text = "Załadowanych plików: " + loadedPicturesCount;

            picturesWithPeople.Clear();
            foreach (var picture in allLoadedPicturesPaths)
            {
                picturesWithPeople.Add(picture, new List<string>());
            }
        }

        private void LoadInitialPicture()
        {
            // load new picture
            currentPicturePath = directoryPath + "\\" + loadedPicturesList.Items[0];
            pictureBox1.Image = Image.FromFile(currentPicturePath);
            loadedPicturesList.SelectedIndex = 0;

            // check saved people
            peopleCheckBoxList.Items.Clear();
            peopleCheckBoxList.Items.AddRange(allPeople.ToArray());
            var currentSelectedPeople = picturesWithPeople[currentPicturePath];
            foreach (var selectedPerson in currentSelectedPeople)
            {
                peopleCheckBoxList.SetItemChecked(allPeople.IndexOf(selectedPerson), true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void PictureSelected(object sender, EventArgs e)
        {
            // Add people from previous picture
            var selectedPeople = new List<string>();
            foreach (var selectedPerson in peopleCheckBoxList.CheckedItems)
            {
                selectedPeople.Add(selectedPerson.ToString());
            }

            if (selectedPeople != picturesWithPeople[currentPicturePath])
            {
                picturesWithPeople[currentPicturePath] = selectedPeople;
                unsavedChanges = true;
            }

            // disposing
            GC.Collect();

            // load new picture
            currentPicturePath = directoryPath + "\\" + loadedPicturesList.SelectedItem;
            pictureBox1.Image = Image.FromFile(currentPicturePath);

            // check saved people
            peopleCheckBoxList.Items.Clear();
            peopleCheckBoxList.Items.AddRange(allPeople.ToArray());
            var currentSelectedPeople = picturesWithPeople[currentPicturePath];
            foreach (var selectedPerson in currentSelectedPeople)
            {
                peopleCheckBoxList.SetItemChecked(peopleCheckBoxList.Items.IndexOf(selectedPerson), true);
            }
        }

        private void pictureBox1_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var model = new OuhmaniaModel
            {
                AllPeople = allPeople,
                DirectoryPath = directoryPath,
                PicturesWithPeople = picturesWithPeople,
                CurrentPicturePath = currentPicturePath
            };
            AppSettings<OuhmaniaModel>.Save(model, directoryPath);
            unsavedChanges = false;
        }

        private void loadSettingsButton_Click(object sender, EventArgs e)
        {
            var model = AppSettings<OuhmaniaModel>.Load("");
            allPeople = model.AllPeople;
            picturesWithPeople = model.PicturesWithPeople;
            currentPicturePath = model.CurrentPicturePath;

            directoryPath = model.DirectoryPath;
            dictionaryPathLabel.Text = directoryPath;

            var allFilesCount = new List<string>(Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories)).Count;
            allFilesCountLabel.Text = "Plików w folderze: " + allFilesCount;
            
            pictureBox1.Image = Image.FromFile(currentPicturePath);

            // check saved people
            peopleCheckBoxList.Items.Clear();
            peopleCheckBoxList.Items.AddRange(allPeople.ToArray());
            var currentSelectedPeople = picturesWithPeople[currentPicturePath];
            foreach (var selectedPerson in currentSelectedPeople)
            {
                peopleCheckBoxList.SetItemChecked(allPeople.IndexOf(selectedPerson), true);
            }
            
            var onlyFilenames = new List<string>();
            foreach (var key in model.PicturesWithPeople.Keys)
            {
                onlyFilenames.Add(key.Replace($"{directoryPath}\\", ""));
            }
            
            loadedPicturesList.Items.Clear();
            loadedPicturesList.Items.AddRange(onlyFilenames.ToArray());

            var selectedPicture = currentPicturePath.Replace($"{directoryPath}\\", "");
            loadedPicturesList.SelectedIndex = onlyFilenames.IndexOf(selectedPicture);

            loadedFilesCountLabel.Text = "Załadowanych plików: " + onlyFilenames.Count;
        }

        private void bookCreatorButton_Click(object sender, EventArgs e)
        {
            var bookCreator = new BookCreator(directoryPath, allPeople, picturesWithPeople)
            {
                Visible = true,
            };
        }

        private void beforeClose(object sender, FormClosingEventArgs e)
        {
            if (unsavedChanges)
            {
                var result = MessageBox.Show("Masz niezapisane zmiany w projekcie! Czy nadal chcesz wyjść?", "Niezapisane zmiany",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                    e.Cancel = true;
            }
                
        }
    }
}
