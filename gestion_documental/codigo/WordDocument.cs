using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using gestion_documental.Utils;

namespace gestion_documental.codigo
{
    public class WordDocument
    {
        private Word.Application wordApp;
        private Word.Document aDoc;
        private object missing = Missing.Value;
        private object filename;
        public string mensaje_modulo = "";

        public string word_tmp = "";
        public string pdf_tmp = "";
        public string fichero = "";


        public static string RutaArchivoTMP = @"~/plantilla/TMP/";
        //---------------------------------------------------------
        protected string getRuta(string fichero = "")
        {
            string Respuesta = "";
            try
            {
                string ruta_temp = RutaArchivoTMP;
                if (fichero != null) { ruta_temp = Path.Combine(RutaArchivoTMP, fichero); }
                Respuesta = System.Web.HttpContext.Current.Server.MapPath(ruta_temp);
            }
            catch (Exception Error) { string que_paso = Error.Message; Respuesta = ""; }


            return Respuesta;
        }

        public WordDocument(string docPath)
        {
            mensaje_modulo = "";
            string file_extension = System.IO.Path.GetExtension(docPath).ToLower();
            fichero = SessionDocumental.UsuarioInicioSession.CODIGO.ToString() + file_extension;
            EliminarFichero(fichero);
            File.Copy(docPath, getRuta(fichero), true);
            wordApp = new Word.Application();
            filename = getRuta(fichero);
            word_tmp = (string)filename;
            //
            if (File.Exists((string)filename))
            {
                object readOnly = false;
                object isVisible = false;
                wordApp.Visible = false;
                aDoc = wordApp.Documents.Open(ref filename, ref missing,
                ref readOnly, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref isVisible, ref missing, ref missing,
                ref missing, ref missing);
                aDoc.Activate();

            }
            else
            {
                //MessageBox.Show("El archivo no existe.", "Sin archivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mensaje_modulo = "El archivo no existe.";
            }

        }

        public void SaveDocument() { aDoc.Save(); }

        public void export_to_pdf()
        {
            if (fichero.Trim().Length > 0)
            {
                string srt_pdf = fichero + ".pdf";
                EliminarFichero(srt_pdf);
                aDoc.ExportAsFixedFormat(getRuta(srt_pdf), WdExportFormat.wdExportFormatPDF);
            }
        }


        public void CloseDocument()
        {
            object saveChanges = Word.WdSaveOptions.wdSaveChanges;
            wordApp.Quit(ref saveChanges, ref missing, ref missing);
        }

        public void FindAndReplace(object findText, object replaceText)
        {
            this.findAndReplace(wordApp, findText, replaceText);
        }


        public void findAndReplace(Word.Application wordApp, object findText, object replaceText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;
            wordApp.Selection.Find.Execute(ref findText, ref matchCase, ref matchWholeWord,
            ref matchWildCards, ref matchSoundsLike, ref matchAllWordForms,
            ref forward, ref wrap, ref format, ref replaceText, ref replace,
            ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);
        }

        public bool EliminarFichero(string fichero)
        {
            bool Respuesta = false;
            try
            {
                if (validarExistenciaArchivo(fichero))
                {
                    string ruta_completa = getRuta(fichero);
                    File.Delete(ruta_completa);
                    Respuesta = true;
                }
            }
            catch (Exception Error) { string que_paso = Error.Message; Respuesta = false; }

            return Respuesta;
        }
        public bool validarExistenciaArchivo(string fichero)
        {
            bool Respuesta = false;
            try
            {
                string ruta_completa = Path.GetFullPath(getRuta(fichero));
                Respuesta = File.Exists(ruta_completa);
            }
            catch (Exception error) { string que_paso = error.Message; Respuesta = false; }
            return Respuesta;
        }
    }
}