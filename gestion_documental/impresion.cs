using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Reporting.WebForms;
using gestion_documental.Utils;


namespace gestion_documental
{
    public class impresion
    {
     public static string direc;
     #region Atributos
 
     public static string nombreimpresora;
     private int m_currentPageIndex;
     private IList<Stream> m_streams;
     
     #endregion
     
     #region Métodos privados
     

       private string Export(LocalReport lr)
       {

        
           string fecha = direc + DateTime.Now.ToString("yyyy-MM-dd");
           System.IO.Directory.CreateDirectory(fecha);
           string mimeType, encoding, extension;

           Warning[] warnings;
           string[] streams;
           var renderedBytes = lr.Render
               (
                   "PDF",
                   @"<DeviceInfo><OutputFormat>PDF</OutputFormat><HumanReadablePDF>False</HumanReadablePDF></DeviceInfo>",
                   out mimeType,
                   out encoding,
                   out extension,
                   out streams,
                   out warnings
               );

           var saveAs = string.Format("{0}.pdf", Path.Combine(fecha, "myfilename"));

           var idx = 0;
           while (File.Exists(saveAs))
           {
               idx++;
               saveAs = string.Format("{0}.{1}.pdf", Path.Combine(fecha, "myfilename"), idx);
           }

           using (var stream = new FileStream(saveAs, FileMode.Create, FileAccess.Write))
           {
               stream.Write(renderedBytes, 0, renderedBytes.Length);
               stream.Close();
           }

           lr.Dispose();
           return saveAs.Replace(direc, "");
    }
     
      #endregion
      
      #region Métodos públicos
       
     public string Imprimir( LocalReport argReporte)
     {
        //
      string imrpimir= Export(argReporte);
      return imrpimir;
      //   m_currentPageIndex = 0;
         //Print();
      }
     
      #endregion
    
      #region Soporte para implementación de interfaces
     
     #region IDisposable
      
     public void Dispose()
      {
         if (m_streams != null)
         {
            foreach (Stream stream in m_streams)
            {  stream.Close(); }
            m_streams = null;
         }
    }
    
     #endregion
   
    #endregion

    
  
  }

        //
    }
