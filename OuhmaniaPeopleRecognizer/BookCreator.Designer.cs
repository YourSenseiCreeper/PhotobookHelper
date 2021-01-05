namespace OuhmaniaPeopleRecognizer
{
    partial class BookCreator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.peopleChechboxList = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.exportButton = new System.Windows.Forms.Button();
            this.pickDirectoryButton = new System.Windows.Forms.Button();
            this.pathOrErrorLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.peopleChechboxList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(218, 523);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // peopleChechboxList
            // 
            this.peopleChechboxList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.peopleChechboxList.CheckOnClick = true;
            this.peopleChechboxList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.peopleChechboxList.FormattingEnabled = true;
            this.peopleChechboxList.Location = new System.Drawing.Point(3, 3);
            this.peopleChechboxList.Name = "peopleChechboxList";
            this.peopleChechboxList.Size = new System.Drawing.Size(212, 424);
            this.peopleChechboxList.Sorted = true;
            this.peopleChechboxList.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.exportButton, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.pickDirectoryButton, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.pathOrErrorLabel, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 443);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(212, 77);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exportButton.Enabled = false;
            this.exportButton.Location = new System.Drawing.Point(3, 45);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(206, 29);
            this.exportButton.TabIndex = 0;
            this.exportButton.Text = "Zbierz zdjęcia dla zaznaczonych osób";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // pickDirectoryButton
            // 
            this.pickDirectoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pickDirectoryButton.Location = new System.Drawing.Point(3, 16);
            this.pickDirectoryButton.Name = "pickDirectoryButton";
            this.pickDirectoryButton.Size = new System.Drawing.Size(206, 23);
            this.pickDirectoryButton.TabIndex = 1;
            this.pickDirectoryButton.Text = "Wybierz folder";
            this.pickDirectoryButton.UseVisualStyleBackColor = true;
            this.pickDirectoryButton.Click += new System.EventHandler(this.pickDirectoryButton_Click);
            // 
            // pathOrErrorLabel
            // 
            this.pathOrErrorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathOrErrorLabel.AutoEllipsis = true;
            this.pathOrErrorLabel.AutoSize = true;
            this.pathOrErrorLabel.Location = new System.Drawing.Point(3, 0);
            this.pathOrErrorLabel.Name = "pathOrErrorLabel";
            this.pathOrErrorLabel.Size = new System.Drawing.Size(206, 13);
            this.pathOrErrorLabel.TabIndex = 2;
            this.pathOrErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BookCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 537);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BookCreator";
            this.Text = "BookCreator";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckedListBox peopleChechboxList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button pickDirectoryButton;
        private System.Windows.Forms.Label pathOrErrorLabel;
    }
}