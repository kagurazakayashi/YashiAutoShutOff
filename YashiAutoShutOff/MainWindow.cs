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

namespace YashiAutoShutOff
{
    public partial class MainWindow : Form
    {
        public bool 窗口打开 = false;
        private int 开关动画计数器 = 0;
        public bool 总开关 = false;

        public string[] 关机模式文本数组 = new string[] { "自动提醒", "自动关机", "自动重启", "自动休眠", "自动注销", "自动关机并准备快速启动", "自动重启并打开之前的程序" };
        public int 关机模式 = 1;
        public int 判断类型 = 0;
        public int 比较方法 = 0;
        public int CPU核心 = 0;
        public int 选中的CPU核心 = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            初始化选择();
            读入默认设置();
        }

        private void 更改模式文字()
        {
            label1.Text = " " + 关机模式文本数组[关机模式] + " ▼";
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            窗口打开 = false;
        }

        private void 总开关1_Click(object sender, EventArgs e)
        {
            开关动画计数器 = 0;
            总开关1.Enabled = false;
            总开关2.Enabled = false;
            if (总开关1.Text == "&OFF")
            {
                总开关1.Text = "&ON";
                总开关 = true;
            }
            else
            {
                总开关1.Text = "&OFF";
                总开关 = false;
            }
            开关动画控制器.Enabled = true;
        }

        private void 总开关2_Click(object sender, EventArgs e)
        {
            总开关1_Click(sender, e);
        }

        private void 开关动画控制器_Tick(object sender, EventArgs e)
        {
            int 动画速度 = 2;
            开关动画计数器++;
            if (总开关1.Text == "&OFF")
            {
                总开关1.Location = new Point(总开关1.Location.X - 动画速度, 总开关1.Location.Y);
            }
            else
            {
                总开关1.Location = new Point(总开关1.Location.X + 动画速度, 总开关1.Location.Y);
            }
            if (开关动画计数器 >= 75 / 动画速度)
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
            打开文件对话框.InitialDirectory = Directory.GetCurrentDirectory();
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
            保存文件对话框.InitialDirectory = Directory.GetCurrentDirectory();
            if (保存文件对话框.ShowDialog() == DialogResult.OK)
            {
                String 设置文件路径 = 保存文件对话框.FileName.ToString();
                保存设置(设置文件路径);
            }
        }

        private void 初始化选择()
        {
            类型列表.SelectedIndex = 0;
            比较列表.SelectedIndex = 0;
            CPU核心选择.SelectedIndex = 0;
            关闭事件跟踪程序设置.SelectedIndex = 20;
        }

        public void 读入默认设置()
        {
            String 默认配置文件 = Directory.GetCurrentDirectory() + "\\default.xml";
            if (!File.Exists(默认配置文件))
            {
                新建设置文件(默认配置文件);
            }
            读入设置(默认配置文件);
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
    }
}
