using System.Windows.Forms;

namespace OuhmaniaPeopleRecognizer
{
    public partial class AddPersonDialog : Form
    {
        public AddPersonDialog(string caption)
        {
            InitializeComponent();
            descriptionLabel.Text = caption;
        }

        private string GetInputValue() => inputTextBox.Text;

        public static string ShowDialog(string title, string caption)
        {
            var prompt = new AddPersonDialog(caption)
            {
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterScreen
            };

            return prompt.ShowDialog() == DialogResult.OK ? prompt.GetInputValue() : null;
        }

        private void okButton_Click(object sender, System.EventArgs e) => Close();
    }
}
