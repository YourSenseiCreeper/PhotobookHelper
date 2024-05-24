using OuhmaniaPeopleRecognizer.Properties;
using OuhmaniaPeopleRecognizer.Services.Interfaces;
using System;
using System.Windows.Threading;

namespace OuhmaniaPeopleRecognizer.ViewManager
{
    public class AutosaveManager
    {
        private DispatcherTimer _timer;
        private readonly IFileService _fileService;
        private readonly MainWindowViewModel _viewModel;
        private readonly DataModel _model;

        public AutosaveManager(IFileService fileService, MainWindowViewModel viewModel, DataModel dataModel)
        {
            _fileService = fileService;
            _viewModel = viewModel;
            _model = dataModel;
        }

        public void SetTimer()
        {
            _timer = new DispatcherTimer(DispatcherPriority.SystemIdle);
            _timer.Tick += OnAutosave;
            _timer.Interval = TimeSpan.FromMilliseconds(_model.AutoSaveIntervalInMinutes * 1000 * 60);
            _timer.Start();
        }

        private void OnAutosave(object source, EventArgs e)
        {
            var success = _fileService.Autosave(_model);
            if (success)
            {
                //unsavedChanges = false;
                _viewModel.AutosaveToolStripStatusLabel.Text = GetAutosaveLabel(true);
            }
        }

        private string GetAutosaveLabel(bool autosaved = false)
        {
            var autosave = _model.IsAutoSaveActive ? Resources.MainWindow_Autosave_On : Resources.MainWindow_Autosave_Off;
            return autosaved ? string.Format(Resources.MainWindow_Autosave_Status, autosave, DateTime.Now.ToShortTimeString()) : autosave;
        }
    }
}
