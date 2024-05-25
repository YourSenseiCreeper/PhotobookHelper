using System;
using System.Collections.Generic;

namespace OuhmaniaPeopleRecognizer.Models
{
    /// <summary>
    /// Is an abstraction for dictionary containing pictures
    /// </summary>
    public class Batch
    {
        public Batch(string directoryPath)
        {
            Id = Guid.NewGuid();
            IsDirty = false;
            DirectoryPath = directoryPath;
            PicturePeople = new Dictionary<string, HashSet<int>>();
        }

        public Guid Id { get; set; }
        public bool IsDirty { get; set; }
        public string DirectoryPath { get; set; }
        public Dictionary<string, HashSet<int>> PicturePeople { get; set; }
    }
}
