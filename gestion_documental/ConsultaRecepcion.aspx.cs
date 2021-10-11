using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestion_documental.Utils;
using gestion_documental.DataAccessLayer;
using gestion_documental.BusinessObjects;
using System.Data;

namespace gestion_documental
{
    public partial class ConsultaRecepcion : System.Web.UI.Page
    {
        Class1 proce = new Class1();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UsuarioInicioSession"] == null)
            {
                Response.Redirect("Default.aspx");

            }
            if (!IsPostBack)
            {
                DdlTipo.Items.Add("ENTRANTE");
                DdlTipo.Items.Add("SALIENTE");
                DdlTipo.Items.Add("INTERNA");


                DDLgrupocom.DataSource = new grupocomManagement().GetGrupocomByIdradicado(Convert.ToInt32(new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO).IDRADICADO));
                DDLgrupocom.DataTextField = "nombre";
                DDLgrupocom.DataValueField = "ID";
                DDLgrupocom.DataBind();
                DDLgrupocom.Items.Insert(0, new ListItem("0. TODOS"));

                /*
                DmpSemaforo.Items.Add("1. DERECHO DE PETICIÓN");
                DmpSemaforo.Items.Add("2. QUEJAS");
                DmpSemaforo.Items.Add("3. RECLAMOS");
                DmpSemaforo.Items.Add("5. CIRCULAR");
                DmpSemaforo.Items.Add("6. CITACIÓN");
                DmpSemaforo.Items.Add("7. MEMORANDO");
                DmpSemaforo.Items.Add("8. ACCION DE TUTELA");
                DmpSemaforo.Items.Add("9. OTROS");
                DmpSemaforo.Items.Add("10.CONTRATOS");
                DmpSemaforo.Items.Add("11.EMBARGO");
                DmpSemaforo.Items.Add("12.INVITACION");
                DmpSemaforo.Items.Add("13.NOTIFICACION");
                DmpSemaforo.Items.Add("14.SOLICITUD");
                DmpSemaforo.Items.Add("15.DESEMBARGOS");
                DmpSemaforo.Items.Add("16.PAGOS");
                DmpSemaforo.Items.Add("17.DECRETOS");
                DmpSemaforo.Items.Add("18.ORDENANZAS");
                */
                string lcInforme = Request.QueryString["informe"];
                Session.Add("lcInforme", lcInforme);
                if (lcInforme == "RepoInforme.rdlc")
                {
                    Label1.Text = "INFORME DE ATENCIONES";
                }
                else if (lcInforme == "RepoPQRS.rdlc")
                {
                    Label1.Text = "INFORME DE PQRS";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Averiguamos que tipo de radicado debemos FILTRAR

            int lnTipo = 0;
            switch (DdlTipo.SelectedValue.ToString())
            {
                case "ENTRANTE":
                    lnTipo = 1;
                    break;

                case "SALIENTE":
                    lnTipo = 2;
                    break;

                case "INTERNA":
                    lnTipo = 3;
                    break;



            }
            String lcSemaforo = "";
            if (DDLgrupocom.SelectedItem.Value == "0. TODOS")
            {
                lcSemaforo = "0. TODOS";
            }
            else
            {
                for (int i = 0; i < LstTipoCom.Items.Count; i++)
                {
                    if (lcSemaforo == "")
                    {
                        lcSemaforo = "'" + LstTipoCom.Items[i].ToString() + "'";
                    }
                    else
                    {
                        lcSemaforo = lcSemaforo + ",'" + LstTipoCom.Items[i].ToString() + "'";
                    }
                }
            }


            DataAccessLayer.WorkFlowManagement.Fdesde = txtFechaDesde.Text;
            DataAccessLayer.WorkFlowManagement.Fhasta = TxtFechaHasta.Text;
            DataAccessLayer.WorkFlowManagement.lnTipo = lnTipo;
            DataAccessLayer.WorkFlowManagement.semaforo = lcSemaforo;
            DataAccessLayer.WorkFlowManagement.lcRadicado = TxtRadicado.Text;
            DataAccessLayer.WorkFlowManagement.tipoinforme = 1;
            EmiRecep emisorVentanilla = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
            DataAccessLayer.WorkFlowManagement.Ventanilla = emisorVentanilla.IDENTE;
            if (Session["lcInforme"].ToString() == "RepoInforme.rdlc")
            {
                DataAccessLayer.WorkFlowManagement.confuncionario = false;
                DataAccessLayer.WorkFlowManagement.TIPO = "";
            }
            else if (Session["lcInforme"].ToString() == "RepoPQRS.rdlc")
            {
                DataAccessLayer.WorkFlowManagement.confuncionario = false;
                DataAccessLayer.WorkFlowManagement.TIPO = "";
            }
            else if (Session["lcInforme"].ToString() == "RepoSIA.rdlc")
            {
                DataAccessLayer.WorkFlowManagement.confuncionario = false;
                DataAccessLayer.WorkFlowManagement.TIPO = "";
            }
            else if (Session["lcInforme"].ToString() == "RepoVentanillaVir.rdlc")
            {
                DataAccessLayer.WorkFlowManagement.confuncionario = false;
                DataAccessLayer.WorkFlowManagement.TIPO = "V";
            }
            else
            {
                DataAccessLayer.WorkFlowManagement.confuncionario = true;
            }

            Response.Redirect("muestraventanilla.aspx?informe=" + Session["lcInforme"]);
        }

        protected void DDLgrupocom_SelectedIndexChanged(object sender, EventArgs e)
        {
            DmpSemaforo.DataSource = new TipocomManagement().GetTipoComById(Convert.ToInt32(DDLgrupocom.SelectedItem.Value));
            DmpSemaforo.DataTextField = "Tipocomunicacion";
            DmpSemaforo.DataValueField = "Tipocomunicacion";
            DmpSemaforo.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            LstTipoCom.Items.Add(DmpSemaforo.SelectedItem.Value.ToString());


        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (LstTipoCom.SelectedValue == null)
            {

            }
            else
            {
                LstTipoCom.Items.Remove(LstTipoCom.SelectedItem);
            }


        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            ListBox TempoTipos = new ListBox();
            TempoTipos.DataValueField = "Tipocomunicacion";
            TempoTipos.DataSource = new TipocomManagement().GetTipoComById(Convert.ToInt32(DDLgrupocom.SelectedItem.Value));

            TempoTipos.DataBind();

            for (int i = 0; i < TempoTipos.Items.Count; i++)
            {
                LstTipoCom.Items.Add(TempoTipos.Items[i].ToString());
            }
        }


    }
}