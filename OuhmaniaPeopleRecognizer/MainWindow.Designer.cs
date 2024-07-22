namespace OuhmaniaPeopleRecognizer
{
    partial class MainWindow
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rotateRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peopleCheckBoxList = new System.Windows.Forms.CheckedListBox();
            this.peopleListMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addPersonToolStripContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletePersonToolStripContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nowyProjektToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.photosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadPhotosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rescanDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removePersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.loadedFilesCounttoolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.allFilesCounttoolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.folderPathtoolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.autosaveToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.singleCategoryContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pictureMenuStrip.SuspendLayout();
            this.peopleListMenuStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.singleCategoryContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem});
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(optionsToolStripMenuItem, "optionsToolStripMenuItem");
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.polishToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.languageToolStripMenuItem.Name = global::OuhmaniaPeopleRecognizer.Properties.Settings.Default.languageMenuItemBinding;
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // polishToolStripMenuItem
            // 
            this.polishToolStripMenuItem.Name = "polishToolStripMenuItem";
            resources.ApplyResources(this.polishToolStripMenuItem, "polishToolStripMenuItem");
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.ContextMenuStrip = this.pictureMenuStrip;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // pictureMenuStrip
            // 
            this.pictureMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.pictureMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotateRightToolStripMenuItem,
            this.rotateLeftToolStripMenuItem});
            this.pictureMenuStrip.Name = "pictureMenuStrip";
            resources.ApplyResources(this.pictureMenuStrip, "pictureMenuStrip");
            // 
            // rotateRightToolStripMenuItem
            // 
            this.rotateRightToolStripMenuItem.Name = "rotateRightToolStripMenuItem";
            resources.ApplyResources(this.rotateRightToolStripMenuItem, "rotateRightToolStripMenuItem");
            // 
            // rotateLeftToolStripMenuItem
            // 
            this.rotateLeftToolStripMenuItem.Name = "rotateLeftToolStripMenuItem";
            resources.ApplyResources(this.rotateLeftToolStripMenuItem, "rotateLeftToolStripMenuItem");
            // 
            // peopleCheckBoxList
            // 
            resources.ApplyResources(this.peopleCheckBoxList, "peopleCheckBoxList");
            this.peopleCheckBoxList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.peopleCheckBoxList.CausesValidation = false;
            this.peopleCheckBoxList.CheckOnClick = true;
            this.peopleCheckBoxList.ContextMenuStrip = this.peopleListMenuStrip;
            this.peopleCheckBoxList.FormattingEnabled = true;
            this.peopleCheckBoxList.Name = "peopleCheckBoxList";
            this.peopleCheckBoxList.Sorted = true;
            // 
            // peopleListMenuStrip
            // 
            this.peopleListMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.peopleListMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPersonToolStripContextMenuItem,
            this.deletePersonToolStripContextMenuItem});
            this.peopleListMenuStrip.Name = "peopleListMenuStrip";
            resources.ApplyResources(this.peopleListMenuStrip, "peopleListMenuStrip");
            // 
            // addPersonToolStripContextMenuItem
            // 
            this.addPersonToolStripContextMenuItem.Name = "addPersonToolStripContextMenuItem";
            resources.ApplyResources(this.addPersonToolStripContextMenuItem, "addPersonToolStripContextMenuItem");
            // 
            // deletePersonToolStripContextMenuItem
            // 
            this.deletePersonToolStripContextMenuItem.Name = "deletePersonToolStripContextMenuItem";
            resources.ApplyResources(this.deletePersonToolStripContextMenuItem, "deletePersonToolStripContextMenuItem");
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            resources.ApplyResources(this.treeView1, "treeView1");
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.HideSelection = false;
            this.treeView1.ItemHeight = 18;
            this.treeView1.Name = "treeView1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.photosToolStripMenuItem,
            this.personToolStripMenuItem,
            optionsToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nowyProjektToolStripMenuItem,
            this.loadProjectToolStripMenuItem,
            this.saveProjectToolStripMenuItem,
            this.exportFilesToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeProgramToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // nowyProjektToolStripMenuItem
            // 
            this.nowyProjektToolStripMenuItem.Name = "nowyProjektToolStripMenuItem";
            resources.ApplyResources(this.nowyProjektToolStripMenuItem, "nowyProjektToolStripMenuItem");
            // 
            // loadProjectToolStripMenuItem
            // 
            this.loadProjectToolStripMenuItem.Name = "loadProjectToolStripMenuItem";
            resources.ApplyResources(this.loadProjectToolStripMenuItem, "loadProjectToolStripMenuItem");
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            resources.ApplyResources(this.saveProjectToolStripMenuItem, "saveProjectToolStripMenuItem");
            // 
            // exportFilesToolStripMenuItem
            // 
            this.exportFilesToolStripMenuItem.Name = "exportFilesToolStripMenuItem";
            resources.ApplyResources(this.exportFilesToolStripMenuItem, "exportFilesToolStripMenuItem");
            this.exportFilesToolStripMenuItem.Text = global::OuhmaniaPeopleRecognizer.Properties.Settings.Default.exportToDirectoriesMenuItemLabel;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // closeProgramToolStripMenuItem
            // 
            this.closeProgramToolStripMenuItem.Name = "closeProgramToolStripMenuItem";
            resources.ApplyResources(this.closeProgramToolStripMenuItem, "closeProgramToolStripMenuItem");
            this.closeProgramToolStripMenuItem.Click += new System.EventHandler(this.closeProgramToolStripMenuItem_Click);
            // 
            // photosToolStripMenuItem
            // 
            this.photosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadPhotosToolStripMenuItem,
            this.rescanDirectoryToolStripMenuItem});
            this.photosToolStripMenuItem.Name = "photosToolStripMenuItem";
            resources.ApplyResources(this.photosToolStripMenuItem, "photosToolStripMenuItem");
            // 
            // loadPhotosToolStripMenuItem
            // 
            this.loadPhotosToolStripMenuItem.Name = "loadPhotosToolStripMenuItem";
            resources.ApplyResources(this.loadPhotosToolStripMenuItem, "loadPhotosToolStripMenuItem");
            // 
            // rescanDirectoryToolStripMenuItem
            // 
            this.rescanDirectoryToolStripMenuItem.Name = "rescanDirectoryToolStripMenuItem";
            resources.ApplyResources(this.rescanDirectoryToolStripMenuItem, "rescanDirectoryToolStripMenuItem");
            // 
            // personToolStripMenuItem
            // 
            this.personToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPersonToolStripMenuItem,
            this.removePersonToolStripMenuItem});
            this.personToolStripMenuItem.Name = "personToolStripMenuItem";
            resources.ApplyResources(this.personToolStripMenuItem, "personToolStripMenuItem");
            // 
            // addPersonToolStripMenuItem
            // 
            this.addPersonToolStripMenuItem.Name = "addPersonToolStripMenuItem";
            resources.ApplyResources(this.addPersonToolStripMenuItem, "addPersonToolStripMenuItem");
            // 
            // removePersonToolStripMenuItem
            // 
            this.removePersonToolStripMenuItem.Name = "removePersonToolStripMenuItem";
            resources.ApplyResources(this.removePersonToolStripMenuItem, "removePersonToolStripMenuItem");
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.TabStop = false;
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.peopleCheckBoxList);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.treeView1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadedFilesCounttoolStripStatusLabel,
            this.allFilesCounttoolStripStatusLabel,
            this.folderPathtoolStripStatusLabel,
            this.autosaveToolStripStatusLabel});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // loadedFilesCounttoolStripStatusLabel
            // 
            this.loadedFilesCounttoolStripStatusLabel.Name = "loadedFilesCounttoolStripStatusLabel";
            resources.ApplyResources(this.loadedFilesCounttoolStripStatusLabel, "loadedFilesCounttoolStripStatusLabel");
            // 
            // allFilesCounttoolStripStatusLabel
            // 
            this.allFilesCounttoolStripStatusLabel.Name = "allFilesCounttoolStripStatusLabel";
            resources.ApplyResources(this.allFilesCounttoolStripStatusLabel, "allFilesCounttoolStripStatusLabel");
            // 
            // folderPathtoolStripStatusLabel
            // 
            this.folderPathtoolStripStatusLabel.Name = "folderPathtoolStripStatusLabel";
            resources.ApplyResources(this.folderPathtoolStripStatusLabel, "folderPathtoolStripStatusLabel");
            // 
            // autosaveToolStripStatusLabel
            // 
            resources.ApplyResources(this.autosaveToolStripStatusLabel, "autosaveToolStripStatusLabel");
            this.autosaveToolStripStatusLabel.Name = "autosaveToolStripStatusLabel";
            // 
            // singleCategoryContextMenuStrip
            // 
            this.singleCategoryContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.singleCategoryContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editPersonToolStripMenuItem});
            this.singleCategoryContextMenuStrip.Name = "singleCategoryContextMenuStrip";
            resources.ApplyResources(this.singleCategoryContextMenuStrip, "singleCategoryContextMenuStrip");
            // 
            // editPersonToolStripMenuItem
            // 
            this.editPersonToolStripMenuItem.Name = "editPersonToolStripMenuItem";
            resources.ApplyResources(this.editPersonToolStripMenuItem, "editPersonToolStripMenuItem");
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.beforeClose);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pictureMenuStrip.ResumeLayout(false);
            this.peopleListMenuStrip.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.singleCategoryContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckedListBox peopleCheckBoxList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem closeProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem photosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadPhotosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rescanDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removePersonToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel loadedFilesCounttoolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel allFilesCounttoolStripStatusLabel;
        private System.Windows.Forms.ContextMenuStrip peopleListMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addPersonToolStripContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletePersonToolStripContextMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel folderPathtoolStripStatusLabel;
        private System.Windows.Forms.ContextMenuStrip pictureMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem rotateRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel autosaveToolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem nowyProjektToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        public System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip singleCategoryContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editPersonToolStripMenuItem;
    }
}

