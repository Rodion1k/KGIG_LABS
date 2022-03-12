using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Lp_Lab01;

namespace LP_Lab03v2
{
    public class Drawing
    {
        private Form _form;
        private List<Point> _points;

        public Drawing(Form form)
        {
            _form = form;
            _points = new List<Point>();
        }

        private List<Point> WorldToLocal(Chart myChart)
        {
            CMatrix cMatrix = new CMatrix(3, _points.Count);
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < cMatrix.Cols; j++)
                {
                    cMatrix[i, j] = _points.ElementAt(j).X;
                }
            }

            for (int i = 1; i < 2; i++)
            {
                for (int j = 0; j < cMatrix.Cols; j++)
                {
                    cMatrix[i, j] = _points.ElementAt(j).Y;
                }
            }

            for (int i = 2; i < 3; i++)
            {
                for (int j = 0; j < cMatrix.Cols; j++)
                {
                    cMatrix[i, j] = 1;
                }
            }

            double xMax = 0;
            double xMin = 0;
            double yMax = 0;
            double yMin = 0;


            xMax = cMatrix.MaxElement(0, 1, cMatrix.Cols);
            xMin = cMatrix.MinElement(0, 1, cMatrix.Cols);

            yMax = cMatrix.MaxElement(1, 2, cMatrix.Cols);
            yMin = cMatrix.MinElement(1, 2, cMatrix.Cols);

            double xMinWind = myChart.Location.X;
            double xMaxWind = myChart.Location.X + myChart.Width;
            double yMinWind = myChart.Location.Y;
            double yMaxWind = myChart.Location.Y + myChart.Height;

            double dXWind = xMaxWind - xMinWind;
            double dYWind = yMaxWind - yMinWind;

            double dX = xMax - xMin;
            double dY = yMax - yMin;

            double Kx = dXWind / dX;
            double Ky = dYWind / dY;

            CMatrix matrixConversion = new CMatrix(3, 3);

            matrixConversion[0, 0] = Kx;
            matrixConversion[1, 1] = -Ky;
            matrixConversion[0, 2] = xMinWind - Kx * xMin;
            matrixConversion[1, 2] = yMaxWind + Ky * yMin;
            matrixConversion[2, 2] = 1;
            List<Point> listOfConvertedPoints = new List<Point>();
            for (int i = 0; i < _points.Count; i++)
            {
                CMatrix point = cMatrix.GetCol(i);

                CMatrix convertedPoint = matrixConversion * point;
                ;
                listOfConvertedPoints.Add(new Point(convertedPoint[0, 0], convertedPoint[1, 0]));
            }

            return listOfConvertedPoints;
        }

        public void DrawingFuncInWorld()
        {
            Chart myChart = new Chart();
            _points.Clear();
            myChart.Parent = _form;
            myChart.Location = new System.Drawing.Point(0, 30);
            myChart.ChartAreas.Add(new ChartArea("Math functions"));
            Series mySeriesOfPoint = new Series("Sinus");
            mySeriesOfPoint.ChartType = SeriesChartType.Line;
            mySeriesOfPoint.ChartArea = "Math functions";

            for (double x = -6; x <= 6; x += 0.1)
            {
                Point point = new Point(x, Math.Sin(Math.PI * x) * Math.Sqrt(Math.Abs(x)));
                _points.Add(point);
                mySeriesOfPoint.Points.AddXY(point.X, point.Y);
            }

            myChart.Series.Add(mySeriesOfPoint);
            DrawingFuncInLocal(myChart);
        }

        public void DrawingFuncInLocal(Chart first)
        {
            Chart myChart = new Chart();
            myChart.Parent = _form;
            myChart.ChartAreas.Add(new ChartArea("Math functions2"));
            myChart.Location = new System.Drawing.Point(first.Location.X + first.Width + 100, first.Location.Y);
            Series mySeriesOfPoint = new Series("Sinus2");
            mySeriesOfPoint.ChartType = SeriesChartType.Line;
            mySeriesOfPoint.ChartArea = "Math functions2";
            var listOfConvertedPoints = WorldToLocal(myChart);
            for (int i = 0; i < listOfConvertedPoints.Count; i++)
            {
                double x = listOfConvertedPoints.ElementAt(i).X;
                double y = listOfConvertedPoints.ElementAt(i).Y;
                mySeriesOfPoint.Points.AddXY(x, y);
            }
            //Добавляем созданный набор точек в Chart
            myChart.Series.Add(mySeriesOfPoint);
        }

        public void DrawingPictureInWorld()
        {
            _points.Clear();
            Chart myChart = new Chart();
            myChart.Parent = _form;
            myChart.ChartAreas.Add(new ChartArea("Houses"));
            myChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            myChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            myChart.Location = new System.Drawing.Point(0, 30);
            Series mySeries = new Series("house in world");
            mySeries.ChartArea = "Houses";
            mySeries.ChartType = SeriesChartType.Line;
            _points.Add(new Point(-2,0));
            _points.Add(new Point(2,0));
            _points.Add(new Point(2,-4));
            _points.Add(new Point(-2,-4));
            _points.Add(new Point(-2,0));
            _points.Add(new Point(-3,0));
            _points.Add(new Point(0,4));
            _points.Add(new Point(3,0));
            _points.Add(new Point(2,0));

            foreach (var point in _points)
            {
                mySeries.Points.AddXY(point.X,point.Y);
            }
            myChart.Series.Add(mySeries);
            DrawingPictureInLocal(myChart);
        }
        public void DrawingPictureInLocal(Chart first)
        {
            Chart myChart = new Chart();
            myChart.Parent = _form;
            myChart.ChartAreas.Add(new ChartArea("Houses"));
            myChart.Location = new System.Drawing.Point(first.Location.X + first.Width + 100, first.Location.Y);
            myChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            myChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            Series mySeries = new Series("house in local");
            mySeries.ChartArea = "Houses";
            mySeries.ChartType = SeriesChartType.Line;
             var resultSeries = WorldToLocal(myChart);
             foreach (var point in resultSeries)
             {
                 mySeries.Points.AddXY(point.X,point.Y);
             }
            myChart.Series.Add(mySeries);
        }
    }
}