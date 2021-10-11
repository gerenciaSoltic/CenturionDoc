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
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;


namespace gestion_documental
{
    
    public partial class CorreoSaliente : BasePage
    {
        EmiRecep emisorRecep;
        Correo proce = new Correo();
        protected void Page_Load(object sender, EventArgs e)
        {
          this.ConfigurarPadrePostBack(this.Msj, this.usuarioLabel);
          if (!this.IsPostBack)
          {
              //
              emisorRecep = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
              emisorRecep.conficor = new ConfiCorManagement().GetConfiCorById(emisorRecep.IDCONFICOR);
              DdlSerie.DataSource = new SerieManagement().GetASeriesEnte(emisorRecep.IDENTE);
              DdlSerie.DataBind();
              DdlSerie.Items.Insert(0, new ListItem("Seleccionar", "0"));
              DdlSerie.SelectedValue = "0";

                 
              FillGvrCorreo();
          }
        }
        protected void FillGvrCorreo()
        {
            cargarComboBoxReceptores();
            EmiRecep emisor = new EmiRecep();
            emisor = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
            TxtRadicado.Text = new RadicadosManagement().GetRadicadoExterno(emisor).Radicado;


        }
        protected void DdlSubserie_SelectedIndexChanged(object sender, EventArgs e)
        {

            EmiRecep ObjEmirecep = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);

            DdlTipologia.Enabled = true;

            DdlTipologia.DataSource = new TipologiaManagement().GetATipologiaEnte(Convert.ToInt32(DdlSubserie.SelectedValue.ToString()), ObjEmirecep.IDENTE);
            DdlTipologia.DataBind();
            DdlTipologia.Items.Insert(0, new ListItem("Seleccionar", "0"));
            DdlTipologia.SelectedValue = "0";

            DdlExpediente.DataSource = new ExpedienteManagement().GetAllExpedienteBySubserie(Convert.ToInt32(DdlSubserie.SelectedValue.ToString()), ObjEmirecep.IDENTE);
            DdlExpediente.DataBind();
            DdlExpediente.Items.Insert(0, new ListItem("Seleccionar", "0"));
            DdlExpediente.SelectedValue = "0";
            DdlExpediente.Enabled = true;





        }



        protected void DdlSerie_SelectedIndexChanged(object sender, EventArgs e)
        {

            EmiRecep ObjEmirecep = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
            DdlSubserie.Enabled = true;

            DdlSubserie.DataSource = new SubSerieManagement().GetASubSerieEnte(Convert.ToInt32(DdlSerie.SelectedValue.ToString()), ObjEmirecep.IDENTE);
            DdlSubserie.DataBind();
            DdlSubserie.Items.Insert(0, new ListItem("Seleccionar", "0"));
            DdlSubserie.SelectedValue = "0";
        }

        protected void DdlExpediente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DdlTipologia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cargarComboBoxReceptores()
        {
            // cargando los contactos para el combo box.
            DdlEmisor.DataSource = new EmiRecepManagement().GetAllEmiRecepByEmail();

            /*
            ListItem item = new ListItem();
            item.Value = "0";
            item.Text = "Seleccionar";
            DdlEmisor.Items.Add(item);
             * */
            DdlEmisor.DataTextField = "DESCRIPCION";
            DdlEmisor.DataValueField = "ID";
           DdlEmisor.DataBind(); 
           if (Session["EMISOR"] != null)
           {
               DdlEmisor.SelectedValue = Session["EMISOR"].ToString();
               TextBox1.Text = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(DdlEmisor.SelectedValue.ToString())).EMAIL;
           }
        
          
        }

       

        protected void fileUploadControl_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {

        }

     
        protected void DdlEmisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(DdlEmisor.SelectedValue.ToString())).EMAIL;
        }

        protected void DdlEmisor_TextChanged(object sender, EventArgs e)
        {
            TextBox1.Text = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(DdlEmisor.SelectedValue.ToString())).EMAIL;
        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            EmiRecep Emisor = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
            string endereco = "";
            string endereco2 = "";
            if (fuImagem.FileName != "")
            {
                
            endereco = Server.MapPath("\\"+Emisor.conficor.CAMINODESCARGA +"\\");
            endereco2 = endereco + fuImagem.FileName;
            fuImagem.SaveAs(endereco + "\\" + fuImagem.FileName);
           

            }
            EmiRecep Receptor =new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(DdlEmisor.SelectedValue.ToString()));


            string lcMensaje = Mensaje.Value.Trim() + "\n" + "\n" + "URBANAS S.A." + "\n" + "RADICADO DE CORREO: " + TxtRadicado.Text + "\n" + "EMISOR :" + Emisor.ente.DESCRIPCION + "-" + Emisor.DESCRIPCION + "\n" + "PARA :" + Receptor.DESCRIPCION;


            if (proce.enviarCorreo(Emisor.conficor.EMAIL, Emisor.conficor.CONTRASENA, lcMensaje, AsuntoTextBox.Text, Receptor.EMAIL, endereco2) == "SI")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Correo envido con Exito..');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No se pudo enviar el Correo..');", true);
            }
        }

        

       

       
    }
}