using OuhmaniaPeopleRecognizer.Models;
using OuhmaniaPeopleRecognizer.Services.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using WebPWrapper;

namespace OuhmaniaPeopleRecognizer.Services
{
    public class FileService : IFileService
    {
        private readonly INotificationService _notificationService;
        private WebP webpWrapper;

        public FileService(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public void CheckMissingFilesForBatch(Batch batch)
        {
            var missingFiles = new List<string>();
            foreach (var file in batch.PicturePeople.Keys)
            {
                if (!File.Exists(file))
                {
                    missingFiles.Add(file);
                }
            }

            if (missingFiles.Count != 0)
            {
                _notificationService.ShowMissingFiles(batch.DirectoryPath, missingFiles, file => batch.PicturePeople.Remove(file));
            }
        }

        public Image LoadImage(string path)
        {
            if (!File.Exists(path))
            {
                return new Bitmap(20, 20);
            }

            if (path.EndsWith(".webp"))
            {
                return webpWrapper.Load(path);
            }
            else
            {
                using (var stream = File.OpenRead(path))
                {
                    var loadedImage = Image.FromStream(stream);
                    loadedImage.RotateFlip(RotateFlipType.Rotate90FlipXY);
                    return Image.FromStream(stream);
                }
            }
        }
    }
}
