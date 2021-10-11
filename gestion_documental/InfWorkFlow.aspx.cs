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
    public partial class InfWorkFlow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {


                DDLEnte.DataSource = new EnteManagement().GetAllEntes();
                DDLEnte.DataValueField = "idente";
                DDLEnte.DataTextField = "Descripcion";
                DDLEnte.DataBind();
                DDLEnte.Items.Insert(0, "Todos");


                DDLserie.DataSource = new SerieManagement().GetAllSeries();
                DDLserie.DataValueField = "id";
                DDLserie.DataTextField = "serie";

                DDLserie.DataBind();
                DDLserie.Items.Insert(0, "Todos");


                DDLsubserie.DataSource = new SubSerieManagement().GetAllSubSeries();
                DDLsubserie.DataValueField = "id";
                DDLsubserie.DataTextField = "subserie";
                DDLsubserie.DataBind();
                DDLsubserie.Items.Insert(0, "Todos");

                seleccionadatos(0, 0, 0);

            }


        }





        public void seleccionadatos(int lnidente,int lnidserie, int lnidsubserie)
        {

            GrdTRD.DataSource = new TipologiaManagement().GetAllWorkFlow(lnidente, lnidserie, lnidsubserie);
            GrdTRD.DataBind();
        }

        protected void DDLsubserie_TextChanged(object sender, EventArgs e)
        {
            string lcIdEnte = DDLEnte.SelectedValue.ToString();
            string lcIdserie = DDLserie.SelectedValue.ToString();
            string lcIdsubserie = DDLsubserie.SelectedValue.ToString();


            if (lcIdEnte == "Todos" || lcIdEnte == "")
            {
                lcIdEnte = "0";
            }

            if (lcIdserie == "Todos" || lcIdserie == "")
            {
                lcIdserie = "0";
            }
            if (lcIdsubserie == "Todos" || lcIdsubserie == "")
            {
                lcIdsubserie = "0";
            }


            seleccionadatos(Convert.ToInt32(lcIdEnte),Convert.ToInt32(lcIdserie), Convert.ToInt32(lcIdsubserie));
        }

        protected void DDLsubserie_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lcIdEnte = DDLEnte.SelectedValue.ToString();
            string lcIdserie = DDLserie.SelectedValue.ToString();
            string lcIdsubserie = DDLsubserie.SelectedValue.ToString();


            if (lcIdEnte == "Todos" || lcIdEnte == "")
            {
                lcIdEnte = "0";
            }
            
            if (lcIdserie == "Todos" || lcIdserie == "")
            {
                lcIdserie = "0";
            }
            if (lcIdsubserie == "Todos" || lcIdsubserie == "")
            {
                lcIdsubserie = "0";
            }
            seleccionadatos(Convert.ToInt32(lcIdEnte), Convert.ToInt32(lcIdserie), Convert.ToInt32(lcIdsubserie));
        }

        protected void DDLserie_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lcIdEnte = DDLEnte.SelectedValue.ToString();
            string lcIdserie = DDLserie.SelectedValue.ToString();
            string lcIdsubserie = DDLsubserie.SelectedValue.ToString();

            if (lcIdEnte == "Todos" || lcIdEnte == "")
            {
                lcIdEnte = "0";
            }
            
            if (lcIdserie == "Todos" || lcIdserie == "")
            {
                lcIdserie = "0";
            }
            if (lcIdsubserie == "Todos" || lcIdsubserie == "")
            {
                lcIdsubserie = "0";
            }


            seleccionadatos(Convert.ToInt32(lcIdEnte), Convert.ToInt32(lcIdserie), Convert.ToInt32(lcIdsubserie));

            DDLsubserie.DataSource = new SubSerieManagement().GetAllSubSeriesBySerie(Convert.ToInt32(lcIdserie));
            DDLsubserie.DataBind();
        }

        protected void GrdTRD_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void DDLEnte_SelectedIndexChanged(object sender, EventArgs e)
        {

            string lcIdEnte = DDLEnte.SelectedValue.ToString();
            string lcIdserie = DDLserie.SelectedValue.ToString();
            string lcIdsubserie = DDLsubserie.SelectedValue.ToString();

            if (lcIdEnte == "Todos" || lcIdEnte == "")
            {
                lcIdEnte = "0";
            }

            if (lcIdserie == "Todos" || lcIdserie == "")
            {
                lcIdserie = "0";
            }
            if (lcIdsubserie == "Todos" || lcIdsubserie == "")
            {
                lcIdsubserie = "0";
            }


            seleccionadatos(Convert.ToInt32(lcIdEnte), Convert.ToInt32(lcIdserie), Convert.ToInt32(lcIdsubserie));


            DDLserie.DataSource = new ConfigwfManagement().GetConfigwfByIdente(Convert.ToInt32(lcIdEnte));
            DDLserie.DataValueField = "idserie";
            DDLserie.DataTextField = "serie";
            DDLserie.DataBind();


        }
    }
}