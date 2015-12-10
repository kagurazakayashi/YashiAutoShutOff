using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Text;
using System.Management;
using System.Runtime.InteropServices;

namespace YashiAutoShutOff
{
    public class SystemInfo
    {
        public List<String> 处理器名称数组 = new List<String>();
        public List<PerformanceCounter> 处理器性能计数器数组 = new List<PerformanceCounter>();
        public List<String> 硬盘名称数组 = new List<String>();
        public List<PerformanceCounter> 硬盘性能计数器数组 = new List<PerformanceCounter>();
        public String[] 处理器内核数数组 = new String[3]; //处理器名，内核数，逻辑处理器数
        public List<PerformanceCounter> 网络性能计数器数组 = new List<PerformanceCounter>();
        ManagementClass 系统管理类 = new ManagementClass("Win32_OperatingSystem");
        public long[] 内存信息数组 = new long[3]; //总计，剩余，已用
        public float[] 硬盘I信息数组 = new float[3]; //当前，峰值，比例
        public float[] 硬盘O信息数组 = new float[3]; //当前，峰值，比例
        public float[] 硬盘IO信息数组 = new float[3]; //当前，峰值，比例
        public float[] 网络I信息数组 = new float[3]; //当前，峰值，比例
        public float[] 网络O信息数组 = new float[3]; //当前，峰值，比例
        public float[] 网络IO信息数组 = new float[3]; //当前，峰值，比例

        public float 已用内存百分比 = 0;

        public void 获得内存信息()
        {
            ManagementObjectCollection 系统管理类对象集合 = 系统管理类.GetInstances();
            foreach (ManagementObject 系统管理类对象 in 系统管理类对象集合)
            {
                if (系统管理类对象["TotalVisibleMemorySize"] != null)
                {
                    long 总计内存大小 = long.Parse(系统管理类对象["TotalVisibleMemorySize"].ToString());
                    内存信息数组[0] = 总计内存大小;
                }
                if (系统管理类对象["FreePhysicalMemory"] != null)
                {
                    long 剩余内存大小 = long.Parse(系统管理类对象["FreePhysicalMemory"].ToString());
                    内存信息数组[1] = 剩余内存大小;
                }
                内存信息数组[2] = 内存信息数组[0] - 内存信息数组[1]; //已用内存大小
                //已用内存百分比 = (float)Math.Round((double)(内存信息数组[2] / Convert.ToDecimal(内存信息数组[0]) * 100),2,MidpointRounding.AwayFromZero);
                已用内存百分比 = (float)(内存信息数组[2] / Convert.ToDecimal(内存信息数组[0]) * 100); //已用内存百分比=已用内存大小/总计内存大小
            }
        }

        public void 获得磁盘信息()
        {
            PerformanceCounter 当前硬盘I计数器 = 硬盘性能计数器数组[0];
            硬盘I信息数组[0] = 当前硬盘I计数器.NextValue();
            if (硬盘I信息数组[0] > 硬盘I信息数组[1])
            {
                硬盘I信息数组[1] = 硬盘I信息数组[0];
            }
            if (硬盘I信息数组[1] > 0)
            {
                硬盘I信息数组[2] = 硬盘I信息数组[0] / 硬盘I信息数组[1] * 100;
            }
            PerformanceCounter 当前硬盘O计数器 = 硬盘性能计数器数组[1];
            硬盘O信息数组[0] = 当前硬盘O计数器.NextValue();
            if (硬盘O信息数组[0] > 硬盘O信息数组[1])
            {
                硬盘O信息数组[1] = 硬盘O信息数组[0];
            }
            if (硬盘O信息数组[1] > 0)
            {
                硬盘O信息数组[2] = 硬盘O信息数组[0] / 硬盘O信息数组[1] * 100;
            }
            硬盘IO信息数组[0] = 硬盘I信息数组[0] + 硬盘O信息数组[0];
            硬盘IO信息数组[1] = 硬盘I信息数组[1] + 硬盘O信息数组[1];
            硬盘IO信息数组[2] = 0;
            if (硬盘IO信息数组[1] > 0)
            {
                硬盘IO信息数组[2] = 硬盘IO信息数组[0] / 硬盘IO信息数组[1] * 100;
            }
        }

