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
    public partial class SystemSettings : System.Web.UI.Page
    {
        #region Page Event

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGvrSeries();
                FillGvrSubSeries();
            }

        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SettingsMenu.aspx", false);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SettingsMenu.aspx", false);
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
            btnAddSerie.Text = "Edit";
        }

        protected void btnClearSerie_Click(object sender, EventArgs e)
        {
            txtSerie.Text = string.Empty;
            btnAddSerie.Text = "Add";
        }

        protected void btnAddSerie_Click(object sender, EventArgs e)
        {
            if (btnAddSerie.Text == "Add")
            {
                Serie serie = new Serie();
                serie.SERIE = txtSerie.Text;

                new SerieManagement().InsertSerie(serie);
                FillGvrSeries();
                btnClearSerie_Click(null, null);
            }
            else
            {
                Serie serie = new Serie();
                serie.ID = Convert.ToInt32(gvSerie.SelectedDataKey.Value);
                serie.SERIE = txtSerie.Text;
                new SerieManagement().UpdateSerie(serie);
                FillGvrSeries();
                btnClearSerie_Click(null, null);
            }
        }

        #endregion





        #region SubSeries

        protected void FillGvrSubSeries()
        {
            gvSubSerie.DataSource = new SubSerieManagement().GetAllSubSeries();

            gvSubSerie.DataBind();

            ddlSerie.DataSource = new SerieManagement().GetAllSeries();
            ddlSerie.DataValueField = "ID";
            ddlSerie.DataTextField = "SERIE";

            ddlSerie.DataBind();

            ddlSerie.Items.Insert(0, new ListItem("Select", "0"));

        }

        protected void gvSubSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SubSerieId = Convert.ToInt32(gvSubSerie.SelectedDataKey.Value);
            SubSerie Subserie = new SubSerieManagement().GetSubSerieById(SubSerieId);
            txtSubSerie.Text = Subserie.SUBSERIE;

            ddlSerie.SelectedValue = Subserie.IDSERIE + "";

            btnAddSubSerie.Text = "Edit";
        }

        protected void btnClearSubSerie_Click(object sender, EventArgs e)
        {
            txtSubSerie.Text = string.Empty;
            btnAddSubSerie.Text = "Add";

            ddlSerie.SelectedValue = "0";
        }

        protected void btnAddSubSerie_Click(object sender, EventArgs e)
        {
            if (btnAddSubSerie.Text == "Add")
            {
                SubSerie Subserie = new SubSerie();
                Subserie.IDSERIE = Convert.ToInt32(ddlSerie.SelectedValue);
                Subserie.SUBSERIE = txtSubSerie.Text;

                new SubSerieManagement().InsertSubSerie(Subserie);
                FillGvrSubSeries();
                btnClearSubSerie_Click(null, null);
            }
            else
            {
                SubSerie Subserie = new SubSerie();
                Subserie.ID = Convert.ToInt32(gvSubSerie.SelectedDataKey.Value);
                Subserie.IDSERIE = Convert.ToInt32(ddlSerie.SelectedValue);
                Subserie.SUBSERIE = txtSubSerie.Text;
                new SubSerieManagement().UpdateSubSerie(Subserie);
                FillGvrSubSeries();
                btnClearSubSerie_Click(null, null);
            }
        }

        #endregion
    }
}