using Newtonsoft.Json;
using OuhmaniaPeopleRecognizer.Models;
using OuhmaniaPeopleRecognizer.Services.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WebPWrapper;

namespace OuhmaniaPeopleRecognizer.Services
{
    public class FileService : IFileService
    {
        private const string FILES_FILTER = "PhotoCategorizer project files (*.pcproj)|*.pcproj|All files (*.*)|*.*";
        private const string WEBP_EXTENSION = ".webp";

        private readonly INotificationService _notificationService;
        private readonly WebP webpWrapper;

        public FileService(INotificationService notificationService)
        {
            _notificationService = notificationService;
            webpWrapper = new WebP();
        }

        public void CheckMissingFilesForBatch(Batch batch)
        {
            var missingFiles = new List<string>();
            foreach (var file in batch.PicturePeople.Keys)
            {
                var path = batch.DirectoryPath + "\\" + file;
                if (!File.Exists(path))
                {
                    missingFiles.Add(path);
                }
            }

            if (missingFiles.Count != 0)
            {
                _notificationService.ShowMissingFiles(batch.DirectoryPath, missingFiles, file => batch.PicturePeople.Remove(file));
            }
        }

        public System.Drawing.Image LoadImage(string path, double? thumbnailScaleFactor = null)
        {
            if (!File.Exists(path))
            {
                return new Bitmap(20, 20);
            }

            if (path.EndsWith(WEBP_EXTENSION))
            {
                return webpWrapper.Load(path);
            }
            else
            {
                System.Drawing.Image resultImage = null;
                using (var stream = File.OpenRead(path))
                using (var image = Image.FromStream(stream))
                {
                    //var loadedImage = System.Drawing.Image.FromStream(stream);
                    //loadedImage.RotateFlip(RotateFlipType.Rotate90FlipXY);
                    //var image = System.Drawing.Image.FromStream(stream);
                    if (thumbnailScaleFactor != null)
                    {
                        var desiredHeight = (int)(image.Height * thumbnailScaleFactor.Value);
                        var desiredWidth = (int) (image.Width * thumbnailScaleFactor.Value);
                        resultImage = image.GetThumbnailImage(desiredWidth, desiredHeight, default, default);
                    }
                    else
                    {
                        resultImage = image;
                    }
                }

                return resultImage;
            }
        }

        public int CopyFilesForPerson(string exportPath, string person, List<string> files)
        {
            var exportedFiles = 0;
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
            if (allSize + 1000000 * 5 >= currentDrive.AvailableFreeSpace)
            {
                _notificationService.Warning(
                    "Brak wolnego miejsca!", $"Nie masz już więcej wolnego miejsca w folderze, do którego chcesz eksportować zdjęcia ({folderPath})");
                return 0;
            }

            foreach (var file in files)
            {
                // TODO: Make a tool for comparing images with identical names and show them side by side.
                var filename = file.Substring(file.LastIndexOf("\\") + 1);

                var filepath = folderPath + "\\" + filename;
                if (File.Exists(filepath))
                {
                    var duplicatesDirectoryPath = folderPath + "\\Duplikaty";
                    filepath = folderPath + "\\Duplikaty\\" + filename;
                    _notificationService.Warning("Powtórzony plik!", $"Znaleziono powtórkę zdjęcia ({filepath}). Zostanie dodane do folderu Duplikaty");

                    if (!Directory.Exists(duplicatesDirectoryPath))
                    {
                        Directory.CreateDirectory(duplicatesDirectoryPath);
                    }

                }

                File.Copy(file, filepath);
                exportedFiles++;
            }

            return exportedFiles;
        }

        public void LoadDirectory(TreeView treeView, DataModel model, string directoryPath)
        {
            var stack = new Stack<TreeNode>();

            var rootDirectory = new DirectoryInfo(directoryPath);
            // check whether batch with this patch exists
            // TODO: Worth to rescan whole folder looking for new 

            // skan głównego folderu
            // jeżeli główny folder już ma swój batch - sprawdź czy zmieniły się pliki
            // skan podfolderów - dodanie ich do listy 

            var node = new TreeNode(rootDirectory.Name) { Tag = rootDirectory };
            stack.Push(node);

            var batches = new List<Batch>() { new Batch(directoryPath) };
            var missingFiles = new List<string>();

            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();

                var directoryInfo = (DirectoryInfo)currentNode.Tag;
                var currentBatch = batches.First(b => b.DirectoryPath == directoryInfo.FullName);
                var existingBatchFromModel = model.GetBatchByDirectoryPath(directoryInfo.FullName);
                var existingBatchFiles = existingBatchFromModel != null ? existingBatchFromModel.PicturePeople.Keys.ToHashSet() : new HashSet<string>();

                foreach (var directory in directoryInfo.GetDirectories())
                {
                    var childDirectoryNode = new TreeNode(directory.Name) { Tag = directory };
                    currentNode.Nodes.Add(childDirectoryNode);
                    stack.Push(childDirectoryNode);
                    batches.Add(new Batch(directory.FullName));
                }

                foreach (var file in directoryInfo.GetFiles())
                {
                    var extension = "*" + file.Name.Substring(file.Name.LastIndexOf("."));
                    if (model.SupportedFileExtensions.Contains(extension))
                    {
                        currentNode.Nodes.Add(new TreeNode(file.Name));
                        var shortPath = file.FullName.Replace(directoryInfo.FullName, "");
                        currentBatch.PicturePeople.Add(shortPath, new HashSet<int>());
                        if (existingBatchFromModel != null && !existingBatchFiles.Contains(shortPath))
                        {
                            missingFiles.Add(file.FullName);
                        }
                    }
                }
            }

            treeView.Nodes.Add(node);
            model.Batches.AddRange(batches);
        }

        public bool SaveProject(DataModel model)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = FILES_FILTER,
                InitialDirectory = model.DirectoryPath
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                model.ProjectPath = saveFileDialog.FileName;
                var serialized = JsonConvert.SerializeObject(model);
                File.WriteAllText(saveFileDialog.FileName, serialized);
                return true;
            }
            return false;
        }

        public bool Autosave(DataModel model)
        {
            if (model.ProjectPath == null)
                return false;

            try
            {
                var serialized = JsonConvert.SerializeObject(model);
                File.WriteAllText(model.ProjectPath, serialized);
                return true;
            }
            catch (IOException exception)
            {
                _notificationService.Error("Error", exception.Message);
                return false;
            }
        }

        public DataModel LoadModel(string initialDirectory)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = FILES_FILTER,
                InitialDirectory = initialDirectory
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return null;

            try
            {
                var text = File.ReadAllText(openFileDialog.FileName);
                var model = JsonConvert.DeserializeObject<DataModel>(text);
                return model;
            }
            catch (IOException e)
            {
                _notificationService.Error("Error", e.Message);
                return null;
            }
        }
    }
}
