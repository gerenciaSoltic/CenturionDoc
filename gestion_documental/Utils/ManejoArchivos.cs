using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing.Imaging;
using GESTIONDOCUMENTAL.Utils;

namespace gestion_documental.Utils
{
    public class ManejoArchivos
    {
       
        
        
        /// <summary>
        /// copia un archivo de un lugar a otro
        /// </summary>
        public static bool copyFile(string pathSource, string pathDestine)
        {
            bool exito = false;
            if (File.Exists(pathSource))
            {
                try
                {
                    
                    File.Copy(pathSource, pathDestine, true);
                    exito = true;
                }
                catch
                {
                    exito = false;
                }
            }

            return exito;
        }
        public static bool TieneFormatoValido(string imagenFile)
        {
            bool exito = false;
            try
            {
                MemoryStream stream = new MemoryStream();
                string extension = Path.GetExtension(imagenFile);
                ImageFormat formatoImagen = null;
                switch (extension)
                {
                    case ".jpg":
                        formatoImagen = ImageFormat.Jpeg;
                        break;
                    case ".jpeg":
                        formatoImagen = ImageFormat.Jpeg;
                        break;
                    case ".png":
                        formatoImagen = ImageFormat.Png;
                        break;
                    case ".gif":
                        formatoImagen = ImageFormat.Gif;
                        break;
                    case ".pdf":
                        formatoImagen = ImageFormat.Gif;
                        break;
                }
                return formatoImagen != null;

            }
            catch (Exception e)
            {

                //log.Error(e.Message, e);

            }
            return exito;
        }

        public static string GetDirectorioActual()
        {
            return Directory.GetCurrentDirectory();
        }

        /// <summary>
        /// Verifica si existe el archivo y procede a eliminarlo.
        /// </summary>
        /// <param name="path"></param>
        public static bool EliminarArchivo(string path, string nombreArchivo)
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(nombreArchivo)) return false;
            string _path = Path.Combine(path, nombreArchivo);
            try
            {
                if (File.Exists(_path))
                {
                    File.Delete(_path);
                }
                return !File.Exists(_path);
            }
            catch (Exception e)
            {
                //log.Info(e.Message, e);
                return false;
            }
        }
        

    }
}