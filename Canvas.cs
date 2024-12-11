
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphito
{
    internal class Canvas : PictureBox
    {
        public Bitmap bmp {  get; set; }

        public Canvas(Bitmap bmp)
        {
            this.bmp = bmp;
        }

        public void Refresh()
        {
            this.Image = bmp;
        }
        
        public void LoadBitmap(Bitmap bmp)
        {
            if(bmp != null)
            {
                this.bmp = bmp;
            }
        }

        public void MouseDown(object sender, MouseEventArgs e) {
            //Main.currentTool.use(this.bmp, new Point(e.X, e.Y))
        }

        public void MouseUp(object sender, MouseEventArgs e) {
            //Main.currentTool.use(this.bmp, new Point(e.X, e.Y))
        }

        public void MouseMove(object sender, MouseEventArgs e) {
            //Main.currentTool.use(this.bmp, new Point(e.X, e.Y))
        }

    }
}
