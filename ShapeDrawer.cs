using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Graphito
{
    internal class ShapeDrawer : ITool
    {
        Color PrimaryColor;
        Color SecondaryColor;
        int Width;
        private Point? StartPoint = null;
        private Action<Bitmap, Point, int> DrawAction;

        public ShapeDrawer(Color primaryColor, Color secondaryColor, int width, string shape)
        {
            this.PrimaryColor = primaryColor;
            this.SecondaryColor = secondaryColor;
            this.Width = width;

            switch (shape.ToLower())
            {
                case "ellipse":
                    DrawAction = UseEllipse;
                    break;
                case "rectangle":
                    DrawAction = UseRectangle;
                    break;
                case "circle":
                    DrawAction = UseCircle;
                    break;
                default:
                    throw new ArgumentException("Shape not supported");
            }
        }

        public void Use(Bitmap bmp, Point point, int click)
        {
            DrawAction(bmp, point, click);
        }

        private void UseCircle(Bitmap bmp, Point point, int click)
        {
            if (StartPoint == null)
            {
                StartPoint = point;
                return;
            }

            Color color = click > 0 ? SecondaryColor : PrimaryColor;

            using (Graphics g = Graphics.FromImage(bmp))
            {
                Pen pen = new Pen(color, Width);
                int diameter = Math.Max(Math.Abs(point.X - StartPoint.Value.X), Math.Abs(point.Y - StartPoint.Value.Y));

                bool positiveX = point.X > StartPoint.Value.X;
                bool positiveY = point.Y > StartPoint.Value.Y;

                g.DrawEllipse(pen, StartPoint.Value.X, StartPoint.Value.Y, positiveX ? diameter: -diameter, positiveY ? diameter: -diameter);
            }
        }

        private void UseEllipse(Bitmap bmp, Point point, int click)
        {
            if (StartPoint == null)
            {
                StartPoint = point;
                return;
            }

            Color color = click > 0 ? SecondaryColor : PrimaryColor;

            using (Graphics g = Graphics.FromImage(bmp))
            {
                Pen pen = new Pen(color, Width);
                g.DrawEllipse(pen, StartPoint.Value.X, StartPoint.Value.Y, point.X - StartPoint.Value.X, point.Y - StartPoint.Value.Y);
            }

        }

        private void UseRectangle(Bitmap bmp, Point point, int click)
        {
            if (StartPoint == null)
            {
                StartPoint = point;
                return;
            }

            Color color = click > 0 ? SecondaryColor : PrimaryColor;

            using (Graphics g = Graphics.FromImage(bmp))
            {
                Pen pen = new Pen(color, Width);
                int x = Math.Min(StartPoint.Value.X, point.X);
                int y = Math.Min(StartPoint.Value.Y, point.Y);
                int width = Math.Abs(point.X - StartPoint.Value.X);
                int height = Math.Abs(point.Y - StartPoint.Value.Y);
                g.DrawRectangle(pen, x, y, width, height);
            }
        }

        public void Reset()
        {
            StartPoint = null;
        }
    }
}
