using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace _6
{
    class Utils3D
    {

        float minX, minZ, maxX, maxZ;
        public bool hide = false;
        private List<Point3D[]> figures = new List<Point3D[]>();

        public List<Point3D[]> ApplyMatrixToFigures(float[,] matrix)
        {
            List<Point3D[]> result = new List<Point3D[]>();
            foreach (Point3D[] points in figures)
            {
                Point3D[] newPoints = new Point3D[points.Length];
                for (int i = 0; i < points.Length; i++)
                {
                    newPoints[i] = floatArrToPoint3D(Dot(Point3DToMatrix(points[i]), matrix));
                }
                result.Add(newPoints);
            }

            return result;

        }

        private float func(float x, float y)
        {
            return (float)(Math.Cos(x) *2* Math.Sin(y));
        }

        public void Init(float leftX, float leftY, float rightX, float rightY, int count)
        {
            float d = (rightX - leftX) / count;
           // minX = leftX;
           // float d = 6.66F;
            Debug.WriteLine(d);
            for (float i = leftX; i < rightX; i+= d)
            {
                List<Point3D> points = new List<Point3D>();
                for (float j = leftY; j < rightY; j+=0.01F)
                {
                    Point3D point = new Point3D();
                    point.X = i;
                    point.Y = j;
                    point.Z = func(i, j );
                    points.Add(point);
                }
                figures.Add(points.ToArray());
            }

           // Smooth();
            ResizeZ(20);
            ResizeX(20);
            ResizeY(20);
        }

      

        private void SwapPoints(ref Point3D firstPoint, ref Point3D secondPoint)
        {
            Point3D tempPoint = firstPoint;
            firstPoint = secondPoint;
            secondPoint = tempPoint;
        }

        public void ResizeZ(int z)
        {
            float[,] matrix = new float[4, 4] { { 1, 0, 0 ,0 },
                                               { 0, 1, 0 ,0 },
                                               { 0, 0, z ,0 },
                                               { 0, 0, 0 , 1 }};

            figures = ApplyMatrixToFigures(matrix);
        }

        public void ResizeX(int x)
        {
            float[,] matrix = new float[4, 4] { { x, 0, 0 ,0 },
                                               { 0, 1, 0 ,0 },
                                               { 0, 0, 1 ,0 },
                                               { 0, 0, 0 , 1 }};

            figures = ApplyMatrixToFigures(matrix);
        }

        public void ResizeY(int y)
        {
            float[,] matrix = new float[4, 4] { { 1, 0, 0 ,0 },
                                               { 0, y, 0 ,0 },
                                               { 0, 0, 1 ,0 },
                                               { 0, 0, 0 , 1 }};

            figures = ApplyMatrixToFigures(matrix);
        }

        private Point3D floatArrToPoint3D(float[,] point)
        {
            return new Point3D(point[0, 0], point[0, 1], point[0, 2]);
        }

       


        public void Move(float Dx, float Dy, float Dz)
        {
            float[,] matrix = new float[4, 4] { { 1, 0, 0 ,0 },
                                               { 0, 1, 0 ,0 },
                                               { 0, 0, 1 ,0 },
                                               { Dx, Dy, Dz , 1 }};

            figures = ApplyMatrixToFigures(matrix);
        }

        public void ReflectYZ()
        {
            float[,] matrix = new float[4, 4] { { -1, 0, 0 ,0 },
                                               { 0, 1, 0 ,0 },
                                               { 0, 0, 1 ,0 },
                                               { 0, 0, 0 , 1 }};

            figures = ApplyMatrixToFigures(matrix);
        }

        public void ReflectYX()
        {
            float[,] matrix = new float[4, 4] { { 1, 0, 0 ,0 },
                                               { 0, 1, 0 ,0 },
                                               { 0, 0, -1 ,0 },
                                               { 0, 0, 0 , 1 }};

            figures = ApplyMatrixToFigures(matrix);
        }

        public void ReflectZX()
        {
            float[,] matrix = new float[4, 4] { { 1, 0, 0 ,0 },
                                               { 0, -1, 0 ,0 },
                                               { 0, 0, 1 ,0 },
                                               { 0, 0, 0 , 1 }};

            figures = ApplyMatrixToFigures(matrix);
        }

        public void RotateZ(float a)
        {
            float cos = (float)Math.Cos(a);
            float sin = (float)Math.Sin(a);
            float[,] matrix = new float[4, 4] { { cos, sin, 0 ,0 },
                                               { -sin, cos, 0 ,0 },
                                               { 0, 0, 1 ,0 },
                                               { 0, 0, 0 , 1 }};

            figures = ApplyMatrixToFigures(matrix);
        }

        public void RotateX(float a)
        {
            float cos = (float)Math.Cos(a);
            float sin = (float)Math.Sin(a);
            float[,] matrix = new float[4, 4] { { 1, 0, 0 ,0 },
                                               { 0, cos, sin ,0 },
                                               { 0, -sin, cos ,0 },
                                               { 0, 0, 0 , 1 }};

            figures = ApplyMatrixToFigures(matrix);
        }

        public void RotateY(float a)
        {
            float cos = (float)Math.Cos(a);
            float sin = (float)Math.Sin(a);
            float[,] matrix = new float[4, 4] { { cos, 0, -sin ,0 },
                                               { 0, 1, 0 ,0 },
                                               { sin, 0, cos ,0 },
                                               { 0, 0, 0 , 1 }};

            figures = ApplyMatrixToFigures(matrix);
        }


       

        internal List<Point[]> getXZProj()
        {
            
            

           
            List<Point[]> result = new List<Point[]>();
            foreach (Point3D[] points in figures)
            {
                Point[] newPoints = new Point[points.Length];
                for (int i = 0; i < points.Length; i++)
                {
                   
                    newPoints[i].X = (int)points[i].Y;
                    newPoints[i].Y = (int)points[i].Z;
                }
                result.Add(newPoints);
            }

            return result;
        }


        public List<Point[]> getProjWithRemovedLines(Graphics g, int cX, int cY)
        {
            maxX = int.MinValue;
            maxZ = int.MinValue;
            minX = int.MaxValue;
            minZ = int.MaxValue;
            for (int i = 0; i < figures.Count; i++)
            {
                for (int j = 0; j < figures[i].Length; j++)
                {
                    Point3D p = figures[i][j];
                    if (p.X > maxX) maxX = p.X;
                    if (p.Y > maxZ) maxZ = p.Z;
                    if (p.X < minX) minX = p.X;
                    if (p.Y < minZ) minZ = p.Z;

                }
            }

            float[] horMax = new float[(int) (maxX - minX) + 1];
            float[] horMin = new float[(int) (maxX - minX) + 1];
            for (int i = 0; i < horMin.Length; i++)
            {
                horMin[i] = maxZ - minZ;
               // horMax[i] = minZ;
            }

            List<Point[]> result = new List<Point[]>();

            for (int i = 0; i < figures.Count; i++)
            {
                List<Point> points = new List<Point>();
                for (int j = 0; j < figures[i].Length; j++)
                {
                    SolidBrush brush = new SolidBrush(Color.Black);
                    Point3D point = figures[i][j];
                    bool isAdded1 = false;
                    bool isAdded = false;
                    int IX = (int)(point.X - minX);
                    int IY = (int)point.Z;
                    /*if ( IY < horMin[IX] )
                    {
                        horMax[IX] = IY;
                        Point p = new Point((int)(IX + minX), IY);
                        points.Add(p);
                        isAdded = true;
                        g.FillRectangle(new SolidBrush(Color.Black), IX + minX + cX, IY + cY, 1, 1);
                    } */

                    if (IY < horMin[IX])
                    {
                        horMin[IX] = IY;
                        Point p = new Point((int)(IX + minX), IY);
                        points.Add(p);
                       // g.FillRectangle(new SolidBrush(Color.Black), IX + minX + cX, IY + cY, 1, 1);
                         isAdded = true;
                    }
                    
                   
                    if (!isAdded )
                    {
                        if (points.Count == 0)
                        {
                          //  points.Add(new Point((int)(IX + minX), IY));
                            //g.FillRectangle(new SolidBrush(Color.Black), IX + minX + cX, IY + cY, 1, 1);
                        }
                        else
                            points.Add(points[points.Count - 1]);
                    }
                }

                result.Add(points.ToArray());
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