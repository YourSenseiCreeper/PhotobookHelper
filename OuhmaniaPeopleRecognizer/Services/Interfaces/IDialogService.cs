using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OuhmaniaPeopleRecognizer.Services.Interfaces
{
    public interface IDialogService
    {
        bool ShowDeletePerson(string personToDelete);
        void ShowMissingFiles(string directoryPath, List<string> missingFiles, Action<string> removeCallback);
        DialogResult ShowUnsavedFilesDialog();
    }
}