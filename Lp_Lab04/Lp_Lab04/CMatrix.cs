using System;
using System.Windows.Forms;

namespace Lp_Lab01
{
    public class CMatrix
    {
        private double[,] _array;
        public int Rows { get; private set; }

        public int Cols { get; private set; }

        public double this[int i, int j]
        {
            get { return _array[i, j]; }
            set { _array[i, j] = value; }
        }

        public double this[int i]
        {
            get { return _array[i, 0]; }
            set { _array[i, 0] = value; }
        }

        public void Show()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                    Console.Write(_array[i, j]);
                Console.WriteLine();
            }
        }


        public CMatrix()
        {
            Rows = 1;
            Cols = 1;
            _array = new double[Rows, Cols];
        }

        public CMatrix(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            _array = new double[Rows, Cols];
        }

        public CMatrix(int rows)
        {
            Rows = rows;
            Cols = 1;
            _array = new double[Rows, Cols];
        }

        public CMatrix(CMatrix matrix)
        {
            Rows = matrix.Rows;
            Cols = matrix.Cols;
            _array = new double[Rows, Cols];
            for (int i = 0; i < Rows; i++)
            for (int j = 0; j < Cols; j++)
                _array[i, j] = matrix[i, j];
        }

        public static CMatrix operator +(CMatrix matrix1, CMatrix matrix2)
        {
            bool bb = matrix1.Rows == matrix2.Rows && matrix1.Cols == matrix2.Cols;
            if (!bb)
            {
                string error = "CMatrix::operator(+): несоответствие размерностей матриц";
                MessageBox.Show(
                    error,
                    @"Error",
                    MessageBoxButtons.OK
                );
                Application.Exit();
            }

            CMatrix resultMatrix = new CMatrix(matrix1.Rows, matrix1.Cols);
            for (int i = 0; i < matrix1.Rows; i++)
            for (int j = 0; j < matrix1.Cols; j++)
                resultMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
            return resultMatrix;
        }

        public static CMatrix operator -(CMatrix matrix1, CMatrix matrix2)
        {
            bool bb = matrix1.Rows == matrix2.Rows && matrix1.Cols == matrix2.Cols;
            if (!bb)
            {
                string error = "CMatrix::operator(-): несоответствие размерностей матриц";
                MessageBox.Show(
                    error,
                    @"Error",
                    MessageBoxButtons.OK
                );
                Application.Exit();
            }

            CMatrix resultMatrix = new CMatrix(matrix1.Rows, matrix1.Cols);
            for (int i = 0; i < matrix1.Rows; i++)
            for (int j = 0; j < matrix1.Cols; j++)
                resultMatrix[i, j] = matrix1[i, j] - matrix2[i, j];
            return resultMatrix;
        }

        public static CMatrix operator -(CMatrix matrix1)
        {
            CMatrix resultMatrix = new CMatrix(matrix1.Rows, matrix1.Cols);
            for (int i = 0; i < matrix1.Rows; i++)
            for (int j = 0; j < matrix1.Cols; j++)
                resultMatrix[i, j] -= matrix1[i, j];
            return resultMatrix;
        }

        public static CMatrix operator *(CMatrix matrix1, CMatrix matrix2)
        {
            bool bb = matrix2.Rows == matrix1.Cols;
            double sum = 0;
            if (!bb)
            {
                string error = "CMatrix::operator(*): несоответствие размерностей матриц";
                MessageBox.Show(
                    error,
                    @"Error",
                    MessageBoxButtons.OK
                );
                Application.Exit();
            }

            CMatrix resultMatrix = new CMatrix(matrix1.Rows, matrix2.Cols);
            for (int i = 0; i < matrix1.Rows; i++)
            for (int j = 0; j < matrix2.Cols; j++)
            {
                sum = 0;
                for (int k = 0; k < matrix1.Cols; k++)
                    sum += matrix1[i, k] * matrix2[k, j];
                resultMatrix[i, j] = sum;
            }

            return resultMatrix;
        }


        public static CMatrix operator +(CMatrix matrix1, double x)
        {
            CMatrix resultMatrix = new CMatrix(matrix1.Rows, matrix1.Cols);
            for (int i = 0; i < matrix1.Rows; i++)
            for (int j = 0; j < matrix1.Cols; j++)
                resultMatrix[i, j] = matrix1[i, j] + x;
            return resultMatrix;
        }

        public static CMatrix operator -(CMatrix matrix1, double x)
        {
            CMatrix resultMatrix = new CMatrix(matrix1.Rows, matrix1.Cols);
            for (int i = 0; i < matrix1.Rows; i++)
            for (int j = 0; j < matrix1.Cols; j++)
                resultMatrix[i, j] = matrix1[i, j] - x;
            return resultMatrix;
        }

        public CMatrix Transp()
        {
            CMatrix resultMatrix = new CMatrix(Cols, Rows);
            for (int i = 0; i < Cols; i++)
            for (int j = 0; j < Rows; j++)
                resultMatrix[i, j] = _array[j, i];
            return resultMatrix;
        }

        public CMatrix GetRow(int k)
        {
            if (k > Rows - 1)
            {
                string error = "CMatrix::GetRow(int k): параметр k превышает число строк";
                MessageBox.Show(
                    error,
                    @"Error",
                    MessageBoxButtons.OK
                );
                Application.Exit();
            }

            CMatrix resultMatrix = new CMatrix(1, Cols);
            for (int i = 0; i < Cols; i++)
                resultMatrix[0, i] = _array[k, i];
            return resultMatrix;
        }

        public CMatrix GetRow(int k, int n, int m)
        {
            bool b1 = k >= 0 && k < Rows;
            bool b2 = n >= 0 && n <= m;
            bool b3 = m >= 0 && m < Cols;
            bool b4 = b1 && b2 && b3;
            if (!b4)
            {
                string error = "CMatrix::GetRow(int k,int n, int m):ошибка в параметрах ";
                MessageBox.Show(
                    error,
                    @"Error",
                    MessageBoxButtons.OK
                );
                Application.Exit();
            }

            int cols = m - n + 1;
            CMatrix resultMatrix = new CMatrix(1, cols);
            for (int i = n; i <= m; i++)
                resultMatrix[0, i - n] = _array[k, i];
            return resultMatrix;
        }

        public CMatrix GetCol(int k)
        {
            if (k > Cols - 1)
            {
                string error = "CMatrix::GetCol(int k): параметр k превышает число строк";
                MessageBox.Show(
                    error,
                    @"Error",
                    MessageBoxButtons.OK
                );
                Application.Exit();
            }

            CMatrix resultMatrix = new CMatrix(Rows, 1);
            for (int i = 0; i < Rows; i++)
                resultMatrix[i, 0] = _array[i, k];
            return resultMatrix;
        }

        public CMatrix GetCol(int k, int n, int m)
        {
            bool b1 = k >= 0 && k < Cols;
            bool b2 = n >= 0 && n <= m;
            bool b3 = m >= 0 && m < Rows;
            bool b4 = b1 && b2 && b3;
            if (!b4)
            {
                string error = "CMatrix::GetCol(int k,int n, int m):ошибка в параметрах ";
                MessageBox.Show(
                    error,
                    @"Error",
                    MessageBoxButtons.OK
                );
                Application.Exit();
            }

            int rows = m - n + 1;
            CMatrix resultMatrix = new CMatrix(rows, 1);
            for (int i = n; i <= m; i++)
                resultMatrix[i - n, 0] = _array[i, k];
            return resultMatrix;
        }

        public CMatrix RedimMatrix(int newRow, int newCol)
        {
            Rows = newRow;
            Cols = newCol;
            _array = new double[Rows, Cols];
            return this;
        }

        public CMatrix RedimData(int newRow, int newCol)
        {
            CMatrix result = new CMatrix(this);
            RedimMatrix(newRow, newCol);
            int minRows = result.Rows < Rows ? result.Rows : Rows;
            int minCols = result.Cols < Cols ? result.Cols : Cols;
            for (int i = 0; i < minRows; i++)
            for (int j = 0; j < minCols; j++)
                _array[i, j] = result[i, j];
            return this;
        }

        public CMatrix RedimMatrix(int newRow)
        {
            Rows = newRow;
            Cols = 1;
            _array = new double[Rows, Cols];
            return this;
        }

        public CMatrix RedimData(int newRow)
        {
            CMatrix result = new CMatrix(this);
            RedimMatrix(newRow);
            int minRows = result.Rows < Rows ? result.Rows : Rows;
            for (int i = 0; i < minRows; i++)
                _array[i, 0] = result[i];
            return this;
        }

        public double MaxElement()
        {
            double max = _array[0, 0];
            for (int i = 0; i < Rows; i++)
            for (int j = 0; j < Cols; j++)
                if (_array[i, j] > max)
                    max = _array[i, j];
            return max;
        }

        public double MinElement()
        {
            double min = _array[0, 0];
            for (int i = 0; i < Rows; i++)
            for (int j = 0; j < Cols; j++)
                if (_array[i, j] < min)
                    min = _array[i, j];
            return min;
        }

        public double MaxElement(int firstIndex, int indexI, int indexJ)
        {
            double max = _array[0, 0];
            for (int i = firstIndex; i < indexI; i++)
            for (int j = 0; j < indexJ; j++)
                if (_array[i, j] > max)
                    max = _array[i, j];
            return max;
        }

        public double MinElement(int firstIndex, int indexI, int indexJ)
        {
            double min = _array[0, 0];
            for (int i = firstIndex; i < indexI; i++)
            for (int j = 0; j < indexJ; j++)
                if (_array[i, j] < min)
                    min = _array[i, j];
            return min;
        }
        public static CMatrix CreateRotate2D(double fi)
            // Формирует матрицу для преобразования координат объекта при его повороте
            // на угол fi (при fi>0 против часовой стрелки)в фиксированной системе координат
            // --- ИЛИ ---
            // Формирует матрицу для преобразования координат объекта при повороте начала
            // системы координат на угол -fi при фиксированном положении объекта 
            // fi - угол в градусах
        {
            double fg = fi % 360.0 ;
            double ff = (fg / 180.0) * Math.PI; // Перевод в радианы
            CMatrix RM = new CMatrix(3, 3);
            RM[0, 0] = Math.Cos(ff); RM[0, 1] = -Math.Sin(ff);
            RM[1, 0] = Math.Sin(ff); RM[1, 1] = Math.Cos(ff);
            RM[2, 2] = 1;
            return RM;
        }


        public static CMatrix CreateTranslate2D(double dx, double dy)
            // Формирует матрицу для преобразования координат объекта при его смещении 
            // на dx по оси X и на dy по оси Y в фиксированной системе координат
            // --- ИЛИ ---
            // Формирует матрицу для преобразования координат объекта при смещении начала
            // системы координат на -dx оси X и на -dy по оси Y при фиксированном положении объекта 
        {
            CMatrix TM = new CMatrix(3, 3);
            TM[0, 0] = 1; TM[0, 2] = dx;
            TM[1, 1] = 1; TM[1, 2] = dy;
            TM[2, 2] = 1;
            return TM;
        }
    }
}