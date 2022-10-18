
namespace 电离层改正计算
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Geocentric = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.GeodeticB = new System.Windows.Forms.TextBox();
            this.GeodeticL = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Geocentric
            // 
            this.Geocentric.Font = new System.Drawing.Font("宋体", 10F);
            this.Geocentric.Location = new System.Drawing.Point(170, 33);
            this.Geocentric.Name = "Geocentric";
            this.Geocentric.Size = new System.Drawing.Size(294, 23);
            this.Geocentric.TabIndex = 0;
            this.Geocentric.Text = "-2225669.7744,4998936.1598,3265908.9678";
            this.Geocentric.WordWrap = false;
            this.Geocentric.TextChanged += new System.EventHandler(this.Geocentric_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(363, 224);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 30);
            this.button2.TabIndex = 4;
            this.button2.Text = "设置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "重置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F);
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "测站点地心坐标:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14F);
            this.label2.Location = new System.Drawing.Point(30, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "大地坐标Bp:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14F);
            this.label3.Location = new System.Drawing.Point(30, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "大地坐标Lp:";
            // 
            // GeodeticB
            // 
            this.GeodeticB.Font = new System.Drawing.Font("宋体", 12F);
            this.GeodeticB.Location = new System.Drawing.Point(170, 93);
            this.GeodeticB.Name = "GeodeticB";
            this.GeodeticB.Size = new System.Drawing.Size(294, 26);
            this.GeodeticB.TabIndex = 9;
            this.GeodeticB.Text = "30";
            this.GeodeticB.WordWrap = false;
            // 
            // GeodeticL
            // 
            this.GeodeticL.Font = new System.Drawing.Font("宋体", 12F);
            this.GeodeticL.Location = new System.Drawing.Point(170, 157);
            this.GeodeticL.Name = "GeodeticL";
            this.GeodeticL.Size = new System.Drawing.Size(294, 26);
            this.GeodeticL.TabIndex = 10;
            this.GeodeticL.Text = "114";
            this.GeodeticL.WordWrap = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 266);
            this.Controls.Add(this.GeodeticL);
            this.Controls.Add(this.GeodeticB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Geocentric);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "参数设置";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Geocentric;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox GeodeticB;
        private System.Windows.Forms.TextBox GeodeticL;
    }
}