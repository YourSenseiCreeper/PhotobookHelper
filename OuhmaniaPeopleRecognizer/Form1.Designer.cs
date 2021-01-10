namespace OuhmaniaPeopleRecognizer
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.loadedFilesInfoTable = new System.Windows.Forms.TableLayoutPanel();
            this.dictionaryPathLabel = new System.Windows.Forms.Label();
            this.loadedFilesCountLabel = new System.Windows.Forms.Label();
            this.allFilesCountLabel = new System.Windows.Forms.Label();
            this.autosaveLabel = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.loadedFilesInfoTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(618, 609);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Layout += new System.Windows.Forms.LayoutEventHandler(this.pictureBox1_Layout);
            // 
            // loadPicturesButton
            // 
            this.loadPicturesButton.Location = new System.Drawing.Point(3, 119);
            this.loadPicturesButton.Name = "loadPicturesButton";
            this.loadPicturesButton.Size = new System.Drawing.Size(75, 36);
            this.loadPicturesButton.TabIndex = 2;
            this.loadPicturesButton.Text = "Załaduj zdjęcia";
            this.loadPicturesButton.UseVisualStyleBackColor = true;
            this.loadPicturesButton.Click += new System.EventHandler(this.LoadPicturesClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.Controls.Add(this.saveTagsButton);
            this.flowLayoutPanel1.Controls.Add(this.loadSettingsButton);
            this.flowLayoutPanel1.Controls.Add(this.addPersonButton);
            this.flowLayoutPanel1.Controls.Add(this.removePersonButton);
            this.flowLayoutPanel1.Controls.Add(this.loadPicturesButton);
            this.flowLayoutPanel1.Controls.Add(this.bookCreatorButton);
            this.flowLayoutPanel1.Controls.Add(this.refreshDirectoryButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(231, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(92, 252);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // saveTagsButton
            // 
            this.saveTagsButton.Location = new System.Drawing.Point(3, 3);
            this.saveTagsButton.Name = "saveTagsButton";
            this.saveTagsButton.Size = new System.Drawing.Size(75, 23);
            this.saveTagsButton.TabIndex = 10;
            this.saveTagsButton.Text = "Zapisz";
            this.saveTagsButton.UseVisualStyleBackColor = true;
            this.saveTagsButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // loadSettingsButton
            // 
            this.loadSettingsButton.Location = new System.Drawing.Point(3, 32);
            this.loadSettingsButton.Name = "loadSettingsButton";
            this.loadSettingsButton.Size = new System.Drawing.Size(75, 23);
            this.loadSettingsButton.TabIndex = 11;
            this.loadSettingsButton.Text = "Wczytaj";
            this.loadSettingsButton.UseVisualStyleBackColor = true;
            this.loadSettingsButton.Click += new System.EventHandler(this.loadSettingsButton_Click);
            // 
            // addPersonButton
            // 
            this.addPersonButton.Enabled = false;
            this.addPersonButton.Location = new System.Drawing.Point(3, 61);
            this.addPersonButton.Name = "addPersonButton";
            this.addPersonButton.Size = new System.Drawing.Size(75, 23);
            this.addPersonButton.TabIndex = 7;
            this.addPersonButton.Text = "Dodaj osobę";
            this.addPersonButton.UseVisualStyleBackColor = true;
            this.addPersonButton.Click += new System.EventHandler(this.AddPersonClicked);
            // 
            // removePersonButton
            // 
            this.removePersonButton.Enabled = false;
            this.removePersonButton.Location = new System.Drawing.Point(3, 90);
            this.removePersonButton.Name = "removePersonButton";
            this.removePersonButton.Size = new System.Drawing.Size(75, 23);
            this.removePersonButton.TabIndex = 12;
            this.removePersonButton.Text = "Usuń osobę";
            this.removePersonButton.UseVisualStyleBackColor = true;
            // 
            // bookCreatorButton
            // 
            this.bookCreatorButton.Location = new System.Drawing.Point(3, 161);
            this.bookCreatorButton.Name = "bookCreatorButton";
            this.bookCreatorButton.Size = new System.Drawing.Size(75, 38);
            this.bookCreatorButton.TabIndex = 13;
            this.bookCreatorButton.Text = "Kreator książek";
            this.bookCreatorButton.UseVisualStyleBackColor = true;
            this.bookCreatorButton.Click += new System.EventHandler(this.bookCreatorButton_Click);
            // 
            // refreshDirectoryButton
            // 
            this.refreshDirectoryButton.Location = new System.Drawing.Point(3, 205);
            this.refreshDirectoryButton.Name = "refreshDirectoryButton";
            this.refreshDirectoryButton.Size = new System.Drawing.Size(75, 38);
            this.refreshDirectoryButton.TabIndex = 14;
            this.refreshDirectoryButton.Text = "Odśwież zdjęcia";
            this.refreshDirectoryButton.UseVisualStyleBackColor = true;
            this.refreshDirectoryButton.Click += new System.EventHandler(this.refreshDirectoryButton_Click);
            // 
            // loadedPicturesList
            // 
            this.loadedPicturesList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.loadedPicturesList.Cursor = System.Windows.Forms.Cursors.Default;
            this.loadedPicturesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.loadedPicturesList.FormattingEnabled = true;
            this.loadedPicturesList.HorizontalScrollbar = true;
            this.loadedPicturesList.ItemHeight = 16;
            this.loadedPicturesList.Location = new System.Drawing.Point(24, 23);
            this.loadedPicturesList.MinimumSize = new System.Drawing.Size(222, 80);
            this.loadedPicturesList.Name = "loadedPicturesList";
            this.loadedPicturesList.Size = new System.Drawing.Size(320, 244);
            this.loadedPicturesList.TabIndex = 5;
            this.loadedPicturesList.Visible = false;
            this.loadedPicturesList.SelectedIndexChanged += new System.EventHandler(this.PictureSelected);
            // 
            // peopleCheckBoxList
            // 
            this.peopleCheckBoxList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.peopleCheckBoxList.CausesValidation = false;
            this.peopleCheckBoxList.CheckOnClick = true;
            this.peopleCheckBoxList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.peopleCheckBoxList.FormattingEnabled = true;
            this.peopleCheckBoxList.HorizontalScrollbar = true;
            this.peopleCheckBoxList.Location = new System.Drawing.Point(3, 3);
            this.peopleCheckBoxList.MinimumSize = new System.Drawing.Size(222, 200);
            this.peopleCheckBoxList.Name = "peopleCheckBoxList";
            this.peopleCheckBoxList.Size = new System.Drawing.Size(222, 235);
            this.peopleCheckBoxList.Sorted = true;
            this.peopleCheckBoxList.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.treeView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.peopleCheckBoxList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.loadedFilesInfoTable, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(636, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(326, 609);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // loadedFilesInfoTable
            // 
            this.loadedFilesInfoTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.loadedFilesInfoTable.ColumnCount = 1;
            this.tableLayoutPanel1.SetColumnSpan(this.loadedFilesInfoTable, 2);
            this.loadedFilesInfoTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.loadedFilesInfoTable.Controls.Add(this.dictionaryPathLabel, 0, 0);
            this.loadedFilesInfoTable.Controls.Add(this.loadedFilesCountLabel, 0, 2);
            this.loadedFilesInfoTable.Controls.Add(this.allFilesCountLabel, 0, 1);
            this.loadedFilesInfoTable.Controls.Add(this.autosaveLabel, 0, 3);
            this.loadedFilesInfoTable.Location = new System.Drawing.Point(3, 519);
            this.loadedFilesInfoTable.Name = "loadedFilesInfoTable";
            this.loadedFilesInfoTable.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.loadedFilesInfoTable.RowCount = 4;
            this.loadedFilesInfoTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.loadedFilesInfoTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.loadedFilesInfoTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.loadedFilesInfoTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.loadedFilesInfoTable.Size = new System.Drawing.Size(320, 73);
            this.loadedFilesInfoTable.TabIndex = 13;
            this.loadedFilesInfoTable.Visible = false;
            // 
            // dictionaryPathLabel
            // 
            this.dictionaryPathLabel.AutoEllipsis = true;
            this.dictionaryPathLabel.AutoSize = true;
            this.dictionaryPathLabel.Location = new System.Drawing.Point(4, 6);
            this.dictionaryPathLabel.Name = "dictionaryPathLabel";
            this.dictionaryPathLabel.Size = new System.Drawing.Size(88, 13);
            this.dictionaryPathLabel.TabIndex = 6;
            this.dictionaryPathLabel.Text = "Ścieżka do zdjęć";
            // 
            // loadedFilesCountLabel
            // 
            this.loadedFilesCountLabel.AutoSize = true;
            this.loadedFilesCountLabel.Location = new System.Drawing.Point(4, 34);
            this.loadedFilesCountLabel.Name = "loadedFilesCountLabel";
            this.loadedFilesCountLabel.Size = new System.Drawing.Size(107, 13);
            this.loadedFilesCountLabel.TabIndex = 9;
            this.loadedFilesCountLabel.Text = "Załadowanych zdjęć";
            // 
            // allFilesCountLabel
            // 
            this.allFilesCountLabel.AutoSize = true;
            this.allFilesCountLabel.Location = new System.Drawing.Point(4, 20);
            this.allFilesCountLabel.Name = "allFilesCountLabel";
            this.allFilesCountLabel.Size = new System.Drawing.Size(94, 13);
            this.allFilesCountLabel.TabIndex = 8;
            this.allFilesCountLabel.Text = "Wszystkich plików";
            // 
            // autosaveLabel
            // 
            this.autosaveLabel.AutoSize = true;
            this.autosaveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.autosaveLabel.Location = new System.Drawing.Point(4, 48);
            this.autosaveLabel.Name = "autosaveLabel";
            this.autosaveLabel.Size = new System.Drawing.Size(73, 18);
            this.autosaveLabel.TabIndex = 10;
            this.autosaveLabel.Text = "Autozapis";
            // 
            // treeView1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.treeView1, 2);
            this.treeView1.Location = new System.Drawing.Point(3, 261);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(320, 252);
            this.treeView1.TabIndex = 14;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSelect);
            this.treeView1.Enter += new System.EventHandler(this.treeView1_Enter);
            this.treeView1.Leave += new System.EventHandler(this.treeView1_Leave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 633);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.loadedPicturesList);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "OuhmaniaPeopleRecognizer v1.0";
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

