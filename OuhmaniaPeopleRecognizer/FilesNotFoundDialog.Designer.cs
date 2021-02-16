namespace OuhmaniaPeopleRecognizer
{
    partial class FilesNotFoundDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilesNotFoundDialog));
            this.keepButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.notFoundLabel = new System.Windows.Forms.Label();
            this.notFoundListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // keepButton
            // 
            this.keepButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.keepButton, "keepButton");
            this.keepButton.Name = "keepButton";
            this.keepButton.UseVisualStyleBackColor = true;
            // 
            // removeButton
            // 
            this.removeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.removeButton, "removeButton");
            this.removeButton.Name = "removeButton";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // notFoundLabel
            // 
            resources.ApplyResources(this.notFoundLabel, "notFoundLabel");
            this.notFoundLabel.Name = "notFoundLabel";
            // 
            // notFoundListBox
            // 
            this.notFoundListBox.FormattingEnabled = true;
            resources.ApplyResources(this.notFoundListBox, "notFoundListBox");
            this.notFoundListBox.Name = "notFoundListBox";
            this.notFoundListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            // 
            // FilesNotFoundDialog
            // 
            this.AcceptButton = this.removeButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.keepButton;
            this.Controls.Add(this.notFoundListBox);
            this.Controls.Add(this.notFoundLabel);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.keepButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilesNotFoundDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button keepButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Label notFoundLabel;
        private System.Windows.Forms.ListBox notFoundListBox;
    }
}