using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Graphito
{
    internal class FillTool : ITool
    {
        private Color PrimaryColor;
        private Color SecondaryColor;
        public FillTool(Color primaryColor, Color secondaryColor)
        {
            PrimaryColor = primaryColor;
            SecondaryColor = secondaryColor;
        }

        public void Use(Bitmap bmp, Point startPoint, int click)
        {
            Color color;
            if (click < 0) color = PrimaryColor;
            else color = SecondaryColor;

            Fill(bmp, startPoint, color);
        }

        private void Fill(Bitmap bmp, Point startPoint, Color color)
        {
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                                           ImageLockMode.ReadWrite,
                                           PixelFormat.Format32bppArgb);

            int stride = data.Stride;
            IntPtr ptr = data.Scan0;

            int[] pixels = new int[bmp.Width * bmp.Height];
            System.Runtime.InteropServices.Marshal.Copy(ptr, pixels, 0, pixels.Length);

            int targetColor = pixels[startPoint.Y * bmp.Width + startPoint.X];
            int fillColor = color.ToArgb();

            if (targetColor == fillColor)
            {
                bmp.UnlockBits(data);
                return;
            }

            Stack<Point> stack = new Stack<Point>();
            stack.Push(startPoint);

            while (stack.Count > 0)
            {
                Point current = stack.Pop();
                int x = current.X;
                int y = current.Y;

                if (x < 0 || x >= bmp.Width || y < 0 || y >= bmp.Height)
                    continue;

                int index = y * bmp.Width + x;

                if (pixels[index] != targetColor)
                    continue;

                // Rellena hacia la izquierda
                int left = x;
                while (left >= 0 && pixels[y * bmp.Width + left] == targetColor)
                {
                    pixels[y * bmp.Width + left] = fillColor;
                    left--;
                }

                // Rellena hacia la derecha
                int right = x + 1;
                while (right < bmp.Width && pixels[y * bmp.Width + right] == targetColor)
                {
                    pixels[y * bmp.Width + right] = fillColor;
                    right++;
                }

                for (int i = left + 1; i < right; i++)
                {
                    if (y > 0 && pixels[(y - 1) * bmp.Width + i] == targetColor)
                        stack.Push(new Point(i, y - 1));
                    if (y < bmp.Height - 1 && pixels[(y + 1) * bmp.Width + i] == targetColor)
                        stack.Push(new Point(i, y + 1));
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(pixels, 0, ptr, pixels.Length);
            bmp.UnlockBits(data);
        }

        public void Reset()
        {

        }
    }
}
