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
        public List<string> AllPeople { get; set; }
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
