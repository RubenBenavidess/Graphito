using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphito
{
    internal class ShapeDrawer : ITool
    {
        public Color color { set; get; }
        public int width { set; get; }
        public String penType { set; get; }
        public Shape shape { set; get; }

        public ShapeDrawer(Color color, int width, String penType, Shape shape) { 
            this.color = color;
            this.width = width;
            this.penType = penType;
            this.shape = shape;
        }

        public void Use(Bitmap bmp, PointF coord)
        {
            //to do: implement
        }
    }
}
