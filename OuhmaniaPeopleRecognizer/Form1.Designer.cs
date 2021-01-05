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
            this.loadedPicturesList = new System.Windows.Forms.ListBox();
            this.peopleCheckBoxList = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dictionaryPathLabel = new System.Windows.Forms.Label();
            this.loadedFilesCountLabel = new System.Windows.Forms.Label();
            this.allFilesCountLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(231, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(92, 268);
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
            // loadedPicturesList
            // 
            this.loadedPicturesList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel1.SetColumnSpan(this.loadedPicturesList, 2);
            this.loadedPicturesList.Cursor = System.Windows.Forms.Cursors.Default;
            this.loadedPicturesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.loadedPicturesList.FormattingEnabled = true;
            this.loadedPicturesList.HorizontalScrollbar = true;
            this.loadedPicturesList.ItemHeight = 16;
            this.loadedPicturesList.Location = new System.Drawing.Point(3, 277);
            this.loadedPicturesList.MinimumSize = new System.Drawing.Size(222, 80);
            this.loadedPicturesList.Name = "loadedPicturesList";
            this.loadedPicturesList.Size = new System.Drawing.Size(320, 260);
            this.loadedPicturesList.TabIndex = 5;
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
            this.peopleCheckBoxList.Size = new System.Drawing.Size(222, 256);
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
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.peopleCheckBoxList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.loadedPicturesList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(636, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(326, 609);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.dictionaryPathLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.loadedFilesCountLabel, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.allFilesCountLabel, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 551);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(320, 48);
            this.tableLayoutPanel2.TabIndex = 13;
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
            this.loadedFilesCountLabel.Size = new System.Drawing.Size(88, 13);
            this.loadedFilesCountLabel.TabIndex = 9;
            this.loadedFilesCountLabel.Text = "Ścieżka do zdjęć";
            // 
            // allFilesCountLabel
            // 
            this.allFilesCountLabel.AutoSize = true;
            this.allFilesCountLabel.Location = new System.Drawing.Point(4, 20);
            this.allFilesCountLabel.Name = "allFilesCountLabel";
            this.allFilesCountLabel.Size = new System.Drawing.Size(88, 13);
            this.allFilesCountLabel.TabIndex = 8;
            this.allFilesCountLabel.Text = "Ścieżka do zdjęć";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 633);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "OuhmaniaPeopleRecognizer v1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.beforeClose);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label loadedFilesCountLabel;
        private System.Windows.Forms.Label dictionaryPathLabel;
        private System.Windows.Forms.Label allFilesCountLabel;
        private System.Windows.Forms.Button removePersonButton;
        private System.Windows.Forms.Button bookCreatorButton;
    }
}

