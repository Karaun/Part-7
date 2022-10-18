using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 电离层改正计算
{
    class Satellite_data
    {
        public Satellite_data(string i, double j, double k, double L)
        {
            id = i;
            X_point = j;
            Y_point = k;
            Z_point = L;

        }

        private string ID;
        private double X_coordinate;
        private double Y_coordinate;
        private double Z_coordinate;

        public string id
        {
            get { return ID;}
            set { ID = value; }
        }

        public double X_point
        {
            set { X_coordinate = value; }
            get { return X_coordinate; }
        }

        public double Y_point
        {
            set { Y_coordinate = value; }
            get { return Y_coordinate; }
        }

        public double Z_point
        {
            set { Z_coordinate = value; }
            get { return Z_coordinate; }
        }

        //运算坐标
        public static List<double> Coordinate_Get(Satellite_data sd, Matrix a, Matrix b)
        {
            List<double> Result = new List<double>();
            Matrix c = new Matrix(3, 1);
            c.Matrix_a[0, 0] = sd.X_coordinate;
            c.Matrix_a[1, 0] = sd.Y_coordinate;
            c.Matrix_a[2, 0] = sd.Z_coordinate;

            Matrix temp1 = Matrix.Sub(c, b);
            Matrix temp2 = Matrix.Mult(a, temp1);

            for (int i = 0; i < 3; i++)
            {
                Result.Add(temp2.Matrix_a[i, 0]);
            }
            return Result;

        }
    }
}
