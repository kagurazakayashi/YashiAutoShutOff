using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;
using System.Threading;
using System.Collections;
using System.Management;
using System.IO;



namespace YashiAutoShutOff
{
    public partial class Form1 : Form
    {
        System.Diagnostics.Process cmd = null;
        bool cmdrun = false;
        String viewerexe = "YashiMsgViewer.com";

        SystemInfo 系统信息管理类 = new SystemInfo();
        
        bool 启动完毕 = false;

        //performanceCounter

        MainWindow 主窗口 = new MainWindow();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            主窗口.Show();
            主窗口.窗口打开 = true;
            this.Visible = false;
            显示主窗口SToolStripMenuItem.Enabled = true;
            系统信息管理类.初始化处理器计数器();
            //初始化硬盘IO计数器();
            系统信息管理类.初始化硬盘IO总计数器();
            系统信息管理类.初始化网络计数器();
            重新为设置窗口赋值();
#if DEBUG
            仅启动系统监视器VToolStripMenuItem.Text = "处于调试模式";
            仅启动系统监视器VToolStripMenuItem.Enabled = false;
#else
            启动或停止系统监视器();
#endif
            //启动或停止系统监视器();
        }

        private void 主计时器_Tick(object sender, EventArgs e)
        {
            主窗口.时间显示.Text = DateTime.Now.ToLongTimeString().ToString();
            if (暂停PToolStripMenuItem.Checked == false)
            {
                //紧急停止("模拟了一个错误。");
                try
                {
                    系统信息管理类.获得内存信息();
                }
                catch (Exception 运行异常)
                {
                    紧急停止("在尝试更新内存信息时遇到了错误，" + 运行异常.Message.ToString());
                }
                try
                {
                    系统信息管理类.获得磁盘信息();
                }
                catch (Exception 运行异常)
                {
                    紧急停止("在尝试更新磁盘信息时遇到了错误，" + 运行异常.Message.ToString());
                }
                try
                {
                    系统信息管理类.获得网络信息();
                }
                catch (Exception 运行异常)
                {
                    紧急停止("在尝试更新网络信息时遇到了错误，" + 运行异常.Message.ToString());
                }
                String 系统信息文本 = "遇到了一些错误，信息获取失败。";
                try
                {
                    系统信息文本 = 系统信息文本合成();
                }
                catch (Exception 运行异常)
                {
                    紧急停止("系统信息文本合成时遇到了错误，" + 运行异常.Message.ToString());
                }
                //notifyIcon1.Text = 系统信息文本;
                //if (主窗口.窗口打开)
                //{
                //    主窗口.系统信息显示文本框.Text = 系统信息文本;
                //}
                if(cmdrun)
                {
                    cmd.StandardInput.WriteLine("@cls");
                    string[] strs = 系统信息文本.Split('\n');
                    for (int i = 0; i < strs.Length; i++)
                    {
                        cmd.StandardInput.WriteLine(strs[i]);
                    }
                }
#if DEBUG
                Console.WriteLine(系统信息文本);
#endif
                if (!启动完毕)
                {
                    //主窗口.tabControl1.SelectedIndex = 1;
                    启动完毕 = true;
                }
                
            }
        }

