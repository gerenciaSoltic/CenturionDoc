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
    public partial class ManageProcesos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGvrProceso();
            }
        }

        #region Series

        protected void FillGvrProceso()
        {
            gvProceso.DataSource = new ProcesoManagement().GetAllProcesos();
            gvProceso.DataBind();

        }

        //protected void gvSerie_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int ProcesoId = Convert.ToInt32(gvProceso.SelectedDataKey.Value);
        //    proceso ProcesosTrabajar = new ProcesoManagement().GetProcesosById(ProcesoId);
        //    TxtNombreProceso.Text = ProcesosTrabajar.PROCESO;
        //    btnAddProceso.Text = "Edit";
        //}

        //protected void gvSerie_DeleteEventHandler(object sender, GridViewDeleteEventArgs e)
        //{
        //    int idEnte = (int)gvProceso.DataKeys[Convert.ToInt32(e.RowIndex)].Value;

        //    if (!new ProcesoManagement().DeleteProceso(idEnte))
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Ocurrio un problema al eliminar el registro, quizas este siendo usado');", true);
        //    }

        //    FillGvrProceso();
        //}


        //protected void gvShowSerie_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        // reference the Delete LinkButton
        //        LinkButton db = (LinkButton)e.Row.Cells[3].Controls[0];

        //        db.OnClientClick = "return confirm('Esta seguro que desea eliminar ?');";
        //    }
        //}

        //protected void btnClearSerie_Click(object sender, EventArgs e)
        //{
        //    TxtNombreProceso.Text = string.Empty;
        //    btnAddProceso.Text = "Añadir";
        //}

        //protected void btnAddSerie_Click(object sender, EventArgs e)
        //{
        //    if (btnAddProceso.Text == "Añadir")
        //    {
        //        proceso t_procesos = new proceso();
        //        t_procesos.PROCESO = TxtNombreProceso.Text;

        //        new ProcesoManagement().InsertProceso(t_procesos);
        //        FillGvrProceso();
        //        btnClearSerie_Click(null, null);
        //    }
        //    else
        //    {
        //        proceso t_proceso = new proceso();
        //        t_proceso.ID = Convert.ToInt32(gvProceso.SelectedDataKey.Value);
        //        t_proceso.PROCESO = TxtNombreProceso.Text;
        //        new ProcesoManagement().UpdateProceso(t_proceso);
        //        FillGvrProceso();
        //        btnClearSerie_Click(null, null);
        //    }
        //}

        #endregion

        protected void btnAddProceso_Click(object sender, EventArgs e)
        {
            if (btnAddProceso.Text == "Añadir")
            {
                proceso t_procesos = new proceso();
                t_procesos.PROCESO = TxtNombreProceso.Text;

                new ProcesoManagement().InsertProceso(t_procesos);
                FillGvrProceso();
                btnModelClear_Click(null, null);
            }
            else
            {
                proceso t_proceso = new proceso();
                t_proceso.ID = Convert.ToInt32(gvProceso.SelectedDataKey.Value);
                t_proceso.PROCESO = TxtNombreProceso.Text;
                new ProcesoManagement().UpdateProceso(t_proceso);
                FillGvrProceso();
                btnModelClear_Click(null, null);
            }
        }

        protected void btnModelClear_Click(object sender, EventArgs e)
        {
            TxtNombreProceso.Text = string.Empty;
            btnAddProceso.Text = "Añadir";
        }

        protected void gvProceso_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idEnte = (int)gvProceso.DataKeys[Convert.ToInt32(e.RowIndex)].Value;

            if (!new ProcesoManagement().DeleteProceso(idEnte))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Ocurrio un problema al eliminar el registro, quizas este siendo usado');", true);
            }

            FillGvrProceso();
        }

        protected void gvProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ProcesoId = Convert.ToInt32(gvProceso.SelectedDataKey.Value);
            proceso ProcesosTrabajar = new ProcesoManagement().GetProcesosById(ProcesoId);
            TxtNombreProceso.Text = ProcesosTrabajar.PROCESO;
            btnAddProceso.Text = "Edit";
        }

        protected void gvProceso_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // reference the Delete LinkButton
                LinkButton db = (LinkButton)e.Row.Cells[2].Controls[0];

                db.OnClientClick = "return confirm('Esta seguro que desea eliminar ?');";
            }
        }
    }
}