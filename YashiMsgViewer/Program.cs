using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//copy C:\Users\yashi\Desktop\YashiAutoShutOff\YashiMsgViewer\bin\Debug\YashiMsgViewer.exe C:\Users\yashi\Desktop\YashiAutoShutOff\YashiAutoShutOff\bin\Debug\

namespace YashiMsgViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            String name = "Yashi application message viewer";
            Console.Title = name;
            if (args.Length > 0 && (args[0] == "-viewer" || args[0] == "--viewer" || args[0] == "/viewer"))
            {
                Console.Clear();
                bool run = true;
                bool echo = true;
                try
                {
                    while (run)
                    {
                        string cmd = Console.ReadLine();
                        if (cmd == "exit")
                        {
                            break;
                        }
                        else if (cmd == "cls" || cmd == "clear")
                        {
                            Console.Clear();
                        }
                        else if (cmd == "echo on")
                        {
                            echo = true;
                        }
                        else if (cmd == "echo off")
                        {
                            echo = false;
                        }
                        else if (cmd.Length > 6 && cmd.Substring(0, 6) == "title ")
                        {
                            Console.Title = cmd.Substring(6);
                        }
                        else
                        {
                            if (echo)
                            {
                                Console.WriteLine(cmd);
                            }
                        }
                    }
                    Console.Clear();
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n" + name + "错误：" + e.Message.ToString());
                }
            }
            else if (args.Length > 0 && (args[0] == "-help" || args[0] == "--help" || args[0] == "/help" || args[0] == "/?"))
            {
                Console.WriteLine("用法： <thisapp> [ --viewer | --help ]");
                Console.WriteLine("没有参数：显示提示退出。");
                Console.WriteLine("viewer：输入模式开启。");
                Console.WriteLine("help：显示此帮助。");
                Console.WriteLine("语法：");
                Console.WriteLine("exit：退出此程序。");
                Console.WriteLine("echo [ on | off ]：显示输入回馈。");
                Console.WriteLine("cls / clear：清除输出。");
                Console.WriteLine("title：设置标题栏显示文字。");
                Console.WriteLine("其他：录入信息。");
                Console.WriteLine("请按任意键退出...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("这个程序是雅诗应用中的一部分，不能单独运行。");
                Console.WriteLine("请按任意键退出...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
