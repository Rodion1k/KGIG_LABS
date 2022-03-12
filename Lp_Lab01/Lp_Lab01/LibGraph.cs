using System;
using System.Threading;
using System.Windows.Forms;

namespace Lp_Lab01
{
    public static class LibGraph
    {
        public static void PrintNum(int x, int y, double number, GroupBox ex, string heap)
        {
            Label OutputBox = new Label();
            int TextSize = 10;
            OutputBox.Location = new System.Drawing.Point(x, y);
            OutputBox.AutoSize = true;
            OutputBox.TabIndex = 4;
            OutputBox.AllowDrop = true;
            OutputBox.Text = $"{heap}:\n";
            OutputBox.Text += number;
            OutputBox.Font = new System.Drawing.Font("TimesNewRoman", TextSize);
            OutputBox.ForeColor = System.Drawing.Color.Black;
            OutputBox.Enabled = true;
            OutputBox.Visible = true;
            ex.Controls.Add(OutputBox);
        }
        public static void PrintMatrix(int x, int y, CMatrix matrix, GroupBox ex, string heap)
        {
            Label OutputBox = new Label();
            int TextSize = 10;
            OutputBox.Location  = new System.Drawing.Point(x, y);
            OutputBox.AutoSize = true;
            OutputBox.TabIndex = 4;
            OutputBox.AllowDrop = true;
            OutputBox.Text = $"{heap}:\n";
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Cols; j++)
                {
                    OutputBox.Text += matrix[i, j] + @"    ";
                }
                OutputBox.Text += "\n";
            }
            OutputBox.Font = new System.Drawing.Font("TimesNewRoman", TextSize);
            OutputBox.ForeColor = System.Drawing.Color.Black;
            OutputBox.Enabled = true;
            OutputBox.Visible = true;
            ex.Controls.Add(OutputBox);
        }

        public static void InitMatrix(CMatrix matrix)
        {
            //var result = "";
            Random random = new Random();
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Cols; j++)
                {
                    matrix[i,j] = random.Next(0, 10);
                    Thread.Sleep(1);
                }
            }
        }

        public static void Operarions(CMatrix matrix1, CMatrix matrix2, CMatrix matrix3, CMatrix matrix4, GroupBox ex)
        {
            CMatrix C1 = matrix1 + matrix2;
            CMatrix C2 = matrix1 * matrix2;
            CMatrix D = matrix1 * matrix3;
            CMatrix Q = matrix3.Transp()*matrix4;
            CMatrix P = matrix3.Transp() * matrix1 * matrix4;

            PrintMatrix(180, 30, C1, ex, "C1=A+B");
            PrintMatrix(290, 30, C2, ex, "C2=A*B");
            PrintMatrix(180, 120, D, ex, "D=A*V1");
            PrintMatrix(250, 120, Q, ex ,"Q=V1^T*V2");
            PrintMatrix(350, 120, P, ex,  "P=V1^T*A*V2");
        }
        public static double ModVec(CMatrix v)
        {
            bool b = v.Cols == 1 && v.Rows == 3;
            if (!b)
            {
                string error = "ModVec : неправильная размерность вектора! ";
                MessageBox.Show(
                    error,
                    @"Error",
                    MessageBoxButtons.OK
                );
                Application.Exit();
            }
            return Math.Sqrt(v[0] * v[0] + v[1] * v[1] + v[2] * v[2]);
        }

        public static double ScalarMult(CMatrix v1, CMatrix v2)
        {
            if(!(v1.Cols == 1 && v1.Rows == 3) & (v2.Cols == 1 && v2.Rows == 3))
            {
                string error = "CosV1V2: неправильные размерности векторов! ";
                MessageBox.Show(
                    error,
                    @"Error",
                    MessageBoxButtons.OK
                );
                Application.Exit();
            }
            return v1[0]*v2[0]+v1[1]*v2[1]+v1[2]*v2[2];
        }

        public static CMatrix VectorMult(CMatrix v1, CMatrix v2)
        {
            if(!(v1.Cols == 1 && v1.Rows == 3) & (v2.Cols == 1 && v2.Rows == 3))
            {
                string error = "VectorMult: неправильные размерности векторов! ";
                MessageBox.Show(
                    error,
                    @"Error",
                    MessageBoxButtons.OK
                );
                Application.Exit();
            }

            CMatrix result = new CMatrix(3);
            result[0] = v1[1] * v2[2] - v1[2] * v2[1];
            result[1] = -(v1[0] * v2[2] - v1[2] * v2[0]);
            result[2] = v1[0] * v2[1] - v1[1] * v2[0];
            return result;
        }

        public static double CosV1V2(CMatrix v1, CMatrix v2)
        {
            var modV1 = ModVec(v1);
            var modV2 = ModVec(v2);
            if (modV1 < 1e-7 || modV2 < 1e-7)
            {
                string error = "CosV1V2: модуль одного или обоих векторов < 1e-7! ";
                MessageBox.Show(
                    error,
                    @"Error",
                    MessageBoxButtons.OK
                );
                Application.Exit();
            }

            if (!(v1.Cols == 1 && v1.Rows == 3) & (v2.Cols == 1 && v2.Rows == 3)) // TODO возможно нахуй не упал этот if потому что проверка есть в модуле и скалярке
            {
                string error = "CosV1V2: неправильные размерности векторов! ";
                MessageBox.Show(
                    error,
                    @"Error",
                    MessageBoxButtons.OK
                );
                Application.Exit();
            }
            return ScalarMult(v1,v2)/(modV1*modV2);
        }

        public static CMatrix SphereToCart(CMatrix pView)
        {
            CMatrix result = new CMatrix(3);
            double r = pView[0];
            double fi = pView[1];
            double q = pView[2];
            double fiRad = fi/180*Math.PI;
            double qRad = q/180*Math.PI;
            result[0]=r*Math.Sin(qRad)*Math.Cos(fiRad);	// x- координата точки наблюдения
            result[1]=r*Math.Sin(qRad)*Math.Sin(fiRad);	// y- координата точки наблюдения
            result[2]=r*Math.Cos(qRad);
            return result;
        }
    }
}