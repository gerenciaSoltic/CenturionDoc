using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestion_documental.Utils;
using gestion_documental.DataAccessLayer;
using gestion_documental.BusinessObjects;
using MySql.Data.MySqlClient;
using System.Data;


namespace gestion_documental
{
    public partial class ManageWorkFlow : System.Web.UI.Page
    {
        #region Page Event

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGvrWorkFlow();
            }

        }

        #endregion

        #region WorkFlow

        protected void FillGvrWorkFlow()
        {

            gvWorkFlow.DataSource = new WorkFlowManagement().GetAllWorkflow();

            gvWorkFlow.DataBind();

            /*ddlEnte.DataSource = new EnteManagement().GetAllEntes();
            ddlEnte.DataValueField = "IDENTE";
            ddlEnte.DataTextField = "DESCRIPCION";

            ddlEnte.DataBind();

            ddlEnte.Items.Insert(0, new ListItem("Seleccionar", "0"));
            */


           /* ddlSerie.DataSource = new SerieManagement().GetAllSeries();
            ddlSerie.DataValueField = "ID";
            ddlSerie.DataTextField = "SERIE";

            ddlSerie.DataBind();
            ddlSerie.Items.Insert(0, new ListItem("Seleccionar", "0"));

            ddlSubSerie.Items.Insert(0, new ListItem("Seleccionar", "0"));
            ddlTipologia.Items.Insert(0, new ListItem("Seleccionar", "0"));
            ddlExpediente.Items.Insert(0, new ListItem("Seleccionar", "0"));
            */



            /*
            ddlSubSerie.DataSource = new SubSerieManagement().GetAllSubSeries();
            ddlSubSerie.DataValueField = "ID";
            ddlSubSerie.DataTextField = "SUBSERIE";

            ddlSubSerie.DataBind();
            ddlSubSerie.Items.Insert(0, new ListItem("Seleccionar", "0"));


            ddlTipologia.DataSource = new TipologiaManagement().GetAllTipologias();
            ddlTipologia.DataValueField = "ID";
            ddlTipologia.DataTextField = "TIPOLOGIA";

            ddlTipologia.DataBind();
            ddlTipologia.Items.Insert(0, new ListItem("Seleccionar", "0"));*/





           /*ddlTarea.DataSource = new TareasManagement().GetAllTareas();
            ddlTarea.DataValueField = "idtareas";
            ddlTarea.DataTextField = "descripcion";

            ddlTarea.DataBind();

            ddlTarea.Items.Insert(0, new ListItem("Seleccionar", "0"));
            */


        }

        protected void gvWorkFlow_DeleteEventHandler(object sender, GridViewDeleteEventArgs e)
        {
            int idWorkFlow = (int)gvWorkFlow.DataKeys[Convert.ToInt32(e.RowIndex)].Value;

            if (!new WorkFlowManagement().DeleteWorkflow(idWorkFlow))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Ocurrio un problema al eliminar el registro, quizas este siendo usado');", true);
            }

            FillGvrWorkFlow();
        }


        protected void gvShowWorkFlow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // reference the Delete LinkButton
                LinkButton db = (LinkButton)e.Row.Cells[11].Controls[0];

                db.OnClientClick = "return confirm('Esta seguro que desea eliminar ?');";
            }
        }

        #endregion
    }
}