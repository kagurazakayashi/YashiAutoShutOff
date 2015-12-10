using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace YashiAutoShutOff
{
    class Calc
    {
        SystemInfo 系统信息管理类;

        public Calc(SystemInfo 系统信息类)
        {
            系统信息管理类 = 系统信息类;
        }

        public int 计数器加减判断() //1=+1,0=0.-1=E
        {
            try
            {
                return 计算();
            }
            catch
            {
                return -1;
            }
        }

        private int 计算()
        {
            float 实际数值 = 0;
            float 条件数值 = 0;
            if (SettingLoad.类型 == 0) //00.时间（格式：4位年-月-日-时-分-秒）
            {
                double 秒数差 = 计算秒数差();
                if (秒数差 < 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else if (SettingLoad.类型 == 1 || SettingLoad.类型 == 2) //01.CPU已利用百分比,02.CPU可用百分比
            {
                int 选择的核心 = SettingLoad.CPU核心;
                实际数值 = SettingLoad.处理器总使用量;
                if (选择的核心 != 0)
                {
                    实际数值 = SettingLoad.处理器分核使用量[选择的核心 - 1];
                }
                if (SettingLoad.类型 == 2)
                {
                    实际数值 = 100 - 实际数值;
                }
            }
            else if (SettingLoad.类型 == 12 || SettingLoad.类型 == 13) //监控程序结束/启动
            {
                Process[] proc = Process.GetProcessesByName(SettingLoad.条件);
                if (proc.Length == 0)
                {
                    if (SettingLoad.类型 == 13)
                    {
                        return 1;
                    }
                    return 0;
                }
                else
                {
                    if (SettingLoad.类型 == 13)
                    {
                        return 0;
                    }
                    return 1;
                }
            }
            else
            {
                switch (SettingLoad.类型)
                {
                    case 3://内存已使用百分比
                        实际数值 = SettingLoad.已用内存百分比; break;
                    case 4://内存已使用多少MB
                        实际数值 = SettingLoad.内存信息数组[2] / 1024; break;
                    case 5://可用内存有多少MB
                        实际数值 = SettingLoad.内存信息数组[1] / 1024; break;
                    case 6://硬盘每秒读写次数
                        实际数值 = SettingLoad.硬盘IO信息数组[0]; break;
                    case 7://硬盘每秒写入次数
                        实际数值 = SettingLoad.硬盘I信息数组[0]; break;
                    case 8://硬盘每秒读取次数
                        实际数值 = SettingLoad.硬盘O信息数组[0]; break;
                    case 9://网络每秒收发多少KB
                        实际数值 = SettingLoad.网络IO信息数组[0] / 1024; break;
                    case 10://网络每秒收取多少KB
                        实际数值 = SettingLoad.网络I信息数组[0] / 1024; break;
                    case 11://网络每秒发送多少KB
                        实际数值 = SettingLoad.网络O信息数组[0] / 1024; break;
                    default:
                        break;
                }
            }
            条件数值 = float.Parse(SettingLoad.条件);
            if ((SettingLoad.比较 == 0 && 实际数值 == 条件数值) || (SettingLoad.比较 == 1 && 实际数值 > 条件数值) || (SettingLoad.比较 == 2 && 实际数值 < 条件数值) || (SettingLoad.比较 == 3 && 实际数值 > 条件数值) || (SettingLoad.比较 == 4 && 实际数值 < 条件数值) || (SettingLoad.比较 == 5 && 实际数值 != 条件数值))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public double 计算秒数差()
        {
            string[] 日期字符字符串 = SettingLoad.条件.Split('-');
            int[] 输入的日期数字 = new int[6];
            for (int i = 0; i < 6; i++)
            {
                输入的日期数字[i] = int.Parse(日期字符字符串[i]);
            }
            DateTime 输入的日期 = new DateTime(输入的日期数字[0], 输入的日期数字[1], 输入的日期数字[2], 输入的日期数字[3], 输入的日期数字[4], 输入的日期数字[5]);
            DateTime 当前的日期 = DateTime.Now;
            if (DateTime.Compare(输入的日期, 当前的日期) <= 0)
            {
                return 1;
            }
            TimeSpan 秒数差对象 = 输入的日期 - 当前的日期;
            return 秒数差对象.TotalSeconds;
        }

    }
}
