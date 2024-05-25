using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OuhmaniaPeopleRecognizer.Services.Interfaces
{
    public interface INotificationService
    {
        void Info(string title, string message);
        void Warning(string title, string message);
        void Error(string title, string message);
        DialogResult ShowUnsavedFilesDialog();
        void ShowMissingFiles(string directoryPath, List<string> missingFiles, Action<string> removeCallback);
        bool ShowDeletePerson(string personToDelete);
    }
}
