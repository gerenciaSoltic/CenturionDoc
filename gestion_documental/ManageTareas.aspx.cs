using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestion_documental.DataAccessLayer;
using gestion_documental.BusinessObjects;

namespace gestion_documental
{
    public partial class ManageTareas : System.Web.UI.Page
    {
        #region Page Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGvrTareas();
            }

        }

        #endregion

        #region Tareas

        protected void FillGvrTareas()
        {
            gvTarea.DataSource = new TareasManagement().GetAllTareas();
            gvTarea.DataBind();

        }

        protected void gvTarea_SelectedIndexChanged(object sender, EventArgs e)
        {
            int TareasId = Convert.ToInt32(gvTarea.SelectedDataKey.Value);
            Tareas Tarea = new TareasManagement().GetTareasById(TareasId);
            
            txtDescripcion.Text = Tarea.descripcion;
            txtOrden.Text = Tarea.orden.ToString(); ;
            btnAddTarea.Text = "Editar";
        }

        protected void gvTarea_DeleteEventHandler(object sender, GridViewDeleteEventArgs e)
        {
            int idTarea = (int)gvTarea.DataKeys[Convert.ToInt32(e.RowIndex)].Value;

            if (!new TareasManagement().DeleteTareas(idTarea))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Ocurrio un problema al eliminar el registro, quizas este siendo usado');", true);
            }

            FillGvrTareas();
        }


        protected void gvShowTarea_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // reference the Delete LinkButton
                LinkButton db = (LinkButton)e.Row.Cells[3].Controls[0];

                db.OnClientClick = "return confirm('Esta seguro que desea eliminar ?');";
            }
        }


        protected void btnClearTarea_Click(object sender, EventArgs e)
        {
           
            txtDescripcion.Text = String.Empty;
            txtOrden.Text = String.Empty;
            btnAddTarea.Text = "Añadir";
        }

        protected void btnAddTarea_Click(object sender, EventArgs e)
        {
            if (btnAddTarea.Text == "Añadir")
            {
                Tareas Tareas = new Tareas();
                
                Tareas.descripcion = txtDescripcion.Text;
                Tareas.orden = Convert.ToInt32(txtOrden.Text);

                new TareasManagement().InsertTareas(Tareas);
                FillGvrTareas();
                btnClearTarea_Click(null, null);
            }
            else
            {
                Tareas Tareas = new Tareas();
                Tareas.idtareas = Convert.ToInt32(gvTarea.SelectedDataKey.Value);
                Tareas.orden = Convert.ToInt32(txtOrden.Text);
                Tareas.descripcion= txtDescripcion.Text;

                new TareasManagement().UpdateTareas(Tareas);
                FillGvrTareas();
                btnClearTarea_Click(null, null);
            }
        }

        #endregion




    }
}