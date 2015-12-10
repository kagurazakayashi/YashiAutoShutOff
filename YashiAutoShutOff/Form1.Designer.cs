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
            this.显示主窗口SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.仅启动系统监视器VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.暂停PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.windows任务管理器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消系统关机计划CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.修复Windows性能计数器注册表RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.主计时器 = new System.Windows.Forms.Timer(this.components);
            this.关闭或注销ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自动关机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自动重启ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自动休眠ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自动注销ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.自动关机并准备快速启动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自动重启并打开之前的程序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自动重启并打开高级启动菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.关闭此菜单QToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.显示主窗口SToolStripMenuItem,
            this.仅启动系统监视器VToolStripMenuItem,
            this.toolStripMenuItem1,
            this.暂停PToolStripMenuItem,
            this.toolStripMenuItem2,
            this.windows任务管理器ToolStripMenuItem,
            this.修复Windows性能计数器注册表RToolStripMenuItem,
            this.toolStripMenuItem3,
            this.关闭或注销ToolStripMenuItem,
            this.取消系统关机计划CToolStripMenuItem,
            this.toolStripMenuItem4,
            this.退出XToolStripMenuItem,
            this.关闭此菜单QToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(266, 248);
            // 
            // 显示主窗口SToolStripMenuItem
            // 
            this.显示主窗口SToolStripMenuItem.Enabled = false;
            this.显示主窗口SToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources.favicon;
            this.显示主窗口SToolStripMenuItem.Name = "显示主窗口SToolStripMenuItem";
            this.显示主窗口SToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.显示主窗口SToolStripMenuItem.Text = "打开/关闭 设置窗口(&S)";
            this.显示主窗口SToolStripMenuItem.Click += new System.EventHandler(this.显示主窗口SToolStripMenuItem_Click);
            // 
            // 仅启动系统监视器VToolStripMenuItem
            // 
            this.仅启动系统监视器VToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources._250;
            this.仅启动系统监视器VToolStripMenuItem.Name = "仅启动系统监视器VToolStripMenuItem";
            this.仅启动系统监视器VToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.仅启动系统监视器VToolStripMenuItem.Text = "打开/关闭 系统监视器(&V)";
            this.仅启动系统监视器VToolStripMenuItem.Click += new System.EventHandler(this.仅启动系统监视器VToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(262, 6);
            // 
            // 暂停PToolStripMenuItem
            // 
            this.暂停PToolStripMenuItem.Name = "暂停PToolStripMenuItem";
            this.暂停PToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.暂停PToolStripMenuItem.Text = "暂停(&P)";
            this.暂停PToolStripMenuItem.Click += new System.EventHandler(this.暂停PToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(262, 6);
            // 
            // windows任务管理器ToolStripMenuItem
            // 
            this.windows任务管理器ToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources._301;
            this.windows任务管理器ToolStripMenuItem.Name = "windows任务管理器ToolStripMenuItem";
            this.windows任务管理器ToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.windows任务管理器ToolStripMenuItem.Text = "Windows任务管理器(&T)";
            this.windows任务管理器ToolStripMenuItem.Click += new System.EventHandler(this.windows任务管理器ToolStripMenuItem_Click);
            // 
            // 取消系统关机计划CToolStripMenuItem
            // 
            this.取消系统关机计划CToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources._207;
            this.取消系统关机计划CToolStripMenuItem.Name = "取消系统关机计划CToolStripMenuItem";
            this.取消系统关机计划CToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.取消系统关机计划CToolStripMenuItem.Text = "取消系统的关机计划(&C)";
            this.取消系统关机计划CToolStripMenuItem.Click += new System.EventHandler(this.取消系统关机计划CToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(262, 6);
            // 
            // 修复Windows性能计数器注册表RToolStripMenuItem
            // 
            this.修复Windows性能计数器注册表RToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources._110;
            this.修复Windows性能计数器注册表RToolStripMenuItem.Name = "修复Windows性能计数器注册表RToolStripMenuItem";
            this.修复Windows性能计数器注册表RToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.修复Windows性能计数器注册表RToolStripMenuItem.Text = "修复Windows性能计数器注册表(&R)";
            this.修复Windows性能计数器注册表RToolStripMenuItem.Click += new System.EventHandler(this.修复Windows性能计数器注册表RToolStripMenuItem_Click);
            // 
            // 退出XToolStripMenuItem
            // 
            this.退出XToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources._264;
            this.退出XToolStripMenuItem.Name = "退出XToolStripMenuItem";
            this.退出XToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.退出XToolStripMenuItem.Text = "完全退出(&X)";
            this.退出XToolStripMenuItem.Click += new System.EventHandler(this.退出XToolStripMenuItem_Click);
            // 
            // 主计时器
            // 
            this.主计时器.Enabled = true;
            this.主计时器.Interval = 1000;
            this.主计时器.Tick += new System.EventHandler(this.主计时器_Tick);
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
            this.关闭或注销ToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources._97;
            this.关闭或注销ToolStripMenuItem.Name = "关闭或注销ToolStripMenuItem";
            this.关闭或注销ToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.关闭或注销ToolStripMenuItem.Text = "关闭或注销(&U)";
            // 
            // 自动关机ToolStripMenuItem
            // 
            this.自动关机ToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources._223;
            this.自动关机ToolStripMenuItem.Name = "自动关机ToolStripMenuItem";
            this.自动关机ToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.自动关机ToolStripMenuItem.Text = "关机(&U)";
            this.自动关机ToolStripMenuItem.Click += new System.EventHandler(this.自动关机ToolStripMenuItem_Click);
            // 
            // 自动重启ToolStripMenuItem
            // 
            this.自动重启ToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources._243;
            this.自动重启ToolStripMenuItem.Name = "自动重启ToolStripMenuItem";
            this.自动重启ToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.自动重启ToolStripMenuItem.Text = "重启(&R)";
            this.自动重启ToolStripMenuItem.Click += new System.EventHandler(this.自动重启ToolStripMenuItem_Click);
            // 
            // 自动休眠ToolStripMenuItem
            // 
            this.自动休眠ToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources._97;
            this.自动休眠ToolStripMenuItem.Name = "自动休眠ToolStripMenuItem";
            this.自动休眠ToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.自动休眠ToolStripMenuItem.Text = "休眠(&S)";
            this.自动休眠ToolStripMenuItem.Click += new System.EventHandler(this.自动休眠ToolStripMenuItem_Click);
            // 
            // 自动注销ToolStripMenuItem
            // 
            this.自动注销ToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources._78;
            this.自动注销ToolStripMenuItem.Name = "自动注销ToolStripMenuItem";
            this.自动注销ToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.自动注销ToolStripMenuItem.Text = "注销(&I)";
            this.自动注销ToolStripMenuItem.Click += new System.EventHandler(this.自动注销ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(245, 6);
            // 
            // 自动关机并准备快速启动ToolStripMenuItem
            // 
            this.自动关机并准备快速启动ToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources._223;
            this.自动关机并准备快速启动ToolStripMenuItem.Name = "自动关机并准备快速启动ToolStripMenuItem";
            this.自动关机并准备快速启动ToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.自动关机并准备快速启动ToolStripMenuItem.Text = "自动关机并准备快速启动(&Q)";
            this.自动关机并准备快速启动ToolStripMenuItem.Click += new System.EventHandler(this.自动关机并准备快速启动ToolStripMenuItem_Click);
            // 
            // 自动重启并打开之前的程序ToolStripMenuItem
            // 
            this.自动重启并打开之前的程序ToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources._243;
            this.自动重启并打开之前的程序ToolStripMenuItem.Name = "自动重启并打开之前的程序ToolStripMenuItem";
            this.自动重启并打开之前的程序ToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.自动重启并打开之前的程序ToolStripMenuItem.Text = "自动重启并打开之前的程序(&E)";
            this.自动重启并打开之前的程序ToolStripMenuItem.Click += new System.EventHandler(this.自动重启并打开之前的程序ToolStripMenuItem_Click);
            // 
            // 自动重启并打开高级启动菜单ToolStripMenuItem
            // 
            this.自动重启并打开高级启动菜单ToolStripMenuItem.Image = global::YashiAutoShutOff.Properties.Resources._110;
            this.自动重启并打开高级启动菜单ToolStripMenuItem.Name = "自动重启并打开高级启动菜单ToolStripMenuItem";
            this.自动重启并打开高级启动菜单ToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.自动重启并打开高级启动菜单ToolStripMenuItem.Text = "自动重启并打开高级启动菜单(&A)";
            this.自动重启并打开高级启动菜单ToolStripMenuItem.Click += new System.EventHandler(this.自动重启并打开高级启动菜单ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(262, 6);
            // 
            // 关闭此菜单QToolStripMenuItem
            // 
            this.关闭此菜单QToolStripMenuItem.Name = "关闭此菜单QToolStripMenuItem";
            this.关闭此菜单QToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.关闭此菜单QToolStripMenuItem.Text = "关闭此菜单(&Q)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 273);
            this.ControlBox = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "正在启动 雅诗智能关机";
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
    }
}

