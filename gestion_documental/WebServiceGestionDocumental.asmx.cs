using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;

namespace gestion_documental
{
    /// <summary>
    /// Descripción breve de WebServiceGestionDocumental
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceGestionDocumental : System.Web.Services.WebService
    {

        [WebMethod]
        public string CargaArchivos(byte[] par_archivo, string par_nombre, string par_usuario)
        {
            try
            {
                if (!Directory.Exists(Server.MapPath(par_usuario)))
                { Directory.CreateDirectory(Server.MapPath(par_usuario)); }
                File.WriteAllBytes(Server.MapPath(par_usuario + "/" + par_nombre), par_archivo);
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
