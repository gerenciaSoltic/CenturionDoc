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
    public partial class ManageAtributos : System.Web.UI.Page
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


        #region Atributos

        protected void FillGvrEntes()
        {
            gvEnte.DataSource = new AtributosManagement().GetAllAtributos();
            gvEnte.DataBind();

        }

        protected void gvEnte_SelectedIndexChanged(object sender, EventArgs e)
        {
            int AtributoId = Convert.ToInt32(gvEnte.SelectedDataKey.Value);
            Atributos Atributo = new AtributosManagement().GetAtributosById(AtributoId);
            
            txtAtributo.Text = Atributo.ATRIBUTO;
            btnAddEnte.Text = "Editar";
        }

        protected void gvEnte_DeleteEventHandler(object sender, GridViewDeleteEventArgs e)
        {
            int idAtributo = (int)gvEnte.DataKeys[Convert.ToInt32(e.RowIndex)].Value;

            if (!new AtributosManagement().DeleteAtributos(idAtributo))
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
                LinkButton db = (LinkButton)e.Row.Cells[2].Controls[0];

                db.OnClientClick = "return confirm('Esta seguro que desea eliminar ?');";
            }
        }
        

        protected void btnClearEnte_Click(object sender, EventArgs e)
        {
            
            txtAtributo.Text = String.Empty;
            btnAddEnte.Text = "Añadir";
        }

        protected void btnAddEnte_Click(object sender, EventArgs e)
        {
            if (btnAddEnte.Text == "Añadir")
            {
                Atributos Atributo = new Atributos();
                
                Atributo.ATRIBUTO = txtAtributo.Text;

                new AtributosManagement().InsertAtributos(Atributo);
                FillGvrEntes();
                btnClearEnte_Click(null, null);
            }
            else
            {
                Atributos Atributo = new Atributos();
                Atributo.ID = Convert.ToInt32(gvEnte.SelectedDataKey.Value);
                Atributo.ATRIBUTO = txtAtributo.Text;
                

                new AtributosManagement().UpdateAtributos(Atributo);
                FillGvrEntes();
                btnClearEnte_Click(null, null);
            }
        }

        #endregion

    }
}