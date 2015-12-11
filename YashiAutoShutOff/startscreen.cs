using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YashiAutoShutOff
{
    public partial class startscreen : Form
    {
        private int t = 0;
        public int initID = new Random().Next(0, int.MaxValue);

        public startscreen()
        {
            InitializeComponent();
        }

        private void startscreen_Load(object sender, EventArgs e)
        {
            Console.WriteLine("startscreen init: " + initID);
#if DEBUG
            button1.Visible = true;
#endif
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            t++;
            if (t == 5)
            {
                info.Text = "似乎还需要一段时间";
            }
            else if (t == 10)
            {
                info.Text = "似乎所花时间比预期更久";
            }
            else if (t == 15)
            {
                info.Text = "超时，可能发生了错误";
            }
            else if (t == 18)
            {
                //Opacity = 0;
                timer1.Enabled = false;
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Close();
        }
    }
}
