using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace YashiAutoShutOff
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        public static int initID = new Random().Next(0, int.MaxValue);
        [STAThread]
        
        static void Main(string[] args)
        {
            Console.WriteLine("Main init: " + initID);
            SettingLoad.运行参数 = args;
            SettingLoad.debug = false;
#if DEBUG
            SettingLoad.debug = true;
#endif
            if (SettingLoad.arg("debug"))
            {
                SettingLoad.debug = true;
            }
            else if (SettingLoad.arg("release"))
            {
                SettingLoad.debug = false;
            }
            if (SettingLoad.arg("shutdownnow"))
            {
                ShutdownNow 关机 = new ShutdownNow();
                SettingLoad.强制关机 = true;
                关机.立即执行类型 = 8;
                关机.开始关机();
                Application.Exit();
            }
            else if (SettingLoad.arg("restartnow"))
            {
                ShutdownNow 关机 = new ShutdownNow();
                SettingLoad.强制关机 = true;
                关机.立即执行类型 = 9;
                关机.开始关机();
                Application.Exit();
            }
            else if (SettingLoad.arg("poweroffnow"))
            {
                ShutdownNow 关机 = new ShutdownNow();
                SettingLoad.强制关机 = true;
                关机.立即执行类型 = 13;
                关机.开始关机();
                Application.Exit();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            bool createNew;

            using (System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out createNew))
            {
                
                if (createNew)
                {
                    startapp();
                }
                else
                {
                    if (SettingLoad.arg("onlyon"))
                    {
                        System.Environment.Exit(1);
                    }
                    else if (SettingLoad.arg("onlyoff"))
                    {
                        startapp();
                    }
                    else
                    {
                        if (MessageBox.Show("本软件已经在运行了，要再重复启动一个吗？\n不建议您同时运行多个实例，建议选否并检查任务栏中已经运行的本软件。", "重复运行通知", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            startapp();
                        }
                        else
                        {
                            //System.Threading.Thread.Sleep(1000);
                            System.Environment.Exit(1);
                        }
                    }
                }
            }
        }
        static void startapp()
        {
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
            {
                SettingLoad.以管理员方式运行 = true;
                Application.Run(new Form1());
            }
            else
            {
                //if (MessageBox.Show("建议您使用管理员方式运行本程序，但这不是必须的。\n拥有管理员权限可以提升关机的成功率。\n要请求管理员权限吗？", "非管理员权限通知", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                if (SettingLoad.arg("administrator") || SettingLoad.arg("admin"))
                {
                    //创建启动对象
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.UseShellExecute = true;
                    startInfo.WorkingDirectory = Environment.CurrentDirectory;
                    startInfo.FileName = Application.ExecutablePath;
                    //设置启动动作,确保以管理员身份运行
                    startInfo.Verb = "runas";
                    try
                    {
                        System.Diagnostics.Process.Start(startInfo);
                    }
                    catch
                    {
                        Application.Run(new Form1());
                    }
                    //退出
                    Application.Exit();
                }
                else
                {
                    Application.Run(new Form1());
                }
            }
        }
    }
}
