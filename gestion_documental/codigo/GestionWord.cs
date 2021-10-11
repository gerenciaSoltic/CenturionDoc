using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Packaging;
using gestion_documental.Utils;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using System.IO;
//using GemBox.Document;


namespace gestion_documental.codigo
{
    public class GestionWord
    {
        private Word.Application wordApp;
        private Word.Document aDoc;
        private WordprocessingDocument wordDocOPENXML;
        private object missing = Missing.Value;
        private object filename;
        string pass_document = "";
        string pass_template = "";

        //Rutas de ficheros
        private string nombre_fichero = "";
        private string srt_fichero_temporal = "";
        private string srt_ficheroPDF_temporal = "";
        public bool open_word = false;


        public GestionWord()
        {
            nombre_fichero = SessionDocumental.UsuarioInicioSession.CODIGO.ToString();
            vaciar_tmp();
        }

        public void set_password(string password_document, string password_template)
        {
            if (password_document.Trim().Length > 0) { pass_document = password_document; }
            if (password_template.Trim().Length > 0) { pass_template = password_template; }
        }

        public void cerrar_procesos_word(string url_archivo)
        {

            try
            {
                Word.Application app = (Word.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
                if (app == null) { return; }

                foreach (Word.Document d in app.Documents)
                {
                    if (d.FullName.ToLower() == url_archivo.ToLower())
                    {
                        object saveOption = Word.WdSaveOptions.wdDoNotSaveChanges;
                        object originalFormat = Word.WdOriginalFormat.wdOriginalDocumentFormat;
                        object routeDocument = false;
                        d.Close(ref saveOption, ref originalFormat, ref routeDocument);
                    }
                }

            }
            catch (Exception error) { string que_paso = error.Message; }
        }



        public void duplicar_word(string ruta_archivo)
        {
            string srt_extension = System.IO.Path.GetExtension(ruta_archivo).ToLower();
            string srt_fichero = nombre_fichero + srt_extension;
            string fichero_destino = getConcatenarRuta(srt_fichero);
            //Cerrando proceso, evitando error
            cerrar_procesos_word(fichero_destino);
            EliminarFichero(fichero_destino);
            //--------------------------------------

            File.Copy(ruta_archivo, getConcatenarRuta(srt_fichero), true);

            srt_fichero_temporal = fichero_destino;
        }

        public void cargar_fichero_word()
        {
            if (validarExistenciaArchivo(srt_fichero_temporal))
            {
                wordApp = new Word.Application();
                //---
                object readOnly = false;
                object isVisible = false;
                wordApp.Visible = false;
                //aDoc = wordApp.Documents.Open(ref filename, ref missing,
                //ref readOnly, ref missing, ref missing, ref missing,
                //ref missing, ref missing, ref missing, ref missing,
                //ref missing, ref isVisible, ref missing, ref missing,
                //ref missing, ref missing);

                aDoc = wordApp.Documents.Open(FileName: srt_fichero_temporal, ReadOnly: readOnly, PasswordDocument: pass_document, PasswordTemplate: pass_template, Visible: isVisible);

                aDoc.Activate();


            }
            else
            {
                vaciar_tmp();
            }
        }


        public void cargar_fichero_word_2(ref string tcArchivoTemp)
        {
            if (validarExistenciaArchivo(srt_fichero_temporal))
            {
                tcArchivoTemp = srt_fichero_temporal;
                wordDocOPENXML = WordprocessingDocument.Open(srt_fichero_temporal, true);
            }
            else
            {
                vaciar_tmp();
            }
        }

        public void SaveDocument() { aDoc.Save(); }
        public void SaveDocument_2() { wordDocOPENXML.Close(); }


        public void reemplazar_texto(object findText, object replaceText)
        {
            //this.findAndReplace(wordApp, findText, replaceText);
            //this.FindAndReplace2(wordApp, findText, replaceText);
            //this.FindAndReplaceLargeContent2(wordApp, findText, replaceText);
            this.findAndReplace_work(wordApp, findText, replaceText);
        }

        public void reemplazar_texto_2(string findText, string replaceText)
        {
            string docText = null;
            using (StreamReader sr = new StreamReader(wordDocOPENXML.MainDocumentPart.GetStream()))
            {
                docText = sr.ReadToEnd();
            }

            Regex regexText = new Regex(System.Web.HttpUtility.HtmlEncode(findText));
            docText = regexText.Replace(docText, replaceText);

            using (StreamWriter sw = new StreamWriter(wordDocOPENXML.MainDocumentPart.GetStream(FileMode.Create)))
            {
                sw.Write(docText);
            }
        }



        public string export_to_pdf()
        {
            string ruta_generado = "";

            try
            {
                if (srt_fichero_temporal.Trim().Length > 0)
                {

                    ruta_generado = getConcatenarRuta(nombre_fichero + ".pdf");
                    EliminarFichero(ruta_generado);

                    wordApp = new Application();
                    aDoc = wordApp.Documents.Open(srt_fichero_temporal);
                    aDoc.Activate();
                    try
                    {
                        aDoc.ExportAsFixedFormat(ruta_generado, WdExportFormat.wdExportFormatPDF);
                        srt_ficheroPDF_temporal = ruta_generado;
                    }
                    catch(Exception e)
                    {
                        string que_paso = e.Message;
                    }
                }

            }
            catch (Exception ex)
            {
                EliminarFichero(ruta_generado);
                ruta_generado = "";
            }

            return ruta_generado;
        }

        public string export_to_pdf_2()
        {
            string ruta_generado = "";

            try
            {
                if (srt_fichero_temporal.Trim().Length > 0)
                {
                    ruta_generado = getConcatenarRuta(nombre_fichero + ".pdf");
                    EliminarFichero(ruta_generado);
                    //aDoc.ExportAsFixedFormat(ruta_generado, WdExportFormat.wdExportFormatPDF);


                    //ComponentInfo.SetLicense("FREE-LIMITED-KEY");
                    //DocumentModel.Load(srt_fichero_temporal).Save(ruta_generado);
                    srt_ficheroPDF_temporal = ruta_generado;
                    
                }

            }
            catch (Exception error)
            {
                string que_paso = error.Message;
                EliminarFichero(ruta_generado);
                ruta_generado = "";
            }

            return ruta_generado;
        }





        //---------------------------------------------------------------------------
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

            //object replaceAll = Word.WdReplace.wdReplaceAll;

            ////object missing = System.Reflection.Missing.Value;

            //wordApp.Application.Selection.Find.ClearFormatting();

            //wordApp.Application.Selection.Find.Text = (string)findText;

            //wordApp.Application.Selection.Find.Replacement.ClearFormatting();



            //object fileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatFilteredHTML; 
            //object fileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocument; 

            //if (html) { replaceText = HtmlToPlainText((string)replaceText); }


            //if (replaceText.ToString().Length < 250) // Normal execution
            //{
            //    wordApp.Application.Selection.Find.Replacement.Text = (string)replaceText;

            //    wordApp.Application.Selection.Find.Execute(

            //    ref missing, ref missing, ref missing, ref missing, ref missing,

            //    ref missing, ref missing, ref missing, ref missing, ref missing,

            //    ref replaceAll, ref missing, ref missing, ref missing, ref missing);
            //}
            //else
            //{
            //    wordApp.Application.Selection.Find.Execute(
            //        ref findText, ref missing, ref missing, ref missing, ref missing,
            //        ref missing, ref missing, ref missing, ref missing, ref missing,
            //        ref missing, ref missing, ref missing, ref missing, ref missing);



            //    // the area where the findMe is located in the Document is selected.

            //    // Hence when you execute the statement below the replaceMe string is

            //    // placed in the area selected, which is what we wanted!



            //    wordApp.Application.Selection.Text = (string)replaceText;
            //}


        }

