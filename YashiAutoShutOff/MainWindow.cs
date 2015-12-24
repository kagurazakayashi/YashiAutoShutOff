using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace YashiAutoShutOff
{
    public partial class MainWindow : Form
    {
        public int initID = new Random().Next(0, int.MaxValue);
        public bool 窗口打开 = false;
        private int 开关动画计数器 = 0;
        public bool 总开关 = false;
        public int 关机模式 = 1;
        public int 判断类型 = 0;
        public int 比较方法 = 0;
        public int CPU核心 = 0;
        public int 选中的CPU核心 = 0;
        public form1Delegate 启动任务代理;
        public form1CDelegate 主窗体关闭代理;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Console.WriteLine("MainWindow init: " + initID);
            载入语言();
            for (short i = 0; i < SettingLoad.类型列表文本数组.Length; i++)
            {
                类型列表.Items.Add(SettingLoad.类型列表文本数组[i]);
            }
            for (short i = 0; i < SettingLoad.比较方法文本数组.Length; i++)
            {
                比较列表.Items.Add(SettingLoad.比较方法文本数组[i]);
            }
            for (short i = 0; i < SettingLoad.关机原因文本数组.Length; i++)
            {
                关闭事件跟踪程序设置.Items.Add(SettingLoad.关机原因文本数组[i]);
            }
            初始化选择();
            读入默认设置();
            if (SettingLoad.以管理员方式运行)
            {
                Text += " (管理员)";
            }
            if (SettingLoad.debug)
            {
                Text += " (调试模式)";
            }
            if (SettingLoad.任务启动时间.Length > 0)
            {
                开关动作(true);
            }
        }

        private void 更改模式文字()
        {
            是否为模式A();
            label1.Text = " " + SettingLoad.关机模式文本数组[关机模式] + " ▼";
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (窗口打开 && 主窗体关闭代理 != null)
            {
                主窗体关闭代理(true);
                e.Cancel = true;
            }
        }

        private void 总开关1_Click(object sender, EventArgs e)
        {
            开关动作(false);
        }

        public void 开关动作(bool 仅动画)
        {
            开关动画计数器 = 0;
            总开关1.Enabled = false;
            总开关2.Enabled = false;
            if (总开关1.Text == "&OFF")
            {
                总开关1.Text = "&ON";
                总开关 = true;
                label1.Enabled = false;
                类型列表.Enabled = false;
                比较列表.Enabled = false;
                CPU核心选择.Enabled = false;
                条件输入框.Enabled = false;
                条件多少秒开始1.Enabled = false;
                执行后提示关机时长1.Enabled = false;
                强制关机.Enabled = false;
                截图保存开关.Enabled = false;
                截图保存路径.Enabled = false;
                截图文件夹选择按钮.Enabled = false;
                导入配置按钮.Enabled = false;
                关闭事件跟踪程序开关.Enabled = false;
                关闭事件跟踪程序设置.Enabled = false;
                条件满足进度.Style = ProgressBarStyle.Continuous;
                if (!仅动画)
                {
                    String 默认配置文件 = SettingLoad.资料文件夹 + "default.xml";
                    保存设置(默认配置文件);
                    准备启动任务();
                }
            }
            else
            {
                总开关1.Text = "&OFF";
                总开关 = false;
                label1.Enabled = true;
                类型列表.Enabled = true;
                比较列表.Enabled = true;
                CPU核心选择.Enabled = true;
                条件输入框.Enabled = true;
                条件多少秒开始1.Enabled = true;
                执行后提示关机时长1.Enabled = true;
                强制关机.Enabled = true;
                截图保存开关.Enabled = true;
                截图保存路径.Enabled = true;
                截图文件夹选择按钮.Enabled = true;
                导入配置按钮.Enabled = true;
                关闭事件跟踪程序开关.Enabled = true;
                关闭事件跟踪程序设置.Enabled = true;
                条件满足进度.Value = 0;
                条件满足进度.Style = ProgressBarStyle.Marquee;
                label10.Text = "停止中";
                if (!仅动画)
                {
                    启动任务代理(false);
                    SettingLoad.reset();
                    //准备启动任务();
                }
            }
            开关动画控制器.Enabled = true;
        }

        private void 总开关2_Click(object sender, EventArgs e)
        {
            总开关1_Click(sender, e);
        }

        private void 开关动画控制器_Tick(object sender, EventArgs e)
        {
            bool 执行动画 = true;
            if (SettingLoad.arg("animationoff"))
            {
                执行动画 = false;
            }
            int 动画速度 = 2;
            开关动画计数器++;
            if (总开关1.Text == "&OFF")
            {
                int 新X坐标 = 总开关1.Location.X - 动画速度;
                if (新X坐标 < 703 || !执行动画)
                {
                    新X坐标 = 703;
                }
                总开关1.Location = new Point(新X坐标, 总开关1.Location.Y);
            }
            else
            {
                int 新X坐标 = 总开关1.Location.X + 动画速度;
                if (新X坐标 > 778 || !执行动画)
                {
                    新X坐标 = 778;
                }
                总开关1.Location = new Point(新X坐标, 总开关1.Location.Y);
            }
            if ((开关动画计数器 >= 75 / 动画速度) || !执行动画)
            {
                开关动画控制器.Enabled = false;
                总开关1.Enabled = true;
                总开关2.Enabled = true;
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            关机方式选择菜单.Show(label1, new Point(0, label1.Height));
        }

        private void 提醒我ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            关机模式 = 0;
            更改模式文字();
        }

        private void 自动关机ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            关机模式 = 1;
            更改模式文字();
        }

        private void 自动重启ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            关机模式 = 2;
            更改模式文字();
        }

        private void 自动注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            关机模式 = 4;
            更改模式文字();
        }

        private void 条件多少秒开始1_Scroll(object sender, EventArgs e)
        {
            更新拉杆时间();
        }

        private void 执行后提示关机时长1_Scroll(object sender, EventArgs e)
        {
            更新拉杆时间();
        }

        private void 更新拉杆时间()
        {
            TimeSpan t1 = new TimeSpan(0, 0, 条件多少秒开始1.Value);
            条件多少秒开始2.Text = t1.Minutes + "分" + t1.Seconds + "秒"; //ts.Hours + "时" + 
            TimeSpan t2 = new TimeSpan(0, 0, 执行后提示关机时长1.Value);
            执行后提示关机时长2.Text = t2.Minutes + "分" + t2.Seconds + "秒";
        }

        private void 自动关机并准备快速启动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            关机模式 = 5;
            更改模式文字();
        }

        private void 自动休眠ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            关机模式 = 3;
            更改模式文字();
        }

        private void 自动重启并打开之前的程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            关机模式 = 6;
            更改模式文字();
        }

        private void 截图文件夹选择按钮_Click(object sender, EventArgs e)
        {
            文件夹选择对话框.Description = "请选择一个文件夹，截图将会以时间作为文件名存储在里面。";
            文件夹选择对话框.SelectedPath = 截图保存路径.Text;
            if (文件夹选择对话框.ShowDialog() == DialogResult.OK)
            {
                截图保存路径.Text = 文件夹选择对话框.SelectedPath;
            }
        }

        private void 导入配置按钮_Click(object sender, EventArgs e)
        {
            打开文件对话框.Title = "要从哪里导入设置呢？";
            打开文件对话框.Filter = "XML设置文件(*.xml)|*.xml|所有文件(*.*)|*.*";
            打开文件对话框.InitialDirectory = SettingLoad.资料文件夹;
            if (打开文件对话框.ShowDialog() == DialogResult.OK)
            {
                String 设置文件路径 = 打开文件对话框.FileName.ToString();
                读入设置(设置文件路径);
            }
        }

        private void 导出配置按钮_Click(object sender, EventArgs e)
        {
            保存文件对话框.Title = "要将设置保存到哪里呢？";
            保存文件对话框.Filter = "XML设置文件(*.xml)|*.xml|自定义文件(*.*)|*.*";
            保存文件对话框.InitialDirectory = SettingLoad.资料文件夹;
            if (保存文件对话框.ShowDialog() == DialogResult.OK)
            {
                String 设置文件路径 = 保存文件对话框.FileName.ToString();
                保存设置(设置文件路径);
            }
        }

        private void 初始化选择()
        {
            类型列表.SelectedIndex = 1;
            比较列表.SelectedIndex = 3;
            CPU核心选择.SelectedIndex = 0;
            关闭事件跟踪程序设置.SelectedIndex = 19;
        }

        public void 读入默认设置()
        {
            String 默认配置文件 = SettingLoad.资料文件夹 + "default.xml";
            if (!File.Exists(默认配置文件))
            {
                新建设置文件(默认配置文件);
            }
            读入设置(默认配置文件);
        }

        private bool 是否为模式A()
        {
            if (关机模式 >= 8)
            {
                关闭事件跟踪程序开关.Checked = false;
                关闭事件跟踪程序开关.Enabled = false;
                return true;
            }
            关闭事件跟踪程序开关.Enabled = true;
            return false;
        }

        private void 读入设置(String 配置文件)
        {
            if (File.Exists(配置文件))
            {
                try
                {
                    Xmlio XML操作器 = new Xmlio(配置文件);
                    if (int.Parse(XML操作器.获得XML值("s", "ver")) == 1)
                    {
                        关机模式 = int.Parse(XML操作器.获得XML值("s", "shutdownmode"));
                        SettingLoad.关机模式 = 关机模式;
                        更改模式文字();
                        类型列表.SelectedIndex = int.Parse(XML操作器.获得XML值("s", "type"));
                        比较列表.SelectedIndex = int.Parse(XML操作器.获得XML值("s", "comparison"));
                        选中的CPU核心 = int.Parse(XML操作器.获得XML值("s", "cpu"));
                        条件输入框.Text = XML操作器.获得XML值("s", "condition");
                        条件多少秒开始1.Value = int.Parse(XML操作器.获得XML值("s", "conditionalwaiting"));
                        条件多少秒开始2.Text = 条件多少秒开始1.Value.ToString();
                        执行后提示关机时长1.Value = int.Parse(XML操作器.获得XML值("s", "shutdownwaiting"));
                        执行后提示关机时长2.Text = 执行后提示关机时长1.Value.ToString();
                        强制关机.Checked = bool.Parse(XML操作器.获得XML值("s", "forcedshutdown"));
                        截图保存开关.Checked = bool.Parse(XML操作器.获得XML值("s", "screenshotswitch"));
                        截图保存路径.Text = XML操作器.获得XML值("s", "screenshotfolder");
                        关闭事件跟踪程序开关.Checked = bool.Parse(XML操作器.获得XML值("s", "shutdowneventtracker"));
                        关闭事件跟踪程序设置.SelectedIndex = int.Parse(XML操作器.获得XML值("s", "shutdowneventtrackerset"));
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("导入设置失败，\n" + e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("文件不存在","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void 保存设置(String 配置文件)
        {
            try
            {
                if (File.Exists(配置文件))
                {
                    File.Delete(配置文件);
                }
                新建设置文件(配置文件);
                //Xmlio XML操作器 = new Xmlio(配置文件);
                //XML操作器.设置XML值("s", "ver", "1");
                //XML操作器.设置XML值("s", "shutdownmode", 关机模式.ToString());
                //XML操作器.设置XML值("s", "type", 类型列表.SelectedIndex.ToString());
                //XML操作器.设置XML值("s", "comparison", 比较列表.SelectedIndex.ToString());
                //XML操作器.设置XML值("s", "cpu", CPU核心选择.SelectedIndex.ToString());
                //XML操作器.设置XML值("s", "condition", 条件输入框.Text);
                //XML操作器.设置XML值("s", "conditionalwaiting", 条件多少秒开始1.Value.ToString());
                //XML操作器.设置XML值("s", "shutdownwaiting", 执行后提示关机时长1.Value.ToString());
                //XML操作器.设置XML值("s", "forcedshutdown", 强制关机.Checked.ToString());
                //XML操作器.设置XML值("s", "screenshotswitch", 截图保存开关.Checked.ToString());
                //XML操作器.设置XML值("s", "screenshotfolder", 截图保存路径.Text);
                //XML操作器.设置XML值("s", "shutdowneventtracker", 关闭事件跟踪程序开关.Checked.ToString());
                //XML操作器.设置XML值("s", "shutdowneventtrackerset", 关闭事件跟踪程序设置.SelectedIndex.ToString());
                //XML操作器.保存XML值();
            }
            catch (Exception e)
            {
                MessageBox.Show("导出设置失败，\n" + e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 新建设置文件(String 配置文件)
        {
            FileStream fs1 = new FileStream(配置文件, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs1);
            sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            sw.WriteLine("<root>");
            sw.WriteLine("<ver>1</ver>");
            sw.WriteLine("<shutdownmode>"+ 关机模式.ToString() + "</shutdownmode>");
            sw.WriteLine("<type>"+ 类型列表.SelectedIndex.ToString() + "</type>");
            sw.WriteLine("<comparison>"+ 比较列表.SelectedIndex.ToString() + "</comparison>");
            sw.WriteLine("<cpu>"+ CPU核心选择.SelectedIndex.ToString() + "</cpu>");
            sw.WriteLine("<condition>"+ 条件输入框.Text + "</condition>");
            sw.WriteLine("<conditionalwaiting>"+ 条件多少秒开始1.Value.ToString() + "</conditionalwaiting>");
            sw.WriteLine("<shutdownwaiting>"+ 执行后提示关机时长1.Value.ToString() + "</shutdownwaiting>");
            sw.WriteLine("<forcedshutdown>"+ 强制关机.Checked.ToString() + "</forcedshutdown>");
            sw.WriteLine("<screenshotswitch>"+ 截图保存开关.Checked.ToString() + "</screenshotswitch>");
            sw.WriteLine("<screenshotfolder>"+ 截图保存路径.Text + "</screenshotfolder>");
            sw.WriteLine("<shutdowneventtracker>"+ 关闭事件跟踪程序开关.Checked.ToString() + "</shutdowneventtracker>");
            sw.WriteLine("<shutdowneventtrackerset>"+ 关闭事件跟踪程序设置.SelectedIndex.ToString() + "</shutdowneventtrackerset>");
            sw.WriteLine("</root>");
            sw.Close();
        }

        private void 准备启动任务()
        {
            SettingLoad.任务启动时间 = DateTime.Now.ToString();
            SettingLoad.关机模式 = 关机模式;
            for (int i = 0; i < SettingLoad.关机模式文本数组.Length; i++)
            {
                if (label1.Text.Substring(1, label1.Text.Length - 4) == SettingLoad.关机模式文本数组[i])
                {
                    SettingLoad.关机模式 = i;
                }
            }
            SettingLoad.类型 = 类型列表.SelectedIndex;
            SettingLoad.比较 = 比较列表.SelectedIndex;
            SettingLoad.CPU核心 = CPU核心选择.SelectedIndex;
            SettingLoad.条件 = 条件输入框.Text;
            SettingLoad.条件多少秒开始 = 条件多少秒开始1.Value;
            SettingLoad.执行后提示关机时长 = 执行后提示关机时长1.Value;
            SettingLoad.强制关机 = 强制关机.Checked;
            SettingLoad.截图保存 = 截图保存开关.Checked;
            SettingLoad.截图保存路径 = 截图保存路径.Text;
            SettingLoad.关闭事件跟踪程序开关 = 关闭事件跟踪程序开关.Checked;
            SettingLoad.关闭事件跟踪程序设置 = 关闭事件跟踪程序设置.SelectedIndex;
            启动任务代理(true);
        }

        private void 准备中止任务()
        {
            if (启动任务代理 != null)
            {
                启动任务代理(false);
            }
        }

        private void MainWindow_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized && 主窗体关闭代理 != null)
            {
                //窗口打开 = false;
                主窗体关闭代理(false);
            }
        }

        private void 类型列表_SelectedIndexChanged(object sender, EventArgs e)
        {
            linkLabel1.Visible = false;
            比较列表.Enabled = true;
            类型介绍框.Text = SettingLoad.类型列表介绍数组[类型列表.SelectedIndex];
            if (类型列表.SelectedIndex == 0)
            {
                DateTime 当前的日期 = DateTime.Now;
                条件输入框.Text = 当前的日期.Year + "-" + 当前的日期.Month + "-" + 当前的日期.Day + "-" + 当前的日期.Hour + "-" + 当前的日期.Minute + "-" + 当前的日期.Second;
                条件单位.Text = "秒";
            }
            else if (类型列表.SelectedIndex == 1 || 类型列表.SelectedIndex == 2 || 类型列表.SelectedIndex == 3)
            {
                条件输入框.Text = "50";
                条件单位.Text = "%";
            }
            else if (类型列表.SelectedIndex == 4 || 类型列表.SelectedIndex == 5)
            {
                条件输入框.Text = "1024";
                条件单位.Text = "MB";
            }
            else if (类型列表.SelectedIndex == 6 || 类型列表.SelectedIndex == 7 || 类型列表.SelectedIndex == 8)
            {
                条件输入框.Text = "100";
                条件单位.Text = "次/秒";
            }
            else if (类型列表.SelectedIndex == 9 || 类型列表.SelectedIndex == 10 || 类型列表.SelectedIndex == 11)
            {
                条件输入框.Text = "512";
                条件单位.Text = "KB/秒";
            }
            else if (类型列表.SelectedIndex == 12)
            {
                条件输入框.Text = "explorer.exe";
                条件单位.Text = "进程名";
            }
            else if (类型列表.SelectedIndex == 13)
            {
                条件输入框.Text = "1000-1000-255-255-255";
                条件单位.Text = "XYRGB";
                linkLabel1.Text = 条件单位.Text;
                linkLabel1.Visible = true;
            }
        }

        private void 自动重启并打开高级启动菜单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            关机模式 = 7;
            更改模式文字();
        }

        private void 打开截图文件夹_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(截图保存路径.Text))
                {
                    System.Diagnostics.Process.Start("explorer.exe", 截图保存路径.Text);
                }
                else
                {
                    if (MessageBox.Show("文件夹不存在，要新建文件夹吗？", "打开失败", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                        Directory.CreateDirectory(截图保存路径.Text);
                        System.Diagnostics.Process.Start("explorer.exe", 截图保存路径.Text);
                    };
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "打开失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (类型列表.SelectedIndex == 13)
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
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            关机模式 = 8;
            更改模式文字();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            关机模式 = 9;
            更改模式文字();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            关机模式 = 10;
            更改模式文字();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            关机模式 = 11;
            更改模式文字();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            关机模式 = 12;
            更改模式文字();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            关机模式 = 13;
            更改模式文字();
        }

        private void 载入语言()
        {
            模式AToolStripMenuItem.Text = Language.s(150);
            提醒我ToolStripMenuItem.Text = Language.s(173);
            自动关机ToolStripMenuItem.Text = Language.s(151);
            自动重启ToolStripMenuItem.Text = Language.s(152);
            自动休眠ToolStripMenuItem.Text = Language.s(153);
            自动注销ToolStripMenuItem.Text = Language.s(154);
            自动关机并准备快速启动ToolStripMenuItem.Text = Language.s(155);
            自动重启并打开之前的程序ToolStripMenuItem.Text = Language.s(156);
            自动重启并打开高级启动菜单ToolStripMenuItem.Text = Language.s(157);
            模式BToolStripMenuItem.Text = Language.s(158);
            toolStripMenuItem4.Text = Language.s(159);
            toolStripMenuItem5.Text = Language.s(160);
            toolStripMenuItem8.Text = Language.s(161);
            toolStripMenuItem6.Text = Language.s(162);
            toolStripMenuItem9.Text = Language.s(163);
            toolStripMenuItem7.Text = Language.s(164);
            label3.Text = Language.s(174);
            label4.Text = Language.s(175);
            label2.Text = Language.s(176);
            label6.Text = Language.s(177);
            label7.Text = Language.s(178);
            label5.Text = Language.s(179);
            强制关机.Text = Language.s(180);
            截图保存开关.Text = Language.s(181);
            截图保存路径.Text = "C:\\"+Language.s(182)+"\\";
            导入配置按钮.Text = Language.s(183);
            导出配置按钮.Text = Language.s(184);
            关闭事件跟踪程序开关.Text = Language.s(185);
            label8.Text = "| " + Language.s(186);
            label9.Text = Language.s(187) + " |";
            label10.Text = Language.s(188);
            toolStripStatusLabel1.Text = Language.s(189);
            toolStripStatusLabel2.Text = Language.s(190);
            toolStripStatusLabel3.Text = Language.s(191);
            toolStripStatusLabel4.Text = Language.s(192);
            暂停提示.Text = Language.s(193);
        }
    }
}
