using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace YashiAutoShutOff
{
    class ShutdownNow
    {
        public int 立即执行类型 = 0;

        public void 开始关机()
        {
            //{ "0自动提醒", "1自动关机", "2自动重启", "3自动休眠", "4自动注销", "5自动关机并准备快速启动", "6自动重启并打开之前的程序" };
            int type = SettingLoad.关机模式;
            if (立即执行类型 > 0)
            {
                type = 立即执行类型;
            }
            if (type == 0)
            {
                MessageBox.Show("条件成立！","通知",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else if (type < 8)
            {
                执行关机命令(true, type);
            }
            else
            {
                执行关机命令(false, type);
            }
        }

        private void 执行关机命令(bool isModeA, int type)
        {
            startscreen st = new startscreen();
            st.info.Text = "正在关机";
            st.Show();
            
            SettingLoad.最终关机命令 = true;
            string output = "";
            try
            {
                if (isModeA)
                {
                    Process cmd = new System.Diagnostics.Process();
                    cmd.StartInfo.FileName = "shutdown";
                    cmd.StartInfo.Arguments = 关机方式参数(type);
                    cmd.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
                    cmd.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
                    cmd.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
                    cmd.StartInfo.RedirectStandardError = true;//重定向标准错误输出
                    cmd.StartInfo.CreateNoWindow = true;//不显示程序窗口
                    if (SettingLoad.arg("showshutdowncmd"))
                    {
                        cmd.StartInfo.CreateNoWindow = false;
                    }
                    if (SettingLoad.debug)
                    {
                        SettingLoad.最终关机命令 = false;
                        MessageBox.Show(cmd.StartInfo.FileName + " " + cmd.StartInfo.Arguments, "DEBUG: ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        cmd.Start();
                        output = cmd.StandardOutput.ReadToEnd();
                        cmd.WaitForExit();
                        cmd.Close();
                    }
                }
                else
                {
                    if (SettingLoad.debug)
                    {
                        SettingLoad.最终关机命令 = false;
                        MessageBox.Show("Mode B : " + SettingLoad.关机模式文本数组[type], "DEBUG: ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        switch (type)
                        {
                            case 8:
                                WindowsController.ExitWindows(RestartOptions.ShutDown, SettingLoad.强制关机);
                                break;
                            case 9:
                                WindowsController.ExitWindows(RestartOptions.Reboot, SettingLoad.强制关机);
                                break;
                            case 10:
                                WindowsController.ExitWindows(RestartOptions.Hibernate, SettingLoad.强制关机);
                                break;
                            case 11:
                                WindowsController.ExitWindows(RestartOptions.Suspend, SettingLoad.强制关机);
                                break;
                            case 12:
                                WindowsController.ExitWindows(RestartOptions.LogOff, SettingLoad.强制关机);
                                break;
                            case 13:
                                WindowsController.ExitWindows(RestartOptions.PowerOff, SettingLoad.强制关机);
                                break;
                            default:
                                break;
                        }
                    }
                }
                if (!SettingLoad.arg("nolog"))
                {
                    try
                    {
                        
                        String 默认日志文件 = SettingLoad.资料文件夹 + "shutdown.log";
                        using (StreamWriter sw = File.AppendText(默认日志文件))
                        {
                            sw.WriteLine(DateTime.Now);
                            if (isModeA)
                            {
                                sw.WriteLine("Mode A : " + SettingLoad.关机模式文本数组[type] + " : " + output);
                            }
                            else
                            {
                                sw.WriteLine("Mode B : " + SettingLoad.关机模式文本数组[type]);
                            }
                            sw.WriteLine("-");
                            sw.Close();
                        }
                    }
                    catch
                    {

                    }
                }
                if (SettingLoad.arg("shutdowninfo") && isModeA)
                {
                    MessageBox.Show(output, "关机", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //Application.Exit();
            }
            catch (Exception err)
            {
                SettingLoad.最终关机命令 = false;
                MessageBox.Show(err.Message.ToString(), "关机发生错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string 关机方式参数(int type)
        {
            string 关机参数 = "";
            switch (type)
            {
                case 1:
                    关机参数 = "/s /t 0"; break; //1自动关机
                case 2:
                    关机参数 = "/r /t 0"; break; //2自动重启
                case 3:
                    关机参数 = "/h /t 0"; break; //3自动休眠
                case 4:
                    关机参数 = "/l"; break; //4自动注销
                case 5:
                    关机参数 = "/hybrid /t 0"; break; //5自动关机并准备快速启动
                case 6:
                    关机参数 = "/g /t 0"; break; //6自动重启并打开之前的程序
                case 7:
                    关机参数 = "/r /o /t 0"; break;
                default:
                    SettingLoad.最终关机命令 = false;
                    MessageBox.Show("无效指令", "关机发生错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            if (SettingLoad.强制关机)
            {
                关机参数 = 关机参数 + " /f";
            }
            if (SettingLoad.关闭事件跟踪程序开关)
            {
                string[] 关机原因参数数组 = new string[31] { "U:0:0", "0:0", "P:0:0", "U:0:5", "1:1", "P:1:1", "1:2", "P:1:2", "2:2", "P:2:2", "P:2:3", "2:4", "P:2:4", "P:2:16", "2:17", "P:2:17", "2:18", "P:2:18", "4:1", "P:4:1", "P:4:2", "4:5", "4:6", "U:5:15", "U:5:19", "5:19", "P:5:19", "5:20", "U:6:11", "U:6:12", "P:7:0" };
                关机参数 = 关机参数 + " /d " + 关机原因参数数组[SettingLoad.关闭事件跟踪程序设置];
            }
            return 关机参数;
        }

    }
}