        public void 获得网络信息()
        {
            PerformanceCounter 当前网络I计数器 = 网络性能计数器数组[0];
            网络I信息数组[0] = 当前网络I计数器.NextValue();
            if (网络I信息数组[0] > 网络I信息数组[1])
            {
                网络I信息数组[1] = 网络I信息数组[0];
            }
            if (网络I信息数组[1] > 0)
            {
                网络I信息数组[2] = 网络I信息数组[0] / 网络I信息数组[1] * 100;
            }
            PerformanceCounter 当前网络O计数器 = 网络性能计数器数组[1];
            网络O信息数组[0] = 当前网络O计数器.NextValue();
            if (网络O信息数组[0] > 网络O信息数组[1])
            {
                网络O信息数组[1] = 网络O信息数组[0];
            }
            if (网络O信息数组[1] > 0)
            {
                网络O信息数组[2] = 网络O信息数组[0] / 网络O信息数组[1] * 100;
            }
            网络IO信息数组[0] = 网络I信息数组[0] + 网络O信息数组[0];
            网络IO信息数组[1] = 网络I信息数组[1] + 网络O信息数组[1];
            网络IO信息数组[2] = 0;
            if (网络IO信息数组[1] > 0)
            {
                网络IO信息数组[2] = 网络IO信息数组[0] / 网络IO信息数组[1] * 100;
            }
        }

        public void 初始化硬盘IO计数器()
        {
            //new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ManagementClass 硬盘系统管理类 = new ManagementClass("Win32_DiskDrive");
            ManagementObjectCollection 系统管理类对象集合 = 硬盘系统管理类.GetInstances();
            int 硬盘数计数器 = 0;
            foreach (ManagementObject 系统管理类对象 in 系统管理类对象集合)
            {
                硬盘名称数组.Add((string)系统管理类对象.Properties["Model"].Value);
                PerformanceCounter 当前硬盘IO计数器 = new PerformanceCounter("PhysicalDisk", "Disk Reads/sec", 硬盘数计数器.ToString());
                硬盘数计数器++;
                硬盘性能计数器数组.Add(当前硬盘IO计数器);
            }
        }

        public void 初始化硬盘IO总计数器()
        {
            ManagementClass 硬盘系统管理类 = new ManagementClass("Win32_DiskDrive");
            ManagementObjectCollection 系统管理类对象集合 = 硬盘系统管理类.GetInstances();
            foreach (ManagementObject 系统管理类对象 in 系统管理类对象集合)
            {
                PerformanceCounter 当前硬盘I计数器 = new PerformanceCounter("PhysicalDisk", "Disk Writes/sec", "_Total");
                硬盘性能计数器数组.Add(当前硬盘I计数器);
                PerformanceCounter 当前硬盘O计数器 = new PerformanceCounter("PhysicalDisk", "Disk Reads/sec", "_Total");
                硬盘性能计数器数组.Add(当前硬盘O计数器);
                break;
            }
        }

        public void 初始化网络计数器()
        {
            PerformanceCounterCategory 网络管理类 = new PerformanceCounterCategory("Network Interface");
            foreach (string name in 网络管理类.GetInstanceNames())
            {
                if (name == "MS TCP Loopback interface")
                    continue;
                PerformanceCounter 当前网络接收计数器 = new PerformanceCounter("Network Interface", "Bytes Received/sec", name);
                网络性能计数器数组.Add(当前网络接收计数器);
                PerformanceCounter 当前网络发送计数器 = new PerformanceCounter("Network Interface", "Bytes Sent/sec", name);
                网络性能计数器数组.Add(当前网络发送计数器);
                break;
            }

        }

        public void 初始化处理器计数器()
        {
            // Get the WMI class
            ManagementClass 处理器系统管理类 = new ManagementClass(new ManagementPath("Win32_Processor"));
            // Get the properties in the class
            ManagementObjectCollection 系统管理类对象集合 = 处理器系统管理类.GetInstances();
            foreach (ManagementObject 系统管理类对象 in 系统管理类对象集合)
            {
                PropertyDataCollection 处理器内核信息 = 系统管理类对象.Properties;
                //获取内核数代码
                处理器内核数数组[0] = (String)处理器内核信息["Name"].Value.ToString(); //处理器名
                处理器名称数组.Add(处理器内核数数组[0]);
                处理器内核数数组[1] = (String)处理器内核信息["NumberOfCores"].Value.ToString(); //物理内核数
                处理器内核数数组[2] = (String)处理器内核信息["NumberOfLogicalProcessors"].Value.ToString(); //逻辑内核数

                //其他属性获取代码
                //foreach (PropertyData 处理器内核属性 in 处理器内核信息)
                //{
                //    Console.WriteLine(处理器内核属性.Name + ":" + 处理器内核属性.Value + "\n");
                //}
            }
            for (int 处理器内核遍历计数器 = 0; 处理器内核遍历计数器 <= int.Parse(处理器内核数数组[2]); 处理器内核遍历计数器++)
            {
                PerformanceCounter 当前处理器性能计数器;
                if (处理器内核遍历计数器 == int.Parse(处理器内核数数组[2]))
                {
                    当前处理器性能计数器 = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                }
                else
                {
                    当前处理器性能计数器 = new PerformanceCounter("Processor", "% Processor Time", 处理器内核遍历计数器.ToString());
                }
                当前处理器性能计数器.NextValue();
                处理器性能计数器数组.Add(当前处理器性能计数器);
            }
        }


    }
}
