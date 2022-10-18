using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 电离层改正计算
{
    class Matrix
    {
        public Matrix(int am, int an)
        {
            M = am;
            N = an;
            Matrix_a = new double[M, N];
        }


        int M;
        int N;
        double[,] matrix;

        public int GetN
        {
            set { N = value; }
            get { return N; }
        }

        public int GetM
        {
            set { M = value; }
            get { return M; }
        }

        public double[,] Matrix_a
        {
            set { matrix = value; }
            get { return matrix; }
        }


        //创建矩阵
        public static Matrix Creat(string Text)
        {
            //获取数据，创建被卷积矩阵
            string[] line1 = Text.Split('\n');
            int M1 = line1.Length;
            int N1 = 0;
            string[][] rank1 = new string[line1.Length][];

            for (int j = 0; j < line1.Length; j++)
            {
                rank1[j] = line1[j].Split(' ');
                N1 = rank1[j].Length;
            }

            Matrix a = new Matrix(M1, N1);
            for (int b = 0; b < M1; b++)
            {
                for (int c = 0; c < N1; c++)
                {
                    a.Matrix_a[b, c] = Convert.ToDouble(rank1[b][c]);
                }
            }

            return a;
        }


        //矩阵减法
        public static Matrix Sub(Matrix a, Matrix b)
        {
            int m = a.GetM;
            int n = a.GetN;
            int m1 = b.GetM;
            int n1 = b.GetN;
            Matrix c = new Matrix(m, n);

            if (m != m1 && n != n1)
            {
                Console.WriteLine("输入矩阵错误，无法计算");
            }
            else
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        c.Matrix_a[i, j] = a.Matrix_a[i, j] - b.Matrix_a[i, j];
                    }

                }
            }
            return c;
        }


        //矩阵乘法
        public static Matrix Mult(Matrix a, Matrix b)
        {
            int m = a.GetM;
            int n = a.GetN;
            int m1 = b.GetM;
            int n1 = b.GetN;
            Matrix c = new Matrix(m, n1);

            if (n != m1)
            {
                Console.WriteLine("输入矩阵错误，无法计算");
            }
            else
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n1; j++)
                    {
                        for (int k = 0; k < n; k++)
                        {
                            c.Matrix_a[i, j] = c.Matrix_a[i, j] + a.Matrix_a[i, k] * b.Matrix_a[k, j];
                        }
                    }

                }
            }
            return c;
        }

        public static Matrix Geo_Coord(double B, double L)
        {
            Matrix a = new Matrix(3, 3);
            a.Matrix_a[0, 0] = -Math.Sin(B) * Math.Cos(L);
            a.Matrix_a[0, 1] = -Math.Sin(B) * Math.Sin(L);
            a.Matrix_a[0, 2] =  Math.Cos(B);
            a.Matrix_a[1, 0] = -Math.Sin(L);
            a.Matrix_a[1, 1] =  Math.Cos(L);
            a.Matrix_a[1, 2] =  0.0;
            a.Matrix_a[2, 0] =  Math.Cos(B) * Math.Cos(L);
            a.Matrix_a[2, 1] =  Math.Cos(B) * Math.Sin(L);
            a.Matrix_a[2, 2] =  Math.Sin(B);
            return a;
        }
    }
}
