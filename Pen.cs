using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphito
{
    internal class Pen : ITool
    {
        public Color color { set; get; }
        public int width { set; get; }
        public String penType { set; get; }
        public Pen(Color color, int width, String penType) { 
            this.color = color;
            this.width = width;
            this.penType = penType;
        }

        public void Use(Bitmap bmp, PointF coord)
        {
            //to do: implement
        }
    }
}
