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
        public int initID = new Random().Next(0, int.MaxValue);

        public startscreen()
        {
            InitializeComponent();
        }

        private void startscreen_Load(object sender, EventArgs e)
        {
            Console.WriteLine("startscreen init: " + initID);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Opacity = 0;
        }
    }
}
