// YashiMsgViewer.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include <windows.h>
#include <string>
#include <iostream>
using namespace std;
int main(int argc, char* argv[])
{
	string name = "Yashi application message viewer";
	string docmd = "title " + name;
	system(docmd.c_str());
	if (argc == 2 && (strcmp(argv[1], "-viewer")==0 || strcmp(argv[1], "--viewer")==0 || strcmp(argv[1], "/viewer")==0)) {
		system("cls");
		bool run = true;
		bool echo = true;
		bool time = false;
		try {
			while (run)
			{
				string cmd;
				cmd.resize(100);
				getline(cin, cmd);
				if (cmd.compare("@exit") == 0)
				{
					run = false;
				}
				else if ((cmd.compare("@clear") == 0) || (cmd.compare("@cls") == 0))
				{
					system("cls");
				}
				else if ((cmd.compare("@echo on") == 0))
				{
					echo = true;
				}
				else if ((cmd.compare("@echo off") == 0))
				{
					echo = false;
				}
				else if ((cmd.compare("@time on") == 0))
				{
					time = true;
				}
				else if ((cmd.compare("@time off") == 0))
				{
					time = false;
				}
				else if (cmd.length() > 6 && cmd.substr(0, 7).compare("@title ") == 0)
				{
					system(cmd.c_str());
				}
				else
				{
					if (echo)
					{
						if (time)
						{
							SYSTEMTIME st = { 0 };
							GetLocalTime(&st);
							printf("[%d-%02d-%02d %02d:%02d:%02d:%03d] ",st.wYear,st.wMonth,st.wDay,st.wHour,st.wMinute,st.wSecond,st.wMilliseconds);
						}
						printf(cmd.c_str());
						printf("\n");
					}
				}
			}
			system("cls");
		}
		catch (double e) {
			printf("Yashi application message viewer error: %g", e);
			return (int)e;
		}
	}
	else if (argc == 2 && (strcmp(argv[1], "-help")==0 || strcmp(argv[1], "--help")==0 || strcmp(argv[1], "/help")==0 || strcmp(argv[1], "/?")==0))
	{
		printf("雅诗软件信息显示工具\n\n");
		printf("用法： <thisapp> [ --viewer | --help ]\n");
		printf("没有参数：显示提示退出。\n");
		printf("--viewer：输入模式开启。\n");
		printf("--help：显示此帮助。\n");
		printf("\n命令语法：\n");
		printf("@exit：退出此程序。\n");
		printf("@echo [ on | off ]：显示输入回馈（默认on）。\n");
		printf("@time [ on | off ]：显示时间（默认off）。\n");
		printf("@cls / clear：清除输出。\n");
		printf("@title：设置标题栏显示文字。\n");
		printf("其他：录入信息。\n\n");
		system("pause");
	}
	else
	{
		printf("这个程序是雅诗应用中的一部分，不能单独运行。\n");
		system("pause");
	}
	
    return 0;
	
}

