using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace YashiAutoShutOff
{
    public partial class logshow : Form
    {
        String 默认日志文件 = Directory.GetCurrentDirectory() + "\\shutdown.log";

        public logshow()
        {
            InitializeComponent();
        }

        private void logshow_Load(object sender, EventArgs e)
        {
            
            listBox1.Items.Clear();
            try
            {
                StreamReader sr = new StreamReader(默认日志文件, Encoding.Default);
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    listBox1.Items.Add(s);
                }
                progressBar1.Value = progressBar1.Maximum;
                button2.Enabled = true;
                sr.Close();
            }
            catch
            {
                listBox1.Items.Add("没有日志。");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            listBox1.Items.Clear();
            listBox1.Items.Add("没有日志。");
            try
            {
                File.Delete(默认日志文件);
            }
            catch
            {
                
            }
            progressBar1.Value = progressBar1.Minimum;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
