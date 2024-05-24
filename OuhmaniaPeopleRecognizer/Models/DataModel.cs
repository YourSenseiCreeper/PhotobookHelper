using Newtonsoft.Json;
using OuhmaniaPeopleRecognizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OuhmaniaPeopleRecognizer
{
    public class DataModel
    {
        private const string VERSION = "1.0";
        [JsonIgnore]
        private const string PROGRAM_NAME = "PhotoCategorizer";
        [JsonIgnore]
        public IEnumerable<string> SupportedFileExtensions => new[] { "*.jpg", "*.png", "*.bmp" };

        private bool _dirty;
        private string _directoryPath;
        private string _projectPath;

        public DataModel()
        {
            //IsAutoSaveActive = autoSave;
            //AutoSaveIntervalInMinutes = autoSaveIntervalInMinutes;
            //DirectoryPath = directoryPath;
            Batches = new List<Batch>();
            PersonAndIndex = new Dictionary<string, int>();
            IndexAndPerson = new Dictionary<int, string>();
            Dirty = false;
        }

        public string GetFormTitle()
        {
            var projectPath = ProjectPath == null ? string.Empty : $"({ProjectPath})";
            return $"{PROGRAM_NAME} v{VERSION} {projectPath}";
        }

        [JsonIgnore]
        public bool IsProjectLoaded { get; set; }

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
        public Dictionary<string, int> PersonAndIndex { get; set; }
        public Dictionary<int, string> IndexAndPerson { get; set; }
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

        public bool HasAlreadyLoadedBatch(string path)
        {
            return Batches.Any(b => b.DirectoryPath == path);
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

        public List<string> GetSelectedPeopleForCurrentPicture()
        {
            var batch = GetBatch(LastUserSelection.BatchId.Value);
            var selectedPeople = batch.PicturePeople[LastUserSelection.ImageName].Select(i => IndexAndPerson[i]).ToList();
            return selectedPeople;
        }

        public bool SetSelectedPeopleForCurrentPicture(List<string> selectedCategories)
        {
            var batch = GetBatch(LastUserSelection.BatchId.Value);
            var currentImagePeople = batch.PicturePeople[LastUserSelection.ImageName];
            var mappedSelectedPeople = selectedCategories.Select(p => PersonAndIndex[p]).ToHashSet();

            if (currentImagePeople != mappedSelectedPeople)
            {
                batch.PicturePeople[LastUserSelection.ImageName] = mappedSelectedPeople;
                _dirty = true;
                return true;
            }
            return false;
        }

        public void AddPerson(string personName)
        {
            PersonAndIndex.Add(personName, ++NextPersonId);
            IndexAndPerson.Add(NextPersonId, personName);

            _dirty = true;
        }

        public void RemovePerson(string personName)
        {
            var personIndex = PersonAndIndex[personName];
            PersonAndIndex.Remove(personName);
            IndexAndPerson.Remove(personIndex);

            _dirty = true;
        }
    }
}
