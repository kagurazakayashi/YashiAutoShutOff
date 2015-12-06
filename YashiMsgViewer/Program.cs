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
            Console.Title = "Yashi application message viewer";
            if (args.Length > 0 && args[0] == "-viewer")
            {
                bool run = true;
                try
                {
                    while (run)
                    {
                        string cmd = Console.ReadLine();
                        if (cmd == "exit")
                        {
                            break;
                        }
                        else if (cmd == "cls")
                        {
                            Console.Clear();
                        }
                        else if (cmd.Length > 6 && cmd.Substring(0, 6) == "title ")
                        {
                            Console.Title = cmd.Substring(6);
                        }
                        else
                        {
                            Console.WriteLine(cmd);
                        }
                    }
                }
                catch (Exception e)
                {

                }
            }
            else
            {
                Console.WriteLine(" \n     这个程序是雅诗应用中的一部分，不能单独运行。\n \n          请按任意键退出...");
                Console.ReadKey();
            }
        }
    }
}
