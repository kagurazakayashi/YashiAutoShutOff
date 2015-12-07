using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YashiAutoShutOffLodctr
{
    public partial class Form1 : Form
    {
        System.Diagnostics.Process cmd = null;
        bool isAdmin = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("正在处理中...");
            button1.Enabled = false;
            if (isAdmin)
            {
                cmd = new System.Diagnostics.Process();
                cmd.StartInfo.FileName = "lodctr";
                cmd.StartInfo.Arguments = "/R";
                cmd.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
                cmd.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
                cmd.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
                cmd.StartInfo.RedirectStandardError = true;//重定向标准错误输出
                cmd.StartInfo.CreateNoWindow = true;//不显示程序窗口
                try
                {
                    MessageBox.Show("将开始操作。\n可能会失去响应，但不会超过3分钟。\n操作未完成之前建议不要操作您的电脑。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmd.Start();//启动程序
                    string output = cmd.StandardOutput.ReadToEnd();
                    cmd.WaitForExit();
                    cmd.Close();
                    MessageBox.Show(output, "处理结果", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                catch (Exception err)
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add(err.Message.ToString());
                    MessageBox.Show(err.Message.ToString(), "发生错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                reloadinfo();
            }
            else
            {
                //创建启动对象
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.UseShellExecute = true;
                startInfo.WorkingDirectory = Environment.CurrentDirectory;
                startInfo.FileName = Application.ExecutablePath;
                //设置启动动作,确保以管理员身份运行
                startInfo.Verb = "runas";
                try
                {
                    System.Diagnostics.Process.Start(startInfo);
                }
                catch (Exception err)
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add(err.Message.ToString());
                    MessageBox.Show(err.Message.ToString(), "发生错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //退出
                Application.Exit();
            }
            button1.Enabled = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reloadinfo();
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
            if (!principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
            {
                button1.Text = "获得管理员权限(&U)";
                isAdmin = false;
            }
        }

        private void reloadinfo()
        {
            button1.Enabled = false;
            cmd = new System.Diagnostics.Process();
            cmd.StartInfo.FileName = "lodctr";
            cmd.StartInfo.Arguments = "/Q";
            cmd.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            cmd.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            cmd.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            cmd.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            cmd.StartInfo.CreateNoWindow = true;//不显示程序窗口
            try
            {
                cmd.Start();//启动程序
                string output = cmd.StandardOutput.ReadToEnd();
                cmd.WaitForExit();
                cmd.Close();
                string[] s = output.Split(new char[] { '\n' });
                listBox1.Items.Clear();
                for (int i = 0; i < s.Length; i++)
                {
                    listBox1.Items.Add(s[i]);
                }
                button1.Enabled = true;
            }
            catch (Exception err)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add(err.Message.ToString());
                MessageBox.Show(err.Message.ToString(),"发生错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
