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
    public partial class ManageDocumentos : System.Web.UI.Page
    {
        #region Page Event

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGvrDocumentos();
            }

        }

        #endregion
        #region Documentos

        protected void FillGvrDocumentos()
        {

            gvDocumentos.DataSource = new DocumentosManagement().GetAllDocumentos();

            gvDocumentos.DataBind();

            
            ddlSerie.DataSource = new SerieManagement().GetAllSeries();
            ddlSerie.DataValueField = "ID";
            ddlSerie.DataTextField = "SERIE";

            ddlSerie.DataBind();
            ddlSerie.Items.Insert(0, new ListItem("Seleccionar", "0"));

            ddlSubSerie.Items.Insert(0, new ListItem("Seleccionar", "0"));
            ddlTipologia.Items.Insert(0, new ListItem("Seleccionar", "0"));
            ddlExpediente.Items.Insert(0, new ListItem("Seleccionar", "0"));

            

        }


        protected void ddlSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSubSerie.DataSource = new SubSerieManagement().GetAllSubSeriesBySerie(Int32.Parse(ddlSerie.SelectedValue));
            ddlSubSerie.DataValueField = "ID";
            ddlSubSerie.DataTextField = "SUBSERIE";
            ddlSubSerie.DataBind();
            ddlSubSerie.Items.Insert(0, new ListItem("Seleccionar", "0"));

            ddlTipologia.Items.Clear();
            ddlExpediente.Items.Clear();
            ddlTipologia.Items.Insert(0, new ListItem("Seleccionar", "0"));
            ddlExpediente.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }


        protected void ddlSubSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlTipologia.DataSource = new TipologiaManagement().GetAllTipologiasBySubSerie(Int32.Parse(ddlSubSerie.SelectedValue));
            ddlTipologia.DataValueField = "ID";
            ddlTipologia.DataTextField = "TIPOLOGIA";
            ddlTipologia.DataBind();
            ddlTipologia.Items.Insert(0, new ListItem("Seleccionar", "0"));

            ddlExpediente.Items.Clear();
            ddlExpediente.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }

        protected void ddlTipologia_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlExpediente.DataSource = new ExpedienteManagement().GetAllExpedienteByTipologia(Int32.Parse(ddlTipologia.SelectedValue));
            ddlExpediente.DataValueField = "ID";
            ddlExpediente.DataTextField = "DESCRIPCION";
            ddlExpediente.DataBind();
            ddlExpediente.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }

        protected void gvDocumentos_SelectedIndexChanged(object sender, EventArgs e)
        {

            int DocumentoId = Convert.ToInt32(gvDocumentos.SelectedDataKey.Value);
            Documentos Documentos = new DocumentosManagement().GetDocumentosById(DocumentoId);
            txtDocumento.Text = Documentos.DOCUMENTO + "";
            txtCamino.Text = Documentos.CAMINO + "";

            ddlSerie.SelectedValue = Documentos.IDSERIE + "";

            ddlSubSerie.Items.Clear();
            ddlTipologia.Items.Clear();
            ddlExpediente.Items.Clear();


            try
            {
                ddlSerie.SelectedValue = Documentos.IDSERIE + "";
            }
            catch (Exception exc1)
            {
                ddlSerie.SelectedValue = "0";

                ddlSubSerie.Items.Clear();
                ddlSubSerie.Items.Insert(0, new ListItem("Seleccionar", "0"));

                ddlSubSerie.SelectedValue = "0";


                ddlTipologia.Items.Clear();
                ddlTipologia.Items.Insert(0, new ListItem("Seleccionar", "0"));
                ddlTipologia.SelectedValue = "0";

                ddlExpediente.Items.Clear();
                ddlExpediente.Items.Insert(0, new ListItem("Seleccionar", "0"));
                ddlExpediente.SelectedValue = "0";
            }


            try
            {
                ddlSubSerie.DataSource = new SubSerieManagement().GetAllSubSeriesBySerie(Documentos.IDSERIE);
                ddlSubSerie.DataValueField = "ID";
                ddlSubSerie.DataTextField = "SUBSERIE";
                ddlSubSerie.DataBind();
                ddlSubSerie.Items.Insert(0, new ListItem("Seleccionar", "0"));

                ddlSubSerie.SelectedValue = Documentos.IDSUBSERIE + "";
            }
            catch (Exception exc1)
            {

                ddlSubSerie.SelectedValue = "0";

                ddlTipologia.Items.Clear();
                ddlTipologia.Items.Insert(0, new ListItem("Seleccionar", "0"));
                ddlTipologia.SelectedValue = "0";

                ddlExpediente.Items.Clear();
                ddlExpediente.Items.Insert(0, new ListItem("Seleccionar", "0"));
                ddlExpediente.SelectedValue = "0";
            }


            try
            {
                ddlTipologia.DataSource = new TipologiaManagement().GetAllTipologiasBySubSerie(Documentos.IDSUBSERIE);
                ddlTipologia.DataValueField = "ID";
                ddlTipologia.DataTextField = "TIPOLOGIA";
                ddlTipologia.DataBind();
                ddlTipologia.Items.Insert(0, new ListItem("Seleccionar", "0"));

                ddlTipologia.SelectedValue = Documentos.IDTIPOLOGIA + "";
            }
            catch (Exception exc1)
            {

                ddlTipologia.Items.Clear();
                ddlTipologia.Items.Insert(0, new ListItem("Seleccionar", "0"));
                ddlTipologia.SelectedValue = "0";

                ddlExpediente.Items.Clear();
                ddlExpediente.Items.Insert(0, new ListItem("Seleccionar", "0"));
                ddlExpediente.SelectedValue = "0";
            }


            try
            {
                ddlExpediente.DataSource = new ExpedienteManagement().GetAllExpedienteByTipologia(Documentos.IDTIPOLOGIA);
                ddlExpediente.DataValueField = "id";
                ddlExpediente.DataTextField = "descripcion";
                ddlExpediente.DataBind();
                ddlExpediente.Items.Insert(0, new ListItem("Seleccionar", "0"));

                ddlExpediente.SelectedValue = Documentos.IDEXPEDIENTE + "";
            }
            catch (Exception exc1)
            {
                ddlExpediente.SelectedValue = "0";
            }


         /*   try
            {
                ddlTarea.SelectedValue = Configwf.idtarea + "";
            }
            catch (Exception exc1)
            {
                ddlTarea.SelectedValue = "0";
            }


            */



            // ddlTarea.SelectedValue = Configwf.idtarea + "";

            btnAddDocumentos.Text = "Editar";

        }

        protected void gvDocumentos_DeleteEventHandler(object sender, GridViewDeleteEventArgs e)
        {
            int idDocumentos = (int)gvDocumentos.DataKeys[Convert.ToInt32(e.RowIndex)].Value;

            if (!new DocumentosManagement().DeleteDocumentos(idDocumentos))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Ocurrio un problema al eliminar el registro, quizas este siendo usado');", true);
            }

            FillGvrDocumentos();
        }


        protected void gvShowDocumentos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // reference the Delete LinkButton
                LinkButton db = (LinkButton)e.Row.Cells[7].Controls[0];

                db.OnClientClick = "return confirm('Esta seguro que desea eliminar ?');";
            }
        }


        protected void btnClearDocumentos_Click(object sender, EventArgs e)
        {
            txtDocumento.Text = string.Empty;
            txtCamino.Text = string.Empty;
            btnAddDocumentos.Text = "Añadir";

            ddlSerie.SelectedValue = "0";
            ddlSubSerie.SelectedValue = "0";
            ddlTipologia.SelectedValue = "0";
            //ddlExpediente.SelectedValue = "0";
        }

        protected void btnAddDocumentos_Click(object sender, EventArgs e)
        {

            if (btnAddDocumentos.Text == "Añadir")
            {
                Documentos Documentos = new Documentos();
                Documentos.IDSERIE = Convert.ToInt32(ddlSerie.SelectedValue);
                Documentos.IDTIPOLOGIA = Convert.ToInt32(ddlTipologia.SelectedValue);
                Documentos.CAMINO = txtCamino.Text;
                Documentos.DOCUMENTO = txtDocumento.Text;
                Documentos.IDSUBSERIE = Convert.ToInt32(ddlSubSerie.SelectedValue);

                Documentos.IDEXPEDIENTE = Convert.ToInt32(ddlExpediente.SelectedValue);

                new DocumentosManagement().InsertDocumentos(Documentos);
                FillGvrDocumentos();
                btnClearDocumentos_Click(null, null);
            }
            else
            {
                Documentos Documentos = new Documentos();
                Documentos.idDOCUMENTOS = Convert.ToInt32(gvDocumentos.SelectedDataKey.Value);
                Documentos.IDSERIE = Convert.ToInt32(ddlSerie.SelectedValue);
                Documentos.IDSUBSERIE = Convert.ToInt32(ddlSubSerie.SelectedValue);
                Documentos.IDTIPOLOGIA = Convert.ToInt32(ddlTipologia.SelectedValue);
                Documentos.DOCUMENTO = txtDocumento.Text;
                Documentos.IDEXPEDIENTE = Convert.ToInt32(ddlExpediente.SelectedValue);

               // new DocumentosManagement().UpdateDocumentos(Documento);
                FillGvrDocumentos();
                btnClearDocumentos_Click(null, null);
            }

        }

        #endregion


    }
}