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
    public partial class ManageRadicados : System.Web.UI.Page
    {
        #region Page Event

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGvrRadicados();
            }

        }

        #endregion


        #region Radicados

        protected void FillGvrRadicados()
        {
            gvRadicados.DataSource = new RadicadosManagement().GetAllRadicados();
            gvRadicados.DataBind();

        }

        protected void gvRadicados_SelectedIndexChanged(object sender, EventArgs e)
        {
            int RadicadosId = Convert.ToInt32(gvRadicados.SelectedDataKey.Value);
            Radicados Radicados = new RadicadosManagement().GetRadicadosById(RadicadosId);
            txtConseInt.Text = Radicados.conseInt.ToString();
            txtConseExtSal.Text = Radicados.ConseExtSal.ToString();
            txtConseExtent.Text = Radicados.ConseExtent.ToString();
            txtprefInter.Text = Radicados.prefInter;
            txtPrefExtSal.Text = Radicados.PrefExtSal;
            txtPrefExtEnt.Text = Radicados.PrefExtEnt;
            txtUltimaFecha.Text = Radicados.UltimaFecha.ToString();
            btnAddRadicados.Text = "Edit";
        }

        protected void gvRadicados_DeleteEventHandler(object sender, GridViewDeleteEventArgs e)
        {
            int idRadicado = (int)gvRadicados.DataKeys[Convert.ToInt32(e.RowIndex)].Value;

            if (!new RadicadosManagement().DeleteRadicados(idRadicado))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Ocurrio un problema al eliminar el registro, quizas este siendo usado');", true);
            }

            FillGvrRadicados();
        }


        protected void gvShowRadicados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // reference the Delete LinkButton
                LinkButton db = (LinkButton)e.Row.Cells[8].Controls[0];

                db.OnClientClick = "return confirm('Esta seguro que desea eliminar ?');";
            }
        }

        protected void btnClearRadicados_Click(object sender, EventArgs e)
        {
            txtConseInt.Text = String.Empty;
            txtConseExtSal.Text = String.Empty;
            txtConseExtent.Text = String.Empty;
            txtprefInter.Text = String.Empty;
            txtPrefExtSal.Text = String.Empty;
            txtPrefExtEnt.Text = String.Empty;
            txtUltimaFecha.Text = String.Empty;
            btnAddRadicados.Text = "Añadir";
        }

        protected void btnAddRadicados_Click(object sender, EventArgs e)
        {
            if (btnAddRadicados.Text == "Añadir")
            {
                Radicados Radicados = new Radicados();
                Radicados.conseInt = Convert.ToInt32( txtConseInt.Text );
                Radicados.ConseExtSal = Convert.ToInt32(txtConseExtSal.Text );
                Radicados.ConseExtent = Convert.ToInt32(txtConseExtent.Text );
                Radicados.prefInter = txtprefInter.Text;
                Radicados.PrefExtSal = txtPrefExtSal.Text;
                Radicados.PrefExtEnt = txtPrefExtEnt.Text;
                Radicados.UltimaFecha = Convert.ToDateTime( txtUltimaFecha.Text );

                new RadicadosManagement().InsertRadicados(Radicados);
                FillGvrRadicados();
                btnClearRadicados_Click(null, null);
            }
            else
            {
                Radicados Radicados = new Radicados();
                Radicados.idradicados = Convert.ToInt32(gvRadicados.SelectedDataKey.Value);
                Radicados.conseInt = Convert.ToInt32( txtConseInt.Text );
                Radicados.ConseExtSal = Convert.ToInt32(txtConseExtSal.Text );
                Radicados.ConseExtent = Convert.ToInt32(txtConseExtent.Text );
                Radicados.prefInter = txtprefInter.Text;
                Radicados.PrefExtSal = txtPrefExtSal.Text;
                Radicados.PrefExtEnt = txtPrefExtEnt.Text;
                Radicados.UltimaFecha = Convert.ToDateTime(txtUltimaFecha.Text);

                new RadicadosManagement().UpdateRadicados(Radicados);
                FillGvrRadicados();
                btnClearRadicados_Click(null, null);
            }
        }

        #endregion

    }
}