        private void 紧急停止(String 错误信息)
        {
            暂停PToolStripMenuItem.Checked = true;
            主窗口.暂停提示.Enabled = true;
            DialogResult 错误对话框回复 = MessageBox.Show(错误信息 + "\n计时器和刷新器已经自动暂停。\n建议点击忽略并前往设置页面请检查设置是否正确。", "啊哦，雅诗变得奇怪了", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            if (错误对话框回复 == DialogResult.Retry)
            {
                暂停PToolStripMenuItem.Checked = false;
                主窗口.暂停提示.Enabled = false;
            }
            else if(错误对话框回复 == DialogResult.Abort)
            {
                退出();
            }
        }

        private string 系统信息文本合成()
        {
            StringBuilder 返回文本 = new StringBuilder();

            返回文本.Append(DateTime.Now.ToString()+ "\n主处理器 " + 系统信息管理类.处理器内核数数组[0]+ "\n" + 系统信息管理类.处理器内核数数组[1] + " 个物理处理器核心， " + 系统信息管理类.处理器内核数数组[2] + " 个逻辑处理器");
            for (int 处理器内核遍历计数器 = 0; 处理器内核遍历计数器 <= int.Parse(系统信息管理类.处理器内核数数组[2]); 处理器内核遍历计数器++)
            {
                PerformanceCounter 当前处理器性能计数器 = 系统信息管理类.处理器性能计数器数组[处理器内核遍历计数器];
                float 当前处理器使用百分比 = 当前处理器性能计数器.NextValue();
                if (处理器内核遍历计数器 == int.Parse(系统信息管理类.处理器内核数数组[2]))
                {
                    返回文本.Append("\n处理器总利用率 " + 当前处理器使用百分比.ToString() + "%");
                    if (主窗口.窗口打开)
                    {
                        主窗口.处理器利用率条.Value = (int)(当前处理器使用百分比 * 10000);
                        主窗口.处理器利用率显示.Text = (int)当前处理器使用百分比 + "%";
                        主窗口.内存利用率条.Value = (int)(系统信息管理类.已用内存百分比 * 10000);
                        主窗口.内存利用率显示.Text = (int)系统信息管理类.已用内存百分比 + "%";
                        主窗口.硬盘利用率条.Value = (int)(系统信息管理类.硬盘IO信息数组[2] * 10000);
                        主窗口.硬盘利用率显示.Text = (int)系统信息管理类.硬盘IO信息数组[2] + "%";
                        主窗口.网络利用率条.Value = (int)(系统信息管理类.网络IO信息数组[2] * 10000);
                        主窗口.网络利用率显示.Text = (int)系统信息管理类.网络IO信息数组[2] + "%";
                    }
                }
                else
                {
                    返回文本.Append("\n逻辑处理器 [" + 处理器内核遍历计数器.ToString() + "] 已使用 " + 当前处理器使用百分比.ToString() + "%");
                }
            }
            
            返回文本.Append("\n内存使用率 " + 系统信息管理类.内存信息数组[2]/1024 + "MB / " + 系统信息管理类.内存信息数组[0] / 1024 + "MB ( " + 系统信息管理类.已用内存百分比 + "% ) ");
            //for (int 硬盘遍历计数器 = 0; 硬盘遍历计数器 < 硬盘性能计数器数组.Count; 硬盘遍历计数器++)
            //{
                //String 当前硬盘名称 = 硬盘名称数组[硬盘遍历计数器];
                //PerformanceCounter 当前硬盘IO计数器 = 硬盘性能计数器数组[硬盘遍历计数器];
                //float 当前硬盘使用百分比 = 当前硬盘IO计数器.NextValue();
                //返回文本.Append("\n硬盘 [" + 当前硬盘名称 + "] 已使用 " + 当前硬盘使用百分比.ToString() + "%");
                //返回文本.Append("\n硬盘读写速度 " + 当前硬盘使用百分比.ToString() + "每秒");
            //}
            foreach (String 磁盘名 in 系统信息管理类.硬盘名称数组)
            {
                返回文本.Append("\n" + 磁盘名);
            }

            返回文本.Append("\n硬盘每秒读取 " + 系统信息管理类.硬盘O信息数组[0].ToString() + " 次，峰值 " + 系统信息管理类.硬盘O信息数组[1].ToString() + "次 ( " + 系统信息管理类.硬盘O信息数组[2].ToString() + " % )");
            返回文本.Append("\n硬盘每秒写入 " + 系统信息管理类.硬盘I信息数组[0].ToString() + " 次，峰值 " + 系统信息管理类.硬盘I信息数组[1].ToString() + "次 ( " + 系统信息管理类.硬盘I信息数组[2].ToString() + " % )");
            返回文本.Append("\n硬盘每秒读写 " + 系统信息管理类.硬盘IO信息数组[0].ToString() + " 次，峰值 " + 系统信息管理类.硬盘IO信息数组[1].ToString() + "次 ( " + 系统信息管理类.硬盘IO信息数组[2].ToString() + " % )");
            返回文本.Append("\n网络每秒接收 " + (系统信息管理类.网络I信息数组[0] / 1024).ToString() + " KB，峰值 " + (系统信息管理类.网络I信息数组[1] / 1024).ToString() + "KB ( " + 系统信息管理类.网络I信息数组[2].ToString() + " % )");
            返回文本.Append("\n网络每秒发送 " + (系统信息管理类.网络O信息数组[0] / 1024).ToString() + " KB，峰值 " + (系统信息管理类.网络O信息数组[1] / 1024).ToString() + "KB ( " + 系统信息管理类.网络O信息数组[2].ToString() + " % )");
            返回文本.Append("\n网络每秒收发 " + (系统信息管理类.网络IO信息数组[0] / 1024).ToString() + " KB，峰值 " + (系统信息管理类.网络IO信息数组[1] / 1024).ToString() + "KB ( " + 系统信息管理类.网络IO信息数组[2].ToString() + " % )");
            return 返回文本.ToString();
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            退出();
        }
        private void 退出()
        {
            if (MessageBox.Show("将停止所有计时器并完全退出，继续？", "停止", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    cmd.Kill();
                    关闭系统监视器();
                }
                catch
                {

                }
                主窗口.窗口打开 = false;
                主计时器.Enabled = false;
                notifyIcon1.Visible = false;
                主窗口.Close();
                Close();
                Application.Exit();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            显示或隐藏主窗口();
        }

        private void 显示或隐藏主窗口()
        {
            if (主窗口.窗口打开)
            {
                主窗口.Hide();
            }
            else
            {
                主窗口 = new MainWindow();
                主窗口.Show();
                重新为设置窗口赋值();
            }
            主窗口.窗口打开 = !主窗口.窗口打开;
        }

        private void 重新为设置窗口赋值()
        {
            for (int i = 0; i < int.Parse(系统信息管理类.处理器内核数数组[2]); i++)
            {
                主窗口.CPU核心选择.Items.Add("逻辑处理器 " + i.ToString());
            }
            if (主窗口.选中的CPU核心 < 主窗口.CPU核心选择.Items.Count)
            {
                主窗口.CPU核心选择.SelectedIndex = 主窗口.选中的CPU核心;
            }
            
        }

        private void 显示主窗口SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            显示或隐藏主窗口();
        }

        private void 暂停PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            暂停PToolStripMenuItem.Checked = !暂停PToolStripMenuItem.Checked;
            主窗口.暂停提示.Enabled = 暂停PToolStripMenuItem.Checked;
        }

