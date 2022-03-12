using System.Drawing;
using System.Windows.Forms;

namespace Lp_Lab02
{
    public static class ImageDisplayer
    {
        public static PictureBox PictureBox;
        public static void ShowImage(Point point, GroupBox groupBox)
        {
            PictureBox = new PictureBox();
            PictureBox.MouseDown += ImageRedactor.MouseDownPictureBox;
            PictureBox.MouseUp += ImageRedactor.MouseUpPictureBox;
            PictureBox.MouseMove += ImageRedactor.MouseMovePictureBox;
            PictureBox.Location = groupBox.PointToClient(point);
            PictureBox.ImageLocation = Form1.SelectedFile;
            PictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            groupBox.Controls.Add(PictureBox);
        }
    }
}