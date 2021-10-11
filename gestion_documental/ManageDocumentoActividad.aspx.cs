using gestion_documental.BusinessObjects;
using gestion_documental.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gestion_documental
{
    public partial class ManageDocumentoActividad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                ddlProceso.DataSource = new ProcesoManagement().GetAllProcesos();
                ddlProceso.DataValueField = "ID";
                ddlProceso.DataTextField = "PROCESO";

                ddlProceso.DataBind();

                ddlProceso.Items.Insert(0, new ListItem("Seleccionar", "0"));

                ddlActividad.Items.Insert(0, new ListItem("Seleccionar", "0"));

                FillGvrDocumentoActividad(0);
            }
        }

        protected void FillGvrDocumentoActividad(int IdActividad)
        {
            gvDocumentoActividad.DataSource = new DocumentoActividadManagement().GetAllDocumentoByActividad(IdActividad);

            gvDocumentoActividad.DataBind();
        }

        protected void ddlProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlActividad.DataSource = new ActividadManagement().GetAllActividadByProceso(Convert.ToInt32(ddlProceso.SelectedValue));
            ddlActividad.DataValueField = "ID";
            ddlActividad.DataTextField = "ACTIVIDAD";

            ddlActividad.DataBind();

            ddlActividad.Items.Insert(0, new ListItem("Seleccionar", "0"));

            FillGvrDocumentoActividad(0);

        }

        protected void ddlActividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGvrDocumentoActividad(Convert.ToInt32(ddlActividad.SelectedValue));
        }

        protected void btnAddDocumentoActividad_Click(object sender, EventArgs e)
        {
            if (btnAddDocumentoActividad.Text == "Añadir")
            {

                DocumentoActividad t_Documentoactividad = new DocumentoActividad();
                t_Documentoactividad.IDACTIVIDAD = Convert.ToInt32(ddlActividad.SelectedValue);
                t_Documentoactividad.NOMBREDOCUMENTO = txtNombreDocumentoActividad.Text;

                new DocumentoActividadManagement().InsertDocumentoActividad(t_Documentoactividad);
                FillGvrDocumentoActividad(Convert.ToInt32(ddlActividad.SelectedValue));
                txtNombreDocumentoActividad.Text = "";
            }
            else
            {
                DocumentoActividad t_Documentoactividad = new DocumentoActividad();
                t_Documentoactividad.ID = Convert.ToInt32(gvDocumentoActividad.SelectedDataKey.Value);
                t_Documentoactividad.IDACTIVIDAD = Convert.ToInt32(ddlActividad.SelectedValue.ToString());
                t_Documentoactividad.NOMBREDOCUMENTO = txtNombreDocumentoActividad.Text;

                new DocumentoActividadManagement().UpdateDocumentoActividad(t_Documentoactividad);
                FillGvrDocumentoActividad(Convert.ToInt32(ddlActividad.SelectedValue.ToString()));
                txtNombreDocumentoActividad.Text = "";
                btnAddDocumentoActividad.Text = "Añadir";
            }
        }

        protected void btnModelClear_Click1(object sender, EventArgs e)
        {
            txtNombreDocumentoActividad.Text = string.Empty;
            btnAddDocumentoActividad.Text = "Añadir";
            ddlActividad.SelectedValue = "0";
            ddlProceso.SelectedValue = "0";
        }

        protected void gvDocumentoActividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ActividadId = Convert.ToInt32(gvDocumentoActividad.SelectedDataKey.Value);
            DocumentoActividad t_DocumentoActividad = new DocumentoActividadManagement().GetDocumentoActividadById(ActividadId);
            txtNombreDocumentoActividad.Text = t_DocumentoActividad.NOMBREDOCUMENTO;


            ddlActividad.SelectedValue = t_DocumentoActividad.IDACTIVIDAD + "";

            btnAddDocumentoActividad.Text = "Editar";
        }

        protected void gvDocumentoActividad_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // reference the Delete LinkButton
                LinkButton db = (LinkButton)e.Row.Cells[4].Controls[0];

                db.OnClientClick = "return confirm('Esta seguro que desea eliminar ?');";
            }
        }

        protected void gvDocumentoActividad_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idDocumentoActividad = (int)gvDocumentoActividad.DataKeys[Convert.ToInt32(e.RowIndex)].Value;

            if (!new DocumentoActividadManagement().DeleteDocumentoActividad(idDocumentoActividad))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Ocurrio un problema al eliminar el registro, quizas este siendo usado');", true);
            }

            FillGvrDocumentoActividad(Convert.ToInt32(ddlActividad.SelectedValue.ToString()));
        }
    }
}