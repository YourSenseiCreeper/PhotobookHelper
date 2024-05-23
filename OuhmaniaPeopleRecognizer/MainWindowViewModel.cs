namespace OuhmaniaPeopleRecognizer
{
    public class MainWindowViewModel
    {
        public System.Windows.Forms.TreeView TreeView1 { get; set; }
        public System.Windows.Forms.PictureBox PictureBox1 { get; set; }
        public System.Windows.Forms.CheckedListBox PeopleCheckBoxList { get; set; }
        public System.Windows.Forms.MenuStrip MenuStrip1 { get; set; }
        public System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem { get; set; }
        public System.Windows.Forms.ToolStripMenuItem LoadProjectToolStripMenuItem { get; set; }
        public System.Windows.Forms.ToolStripMenuItem SaveProjectToolStripMenuItem { get; set; }
        public System.Windows.Forms.ToolStripMenuItem ExportFilesToolStripMenuItem { get; set; }
        public System.Windows.Forms.ToolStripSeparator ToolStripSeparator1 { get; set; }
        public System.Windows.Forms.ToolStripMenuItem CloseProgramToolStripMenuItem { get; set; }
        public System.Windows.Forms.ToolStripMenuItem PhotosToolStripMenuItem { get; set; }
        public System.Windows.Forms.ToolStripMenuItem LoadPhotosToolStripMenuItem { get; set; }
        public System.Windows.Forms.ToolStripMenuItem RescanDirectoryToolStripMenuItem { get; set; }
        public System.Windows.Forms.ToolStripMenuItem PersonToolStripMenuItem { get; set; }
        public System.Windows.Forms.ToolStripMenuItem AddPersonToolStripMenuItem { get; set; }
        public System.Windows.Forms.ToolStripMenuItem RemovePersonToolStripMenuItem { get; set; }
        public System.Windows.Forms.SplitContainer SplitContainer1 { get; set; }
        public System.Windows.Forms.SplitContainer SplitContainer2 { get; set; }
        public System.Windows.Forms.StatusStrip StatusStrip1 { get; set; }
        public System.Windows.Forms.ToolStripStatusLabel LoadedFilesCounttoolStripStatusLabel { get; set; }
        public System.Windows.Forms.ToolStripStatusLabel AllFilesCounttoolStripStatusLabel { get; set; }
        public System.Windows.Forms.ContextMenuStrip PeopleListMenuStrip { get; set; }
        public System.Windows.Forms.ToolStripMenuItem AddPersonToolStripContextMenuItem { get; set; }
        public System.Windows.Forms.ToolStripMenuItem DeletePersonToolStripContextMenuItem { get; set; }
        public System.Windows.Forms.ToolStripStatusLabel FolderPathtoolStripStatusLabel { get; set; }
        public System.Windows.Forms.ContextMenuStrip PictureMenuStrip { get; set; }
        public System.Windows.Forms.ToolStripMenuItem RotateRightToolStripMenuItem { get; set; }
        public System.Windows.Forms.ToolStripMenuItem RotateLeftToolStripMenuItem { get; set; }
        public System.Windows.Forms.ToolStripStatusLabel AutosaveToolStripStatusLabel { get; set; }
        public System.Windows.Forms.ToolStripMenuItem NowyProjektToolStripMenuItem { get; set; }
    }
}
