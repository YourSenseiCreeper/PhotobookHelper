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
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Warning(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void Error(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public DialogResult ShowUnsavedFilesDialog()
        {
            return MessageBox.Show(
                    Resources.UnsavedChangesDialog_Text,
                    Resources.UnsavedChangesDialog_Title,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
        }

        public void ShowMissingFiles(string directoryPath, List<string> missingFiles, Action<string> removeCallback)
        {
            var filesNotFoundDialog = FilesNotFoundDialog.ShowDialog(
                Resources.CheckMissingFilesDialog_FoundMissingFiles_Title,
                string.Format(Resources.CheckMissingFilesDialog_FoundMissingFiles, missingFiles.Count),
                missingFiles.ToArray());

            if (filesNotFoundDialog == DialogResult.Yes)
            {
                foreach (var missingFile in missingFiles)
                {
                    removeCallback(missingFile);
                }
            }
        }

        public bool ShowDeletePerson(string personToDelete)
        {
            var dialogInfo = string.Format(Resources.RemoveCategoryDialog_Text, personToDelete);
            var dialogTitle = Resources.RemoveCategoryDialog_Title;
            return MessageBox.Show(dialogInfo, dialogTitle, MessageBoxButtons.YesNo) == DialogResult.Yes;
        }
    }
}
