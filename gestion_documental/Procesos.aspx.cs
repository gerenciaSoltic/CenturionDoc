using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestion_documental.Utils;
using gestion_documental.DataAccessLayer;
using gestion_documental.BusinessObjects;
using GESTIONDOCUMENTAL.Utils;
using System.Data;


namespace gestion_documental
{
    public partial class Procesos : BasePage
    {


        Class1 proce = new Class1();

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGvrSeries();
            }

        }

        


        

        protected void FillGvrSeries()
        {
            DataTable DatProceso = new DataTable();
            proce.consultacamposcondicion("procesos", "*", "true",DatProceso);
            gvSerie.DataSource = DatProceso;
            gvSerie.DataBind();

        }

        protected void gvSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SerieId = Convert.ToInt32(gvSerie.SelectedDataKey.Values[0]);

            txtSerie.Text = gvSerie.SelectedDataKey.Values[1].ToString();
            
            btnAddSerie.Text = "Edit";
        }

        protected void gvSerie_DeleteEventHandler(object sender, GridViewDeleteEventArgs e)
        {
            int idEnte = (int)gvSerie.DataKeys[Convert.ToInt32(e.RowIndex)].Value;

            proce.eliminar("proceso", "id=" + idEnte.ToString());
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
            if (txtSerie.Text == "")
            {
                return;
            }

            if (btnAddSerie.Text == "Añadir")
            {

                proce.insertaralgunos("procesos", "proceso", txtSerie.Text);
                FillGvrSeries();
                
            }
            else
            {

                proce.editar("procesos", "proceso = '" + txtSerie.Text + "'", "id = " + gvSerie.SelectedDataKey.Values[0].ToString());
                FillGvrSeries();
                
            }
        }

       
    }
}