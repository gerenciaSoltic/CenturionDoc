using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestion_documental.Utils;
using gestion_documental.DataAccessLayer;
using gestion_documental.BusinessObjects;

namespace gestion_documental
{
    public partial class PagImpresion_1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioInicioSession"] == null)
            {
                Response.Redirect("Default.aspx");

            }
            if (!this.IsPostBack)
            {
                if (Request["idworkflow"] != null)
                {
                    hiddIdworkFlow.Value = Request["idworkflow"];
                }
                if (Request["formato"] != null)
                {
                    hiddFormato.Value = Request["formato"];
                }
                //txtLabel.Text = " Valores " + hiddIdworkFlow.Value + "  " + hiddFormato.Value;

                estableceImagen();

            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {

        }
        public void estableceImagen()
        {
            Workflow workflow = new WorkFlowManagement().GetWorkflowById(Convert.ToInt32(hiddIdworkFlow.Value));
            tabladiv_1.Visible = false;
            tabladiv_2.Visible = false;
            tabladiv_3.Visible = false;
            tabladiv_4.Visible = false;


            if (hiddFormato.Value == "1")
            {
                tabladiv_1.Visible = true;
                lblRadicado_1.Text = workflow.RADICADO;
                lblFecha_1.Text = workflow.FECHA.ToString();

               
                    lblRemite_1.Text = new EnteManagement().GetEnteById(workflow.IDENTEORIGEN).DESCRIPCION + "-" + new EmiRecepManagement().GetEmiRecepById(workflow.IDEMIRECEP).DESCRIPCION;
                    lblDestinatario_1.Text = new EnteManagement().GetEnteById(workflow.IDENTEDESTINO).DESCRIPCION+"-"+new EmiRecepManagement().GetEmiRecepById(workflow.IDEMIDESTINO).DESCRIPCION; 
              
                EmiRecep Receptor = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(workflow.IDEMIDESTINO));
                EmiRecep Emisor = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(workflow.IDEMIRECEP));
                int lnIdEnte = 0;
                if (Receptor.IDTIPOEMISOR != 3 && Receptor.IDTIPOEMISOR != 5)
                {
                    lnIdEnte = Receptor.IDENTE;
                }
                else
                {
                    lnIdEnte = Emisor.IDENTE;
                }
                lblAnexos_1.Text = new DocumentosManagement().GetDocumentosById(workflow.iddocumento,lnIdEnte).ANEXOS;
                lblFolios_1.Text = new DocumentosManagement().GetDocumentosById(workflow.iddocumento,lnIdEnte).FOLIOS.ToString();

            }
            if (hiddFormato.Value == "2")
            {
                tabladiv_2.Visible = true;
                
                lblRadicado_2.Text = workflow.RADICADO;
                lblFecha_2.Text = workflow.FECHA.ToString();
               
                lblRemite_2.Text = new EnteManagement().GetEnteById(workflow.IDENTEORIGEN).DESCRIPCION + "-" + new EmiRecepManagement().GetEmiRecepById(workflow.IDEMIRECEP).DESCRIPCION;
                lblDestinatario_2.Text = new EnteManagement().GetEnteById(workflow.IDENTEDESTINO).DESCRIPCION + "-" + new EmiRecepManagement().GetEmiRecepById(workflow.IDEMIDESTINO).DESCRIPCION;
                EmiRecep Receptor = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(workflow.IDEMIDESTINO));
                EmiRecep Emisor = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(workflow.IDEMIRECEP));
                int lnIdEnte = 0;
                if (Receptor.IDTIPOEMISOR != 3 && Receptor.IDTIPOEMISOR != 5)
                {
                    lnIdEnte = Receptor.IDENTE;
                }
                else
                {
                    lnIdEnte = Emisor.IDENTE;
                }



                lblAnexos_2.Text = new DocumentosManagement().GetDocumentosById(workflow.iddocumento,lnIdEnte).ANEXOS;
                lblFolios_2.Text = new DocumentosManagement().GetDocumentosById(workflow.iddocumento,lnIdEnte).FOLIOS.ToString();
            }
            if (hiddFormato.Value == "3")
            {
                tabladiv_3.Visible = true;
                lblRadicado_3.Text = workflow.RADICADO;
                lblFecha_3.Text = workflow.FECHA.ToString();
                lblRemite_3.Text = new EnteManagement().GetEnteById(workflow.IDENTEORIGEN).DESCRIPCION + "-" + new EmiRecepManagement().GetEmiRecepById(workflow.IDEMIRECEP).DESCRIPCION;
                lblDestinatario_3.Text = new EnteManagement().GetEnteById(workflow.IDENTEDESTINO).DESCRIPCION + "-" + new EmiRecepManagement().GetEmiRecepById(workflow.IDEMIDESTINO).DESCRIPCION;


                EmiRecep Receptor = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(workflow.IDEMIDESTINO));
                EmiRecep Emisor = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(workflow.IDEMIRECEP));
                int lnIdEnte = 0;
                if (Receptor.IDTIPOEMISOR != 3 && Receptor.IDTIPOEMISOR != 5)
                {
                    lnIdEnte = Receptor.IDENTE;
                }
                else
                {
                    lnIdEnte = Emisor.IDENTE;
                }

                lblAnexos_3.Text = new DocumentosManagement().GetDocumentosById(workflow.iddocumento,lnIdEnte).ANEXOS;
                lblFolios_3.Text = new DocumentosManagement().GetDocumentosById(workflow.iddocumento,lnIdEnte).FOLIOS.ToString();
            }
            if (hiddFormato.Value == "4")
            {
                tabladiv_4.Visible = true;
                lblRadicado_4.Text = workflow.RADICADO;
                lblFecha_4.Text = workflow.FECHA.ToString();
                lblRemite_4.Text = new EnteManagement().GetEnteById(workflow.IDENTEORIGEN).DESCRIPCION + "-" + new EmiRecepManagement().GetEmiRecepById(workflow.IDEMIRECEP).DESCRIPCION;
                lblDestinatario_4.Text = new EnteManagement().GetEnteById(workflow.IDENTEDESTINO).DESCRIPCION + "-" + new EmiRecepManagement().GetEmiRecepById(workflow.IDEMIDESTINO).DESCRIPCION;

                EmiRecep Receptor = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(workflow.IDEMIDESTINO));
                EmiRecep Emisor = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(workflow.IDEMIRECEP));
                int lnIdEnte = 0;
                if (Receptor.IDTIPOEMISOR != 3 && Receptor.IDTIPOEMISOR != 5)
                {
                    lnIdEnte = Receptor.IDENTE;
                }
                else
                {
                    lnIdEnte = Emisor.IDENTE;
                }

                lblAnexos_4.Text = new DocumentosManagement().GetDocumentosById(workflow.iddocumento,lnIdEnte).ANEXOS;
                lblFolios_4.Text = new DocumentosManagement().GetDocumentosById(workflow.iddocumento,lnIdEnte).FOLIOS.ToString();
            }
        }
    }
}