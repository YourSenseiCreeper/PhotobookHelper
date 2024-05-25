using OuhmaniaPeopleRecognizer.Properties;
using System.ComponentModel;
using System.Globalization;

namespace OuhmaniaPeopleRecognizer.ViewManager
{
    public class LanguageManager
    {
        private readonly MainWindowViewModel _viewModel;

        public LanguageManager(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void SubscribeOnEvents()
        {
            _viewModel.PolishLanguageToolStripMenuItem.Click += PolishLanguageToolStripMenuItem_Click;
            _viewModel.EnglishLanguageToolStripMenuItem.Click += EnglishLanguageToolStripMenuItem_Click;
        }

        private void EnglishLanguageToolStripMenuItem_Click(object sender, System.EventArgs e) => LoadLanguage("en-us");
        private void PolishLanguageToolStripMenuItem_Click(object sender, System.EventArgs e) => LoadLanguage("pl-pl");

        private void LoadLanguage(string lang)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainWindow));
            CultureInfo cultureInfo = new CultureInfo(lang);

            var rotateLeft = resources.GetString(nameof(Resources.RotateLeft), cultureInfo);
            resources.ApplyResources(_viewModel.RotateLeftToolStripMenuItem, nameof(Resources.RotateLeft), cultureInfo);
            //doRecursiveLoading(this, cultureInfo, resources);
        }

        //private void doRecursiveLoading(Control parent, CultureInfo cultureInfo, ComponentResourceManager resources)
        //{
        //    foreach (Control c in parent.Controls)
        //    {
        //        resources.ApplyResources(c, c.Name, cultureInfo);
        //        if (c.Controls.Count > 0)
        //            doRecursiveLoading(c, cultureInfo, resources);
        //    }
        //}
    }
}
