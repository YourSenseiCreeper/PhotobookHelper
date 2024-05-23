﻿using OuhmaniaPeopleRecognizer.Commands;
using OuhmaniaPeopleRecognizer.Commands.Abstraction;
using OuhmaniaPeopleRecognizer.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OuhmaniaPeopleRecognizer.ViewManager
{
    public class TreeViewManager
    {
        private readonly MainWindowViewModel _viewModel;
        private readonly DataModel _dataModel;
        private readonly ICommandFactory _commandFactory;

        private readonly TreeView _treeView;

        public TreeViewManager(MainWindowViewModel viewModel, DataModel dataModel, ICommandFactory commandFactory)
        {
            _viewModel = viewModel;
            _dataModel = dataModel;
            _treeView = viewModel.TreeView1;
            _commandFactory = commandFactory;
        }

        public void SubscribeOnEvents()
        {
            _treeView.AfterSelect += TreeViewSelect;
            _treeView.DragEnter += treeView1_DragEnter;
        }

        private void TreeViewSelect(object sender, TreeViewEventArgs e)
        {
            if (_treeView.SelectedNode.Nodes.Count != 0)
            {
                _viewModel.PictureBox1.Image = new Bitmap(20, 20);
                _viewModel.PeopleCheckBoxList.Enabled = false;
                return;
            }

            _viewModel.PeopleCheckBoxList.Enabled = true;
            _commandFactory.Get(Command.SaveCurrentPictureSelections).Execute(null, null);

            // disposing
            GC.Collect();
            _viewModel.PictureBox1.Image.Dispose();

            // load new picture
            var allNodes = _treeView.Nodes;
            var rootNode = allNodes[0];
            var selectedNode = _treeView.SelectedNode;
            var batchPath = selectedNode.FullPath.Replace($"\\{selectedNode.Text}", "");
            var selectedBatch = _dataModel.Batches.First(b => b.DirectoryPath.EndsWith(batchPath));
            _dataModel.LastUserSelection.BatchId = selectedBatch.Id;
            _dataModel.LastUserSelection.ImageName = $"\\{selectedNode.Text}";
            
            _commandFactory.Get(Command.LoadCurrentImage).Execute(null, null);
            _commandFactory.Get(Command.UpdateCategoryCheckboxes).Execute(null, null);
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        public void LoadTreeViewFromModel()
        {
            // scan for unique paths (shortest, then add longest that is extension to this node)
            // 
            // albo stworzyć drzewko guidów i w zależności od tego drzewka wczytywać wszystko
            var rootBatches = new List<Batch>();

            // podejście 2
            // grupujemy po ilości ukośników
            // pierwsza grupa z najmniejszą ilością \ to foldery główne
            // pozostałe to podrzędne które należy dobrze dopasować do istniejących folderów głównych


            // C:\\zdjecia
            // C:\\wakacje
            // C:\\zdjecia\morze
            // D:\\rodzinne\pamiatki
            // D:\\rodzinne\babcia


            // podejście 3 - odsiewowe
            // biorę pierwszego batcha i jego DirectoryPath
            // splituję po \\ i szukam ile batchy zaczyna się od tego fragmentu
            // jeżeli wszystkie za pierwszym razem zapisuję ten początek do zmiennej startPath
            // jeżeli znowu wszystkie - dodaję to do startPath i zapisuję nazwę tego Node'a
            // jeżeli już mniej tworzę tamtego Node'a i istniejące w tej grupie Nody (odcinając początek i dalszą część (tylko do nazwy obecnego noda)
            // iteruję dalej i powtarzam operację
            // jeżeli liczba istniejących tak samo zaczyznających się nodów  jest równa 1 (tylko ten node) to dodaj zawartość noda i przejdź do kolejnego

            // wystarczy wyszukać unikalne root node'y i dodać je. Następnie przeiterować po wszystkich batchach i dodawać brakujące nody i pliki

            _viewModel.TreeView1.Nodes.Clear();
            var directoryPathBatch = _dataModel.Batches.ToDictionary(b => b.DirectoryPath, b => b);
            foreach (var batch in _dataModel.Batches)
            {
                // zakładamy, że ścieżka C:\pliki\podfolder jest bardziej nadrzędna od C:\pliki\podfolder\zdjecia
                // jeżeli jest częścią ścieżki już dodanej. W drugą stronę to nie zadziała
                var moreRootBatch = rootBatches.FirstOrDefault(b => batch.DirectoryPath.Contains(b.DirectoryPath));
                if (moreRootBatch != null)
                {
                    rootBatches.Remove(moreRootBatch);
                    rootBatches.Add(batch);
                }
                else
                {
                    rootBatches.Add(batch);
                    // dodaj
                }
            }
        }
    }
}