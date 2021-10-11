using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text.RegularExpressions;
using System.IO;

namespace GESTIONDOCUMENTAL.Utils
{
    public static class Util
    {

        public static DataTable ToDataTable(this List<dynamic> items)
        {
            var data = items.ToArray();
            if (data.Count() == 0) return null;

            var dt = new DataTable();
            foreach (var key in ((IDictionary<string, object>)data[0]).Keys)
            {
                dt.Columns.Add(key);
            }
            foreach (var d in data)
            {
                dt.Rows.Add(((IDictionary<string, object>)d).Values.ToArray());
            }
            return dt;
        }

        public static bool EmailBienEscrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                return Regex.Replace(email, expresion, String.Empty).Length == 0;
            }
            else
            {
                return false;
            }
        }
        public static string PathWeb()
        {
            return System.Web.HttpContext.Current.Request.PhysicalApplicationPath;
        }

        public static string UrlWeb()
        {
            return "http://" + System.Web.HttpContext.Current.Request.Url.Authority + ((System.Web.HttpContext.Current.Request.ApplicationPath.Length > 1) ? System.Web.HttpContext.Current.Request.ApplicationPath : "");
        }
        public static string DocumentosTEMP { get { return "TempFiles"; } }
        public static string PathDocumentosTEMP { get { string path = Path.Combine(Util.PathWeb(), DocumentosTEMP); DirectoryInfo dir = new DirectoryInfo(path); if (!dir.Exists)dir.Create(); return path; } }

        public static string DocumentosDesc { get { return "uploadFiles"; } }
        public static string PathDocumentosDESC { get { string path = Path.Combine(Util.PathWeb(), DocumentosDesc); DirectoryInfo dir = new DirectoryInfo(path); if (!dir.Exists)dir.Create(); return path; } }
        

     }
}