        private void 标准速度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            标准速度ToolStripMenuItem.Checked = true;
            高速ToolStripMenuItem.Checked = false;
            极速ToolStripMenuItem.Checked = false;
            主计时器.Interval = 1000;
        }

        private void 高速ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            标准速度ToolStripMenuItem.Checked = false;
            高速ToolStripMenuItem.Checked = true;
            极速ToolStripMenuItem.Checked = false;
            主计时器.Interval = 500;
        }

        private void 极速ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            标准速度ToolStripMenuItem.Checked = false;
            高速ToolStripMenuItem.Checked = false;
            极速ToolStripMenuItem.Checked = true;
            主计时器.Interval = 100;
        }

        private void windows任务管理器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = "taskmgr.exe";
            proc.Start();
        }

        private void 取消系统关机计划CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = "shutdown.exe";
            proc.StartInfo.Arguments = "-a";
            proc.Start();
        }
        //private void 命令行输出
        private void 仅启动系统监视器VToolStripMenuItem_Click(object sender, EventArgs e)
        {
            启动或停止系统监视器();
        }
        private void 启动或停止系统监视器()
        {
            if (!cmdrun)
            {
                cmd = new System.Diagnostics.Process();
                cmd.StartInfo.FileName = viewerexe;
                cmd.StartInfo.Arguments = "-viewer";
                cmd.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
                cmd.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
                cmd.StartInfo.RedirectStandardOutput = false;//由调用程序获取输出信息
                cmd.StartInfo.RedirectStandardError = false;//重定向标准错误输出
                cmd.StartInfo.CreateNoWindow = false;//不显示程序窗口
                cmd.Exited += new EventHandler(exep_Exited);

                //cmd.StandardInput.AutoFlush = true;

                StreamWriter standardOutput = new StreamWriter(Console.OpenStandardOutput());
                try
                {
                    cmd.Start();//启动程序
                    //仅启动系统监视器VToolStripMenuItem.Checked = true;
                    cmdrun = true;
                    cmd.StandardInput.WriteLine("@title 雅诗智能关机 - 实时系统信息");
                }
                catch
                {
                    cmdrun = false;
                    仅启动系统监视器VToolStripMenuItem.Enabled = false;
                    MessageBox.Show("找不到文件 "+ viewerexe +" ，\n请确保这个文件和主程序放在了一起。\n程序仍可以继续使用，但是系统信息查看功能将不可用。","缺少文件", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                try
                {
                    cmd.Kill();
                    关闭系统监视器();
                }
                catch
                {
                    cmdrun = false;
                    启动或停止系统监视器();
                }
            }
        }
        private void exep_Exited(object sender, EventArgs e)
        {
            关闭系统监视器();
        }
        private void 关闭系统监视器()
        {
            //仅启动系统监视器VToolStripMenuItem.Checked = false;
            cmdrun = false;
            cmd.Close();
            cmd = null;
        }

        private void 修复Windows性能计数器注册表RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("将停止所有计时器并完全退出，以便运行修复工具，继续？", "停止", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    cmd.Kill();
                    关闭系统监视器();
                }
                catch
                {
                    
                }
                try
                {
                    cmd = new System.Diagnostics.Process();
                    cmd.StartInfo.FileName = "YashiAutoShutOffLodctr.exe";
                    cmd.Start();
                    主窗口.窗口打开 = false;
                    主计时器.Enabled = false;
                    notifyIcon1.Visible = false;
                    主窗口.Close();
                    Close();
                    Application.Exit();
                }
                catch
                {
                    MessageBox.Show("找不到文件 YashiAutoShutOffLodctr.exe ，\n请确保这个文件和主程序放在了一起。\n程序仍可以继续使用，但是系统信息查看功能将不可用。", "缺少文件", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
