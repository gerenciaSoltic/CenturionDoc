using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestion_documental.DataAccessLayer;
using gestion_documental.BusinessObjects;
using System.Data;
using gestion_documental.Utils;



namespace gestion_documental
{
    public partial class hojaruta : BasePage
  
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DDlEntes.DataValueField = "idente";
                DDlEntes.DataTextField = "DESCRIPCION";
                DDlEntes.DataSource = new EnteManagement().GetAllEntes();
                DDlEntes.DataBind();
                DDlContenedor.Items.Add("SELECCIONAR");
                DDlContenedor.Items.Add("ARCHIVADOR");
                DDlContenedor.Items.Add("ESTANTE");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            FillTodo();
         }

        protected void BtnAdicionar_Click(object sender, EventArgs e)
        {
            if (DDlContenedor.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe seleccionar un contenedor..');", true);
                return;
            }
            if (BtnAdicionar.Text == "ACTUALIZAR")
            {
                int identeruta = Convert.ToInt32(GridView1.SelectedDataKey.Value.ToString());
                EnteRuta Enteruta = new EnteRuta();
                Enteruta.IDENTERUTA = identeruta;
                Enteruta.IDENTE = Convert.ToInt32(DDlEntes.SelectedValue);
                Enteruta.CONTENEDOR = DDlContenedor.SelectedValue.ToString();
                Enteruta.COMPARTIMIENTO = Convert.ToInt32(TxtCompartimientos.Text);
                Enteruta.NUMERO = TxtNumero.Text;
                new EnteRutaManagement().UpdateEnte(Enteruta);
            }
            else
            {

                EnteRuta EnteRuta = new EnteRuta();
                EnteRuta.IDENTE = Convert.ToInt32(DDlEntes.SelectedValue);
                EnteRuta.CONTENEDOR = DDlContenedor.SelectedValue.ToString();
                EnteRuta.COMPARTIMIENTO = Convert.ToInt32(TxtCompartimientos.Text);
                EnteRuta.NUMERO = TxtNumero.Text;

                new EnteRutaManagement().InsertEnteRuta(EnteRuta);

                
            }
            BtnAdicionar.Text = "Adicionar";
            FillTodo();
            BlanquearTextos();
        }

        private void BlanquearTextos()
        {
            DDlContenedor.SelectedIndex = 0;
            TxtNumero.Text = "";
            TxtCompartimientos.Text = "";
            



        }
        private void FillTodo()
        {
            int idEnte = Convert.ToInt32(DDlEntes.SelectedValue);

            GridView1.DataSource = new EnteRutaManagement().GetEnteRutaByIdEnte(idEnte);
            GridView1.DataBind();


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
                int identeruta = Convert.ToInt32(GridView1.SelectedDataKey.Value.ToString());
                EnteRuta Enteruta = new EnteRutaManagement().GetEnteRutaById(identeruta);
                switch (Enteruta.CONTENEDOR)
                {
                    case "ARCHIVADOR":
                        DDlContenedor.SelectedIndex = 1;
                        break;
                    case "ESTANTE":
                        DDlContenedor.SelectedIndex = 2;
                        break;
                }

                TxtCompartimientos.Text = Enteruta.COMPARTIMIENTO.ToString();
                TxtNumero.Text = Enteruta.NUMERO.ToString();
                BtnAdicionar.Text = "ACTUALIZAR";
            
        }

        protected void BtnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("docpendi.aspx");
        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int identeruta = Convert.ToInt32(GridView1.SelectedDataKey.Value.ToString());
                new EnteRutaManagement().DeleteEnteRuta(identeruta);
                FillTodo();
                BlanquearTextos();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe seleccionar Una fila primero..');", true);

            }
                
              
            
        }

    }
}