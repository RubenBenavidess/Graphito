﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphito
{
    internal interface ITool
    {
        void use(Bitmap bmp, PointF coord);    
    }
}
