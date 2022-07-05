using OuhmaniaPeopleRecognizer.Models;
using System.Drawing;

namespace OuhmaniaPeopleRecognizer.Services.Interfaces
{
    public interface IFileService
    {
        void CheckMissingFilesForBatch(Batch batch);
        Image LoadImage(string path);
    }
}
