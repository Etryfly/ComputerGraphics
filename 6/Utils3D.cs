using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _6
{
    class Utils3D
    {

        float minX, minY, maxX, maxY;
        public bool hide = false;
        private List<Point3D[]> figures = new List<Point3D[]>();
        private List<Point3D[]> axis = new List<Point3D[]>();

        public List<Point3D[]> ApplyMatrixToFigures(float[,] matrix)
        {
            return ApplyMatrix(matrix, figures);

        }

        public List<Point3D[]> getFigures()
        {
            return figures;
        }

        public List<Point3D[]> ApplyMatrix(float[,] matrix, List<Point3D[]> point3Ds)
        {
            List<Point3D[]> result = new List<Point3D[]>();
            foreach (Point3D[] points in point3Ds)
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
          //  return (float)(Math.Sqrt(x*x + y*y));
           // return 0;
        }

        private void InitAxis(float size)
        {
            Point3D[] x = new Point3D[2];
            Point3D[] y = new Point3D[2];
            Point3D[] z = new Point3D[2];
            x[0] = new Point3D(-size, 0, 0);
            x[1] = new Point3D(size, 0, 0);
            y[1] = new Point3D(0, -size, 0);
            y[0] = new Point3D(0, size, 0);
            z[0] = new Point3D(0, 0, -size);
            z[1] = new Point3D(0, 0, size);
            axis.Clear();
            axis.Add(x);
            axis.Add(y);
            axis.Add(z);
        }

        public void Init(float leftX, float leftY, float rightX, float rightY, int count)
        {
            InitAxis(rightY - leftY);
            float d = (rightX - leftX) / count;

            for (float i = leftY; i < rightY; i += d)
            {
                List<Point3D> points = new List<Point3D>();
                for (float j = leftX; j < rightX; j += 0.1F)
                {
                    Point3D point = new Point3D();
                    point.X =j;
                    point.Y = i;
                    point.Z = func(j, i);
                    points.Add(point);
                }
                figures.Add(points.ToArray());
            }

           
            ResizeZ(10);
            ResizeX(10);
            ResizeY(10);
        }

        public void ResizeZ(int z)
        {
            float[,] matrix = new float[4, 4] { { 1, 0, 0 ,0 },
                                               { 0, 1, 0 ,0 },
                                               { 0, 0, z ,0 },
                                               { 0, 0, 0 , 1 }};

            figures = ApplyMatrixToFigures(matrix);
            axis = ApplyMatrix(matrix, axis);
        }

      

        public void ResizeX(int x)
        {
            float[,] matrix = new float[4, 4] { { x, 0, 0 ,0 },
                                               { 0, 1, 0 ,0 },
                                               { 0, 0, 1 ,0 },
                                               { 0, 0, 0 , 1 }};

            figures = ApplyMatrixToFigures(matrix);
            axis = ApplyMatrix(matrix, axis);
        }

        public void ResizeY(int y)
        {
            float[,] matrix = new float[4, 4] { { 1, 0, 0 ,0 },
                                               { 0, y, 0 ,0 },
                                               { 0, 0, 1 ,0 },
                                               { 0, 0, 0 , 1 }};

            figures = ApplyMatrixToFigures(matrix);
            axis = ApplyMatrix(matrix, axis);
        }

        public List<Point3D[]> Resize(float k, List<Point3D[]> target)
        {
            float[,] matrix = new float[4, 4] { { k, 0, 0 ,0 },
                                               { 0, k, 0 ,0 },
                                               { 0, 0, k ,0 },
                                               { 0, 0, 0 , 1 }};
            return ApplyMatrix(matrix, target);
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
            axis = ApplyMatrix(matrix, axis);
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
            axis = ApplyMatrix(matrix, axis);
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
            axis = ApplyMatrix(matrix, axis);
        }

        private Point getProjection(Point3D point, float aX, float aZ, int size)
        {
            point.X *= size;
            point.Y *= size;
            point.Z *= size; 
            float cosZ = (float)Math.Cos(aZ);
            float sinZ = (float)Math.Sin(aZ);
            float[,] zMatrix = new float[4, 4]{ { cosZ, sinZ, 0 ,0 },
                                               { -sinZ, cosZ, 0 ,0 },
                                               { 0, 0, 1 ,0 },
                                               { 0, 0, 0 , 1 }};
            float cos = (float)Math.Cos(aX);
            float sin = (float)Math.Sin(aX);
            float[,] xMatrix = new float[4, 4] { { 1, 0, 0 ,0 },
                                               { 0, cos, sin ,0 },
                                               { 0, -sin, cos ,0 },
                                               { 0, 0, 0 , 1 }};

            float[,] resizeMatrix = new float[4, 4] { {size, 0, 0 ,0 },
                                               { 0, size, 0 ,0 },
                                               { 0, 0, size ,0 },
                                               { 0, 0, 0 , 1 }};


            //Point3D rotated = floatArrToPoint3D(Dot(Dot(Dot(Point3DToMatrix(point), resizeMatrix), xMatrix), zMatrix));
            Point3D rotated = floatArrToPoint3D(Dot(Dot(Point3DToMatrix(point), zMatrix), xMatrix) );
            return new Point((int)rotated.X , (int)rotated.Z );
        }


        internal List<Point[]> getXZProj(List<Point3D[]> target)
        {
            
            

           
            List<Point[]> result = new List<Point[]>();
            foreach (Point3D[] points in target)
            {
                Point[] newPoints = new Point[points.Length];
                for (int i = 0; i < points.Length; i++)
                {
                   
                    newPoints[i].X = (int)points[i].X;
                    newPoints[i].Y = (int)points[i].Z;
                }
                result.Add(newPoints);
            }

            return result;
        }

        internal List<Point[]> getXZFiguresProj()
        {


            return getXZProj(figures);
        }

        internal List<Point[]> getXZAxisProj()
        {
            return getXZProj(axis);
        }


        public List<Point[]> getProjWithRemovedLines(Graphics g, int cX, int cY)
        {
            maxX = int.MinValue;
            maxY = int.MinValue;
            minX = int.MaxValue;
            minY = int.MaxValue;
            for (int i = 0; i < figures.Count; i++)
            {
                for (int j = 0; j < figures[i].Length; j++)
                {
                    Point3D p = figures[i][j];
                    if (p.X > maxX) maxX = p.X;
                    if (p.Y > maxY) maxY = p.Z;
                    if (p.X < minX) minX = p.X;
                    if (p.Y < minY) minY = p.Z;

                }
            }

            float[] horMax = new float[(int) (maxX - minX) + 1];
            float[] horMin = new float[(int) (maxX - minX) + 1];
            for (int i = 0; i < horMin.Length; i++)
            {
                horMin[i] = int.MaxValue;
                horMax[i] = int.MinValue;
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
                 
                    bool isAdded = false;
                    int IX = (int)(point.X - minX);
                    int IY = (int)point.Z;
                    if ( IY > horMax[IX] )
                    {
                        horMax[IX] = IY;
                        Point p = new Point((int)(IX + minX), IY);
                        points.Add(p);
                        isAdded = true;
                        //g.FillRectangle(new SolidBrush(Color.Black), IX + minX + cX, IY + cY, 1, 1);
                    } 

                    if (IY < horMin[IX])
                    {
                        horMin[IX] = IY;
                        Point p = new Point((int)(IX + minX), IY);
                        points.Add(p);
                       // g.FillRectangle(new SolidBrush(Color.Black), IX + minX + cX, IY + cY, 1, 1);
                         isAdded = true;
                    } 
                    

                    if (!isAdded)
                    {
                        result.Add(points.ToArray());
                        points.Clear();
                    }
                   
                 
                }

                result.Add(points.ToArray());
            }

            return result;
        }

        public void RotateAxis(float x, float z)
        {
            float cosZ = (float)Math.Cos(z);
            float sinZ = (float)Math.Sin(z);
            float[,] zMatrix = new float[4, 4]{ { cosZ, sinZ, 0 ,0 },
                                               { -sinZ, cosZ, 0 ,0 },
                                               { 0, 0, 1 ,0 },
                                               { 0, 0, 0 , 1 }};
            float cos = (float)Math.Cos(x);
            float sin = (float)Math.Sin(x);
            float[,] xMatrix = new float[4, 4] { { 1, 0, 0 ,0 },
                                               { 0, cos, sin ,0 },
                                               { 0, -sin, cos ,0 },
                                               { 0, 0, 0 , 1 }};

            axis = ApplyMatrix(zMatrix, axis);
            axis = ApplyMatrix(xMatrix, axis);
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