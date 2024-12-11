using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphito
{
    internal class FillingBucket : ITool
    {
        Color color { set; get; }
        public FillingBucket(Color color) { 
            this.color = color;
        }

        public void Use(Bitmap bmp, PointF coord)
        {
            //to do: implement
        }
    }
}
