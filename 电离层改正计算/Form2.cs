using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 电离层改正计算
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public List<double> GeoCenter = new List<double>{-2225669.7744, 4998936.1598, 3265908.9678};
        public double Bp;
        public double Lp;
        private void Geocentric_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Geocentric.Text == "" || GeodeticB.Text == "" || GeodeticL.Text == "")
                {
                    MessageBox.Show("请输入正确数据");
                    return;
                }
                else
                {
                    GeoCenter = new List<double>();
                    string[] str = Geocentric.Text.Split(',');
                    for (int i = 0; i < str.Length; i++)
                    {
                        GeoCenter.Add(Convert.ToDouble(str[i]));
                        //MessageBox.Show(str[i]);
                    }
                    Bp = Math.PI * Convert.ToDouble(GeodeticB.Text) / 180;
                    Lp = Math.PI * Convert.ToDouble(GeodeticL.Text) / 180;

                }
                MessageBox.Show("修改成功");
            }
            catch
            {
                MessageBox.Show("输入格式错误");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Bp = Math.PI * 30 / 180;
            Lp = Math.PI * 114 / 180;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Geocentric.Clear();
            GeodeticB.Clear();
            GeodeticL.Clear();
        }
    }
}
