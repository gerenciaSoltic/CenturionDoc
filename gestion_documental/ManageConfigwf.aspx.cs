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
    public partial class ManageConfigwf : System.Web.UI.Page
    {
        #region Page Event

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGvrConfigwfs();
            }

        }

        #endregion

        #region Configwf

        protected void FillGvrConfigwfs()
        {
            
            gvConfigwf.DataSource = new ConfigwfManagement().GetAllConfigwf();

            gvConfigwf.DataBind();

            ddlEnte.DataSource = new EnteManagement().GetAllEntes();
            ddlEnte.DataValueField = "IDENTE";
            ddlEnte.DataTextField = "DESCRIPCION";

            ddlEnte.DataBind();

            ddlEnte.Items.Insert(0, new ListItem("Seleccionar", "0"));



            ddlSerie.DataSource = new SerieManagement().GetAllSeries();
            ddlSerie.DataValueField = "ID";
            ddlSerie.DataTextField = "SERIE";

            ddlSerie.DataBind();
            ddlSerie.Items.Insert(0, new ListItem("Seleccionar", "0"));

            ddlSubSerie.Items.Insert(0, new ListItem("Seleccionar", "0"));
            ddlTipologia.Items.Insert(0, new ListItem("Seleccionar", "0"));


            ddlProceso.DataSource = new ProcesoManagement().GetAllProcesos();
            ddlProceso.DataValueField = "ID";
            ddlProceso.DataTextField = "PROCESO";

            ddlProceso.DataBind();
            ddlProceso.Items.Insert(0, new ListItem("Seleccionar", "0"));

            ddlActividad.Items.Insert(0, new ListItem("Seleccionar", "0"));
            int lnidradicado = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO).IDRADICADO;
            ddlEmirecep.DataSource = new EmiRecepManagement().GetAllFuncionarios(lnidradicado);
            ddlEmirecep.DataValueField = "idemirecep";
            ddlEmirecep.DataTextField = "funcionario";
            ddlEmirecep.DataBind();
            ddlProceso.Items.Insert(0, new ListItem("Seleccionar", "0"));

            //ddlExpediente.Items.Insert(0, new ListItem("Seleccionar", "0"));

            /*
            ddlSubSerie.DataSource = new SubSerieManagement().GetAllSubSeries();
            ddlSubSerie.DataValueField = "ID";
            ddlSubSerie.DataTextField = "SUBSERIE";

            ddlSubSerie.DataBind();
            ddlSubSerie.Items.Insert(0, new ListItem("Seleccionar", "0"));


            ddlTipologia.DataSource = new TipologiaManagement().GetAllTipologias();
            ddlTipologia.DataValueField = "ID";
            ddlTipologia.DataTextField = "TIPOLOGIA";

            ddlTipologia.DataBind();
            ddlTipologia.Items.Insert(0, new ListItem("Seleccionar", "0"));*/





            ddlTarea.DataSource = new TareasManagement().GetAllTareas();
            ddlTarea.DataValueField = "idtareas";
            ddlTarea.DataTextField = "descripcion";

            ddlTarea.DataBind();

            ddlTarea.Items.Insert(0, new ListItem("Seleccionar", "0"));
             

        }


        protected void ddlSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSubSerie.DataSource = new SubSerieManagement().GetAllSubSeriesBySerie(Int32.Parse(ddlSerie.SelectedValue));
            ddlSubSerie.DataValueField = "ID";
            ddlSubSerie.DataTextField = "SUBSERIE";
            ddlSubSerie.DataBind();
            ddlSubSerie.Items.Insert(0, new ListItem("Seleccionar", "0"));

            ddlTipologia.Items.Clear();
            //ddlExpediente.Items.Clear();
            ddlTipologia.Items.Insert(0, new ListItem("Seleccionar", "0"));
           // ddlExpediente.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }

        
        protected void ddlSubSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlTipologia.DataSource = new TipologiaManagement().GetAllTipologiasBySubSerie(Int32.Parse(ddlSubSerie.SelectedValue));
            ddlTipologia.DataValueField = "ID";
            ddlTipologia.DataTextField = "TIPOLOGIA";
            ddlTipologia.DataBind();
            ddlTipologia.Items.Insert(0, new ListItem("Seleccionar", "0"));

           // ddlExpediente.Items.Clear();
            //ddlExpediente.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }

      /*  protected void ddlTipologia_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlExpediente.DataSource = new ExpedienteManagement().GetAllExpedienteByTipologia(Int32.Parse(ddlTipologia.SelectedValue));
            ddlExpediente.DataValueField = "ID";
            ddlExpediente.DataTextField = "DESCRIPCION";
            ddlExpediente.DataBind();
            ddlExpediente.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }
        */
        protected void gvConfigwf_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int ConfigwfId = Convert.ToInt32(gvConfigwf.SelectedDataKey.Value);
            Configwf Configwf = new ConfigwfManagement().GetConfigwfById(ConfigwfId);
            txtOrden.Text = Configwf.ORDEN + "";
            txtDias.Text = Configwf.DIAS + "";

            ddlEnte.SelectedValue = Configwf.IDENTE + "";
            ddlEmirecep.SelectedValue = Configwf.idemirecep.ToString();

            ddlSubSerie.Items.Clear();
            ddlTipologia.Items.Clear();
            ddlActividad.Items.Clear();


            try
            {
                ddlSerie.SelectedValue = Configwf.subserie.serie.ID + "";
                ddlProceso.SelectedValue = Configwf.idproceso + "";
            }
            catch (Exception exc1)
            {
                ddlSerie.SelectedValue = "0";

                ddlProceso.SelectedValue = "0";

                ddlSubSerie.Items.Clear();
                ddlSubSerie.Items.Insert(0, new ListItem("Seleccionar", "0"));

                ddlSubSerie.SelectedValue = "0";


                ddlTipologia.Items.Clear();
                ddlTipologia.Items.Insert(0, new ListItem("Seleccionar", "0"));
                ddlTipologia.SelectedValue = "0";

                ddlActividad.Items.Clear();
                ddlActividad.Items.Insert(0, new ListItem("Seleccionar", "0"));
                ddlActividad.SelectedValue = "0";

                /* ddlExpediente.Items.Clear();
                 ddlExpediente.Items.Insert(0, new ListItem("Seleccionar", "0"));
                 ddlExpediente.SelectedValue = "0";
                 */
            }


            try
            {
                ddlSubSerie.DataSource = new SubSerieManagement().GetAllSubSeriesBySerie(Configwf.subserie.serie.ID);
                ddlSubSerie.DataValueField = "ID";
                ddlSubSerie.DataTextField = "SUBSERIE";
                ddlSubSerie.DataBind();
                ddlSubSerie.Items.Insert(0, new ListItem("Seleccionar", "0"));

                ddlSubSerie.SelectedValue = Configwf.idsubserie + "";

                ddlActividad.DataSource = new ActividadManagement().GetAllActividadByProceso(Configwf.idproceso);
                ddlActividad.DataValueField = "ID";
                ddlActividad.DataTextField = "ACTIVIDAD";
                ddlActividad.DataBind();
                ddlActividad.Items.Insert(0, new ListItem("Seleccionar", "0"));

                ddlActividad.SelectedValue = Configwf.idactividad + "";
            }
            catch (Exception exc1) {

                ddlSubSerie.SelectedValue = "0";

                ddlActividad.SelectedValue = "0";

                ddlTipologia.Items.Clear();
                ddlTipologia.Items.Insert(0, new ListItem("Seleccionar", "0"));
                ddlTipologia.SelectedValue = "0";
                /*
                ddlExpediente.Items.Clear();
                ddlExpediente.Items.Insert(0, new ListItem("Seleccionar", "0"));
                ddlExpediente.SelectedValue = "0";
                 */
            }


            try
            {
                ddlTipologia.DataSource = new TipologiaManagement().GetAllTipologiasBySubSerie(Configwf.idsubserie);
                ddlTipologia.DataValueField = "ID";
                ddlTipologia.DataTextField = "TIPOLOGIA";
                ddlTipologia.DataBind();
                ddlTipologia.Items.Insert(0, new ListItem("Seleccionar", "0"));

                ddlTipologia.SelectedValue = Configwf.IDTIPOLOGIA + "";
            }
            catch (Exception exc1) {

                ddlTipologia.Items.Clear();
                ddlTipologia.Items.Insert(0, new ListItem("Seleccionar", "0"));
                ddlTipologia.SelectedValue = "0";

               /* ddlExpediente.Items.Clear();
                ddlExpediente.Items.Insert(0, new ListItem("Seleccionar", "0"));
                ddlExpediente.SelectedValue = "0";
                */
            }


          /*  try
            {
                ddlExpediente.DataSource = new ExpedienteManagement().GetAllExpedienteByTipologia(Configwf.IDTIPOLOGIA);
                ddlExpediente.DataValueField = "id";
                ddlExpediente.DataTextField = "descripcion";
                ddlExpediente.DataBind();
                ddlExpediente.Items.Insert(0, new ListItem("Seleccionar", "0"));

                ddlExpediente.SelectedValue = Configwf.idexpediente + "";
            }
            catch (Exception exc1)
            {
                ddlExpediente.SelectedValue = "0";
            }
            */

            try
            {
                ddlTarea.SelectedValue = Configwf.idtarea + "";
            }
            catch (Exception exc1)
            {
                ddlTarea.SelectedValue = "0";
            }

            

            
            
            
           // ddlTarea.SelectedValue = Configwf.idtarea + "";

            btnAddConfigwf.Text = "Editar";
             
        }

        protected void gvConfigwf_DeleteEventHandler(object sender, GridViewDeleteEventArgs e)
        {
            int idConfigwf = (int)gvConfigwf.DataKeys[Convert.ToInt32(e.RowIndex)].Value;

            if (!new ConfigwfManagement().DeleteConfigwf(idConfigwf))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Ocurrio un problema al eliminar el registro, quizas este siendo usado');", true);
            }

            FillGvrConfigwfs();
        }


        protected void gvShowConfigwf_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // reference the Delete LinkButton
                LinkButton db = (LinkButton)e.Row.Cells[7].Controls[0];

                db.OnClientClick = "return confirm('Esta seguro que desea eliminar ?');";
            }
        }
        

        protected void btnClearConfigwf_Click(object sender, EventArgs e)
        {
            txtOrden.Text = string.Empty;
            txtDias.Text = string.Empty;
            btnAddConfigwf.Text = "Añadir";

            ddlEnte.SelectedValue = "0";
            ddlTipologia.SelectedValue = "0";
            ddlSubSerie.SelectedValue = "0";
            ddlTarea.SelectedValue = "0";
            ddlActividad.SelectedValue = "0";
            ddlProceso.SelectedValue = "0";
        }

        protected void btnAddConfigwf_Click(object sender, EventArgs e)
        {
            
            if (btnAddConfigwf.Text == "Añadir")
            {
                Configwf Configwf = new Configwf();
                Configwf.IDENTE = Convert.ToInt32(ddlEnte.SelectedValue);
                Configwf.IDTIPOLOGIA = Convert.ToInt32(ddlTipologia.SelectedValue);
                Configwf.ORDEN = Convert.ToInt32(txtOrden.Text);
                Configwf.DIAS = Convert.ToInt32(txtDias.Text);
                Configwf.idsubserie = Convert.ToInt32(ddlSubSerie.SelectedValue);
                Configwf.idtarea = Convert.ToInt32(ddlTarea.SelectedValue);
                Configwf.IDSERIE = Convert.ToInt32(ddlSerie.SelectedValue);
                Configwf.idactividad= Convert.ToInt32(ddlActividad.SelectedValue);
                Configwf.idproceso = Convert.ToInt32(ddlProceso.SelectedValue);
                Configwf.idemirecep = Convert.ToInt32(ddlEmirecep.SelectedValue);
                // Configwf.idexpediente = Convert.ToInt32(ddlExpediente.SelectedValue);

                new ConfigwfManagement().InsertConfigwf(Configwf);
                FillGvrConfigwfs();
                btnClearConfigwf_Click(null, null);
            }
            else
            {
                Configwf Configwf = new Configwf();
                Configwf.ID = Convert.ToInt32(gvConfigwf.SelectedDataKey.Value);
                Configwf.IDENTE = Convert.ToInt32(ddlEnte.SelectedValue);
                Configwf.IDTIPOLOGIA = Convert.ToInt32(ddlTipologia.SelectedValue);
                Configwf.ORDEN = Convert.ToInt32(txtOrden.Text);
                Configwf.DIAS = Convert.ToInt32(txtDias.Text);
                Configwf.idsubserie = Convert.ToInt32(ddlSubSerie.SelectedValue);
                Configwf.idtarea = Convert.ToInt32(ddlTarea.SelectedValue);
                Configwf.IDSERIE = Convert.ToInt32(ddlSerie.SelectedValue);
                Configwf.idactividad = Convert.ToInt32(ddlActividad.SelectedValue);
                Configwf.idproceso = Convert.ToInt32(ddlProceso.SelectedValue);
                Configwf.idemirecep = Convert.ToInt32(ddlEmirecep.SelectedValue);
                // Configwf.idexpediente = Convert.ToInt32(ddlExpediente.SelectedValue);

                new ConfigwfManagement().UpdateConfigwf(Configwf);
                FillGvrConfigwfs();
                btnClearConfigwf_Click(null, null);
            }
             
        }


        #endregion

        protected void ddlProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlActividad.DataSource = new ActividadManagement().GetAllActividadByProceso(Int32.Parse(ddlProceso.SelectedValue));
            ddlActividad.DataValueField = "ID";
            ddlActividad.DataTextField = "ACTIVIDAD";
            ddlActividad.DataBind();
            ddlActividad.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }
    }
}