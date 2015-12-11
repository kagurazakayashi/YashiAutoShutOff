namespace YashiAutoShutOff
{
    partial class Shutdown
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shutdown));
            this.取消按钮 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.立即执行按钮 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // 取消按钮
            // 
            this.取消按钮.Cursor = System.Windows.Forms.Cursors.Hand;
            this.取消按钮.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.取消按钮.Location = new System.Drawing.Point(399, 103);
            this.取消按钮.Name = "取消按钮";
            this.取消按钮.Size = new System.Drawing.Size(207, 38);
            this.取消按钮.TabIndex = 0;
            this.取消按钮.Text = "取消(&C)";
            this.取消按钮.UseVisualStyleBackColor = true;
            this.取消按钮.Click += new System.EventHandler(this.取消按钮_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::YashiAutoShutOff.Properties.Resources._74;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // 立即执行按钮
            // 
            this.立即执行按钮.Cursor = System.Windows.Forms.Cursors.Hand;
            this.立即执行按钮.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.立即执行按钮.Location = new System.Drawing.Point(186, 103);
            this.立即执行按钮.Name = "立即执行按钮";
            this.立即执行按钮.Size = new System.Drawing.Size(207, 38);
            this.立即执行按钮.TabIndex = 2;
            this.立即执行按钮.Text = "立即执行(&N)";
            this.立即执行按钮.UseVisualStyleBackColor = true;
            this.立即执行按钮.Click += new System.EventHandler(this.立即执行按钮_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(146, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "注意，系统将在<time>后<type>。";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(150, 46);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(456, 40);
            this.progressBar1.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Shutdown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 153);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.立即执行按钮);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.取消按钮);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Shutdown";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "雅诗智能关机 - 即将关机";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Shutdown_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button 取消按钮;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button 立即执行按钮;
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ProgressBar progressBar1;
    }
}