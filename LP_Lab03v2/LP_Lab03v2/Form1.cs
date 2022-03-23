using System;
using System.Linq;
using System.Windows.Forms;

namespace LP_Lab03v2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void func1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controls.Cast<Control>().Where(n => n.GetType() != typeof(MenuStrip)).ToList()
                .ForEach(n => n.Visible = false);
            Drawing drawing = new Drawing(this);
            drawing.DrawingFuncInLocal();
        }

        private void func2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controls.Cast<Control>().Where(n => n.GetType() != typeof(MenuStrip)).ToList()
                .ForEach(n => n.Visible = false);
            Drawing drawing = new Drawing(this);
            drawing.DrawingPictureInLocal();
        }
    }
}