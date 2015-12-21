//程序作者：h46incon。
//神楽坂雅詩加入了少量修改。
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SleepPreventer
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
            //new MyNotifyIcon();
            //Application.Run();
            LidCloseAwakeKeeper.CheckLogError();
            bool createNew;

            using (System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out createNew))
            {

                if (createNew)
                {
                    Application.Run(new Form1());
                }
                else
                {
                    MessageBox.Show("程序已在运行");
                    Application.Exit();
                }
            }
        }
    }
}
