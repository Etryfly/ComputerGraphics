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
                                               { 0, 0, 0 , z },
                                               { 0, 0, 0 , 1 }};
            // List<Point3D[]> figures3D = ApplyMatrixToFigures(matrix);
            // List<PointF[]> result = new List<PointF[]>();
            // for (int i = 0; i < figures3D.Count; i++)
            //  {
            //     PointF[] pointFs = new PointF[figures3D[i].Length];
            //    for (int j = 0; j < figures3D[i].Length; j++)
            //   {
            //       pointFs[j].X = figures3D[i][j].X;
            //       pointFs[j].Y = figures3D[i][j].Y;
            //
            //   }
            //   result.Add(pointFs);

            //  }

            //  return result;


            List<PointF[]> result = new List<PointF[]>();
            foreach (Point3D[] points in figures)
            {
                PointF[] newPoints = new PointF[points.Length];
                for (int i = 0; i < points.Length; i++)
                {
                    float[,] fl = Dot(Point3DToMatrix(points[i]), matrix);
                    newPoints[i].X = fl[0, 0]  ;
                    newPoints[i].Y = fl[0, 1]  ;
                }
                result.Add(newPoints);
            }

            return result;

        }


        public List<PointF[]> getOrthoProjection()
        {
            float[,] matrix = new float[4, 4] { { 0, 0, 0 ,0 },
                                               { 0, 1, 0 ,0 },
                                               { 0, 0, 1 , 0 },
                                               { 0, 0, 0 , 1 }};
            List<PointF[]> result = new List<PointF[]>();
            foreach (Point3D[] points in figures)
            {
                PointF[] newPoints = new PointF[points.Length];
                for (int i = 0; i < points.Length; i++)
                {
                    float[,] fl = Dot(Point3DToMatrix(points[i]), matrix);
                    newPoints[i].X = fl[0, 1];
                    newPoints[i].Y = fl[0, 2];
                }
                result.Add(newPoints);
            }

            return result;



        }

        public void Move(float Dx, float Dy, float Dz)
        {
            float[,] matrix = new float[4, 4] { { 1, 0, 0 ,0 },
                                               { 0, 1, 0 ,0 },
                                               { 0, 0, 1 ,0 },
                                               { Dx, Dy, Dz , 1 }};

            figures = ApplyMatrixToFigures(matrix);
        }

        public float[] Points3DToABCDMatrix(Point3D[] points)
        {
            if (points.Length < 3) throw new ArgumentException();
            float x1 = points[0].X;
            float x2 = points[1].X;
            float x3 = points[2].X;
            float y1 = points[0].Y;
            float y2 = points[1].Y;
            float y3 = points[2].Y;
            float z1 = points[0].Z;
            float z2 = points[1].Z;
            float z3 = points[2].Z;
            float A = y1 * (z2 - z3) + y2 * (z3 - z1) + y3 * (z1 - z2);
            float B = z1 * (x2 - x3) + z2 * (x3 - x1) + z3 * (x1 - x2);
            float C = x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2);
            float D = -x1 * (y2 * z3 - y3 * z2) - x2 * (y3 * z1 - y1 * z3) - x3 * (y1 * z2 - y2 * z1);
            float[] result = new float[4];
           
            result[0] = A ;
            result[1] = B ;
            result[2] = C ;
            result[3] = D ;
            return result;
        }

        private Color getColorByABCD(float[] abcd)
        {
             int c = (int)(Math.Abs(abcd[0]) + Math.Abs(abcd[1]) + Math.Abs(abcd[2]) + Math.Abs(abcd[3])) ;
            //int c = (int)(Math.Ababcd[0] + abcd[1] + abcd[2] + abcd[3]);
            c %= 255;
            return Color.FromArgb(c, c, 0, c);
        }

        public Color[] getFiguresColors()
        {
            Color[] result = new Color[figures.Count];
            for (int i = 0; i < figures.Count; i++)
            {
                result[i] = getColorByABCD(Points3DToABCDMatrix(figures[i]));
            }
            return result;
        }

        internal List<PointF[]> getObliqueProjection(float alpha, float l)
        {
            float cos = (float)Math.Cos(alpha);
            float sin = (float)Math.Sin(alpha);
            float[,] matrix = new float[4, 4] { { 1, 0, 0 ,0 },
                                               { 0, 1, 0 ,0 },
                                               { l * cos,  l * sin, 0 , 0 },
                                               { 0, 0, 0 , 1 }};
            List<PointF[]> result = new List<PointF[]>();
            foreach (Point3D[] points in figures)
            {
                PointF[] newPoints = new PointF[points.Length];
                for (int i = 0; i < points.Length; i++)
                {
                    float[,] fl = Dot(Point3DToMatrix(points[i]), matrix);
                    newPoints[i].X = fl[0, 0];
                    newPoints[i].Y = fl[0, 1];
                }
                result.Add(newPoints);
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
