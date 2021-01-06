using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
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
        private string[] supportedExtensions = { "*.jpg", "*.png", "*.bmp" };
        private const string PROGRAM_NAME = "OuhmaniaPeopleRecognizer v1.0 ";
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
            currentPicturePath = "";
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
            using (var stream = File.OpenRead(currentPicturePath))
            {
                var currentImage = Image.FromStream(stream);
                pictureBox1.Image = currentImage;
            }
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

        private void SaveCurrentPictureState(bool beforeSaveAction = false)
        {
            if (picturesWithPeople.ContainsKey(currentPicturePath))
            {
                var selectedPeople = new List<string>();
                foreach (var selectedPerson in peopleCheckBoxList.CheckedItems)
                {
                    selectedPeople.Add(selectedPerson.ToString());
                }

                if (selectedPeople != picturesWithPeople[currentPicturePath])
                {
                    picturesWithPeople[currentPicturePath] = selectedPeople;
                    unsavedChanges = !beforeSaveAction;
                }
            }
        }

        private void PictureSelected(object sender, EventArgs e)
        {
            // Add people from previous picture
            SaveCurrentPictureState();

            // disposing
            GC.Collect();
            pictureBox1.Image.Dispose();

            // load new picture
            currentPicturePath = directoryPath + "\\" + loadedPicturesList.SelectedItem;
            if (!File.Exists(currentPicturePath))
            {
                pictureBox1.Image = new Bitmap(20, 20);
                // var result = MessageBox.Show("Ooops! Wygląda na to, że plik został usunięty, lub przeniesiony. Chcesz usunąć plik z listy?", "Brakujący plik",
                //     MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                // if (result == DialogResult.Yes)
                // {
                //     picturesWithPeople.Remove(currentPicturePath);
                //     var newSelectedIndex = loadedPicturesList.SelectedIndex + 1 != loadedPicturesList.Items.Count ?
                //         loadedPicturesList.SelectedIndex + 1 :
                //         0;
                //
                //     // do not refresh by rand. Do it for all pictures (unfortunately)
                //     // hand action triggers event
                //     loadedPicturesList.SelectedItem = loadedPicturesList.Items[newSelectedIndex];
                //     // loadedPicturesList.Items.Remove(itemToDelete);
                //     
                //     
                // }
                // else
                // {
                //     pictureBox1.Image = new Bitmap(20, 20);
                // }
                return;
            }
            Image currentImage;
            using (var stream = File.OpenRead(currentPicturePath))
            {
                currentImage = Image.FromStream(stream);
                pictureBox1.Image = currentImage;
            }

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
            SaveCurrentPictureState(true);
            SaveModel();
        }

        private void loadSettingsButton_Click(object sender, EventArgs e)
        {
            SaveCurrentPictureState();
            CheckUnsavedChangesDialog("Czy chcesz je zapisać?", SaveModel);

            var response = Load();
            // user clicked cancel button during file opening
            if (!response.Item1)
                return;

            var model = response.Item2;
            allPeople = model.AllPeople;
            var missingFiles = new List<string>();
            foreach (var file in model.PicturesWithPeople.Keys)
            {
                if (!File.Exists(file))
                    missingFiles.Add(file);
            }

            if (missingFiles.Count != 0)
            {
                var message = $"Nie znaleziono {missingFiles.Count} plików. Czy chcesz je usunąć z projektu? \n" +
                              string.Join("\n", missingFiles);
                var result = MessageBox.Show(message, "Brakujące pliki", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    foreach (var missingFile in missingFiles)
                    {
                        model.PicturesWithPeople.Remove(missingFile);
                    }
                }
            }
            picturesWithPeople = model.PicturesWithPeople;
            currentPicturePath = model.CurrentPicturePath;

            directoryPath = model.DirectoryPath;
            dictionaryPathLabel.Text = directoryPath;

            var allFilesCount = new List<string>(Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories)).Count;
            allFilesCountLabel.Text = "Plików w folderze: " + allFilesCount;

            Image currentImage;
            using (var stream = File.OpenRead(currentPicturePath))
            {
                currentImage = Image.FromStream(stream);
                pictureBox1.Image = currentImage;
            }

            // check saved people
            peopleCheckBoxList.Items.Clear();
            peopleCheckBoxList.Items.AddRange(allPeople.ToArray());
            var currentPictureSelectedPeople = picturesWithPeople[currentPicturePath];
            foreach (var selectedPerson in currentPictureSelectedPeople)
            {
                peopleCheckBoxList.SetItemChecked(peopleCheckBoxList.Items.IndexOf(selectedPerson), true);
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
            unsavedChanges = false;
        }

        private void bookCreatorButton_Click(object sender, EventArgs e)
        {
            // save current picture first
            SaveCurrentPictureState();
            var bookCreator = new BookCreator(directoryPath, allPeople, picturesWithPeople)
            {
                Visible = true,
            };
        }

        private void CheckUnsavedChangesDialog(string details, Action yesAction = null, Action noAction = null)
        {
            if (unsavedChanges)
            {
                var result = MessageBox.Show("Masz niezapisane zmiany w projekcie! " + details, "Niezapisane zmiany",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No && noAction != null)
                    noAction();
                else if (result == DialogResult.Yes & yesAction != null)
                    yesAction();
            }
        }

        private void beforeClose(object sender, FormClosingEventArgs e)
        {
            CheckUnsavedChangesDialog("Czy chcesz je zapisać?", SaveModel);
        }

        private void refreshDirectoryButton_Click(object sender, EventArgs e)
        {
            var newFiles = new List<string>();
            var newOnlyFilenames = new List<string>();
            foreach (var extension in supportedExtensions)
            {
                var loadedFilesForExtension = new List<string>(Directory.GetFiles(directoryPath, extension, SearchOption.AllDirectories));
                foreach (var file in loadedFilesForExtension)
                {
                    if (!picturesWithPeople.ContainsKey(file))
                        newFiles.Add(file);
                }
            }

            var newFilesMessage = newFiles.Count == 0
                ? "Nie znaleziono nowych zdjęć"
                : $"Znaleziono {newFiles.Count} nowych zdjęć";

            MessageBox.Show(newFilesMessage, "Nowe zdjęcia",
                MessageBoxButtons.OK, MessageBoxIcon.Information);


            foreach (var filename in newFiles)
            {
                picturesWithPeople.Add(filename, new List<string>());
                newOnlyFilenames.Add(filename.Replace($"{directoryPath}\\", ""));
            }

            // refresh pictures list
            loadedPicturesList.Items.AddRange(newOnlyFilenames.ToArray());
            var allFilesCount = new List<string>(Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories)).Count;
            var loadedPicturesCount = picturesWithPeople.Count + newFiles.Count;
            allFilesCountLabel.Text = "Plików w folderze: " + allFilesCount;
            loadedFilesCountLabel.Text = "Załadowanych plików: " + loadedPicturesCount;

        }

        public void SaveModel()
        {
            var model = new OuhmaniaModel
            {
                AllPeople = allPeople,
                DirectoryPath = directoryPath,
                PicturesWithPeople = picturesWithPeople,
                CurrentPicturePath = currentPicturePath
            };
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Ouhmania reco files (*.opr)|*.opr|All files (*.*)|*.*";
            saveFileDialog.InitialDirectory = directoryPath;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveFileDialog.OpenFile());
                writer.WriteLine(new JavaScriptSerializer().Serialize(model));
                writer.Dispose();
                writer.Close();
                Text = PROGRAM_NAME + $"({saveFileDialog.FileName})";
            }
            unsavedChanges = false;
        }

        public Tuple<bool, OuhmaniaModel> Load()
        {
            OuhmaniaModel t = new OuhmaniaModel();
            bool success = false;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Ouhmania reco files (*.opr)|*.opr|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(openFileDialog.OpenFile());
                t = new JavaScriptSerializer().Deserialize<OuhmaniaModel>(reader.ReadLine());
                reader.Dispose();
                reader.Close();
                success = true;
                Text = PROGRAM_NAME + $"({openFileDialog.FileName})";
            }
            return new Tuple<bool, OuhmaniaModel>(success, t);
        }
    }
}
