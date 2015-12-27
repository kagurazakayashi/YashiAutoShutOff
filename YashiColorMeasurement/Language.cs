using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace YashiColorMeasurement
{
    static class Language
    {
        public static List<string> ls = new List<string>();
        static string exe = "YashiColorMeasurement_";
        static string defaultlang = exe + "zh-CN.language";
        public static bool showErr = true;
        static bool linit = false;

        public static bool initLanguage(string lfilename)
        {
            string 系统语言 = System.Globalization.CultureInfo.InstalledUICulture.Name;
            string lfile = exe + 系统语言 + ".language";
            if (lfilename != null)
            {
                lfile = lfilename;
            }
            bool req = loadLanguage(lfile);
            if (ls.Count == 0)
            {
                req = false;
            }
            if (!req && showErr)
            {
                MessageBox.Show("Failed to load language file:\n" + lfile, "载入语言文件失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            linit = true;
            //MessageBox.Show(":" + ls.Count, "载入语言成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return req;
        }

        public static string s(int id)
        {
            if (!linit)
            {
                MessageBox.Show("No initial language! " + ls.Count, "载入语言文件失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (id < ls.Count)
            {
                return ls[id];
            }
            //MessageBox.Show(":" + ls.Count, "载入语言文件失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return "<language file error>";
        }

        static bool loadLanguage(string lfilename)
        {
            if (File.Exists(lfilename))
            {
                try
                {
                    String lfile = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + lfilename;
                    StreamReader sr = new StreamReader(lfile, Encoding.Default);
                    string n;
                    while ((n = sr.ReadLine()) != null)
                    {
                        ls.Add(n);
                    }
                    sr.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                if (lfilename.Equals(defaultlang))
                {
                    return false;
                }
                return loadLanguage(defaultlang);
            }
        }
    }
}
