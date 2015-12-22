using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YashiAutoShutOff
{
    static class SettingLoad
    {
        /* 启动参数
--nologo
不显示启动画面。
--nowindow
启动时不显示主窗口，只显示任务栏小图标。
--animationoff
禁用主开关的动画效果。
--autohide
关闭主窗体到任务栏图标，而不是退出软件。
--minimizewindow
最小化到任务栏程序列，而不是右侧小图标。
--viewon
强制显示系统信息监控，即使是在调试模式下（仅在开发时用）。
--viewoff
强制不显示系统信息监控。手工也无法打开。
--quickexit
退出软件时不询问是否退出，而是直接退出。
--crash
计时器发生错误时直接闪退，而不是显示可继续的错误对话框。
--reset
启动时抹掉所有配置文件和日志文件并重新初始化，突然出现不明错误可尝试。
--onlyon
禁止本程序运行多个实例，而不是询问。
--onlyoff
允许本程序运行多个实例，而不是询问。
--administrator / --admin
启动时尝试请求管理员权限。
--ver
启动时显示关于对话框。
--stop
不启动检测主循环，软件核心功能将禁用（仅在开发时用）。
--pause
启动后处于暂停模式。
--opacity
启动主窗口透明度效果。
--nolog
关机时不记录日志。
--shutdowninfo
关机时弹框显示关机命令的返回值。
--shutdownnow
立即关机，在某些系统故障情况下可以帮助让系统正常关机。
--restartnow
立即重启，在某些系统故障情况下可以帮助让系统正常重启。
--debug
强制在调试模式运行，关机命令不会被真正执行（仅在开发时用）。
--release
强制在非调试模式运行。
--exit
运行后即退出，仅用于测试是否能正确初始化。
--showshutdowncmd
调用命令时显示命令行窗口。
        */
        public static int initID = new Random().Next(0, int.MaxValue);
        public static string 资料文件夹 = "";
        public static string[] 运行参数;
        public static bool 以管理员方式运行 = false;
        public static bool debug = false;

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

        public static int 当前已满足秒 = 0;
        public static int 当前已满足百分之 = 0;

        public static float 处理器总使用量 = 0;
        public static float[] 处理器分核使用量 = new float[1002];
        public static int CPU核心数量 = 0;
        public static float 已用内存百分比 = 0;
        public static long[] 内存信息数组 = new long[3];
        public static float[] 硬盘I信息数组 = new float[3];
        public static float[] 硬盘O信息数组 = new float[3];
        public static float[] 硬盘IO信息数组 = new float[3]; 
        public static float[] 网络I信息数组 = new float[3];
        public static float[] 网络O信息数组 = new float[3];
        public static float[] 网络IO信息数组 = new float[3];

        //总计，剩余，已用 //当前，峰值，比例

        public static bool 最终关机命令 = false;

        public static string[] 类型列表文本数组 = new string[14];
        public static string[] 类型列表介绍数组 = new string[14];
        public static string[] 比较方法文本数组 = new string[6];
        public static string[] 关机原因文本数组 = new string[31];
        public static string[] 关机模式文本数组 = new string[14];

        static SettingLoad()
        {
            Console.WriteLine("SettingLoad init: " + initID);
            int j = 0;
            for (int i = 0; i < 类型列表文本数组.Length; i++)
            {
                类型列表文本数组[i] = Language.s(j);
                j++;
            }
            for (int i = 0; i < 类型列表介绍数组.Length; i++)
            {
                类型列表介绍数组[i] = Language.s(j);
                j++;
            }
            for (int i = 0; i < 比较方法文本数组.Length; i++)
            {
                比较方法文本数组[i] = Language.s(j);
                j++;
            }
            for (int i = 0; i < 关机原因文本数组.Length; i++)
            {
                关机原因文本数组[i] = Language.s(j);
                j++;
            }
            for (int i = 0; i < 关机模式文本数组.Length; i++)
            {
                关机模式文本数组[i] = Language.s(j);
                j++;
            }

        }
        public static void reset()
        {
            任务启动时间 = "";
            条件满足秒数 = 0;
            //关机模式 = 0;
            //类型 = 0;
            比较 = 0;
            CPU核心 = 0;
            条件 = "";
            条件多少秒开始 = 0;
            //执行后提示关机时长 = 0;
            强制关机 = false;
            //截图保存 = false;
            //截图保存路径 = "";
            //关闭事件跟踪程序开关 = false;
            //关闭事件跟踪程序设置 = 0;
            当前已满足秒 = 0;
            当前已满足百分之 = 0;
            处理器总使用量 = 0;
            处理器分核使用量 = new float[1002];
            CPU核心数量 = 0;
            已用内存百分比 = 0;
            内存信息数组 = new long[3];
            硬盘I信息数组 = new float[3];
            硬盘O信息数组 = new float[3];
            硬盘IO信息数组 = new float[3];
            网络I信息数组 = new float[3];
            网络O信息数组 = new float[3];
            网络IO信息数组 = new float[3];
        }
        public static bool arg(string a)
        {
            if (运行参数.Length > 0)
            {
                for (int i = 0; i < 运行参数.Length; i++)
                {
                    if (运行参数[i].Equals("-" + a) || 运行参数[i].Equals("--" + a) || 运行参数[i].Equals("/" + a))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
