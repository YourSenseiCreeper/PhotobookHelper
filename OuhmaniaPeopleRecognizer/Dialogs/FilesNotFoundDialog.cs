using System;
using System.Windows.Forms;

namespace OuhmaniaPeopleRecognizer
{
    public partial class FilesNotFoundDialog : Form
    {
        public FilesNotFoundDialog(string caption)
        {
            InitializeComponent();
            notFoundLabel.Text = caption;
        }

        public void SetValues(string[] notFoundFiles)
        {
            notFoundListBox.Items.AddRange(notFoundFiles);
        }

        public static DialogResult ShowDialog(string title, string caption, string[] notFoundFiles)
        {
            var prompt = new FilesNotFoundDialog(caption)
            {
                Text = title,
                StartPosition = FormStartPosition.CenterScreen
            };
            prompt.SetValues(notFoundFiles);

            return prompt.ShowDialog();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }
    }
}
