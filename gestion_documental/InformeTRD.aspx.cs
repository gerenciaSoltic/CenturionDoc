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


namespace gestion_documental.Styles
{
    public partial class InformeTRD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {

                

                
                
                DDLserie.DataSource = new SerieManagement().GetAllSeries();
                DDLserie.DataValueField = "id";
                DDLserie.DataTextField = "serie";
                
                DDLserie.DataBind();
                DDLserie.Items.Insert(0,"Todos");


                DDLsubserie.DataSource = new SubSerieManagement().GetAllSubSeries();
                DDLsubserie.DataValueField = "id";
                DDLsubserie.DataTextField = "subserie";
                DDLsubserie.DataBind();
                DDLsubserie.Items.Insert(0,"Todos");

                seleccionadatos(0,0);

            }


        }

        



        public void seleccionadatos(int lnidserie, int lnidsubserie)
        {
            
            GrdTRD.DataSource = new TipologiaManagement().GetAllTrd(lnidserie, lnidsubserie);
            GrdTRD.DataBind();      
        }

        protected void DDLsubserie_TextChanged(object sender, EventArgs e)
        {
            string lcIdserie = DDLserie.SelectedValue.ToString(); 
            string lcIdsubserie = DDLsubserie.SelectedValue.ToString();

            if (lcIdserie == "Todos" || lcIdserie == "")
            {
                lcIdserie = "0";
            }
            if (lcIdsubserie == "Todos" || lcIdsubserie == "")
            {
                lcIdsubserie = "0";
            }
            seleccionadatos(Convert.ToInt32(lcIdserie), Convert.ToInt32(lcIdsubserie));
        }

        protected void DDLsubserie_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lcIdserie = DDLserie.SelectedValue.ToString();
            string lcIdsubserie = DDLsubserie.SelectedValue.ToString();

            if (lcIdserie == "Todos" || lcIdserie == "")
            {
                lcIdserie = "0";
            }
            if (lcIdsubserie == "Todos" || lcIdsubserie == "")
            {
                lcIdsubserie = "0";
            }
            seleccionadatos(Convert.ToInt32(lcIdserie), Convert.ToInt32(lcIdsubserie));
        }

        protected void DDLserie_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lcIdserie = DDLserie.SelectedValue.ToString();
            string lcIdsubserie = DDLsubserie.SelectedValue.ToString();

            if (lcIdserie == "Todos" || lcIdserie == "")
            {
                lcIdserie = "0";
            }
            if (lcIdsubserie == "Todos" || lcIdsubserie == "")
            {
                lcIdsubserie = "0";
            }
            seleccionadatos(Convert.ToInt32(lcIdserie), Convert.ToInt32(lcIdsubserie));

            DDLsubserie.DataSource = new SubSerieManagement().GetAllSubSeriesBySerie(Convert.ToInt32(lcIdserie));
            DDLsubserie.DataBind();
        }

        protected void GrdTRD_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lcIdserie = DDLserie.SelectedValue.ToString();
            string lcIdsubserie = DDLsubserie.SelectedValue.ToString();

            if (lcIdserie == "Todos" || lcIdserie == "")
            {
                lcIdserie = "0";
            }
            if (lcIdsubserie == "Todos" || lcIdsubserie == "")
            {
                lcIdsubserie = "0";
            }
            seleccionadatos(Convert.ToInt32(lcIdserie), Convert.ToInt32(lcIdsubserie));
        }

        


   
       

        
    }
}