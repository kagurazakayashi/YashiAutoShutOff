using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace YashiAutoShutOff
{
    public partial class Shutdown : Form
    {
        public Shutdown()
        {
            InitializeComponent();
        }

        private void Shutdown_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar1.Maximum = SettingLoad.执行后提示关机时长;
            label1.Text = "注意，系统将在"+ SettingLoad.执行后提示关机时长 + "秒后" + SettingLoad.关机模式文本数组[SettingLoad.关机模式] + "。";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value++;
            }
            int 剩余秒 = progressBar1.Maximum - progressBar1.Value;
            label1.Text = "注意，系统将在" + 剩余秒 + "秒后" + SettingLoad.关机模式文本数组[SettingLoad.关机模式] + "。";
            if (剩余秒 <= 0)
            {
                Opacity = 0;
                if (SettingLoad.截图保存 && SettingLoad.截图保存路径.Length > 0)
                {
                    Screenshot.截图到文件();
                }
                
                timer1.Enabled = false;
                SettingLoad.执行后提示关机时长 = 0;
                ShutdownNow now = new ShutdownNow();
                now.立即执行类型 = 0;
                now.开始关机();
                Close();
            }
        }

        private void 取消按钮_Click(object sender, EventArgs e)
        {
            SettingLoad.执行后提示关机时长 = 0;
            timer1.Enabled = false;
            Close();
        }

        private void 立即执行按钮_Click(object sender, EventArgs e)
        {
            progressBar1.Value = progressBar1.Maximum;
        }
    }
}
