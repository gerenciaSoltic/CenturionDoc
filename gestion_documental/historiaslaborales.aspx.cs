using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestion_documental.Utils;

namespace gestion_documental
{
    public partial class historiaslaborales : System.Web.UI.Page
    {
        BasePage nuevabase = new BasePage();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UsuarioInicioSession"] == null)
            {
                Response.Redirect("Default.aspx");

            }
            if (!IsPostBack)
            {
                string lcInforme = Request.QueryString["informe"];
                Session.Add("lcInforme", lcInforme);
                if (lcInforme == "RepoHistorialaboral.rdlc")
                {
                    Label1.Text = "HISTORIAS LABORALES";
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            DataAccessLayer.DocumentosManagement.Fdesde = Convert.ToDateTime(txtFechaDesde.Text);
            DataAccessLayer.DocumentosManagement.Fhasta = Convert.ToDateTime(TxtFechaHasta.Text);
            Response.Redirect("muestraReporte.aspx?informe=" + Session["lcInforme"]);
        }
    }
}