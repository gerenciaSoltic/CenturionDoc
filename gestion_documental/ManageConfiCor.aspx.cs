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
    public partial class ManageConfiCor : System.Web.UI.Page
    {
        #region Page Event

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGvrConfiCor();
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




        #region ConfiCors

        protected void FillGvrConfiCor()
        {
            gvConfiCor.DataSource = new ConfiCorManagement().GetAllConficor();

            gvConfiCor.DataBind();

        }

        protected void gvConfiCor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ConfiCorId = Convert.ToInt32(gvConfiCor.SelectedDataKey.Value);
            ConfiCor ConfiCor = new ConfiCorManagement().GetConfiCorById(ConfiCorId);

            txtEmail.Text = ConfiCor.EMAIL;
            txtContrasena.Text = ConfiCor.CONTRASENA;
            txtServPopEntrante.Text = ConfiCor.SERVPOPENTRANTE;
            txtServPopSaliente.Text = ConfiCor.SERVPOPSALIENTE;
            txtCaminoDescarga.Text = ConfiCor.CAMINODESCARGA;
            txtCaminosEscaner.Text = ConfiCor.CAMINOSCANNER;
            TxtSoftEscaner.Text = ConfiCor.SOFTESCANER;
            TxtCarpetaTemporal.Text = ConfiCor.CARPETATEMP;
            TxtFechaArranque.Text = ConfiCor.FECHAARRANQUE.ToString();
            

            btnAddConfiCor.Text = "Edit";
        }

        protected void gvConfiCor_DeleteEventHandler(object sender, GridViewDeleteEventArgs e)
        {
            int idConfiCor = (int)gvConfiCor.DataKeys[Convert.ToInt32(e.RowIndex)].Value;

            if (!new ConfiCorManagement().DeleteConfiCor(idConfiCor))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Ocurrio un problema al eliminar el registro, quizas este siendo usado');", true);
            }

            FillGvrConfiCor();
        }

        protected void gvShowConfiCor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // reference the Delete LinkButton
                LinkButton db = (LinkButton)e.Row.Cells[7].Controls[0];

                db.OnClientClick = "return confirm('Esta seguro que desea eliminar ?');";
            }
        }

        protected void btnClearConfiCor_Click(object sender, EventArgs e)
        {
            txtEmail.Text = String.Empty;
            txtContrasena.Text = String.Empty;
            txtServPopEntrante.Text = String.Empty;
            txtServPopSaliente.Text = String.Empty;
            txtCaminoDescarga.Text = String.Empty;
            txtCaminosEscaner.Text = String.Empty;
            TxtSoftEscaner.Text = String.Empty;
            TxtCarpetaTemporal.Text = String.Empty;
            TxtFechaArranque.Text = String.Empty;
            btnAddConfiCor.Text = "Añadir";
        }

        protected void btnAddConfiCor_Click(object sender, EventArgs e)
        {
            if (btnAddConfiCor.Text == "Añadir")
            {
                ConfiCor ConfiCor = new ConfiCor();

                ConfiCor.EMAIL = txtEmail.Text;
                ConfiCor.CONTRASENA = txtContrasena.Text;
                ConfiCor.SERVPOPENTRANTE = txtServPopEntrante.Text;
                ConfiCor.SERVPOPSALIENTE = txtServPopSaliente.Text;
                ConfiCor.CAMINODESCARGA = txtCaminoDescarga.Text;
                ConfiCor.CAMINOSCANNER = txtCaminosEscaner.Text;
                ConfiCor.SOFTESCANER = TxtSoftEscaner.Text;
                ConfiCor.CARPETATEMP = TxtCarpetaTemporal.Text;

                new ConfiCorManagement().InsertConfiCor(ConfiCor);
                FillGvrConfiCor();
                btnClearConfiCor_Click(null, null);
            }
            else
            {
                ConfiCor ConfiCor = new ConfiCor();
                
                ConfiCor.ID = Convert.ToInt32(gvConfiCor.SelectedDataKey.Value);
                ConfiCor.EMAIL = txtEmail.Text;
                ConfiCor.CONTRASENA = txtContrasena.Text;
                ConfiCor.SERVPOPENTRANTE = txtServPopEntrante.Text;
                ConfiCor.SERVPOPSALIENTE = txtServPopSaliente.Text;
                ConfiCor.CAMINODESCARGA = txtCaminoDescarga.Text;
                ConfiCor.CAMINOSCANNER = txtCaminosEscaner.Text;
                ConfiCor.SOFTESCANER = TxtSoftEscaner.Text;
                ConfiCor.CARPETATEMP = TxtCarpetaTemporal.Text;
                ConfiCor.FECHAARRANQUE = Convert.ToDateTime(TxtFechaArranque.Text);
                new ConfiCorManagement().UpdateConfiCor(ConfiCor);

                FillGvrConfiCor();
                btnClearConfiCor_Click(null, null);
            }
        }

        #endregion

       
    }
}