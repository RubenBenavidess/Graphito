using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphito
{
    public interface ITool
    {
        void Use(Bitmap bmp, Point p, int click);

        void Reset();
    }
}
