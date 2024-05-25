using System.Windows.Forms;
using OuhmaniaPeopleRecognizer;
using OuhmaniaPeopleRecognizer.Commands.Abstraction;
using OuhmaniaPeopleRecognizer.Models;
using OuhmaniaPeopleRecognizer.ViewManager;

namespace PhotobookHelperTests
{
    [TestClass]
    public class LoadTreeViewTests
    {
        [TestMethod]
        public void LoadTreeView_CorrectTree_WhenListOfUnrelatedDirectories()
        {
            var treeView = new TreeView();
            var mainWindowViewModel = new MainWindow().LoadFromMainWindow();
            var model = new DataModel
            {
                IsAutoSaveActive = false,
                ExportPath = string.Empty,
                AutoSaveIntervalInMinutes = 5,
            };
            var commandFactory = new CommandFactory(null, model, mainWindowViewModel);
            var treeViewManager = new TreeViewManager(mainWindowViewModel, model, commandFactory);
            model.Batches = new List<Batch>
            {
                new("C:\\zdjecia"),
                new("C:\\test"),
                new("C:\\nowe\\zdjecia")
            };

            treeViewManager.LoadTreeViewFromModel();
            Assert.AreEqual(treeView.Nodes.Count, 3);
        }
    }
}