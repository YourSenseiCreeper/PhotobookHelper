using PhotoCategorizer.i18N;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OuhmaniaPeopleRecognizer
{
    public partial class ErrorDialog : Form
    {
        public ErrorDialog(Exception ex)
        {
            InitializeComponent();
            Text = Resources.ErrorDialog_Title;
            closeButton.Text = Resources.ErrorDialog_Close;
            
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;
            errorTextBox.Lines = GetErrorLines(ex);
        }

        private string[] GetErrorLines(Exception ex)
        {
            return new List<string> { ex.Message, ex.StackTrace }.ToArray();
        }

        private void okButton_Click(object sender, System.EventArgs e) => Close();
    }
}