        public void findAndReplace_work(Word.Application wordApp, object findText, object replaceText)
        {
            object replaceAll = Word.WdReplace.wdReplaceAll;
            object missing = System.Reflection.Missing.Value;

            wordApp.Application.Selection.Find.ClearFormatting();
            wordApp.Application.Selection.Find.Text = (string)findText;
            wordApp.Application.Selection.Find.Replacement.ClearFormatting();

            //object fileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatFilteredHTML;
            //object fileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocument;

            if (replaceText.ToString().Length < 250) // Normal execution
            {
                wordApp.Application.Selection.Find.Replacement.Text = (string)replaceText;

                wordApp.Application.Selection.Find.Execute(

                ref missing, ref missing, ref missing, ref missing, ref missing,

                ref missing, ref missing, ref missing, ref missing, ref missing,

                ref replaceAll, ref missing, ref missing, ref missing, ref missing);
            }
            else
            {
                wordApp.Application.Selection.Find.Execute(
                    ref findText, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing);



                // the area where the findMe is located in the Document is selected.

                // Hence when you execute the statement below the replaceMe string is

                // placed in the area selected, which is what we wanted!



                wordApp.Application.Selection.Text = (string)replaceText;
            }
        }

        public bool FindAndReplace2(Microsoft.Office.Interop.Word.Application wordApp, object findText, object replaceWithText)
        {
            bool result = false;

            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllwordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object readOnly = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            string strNewReplaceWith = string.Empty;
            string[] strReplacements = replaceWithText.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strReplacements.Length; i++)
            {
                if (i != strReplacements.Length - 1)
                {
                    strNewReplaceWith = string.Format("{0}\r\n{1}", strReplacements[i], findText);
                }
                else
                {
                    strNewReplaceWith = strReplacements[i];
                }
                object newReplaceWith = strNewReplaceWith;
                result = wordApp.Selection.Find.Execute(ref findText, ref matchCase, ref matchWholeWord, ref matchWildCards, ref matchSoundsLike, ref matchAllwordForms,
                ref forward, ref wrap, ref format, ref newReplaceWith, ref replace, ref matchKashida, ref matchDiacritics, ref matchAlefHamza,
                ref matchControl);
            }

