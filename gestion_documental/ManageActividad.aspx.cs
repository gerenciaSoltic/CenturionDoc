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
    public partial class ManageActividad : System.Web.UI.Page
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
                FillGvrActividad();
            }
        }

        

        protected void FillGvrActividad()
        {
           
            gvActividad.DataSource = new ActividadManagement().GetAllActividadByProceso(Convert.ToInt32(ddlProceso.SelectedValue));

            gvActividad.DataBind();

        }

        

        protected void btnAddActividad_Click(object sender, EventArgs e)
        {
            if (btnAddActividad.Text == "Añadir")
            {

                Actividad t_actividad = new Actividad();
                t_actividad.IDPROCESO = Convert.ToInt32(ddlProceso.SelectedValue);
                t_actividad.ACTIVIDAD = txtNombreActividad.Text;

                new ActividadManagement().InsertActividad(t_actividad);
                FillGvrActividad();
                txtNombreActividad.Text = "";

            }
            else
            {
                Actividad t_actividad = new Actividad();
                t_actividad.ID = Convert.ToInt32(gvActividad.SelectedDataKey.Value);
                t_actividad.IDPROCESO = Convert.ToInt32(ddlProceso.SelectedValue.ToString());
                t_actividad.ACTIVIDAD = txtNombreActividad.Text;
                
                new ActividadManagement().UpdateActividad(t_actividad);
                FillGvrActividad();
                txtNombreActividad.Text = "";
                btnAddActividad.Text = "Añadir";
            }
        }

        protected void btnModelClear_Click(object sender, EventArgs e)
        {
            txtNombreActividad.Text = string.Empty;
            btnAddActividad.Text = "Añadir";

            ddlProceso.SelectedValue = "0";
            
        }

        protected void gvActividad_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idActividad = (int)gvActividad.DataKeys[Convert.ToInt32(e.RowIndex)].Value;

            if (!new ActividadManagement().DeleteActividad(idActividad))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Ocurrio un problema al eliminar el registro, quizas este siendo usado');", true);
            }

            FillGvrActividad();
        }

        protected void gvActividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ActividadId = Convert.ToInt32(gvActividad.SelectedDataKey.Value);
            Actividad t_Actividad = new ActividadManagement().GetActividadById(ActividadId);
            txtNombreActividad.Text = t_Actividad.ACTIVIDAD;


            ddlProceso.SelectedValue = t_Actividad.IDPROCESO + "";

            btnAddActividad.Text = "Editar";
        }

        protected void gvActividad_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // reference the Delete LinkButton
                LinkButton db = (LinkButton)e.Row.Cells[3].Controls[0];

                db.OnClientClick = "return confirm('Esta seguro que desea eliminar ?');";
            }
        }

        protected void ddlProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGvrActividad();
        }
    }
}