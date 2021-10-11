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
    public partial class ManageSitioArchivo : System.Web.UI.Page
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


        #region SitioArchivo

        protected void FillGvrSeries()
        {
            gvSerie.DataSource = new SitioArchivoManagement().GetAllSitioArchivo();
            gvSerie.DataBind();

        }

        protected void gvSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SitioArchivoId = Convert.ToInt32(gvSerie.SelectedDataKey.Value);
            SitioArchivo SitioArchivo = new SitioArchivoManagement().GetSitioArchivoById(SitioArchivoId);
            txtDescripcion.Text = SitioArchivo.DESCRIPCION;
            
            btnAddSerie.Text = "Edit";
        }

        protected void gvSerie_DeleteEventHandler(object sender, GridViewDeleteEventArgs e)
        {
            int idEnte = (int)gvSerie.DataKeys[Convert.ToInt32(e.RowIndex)].Value;

            if (!new SitioArchivoManagement().DeleteSitioArchivo(idEnte))
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
                LinkButton db = (LinkButton)e.Row.Cells[2].Controls[0];

                db.OnClientClick = "return confirm('Esta seguro que desea eliminar ?');";
            }
        }

        protected void btnClearSerie_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = string.Empty;
            btnAddSerie.Text = "Añadir";
        }

        protected void btnAddSerie_Click(object sender, EventArgs e)
        {
            if (btnAddSerie.Text == "Añadir")
            {
                SitioArchivo SitioArchivo = new SitioArchivo();
                SitioArchivo.DESCRIPCION = txtDescripcion.Text;
                

                new SitioArchivoManagement().InsertSitioArchivo(SitioArchivo);
                FillGvrSeries();
                btnClearSerie_Click(null, null);
            }
            else
            {
                SitioArchivo SitioArchivo = new SitioArchivo();
                SitioArchivo.IDSITIOARCHIVO = Convert.ToInt32(gvSerie.SelectedDataKey.Value);
                SitioArchivo.DESCRIPCION = txtDescripcion.Text;
                
                new SitioArchivoManagement().UpdateSitioArchivo(SitioArchivo);
                FillGvrSeries();
                btnClearSerie_Click(null, null);
            }
        }

        #endregion

    }
}