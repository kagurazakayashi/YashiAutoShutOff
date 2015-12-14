using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace YashiAutoShutOff
{
    static class Screenshot
    {
        [DllImport("gdi32.dll")]
        public static extern System.UInt32 GetPixel(IntPtr hdc, int xPos, int yPos);
        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("user32.dll")]
        private static extern IntPtr ReleaseDC(IntPtr hc, IntPtr hDest);

        static public System.Drawing.Color GetPixelColor(int x, int y)
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            uint pixel = GetPixel(hdc, x, y);
            ReleaseDC(IntPtr.Zero, hdc);
            Color color = Color.FromArgb((int)(pixel & 0x000000FF),
            (int)(pixel & 0x0000FF00) >> 8,
            (int)(pixel & 0x00FF0000) >> 16);
            return color;
        }

        static public int[] GetPixelColorRGBA(int x, int y)
        {
            Color nc = GetPixelColor(x, y);
            return new int[4] { nc.R, nc.G, nc.B, nc.A };
        }

        static public int[] mousePixelColorXYRGBA()
        {
            int[] mousepx = new int[2] { Control.MousePosition.X, Control.MousePosition.Y };
            Color cor = GetPixelColor(mousepx[0], mousepx[1]);
            return new int[6] { mousepx[0], mousepx[1], cor.R, cor.G, cor.B, cor.A };
        }

        static public void 截图到文件()
        {
            string 截图文件 = SettingLoad.截图保存路径 + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".jpeg";
            try
            {
                if (!Directory.Exists(SettingLoad.截图保存路径))
                {
                    Directory.CreateDirectory(SettingLoad.截图保存路径);
                }
                Screen scr = Screen.PrimaryScreen;
                Rectangle rc = scr.Bounds;
                int iWidth = rc.Width;
                int iHeight = rc.Height;
                Bitmap myImage = new Bitmap(iWidth, iHeight);
                Graphics gl = Graphics.FromImage(myImage);
                gl.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(iWidth, iHeight));
                myImage.Save(截图文件);
            }
            catch (Exception err)
            {
                if (SettingLoad.debug)
                {
                    MessageBox.Show(截图文件 + err.Message, "DEBUG: 截图失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //private void timer_Tick(object sender, EventArgs e)
        //{
        //    textBox1.Text = GetPixelColor(Cursor.Position.X, Cursor.Position.Y).R.ToString() + " " + GetPixelColor(Cursor.Position.X, Cursor.Position.Y).G.ToString() + " " + GetPixelColor(Cursor.Position.X, Cursor.Position.Y).B.ToString();
        //}

    }
}
