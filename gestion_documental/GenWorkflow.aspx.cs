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
    public partial class GenWorkflow : System.Web.UI.Page
    {
        Class1 proce = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenaddls();
                llenargrid();
                blanquea();
            }


        }

        protected void llenaddls()
        {
            EmiRecep  emisor = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
            Ddlmidestino.DataSource = new EmiRecepManagement().GetAllFuncionarios(emisor.IDRADICADO);
            Ddlmidestino.DataValueField = "IDEMIRECEP";
            Ddlmidestino.DataTextField = "FUNCIONARIO";
            Ddlmidestino.DataBind();

            ddlEmirevision.DataSource = new EmiRecepManagement().GetAllFuncionarios(emisor.IDRADICADO);
            ddlEmirevision.DataValueField = "IDEMIRECEP";
            ddlEmirevision.DataTextField = "FUNCIONARIO";
            ddlEmirevision.DataBind();


            DdlTarea.DataSource = new TareasManagement().GetAllTareas();
            DdlTarea.DataTextField = "Descripcion";
            DdlTarea.DataValueField = "idtareas";
            DdlTarea.DataBind();

            DdlRepetir.Items.Add("DIARIO");
            DdlRepetir.Items.Add("SEMANAL");
            DdlRepetir.Items.Add("QUINCENAL");
            DdlRepetir.Items.Add("MENSUAL");
            DdlRepetir.Items.Add("BIMESTRAL");
            DdlRepetir.Items.Add("TRIMESTRAL");
            DdlRepetir.Items.Add("CUATRIMESTRAL");
            DdlRepetir.Items.Add("SEMESTRAL");
            DdlRepetir.Items.Add("ANUAL");

            

        }

        protected void blanquea()
        {
            txtAsunto.Text = "";
            txtFechaInicial.Text = "";
            txtUltimaFecha.Text = "";
            FileUpload1.Dispose();
            
            btnAddEnte.Text = "Añadir";


             
        }

        protected void gvEnte_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable DatGenWorkflow = new DataTable();
            proce.consultacamposcondicion("generaworkflow", "*", "id = " + gvEnte.SelectedDataKey.Value.ToString(), DatGenWorkflow);
            
            if (DatGenWorkflow.Rows.Count > 0)
            {
                Ddlmidestino.SelectedValue = DatGenWorkflow.Rows[0]["idemidestino"].ToString();
                if (Convert.ToInt32(DatGenWorkflow.Rows[0]["idemidestino2"].ToString())!= 0)
                {
                ddlEmirevision.SelectedValue = DatGenWorkflow.Rows[0]["idemidestino2"].ToString();
                }
                DdlRepetir.SelectedValue = DatGenWorkflow.Rows[0]["repetir"].ToString();
                DdlTarea.SelectedValue = DatGenWorkflow.Rows[0]["idtarea"].ToString();
                txtAsunto.Text = DatGenWorkflow.Rows[0]["asunto"].ToString();
                txtDias.Text = DatGenWorkflow.Rows[0]["Dias"].ToString();
                txtFechaInicial.Text = proce.formateafecha(Convert.ToDateTime(DatGenWorkflow.Rows[0]["fechaIni"].ToString()),0);
                txtDocumento.Text = DatGenWorkflow.Rows[0]["caminodoc"].ToString();
                if (DatGenWorkflow.Rows[0]["UltimaFecha"].ToString() != " " && DatGenWorkflow.Rows[0]["UltimaFecha"].ToString() != null)
                {
                    txtUltimaFecha.Text = DatGenWorkflow.Rows[0]["UltimaFecha"].ToString();
                }
                if (Convert.ToInt32(DatGenWorkflow.Rows[0]["Activo"]) == 1)
                {
                    chkActivo.Checked = true;
                }
                else
                {
                    chkActivo.Checked = false;
                }
                
                btnAddEnte.Text = "Actualizar";
            }

        }

        protected void gvEnte_DeleteEventHandler(object sender, GridViewDeleteEventArgs e)
        {
            if (gvEnte.SelectedDataKey == null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Debe seleccionar un registro');", true);
             
            }
              else
                {

           proce.eliminar("generaworkflow","id = "+ gvEnte.SelectedDataKey.Value.ToString());
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Registro Eliminado');", true);

                llenargrid();
                }
        }

        private void llenargrid()
        {
            DataTable DatGenworkFlowAll = new DataTable();
            proce.consultacamposcondicion("generaworkflow,emirecep", "generaworkflow.*,emirecep.descripcion as Para", " generaworkflow.idemidestino = emirecep.id ", DatGenworkFlowAll);

            gvEnte.DataSource = DatGenworkFlowAll;
            gvEnte.DataBind();

        }

        protected void gvShowEnte_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // reference the Delete LinkButton
                LinkButton db = (LinkButton)e.Row.Cells[4].Controls[0];

                db.OnClientClick = "return confirm('Esta seguro que desea eliminar ?');";
            }
        }

        protected void btnAddEnte_Click(object sender, EventArgs e)
        {

            // Validamos Campos Llenos

            if (txtAsunto.Text == "")
            {
                txtAsunto.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Falta llenar el Asunto');", true);
                return;
            }
            if (txtFechaInicial.Text== "")
            {
                txtFechaInicial.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Falta llenar la fecha Inicial');", true);
                return;
            }
            if (txtDias.Text == "")
            {
                txtDias.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Falta llenar los dias');", true);
                return;
            }
             EmiRecep Emisor = new EmiRecepManagement().GetEmiRecepByCodUsuario(Convert.ToInt32(SessionDocumental.UsuarioInicioSession.CODIGO.ToString()));
            // Capturamos la variable del archivo
            string lcCaminoDoc = CaminoDoc.Value; 
            

            if (btnAddEnte.Text == "Añadir")
            {

                proce.insertaralgunos("generaworkflow", "asunto,repetir,fechaIni,idemirecep,idemidestino,caminodoc,idtarea,activo,fechacrea,dias", "'" + txtAsunto.Text + "','" + DdlRepetir.SelectedValue + "','" + txtFechaInicial.Text + "'," + Emisor.ID+","+ Ddlmidestino.SelectedValue.ToString() + ",'" + lcCaminoDoc + "'," + DdlTarea.SelectedValue.ToString() + ",1,'"+proce.formateafecha(DateTime.Now,0)+"',"+txtDias.Text);

            }
            else
            {
                int lnActivo = 1;
                if (!chkActivo.Checked)
                {
                    lnActivo = 0;
                }
                proce.editar("generaworkflow", "asunto ='" + txtAsunto.Text + "',repetir='" + DdlRepetir.SelectedValue + "', fechaini ='" + txtFechaInicial.Text + "',idemidestino=" + Ddlmidestino.SelectedValue + ",caminodoc='" + lcCaminoDoc + "',idtarea =" + DdlTarea.SelectedValue+",activo = "+lnActivo.ToString()+",dias="+txtDias.Text, "id = " + gvEnte.SelectedDataKey.Value);
            }

            btnAddEnte.Text = "Añadir";
            blanquea();
            llenargrid();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Registro Grabado');", true);
            


        }

        protected void btnClearEnte_Click(object sender, EventArgs e)
        {
            blanquea();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (FileUpload1.HasFile)
            {
                EmiRecep Emisor = new EmiRecepManagement().GetEmiRecepByCodUsuario(Convert.ToInt32(SessionDocumental.UsuarioInicioSession.CODIGO.ToString()));
                // Grabamdo el Archivo
                string lcArchivo = proce.recuperaUbicacion() + "\\" + Emisor.conficor.CAMINODESCARGA.Trim() + "\\" + FileUpload1.FileName;
                CaminoDoc.Value = FileUpload1.FileName;
                txtDocumento.Text = FileUpload1.FileName;
                FileUpload1.SaveAs(lcArchivo);
            }
        }

        protected void Btn_Salir_Click(object sender, EventArgs e)
        {
            Response.Redirect("docpendi.aspx");
        }

     

    }
}