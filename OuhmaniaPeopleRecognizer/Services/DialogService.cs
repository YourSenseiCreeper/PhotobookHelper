using OuhmaniaPeopleRecognizer.Properties;
using OuhmaniaPeopleRecognizer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OuhmaniaPeopleRecognizer.Services
{
    public class DialogService : IDialogService
    {
        public DialogResult ShowUnsavedFilesDialog()
        {
            return MessageBox.Show(
                    Resources.MainWindow_CheckUnsavedChangesDialog_Caption,
                    Resources.MainWindow_CheckUnsavedChangesDialog_Title,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
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

        public bool ShowDeletePerson(string personToDelete)
        {
            var dialogInfo = string.Format(Resources.MainWindow_deletePersonToolStripContextMenuItem_Confirm, personToDelete);
            var dialogTitle = Resources.MainWindow_deletePersonToolStripContextMenuItem_ConfirmTitle;
            return MessageBox.Show(dialogInfo, dialogTitle, MessageBoxButtons.YesNo) == DialogResult.Yes;
        }
    }
}
