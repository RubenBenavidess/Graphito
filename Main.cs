using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphito
{
    public partial class Main : Form
    {
        public static ITool CurrentTool;
        //private Toolkit toolkit;

        public Main()
        {
            InitializeComponent();
            InitializeData();
        }

        public void InitializeData()
        {
            CurrentTool = ToolFactory.CreateTool("pen", Color.Black, Color.White);
            this.picCanvas.Left = (this.ClientSize.Width - this.picCanvas.Width) / 2;
        }


        private void Main_Load(object sender, EventArgs e)
        {
            InitializeData();
        }

        //boton para guardar la imagen
        private void itmSave_Click(object sender, EventArgs e)
        {
            try
            {
                CanvasController.SaveCanvas(this.picCanvas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        //metodo para cargar el canvas
        private void itmLoad_Click(object sender, EventArgs e)
        {
            try
            {
                CanvasController.LoadCanvas(this.picCanvas);
            }
            catch (Exception ex) { 
                MessageBox.Show("Error: " + ex.Message);
            }
            
        }
        //reajustar la pizarra
        private void Main_Resize(object sender, EventArgs e)
        {
            this.picCanvas.Left = (this.ClientSize.Width - this.picCanvas.Width) / 2;
        }
            
        //Limpiar la pizarra
        private void itmNew_Click(object sender, EventArgs e)
        {
            picCanvas.Renew();
        }
        
        //funcion del click de UnDo
        private void strItemUndo_Click(object sender, EventArgs e)
        {
            picCanvas.LoadBitmap(ActionsRecordManager.Undo((Bitmap)picCanvas.bmp.Clone()));
        }

        //Funcion del click de ReDo
        private void strItemRedo_Click(object sender, EventArgs e)
        {
            picCanvas.LoadBitmap(ActionsRecordManager.Redo((Bitmap)picCanvas.bmp.Clone()));
        }

        //Funcion para capturar el ctrl + z y el ctrl + y
        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.Z) //ctrl + z
            {
                picCanvas.LoadBitmap(ActionsRecordManager.Undo((Bitmap)picCanvas.bmp.Clone()));
            }
            if (e.Control && e.KeyCode == Keys.Y) // ctrl + y
            {
                picCanvas.LoadBitmap(ActionsRecordManager.Redo((Bitmap)picCanvas.bmp.Clone()));
            }
        }
        //levantar el mouse y salir del foco hacia el main
        private void picCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
            this.Focus();
        }
    }
}
