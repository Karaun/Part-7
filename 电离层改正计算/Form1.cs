using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace 电离层改正计算
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择打开的文件";
            ofd.Filter = "txt|*.txt|All|*.*";
            ofd.ShowDialog();

            string path = ofd.FileName;
            if (path == "")
            {
                return;
            }
            using (FileStream FsRead = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                byte[] buffer = new byte[1024 * 1024 * 5];
                int r = FsRead.Read(buffer, 0, buffer.Length);
                txtSource.Text = Encoding.UTF8.GetString(buffer, 0, r);

            }

        }

        private void 导出结果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.Title = "请选择保存路径";
            ofd.Filter = "txt|*.txt|All|*.*";
            ofd.ShowDialog();

            string path = ofd.FileName;
            if (path == "")
            {
                return;
            }
            using (FileStream FsWrite = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(txtResult.Text);
                FsWrite.Write(buffer, 0, buffer.Length);

            }
        }

        public List<double> GeoD;
        public double B_p;
        public double L_p;
        private void 参数设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            GeoD = f2.GeoCenter;
            B_p = f2.Bp;
            L_p = f2.Lp;
        }

        private void 计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtResult.Clear();
            try
            {
                string line;
                string[] Text = txtSource.Text.Split('\n');
                List<Satellite_data> SateList = new List<Satellite_data>();
                string time = "";

                //添加卫星数据信息
                for (int i = 0; i < Text.Length; i++)
                {
                    line = Text[i];
                    if (line.Contains("*"))
                    {
                        time = line;
                    }
                    else
                    {
                        Satellite_data Sd = new Satellite_data(line.Substring(0, 3), Convert.ToDouble(line.Substring(3, 14)) * 1000, Convert.ToDouble(line.Substring(17, 14)) * 1000, Convert.ToDouble(line.Substring(31, 14)) * 1000);
                        SateList.Add(Sd);
                    }
                }

                //记录当天秒数
                string[] times = time.Split(' ');
                double second = Convert.ToDouble(times[4]) * 3600.0 + Convert.ToDouble(times[5]) * 60.0 + Convert.ToDouble(times[6]);
                List<SateResult> results = new List<SateResult>();

                //将地心坐标，大地坐标角度设置为矩阵
                Matrix p = new Matrix(3, 1);
                p.Matrix_a[0, 0] = GeoD[0];
                p.Matrix_a[1, 0] = GeoD[1];
                p.Matrix_a[2, 0] = GeoD[2];


                //创建列表，用于存储卫星空间直角坐标系参数
                foreach (var i in SateList)
                {
                    List<double> Sate_position = Satellite_data.Coordinate_Get(i, Matrix.Geo_Coord(B_p, L_p), p);
                
                    //测试
                   //for (int x = 0; x < 3; x++)
                   //{
                   //    MessageBox.Show(Sate_position[x] + "");
                   //}
                    double X = Sate_position[0];
                    double Y = Sate_position[1];
                    double Z = Sate_position[2];
                    
                    double A = Math.Atan2(Y, X) / Math.PI * 180; //方位角计算
                    
                    if (A < 0.0)
                    {
                        A += 360;
                    }
                    else if (A > 360.0)
                    {
                        A -= 360;
                    }

                    
                    double E = Math.Atan2(Z, Math.Sqrt(X * X + Y * Y))/ Math.PI * 180;// 高度角计算

                    //穿刺点地磁纬度
                    double H = 350000.0; //穿刺点IP高度
                    double temp1 = 0.0137 / (Math.Atan2(Z, Math.Sqrt(X * X + Y * Y)) + 0.11);//穿刺点参数
                    double IP_X = B_p + temp1 * Math.Cos(A);//穿刺点坐标X
                    double IP_Y = L_p + temp1 * Math.Sin(A) / Math.Cos(IP_X);//穿刺点坐标Y
                    double IP_latitude = IP_X + 0.064 * Math.Cos(IP_Y - 1.617);//穿刺点地磁纬度
                    

                    //计算电离层延迟量
                    double F = 1 + 16 * Math.Pow((0.53 - E), 3);
                    double A1 = 5 * Math.Pow(10, -9);//夜晚时间常量
                    double A3 = 50400;//表示取最大值的当地时间
                    double t = 43200 * IP_Y + second;//观测时间

                    //改正参数a
                    double a1 = 0.1397 * Math.Pow(10, -7);
                    double a2 = -0.7451 * Math.Pow(10, -8);
                    double a3 = -0.5960 * Math.Pow(10, -7);
                    double a4 = -0.1192 * Math.Pow(10, -6);

                    //改正参数b
                    double b1 = 0.1270 * Math.Pow(10, 6);
                    double b2 = -0.1966 * Math.Pow(10, 6);
                    double b3 = 0.6554 * Math.Pow(10, 5);
                    double b4 = 0.2621 * Math.Pow(10, 6);

                    double A2 = a1 + a2 * IP_latitude + a3 * Math.Pow(IP_latitude, 2) + a4 * Math.Pow(IP_latitude, 3);
                    double A4 = b1 + b2 * IP_latitude + b3 * Math.Pow(IP_latitude, 2) + b4 * Math.Pow(IP_latitude, 3);

                    double temp2 = (2 * Math.PI * (t - A3)) / A4;
                    double T = 0.0;
                   // MessageBox.Show(F + "");
                    //L1频率电离层延迟时间
                    if (Math.Abs(temp2) < 1.57)
                    {
                        T = F * (A1 + A2 * Math.Cos(temp2));
                    }
                    else if (temp2 >= 1.57)
                    {
                        T = F * A1;
                    }
                   
                    //光速
                    double C = 299792458.0;
                    //延迟距离
                    double D = T * C;

                    SateResult sr = new SateResult(i.id, E, A, D);
                    results.Add(sr);

                }

                foreach (var i in results)
                {
                    txtResult.Text += SateResult.Display(i) + "\r\n";
                }
                txtResult.Text += "";

            }
            catch
            {
                MessageBox.Show("运算错误", "提示");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GeoD = new List<double> { -2225669.7744, 4998936.1598, 3265908.9678 };
            B_p = Math.PI * 30 / 180;
            L_p = Math.PI * 114 / 180;
        }
    }
}

