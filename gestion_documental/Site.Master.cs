using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GESTIONDOCUMENTAL;

namespace gestion_documental
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        Class1 proce = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            string lcBanner = proce.recuperabanner();
            IdBanner.ImageUrl = lcBanner;
            if ( Session["UsuarioInicioSession"] == null )
            {
                String s = Request.QueryString["user"].ToString();
                if (s == "")
                {
                    Response.Redirect("Default.aspx");
                }
                
            }

        }
    }
}
