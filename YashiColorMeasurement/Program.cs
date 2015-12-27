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
                Language.initLanguage(null);
                if (createNew)
                {
                    Application.Run(new Form1());
                }
                else
                {
                    if (MessageBox.Show(Language.s(8), Language.s(9), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
