
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
        public bool IsDrawing;
        int click;

        public Canvas()
        {
            bmp = new Bitmap(1280, 720);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
            }
            this.MouseDown += CanvasMouseDown;
            this.MouseMove += CanvasMouseMove;
            this.MouseUp += CanvasMouseUp;

            IsDrawing = false;
        }

        public Canvas(int width, int height)
        {
            this.bmp = new Bitmap(width, height);
            this.Image = this.bmp;
            using(Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
            }
            RefreshImage();
        }

        public void RefreshImage()
        {
            Image = bmp;
        }
        
        public void Renew()
        {
            bmp = new Bitmap(1280, 720);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
            }
            RefreshImage();
        }

        public void LoadBitmap(Bitmap btmp)
        {
            if(btmp != null)
            {
                bmp = btmp;
                RefreshImage();
            }
            
        }

        public void CanvasMouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left)
                click = -1;
            else
                click = 1;

            IsDrawing = true;
            Main.CurrentTool?.Use(bmp, new Point(e.X, e.Y), click);
            RefreshImage();

            ActionsRecordManager.PushActionUndo((Bitmap)this.bmp.Clone());
            if (ActionsRecordManager.RedoStack.Count > 0)
            {
                ActionsRecordManager.RedoStack.Pop();
            }
            
        }

        public void CanvasMouseMove(object sender, MouseEventArgs e) {
            if(IsDrawing)
            {
                Main.CurrentTool?.Use(bmp, new Point(e.X, e.Y), click);
                RefreshImage();
            }
        }

        public void CanvasMouseUp(object sender, MouseEventArgs e)
        {
            IsDrawing = false;
            Main.CurrentTool?.Reset();

            ActionsRecordManager.PushActionRedo((Bitmap)this.bmp.Clone());
        }

        public void OnMouseLeave(object sender, EventArgs e)
        {
        }
    }
}
