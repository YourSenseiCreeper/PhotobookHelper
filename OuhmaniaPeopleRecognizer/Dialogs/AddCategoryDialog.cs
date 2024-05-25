using PhotoCategorizer.i18N;
using System.Windows.Forms;

namespace OuhmaniaPeopleRecognizer
{
    public partial class AddCategoryDialog : Form
    {
        private bool _isKeyAssignmentActive = false;
        private Keys? _assignedKey;

        public AddCategoryDialog()
        {
            InitializeComponent();
            Text = Resources.AddCategoryDialog_Title;
            descriptionLabel.Text = Resources.AddCategoryDialog_Text;
            okButton.Text = Resources.AddCategoryDialog_Ok;
            assignActivationKey.Text = Resources.AddCategoryDialog_AssignCategoryKey;
        }

        private string GetInputValue() => inputTextBox.Text;

        public AddCategoryDialogResult ShowCategoryDialog()
        {
            var prompt = new AddCategoryDialog()
            {
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen
            };

            // using base method
            if (prompt.ShowDialog() != DialogResult.OK)
                return null;

            var categoryName = prompt.GetInputValue();
            return new AddCategoryDialogResult
            {
                CategoryName = categoryName,
                AssignedKey = _assignedKey
            };
        }

        private void okButton_Click(object sender, System.EventArgs e) => Close();

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (_isKeyAssignmentActive)
            {
                assignActivationKey.Text = string.Format(Resources.AddCategoryDialog_AssignedKey, keyData);
                _assignedKey = keyData;
                _isKeyAssignmentActive = false;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void assignActivationKey_Click(object sender, System.EventArgs e)
        {
            _isKeyAssignmentActive = true;
            assignActivationKey.Text = Resources.AddCategoryDialog_WaitingForKey;
        }
    }

    public class AddCategoryDialogResult
    {
        public string CategoryName { get; set; }
        public Keys? AssignedKey { get; set; }
    }
}
