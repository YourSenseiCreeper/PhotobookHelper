using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuhmaniaPeopleRecognizer.Models
{
    public class Batch
    {
        public Guid Id { get; set; }
        public bool IsDirty { get; set; }
        public string DirectoryPath { get; set; }
        public Dictionary<string, HashSet<int>> PicturePeople { get; set; }
    }
}
