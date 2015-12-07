using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YashiAutoShutOff
{
    static class SettingLoad
    {
        public static string 任务启动时间 = "";

        public static int 开关引导 = 0; //0已关闭，1已开启，10尝试关闭，10尝试开启
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
    }
}
