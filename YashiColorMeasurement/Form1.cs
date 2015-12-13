using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YashiColorMeasurement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Size.Width - 100, Screen.PrimaryScreen.Bounds.Height - this.Size.Height - 100); //设置初始窗口位置  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox4.BackColor = pictureBox5.BackColor;
            pictureBox3.Visible = !pictureBox3.Visible;
            timer1.Enabled = !pictureBox3.Visible;
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            textBox1.SelectAll();
            Clipboard.SetDataObject(textBox1.Text);
            pictureBox6.Visible = true;
            timer2.Enabled = true;
        }

        private void textBox2_DoubleClick(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            textBox2.SelectAll();
            Clipboard.SetDataObject(textBox2.Text);
            pictureBox6.Visible = true;
            timer2.Enabled = true;
        }

        private void textBox3_DoubleClick(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            textBox3.SelectAll();
            Clipboard.SetDataObject(textBox3.Text);
            pictureBox6.Visible = true;
            timer2.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int[] c = Screenshot.mousePixelColorXYRGBA();
            textBox1.Text = c[0] + " , " + c[1];
            textBox2.Text = c[2] + " , " + c[3] + " , " + c[4];
            textBox3.Text = c[0] + "-" + c[1] + "-" + c[2] + "-" + c[3] + "-" + c[4];
            pictureBox5.BackColor = Color.FromArgb(c[2], c[3], c[4]);
            textBox4.Text = ColorTranslator.ToHtml(pictureBox5.BackColor);
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            pictureBox6.Visible = false;
            timer2.Enabled = false;
        }

        private void textBox4_DoubleClick(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            textBox4.SelectAll();
            Clipboard.SetDataObject(textBox4.Text);
            pictureBox6.Visible = true;
            timer2.Enabled = true;
        }
    }
}
