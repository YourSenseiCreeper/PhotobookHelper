using System.Windows.Forms;
using OuhmaniaPeopleRecognizer;
using OuhmaniaPeopleRecognizer.Models;

namespace PhotobookHelperTests
{
    [TestClass]
    public class LoadTreeViewTests
    {
        [TestMethod]
        public void LoadTreeView_CorrectTree_WhenListOfUnrelatedDirectories()
        {
            var treeView = new TreeView();
            var mainWindow = new MainWindow();
            var model = new OuhmaniaModel("0", Array.Empty<string>(), false, 5, "");
            model.Batches = new List<Batch>
            {
                new Batch("C:\\zdjecia"),
                new Batch("C:\\test"),
                new Batch("C:\\nowe\\zdjecia")
            };

            mainWindow.LoadTreeViewFromModel(treeView, model);
            Assert.AreEqual(treeView.Nodes.Count, 3);
        }
    }
}