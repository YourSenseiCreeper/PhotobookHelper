using Newtonsoft.Json;
using OuhmaniaPeopleRecognizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OuhmaniaPeopleRecognizer
{
    public class DataModel
    {
        private const string VERSION = "1.0";
        [JsonIgnore]
        private const string PROGRAM_NAME = "PhotoCategorizer";
        [JsonIgnore]
        public IEnumerable<string> SupportedFileExtensions => new[] { "*.jpg", "*.png", "*.bmp" };

        [JsonIgnore]
        public bool IsProjectLoaded { get; set; }

        private bool _dirty;
        private string _directoryPath;
        private string _projectPath;

        public DataModel()
        {
            //IsAutoSaveActive = autoSave;
            //AutoSaveIntervalInMinutes = autoSaveIntervalInMinutes;
            //DirectoryPath = directoryPath;
            Batches = new List<Batch>();
            CategoryAndIndex = new Dictionary<string, int>();
            IndexAndCategory = new Dictionary<int, string>();
            Dirty = false;
            PeopleToDisplay = new List<string>();
        }

        public List<string> PeopleToDisplay { get; set; }

        public string GetFormTitle()
        {
            var projectPath = ProjectPath == null ? string.Empty : $"({ProjectPath})";
            return $"{PROGRAM_NAME} v{VERSION} {projectPath}";
        }

        public bool Dirty
        {
            get => _dirty;
            set => _dirty = value;
        }

        public string ProjectPath
        {
            get => _projectPath;
            set
            {
                _projectPath = value;
                _dirty = true;
            }
        }

        public string DirectoryPath
        {
            get => _directoryPath;
            set
            {
                _directoryPath = value;
                _dirty = true;
            }
        }

        public string ExportPath { get; set; }
        public bool IsAutoSaveActive { get; set; }
        public int AutoSaveIntervalInMinutes { get; set; }
        public LastUserSelection LastUserSelection { get; set; }
        public int NextPersonId { get; set; }
        public Dictionary<string, int> CategoryAndIndex { get; set; }
        public Dictionary<int, string> IndexAndCategory { get; set; }
        public Dictionary<int, string> IndexAndKeyBindings { get; set; }
        public List<Batch> Batches { get; set; }

        public bool HasUserSelectedImage()
        {
            return LastUserSelection.BatchId.HasValue && LastUserSelection.ImageName != null;
        }

        public string GetSelectedImagePath()
        {
            if (!HasUserSelectedImage())
                throw new Exception("No picture has been selected.");

            var selectedBatch = Batches.First(b => b.Id == LastUserSelection.BatchId);
            return selectedBatch.DirectoryPath + LastUserSelection.ImageName;
        }

        public Batch GetBatch(Guid batchId)
        {
            return Batches.FirstOrDefault(b => b.Id == batchId);
        }

        public Batch GetBatchByDirectoryPath(string path)
        {
            return Batches.FirstOrDefault(b => b.DirectoryPath == path);
        }

        public List<string> GetPicturesForPerson(int personIndex)
        {
            var picturesPaths = new List<string>();
            foreach (var batch in Batches)
            {
                foreach (var keyValue in batch.PicturePeople)
                {
                    if (keyValue.Value.Contains(personIndex))
                    {
                        picturesPaths.Add(keyValue.Key);
                    }
                }
            }
            return picturesPaths;
        }

        public List<string> GetSelectedCategoriesForCurrentPicture()
        {
            var batch = GetBatch(LastUserSelection.BatchId.Value);
            var selectedPeople = batch.PicturePeople[LastUserSelection.ImageName].Select(i => IndexAndCategory[i]).ToList();
            return selectedPeople;
        }

        public bool SetSelectedCategoriesForCurrentPicture(List<string> selectedCategories)
        {
            var batch = GetBatch(LastUserSelection.BatchId.Value);
            var currentImagePeople = batch.PicturePeople[LastUserSelection.ImageName];
            var mappedSelectedPeople = selectedCategories.Select(p => CategoryAndIndex[p]).ToHashSet();

            if (currentImagePeople != mappedSelectedPeople)
            {
                batch.PicturePeople[LastUserSelection.ImageName] = mappedSelectedPeople;
                _dirty = true;
                return true;
            }
            return false;
        }

        public void AddCategory(string categoryName, Keys? keyBinding)
        {
            PeopleToDisplay.Add(categoryName);
            CategoryAndIndex.Add(categoryName, ++NextPersonId);
            IndexAndCategory.Add(NextPersonId, categoryName);

            _dirty = true;
        }

        public void EditCategory(string categoryName, string newCategoryName, Keys? keyBinding)
        {
            var categoryId = CategoryAndIndex[categoryName];

            IndexAndCategory[NextPersonId] = newCategoryName;
            CategoryAndIndex.Remove(categoryName);
            CategoryAndIndex.Add(newCategoryName, categoryId);

            PeopleToDisplay.Remove(categoryName);
            PeopleToDisplay.Add(newCategoryName);
            _dirty = true;
        }

        public void RemoveCategory(string categoryName)
        {
            var personIndex = CategoryAndIndex[categoryName];
            PeopleToDisplay.Remove(categoryName);
            CategoryAndIndex.Remove(categoryName);
            IndexAndCategory.Remove(personIndex);

            _dirty = true;
        }
    }
}
