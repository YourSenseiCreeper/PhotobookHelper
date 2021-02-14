﻿namespace OuhmaniaPeopleRecognizer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
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
            this.SuspendLayout();
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
            this.rotateRightToolStripMenuItem.Click += new System.EventHandler(this.rotateRightToolStripMenuItem_Click);
            // 
            // rotateLeftToolStripMenuItem
            // 
            this.rotateLeftToolStripMenuItem.Name = "rotateLeftToolStripMenuItem";
            resources.ApplyResources(this.rotateLeftToolStripMenuItem, "rotateLeftToolStripMenuItem");
            this.rotateLeftToolStripMenuItem.Click += new System.EventHandler(this.rotateLeftToolStripMenuItem_Click);
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
            this.addPersonToolStripContextMenuItem.Click += new System.EventHandler(this.addPersonToolStripContextMenuItem_Click);
            // 
            // deletePersonToolStripContextMenuItem
            // 
            this.deletePersonToolStripContextMenuItem.Name = "deletePersonToolStripContextMenuItem";
            resources.ApplyResources(this.deletePersonToolStripContextMenuItem, "deletePersonToolStripContextMenuItem");
            this.deletePersonToolStripContextMenuItem.Click += new System.EventHandler(this.deletePersonToolStripContextMenuItem_Click);
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            resources.ApplyResources(this.treeView1, "treeView1");
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.HideSelection = false;
            this.treeView1.ItemHeight = 18;
            this.treeView1.Name = "treeView1";
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSelect);
            this.treeView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            this.treeView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView1_DragEnter);
            this.treeView1.Enter += new System.EventHandler(this.treeView1_Enter);
            this.treeView1.Leave += new System.EventHandler(this.treeView1_Leave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.photosToolStripMenuItem,
            this.personToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadProjectToolStripMenuItem,
            this.saveProjectToolStripMenuItem,
            this.exportFilesToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeProgramToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // loadProjectToolStripMenuItem
            // 
            this.loadProjectToolStripMenuItem.Name = "loadProjectToolStripMenuItem";
            resources.ApplyResources(this.loadProjectToolStripMenuItem, "loadProjectToolStripMenuItem");
            this.loadProjectToolStripMenuItem.Click += new System.EventHandler(this.loadProjectToolStripMenuItem_Click);
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            resources.ApplyResources(this.saveProjectToolStripMenuItem, "saveProjectToolStripMenuItem");
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
            // 
            // exportFilesToolStripMenuItem
            // 
            this.exportFilesToolStripMenuItem.Name = "exportFilesToolStripMenuItem";
            resources.ApplyResources(this.exportFilesToolStripMenuItem, "exportFilesToolStripMenuItem");
            this.exportFilesToolStripMenuItem.Click += new System.EventHandler(this.exportFilesToolStripMenuItem_Click);
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
            this.loadPhotosToolStripMenuItem.Click += new System.EventHandler(this.loadPhotosToolStripMenuItem_Click);
            // 
            // rescanDirectoryToolStripMenuItem
            // 
            this.rescanDirectoryToolStripMenuItem.Name = "rescanDirectoryToolStripMenuItem";
            resources.ApplyResources(this.rescanDirectoryToolStripMenuItem, "rescanDirectoryToolStripMenuItem");
            this.rescanDirectoryToolStripMenuItem.Click += new System.EventHandler(this.rescanDirectoryToolStripMenuItem_Click);
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
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckedListBox peopleCheckBoxList;
        private System.Windows.Forms.TreeView treeView1;
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
    }
}

