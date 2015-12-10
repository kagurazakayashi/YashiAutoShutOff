namespace YashiAutoShutOff
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.处理器利用率条 = new System.Windows.Forms.ToolStripProgressBar();
            this.处理器利用率显示 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.内存利用率条 = new System.Windows.Forms.ToolStripProgressBar();
            this.内存利用率显示 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.硬盘利用率条 = new System.Windows.Forms.ToolStripProgressBar();
            this.硬盘利用率显示 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.网络利用率条 = new System.Windows.Forms.ToolStripProgressBar();
            this.网络利用率显示 = new System.Windows.Forms.ToolStripStatusLabel();
            this.暂停提示 = new System.Windows.Forms.ToolStripStatusLabel();
            this.时间显示 = new System.Windows.Forms.ToolStripStatusLabel();
            this.开关动画控制器 = new System.Windows.Forms.Timer(this.components);
            this.关机方式选择菜单 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.提醒我ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自动关机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自动重启ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自动休眠ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自动注销ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.自动关机并准备快速启动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自动重启并打开之前的程序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.总开关2 = new System.Windows.Forms.ProgressBar();
            this.总开关1 = new System.Windows.Forms.Button();
            this.类型列表 = new System.Windows.Forms.ListBox();
            this.比较列表 = new System.Windows.Forms.ListBox();
            this.条件输入框 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CPU核心选择 = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.条件多少秒开始1 = new System.Windows.Forms.TrackBar();
            this.执行后提示关机时长1 = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.条件多少秒开始2 = new System.Windows.Forms.Label();
            this.执行后提示关机时长2 = new System.Windows.Forms.Label();
            this.条件满足进度 = new System.Windows.Forms.ProgressBar();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.截图保存路径 = new System.Windows.Forms.TextBox();
            this.截图文件夹选择按钮 = new System.Windows.Forms.Button();
            this.截图保存开关 = new System.Windows.Forms.CheckBox();
            this.强制关机 = new System.Windows.Forms.CheckBox();
            this.关闭事件跟踪程序设置 = new System.Windows.Forms.ComboBox();
            this.关闭事件跟踪程序开关 = new System.Windows.Forms.CheckBox();
            this.导入配置按钮 = new System.Windows.Forms.Button();
            this.文件夹选择对话框 = new System.Windows.Forms.FolderBrowserDialog();
            this.保存文件对话框 = new System.Windows.Forms.SaveFileDialog();
            this.打开文件对话框 = new System.Windows.Forms.OpenFileDialog();
            this.导出配置按钮 = new System.Windows.Forms.Button();
            this.条件单位 = new System.Windows.Forms.Label();
            this.自动重启并打开高级启动菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.关机方式选择菜单.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.条件多少秒开始1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.执行后提示关机时长1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.处理器利用率条,
            this.处理器利用率显示,
            this.toolStripStatusLabel2,
            this.内存利用率条,
            this.内存利用率显示,
            this.toolStripStatusLabel3,
            this.硬盘利用率条,
            this.硬盘利用率显示,
            this.toolStripStatusLabel4,
            this.网络利用率条,
            this.网络利用率显示,
            this.暂停提示,
            this.时间显示});
            this.statusStrip1.Location = new System.Drawing.Point(0, 510);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(859, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel1.Text = "处理器";
            // 
            // 处理器利用率条
            // 
            this.处理器利用率条.Maximum = 1000000;
            this.处理器利用率条.Name = "处理器利用率条";
            this.处理器利用率条.Size = new System.Drawing.Size(100, 16);
            this.处理器利用率条.Step = 1;
            this.处理器利用率条.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // 处理器利用率显示
            // 
            this.处理器利用率显示.Name = "处理器利用率显示";
            this.处理器利用率显示.Size = new System.Drawing.Size(26, 17);
            this.处理器利用率显示.Text = "0%";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabel2.Text = "内存";
            // 
            // 内存利用率条
            // 
            this.内存利用率条.Maximum = 1000000;
            this.内存利用率条.Name = "内存利用率条";
            this.内存利用率条.Size = new System.Drawing.Size(100, 16);
            this.内存利用率条.Step = 1;
            this.内存利用率条.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // 内存利用率显示
            // 
            this.内存利用率显示.Name = "内存利用率显示";
            this.内存利用率显示.Size = new System.Drawing.Size(26, 17);
            this.内存利用率显示.Text = "0%";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabel3.Text = "硬盘";
            // 
            // 硬盘利用率条
            // 
            this.硬盘利用率条.Maximum = 1000000;
            this.硬盘利用率条.Name = "硬盘利用率条";
            this.硬盘利用率条.Size = new System.Drawing.Size(100, 16);
            this.硬盘利用率条.Step = 1;
            this.硬盘利用率条.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // 硬盘利用率显示
            // 
            this.硬盘利用率显示.Name = "硬盘利用率显示";
            this.硬盘利用率显示.Size = new System.Drawing.Size(26, 17);
            this.硬盘利用率显示.Text = "0%";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabel4.Text = "网络";
            // 
            // 网络利用率条
            // 
            this.网络利用率条.Maximum = 1000000;
            this.网络利用率条.Name = "网络利用率条";
            this.网络利用率条.Size = new System.Drawing.Size(100, 16);
            this.网络利用率条.Step = 1;
            this.网络利用率条.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // 网络利用率显示
            // 
            this.网络利用率显示.Name = "网络利用率显示";
            this.网络利用率显示.Size = new System.Drawing.Size(26, 17);
            this.网络利用率显示.Text = "0%";
            // 
            // 暂停提示
            // 
            this.暂停提示.Enabled = false;
            this.暂停提示.Name = "暂停提示";
            this.暂停提示.Size = new System.Drawing.Size(32, 17);
            this.暂停提示.Text = "暂停";
            // 
            // 时间显示
            // 
            this.时间显示.Name = "时间显示";
            this.时间显示.Size = new System.Drawing.Size(56, 17);
            this.时间显示.Text = "时间显示";
            // 
            // 开关动画控制器
            // 
            this.开关动画控制器.Interval = 10;
            this.开关动画控制器.Tick += new System.EventHandler(this.开关动画控制器_Tick);
            // 
            // 关机方式选择菜单
            // 
            this.关机方式选择菜单.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.提醒我ToolStripMenuItem,
            this.自动关机ToolStripMenuItem,
            this.自动重启ToolStripMenuItem,
            this.自动休眠ToolStripMenuItem,
            this.自动注销ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.自动关机并准备快速启动ToolStripMenuItem,
            this.自动重启并打开之前的程序ToolStripMenuItem,
            this.自动重启并打开高级启动菜单ToolStripMenuItem});
            this.关机方式选择菜单.Name = "关机方式选择菜单";
            this.关机方式选择菜单.Size = new System.Drawing.Size(243, 208);
            // 
            // 提醒我ToolStripMenuItem
            // 
            this.提醒我ToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources._80;
            this.提醒我ToolStripMenuItem.Name = "提醒我ToolStripMenuItem";
            this.提醒我ToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.提醒我ToolStripMenuItem.Text = "&0.自动提醒";
            this.提醒我ToolStripMenuItem.Click += new System.EventHandler(this.提醒我ToolStripMenuItem_Click);
            // 
            // 自动关机ToolStripMenuItem
            // 
            this.自动关机ToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources._223;
            this.自动关机ToolStripMenuItem.Name = "自动关机ToolStripMenuItem";
            this.自动关机ToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.自动关机ToolStripMenuItem.Text = "&1.自动关机";
            this.自动关机ToolStripMenuItem.Click += new System.EventHandler(this.自动关机ToolStripMenuItem_Click);
            // 
            // 自动重启ToolStripMenuItem
            // 
            this.自动重启ToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources._243;
            this.自动重启ToolStripMenuItem.Name = "自动重启ToolStripMenuItem";
            this.自动重启ToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.自动重启ToolStripMenuItem.Text = "&2.自动重启";
            this.自动重启ToolStripMenuItem.Click += new System.EventHandler(this.自动重启ToolStripMenuItem_Click);
            // 
            // 自动休眠ToolStripMenuItem
            // 
            this.自动休眠ToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources._97;
            this.自动休眠ToolStripMenuItem.Name = "自动休眠ToolStripMenuItem";
            this.自动休眠ToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.自动休眠ToolStripMenuItem.Text = "&3.自动休眠";
            this.自动休眠ToolStripMenuItem.Click += new System.EventHandler(this.自动休眠ToolStripMenuItem_Click);
            // 
            // 自动注销ToolStripMenuItem
            // 
            this.自动注销ToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources._78;
            this.自动注销ToolStripMenuItem.Name = "自动注销ToolStripMenuItem";
            this.自动注销ToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.自动注销ToolStripMenuItem.Text = "&4.自动注销";
            this.自动注销ToolStripMenuItem.Click += new System.EventHandler(this.自动注销ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(242, 6);
            // 
            // 自动关机并准备快速启动ToolStripMenuItem
            // 
            this.自动关机并准备快速启动ToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources._223;
            this.自动关机并准备快速启动ToolStripMenuItem.Name = "自动关机并准备快速启动ToolStripMenuItem";
            this.自动关机并准备快速启动ToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.自动关机并准备快速启动ToolStripMenuItem.Text = "&5.自动关机并准备快速启动";
            this.自动关机并准备快速启动ToolStripMenuItem.Click += new System.EventHandler(this.自动关机并准备快速启动ToolStripMenuItem_Click);
            // 
            // 自动重启并打开之前的程序ToolStripMenuItem
            // 
            this.自动重启并打开之前的程序ToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources._243;
            this.自动重启并打开之前的程序ToolStripMenuItem.Name = "自动重启并打开之前的程序ToolStripMenuItem";
            this.自动重启并打开之前的程序ToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.自动重启并打开之前的程序ToolStripMenuItem.Text = "&6.自动重启并打开之前的程序";
            this.自动重启并打开之前的程序ToolStripMenuItem.Click += new System.EventHandler(this.自动重启并打开之前的程序ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.PowderBlue;
            this.label1.Cursor = System.Windows.Forms.Cursors.PanSouth;
            this.label1.Font = new System.Drawing.Font("微软雅黑 Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(-1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(860, 64);
            this.label1.TabIndex = 2;
            this.label1.Text = " 自动关机 ▼";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // 总开关2
            // 
            this.总开关2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.总开关2.Location = new System.Drawing.Point(703, 7);
            this.总开关2.Maximum = 2;
            this.总开关2.Name = "总开关2";
            this.总开关2.Size = new System.Drawing.Size(150, 50);
            this.总开关2.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.总开关2.TabIndex = 0;
            this.总开关2.Value = 1;
            this.总开关2.Click += new System.EventHandler(this.总开关2_Click);
            // 
            // 总开关1
            // 
            this.总开关1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.总开关1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.总开关1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.总开关1.Location = new System.Drawing.Point(703, 7);
            this.总开关1.Name = "总开关1";
            this.总开关1.Size = new System.Drawing.Size(75, 50);
            this.总开关1.TabIndex = 1;
            this.总开关1.Text = "&OFF";
            this.总开关1.UseVisualStyleBackColor = true;
            this.总开关1.Click += new System.EventHandler(this.总开关1_Click);
            // 
            // 类型列表
            // 
            this.类型列表.Cursor = System.Windows.Forms.Cursors.Hand;
            this.类型列表.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.类型列表.FormattingEnabled = true;
            this.类型列表.ItemHeight = 17;
            this.类型列表.Location = new System.Drawing.Point(26, 105);
            this.类型列表.Name = "类型列表";
            this.类型列表.Size = new System.Drawing.Size(336, 327);
            this.类型列表.TabIndex = 3;
            this.类型列表.SelectedIndexChanged += new System.EventHandler(this.类型列表_SelectedIndexChanged);
            // 
            // 比较列表
            // 
            this.比较列表.Cursor = System.Windows.Forms.Cursors.Hand;
            this.比较列表.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.比较列表.FormattingEnabled = true;
            this.比较列表.ItemHeight = 17;
            this.比较列表.Location = new System.Drawing.Point(368, 105);
            this.比较列表.Name = "比较列表";
            this.比较列表.Size = new System.Drawing.Size(158, 106);
            this.比较列表.TabIndex = 4;
            // 
            // 条件输入框
            // 
            this.条件输入框.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.条件输入框.Location = new System.Drawing.Point(532, 105);
            this.条件输入框.Name = "条件输入框";
            this.条件输入框.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.条件输入框.Size = new System.Drawing.Size(246, 23);
            this.条件输入框.TabIndex = 5;
            this.条件输入框.Text = "0000-00-00-00-00-00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(530, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "条件数值：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(24, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "要判断的类型：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(366, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "比较方法：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(368, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "CPU核心：";
            // 
            // CPU核心选择
            // 
            this.CPU核心选择.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CPU核心选择.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CPU核心选择.FormattingEnabled = true;
            this.CPU核心选择.ItemHeight = 17;
            this.CPU核心选择.Items.AddRange(new object[] {
            "总CPU利用率"});
            this.CPU核心选择.Location = new System.Drawing.Point(369, 241);
            this.CPU核心选择.Name = "CPU核心选择";
            this.CPU核心选择.Size = new System.Drawing.Size(158, 191);
            this.CPU核心选择.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(529, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "连续满足条件多少秒开始执行：";
            // 
            // 条件多少秒开始1
            // 
            this.条件多少秒开始1.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.条件多少秒开始1.LargeChange = 1;
            this.条件多少秒开始1.Location = new System.Drawing.Point(532, 153);
            this.条件多少秒开始1.Maximum = 1800;
            this.条件多少秒开始1.Name = "条件多少秒开始1";
            this.条件多少秒开始1.Size = new System.Drawing.Size(298, 45);
            this.条件多少秒开始1.SmallChange = 60;
            this.条件多少秒开始1.TabIndex = 12;
            this.条件多少秒开始1.TickFrequency = 60;
            this.条件多少秒开始1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.条件多少秒开始1.Value = 180;
            this.条件多少秒开始1.Scroll += new System.EventHandler(this.条件多少秒开始1_Scroll);
            // 
            // 执行后提示关机时长1
            // 
            this.执行后提示关机时长1.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.执行后提示关机时长1.LargeChange = 1;
            this.执行后提示关机时长1.Location = new System.Drawing.Point(531, 224);
            this.执行后提示关机时长1.Maximum = 180;
            this.执行后提示关机时长1.Name = "执行后提示关机时长1";
            this.执行后提示关机时长1.Size = new System.Drawing.Size(300, 45);
            this.执行后提示关机时长1.TabIndex = 13;
            this.执行后提示关机时长1.TickFrequency = 10;
            this.执行后提示关机时长1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.执行后提示关机时长1.Value = 30;
            this.执行后提示关机时长1.Scroll += new System.EventHandler(this.执行后提示关机时长1_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(529, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "开始执行后提示关机时长：";
            // 
            // 条件多少秒开始2
            // 
            this.条件多少秒开始2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.条件多少秒开始2.Location = new System.Drawing.Point(765, 130);
            this.条件多少秒开始2.Name = "条件多少秒开始2";
            this.条件多少秒开始2.Size = new System.Drawing.Size(65, 20);
            this.条件多少秒开始2.TabIndex = 15;
            this.条件多少秒开始2.Text = "0";
            this.条件多少秒开始2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // 执行后提示关机时长2
            // 
            this.执行后提示关机时长2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.执行后提示关机时长2.Location = new System.Drawing.Point(764, 201);
            this.执行后提示关机时长2.Name = "执行后提示关机时长2";
            this.执行后提示关机时长2.Size = new System.Drawing.Size(65, 20);
            this.执行后提示关机时长2.TabIndex = 16;
            this.执行后提示关机时长2.Text = "0";
            this.执行后提示关机时长2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // 条件满足进度
            // 
            this.条件满足进度.Enabled = false;
            this.条件满足进度.Location = new System.Drawing.Point(20, 467);
            this.条件满足进度.Name = "条件满足进度";
            this.条件满足进度.Size = new System.Drawing.Size(808, 27);
            this.条件满足进度.Step = 1;
            this.条件满足进度.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.条件满足进度.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(17, 446);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "| 条件满足";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(722, 445);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "条件达成 |";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(274, 445);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(303, 20);
            this.label10.TabIndex = 20;
            this.label10.Text = "0";
            this.label10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // 截图保存路径
            // 
            this.截图保存路径.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.截图保存路径.Location = new System.Drawing.Point(532, 322);
            this.截图保存路径.Name = "截图保存路径";
            this.截图保存路径.Size = new System.Drawing.Size(265, 23);
            this.截图保存路径.TabIndex = 23;
            this.截图保存路径.Text = "C:\\雅诗自动关机截图\\";
            // 
            // 截图文件夹选择按钮
            // 
            this.截图文件夹选择按钮.Cursor = System.Windows.Forms.Cursors.Hand;
            this.截图文件夹选择按钮.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.截图文件夹选择按钮.Location = new System.Drawing.Point(803, 319);
            this.截图文件夹选择按钮.Name = "截图文件夹选择按钮";
            this.截图文件夹选择按钮.Size = new System.Drawing.Size(30, 27);
            this.截图文件夹选择按钮.TabIndex = 24;
            this.截图文件夹选择按钮.Text = "…";
            this.截图文件夹选择按钮.UseVisualStyleBackColor = true;
            this.截图文件夹选择按钮.Click += new System.EventHandler(this.截图文件夹选择按钮_Click);
            // 
            // 截图保存开关
            // 
            this.截图保存开关.AutoSize = true;
            this.截图保存开关.Checked = true;
            this.截图保存开关.CheckState = System.Windows.Forms.CheckState.Checked;
            this.截图保存开关.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.截图保存开关.Location = new System.Drawing.Point(532, 301);
            this.截图保存开关.Name = "截图保存开关";
            this.截图保存开关.Size = new System.Drawing.Size(271, 21);
            this.截图保存开关.TabIndex = 25;
            this.截图保存开关.Text = "操作前自动捕获屏幕并保存到以下文件夹(&C)：";
            this.截图保存开关.UseVisualStyleBackColor = true;
            // 
            // 强制关机
            // 
            this.强制关机.AutoSize = true;
            this.强制关机.Checked = true;
            this.强制关机.CheckState = System.Windows.Forms.CheckState.Checked;
            this.强制关机.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.强制关机.Location = new System.Drawing.Point(532, 274);
            this.强制关机.Name = "强制关机";
            this.强制关机.Size = new System.Drawing.Size(293, 21);
            this.强制关机.TabIndex = 26;
            this.强制关机.Text = "即使程序没有响应或阻止关机，也仍然强制继续(&F)";
            this.强制关机.UseVisualStyleBackColor = true;
            // 
            // 关闭事件跟踪程序设置
            // 
            this.关闭事件跟踪程序设置.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.关闭事件跟踪程序设置.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.关闭事件跟踪程序设置.FormattingEnabled = true;
            this.关闭事件跟踪程序设置.Location = new System.Drawing.Point(530, 407);
            this.关闭事件跟踪程序设置.Name = "关闭事件跟踪程序设置";
            this.关闭事件跟踪程序设置.Size = new System.Drawing.Size(302, 25);
            this.关闭事件跟踪程序设置.TabIndex = 27;
            // 
            // 关闭事件跟踪程序开关
            // 
            this.关闭事件跟踪程序开关.AutoSize = true;
            this.关闭事件跟踪程序开关.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.关闭事件跟踪程序开关.Location = new System.Drawing.Point(531, 386);
            this.关闭事件跟踪程序开关.Name = "关闭事件跟踪程序开关";
            this.关闭事件跟踪程序开关.Size = new System.Drawing.Size(141, 21);
            this.关闭事件跟踪程序开关.TabIndex = 28;
            this.关闭事件跟踪程序开关.Text = "关闭事件跟踪程序(&Q)";
            this.关闭事件跟踪程序开关.UseVisualStyleBackColor = true;
            // 
            // 导入配置按钮
            // 
            this.导入配置按钮.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.导入配置按钮.Location = new System.Drawing.Point(532, 352);
            this.导入配置按钮.Name = "导入配置按钮";
            this.导入配置按钮.Size = new System.Drawing.Size(148, 29);
            this.导入配置按钮.TabIndex = 29;
            this.导入配置按钮.Text = "导入配置从(&O)...";
            this.导入配置按钮.UseVisualStyleBackColor = true;
            this.导入配置按钮.Click += new System.EventHandler(this.导入配置按钮_Click);
            // 
            // 导出配置按钮
            // 
            this.导出配置按钮.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.导出配置按钮.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.导出配置按钮.Location = new System.Drawing.Point(685, 352);
            this.导出配置按钮.Name = "导出配置按钮";
            this.导出配置按钮.Size = new System.Drawing.Size(148, 29);
            this.导出配置按钮.TabIndex = 30;
            this.导出配置按钮.Text = "导出配置到(&S)...";
            this.导出配置按钮.UseVisualStyleBackColor = true;
            this.导出配置按钮.Click += new System.EventHandler(this.导出配置按钮_Click);
            // 
            // 条件单位
            // 
            this.条件单位.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.条件单位.Location = new System.Drawing.Point(784, 108);
            this.条件单位.Name = "条件单位";
            this.条件单位.Size = new System.Drawing.Size(63, 20);
            this.条件单位.TabIndex = 31;
            this.条件单位.Text = "秒";
            // 
            // 自动重启并打开高级启动菜单ToolStripMenuItem
            // 
            this.自动重启并打开高级启动菜单ToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources._110;
            this.自动重启并打开高级启动菜单ToolStripMenuItem.Name = "自动重启并打开高级启动菜单ToolStripMenuItem";
            this.自动重启并打开高级启动菜单ToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.自动重启并打开高级启动菜单ToolStripMenuItem.Text = "&7.自动重启并打开高级启动菜单";
            this.自动重启并打开高级启动菜单ToolStripMenuItem.Click += new System.EventHandler(this.自动重启并打开高级启动菜单ToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 532);
            this.Controls.Add(this.条件单位);
            this.Controls.Add(this.导出配置按钮);
            this.Controls.Add(this.导入配置按钮);
            this.Controls.Add(this.关闭事件跟踪程序设置);
            this.Controls.Add(this.关闭事件跟踪程序开关);
            this.Controls.Add(this.强制关机);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.截图保存开关);
            this.Controls.Add(this.截图文件夹选择按钮);
            this.Controls.Add(this.截图保存路径);
            this.Controls.Add(this.条件输入框);
            this.Controls.Add(this.总开关1);
            this.Controls.Add(this.类型列表);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.比较列表);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.条件满足进度);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.执行后提示关机时长2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.条件多少秒开始2);
            this.Controls.Add(this.CPU核心选择);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.执行后提示关机时长1);
            this.Controls.Add(this.条件多少秒开始1);
            this.Controls.Add(this.总开关2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "雅诗智能关机 - 设置窗口";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.SizeChanged += new System.EventHandler(this.MainWindow_SizeChanged);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.关机方式选择菜单.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.条件多少秒开始1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.执行后提示关机时长1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.ToolStripProgressBar 处理器利用率条;
        public System.Windows.Forms.ToolStripStatusLabel 时间显示;
        public System.Windows.Forms.ToolStripStatusLabel 处理器利用率显示;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        public System.Windows.Forms.ToolStripProgressBar 内存利用率条;
        public System.Windows.Forms.ToolStripStatusLabel 内存利用率显示;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        public System.Windows.Forms.ToolStripProgressBar 硬盘利用率条;
        public System.Windows.Forms.ToolStripStatusLabel 硬盘利用率显示;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        public System.Windows.Forms.ToolStripProgressBar 网络利用率条;
        public System.Windows.Forms.ToolStripStatusLabel 网络利用率显示;
        public System.Windows.Forms.ToolStripStatusLabel 暂停提示;
        private System.Windows.Forms.Timer 开关动画控制器;
        private System.Windows.Forms.ContextMenuStrip 关机方式选择菜单;
        private System.Windows.Forms.ToolStripMenuItem 自动关机ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自动重启ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自动注销ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 提醒我ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自动休眠ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 自动关机并准备快速启动ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自动重启并打开之前的程序ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar 总开关2;
        private System.Windows.Forms.Button 总开关1;
        private System.Windows.Forms.ListBox 类型列表;
        private System.Windows.Forms.ListBox 比较列表;
        private System.Windows.Forms.TextBox 条件输入框;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ListBox CPU核心选择;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar 条件多少秒开始1;
        private System.Windows.Forms.TrackBar 执行后提示关机时长1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label 条件多少秒开始2;
        private System.Windows.Forms.Label 执行后提示关机时长2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox 截图保存路径;
        private System.Windows.Forms.Button 截图文件夹选择按钮;
        private System.Windows.Forms.CheckBox 截图保存开关;
        private System.Windows.Forms.CheckBox 强制关机;
        private System.Windows.Forms.ComboBox 关闭事件跟踪程序设置;
        private System.Windows.Forms.CheckBox 关闭事件跟踪程序开关;
        private System.Windows.Forms.Button 导入配置按钮;
        private System.Windows.Forms.Button 导出配置按钮;
        private System.Windows.Forms.FolderBrowserDialog 文件夹选择对话框;
        private System.Windows.Forms.SaveFileDialog 保存文件对话框;
        private System.Windows.Forms.OpenFileDialog 打开文件对话框;
        public System.Windows.Forms.ProgressBar 条件满足进度;
        public System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label 条件单位;
        private System.Windows.Forms.ToolStripMenuItem 自动重启并打开高级启动菜单ToolStripMenuItem;
    }
}