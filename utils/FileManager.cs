using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphito
{
    internal static class FileManager
    {
        private static String LastFilePath;
        public static bool Save(Canvas canvas, string extension, string path)
        {

            if (String.IsNullOrWhiteSpace(extension) || String.IsNullOrWhiteSpace(path))
            {
                Console.WriteLine("Error al guardar el archivo: Campos Incorrectos");
                MessageBox.Show("Archivo guardado exitosamente.");
                return false;
            }

            ImageFormat format;
            extension = extension.ToLowerInvariant();


            switch (extension)
            {
                case ".jpg":
                    format = ImageFormat.Jpeg;
                    break;
                case ".png":
                    format = ImageFormat.Png;
                    break;
                case ".bmp":
                    format = ImageFormat.Bmp;
                    break;
                default:
                    MessageBox.Show("Error al guardar el archivo: Extensión Inválida");                   
                    return false;
            }

            try
            {
                canvas.bmp.Save(path, format);
                MessageBox.Show("Archivo guardado exitosamente.");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Archivo NO guardado exitosamente: " + ex.Message);
                return false;
            }
        }

        public static Bitmap Resize(Bitmap Image, int Width, int Height)
        {
            Bitmap resizedImage = new Bitmap(Width, Height);
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                graphics.DrawImage(Image, 0, 0, Width, Height);
            }
            
            return resizedImage;
        }

        public static bool Load(Canvas canvas, String filePath)
        {
            
            string extension = Path.GetExtension(filePath)?.ToLowerInvariant();
            if (string.IsNullOrEmpty(extension) || (extension != ".jpg" && extension != ".png" && extension != ".bmp"))
            {
                MessageBox.Show("Error: Extensión de archivo no soportada.");
                return false;
            }

            try
            {
                Image image = Image.FromFile(filePath);


                canvas.LoadBitmap(Resize(new Bitmap(image), canvas.Width, canvas.Height));

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el archivo: " + ex.Message);
                return false;
            }

        }

    }
}
