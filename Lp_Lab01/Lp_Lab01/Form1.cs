using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lp_Lab01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void ExitMenuItemClick(object sender, EventArgs e) //TODO переименовать методы начинаются с глагола 
        {
            Application.Exit();
        }

        private void FunctionsMenuItemClick(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();
            CChildView childView = new CChildView();
            LibGraph.PrintMatrix(10, 30, childView.V1, groupBox1, "V1");
            LibGraph.PrintMatrix(90, 30, childView.V2, groupBox1, "V2");
            CMatrix vectorMul = LibGraph.VectorMult(childView.V1, childView.V2);
            LibGraph.PrintMatrix(10, 120, vectorMul, groupBox1, "vectorMul");

            double scalarMul = LibGraph.ScalarMult(childView.V1, childView.V2);
            LibGraph.PrintNum(150, 120, scalarMul, groupBox1, "scalarMul");
        }

        private void MatrixMenuItemClick(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();
            CChildView childView = new CChildView();
            LibGraph.PrintMatrix(10, 30, childView.A, groupBox1, "A");
            LibGraph.PrintMatrix(90, 30, childView.B, groupBox1, "B");
            LibGraph.PrintMatrix(10, 120, childView.V1, groupBox1, "V1");
            LibGraph.PrintMatrix(90, 120, childView.V2, groupBox1, "V2");
            LibGraph.Operarions(childView.A, childView.B, childView.V1, childView.V2, groupBox1);
        }
    }
}