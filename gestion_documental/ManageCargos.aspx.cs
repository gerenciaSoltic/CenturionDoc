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
    public partial class ManageCargos : System.Web.UI.Page
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
            gvEnte.DataSource = new CargoManagement().GetAllCargos();
            gvEnte.DataBind();

        }

        protected void gvEnte_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CargoId = Convert.ToInt32(gvEnte.SelectedDataKey.Value);
            Cargo Cargo = new CargoManagement().GetCargoById(CargoId);
            
            txtCargo.Text = Cargo.DESCRIPCION;
            if (Cargo.LIDER == 1)
            {
                ChkLider.Checked = true;
            }
            else
            {
                ChkLider.Checked = false;
            }
            btnAddEnte.Text = "Editar";
        }

        protected void gvEnte_DeleteEventHandler(object sender, GridViewDeleteEventArgs e)
        {
            int idCargo = (int)gvEnte.DataKeys[Convert.ToInt32(e.RowIndex)].Value;

            if (!new CargoManagement().DeleteCargo(idCargo))
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
            
            txtCargo.Text = String.Empty;
            btnAddEnte.Text = "Añadir";
        }

        protected void btnAddEnte_Click(object sender, EventArgs e)
        {
            int INTLIDER = 0;
            if (ChkLider.Checked)
            {
                INTLIDER = 1;
            }
            else
            {
                INTLIDER = 0;
            }
                
            if (btnAddEnte.Text == "Añadir")
            {
                Cargo Cargo = new Cargo();
                
                Cargo.DESCRIPCION = txtCargo.Text;
                Cargo.LIDER = INTLIDER;

                new CargoManagement().InsertCargo(Cargo);
                FillGvrEntes();
                btnClearEnte_Click(null, null);
            }
            else
            {
                Cargo Cargo = new Cargo();
                Cargo.IDCARGO = Convert.ToInt32(gvEnte.SelectedDataKey.Value);
                Cargo.DESCRIPCION = txtCargo.Text;
                Cargo.LIDER = INTLIDER;

                new CargoManagement().UpdateCargo(Cargo);
                FillGvrEntes();
                btnClearEnte_Click(null, null);
            }
        }

        #endregion

    }
}