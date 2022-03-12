using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
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
            Controls.Cast<Control>().Where(n=>n.GetType()!=typeof(MenuStrip)).ToList().ForEach(n=>n.Visible=false);
            Drawing drawing = new Drawing(this);
            drawing.DrawingFuncInWorld();
        }

        private void func2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controls.Cast<Control>().Where(n=>n.GetType()!=typeof(MenuStrip)).ToList().ForEach(n=>n.Visible=false);
            Drawing drawing = new Drawing(this);
            drawing.DrawingPictureInWorld();
        }
    }
}