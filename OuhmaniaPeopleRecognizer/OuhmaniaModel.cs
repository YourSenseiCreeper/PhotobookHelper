using OuhmaniaPeopleRecognizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OuhmaniaPeopleRecognizer
{
    public class OuhmaniaModel
    {
        private bool _dirty;

        public bool Dirty
        {
            get => _dirty;
            set => _dirty = value;
        }

        public string Version { get; set; }

        private string _projectPath;
        public string ProjectPath
        {
            get => _projectPath;
            set
            {
                _projectPath = value;
                _dirty = true;
            }
        }

        private string _directoryPath;
        public string DirectoryPath
        {
            get => _directoryPath;
            set
            {
                _directoryPath = value;
                _dirty = true;
            }
        }

        private string _exportPath;
        public string ExportPath
        {
            get => _exportPath;
            set
            {
                _exportPath = value;
                _dirty = true;
            }
        }

        public string CurrentPicturePath { get; set; }
        public bool AutoSave { get; set; }
        public int AutoSaveIntervalInMinutes { get; set; }
        public LastUserSelection LastUserSelection { get; set; }
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

        public int NextPersonId { get; set; }
        public List<string> AllPeople { get; set; }
        public List<Batch> Batches { get; set; }

        public bool HasAlreadyLoadedBatch(string path)
        {
            return Batches.Any(b => b.DirectoryPath == path);
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

        public Dictionary<string, List<string>> PicturesWithPeople { get; set; }

        public IEnumerable<string> SupportedFileExtensions { get; set; }

        public List<string> GetSelectedPeopleForCurrentPicture()
        {
            return PicturesWithPeople.TryGetValue(CurrentPicturePath, out var selectedPeople)
                ? selectedPeople
                : new List<string>();
        }

        public void SetSelectedPeopleForCurrentPicture(List<string> selectedPeople)
        {
            var modelSelectedPeople = PicturesWithPeople[CurrentPicturePath];
            if (modelSelectedPeople != selectedPeople)
            {
                PicturesWithPeople[CurrentPicturePath] = selectedPeople;
                _dirty = true;
            }
        }

        public List<string> GetOnlyFileNames()
        {
            return PicturesWithPeople.Keys.Select(k => k.Replace($"{DirectoryPath}\\", "")).ToList();
        }

        public void AddPerson(string personName)
        {
            AllPeople.Add(personName);
            _dirty = true;
        }

        public void RemovePerson(string personName)
        {
            AllPeople.Remove(personName);
            _dirty = true;
        }
    }
}
