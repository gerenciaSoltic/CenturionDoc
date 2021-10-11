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
    public partial class ManageTipologia : System.Web.UI.Page
    {
        #region Page Event

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGvrTipologias();
            }

        }

        #endregion

        #region Tipologias

        protected void FillGvrTipologias()
        {
            gvTipologia.DataSource = new TipologiaManagement().GetAllTipologias();

            gvTipologia.DataBind();


          
        }

        protected void gvTipologia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int TipologiaId = Convert.ToInt32(gvTipologia.SelectedDataKey.Value);
            Tipologia Tipologia = new TipologiaManagement().GetTipologiaById(TipologiaId);
            txtTipologia.Text = Tipologia.TIPOLOGIA;

            //ddlSerie.SelectedValue = SubSerie.IDSERIE + "";
           // ddlSerie.SelectedValue = Tipologia.subserie.serie.ID + "";
           // ddlSubSerie.SelectedValue = Tipologia.IDSUBSERIE + "";

            btnAddTipologia.Text = "Editar";
        }


        protected void gvTipologia_DeleteEventHandler(object sender, GridViewDeleteEventArgs e)
        {
            int idTipologia = (int)gvTipologia.DataKeys[Convert.ToInt32(e.RowIndex)].Value;

            if (!new TipologiaManagement().DeleteTipologia(idTipologia))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Ocurrio un problema al eliminar el registro, quizas este siendo usado');", true);
            }

            FillGvrTipologias();
        }


        protected void gvShowTipologia_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // reference the Delete LinkButton
                LinkButton db = (LinkButton)e.Row.Cells[2].Controls[0];

                db.OnClientClick = "return confirm('Esta seguro que desea eliminar ?');";
            }
        }

        protected void btnClearTipologia_Click(object sender, EventArgs e)
        {
            txtTipologia.Text = string.Empty;
            btnAddTipologia.Text = "Añadir";

            //ddlSubSerie.SelectedValue = "0";
        }

        protected void btnAddTipologia_Click(object sender, EventArgs e)
        {
            if (btnAddTipologia.Text == "Añadir")
            {
                Tipologia Tipologia = new Tipologia();
                //   Tipologia.subserie.serie.ID = Convert.ToInt32(ddlSerie.SelectedValue);
                //Tipologia.IDSUBSERIE = Convert.ToInt32(ddlSubSerie.SelectedValue);
                Tipologia.TIPOLOGIA = txtTipologia.Text;

                new TipologiaManagement().InsertTipologia(Tipologia);
                FillGvrTipologias();
                btnClearTipologia_Click(null, null);
            }
            else
            {
                Tipologia Tipologia = new Tipologia();
                Tipologia.ID = Convert.ToInt32(gvTipologia.SelectedDataKey.Value);
                //Tipologia.IDSUBSERIE = Convert.ToInt32(ddlSubSerie.SelectedValue);
                Tipologia.TIPOLOGIA = txtTipologia.Text;
                new TipologiaManagement().UpdateTipologia(Tipologia);
                FillGvrTipologias();
                btnClearTipologia_Click(null, null);
            }
        }

        

      
        #endregion

    }
}