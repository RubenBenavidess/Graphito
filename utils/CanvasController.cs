using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphito
{
    internal static class CanvasController
    {
        private static String Filters = "Archivos JPEG (*.jpg)|*.jpg|Archivos PNG (*.png)|*.png|Archivos BMP (*.bmp)|*.bmp";

        public static void SaveCanvas(Canvas picCanvas) {

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Title = "Guardar archivo";
            saveFileDialog.Filter = Filters;
            saveFileDialog.DefaultExt = "png";
            saveFileDialog.AddExtension = true;
            saveFileDialog.OverwritePrompt = true;

            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                String filePath = saveFileDialog.FileName;
                String extension = Path.GetExtension(filePath);
                FileManager.Save(picCanvas, extension, filePath);
            }
            else
            {
                MessageBox.Show("El guardado fue cancelado.");
            }

        }

        public static void LoadCanvas(Canvas picCanvas)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = Filters;

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                FileManager.Load(picCanvas, openFileDialog.FileName);
            }
            else
            {
                MessageBox.Show("No se seleccionó ningún archivo.");
            }
        }

    }
}
