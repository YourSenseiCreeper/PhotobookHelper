using PhotoCategorizer.i18N;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace OuhmaniaPeopleRecognizer.ViewManager
{
    public class LanguageManager
    {
        private readonly MainWindowViewModel _viewModel;
        private readonly MainWindow _window;
        public LanguageManager(MainWindow window, MainWindowViewModel viewModel)
        {
            _window = window;
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
            var cultureInfo = CultureInfo.GetCultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Resources.Culture = new CultureInfo(lang);

            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainWindow));
            doRecursiveLoading(_window, cultureInfo, resources);
        }

        private void doRecursiveLoading(Control parent, CultureInfo cultureInfo, ComponentResourceManager resources)
        {
            // it does not access MenuStrips and do not translate them
            foreach (Control c in parent.Controls)
            {
                resources.ApplyResources(c, c.Name, cultureInfo);
                if (c.Controls.Count > 0)
                    doRecursiveLoading(c, cultureInfo, resources);
            }
        }
    }
}
