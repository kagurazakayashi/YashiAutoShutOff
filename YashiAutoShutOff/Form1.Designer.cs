namespace YashiAutoShutOff
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.窗口管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示主窗口SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.仅启动系统监视器VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开数码测色计MToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.性能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.暂停PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.优先级NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pu0 = new System.Windows.Forms.ToolStripMenuItem();
            this.pu1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pu2 = new System.Windows.Forms.ToolStripMenuItem();
            this.pu3 = new System.Windows.Forms.ToolStripMenuItem();
            this.pu4 = new System.Windows.Forms.ToolStripMenuItem();
            this.pu5 = new System.Windows.Forms.ToolStripMenuItem();
            this.空闲IToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.维护ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windows任务管理器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修复Windows性能计数器注册表RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.抹掉用户设置EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.强制退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.立即操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭或注销ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自动关机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自动重启ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自动休眠ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自动注销ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.自动关机并准备快速启动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自动重启并打开之前的程序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自动重启并打开高级启动菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消系统关机计划CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开用户设置文件夹DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看关机事件日志LToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.关于和退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭此菜单QToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.主计时器 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipTitle = "雅诗智能关机";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "雅诗智能关机";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.窗口管理ToolStripMenuItem,
            this.显示主窗口SToolStripMenuItem,
            this.仅启动系统监视器VToolStripMenuItem,
            this.打开数码测色计MToolStripMenuItem,
            this.toolStripMenuItem1,
            this.性能ToolStripMenuItem,
            this.暂停PToolStripMenuItem,
            this.优先级NToolStripMenuItem,
            this.toolStripMenuItem2,
            this.维护ToolStripMenuItem,
            this.windows任务管理器ToolStripMenuItem,
            this.修复Windows性能计数器注册表RToolStripMenuItem,
            this.抹掉用户设置EToolStripMenuItem,
            this.强制退出ToolStripMenuItem,
            this.toolStripMenuItem3,
            this.立即操作ToolStripMenuItem,
            this.关闭或注销ToolStripMenuItem,
            this.取消系统关机计划CToolStripMenuItem,
            this.toolStripMenuItem4,
            this.设置ToolStripMenuItem,
            this.打开用户设置文件夹DToolStripMenuItem,
            this.查看关机事件日志LToolStripMenuItem,
            this.toolStripMenuItem5,
            this.关于和退出ToolStripMenuItem,
            this.关于AToolStripMenuItem,
            this.退出XToolStripMenuItem,
            this.关闭此菜单QToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(299, 584);
            // 
            // 窗口管理ToolStripMenuItem
            // 
            this.窗口管理ToolStripMenuItem.Enabled = false;
            this.窗口管理ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.窗口管理ToolStripMenuItem.Name = "窗口管理ToolStripMenuItem";
            this.窗口管理ToolStripMenuItem.Size = new System.Drawing.Size(298, 24);
            this.窗口管理ToolStripMenuItem.Text = "窗口管理";
            // 
            // 显示主窗口SToolStripMenuItem
            // 
            this.显示主窗口SToolStripMenuItem.Enabled = false;
            this.显示主窗口SToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.显示主窗口SToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources.favicon;
            this.显示主窗口SToolStripMenuItem.Name = "显示主窗口SToolStripMenuItem";
            this.显示主窗口SToolStripMenuItem.Size = new System.Drawing.Size(298, 24);
            this.显示主窗口SToolStripMenuItem.Text = "打开/关闭 设置窗口(&S)";
            this.显示主窗口SToolStripMenuItem.Click += new System.EventHandler(this.显示主窗口SToolStripMenuItem_Click);
            // 
            // 仅启动系统监视器VToolStripMenuItem
            // 
            this.仅启动系统监视器VToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.仅启动系统监视器VToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources.imageres_5323;
            this.仅启动系统监视器VToolStripMenuItem.Name = "仅启动系统监视器VToolStripMenuItem";
            this.仅启动系统监视器VToolStripMenuItem.Size = new System.Drawing.Size(298, 24);
            this.仅启动系统监视器VToolStripMenuItem.Text = "打开/关闭 系统监视器(&V)";
            this.仅启动系统监视器VToolStripMenuItem.Click += new System.EventHandler(this.仅启动系统监视器VToolStripMenuItem_Click);
            // 
            // 打开数码测色计MToolStripMenuItem
            // 
            this.打开数码测色计MToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.打开数码测色计MToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources.imageres_168;
            this.打开数码测色计MToolStripMenuItem.Name = "打开数码测色计MToolStripMenuItem";
            this.打开数码测色计MToolStripMenuItem.Size = new System.Drawing.Size(298, 24);
            this.打开数码测色计MToolStripMenuItem.Text = "打开 数码测色计(&M)";
            this.打开数码测色计MToolStripMenuItem.Click += new System.EventHandler(this.打开数码测色计MToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(295, 6);
            // 
            // 性能ToolStripMenuItem
            // 
            this.性能ToolStripMenuItem.Enabled = false;
            this.性能ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.性能ToolStripMenuItem.Name = "性能ToolStripMenuItem";
            this.性能ToolStripMenuItem.Size = new System.Drawing.Size(298, 24);
            this.性能ToolStripMenuItem.Text = "性能";
            // 
            // 暂停PToolStripMenuItem
            // 
            this.暂停PToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.暂停PToolStripMenuItem.Name = "暂停PToolStripMenuItem";
            this.暂停PToolStripMenuItem.Size = new System.Drawing.Size(298, 24);
            this.暂停PToolStripMenuItem.Text = "暂停/推迟执行时间(&P)";
            this.暂停PToolStripMenuItem.Click += new System.EventHandler(this.暂停PToolStripMenuItem_Click);
            // 
            // 优先级NToolStripMenuItem
            // 
            this.优先级NToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pu0,
            this.pu1,
            this.pu2,
            this.pu3,
            this.pu4,
            this.pu5,
            this.空闲IToolStripMenuItem});
            this.优先级NToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.优先级NToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources.imageres_34;
            this.优先级NToolStripMenuItem.Name = "优先级NToolStripMenuItem";
            this.优先级NToolStripMenuItem.Size = new System.Drawing.Size(298, 24);
            this.优先级NToolStripMenuItem.Text = "处理器优先级(&N)";
            // 
            // pu0
            // 
            this.pu0.Enabled = false;
            this.pu0.Name = "pu0";
            this.pu0.Size = new System.Drawing.Size(154, 24);
            this.pu0.Text = "实时(&R)";
            this.pu0.Click += new System.EventHandler(this.pu0_Click);
            // 
            // pu1
            // 
            this.pu1.Name = "pu1";
            this.pu1.Size = new System.Drawing.Size(154, 24);
            this.pu1.Text = "高(&H)";
            this.pu1.Click += new System.EventHandler(this.pu1_Click);
            // 
            // pu2
            // 
            this.pu2.Checked = true;
            this.pu2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pu2.Name = "pu2";
            this.pu2.Size = new System.Drawing.Size(154, 24);
            this.pu2.Text = "高于正常(&A)";
            this.pu2.Click += new System.EventHandler(this.pu2_Click);
            // 
            // pu3
            // 
            this.pu3.Name = "pu3";
            this.pu3.Size = new System.Drawing.Size(154, 24);
            this.pu3.Text = "正常(&N)";
            this.pu3.Click += new System.EventHandler(this.pu3_Click);
            // 
            // pu4
            // 
            this.pu4.Name = "pu4";
            this.pu4.Size = new System.Drawing.Size(154, 24);
            this.pu4.Text = "低于正常(&B)";
            this.pu4.Click += new System.EventHandler(this.pu4_Click);
            // 
            // pu5
            // 
            this.pu5.Name = "pu5";
            this.pu5.Size = new System.Drawing.Size(154, 24);
            this.pu5.Text = "低(&L)";
            this.pu5.Click += new System.EventHandler(this.pu5_Click);
            // 
            // 空闲IToolStripMenuItem
            // 
            this.空闲IToolStripMenuItem.Enabled = false;
            this.空闲IToolStripMenuItem.Name = "空闲IToolStripMenuItem";
            this.空闲IToolStripMenuItem.Size = new System.Drawing.Size(154, 24);
            this.空闲IToolStripMenuItem.Text = "空闲(&I)";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(295, 6);
            // 
            // 维护ToolStripMenuItem
            // 
            this.维护ToolStripMenuItem.Enabled = false;
            this.维护ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.维护ToolStripMenuItem.Name = "维护ToolStripMenuItem";
            this.维护ToolStripMenuItem.Size = new System.Drawing.Size(298, 24);
            this.维护ToolStripMenuItem.Text = "维护";
            // 
            // windows任务管理器ToolStripMenuItem
            // 
            this.windows任务管理器ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.windows任务管理器ToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources.imageres_5374;
            this.windows任务管理器ToolStripMenuItem.Name = "windows任务管理器ToolStripMenuItem";
            this.windows任务管理器ToolStripMenuItem.Size = new System.Drawing.Size(298, 24);
            this.windows任务管理器ToolStripMenuItem.Text = "Windows任务管理器(&T)";
            this.windows任务管理器ToolStripMenuItem.Click += new System.EventHandler(this.windows任务管理器ToolStripMenuItem_Click);
            // 
            // 修复Windows性能计数器注册表RToolStripMenuItem
            // 
            this.修复Windows性能计数器注册表RToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.修复Windows性能计数器注册表RToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources.imageres_5364;
            this.修复Windows性能计数器注册表RToolStripMenuItem.Name = "修复Windows性能计数器注册表RToolStripMenuItem";
            this.修复Windows性能计数器注册表RToolStripMenuItem.Size = new System.Drawing.Size(298, 24);
            this.修复Windows性能计数器注册表RToolStripMenuItem.Text = "修复Windows性能计数器注册表(&R)";
            this.修复Windows性能计数器注册表RToolStripMenuItem.Click += new System.EventHandler(this.修复Windows性能计数器注册表RToolStripMenuItem_Click);
            // 
            // 抹掉用户设置EToolStripMenuItem
            // 
            this.抹掉用户设置EToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.抹掉用户设置EToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources.imageres_98;
            this.抹掉用户设置EToolStripMenuItem.Name = "抹掉用户设置EToolStripMenuItem";
            this.抹掉用户设置EToolStripMenuItem.Size = new System.Drawing.Size(298, 24);
            this.抹掉用户设置EToolStripMenuItem.Text = "抹掉用户设置";
            this.抹掉用户设置EToolStripMenuItem.Click += new System.EventHandler(this.抹掉用户设置EToolStripMenuItem_Click);
            // 
            // 强制退出ToolStripMenuItem
            // 
            this.强制退出ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.强制退出ToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources.imageres_105;
            this.强制退出ToolStripMenuItem.Name = "强制退出ToolStripMenuItem";
            this.强制退出ToolStripMenuItem.Size = new System.Drawing.Size(298, 24);
            this.强制退出ToolStripMenuItem.Text = "强制完全退出/结束进程";
            this.强制退出ToolStripMenuItem.Click += new System.EventHandler(this.强制退出ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(295, 6);
            // 
            // 立即操作ToolStripMenuItem
            // 
            this.立即操作ToolStripMenuItem.Enabled = false;
            this.立即操作ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.立即操作ToolStripMenuItem.Name = "立即操作ToolStripMenuItem";
            this.立即操作ToolStripMenuItem.Size = new System.Drawing.Size(298, 24);
            this.立即操作ToolStripMenuItem.Text = "立即操作";
            // 
            // 关闭或注销ToolStripMenuItem
            // 
            this.关闭或注销ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.自动关机ToolStripMenuItem,
            this.自动重启ToolStripMenuItem,
            this.自动休眠ToolStripMenuItem,
            this.自动注销ToolStripMenuItem,
            this.toolStripSeparator1,
            this.自动关机并准备快速启动ToolStripMenuItem,
            this.自动重启并打开之前的程序ToolStripMenuItem,
            this.自动重启并打开高级启动菜单ToolStripMenuItem});
            this.关闭或注销ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.关闭或注销ToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources.imageres_1008;
            this.关闭或注销ToolStripMenuItem.Name = "关闭或注销ToolStripMenuItem";
            this.关闭或注销ToolStripMenuItem.Size = new System.Drawing.Size(298, 24);
            this.关闭或注销ToolStripMenuItem.Text = "关闭或注销(&U)";
            // 
            // 自动关机ToolStripMenuItem
            // 
            this.自动关机ToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources.imageres_1008;
            this.自动关机ToolStripMenuItem.Name = "自动关机ToolStripMenuItem";
            this.自动关机ToolStripMenuItem.Size = new System.Drawing.Size(280, 24);
            this.自动关机ToolStripMenuItem.Text = "关机(&U)";
            this.自动关机ToolStripMenuItem.Click += new System.EventHandler(this.自动关机ToolStripMenuItem_Click);
            // 
            // 自动重启ToolStripMenuItem
            // 
            this.自动重启ToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources.imageres_147;
            this.自动重启ToolStripMenuItem.Name = "自动重启ToolStripMenuItem";
            this.自动重启ToolStripMenuItem.Size = new System.Drawing.Size(280, 24);
            this.自动重启ToolStripMenuItem.Text = "重启(&R)";
            this.自动重启ToolStripMenuItem.Click += new System.EventHandler(this.自动重启ToolStripMenuItem_Click);
            // 
            // 自动休眠ToolStripMenuItem
            // 
            this.自动休眠ToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources.imageres_149;
            this.自动休眠ToolStripMenuItem.Name = "自动休眠ToolStripMenuItem";
            this.自动休眠ToolStripMenuItem.Size = new System.Drawing.Size(280, 24);
            this.自动休眠ToolStripMenuItem.Text = "休眠(&S)";
            this.自动休眠ToolStripMenuItem.Click += new System.EventHandler(this.自动休眠ToolStripMenuItem_Click);
            // 
            // 自动注销ToolStripMenuItem
            // 
            this.自动注销ToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources.imageres_5351;
            this.自动注销ToolStripMenuItem.Name = "自动注销ToolStripMenuItem";
            this.自动注销ToolStripMenuItem.Size = new System.Drawing.Size(280, 24);
            this.自动注销ToolStripMenuItem.Text = "注销(&I)";
            this.自动注销ToolStripMenuItem.Click += new System.EventHandler(this.自动注销ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(277, 6);
            // 
            // 自动关机并准备快速启动ToolStripMenuItem
            // 
            this.自动关机并准备快速启动ToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources.imageres_5371;
            this.自动关机并准备快速启动ToolStripMenuItem.Name = "自动关机并准备快速启动ToolStripMenuItem";
            this.自动关机并准备快速启动ToolStripMenuItem.Size = new System.Drawing.Size(280, 24);
            this.自动关机并准备快速启动ToolStripMenuItem.Text = "自动关机并准备快速启动(&Q)";
            this.自动关机并准备快速启动ToolStripMenuItem.Click += new System.EventHandler(this.自动关机并准备快速启动ToolStripMenuItem_Click);
            // 
            // 自动重启并打开之前的程序ToolStripMenuItem
            // 
            this.自动重启并打开之前的程序ToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources.imageres_171;
            this.自动重启并打开之前的程序ToolStripMenuItem.Name = "自动重启并打开之前的程序ToolStripMenuItem";
            this.自动重启并打开之前的程序ToolStripMenuItem.Size = new System.Drawing.Size(280, 24);
            this.自动重启并打开之前的程序ToolStripMenuItem.Text = "自动重启并打开之前的程序(&E)";
            this.自动重启并打开之前的程序ToolStripMenuItem.Click += new System.EventHandler(this.自动重启并打开之前的程序ToolStripMenuItem_Click);
            // 
            // 自动重启并打开高级启动菜单ToolStripMenuItem
            // 
            this.自动重启并打开高级启动菜单ToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources.imageres_5372;
            this.自动重启并打开高级启动菜单ToolStripMenuItem.Name = "自动重启并打开高级启动菜单ToolStripMenuItem";
            this.自动重启并打开高级启动菜单ToolStripMenuItem.Size = new System.Drawing.Size(280, 24);
            this.自动重启并打开高级启动菜单ToolStripMenuItem.Text = "自动重启并打开高级启动菜单(&A)";
            this.自动重启并打开高级启动菜单ToolStripMenuItem.Click += new System.EventHandler(this.自动重启并打开高级启动菜单ToolStripMenuItem_Click);
            // 
            // 取消系统关机计划CToolStripMenuItem
            // 
            this.取消系统关机计划CToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.取消系统关机计划CToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources.imageres_1027;
            this.取消系统关机计划CToolStripMenuItem.Name = "取消系统关机计划CToolStripMenuItem";
            this.取消系统关机计划CToolStripMenuItem.Size = new System.Drawing.Size(298, 24);
            this.取消系统关机计划CToolStripMenuItem.Text = "取消系统的关机计划(&C)";
            this.取消系统关机计划CToolStripMenuItem.Click += new System.EventHandler(this.取消系统关机计划CToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(295, 6);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Enabled = false;
            this.设置ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(298, 24);
            this.设置ToolStripMenuItem.Text = "设置管理";
            // 
            // 打开用户设置文件夹DToolStripMenuItem
            // 
            this.打开用户设置文件夹DToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.打开用户设置文件夹DToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources.imageres_178;
            this.打开用户设置文件夹DToolStripMenuItem.Name = "打开用户设置文件夹DToolStripMenuItem";
            this.打开用户设置文件夹DToolStripMenuItem.Size = new System.Drawing.Size(298, 24);
            this.打开用户设置文件夹DToolStripMenuItem.Text = "打开用户设置文件夹(&D)";
            this.打开用户设置文件夹DToolStripMenuItem.Click += new System.EventHandler(this.打开用户设置文件夹DToolStripMenuItem_Click);
            // 
            // 查看关机事件日志LToolStripMenuItem
            // 
            this.查看关机事件日志LToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.查看关机事件日志LToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources.imageres_1303;
            this.查看关机事件日志LToolStripMenuItem.Name = "查看关机事件日志LToolStripMenuItem";
            this.查看关机事件日志LToolStripMenuItem.Size = new System.Drawing.Size(298, 24);
            this.查看关机事件日志LToolStripMenuItem.Text = "查看关机事件日志(&L)";
            this.查看关机事件日志LToolStripMenuItem.Click += new System.EventHandler(this.查看关机事件日志LToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(295, 6);
            // 
            // 关于和退出ToolStripMenuItem
            // 
            this.关于和退出ToolStripMenuItem.Enabled = false;
            this.关于和退出ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.关于和退出ToolStripMenuItem.Name = "关于和退出ToolStripMenuItem";
            this.关于和退出ToolStripMenuItem.Size = new System.Drawing.Size(298, 24);
            this.关于和退出ToolStripMenuItem.Text = "关于和退出";
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.关于AToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources.imageres_81;
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(298, 24);
            this.关于AToolStripMenuItem.Text = "关于和使用约定(&A)";
            this.关于AToolStripMenuItem.Click += new System.EventHandler(this.关于AToolStripMenuItem_Click);
            // 
            // 退出XToolStripMenuItem
            // 
            this.退出XToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.退出XToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources.imageres_89;
            this.退出XToolStripMenuItem.Name = "退出XToolStripMenuItem";
            this.退出XToolStripMenuItem.Size = new System.Drawing.Size(298, 24);
            this.退出XToolStripMenuItem.Text = "完全退出(&X)";
            this.退出XToolStripMenuItem.Click += new System.EventHandler(this.退出XToolStripMenuItem_Click);
            // 
            // 关闭此菜单QToolStripMenuItem
            // 
            this.关闭此菜单QToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.关闭此菜单QToolStripMenuItem.Name = "关闭此菜单QToolStripMenuItem";
            this.关闭此菜单QToolStripMenuItem.Size = new System.Drawing.Size(298, 24);
            this.关闭此菜单QToolStripMenuItem.Text = "关闭此菜单(&Q)";
            // 
            // 主计时器
            // 
            this.主计时器.Enabled = true;
            this.主计时器.Interval = 1000;
            this.主计时器.Tick += new System.EventHandler(this.主计时器_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(120, 23);
            this.ControlBox = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Opacity = 0D;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 退出XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示主窗口SToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.Timer 主计时器;
        private System.Windows.Forms.ToolStripMenuItem 暂停PToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem windows任务管理器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消系统关机计划CToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 仅启动系统监视器VToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修复Windows性能计数器注册表RToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭或注销ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自动关机ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自动重启ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自动休眠ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自动注销ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 自动关机并准备快速启动ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自动重启并打开之前的程序ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自动重启并打开高级启动菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem 关闭此菜单QToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看关机事件日志LToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem 优先级NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pu0;
        private System.Windows.Forms.ToolStripMenuItem pu1;
        private System.Windows.Forms.ToolStripMenuItem pu2;
        private System.Windows.Forms.ToolStripMenuItem pu3;
        private System.Windows.Forms.ToolStripMenuItem pu4;
        private System.Windows.Forms.ToolStripMenuItem pu5;
        private System.Windows.Forms.ToolStripMenuItem 空闲IToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开用户设置文件夹DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 抹掉用户设置EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 强制退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 窗口管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 性能ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 维护ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 立即操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于和退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开数码测色计MToolStripMenuItem;
    }
}

