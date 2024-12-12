
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
        public Bitmap bmpPreview { get; set; }
        public bool IsDrawing, IsDrawingTool;
        int click;

        public Canvas()
        {
            bmp = new Bitmap(1280, 720);
            bmpPreview = new Bitmap(1280, 720);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
            }
            this.MouseDown += CanvasMouseDown;
            this.MouseMove += CanvasMouseMove;
            this.MouseUp += CanvasMouseUp;

            IsDrawing = false;
        }

        public void RefreshImage()
        {
            Image = bmp;
        }
        
        public void ShowPreview()
        {
            Image = bmpPreview;
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

            ActionsRecordManager.PushActionUndo((Bitmap)this.bmp.Clone());

            if (e.Button == MouseButtons.Left)
                click = -1;
            else
                click = 1;

            if (Main.CurrentTool.ToString() != "Graphito.ShapeDrawer")
            {
                IsDrawingTool = false;
                Main.CurrentTool?.Use(bmp, new Point(e.X, e.Y), click);
                RefreshImage();
            }
            else
            {
                bmpPreview = (Bitmap)bmp.Clone(); 
                IsDrawingTool = true;
                Main.CurrentTool?.Use(bmpPreview, new Point(e.X, e.Y), click);
                ShowPreview();
            }

            IsDrawing = true;
        }

        public void CanvasMouseMove(object sender, MouseEventArgs e) {
           
            if(IsDrawing)
            {
                if (!IsDrawingTool)
                {
                    Main.CurrentTool?.Use(bmp, new Point(e.X, e.Y), click);
                    RefreshImage();
                }
                else
                {
                    bmpPreview = (Bitmap)bmp.Clone();
                    Main.CurrentTool?.Use(bmpPreview, new Point(e.X, e.Y), click);
                    ShowPreview();
                }
            }
        }

        public void CanvasMouseUp(object sender, MouseEventArgs e)
        {
            IsDrawing = false;
            if (IsDrawingTool)
            {
                bmp = (Bitmap)bmpPreview.Clone();
                IsDrawingTool = false;
            }
            Main.CurrentTool?.Reset();
            RefreshImage();

        }

        public void OnMouseLeave(object sender, EventArgs e)
        {
        }
    }
}
