using System.Windows.Forms;

namespace OuhmaniaPeopleRecognizer
{
    public class MainWindowViewModel
    {
        public BindingSource CategoryBindingSource { get; set; }
        public object FormTitle { get; set; }
        public TreeView TreeView1 { get; set; }
        public PictureBox PictureBox1 { get; set; }
        public CheckedListBox PeopleCheckBoxList { get; set; }
        public MenuStrip MenuStrip1 { get; set; }
        public ToolStripSeparator ToolStripSeparator1 { get; set; }
        public SplitContainer SplitContainer1 { get; set; }
        public SplitContainer SplitContainer2 { get; set; }
        public StatusStrip StatusStrip1 { get; set; }
        public ContextMenuStrip PeopleListMenuStrip { get; set; }
        public ContextMenuStrip PictureMenuStrip { get; set; }
        public ToolStripMenuItem FileToolStripMenuItem { get; set; }
        public ToolStripMenuItem LoadProjectToolStripMenuItem { get; set; }
        public ToolStripMenuItem SaveProjectToolStripMenuItem { get; set; }
        public ToolStripMenuItem ExportFilesToolStripMenuItem { get; set; }
        public ToolStripMenuItem CloseProgramToolStripMenuItem { get; set; }
        public ToolStripMenuItem PhotosToolStripMenuItem { get; set; }
        public ToolStripMenuItem LoadPhotosToolStripMenuItem { get; set; }
        public ToolStripMenuItem RescanDirectoryToolStripMenuItem { get; set; }
        public ToolStripMenuItem PersonToolStripMenuItem { get; set; }
        public ToolStripMenuItem AddPersonToolStripMenuItem { get; set; }
        public ToolStripMenuItem RemovePersonToolStripMenuItem { get; set; }
        public ToolStripMenuItem AddPersonToolStripContextMenuItem { get; set; }
        public ToolStripMenuItem DeletePersonToolStripContextMenuItem { get; set; }
        public ToolStripMenuItem RotateRightToolStripMenuItem { get; set; }
        public ToolStripMenuItem RotateLeftToolStripMenuItem { get; set; }
        public ToolStripMenuItem NowyProjektToolStripMenuItem { get; set; }
        public ToolStripStatusLabel LoadedFilesCounttoolStripStatusLabel { get; set; }
        public ToolStripStatusLabel AllFilesCounttoolStripStatusLabel { get; set; }
        public ToolStripStatusLabel FolderPathtoolStripStatusLabel { get; set; }
        public ToolStripStatusLabel AutosaveToolStripStatusLabel { get; set; }
        public ToolStripMenuItem PolishLanguageToolStripMenuItem { get; set; }
        public ToolStripMenuItem EnglishLanguageToolStripMenuItem { get; set; } 
    }
}
