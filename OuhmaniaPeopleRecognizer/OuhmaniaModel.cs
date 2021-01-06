using System;
using System.Collections.Generic;

namespace OuhmaniaPeopleRecognizer
{
    public class OuhmaniaModel
    {
        public string DirectoryPath { get; set; }
        public string CurrentPicturePath { get; set; }
        public string ProjectPath { get; set; }
        public bool AutoSave { get; set; }
        public List<string> AllPeople { get; set; }
        public Dictionary<string, List<string>> PicturesWithPeople { get; set; }
    }
}
