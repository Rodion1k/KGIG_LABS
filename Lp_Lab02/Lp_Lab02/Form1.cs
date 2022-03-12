using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lp_Lab02
{
    public partial class Form1 : Form
    {
        public static bool ImageItemClick { get; set; }
        public static string SelectedFile { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void ClickAddImageMenuItem(object sender, EventArgs e)
        {
            mainGroupBox.Controls.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if (!string.IsNullOrWhiteSpace(openFileDialog.FileName))
            {
                SelectedFile = openFileDialog.FileName;
                ImageItemClick = true;
            }
        }

        private void ClickSaveImageMenuItem(object sender, EventArgs e)
        {
            if (!ImageItemClick)
            {
                MessageBox.Show
                (@"You need to add an image",
                    @"warning",
                    MessageBoxButtons.OK
                );
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = @"Images |*.bmp;";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ImageDisplayer.PictureBox.Image.Save(saveFileDialog.FileName);
                MessageBox.Show
                (@"Image saved",
                    @"notification",
                    MessageBoxButtons.OK
                );
                ImageItemClick = false;
            }
        }

        private void ClickMainGroupBox(object sender, EventArgs e)
        {
            if (ImageItemClick)
            {
                Point point = new Point(MousePosition.X, MousePosition.Y);
                ImageDisplayer.ShowImage(point, mainGroupBox);
            }
        }
    }
}