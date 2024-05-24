using System;
using System.Drawing;

namespace OuhmaniaPeopleRecognizer.ViewManager
{
    public class PictureBoxManager
    {
        private readonly MainWindowViewModel _viewModel;
        public PictureBoxManager(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void SubscriveOnEvents()
        {
            _viewModel.RotateLeftToolStripMenuItem.Click += rotateLeftToolStripMenuItem_Click;
            _viewModel.RotateRightToolStripMenuItem.Click += rotateRightToolStripMenuItem_Click;
        }

        private void rotateRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currentImage = _viewModel.PictureBox1.Image;
            currentImage.RotateFlip(RotateFlipType.Rotate270FlipXY);
            _viewModel.PictureBox1.Image = currentImage;
        }

        private void rotateLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currentImage = _viewModel.PictureBox1.Image;
            currentImage.RotateFlip(RotateFlipType.Rotate90FlipXY);
            _viewModel.PictureBox1.Image = currentImage;
        }
    }
}
