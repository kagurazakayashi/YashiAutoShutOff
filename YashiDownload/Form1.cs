using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace YashiDownload
{
    public partial class Form1 : Form
    {

        private string d1 = "";
        private string d2 = "https://github.com/cxchope/YashiAutoShutOff/archive/master.zip";
        int tt = 0;
        char[] pas = new char[4] { '-', '\\', '|', '/' };
        int pa = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (d1.Length == 0)
            {
                checkBox1.Enabled = false;
                checkBox1.Checked = false;
                checkBox2.Checked = true;
            }
            if (d2.Length == 0)
            {
                checkBox2.Checked = false;
                checkBox2.Enabled = false;
            }
            string temp = System.Environment.GetEnvironmentVariable("TEMP");
            DirectoryInfo info = new DirectoryInfo(temp);
            textBox1.Text = info.FullName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox2.Checked)
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                textBox1.Enabled = false;
                button1.Enabled = false;
                label2.Enabled = false;
                label3.Visible = true;
                label4.Visible = true;
                button2.Text = "正在下载\nDownloading";
                button2.Enabled = false;
                if (textBox1.Text.Substring(textBox1.Text.Length - 1).Equals("\\"))
                {
                    textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                }
                //startdownload();
            }
        }

        void startdownload()
        {
            if (checkBox1.Checked)
            {
                tt++;
                System.Net.WebClient wc = new System.Net.WebClient();
                wc.DownloadFileAsync(new Uri(d1), textBox1.Text + "\\setup.zip");
                wc.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(wc_DownloadProgressChanged1);
                wc.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileCompleted);
            }
            else
            {
                label3.Visible = false;
                progressBar1.Value = progressBar1.Maximum;
            }
            if (checkBox2.Checked)
            {
                tt++;
                System.Net.WebClient wc = new System.Net.WebClient();
                wc.DownloadFileAsync(new Uri(d2), textBox1.Text + "\\source.zip");
                wc.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(wc_DownloadProgressChanged2);
                wc.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileCompleted);
            }
            else
            {
                label4.Visible = false;
                progressBar2.Value = progressBar2.Maximum;
            }
        }

        void wc_DownloadProgressChanged1(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label3.Text = e.BytesReceived.ToString();
            pap();
        }
        void wc_DownloadProgressChanged2(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            progressBar2.Value = e.ProgressPercentage;
            label4.Text = e.BytesReceived.ToString();
            pap();
        }
        void pap()
        {
            if (pa >= 4)
            {
                pa = 0;
            }
            label5.Text = pas[pa++].ToString();
        }

        void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            tt--;
            if (tt == 0)
            {
                MessageBox.Show("Download OK");
                System.Diagnostics.Process.Start("Explorer.exe", textBox1.Text);
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = textBox1.Text;
            folderBrowserDialog1.ShowNewFolderButton = true;
            folderBrowserDialog1.Description = "Save To";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
