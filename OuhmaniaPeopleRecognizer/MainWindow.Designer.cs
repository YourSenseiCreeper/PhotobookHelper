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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.peopleCheckBoxList = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.loadedFilesInfoTable = new System.Windows.Forms.TableLayoutPanel();
            this.dictionaryPathLabel = new System.Windows.Forms.Label();
            this.loadedFilesCountLabel = new System.Windows.Forms.Label();
            this.allFilesCountLabel = new System.Windows.Forms.Label();
            this.autosaveLabel = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.loadedFilesInfoTable.SuspendLayout();
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
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Layout += new System.Windows.Forms.LayoutEventHandler(this.pictureBox1_Layout);
            // 
            // peopleCheckBoxList
            // 
            this.peopleCheckBoxList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.peopleCheckBoxList.CausesValidation = false;
            this.peopleCheckBoxList.CheckOnClick = true;
            resources.ApplyResources(this.peopleCheckBoxList, "peopleCheckBoxList");
            this.peopleCheckBoxList.FormattingEnabled = true;
            this.peopleCheckBoxList.Name = "peopleCheckBoxList";
            this.peopleCheckBoxList.Sorted = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.treeView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.loadedFilesInfoTable, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.treeView1, "treeView1");
            this.treeView1.HideSelection = false;
            this.treeView1.ItemHeight = 18;
            this.treeView1.Name = "treeView1";
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSelect);
            this.treeView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            this.treeView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView1_DragEnter);
            this.treeView1.Enter += new System.EventHandler(this.treeView1_Enter);
            this.treeView1.Leave += new System.EventHandler(this.treeView1_Leave);
            // 
            // loadedFilesInfoTable
            // 
            resources.ApplyResources(this.loadedFilesInfoTable, "loadedFilesInfoTable");
            this.tableLayoutPanel1.SetColumnSpan(this.loadedFilesInfoTable, 2);
            this.loadedFilesInfoTable.Controls.Add(this.dictionaryPathLabel, 0, 0);
            this.loadedFilesInfoTable.Controls.Add(this.loadedFilesCountLabel, 0, 2);
            this.loadedFilesInfoTable.Controls.Add(this.allFilesCountLabel, 0, 1);
            this.loadedFilesInfoTable.Controls.Add(this.autosaveLabel, 0, 3);
            this.loadedFilesInfoTable.Name = "loadedFilesInfoTable";
            // 
            // dictionaryPathLabel
            // 
            this.dictionaryPathLabel.AutoEllipsis = true;
            resources.ApplyResources(this.dictionaryPathLabel, "dictionaryPathLabel");
            this.dictionaryPathLabel.Name = "dictionaryPathLabel";
            // 
            // loadedFilesCountLabel
            // 
            resources.ApplyResources(this.loadedFilesCountLabel, "loadedFilesCountLabel");
            this.loadedFilesCountLabel.Name = "loadedFilesCountLabel";
            // 
            // allFilesCountLabel
            // 
            resources.ApplyResources(this.allFilesCountLabel, "allFilesCountLabel");
            this.allFilesCountLabel.Name = "allFilesCountLabel";
            // 
            // autosaveLabel
            // 
            resources.ApplyResources(this.autosaveLabel, "autosaveLabel");
            this.autosaveLabel.Name = "autosaveLabel";
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
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadedFilesCounttoolStripStatusLabel,
            this.allFilesCounttoolStripStatusLabel});
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.loadedFilesInfoTable.ResumeLayout(false);
            this.loadedFilesInfoTable.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel loadedFilesInfoTable;
        private System.Windows.Forms.Label loadedFilesCountLabel;
        private System.Windows.Forms.Label dictionaryPathLabel;
        private System.Windows.Forms.Label allFilesCountLabel;
        private System.Windows.Forms.Label autosaveLabel;
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
    }
}

