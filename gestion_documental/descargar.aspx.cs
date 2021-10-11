using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace CENTURION.salud
{
    public partial class descargar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["file"] != null)
                {
                    descargar_documento(Server.UrlDecode(Request.QueryString["file"]));
                }
                else
                {
                    cerrar();
                }
            }
        }



        private void descargar_documento(string file_patch)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(file_patch);
                string file_name = Path.GetFileName(file_patch);

                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment;filename=" + file_name);
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.Flush();
                Response.WriteFile(fileInfo.FullName);
                Response.End();
                cerrar();

            }
            catch (Exception Error)
            {
                string que_paso = Error.Message;
            }
        }




        private void cerrar()
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "closePage", "window.close();", true);
        }
    }
}