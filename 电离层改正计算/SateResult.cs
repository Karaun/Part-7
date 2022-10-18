using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 电离层改正计算
{
    class SateResult
    {
        public SateResult(string v, double i, double j, double k, double l)
        {
            id = v;
            H_angle = i;
            azi = j;
            lays = k;
            laye = l;
        }

        public SateResult(string i, double j, double k, double l)
        {
            id = i;
            H_angle = j;
            azi = k;
            lays = l;
        }

        private string ID;
        private double Height_angle;
        private double Azimuth;
        private double Delay_S;
        private double Delay_E;

        public string id
        {
            get { return ID; }
            set { ID = value; }
        }

        public double H_angle
        {
            set { Height_angle = value; }
            get { return Height_angle; }
        }

        public double azi
        {
            set { Azimuth = value; }
            get { return Azimuth; }
        }

        public double lays
        {
            set { Delay_S = value; }
            get { return Delay_S; }
        }

        public double laye
        {
            set { Delay_E = value; }
            get { return Delay_E; }
        }

        public static string Display(SateResult i)
        {
            string result = i.id + "  " + i.H_angle.ToString("#0.000") + "  " + i.azi.ToString("#0.000") + "  " + i.Delay_S.ToString("#0.000");

            return result;
        }
    }
}
