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

        //performanceCounter

        MainWindow 主窗口 = new MainWindow();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.AboveNormal;
            启动窗体.Show();
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
#if DEBUG
            仅启动系统监视器VToolStripMenuItem.Text = "处于调试模式";
            仅启动系统监视器VToolStripMenuItem.Enabled = false;
#else
            startcmd = true;
#endif
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
                if (SettingLoad.arg("opacity"))
                {
                    主窗口.Opacity = 0.8;
                } else
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
                if (SettingLoad.arg("stop"))
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
            DialogResult 错误对话框回复 = MessageBox.Show(错误信息 + "\n计时器和刷新器已经自动暂停。\n建议点击忽略并前往设置页面请检查设置是否正确。", "啊哦，雅诗变得奇怪了", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
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

            返回文本.Append(DateTime.Now.ToString()+ "\n主处理器 " + 系统信息管理类.处理器内核数数组[0]+ "\n" + 系统信息管理类.处理器内核数数组[1] + " 个物理处理器核心， " + 系统信息管理类.处理器内核数数组[2] + " 个逻辑处理器");
            SettingLoad.CPU核心数量 = int.Parse(系统信息管理类.处理器内核数数组[2]);
            if (SettingLoad.CPU核心数量 > 1000)
            {
                MessageBox.Show("抱歉，我真没有预料到你会有这么多逻辑处理器。请联系我以为你的处理器提供支持。\n然而你的处理器目前已经超过了本软件的承受范围，即将退出。","处理器计数器已达最大值",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Application.Exit();
            }
            float[] 处理器分核使用量 = new float[1002];
            for (int 处理器内核遍历计数器 = 0; 处理器内核遍历计数器 <= SettingLoad.CPU核心数量; 处理器内核遍历计数器++)
            {
                PerformanceCounter 当前处理器性能计数器 = 系统信息管理类.处理器性能计数器数组[处理器内核遍历计数器];
                float 当前处理器使用百分比 = 当前处理器性能计数器.NextValue();
                if (处理器内核遍历计数器 == SettingLoad.CPU核心数量)
                {
                    返回文本.Append("\n处理器总利用率 " + 当前处理器使用百分比.ToString() + "%");
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
                    返回文本.Append("\n逻辑处理器 [" + 处理器内核遍历计数器.ToString() + "] 已使用 " + 当前处理器使用百分比.ToString() + "%");
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
            if (执行中)
            {
                返回文本.Append("\n任务启动时间 "+ SettingLoad.任务启动时间);
                返回文本.Append("\n依据：" + SettingLoad.类型列表文本数组[SettingLoad.类型]);
                返回文本.Append("\n判断：" + SettingLoad.比较方法文本数组[SettingLoad.比较]);
                返回文本.Append("\n条件：" + SettingLoad.条件);
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
                返回文本.Append("\n满足：" + 满足信息);
                返回文本.Append("\n执行：" + SettingLoad.关机模式文本数组[SettingLoad.关机模式]);
                
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
                    string 条件计算发生错误 = "条件计算发生错误，不支持的条件。请检查条件输入是否正确";
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
                if (MessageBox.Show("将停止所有计时器并完全退出，继续？", "停止", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                notifyIcon1.ShowBalloonTip(3, "雅诗智能自动关机仍在运行。", "计时器仍然会在后台继续运行，可以在图标上点右键打开主菜单。", ToolTipIcon.Info);
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
                    Process cmd2 = new System.Diagnostics.Process();
                    cmd2.StartInfo.FileName = "YashiAutoShutOffLodctr.exe";
                    cmd2.Start();
                    运行命令后退出();
                }
                catch
                {
                    MessageBox.Show("找不到文件 YashiAutoShutOffLodctr.exe 或发生了错误，\n请确保这个文件和主程序放在了一起。\n程序仍可以继续使用，但是系统信息查看功能将不可用。", "缺少文件", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
                        紧急停止("条件时间计算发生错误，请检查条件输入是否正确");
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
            if (MessageBox.Show("更低的优先级可能会导致计时器延迟，使时间不准确。确认继续？", "注意", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                clearpu();
                pu5.Checked = true;
                Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.BelowNormal;
            }
        }

        private void pu5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("更低的优先级可能会导致计时器延迟，使时间不准确。确认继续？", "注意", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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
                MessageBox.Show(err.Message, "打开失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 抹掉用户设置EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("会删除所有设置和日志文件并退出。确认继续？", "注意", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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
                MessageBox.Show(err.Message, "复位失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 强制退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void 打开数码测色计MToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process cmd2 = new System.Diagnostics.Process();
                cmd2.StartInfo.FileName = "YashiColorMeasurement.exe";
                cmd2.Start();
            }
            catch
            {
                MessageBox.Show("找不到文件 YashiColorMeasurement.exe 或发生了错误，\n请确保这个文件和主程序放在了一起。\n程序仍可以继续使用，但是屏幕测色功能将不可用。", "缺少文件", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
    }
}
