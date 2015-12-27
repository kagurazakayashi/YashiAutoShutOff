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
using System.Runtime.InteropServices;



namespace YashiAutoShutOff
{
    public delegate void form1Delegate(bool 开关);
    public delegate void form1CDelegate(bool 退出); //关闭窗口或退出

    public partial class Form1 : Form
    {
        public int initID = new Random().Next(0, int.MaxValue);
        System.Diagnostics.Process cmd = null;
        bool cmdrun = false;
        String viewerexe = "YashiMsgViewer.com";
        SystemInfo 系统信息管理类 = new SystemInfo();
        startscreen 启动窗体 = new startscreen();
        bool 启动窗体开启 = true;
        bool 启动完毕 = false;
        form1Delegate 启动任务代理;
        form1CDelegate 主窗体关闭代理;
        Calc 数值计算器;
        bool 执行中 = false;

        //[DllImport("kernel32.dll")]
        //static extern uint SetThreadExecutionState(uint esFlags);
        //const uint ES_AWAYMODE_REQUIRED = 0x00000040;
        //const uint ES_CONTINUOUS = 0x80000000;
        //const uint ES_DISPLAY_REQUIRED = 0x00000002;
        //const uint ES_SYSTEM_REQUIRED = 0x00000001;

        MainWindow 主窗口 = new MainWindow();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.AboveNormal;
            if (!SettingLoad.arg("nologo"))
            {
                启动窗体.Show();
            }
            if (SettingLoad.arg("reset"))
            {
                抹掉设置();
            }
            if (SettingLoad.arg("ver"))
            {
                AboutBox about = new AboutBox();
                about.Show();
            }
            创建用户文件夹();
            数值计算器 = new Calc(系统信息管理类);
            Console.WriteLine("Form1 init: " + initID);
            载入语言();
            主窗口.Show();
            主窗口.窗口打开 = true;
            this.Visible = false;
            显示主窗口SToolStripMenuItem.Enabled = true;

            启动任务代理 = new form1Delegate(启动任务);
            主窗口.启动任务代理 = 启动任务代理;
            主窗体关闭代理 = new form1CDelegate(主窗体关闭);
            主窗口.主窗体关闭代理 = 主窗体关闭代理;

            系统信息管理类.初始化处理器计数器();
            //初始化硬盘IO计数器();
            系统信息管理类.初始化硬盘IO总计数器();
            系统信息管理类.初始化网络计数器();
            重新为设置窗口赋值();
            bool startcmd = false;
            if (SettingLoad.debug)
            {
                仅启动系统监视器VToolStripMenuItem.Text = Language.s(86);
                仅启动系统监视器VToolStripMenuItem.Enabled = false;
            }
            else
            {
                startcmd = true;
            }
            if (SettingLoad.arg("viewon"))
            {
                仅启动系统监视器VToolStripMenuItem.Enabled = true;
                启动或停止系统监视器();
            }
            else if (SettingLoad.arg("viewoff"))
            {
                仅启动系统监视器VToolStripMenuItem.Enabled = false;
            }
            else if (startcmd)
            {
                仅启动系统监视器VToolStripMenuItem.Enabled = true;
                启动或停止系统监视器();
            }
        }

