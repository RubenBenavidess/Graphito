using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphito
{
    internal static class FileManager
    {
        private static String LastFilePath;
        public static bool Save(Canvas canvas, string extension, string path, string fileName)
        {

            if (String.IsNullOrWhiteSpace(extension) || String.IsNullOrWhiteSpace(path) || String.IsNullOrWhiteSpace(fileName))
            {
                Console.WriteLine("Error al guardar el archivo: Campos Incorrectos");
                return false;
            }

            ImageFormat format;
            extension = extension.ToLowerInvariant();

            switch (extension)
            {
                case "jpeg":
                    format = ImageFormat.Jpeg;
                    break;
                case "png":
                    format = ImageFormat.Png;
                    break;
                case "bmp":
                    format = ImageFormat.Bmp;
                    break;
                default:
                    Console.WriteLine("Error al guardar el archivo: Extensión Inválida");
                    return false;
            }

            try
            {
                string fullPath = Path.Combine(path, fileName);
                canvas.bmp.Save(fullPath, format);
                Console.WriteLine("Archivo guardado exitosamente.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar el archivo: " + ex.Message);
                return false;
            }
        }

        public static bool Load(Canvas canvas, String filePath)
        {
            
            string extension = Path.GetExtension(filePath)?.ToLowerInvariant();
            if (string.IsNullOrEmpty(extension) || (extension != ".jpeg" && extension != ".png" && extension != ".bmp"))
            {
                Console.WriteLine("Error: Extensión de archivo no soportada.");
                return false;
            }

            try
            {
                Image image = Image.FromFile(filePath);
                canvas.LoadBitmap(new Bitmap(image));
                canvas.Refresh();

                Console.WriteLine("Archivo cargado exitosamente.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar el archivo: " + ex.Message);
                return false;
            }

        }

    }
}
