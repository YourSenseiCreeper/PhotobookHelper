using OuhmaniaPeopleRecognizer.Properties;
using OuhmaniaPeopleRecognizer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OuhmaniaPeopleRecognizer.Services
{
    public class NotificationService : INotificationService
    {
        public void Info(string title, string message)
        {

        }

        public void Warning(string title, string message)
        {

        }

        public void Error(string title, string message)
        {

        }

        public void ShowMissingFiles(string directoryPath, List<string> missingFiles, Action<string> removeCallback)
        {
            var filesNotFoundDialog = FilesNotFoundDialog.ShowDialog(
                Resources.MainWindow_CheckMissingFiles_FoundMissingFiles_Title,
                string.Format(Resources.MainWindow_CheckMissingFiles_FoundMissingFiles, missingFiles.Count),
                missingFiles.ToArray());

            if (filesNotFoundDialog == DialogResult.Yes)
            {
                foreach (var missingFile in missingFiles)
                {
                    removeCallback(missingFile);
                }
            }
        }
    }
}
