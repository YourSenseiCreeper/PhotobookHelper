﻿using OuhmaniaPeopleRecognizer.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OuhmaniaPeopleRecognizer.Services.Interfaces
{
    public interface IFileService
    {
        void CheckMissingFilesForBatch(Batch batch);
        Image LoadImage(string path, double? thumbnailScaleFactor = null);
        int CopyFilesForCategory(string exportPath, string person, List<string> files);

        /// <summary>
        /// Shows SaveProjectDialog to user and saves current state of model to .opr file at
        /// users location
        /// </summary>
        /// <param name="filesFilter">Which files user can pick to save file</param>
        /// <param name="model">Project model having all data</param>
        /// <returns>Whether user picked a file to save or not</returns>
        bool SaveProject(DataModel model);
        bool Autosave(DataModel model);
        DataModel LoadModel(string initialDirectory);
        void LoadDirectory(TreeView treeView, DataModel model, string directoryPath);
    }
}
