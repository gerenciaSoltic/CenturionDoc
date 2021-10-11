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
    public partial class ManageEnte : System.Web.UI.Page
    {
        #region Page Event

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGvrEntes();
            }

        }

        #endregion


        #region Entes

        protected void FillGvrEntes()
        {
            gvEnte.DataSource = new EnteManagement().GetAllEntes();
            gvEnte.DataBind();

        }

        protected void gvEnte_SelectedIndexChanged(object sender, EventArgs e)
        {
            int EnteId = Convert.ToInt32(gvEnte.SelectedDataKey.Value);
            Ente Ente = new EnteManagement().GetEnteById(EnteId);
            txtCodigo.Text = Ente.CODIGO;
            txtDescripcion.Text = Ente.DESCRIPCION;
            btnAddEnte.Text = "Editar";
        }

        protected void gvEnte_DeleteEventHandler(object sender, GridViewDeleteEventArgs e)
        {
            int idEnte = (int)gvEnte.DataKeys[Convert.ToInt32(e.RowIndex)].Value;

            if (!new EnteManagement().DeleteEnte(idEnte))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Ocurrio un problema al eliminar el registro, quizas este siendo usado');", true);
            }

            FillGvrEntes();
        }


        protected void gvShowEnte_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // reference the Delete LinkButton
                LinkButton db = (LinkButton)e.Row.Cells[3].Controls[0];

                db.OnClientClick = "return confirm('Esta seguro que desea eliminar ?');";
            }
        }
        

        protected void btnClearEnte_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            btnAddEnte.Text = "Añadir";
        }

        protected void btnAddEnte_Click(object sender, EventArgs e)
        {
            if (btnAddEnte.Text == "Añadir")
            {
                Ente Ente = new Ente();
                Ente.CODIGO = txtCodigo.Text;
                Ente.DESCRIPCION = txtDescripcion.Text;

                new EnteManagement().InsertEnte(Ente);
                FillGvrEntes();
                btnClearEnte_Click(null, null);
            }
            else
            {
                Ente Ente = new Ente();
                Ente.IDENTE = Convert.ToInt32(gvEnte.SelectedDataKey.Value);
                Ente.CODIGO = txtCodigo.Text;
                Ente.DESCRIPCION = txtDescripcion.Text;

                new EnteManagement().UpdateEnte(Ente);
                FillGvrEntes();
                btnClearEnte_Click(null, null);
            }
        }

        #endregion

    }
}