        private string 创建用户文件夹()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\YashiAutoShutdown\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            SettingLoad.资料文件夹 = path;
            return path;
        }

        private void 主窗体关闭(bool 退出)
        {
            if (退出)
            {
                if (SettingLoad.arg("autohide"))
                {
                    显示或隐藏主窗口();
                }
                else
                {
                    执行退出();
                }
            }
            else
            {
                if (!SettingLoad.arg("minimizewindow"))
                {
                    显示或隐藏主窗口();
                }
            }
        }

        private void 主计时器_Tick(object sender, EventArgs e)
        {
            if (启动窗体开启 && 启动完毕)
            {
                if (SettingLoad.arg("nowindow"))
                {
                    显示或隐藏主窗口();
                }
                else if (SettingLoad.arg("opacity"))
                {
                    主窗口.Opacity = 0.8;
                }
                else
                {
                    主窗口.Opacity = 1;
                }
                
                notifyIcon1.Visible = true;
                try
                {
                    启动窗体.timer1.Enabled = false;
                    启动窗体.Close();
                }
                catch
                {

                }
                启动窗体开启 = false;
                启动窗体 = null;
                if (SettingLoad.arg("exit"))
                {
                    SettingLoad.最终关机命令 = true;
                    Application.Exit();
                }
                else if (SettingLoad.arg("stop"))
                {
                    主计时器.Enabled = false;
                }
                else if (SettingLoad.arg("pause"))
                {
                    暂停PToolStripMenuItem.Checked = true;
                }
            }
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
                    紧急停止(Language.s(87) + 运行异常.Message.ToString());
                }
                try
                {
                    系统信息管理类.获得磁盘信息();
                }
                catch (Exception 运行异常)
                {
                    紧急停止(Language.s(88) + 运行异常.Message.ToString());
                }
                try
                {
                    系统信息管理类.获得网络信息();
                }
                catch (Exception 运行异常)
                {
                    紧急停止(Language.s(89) + 运行异常.Message.ToString());
                }
                String 系统信息文本 = Language.s(90);
                try
                {
                    系统信息文本 = 系统信息文本合成();
                }
                catch (Exception 运行异常)
                {
                    紧急停止(Language.s(91) + 运行异常.Message.ToString());
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
                if (SettingLoad.debug)
                {
                    Console.WriteLine(系统信息文本);
                }
                if (!启动完毕)
                {
                    //主窗口.tabControl1.SelectedIndex = 1;
                    启动完毕 = true;
                }
                
            }
        }

        private void 紧急停止(String 错误信息)
        {
            if (SettingLoad.arg("crash"))
            {
                Application.ExitThread();
            }
            暂停PToolStripMenuItem.Checked = true;
            执行中 = false;
            if (主窗口.窗口打开)
            {
                主窗口.暂停提示.Enabled = true;
                主窗口.开关动作(false);
            }
            SettingLoad.reset();
            DialogResult 错误对话框回复 = MessageBox.Show(错误信息 + Language.s(92), Language.s(93), MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            if (错误对话框回复 == DialogResult.Retry)
            {
                暂停PToolStripMenuItem.Checked = false;
                主窗口.暂停提示.Enabled = false;
            }
            else if(错误对话框回复 == DialogResult.Abort)
            {
                执行退出();
            }
        }

        private string 系统信息文本合成()
        {
            StringBuilder 返回文本 = new StringBuilder();

            返回文本.Append(DateTime.Now.ToString()+ "\n"+ Language.s(94) + " " + 系统信息管理类.处理器内核数数组[0]+ "\n" + 系统信息管理类.处理器内核数数组[1] + " " + Language.s(95) + " " + 系统信息管理类.处理器内核数数组[2] + " " + Language.s(96));
            SettingLoad.CPU核心数量 = int.Parse(系统信息管理类.处理器内核数数组[2]);
            if (SettingLoad.CPU核心数量 > 1000)
            {
                MessageBox.Show(Language.s(97), Language.s(98), MessageBoxButtons.OK,MessageBoxIcon.Error);
                Application.Exit();
            }
            float[] 处理器分核使用量 = new float[1002];
            for (int 处理器内核遍历计数器 = 0; 处理器内核遍历计数器 <= SettingLoad.CPU核心数量; 处理器内核遍历计数器++)
            {
                PerformanceCounter 当前处理器性能计数器 = 系统信息管理类.处理器性能计数器数组[处理器内核遍历计数器];
                float 当前处理器使用百分比 = 当前处理器性能计数器.NextValue();
                if (处理器内核遍历计数器 == SettingLoad.CPU核心数量)
                {
                    返回文本.Append("\n" + Language.s(99) + " " + 当前处理器使用百分比.ToString() + "%");
                    SettingLoad.处理器总使用量 = 当前处理器使用百分比;
                    SettingLoad.已用内存百分比 = 系统信息管理类.已用内存百分比;
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
                    返回文本.Append("\n" + Language.s(100) + " [" + 处理器内核遍历计数器.ToString() + "] " + Language.s(101) + " " + 当前处理器使用百分比.ToString() + "%");
                    处理器分核使用量[处理器内核遍历计数器] = 当前处理器使用百分比;
                }
            }
            SettingLoad.处理器分核使用量 = 处理器分核使用量;
            SettingLoad.内存信息数组 = 系统信息管理类.内存信息数组;
            SettingLoad.硬盘I信息数组 = 系统信息管理类.硬盘I信息数组;
            SettingLoad.硬盘O信息数组 = 系统信息管理类.硬盘O信息数组;
            SettingLoad.硬盘IO信息数组 = 系统信息管理类.硬盘IO信息数组;
            SettingLoad.网络I信息数组 = 系统信息管理类.网络I信息数组;
            SettingLoad.网络O信息数组 = 系统信息管理类.网络O信息数组;
            SettingLoad.网络IO信息数组 = 系统信息管理类.网络IO信息数组;


            返回文本.Append("\n" + Language.s(102) + " " + 系统信息管理类.内存信息数组[2]/1024 + "MB / " + 系统信息管理类.内存信息数组[0] / 1024 + "MB ( " + 系统信息管理类.已用内存百分比 + "% ) ");
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

            返回文本.Append("\n"+ Language.s(8) + ": " + 系统信息管理类.硬盘O信息数组[0].ToString() + "，"+ Language.s(103) + " " + 系统信息管理类.硬盘O信息数组[1].ToString() + "( " + 系统信息管理类.硬盘O信息数组[2].ToString() + " % )");
            返回文本.Append("\n" + Language.s(7) + ": " + 系统信息管理类.硬盘I信息数组[0].ToString() + "，" + Language.s(103) + " " + 系统信息管理类.硬盘I信息数组[1].ToString() + "( " + 系统信息管理类.硬盘I信息数组[2].ToString() + " % )");
            返回文本.Append("\n" + Language.s(6) + ": " + 系统信息管理类.硬盘IO信息数组[0].ToString() + "，" + Language.s(103) + " " + 系统信息管理类.硬盘IO信息数组[1].ToString() + "( " + 系统信息管理类.硬盘IO信息数组[2].ToString() + " % )");
            返回文本.Append("\n" + Language.s(10) + ": " + (系统信息管理类.网络I信息数组[0] / 1024).ToString() + "，" + Language.s(103) + " " + (系统信息管理类.网络I信息数组[1] / 1024).ToString() + "( " + 系统信息管理类.网络I信息数组[2].ToString() + " % )");
            返回文本.Append("\n" + Language.s(11) + ": " + (系统信息管理类.网络O信息数组[0] / 1024).ToString() + "，" + Language.s(103) + " " + (系统信息管理类.网络O信息数组[1] / 1024).ToString() + "( " + 系统信息管理类.网络O信息数组[2].ToString() + " % )");
            返回文本.Append("\n" + Language.s(9) + ": " + (系统信息管理类.网络IO信息数组[0] / 1024).ToString() + "，" + Language.s(103) + " " + (系统信息管理类.网络IO信息数组[1] / 1024).ToString() + "( " + 系统信息管理类.网络IO信息数组[2].ToString() + " % )");
            if (执行中)
            {
                返回文本.Append("\n" + Language.s(104) + SettingLoad.任务启动时间);
                返回文本.Append("\n" + Language.s(105) + SettingLoad.类型列表文本数组[SettingLoad.类型]);
                返回文本.Append("\n" + Language.s(106) + SettingLoad.比较方法文本数组[SettingLoad.比较]);
                返回文本.Append("\n" + Language.s(107) + SettingLoad.条件);
                string 满足信息 = "";
                if (SettingLoad.条件多少秒开始 > 0)
                {
                    SettingLoad.当前已满足百分之 = (int)((float)SettingLoad.当前已满足秒 / (float)SettingLoad.条件多少秒开始 * 100.0f);
                    满足信息 = SettingLoad.当前已满足秒 + " / " + SettingLoad.条件多少秒开始 + " ( " + SettingLoad.当前已满足百分之 + "% )";
                }
                else
                {
                    满足信息 = SettingLoad.当前已满足秒 + " / 0 ( 0%% )";
                }
                返回文本.Append("\n" + Language.s(108) + 满足信息);
                返回文本.Append("\n" + Language.s(109) + SettingLoad.关机模式文本数组[SettingLoad.关机模式]);
                
                int 计算结果 = 数值计算器.计数器加减判断();
                
                if (计算结果 == 1) //+1
                {
                    SettingLoad.当前已满足秒++;
                    if (SettingLoad.当前已满足秒 > SettingLoad.条件多少秒开始)
                    {
                        执行中 = false;
                        SettingLoad.reset();
                        if (主窗口.窗口打开)
                        {
                            主窗口.开关动作(true);
                        }
                        //触发关机
                        Shutdown 关机对话框 = new Shutdown();
                        关机对话框.Show();
                    }
                }
                else if (计算结果 == 0)
                {
                    SettingLoad.当前已满足秒 = 0;
                }
                else
                {
                    string 条件计算发生错误 = Language.s(110);
                    紧急停止(条件计算发生错误);
                    return 条件计算发生错误;
                }
                if (主窗口.窗口打开)
                {
                    if (主窗口.条件满足进度.Maximum != SettingLoad.条件多少秒开始)
                    {
                        主窗口.条件满足进度.Maximum = SettingLoad.条件多少秒开始;
                    }
                    if (SettingLoad.当前已满足秒 > 主窗口.条件满足进度.Maximum)
                    {
                        主窗口.条件满足进度.Value = 主窗口.条件满足进度.Maximum;
                    }
                    else
                    {
                        主窗口.条件满足进度.Value = SettingLoad.当前已满足秒;
                    }
                    主窗口.label10.Text = 满足信息;
                }
            }
            return 返回文本.ToString();
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            执行退出();
        }
        private void 执行退出()
        {
            if (SettingLoad.最终关机命令 || SettingLoad.arg("quickexit"))
            {
                完全退出();
            }
            else
            {
                if (MessageBox.Show(Language.s(111), Language.s(112), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    完全退出();
                }
            }
        }

        private void 完全退出()
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

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            显示或隐藏主窗口();
        }

        private void 显示或隐藏主窗口()
        {
            if (主窗口.窗口打开)
            {
                主窗口.启动任务代理 = null;
                主窗口.主窗体关闭代理 = null;
                主窗口.Close();
                notifyIcon1.ShowBalloonTip(3, Language.s(113)+ Language.s(114), Language.s(115), ToolTipIcon.Info);
            }
            else
            {
                主窗口 = new MainWindow();
                主窗口.启动任务代理 = 启动任务代理;
                主窗口.主窗体关闭代理 = 主窗体关闭代理;
                主窗口.Show();
                重新为设置窗口赋值();
                if (SettingLoad.arg("opacity"))
                {
                    主窗口.Opacity = 0.8;
                }
                else
                {
                    主窗口.Opacity = 1;
                }
            }
            主窗口.窗口打开 = !主窗口.窗口打开;
        }

        private void 重新为设置窗口赋值()
        {
            for (int i = 0; i < int.Parse(系统信息管理类.处理器内核数数组[2]); i++)
            {
                主窗口.CPU核心选择.Items.Add(Language.s(100) + " " + i.ToString());
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
                    cmd.PriorityClass = ProcessPriorityClass.High;
                    //仅启动系统监视器VToolStripMenuItem.Checked = true;
                    cmdrun = true;
                    cmd.StandardInput.WriteLine("@title "+ Language.s(113) + " - " + Language.s(116));
                }
                catch
                {
                    cmdrun = false;
                    仅启动系统监视器VToolStripMenuItem.Enabled = false;
                    MessageBox.Show(Language.s(117) + " " + viewerexe +" "+ Language.s(118), Language.s(119), MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (MessageBox.Show(Language.s(120),Language.s(112), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    cmd.Kill();
                    关闭系统监视器();
                }
                catch
                {
                    
                }
                启动外部程序("YashiAutoShutOffLodctr.exe");
                运行命令后退出();
            }
        }

        private void 运行命令后退出()
        {
            try
            {
                SettingLoad.最终关机命令 = true;
                主窗口.窗口打开 = false;
                主计时器.Enabled = false;
                notifyIcon1.Visible = false;
                主窗口.Close();
                Close();
            }
            catch
            {

            }
            Application.Exit();
        }

        public void 启动任务(bool 开关)
        {
            if (开关)
            {
                if (SettingLoad.类型 == 0)
                {
                    try
                    {
                        int 秒数差 = (int)数值计算器.计算秒数差();
                        SettingLoad.条件多少秒开始 = 秒数差;
                    }
                    catch
                    {
                        紧急停止(Language.s(121));
                    }
                }
                执行中 = true;
            }
            else
            {
                执行中 = false;
                SettingLoad.reset();
            }
        }

        private void 自动关机ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShutdownNow 关机 = new ShutdownNow();
            关机.立即执行类型 = 1;
            关机.开始关机();
        }

        private void 自动重启ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShutdownNow 关机 = new ShutdownNow();
            关机.立即执行类型 = 2;
            关机.开始关机();
        }

        private void 自动休眠ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShutdownNow 关机 = new ShutdownNow();
            关机.立即执行类型 = 3;
            关机.开始关机();
        }

        private void 自动注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShutdownNow 关机 = new ShutdownNow();
            关机.立即执行类型 = 4;
            关机.开始关机();
        }

        private void 自动关机并准备快速启动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShutdownNow 关机 = new ShutdownNow();
            关机.立即执行类型 = 5;
            关机.开始关机();
        }

        private void 自动重启并打开之前的程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShutdownNow 关机 = new ShutdownNow();
            关机.立即执行类型 = 6;
            关机.开始关机();
        }

        private void 自动重启并打开高级启动菜单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShutdownNow 关机 = new ShutdownNow();
            关机.立即执行类型 = 7;
            关机.开始关机();
        }

        private void 查看关机事件日志LToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logshow 日志查看 = new logshow();
            日志查看.Show();
        }

        private void pu0_Click(object sender, EventArgs e)
        {
            clearpu();
            pu0.Checked = true;
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;
        }

        private void pu1_Click(object sender, EventArgs e)
        {
            clearpu();
            pu1.Checked = true;
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
        }

        private void pu2_Click(object sender, EventArgs e)
        {
            clearpu();
            pu2.Checked = true;
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.AboveNormal;
        }

        private void pu3_Click(object sender, EventArgs e)
        {
            clearpu();
            pu3.Checked = true;
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.Normal;
        }

        private void pu4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Language.s(122), Language.s(123), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                clearpu();
                pu5.Checked = true;
                Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.BelowNormal;
            }
        }

        private void pu5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Language.s(122), Language.s(123), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                clearpu();
                pu5.Checked = true;
                Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.Idle;
            }
        }

        private void clearpu()
        {
            pu0.Checked = false;
            pu1.Checked = false;
            pu2.Checked = false;
            pu3.Checked = false;
            pu4.Checked = false;
            pu5.Checked = false;
        }

        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show();
        }

        private void 打开用户设置文件夹DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("explorer.exe", SettingLoad.资料文件夹);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, Language.s(124), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 抹掉用户设置EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Language.s(125), Language.s(123), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                抹掉设置();
            }
            主计时器.Enabled = false;
            Application.Exit();
        }

        private void 抹掉设置()
        {
            try
            {
                string path = 创建用户文件夹();
                DirectoryInfo dir = new DirectoryInfo(path);
                if (dir.Exists)
                {
                    DirectoryInfo[] childs = dir.GetDirectories();
                    foreach (DirectoryInfo child in childs)
                    {
                        child.Delete(true);
                    }
                    dir.Delete(true);
                }
                运行命令后退出();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, Language.s(126), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 强制退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void 打开数码测色计MToolStripMenuItem_Click(object sender, EventArgs e)
        {
            启动外部程序("YashiColorMeasurement.exe");
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
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
                //退出
                运行命令后退出();
            }
            catch
            {
                return;
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            ShutdownNow 关机 = new ShutdownNow();
            关机.立即执行类型 = 8;
            关机.开始关机();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            ShutdownNow 关机 = new ShutdownNow();
            关机.立即执行类型 = 9;
            关机.开始关机();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            ShutdownNow 关机 = new ShutdownNow();
            关机.立即执行类型 = 10;
            关机.开始关机();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            ShutdownNow 关机 = new ShutdownNow();
            关机.立即执行类型 = 11;
            关机.开始关机();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            ShutdownNow 关机 = new ShutdownNow();
            关机.立即执行类型 = 12;
            关机.开始关机();
        }

        private void 直接关闭电源XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShutdownNow 关机 = new ShutdownNow();
            关机.立即执行类型 = 13;
            关机.开始关机();
        }

        private void 打开睡眠和关屏阻止工具FToolStripMenuItem_Click(object sender, EventArgs e)
        {
            启动外部程序("SleepPreventer.exe");
        }

        private void 启动外部程序(string fname)
        {
            try
            {
                Process cmd2 = new System.Diagnostics.Process();
                cmd2.StartInfo.FileName = fname;
                cmd2.Start();
                cmd2.PriorityClass = Process.GetCurrentProcess().PriorityClass;
            }
            catch
            {
                MessageBox.Show(Language.s(117) + " " + fname + " " + Language.s(118), Language.s(119), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void 载入语言()
        {
            if (!SettingLoad.arg("defaultlanguage"))
            {
                窗口管理ToolStripMenuItem.Text = Language.s(127);
                显示主窗口SToolStripMenuItem.Text = Language.s(128);
                仅启动系统监视器VToolStripMenuItem.Text = Language.s(129);
                打开数码测色计MToolStripMenuItem.Text = Language.s(130);
                打开睡眠和关屏阻止工具FToolStripMenuItem.Text = Language.s(131);
                性能ToolStripMenuItem.Text = Language.s(132);
                暂停PToolStripMenuItem.Text = Language.s(133);
                toolStripMenuItem6.Text = Language.s(134);
                优先级NToolStripMenuItem.Text = Language.s(135);
                pu0.Text = Language.s(136);
                pu1.Text = Language.s(137);
                pu2.Text = Language.s(138);
                pu3.Text = Language.s(139);
                pu4.Text = Language.s(140);
                pu5.Text = Language.s(141);
                pu6.Text = Language.s(142);
                维护ToolStripMenuItem.Text = Language.s(143);
                windows任务管理器ToolStripMenuItem.Text = Language.s(144);
                修复Windows性能计数器注册表RToolStripMenuItem.Text = Language.s(145);
                抹掉用户设置EToolStripMenuItem.Text = Language.s(146);
                强制退出ToolStripMenuItem.Text = Language.s(147);
                立即操作ToolStripMenuItem.Text = Language.s(148);
                关闭或注销ToolStripMenuItem.Text = Language.s(149);
                toolStripMenuItem13.Text = Language.s(150);
                自动关机ToolStripMenuItem.Text = Language.s(151);
                自动重启ToolStripMenuItem.Text = Language.s(152);
                自动休眠ToolStripMenuItem.Text = Language.s(153);
                自动注销ToolStripMenuItem.Text = Language.s(154);
                自动关机并准备快速启动ToolStripMenuItem.Text = Language.s(155);
                自动重启并打开之前的程序ToolStripMenuItem.Text = Language.s(156);
                自动重启并打开高级启动菜单ToolStripMenuItem.Text = Language.s(157);
                toolStripMenuItem14.Text = Language.s(158);
                toolStripMenuItem7.Text = Language.s(159);
                toolStripMenuItem8.Text = Language.s(160);
                toolStripMenuItem12.Text = Language.s(161);
                toolStripMenuItem9.Text = Language.s(162);
                toolStripMenuItem10.Text = Language.s(163);
                直接关闭电源XToolStripMenuItem.Text = Language.s(164);
                取消系统关机计划CToolStripMenuItem.Text = Language.s(165);
                设置ToolStripMenuItem.Text = Language.s(166);
                打开用户设置文件夹DToolStripMenuItem.Text = Language.s(167);
                查看关机事件日志LToolStripMenuItem.Text = Language.s(168);
                关于和退出ToolStripMenuItem.Text = Language.s(169);
                关于AToolStripMenuItem.Text = Language.s(170);
                退出XToolStripMenuItem.Text = Language.s(171);
                关闭此菜单QToolStripMenuItem.Text = Language.s(172);
            }
        }
    }
}
