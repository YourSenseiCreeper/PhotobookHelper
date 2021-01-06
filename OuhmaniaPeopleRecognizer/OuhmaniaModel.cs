using System.Collections.Generic;
using System.Linq;

namespace OuhmaniaPeopleRecognizer
{
    public class OuhmaniaModel
    {
        public string Version { get; set; }
        public string ProjectPath { get; set; }
        public string DirectoryPath { get; set; }
        public string ExportPath { get; set; }
        public string CurrentPicturePath { get; set; }
        public bool AutoSave { get; set; }
        public int AutoSaveIntervalInMins { get; set; }
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
            PicturesWithPeople[CurrentPicturePath] = selectedPeople;
        }

        public List<string> GetOnlyFileNames()
        {
            return PicturesWithPeople.Keys.Select(k => k.Replace($"{DirectoryPath}\\", "")).ToList();
        }
    }
}
