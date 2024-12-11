using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphito
{
    internal class Eraser : ITool
    {
        public int width { set; get; }

        public Eraser(int width) {
            this.width = width;
        }

        public void Use(Bitmap bmp, PointF coord)
        {
            //to do: implement
        }
    }
}