            return result;
        }

        private void FindAndReplaceLargeContent2(Microsoft.Office.Interop.Word.Application wordApp, object strSearch, object strReplace)
        {
            object missing = System.Reflection.Missing.Value;
            object foward = true;
            Microsoft.Office.Interop.Word.WdFindWrap wrapFind = Microsoft.Office.Interop.Word.WdFindWrap.wdFindStop;
            object wrapExecute = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;

            List<string> subs = new List<string>();
            int counter = 0;
            while (counter <= strSearch.ToString().Length)
            {
                if (strSearch.ToString().Length < counter + 250)
                {
                    subs.Add(strSearch.ToString().Substring(counter, strSearch.ToString().Length - counter));
                }
                else
                {
                    subs.Add(strSearch.ToString().Substring(counter, 250) + "#r#");
                }
                counter += 250;
            }
            wordApp.Selection.Range.Find.ClearFormatting();
            wordApp.Selection.Range.Find.Replacement.ClearFormatting();
            wordApp.Selection.Range.Find.Text = strSearch.ToString();
            wordApp.Selection.Range.Find.Wrap = wrapFind;
            wordApp.Selection.Range.Find.Replacement.Text = subs[0];
            wordApp.Selection.Range.Find.Execute(ref strSearch, ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref strReplace, ref wrapExecute, ref missing, ref missing, ref missing,
                    ref missing);
            wordApp.Selection.Range.Find.Text = "#r#";
            for (int i = 1; i < subs.Count; i++)
            {
                wordApp.Selection.Range.Find.Replacement.Text = subs[i];
                wordApp.Selection.Range.Find.Execute(ref strSearch, ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref strReplace, ref wrapExecute, ref missing, ref missing, ref missing,
                    ref missing);
            }
        }

        public void vaciar_tmp()
        {
            try
            {
                CloseDocument();
                CloseDocument_2();
                open_word = false;
                //EliminarFichero(srt_fichero_temporal);
                //EliminarFichero(srt_ficheroPDF_temporal);

            }
            catch (Exception error) { string que_paso = error.Message; }
        }

        public void CloseDocument()
        {
            try
            {
                object saveChanges = Word.WdSaveOptions.wdSaveChanges;
                wordApp.Quit(ref saveChanges, ref missing, ref missing);
            }
            catch (Exception error) { string que_paso = error.Message; }
        }

        public void CloseDocument_2()
        {
            try
            {
                wordDocOPENXML.Close();
                wordDocOPENXML = null;
            }
            catch (Exception error) { string que_paso = error.Message; }
        }

        //---------------------------------------------------------------------------
        public bool validarExistenciaArchivo(string ruta_archivo)
        {
            bool Respuesta = false;
            try
            {
                string ruta_completa = Path.GetFullPath(ruta_archivo);
                Respuesta = File.Exists(ruta_completa);
            }
            catch (Exception error) { string que_paso = error.Message; Respuesta = false; }
            return Respuesta;
        }

        public bool EliminarFichero(string ruta_archivo)
        {
            bool Respuesta = false;
            try
            {
                if (validarExistenciaArchivo(ruta_archivo))
                {
                    string ruta_completa = Path.GetFullPath(ruta_archivo);
                    File.Delete(ruta_completa);
                    Respuesta = true;
                }
            }
            catch (Exception Error) { string que_paso = Error.Message; Respuesta = false; }

            return Respuesta;
        }


        public static string RutaArchivoTMP = @"plantilla/TMP/";
        //---------------------------------------------------------
        protected string getConcatenarRuta(string fichero = "")
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
        //---------------------------------------------------------------------------







    }





}