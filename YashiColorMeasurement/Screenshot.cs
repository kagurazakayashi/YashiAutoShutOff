using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace YashiColorMeasurement
{
    class Screenshot
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

        static public int[] mousePixelColorXYRGBA()
        {
            int[] mousepx = new int[2] { Control.MousePosition.X, Control.MousePosition.Y };
            Color cor = GetPixelColor(mousepx[0], mousepx[1]);
            return new int[6] { mousepx[0], mousepx[1], cor.R, cor.G, cor.B, cor.A };
        }
    }
}
