using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lp_Lab02
{
    public static class ImageRedactor
    {
        static Rectangle selRect;
        static Point orig;
        static Pen pen = new Pen(Brushes.Blue, 0.8f) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
        private static bool _leftClick;

        public static void MouseDownPictureBox(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.Paint += SelectionPaint;
            orig = e.Location; 
            _leftClick = true;
        }

        public static void MouseUpPictureBox(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            pictureBox.Paint -= SelectionPaint;
            pictureBox.Invalidate();
            Bitmap bmp = new Bitmap(selRect.Width + selRect.X, selRect.Height + selRect.Y);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawImage(pictureBox.Image, selRect.X, selRect.Y, selRect, GraphicsUnit.Pixel);
            }

            _leftClick = false;
            //Возвращаем кусок картинки.
            pictureBox.Image = bmp;
        }

        private static void SelectionPaint(object sender, PaintEventArgs e) =>
            e.Graphics.DrawRectangle(pen, selRect);

        public static void MouseMovePictureBox(object sender, MouseEventArgs e)
        {
            if (!_leftClick) return;
            selRect = GetSelRectangle(orig, e.Location);
            if (e.Button == MouseButtons.Left)
                ((PictureBox)sender).Refresh();
        }

        private static Rectangle GetSelRectangle(Point orig, Point location)
        {
            int deltaX = location.X - orig.X, deltaY = location.Y - orig.Y;
            Size s = new Size(Math.Abs(deltaX), Math.Abs(deltaY));
            Rectangle rect = new Rectangle();
            if (deltaX >= 0 & deltaY >= 0) // из левого верхнего 
                rect = new Rectangle(orig, s);
            else if (deltaX < 0 & deltaY > 0) // из правого верхнего 
                rect = new Rectangle(location.X, orig.Y, s.Width, s.Height);
            else if (deltaX < 0 & deltaY < 0) // из правого нижнего 
                rect = new Rectangle(location, s);
            else if (deltaX > 0 & deltaY < 0) // из левого нижнего 
                rect = new Rectangle(orig.X, location.Y, s.Width, s.Height);
            return rect;
        }
    }
}