using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YashiAutoShutOff
{
    static class SettingLoad
    {
        public static int initID = new Random().Next(0, int.MaxValue);
        public static bool 以管理员方式运行 = false;

        public static string 任务启动时间 = "";
        public static int 条件满足秒数 = 0;
        public static int 关机模式 = 0;
        public static int 类型 = 0;
        public static int 比较 = 0;
        public static int CPU核心 = 0;
        public static string 条件 = "";
        public static int 条件多少秒开始 = 0;
        public static int 执行后提示关机时长 = 0;
        public static bool 强制关机 = false;
        public static bool 截图保存 = false;
        public static string 截图保存路径 = "";
        public static bool 关闭事件跟踪程序开关 = false;
        public static int 关闭事件跟踪程序设置 = 0;

        public static string[] 类型列表文本数组 = new string[12] { "00.时间（格式：4位年-月-日-时-分-秒）", "01.CPU已利用百分比", "02.CPU可用百分比", "03.内存已使用百分比", "04.内存已使用多少MB", "05.可用内存有多少MB", "06.硬盘每秒读写次数", "07.硬盘每秒写入次数", "08.硬盘每秒读取次数", "09.网络每秒收发多少KB", "10.网络每秒收取多少KB", "11.网络每秒发送多少KB" };
        public static string[] 比较方法文本数组 = new string[5] { "0.等于", "1.大于", "2.小于", "3.大于等于", "4.小于等于" };
        public static string[] 关机原因文本数组 = new string[31] { "00.其他(计划外)", "01.其他(计划外)", "02.其他(计划内)", "03.其他故障：系统没有反应", "04.硬件：维护(计划外)", "05.硬件：维护(计划内)", "06.硬件：安装(计划外)", "07.硬件：安装(计划内)", "08.操作系统：恢复(计划外)", "09.操作系统：恢复(计划内)", "10.操作系统：升级(计划内)", "11.操作系统：重新配置(计划外)", "12.操作系统：重新配置(计划内)", "13.操作系统：Service.Pack.(计划内)", "14.操作系统：热修补(计划外)", "15.操作系统：热修补(计划内)", "16.操作系统：安全修补(计划外)", "17.操作系统：安全修补(计划内)", "18.应用程序：维护(计划外)", "19.应用程序：维护(计划内)", "20.应用程序：安装(计划内)", "21.应用程序：没有反应", "22.应用程序：不稳定", "23.系统故障：停止错误", "24.安全问题(计划外)", "25.安全问题(计划外)", "26.安全问题(计划内)", "27.网络连接丢失(计划外)", "28.电源故障：电线被拔掉", "29.电源故障：环境", "30.旧版API关机" };
        public static string[] 关机模式文本数组 = new string[7] { "自动提醒", "自动关机", "自动重启", "自动休眠", "自动注销", "自动关机并准备快速启动", "自动重启并打开之前的程序" };

        static SettingLoad()
        {
            Console.WriteLine("SettingLoad init: " + initID);
        }

        public static void reset()
        {
            任务启动时间 = "";
            条件满足秒数 = 0;
            关机模式 = 0;
            类型 = 0;
            比较 = 0;
            CPU核心 = 0;
            条件 = "";
            条件多少秒开始 = 0;
            执行后提示关机时长 = 0;
            强制关机 = false;
            截图保存 = false;
            截图保存路径 = "";
            关闭事件跟踪程序开关 = false;
            关闭事件跟踪程序设置 = 0;
        }

    }
}
