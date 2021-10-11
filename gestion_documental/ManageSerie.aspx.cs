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
    public partial class ManageSerie : System.Web.UI.Page
    {
        #region Page Event

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGvrSeries();
            }

        }

        #endregion


        #region Series

        protected void FillGvrSeries()
        {
            gvSerie.DataSource = new SerieManagement().GetAllSeries();
            gvSerie.DataBind();

        }

        protected void gvSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SerieId = Convert.ToInt32(gvSerie.SelectedDataKey.Value);
            Serie serie = new SerieManagement().GetSerieById(SerieId);
            txtSerie.Text = serie.SERIE;
            Txtcodigo.Text = serie.CODIGO;
            btnAddSerie.Text = "Edit";
        }

        protected void gvSerie_DeleteEventHandler(object sender, GridViewDeleteEventArgs e)
        {
            int idEnte = (int)gvSerie.DataKeys[Convert.ToInt32(e.RowIndex)].Value;

            if (!new SerieManagement().DeleteSerie(idEnte))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Ocurrio un problema al eliminar el registro, quizas este siendo usado');", true);
            }

            FillGvrSeries();
        }


        protected void gvShowSerie_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // reference the Delete LinkButton
                LinkButton db = (LinkButton)e.Row.Cells[3].Controls[0];

                db.OnClientClick = "return confirm('Esta seguro que desea eliminar ?');";
            }
        }

        protected void btnClearSerie_Click(object sender, EventArgs e)
        {
            txtSerie.Text = string.Empty;
            btnAddSerie.Text = "Añadir";
        }

        protected void btnAddSerie_Click(object sender, EventArgs e)
        {
            if (btnAddSerie.Text == "Añadir")
            {
                Serie serie = new Serie();
                serie.SERIE = txtSerie.Text;
                serie.CODIGO = Txtcodigo.Text;

                new SerieManagement().InsertSerie(serie);
                FillGvrSeries();
                btnClearSerie_Click(null, null);
            }
            else
            {
                Serie serie = new Serie();
                serie.ID = Convert.ToInt32(gvSerie.SelectedDataKey.Value);
                serie.SERIE = txtSerie.Text;
                serie.CODIGO = Txtcodigo.Text;
                new SerieManagement().UpdateSerie(serie);
                FillGvrSeries();
                btnClearSerie_Click(null, null);
            }
        }

        #endregion

    }
}