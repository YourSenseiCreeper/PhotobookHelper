using OuhmaniaPeopleRecognizer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace OuhmaniaPeopleRecognizer
{
    public class OuhmaniaModel
    {
        private bool _dirty;
        private string _directoryPath;
        private string _projectPath;


        public OuhmaniaModel(string version, string[] supportedFileExtensions, bool autoSave, int autoSaveIntervalInMinutes, string directoryPath)
        {
            Version = version;
            SupportedFileExtensions = supportedFileExtensions;
            AutoSave = autoSave;
            AutoSaveIntervalInMinutes = autoSaveIntervalInMinutes;
            DirectoryPath = directoryPath;
            PersonAndIndex = new Dictionary<string, int>();
            Batches = new List<Batch>();
            PersonAndIndex = new Dictionary<string, int>();
            IndexAndPerson = new Dictionary<int, string>();
            Dirty = false;
        }

        public bool Dirty
        {
            get => _dirty;
            set => _dirty = value;
        }

        public string Version { get; set; }

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
        public bool AutoSave { get; set; }
        public int AutoSaveIntervalInMinutes { get; set; }
        public LastUserSelection LastUserSelection { get; set; }
        public int NextPersonId { get; set; }
        public Dictionary<string, int> PersonAndIndex { get; set; }
        public Dictionary<int, string> IndexAndPerson { get; set; }
        public List<Batch> Batches { get; set; }
        public IEnumerable<string> SupportedFileExtensions { get; set; }


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

        public bool SetSelectedPeopleForCurrentPicture(List<string> selectedPeopleNames)
        {
            var batch = GetBatch(LastUserSelection.BatchId.Value);
            var currentImagePeople = batch.PicturePeople[LastUserSelection.ImageName];
            var mappedSelectedPeople = selectedPeopleNames.Select(p => PersonAndIndex[p]).ToHashSet();

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
