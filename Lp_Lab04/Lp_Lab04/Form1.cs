using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lp_Lab04
{
    public partial class Form1 : Form
    {
        private SunSystem sunSystem;
        public Form1()
        {
            InitializeComponent();
            
            //sunSystem.Drawing();

        }
        

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void TimerTick(object sender, EventArgs e)
        {
            sunSystem.Drawing();
            pictureBox1.Invalidate();
            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            sunSystem.StartDrawing(e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sunSystem = new SunSystem(pictureBox1);
        }
    }
}