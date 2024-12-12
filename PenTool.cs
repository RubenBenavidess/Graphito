using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphito
{
    internal class PenTool : ITool
    {
        private Color PrimaryColor;
        private Color SecondaryColor;
        private int Width;
        public PenTool(Color primaryColor, Color secondaryColor, int width) { 
            this.PrimaryColor = primaryColor;
            this.SecondaryColor = secondaryColor;
            this.Width = width;
        }

        private Point? lastPoint = null;

        public void Use(Bitmap bmp, Point point, int click)
        {
            Color color;
            if (click > 0) color = SecondaryColor;
            else color = PrimaryColor;

            if (lastPoint != null)
            {
                DrawLine(bmp, lastPoint.Value, point, color);
                DrawLine(bmp, lastPoint.Value, point, color);
            }

            lastPoint = point;
            DrawCircle(bmp, point, color); // Dibuja en el punto actual
        }

        private void DrawCircle(Bitmap bmp, Point center, Color color)
        {
            int radius = Width / 2;
            for (int y = -radius; y <= radius; y++)
            {
                for (int x = -radius; x <= radius; x++)
                {
                    if (x * x + y * y <= radius * radius)
                    {
                        int px = center.X + x;
                        int py = center.Y + y;

                        if (px >= 0 && px < bmp.Width && py >= 0 && py < bmp.Height)
                        {
                            bmp.SetPixel(px, py, color);
                        }
                    }
                }
            }
        }

        private void DrawLine(Bitmap bmp, Point start, Point end, Color color)
        {
            int dx = Math.Abs(end.X - start.X);
            int dy = Math.Abs(end.Y - start.Y);
            int sx = start.X < end.X ? 1 : -1;
            int sy = start.Y < end.Y ? 1 : -1;
            int err = dx - dy;

            while (true)
            {
                DrawCircle(bmp, start, color);

                if (start.X == end.X && start.Y == end.Y)
                    break;

                int e2 = 2 * err;

                if (e2 > -dy)
                {
                    err -= dy;
                    start.X += sx;
                }

                if (e2 < dx)
                {
                    err += dx;
                    start.Y += sy;
                }
            }
        }

        public void Reset()
        {
            lastPoint = null;
        }
    }
}
