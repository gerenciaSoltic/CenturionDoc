using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using gestion_documental;
using gestion_documental.Utils;
using gestion_documental.DataAccessLayer;
using gestion_documental.BusinessObjects;
using GESTIONDOCUMENTAL.Utils;

namespace gestion_documental.reporting
{
    public partial class ViewCertificado : System.Web.UI.Page
    {
        Class1 proce = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            //DataTable _certificado = Session["datacertificado"] as DataTable;
            gvprincipal.DataSource = Session["datacertificado"];
            gvprincipal.DataBind();

            lbnombre.Text = "Que " + Session["nombreimprimir"].ToString() + " Curso el grado " + Session["gradoimprimir"].ToString() + " en la " + Session["jornadaimprimir"].ToString() + " durante el año " + Session["yearimprimir"].ToString() + " en la INSTITUCION "+Session["colegioimprimir"].ToString()+"  del municipio de "+Session["municipioimprimir"].ToString()+" con el logro de los siguientes resultados: ";

            lblibro.Text = "Copia tomada de las planillas de calificaciones remitidas por la Institución educativa y que reposan en el Grupo Administración de Documentos de la Gobernación de Santander, según libro " + Session["libroimprimir"].ToString() + " folio " + Session["folioimprimir"].ToString() + ".";

            lbfecha.Text = "Expedido en Bucaramanga, el " +Session["fechaexpedicion"].ToString()+".";

            // Traemos del webconfig la informacion

            string titulocertificado = proce.recuperatitulocertificado();
            lbtitulo1.Text = titulocertificado;

            string firmacertificado = proce.recuperafirmacertificado();
            Image2.ImageUrl = firmacertificado;

            string firmanombre = proce.recuperafirmanombre();
            Label12.Text = firmanombre;

            string firmacargo = proce.recuperafirmacargo();
            Label13.Text = firmacargo;

            lbproyecto.Text = "Proyectó: "+SessionDocumental.UsuarioInicioSession.NOMBRE;
           

            

        }
        protected void gvprincipal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["datacertificado"] = "";
            Response.Redirect("~/docPendi.aspx");
        }
    }
}