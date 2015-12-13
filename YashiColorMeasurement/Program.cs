using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YashiColorMeasurement
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            bool createNew;
            using (System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out createNew))
            {

                if (createNew)
                {
                    Application.Run(new Form1());
                }
                else
                {
                    if (MessageBox.Show("本软件已经在运行了，要再重复启动一个吗？\n不建议您同时运行多个实例，建议选否并检查任务栏中已经运行的本软件。", "重复运行通知", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Application.Run(new Form1());
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(1000);
                        System.Environment.Exit(1);
                    }
                }
            }
        }
    }
}
