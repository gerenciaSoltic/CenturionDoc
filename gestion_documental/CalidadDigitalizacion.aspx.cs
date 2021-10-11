using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestion_documental.Utils;
using gestion_documental.DataAccessLayer;
using gestion_documental.BusinessObjects;

namespace gestion_documental
{
    public partial class CalidadDigitalizacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillgvCalidad();
            }
        }

        

        protected void gvEnte_SelectedIndexChanged(object sender, EventArgs e)
        {
            string texto = e.ToString();
            object obe = e.GetType();
            string  documento=gvCalidad.SelectedRow.Cells[2].Text;
            string caminoCalidad= gvCalidad.DataKeys[gvCalidad.SelectedRow.DataItemIndex].Values[0].ToString();
            
            string ruta = gvCalidad.DataKeys[gvCalidad.SelectedRow.DataItemIndex].Values[1].ToString();
            
            //string documento=gvCalidad.SelectedRow.Attributes.

            try
            {
                lblmesj.Text = "ingresando";

                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = caminoCalidad;
                proc.StartInfo.Arguments = "\"" + ruta + "\"";
                proc.Start();
                //proc.WaitForExit();
                //proc.Close();
                lblmesj.Text = proc.StartInfo.FileName + " " + proc.StartInfo.Arguments;
            }
            catch 
            {
                lblmesj.Text = "ocurrio un error al leer el programa";
            }
            //System.Diagnostics.Process.Start(@receptor.conficor.SOFTESCANER.Trim());

        }
        protected void FillgvCalidad()
        {
            List<CalidadDigital> documentos = new DocumentosManagement().GetDocumentosbyNotCalidad();
            gvCalidad.DataSource = documentos;
            gvCalidad.DataBind();
        }

       

        protected void cambia_Calidad(object sender, GridViewCommandEventArgs e)
        {
            string cadena = "";
          
        }

        protected void gvCalidad_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string documento = gvCalidad.SelectedRow.Cells[2].Text;
            string ruta = gvCalidad.SelectedValue.ToString();
            string cad = "hola";
        }

        protected void gvCalidad_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string nombre = e.CommandName;
            if (nombre == "Delete")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string idDoc = gvCalidad.DataKeys[index].Values[2].ToString();
                addCalidad(Convert.ToInt32(idDoc));
            }
            
        }
        protected void addCalidad(int idDocumento)
        {
            EmiRecep Receptor = new EmiRecepManagement().GetEmiRecepByCodUsuario(Convert.ToInt32(SessionDocumental.UsuarioInicioSession.CODIGO.ToString()));
            Documentos doc = new DocumentosManagement().GetDocumentosById(idDocumento,Receptor.IDENTE);
            doc.CALIDAD = 1;
            new DocumentosManagement().UpdateDocumentos(doc);
            Response.Redirect("CalidadDigitalizacion.aspx");
        }

    }
}