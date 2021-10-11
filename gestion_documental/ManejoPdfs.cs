using System;
using System.Collections.Generic;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.xtra;
using System.IO;
using System.Data;

public class ManejoPdfs
{
    DataTable dtErrores = new DataTable();

    public DataTable Mezclar(string strFileTarget, string[] arrStrFilesSource)
    {
        dtErrores.Clear();

       
        // Crea el PDF de salida
        try
        {
            using (System.IO.FileStream stmFile = new System.IO.FileStream(strFileTarget, System.IO.FileMode.Create))
            {
                Document objDocument = null;
                PdfWriter objWriter = null;

                // Recorre los archivos
                for (int intIndexFile = 0; intIndexFile < arrStrFilesSource.Length; intIndexFile++)
                {
                    PdfReader objReader = new PdfReader(arrStrFilesSource[intIndexFile]);
                    int intNumberOfPages = objReader.NumberOfPages;

                    // La primera vez, inicializa el documento y el escritor
                    if (intIndexFile == 0)
                    { // Asigna el documento y el generador
                        objDocument = new Document(objReader.GetPageSizeWithRotation(1));
                        objWriter = PdfWriter.GetInstance(objDocument, stmFile);
                        // Abre el documento
                        objDocument.Open();
                    }
                    // Añade las páginas
                    for (int intPage = 0; intPage < intNumberOfPages; intPage++)
                    {
                        int intRotation = objReader.GetPageRotation(intPage + 1);
                        PdfImportedPage objPage = objWriter.GetImportedPage(objReader, intPage + 1);

                        // Asigna el tamaño de la página
                        objDocument.SetPageSize(objReader.GetPageSizeWithRotation(intPage + 1));
                        // Crea una nueva página
                        objDocument.NewPage();
                        // Añade la página leída
                        if (intRotation == 90 || intRotation == 270)
                            objWriter.DirectContent.AddTemplate(objPage, 0, -1f, 1f, 0, 0,
                                                                objReader.GetPageSizeWithRotation(intPage + 1).Height);
                        else
                            objWriter.DirectContent.AddTemplate(objPage, 1f, 0, 0, 1f, 0, 0);
                    }
                }
                // Cierra el documento
                if (objDocument != null)
                    objDocument.Close();
                // Cierra el stream del archivo
                stmFile.Close();
            }
            
            
        }

        catch (Exception ex)
        {
            /*
            string errorff;
            errorff = ex.Message;
            errorff = errorff.Replace("'", "");

            DataRow FilaErr = dtErrores.NewRow();

            FilaErr["MOTIVO"] = errorff;

            dtErrores.Rows.Add(FilaErr);
             * */
            
        }
       
        // Devuelve el blanco si se han mezclado los archivos
        return dtErrores;
    }


    public DataTable Dividir(string strFileOrigen, string[] arrStrRangos,string lcNombreArchivo)
    {

        DataColumn MOTIVO = new DataColumn("MOTIVO");
        MOTIVO.DataType = System.Type.GetType("System.String");
        dtErrores.Columns.Add(MOTIVO);

        
        try
        {
            // abrir el documento
            PdfReader objReader = new PdfReader(strFileOrigen);
            int intNumberOfPages = objReader.NumberOfPages;
                                    

            for (int intIndexRango = 0; intIndexRango < arrStrRangos.Length; intIndexRango++)
            {
                // obtener el rango inicial y final de la seccion a partir
                string lcRangoActual = arrStrRangos[intIndexRango];
                string[] lcPaginas = lcRangoActual.Split(new Char[] { '-' });
                int lnPaginaInicio = Int32.Parse(lcPaginas[0].ToString());
                int lnPaginaFinal  = Int32.Parse(lcPaginas[1].ToString()) ;

                int lnNumeroArchivo = intIndexRango + 1;
                int Hasta = strFileOrigen.Length-4;
                String nombreFile = strFileOrigen.Substring(0, Hasta);

                string lcFileSalida = nombreFile + "_" + lcNombreArchivo+"_"+lnNumeroArchivo.ToString()+".pdf";
                //por cada rango creamos el archivo e la lista

                using (System.IO.FileStream stmFile = new System.IO.FileStream(lcFileSalida, System.IO.FileMode.Create))
                {
                    Document objDocument = null;
                    PdfWriter objWriter = null;

                    // Asigna el documento y el generador
                    objDocument = new Document(objReader.GetPageSizeWithRotation(1));
                    objWriter = PdfWriter.GetInstance(objDocument, stmFile);
                    // Abre el documento
                    objDocument.Open();

                    // recorremos el archivo 
                    for (int intPage = 0; intPage < intNumberOfPages; intPage++)
                    {
                        if (intPage + 1 >= lnPaginaInicio && intPage + 1 <= lnPaginaFinal)
                        {
                             int intRotation = objReader.GetPageRotation(intPage + 1);
                            PdfImportedPage objPage = objWriter.GetImportedPage(objReader, intPage + 1);

                            // Asigna el tamaño de la página
                            objDocument.SetPageSize(objReader.GetPageSizeWithRotation(intPage + 1));
                            // Crea una nueva página
                            objDocument.NewPage();
                            // Añade la página leída
                            if (intRotation == 90 || intRotation == 270)
                                objWriter.DirectContent.AddTemplate(objPage, 0, -1f, 1f, 0, 0,
                                                                objReader.GetPageSizeWithRotation(intPage + 1).Height);
                            else
                                objWriter.DirectContent.AddTemplate(objPage, 1f, 0, 0, 1f, 0, 0);

                        }

                    }


                    // Cierra el documento
                     if (objDocument != null)
                        objDocument.Close();
                    // Cierra el stream del archivo
                    stmFile.Close();
                    
                }


            }



        }

        catch (Exception ex)
        {
            string errorff;
            errorff = ex.Message;
            errorff = errorff.Replace("'", "");

            DataRow FilaErr = dtErrores.NewRow();

            FilaErr["MOTIVO"] = errorff;

            dtErrores.Rows.Add(FilaErr);

        }

        // Devuelve en bñanco si se han dividido los archivos
        return dtErrores;
    }

    
}