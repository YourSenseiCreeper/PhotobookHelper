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
            this.loadPicturesButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.saveTagsButton = new System.Windows.Forms.Button();
            this.loadSettingsButton = new System.Windows.Forms.Button();
            this.addPersonButton = new System.Windows.Forms.Button();
            this.removePersonButton = new System.Windows.Forms.Button();
            this.bookCreatorButton = new System.Windows.Forms.Button();
            this.refreshDirectoryButton = new System.Windows.Forms.Button();
            this.loadedPicturesList = new System.Windows.Forms.ListBox();
            this.peopleCheckBoxList = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.loadedFilesInfoTable = new System.Windows.Forms.TableLayoutPanel();
            this.dictionaryPathLabel = new System.Windows.Forms.Label();
            this.loadedFilesCountLabel = new System.Windows.Forms.Label();
            this.allFilesCountLabel = new System.Windows.Forms.Label();
            this.autosaveLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.loadedFilesInfoTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Layout += new System.Windows.Forms.LayoutEventHandler(this.pictureBox1_Layout);
            // 
            // loadPicturesButton
            // 
            resources.ApplyResources(this.loadPicturesButton, "loadPicturesButton");
            this.loadPicturesButton.Name = "loadPicturesButton";
            this.loadPicturesButton.UseVisualStyleBackColor = true;
            this.loadPicturesButton.Click += new System.EventHandler(this.LoadPicturesClick);
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.saveTagsButton);
            this.flowLayoutPanel1.Controls.Add(this.loadSettingsButton);
            this.flowLayoutPanel1.Controls.Add(this.addPersonButton);
            this.flowLayoutPanel1.Controls.Add(this.removePersonButton);
            this.flowLayoutPanel1.Controls.Add(this.loadPicturesButton);
            this.flowLayoutPanel1.Controls.Add(this.bookCreatorButton);
            this.flowLayoutPanel1.Controls.Add(this.refreshDirectoryButton);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // saveTagsButton
            // 
            resources.ApplyResources(this.saveTagsButton, "saveTagsButton");
            this.saveTagsButton.Name = "saveTagsButton";
            this.saveTagsButton.UseVisualStyleBackColor = true;
            this.saveTagsButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // loadSettingsButton
            // 
            resources.ApplyResources(this.loadSettingsButton, "loadSettingsButton");
            this.loadSettingsButton.Name = "loadSettingsButton";
            this.loadSettingsButton.UseVisualStyleBackColor = true;
            this.loadSettingsButton.Click += new System.EventHandler(this.loadSettingsButton_Click);
            // 
            // addPersonButton
            // 
            resources.ApplyResources(this.addPersonButton, "addPersonButton");
            this.addPersonButton.Name = "addPersonButton";
            this.addPersonButton.UseVisualStyleBackColor = true;
            this.addPersonButton.Click += new System.EventHandler(this.AddPersonClicked);
            // 
            // removePersonButton
            // 
            resources.ApplyResources(this.removePersonButton, "removePersonButton");
            this.removePersonButton.Name = "removePersonButton";
            this.removePersonButton.UseVisualStyleBackColor = true;
            // 
            // bookCreatorButton
            // 
            resources.ApplyResources(this.bookCreatorButton, "bookCreatorButton");
            this.bookCreatorButton.Name = "bookCreatorButton";
            this.bookCreatorButton.UseVisualStyleBackColor = true;
            this.bookCreatorButton.Click += new System.EventHandler(this.bookCreatorButton_Click);
            // 
            // refreshDirectoryButton
            // 
            resources.ApplyResources(this.refreshDirectoryButton, "refreshDirectoryButton");
            this.refreshDirectoryButton.Name = "refreshDirectoryButton";
            this.refreshDirectoryButton.UseVisualStyleBackColor = true;
            this.refreshDirectoryButton.Click += new System.EventHandler(this.refreshDirectoryButton_Click);
            // 
            // loadedPicturesList
            // 
            resources.ApplyResources(this.loadedPicturesList, "loadedPicturesList");
            this.loadedPicturesList.Cursor = System.Windows.Forms.Cursors.Default;
            this.loadedPicturesList.FormattingEnabled = true;
            this.loadedPicturesList.Name = "loadedPicturesList";
            this.loadedPicturesList.SelectedIndexChanged += new System.EventHandler(this.PictureSelected);
            // 
            // peopleCheckBoxList
            // 
            resources.ApplyResources(this.peopleCheckBoxList, "peopleCheckBoxList");
            this.peopleCheckBoxList.CausesValidation = false;
            this.peopleCheckBoxList.CheckOnClick = true;
            this.peopleCheckBoxList.FormattingEnabled = true;
            this.peopleCheckBoxList.Name = "peopleCheckBoxList";
            this.peopleCheckBoxList.Sorted = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.treeView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.peopleCheckBoxList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.loadedFilesInfoTable, 0, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // treeView1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.treeView1, 2);
            resources.ApplyResources(this.treeView1, "treeView1");
            this.treeView1.Name = "treeView1";
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSelect);
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
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.loadedPicturesList);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.beforeClose);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.loadedFilesInfoTable.ResumeLayout(false);
            this.loadedFilesInfoTable.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button loadPicturesButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button saveTagsButton;
        private System.Windows.Forms.Button loadSettingsButton;
        private System.Windows.Forms.Button addPersonButton;
        private System.Windows.Forms.ListBox loadedPicturesList;
        private System.Windows.Forms.CheckedListBox peopleCheckBoxList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel loadedFilesInfoTable;
        private System.Windows.Forms.Label loadedFilesCountLabel;
        private System.Windows.Forms.Label dictionaryPathLabel;
        private System.Windows.Forms.Label allFilesCountLabel;
        private System.Windows.Forms.Button removePersonButton;
        private System.Windows.Forms.Button bookCreatorButton;
        private System.Windows.Forms.Button refreshDirectoryButton;
        private System.Windows.Forms.Label autosaveLabel;
        private System.Windows.Forms.TreeView treeView1;
    }
}

