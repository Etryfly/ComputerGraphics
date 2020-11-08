using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace _5
{
    class UtilsFor3D
    {
        private List<Point3D[]> figures;

        public void setFigures(List<Point3D[]> figures)
        {
            this.figures = figures;
        }

        public UtilsFor3D()
        {

        }

        public void Resize(float kx, float ky, float kz)
        {
            float[,] matrix = new float[4, 4] { { kx, 0, 0 ,0 },
                                               { 0, ky, 0 ,0 },
                                               { 0, 0, kz ,0 },
                                               { 0, 0, 0 , 1 }};

            figures = ApplyMatrixToFigures(matrix);
        }

        public List<Point3D[]> ApplyMatrixToFigures(float[,] matrix)
        {
            List<Point3D[]> result = new List<Point3D[]>();
            foreach (Point3D[] points in figures)
            {
                Point3D[] newPoints = new Point3D[points.Length];
                for (int i = 0; i < points.Length; i++)
                {
                    newPoints[i] = floatArrToPoint3D( Dot(Point3DToMatrix(points[i]), matrix));
                }
                result.Add(newPoints);
            }

            return result;
            
        }

        private Point3D floatArrToPoint3D(float[,] point)
        {
            return new Point3D(point[0, 0], point[0, 1], point[0, 2]);
        }

        public List<PointF[]> getCentralProjection(float z)
        {
            float[,] matrix = new float[4, 4] { { 1, 0, 0 ,0 },
                                               { 0, 1, 0 ,0 },
                                               { 0, 0, 0 , 1/z },
                                               { 0, 0, 0 , 1 }};
            List<Point3D[]> figures3D = ApplyMatrixToFigures(matrix);
            List<PointF[]> result = new List<PointF[]>();
            for (int i = 0; i < figures3D.Count; i++)
            {
                PointF[] pointFs = new PointF[figures3D[i].Length];
                for (int j = 0; j < figures3D[i].Length; j++)
                {
                    pointFs[j].X = figures3D[i][j].X;
                    pointFs[j].Y = figures3D[i][j].Y;

                }
                result.Add(pointFs);

            }

            return result;
            
        }

        private float[,] Point3DToMatrix(Point3D point)
        {
            float[,] result = new float[1, 4];
            result[0, 0] = point.X;
            result[0, 1] = point.Y;
            result[0, 2] = point.Z;
            result[0, 3] = 1;
            return result;
        }

        private float[,] Dot(float[,] A, float[,] B)
        {
            if (A.GetLength(1) != B.GetLength(0))
            {
                throw new ArithmeticException();
            }
            float[,] result = new float[A.GetLength(0), B.GetLength(1)];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    for (int k = 0; k < B.GetLength(0); k++)
                    {
                        result[i, j] += A[i, k] * B[k, j];
                    }
                }
            }
            return result;
        }
    }
}
