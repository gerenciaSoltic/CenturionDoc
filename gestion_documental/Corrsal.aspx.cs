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
    public partial class Corrsal : BasePage
    {
        EmiRecep emisorRecep;
        Correo proce = new Correo();
        Class1 proce2 = new Class1();

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
                creatablaArchivo();

                FillGvrCorreo();

                if (Session["Asunto"] != null)
                {
                    AsuntoTextBox.Text = Convert.ToString(Session["Asunto"]);
                }

                if (Session["TextoMail"] != null)
                {
                    Mensaje.Value = Convert.ToString(Session["TextoMail"]); 
                }

  
                Session.Remove("Asunto");
                Session.Remove("TextMail");
          
            }
        }
        protected void FillGvrCorreo()
        {
            cargarComboBoxReceptores();
            EmiRecep emisor = new EmiRecep();
            emisor = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
        
           
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

        protected void obtieneRadicado(int tcIdDe, int tcIdPara)
        {
            EmiRecep Para = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(tcIdPara));
            EmiRecep De = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(tcIdDe));
            Radicados radicado = new Radicados();
            SessionDocumental.ObjEmisorOrigen = De;
            SessionDocumental.ObjEmisorDestino = Para;

            if (Para.ID != 0 && De.ID != 0)
            {
                radicado = new RadicadosManagement().GetRadicadoActual(De, Para,true);
                TxtRadicado.Text = radicado.Radicado;
                string lcPrefijo = "";
                if (radicado.PrefCorrSal.Trim() == TxtRadicado.Text.Substring(0, radicado.PrefCorrSal.Trim().Length))
                {
                    lcPrefijo = radicado.PrefCorrSal.Trim();
                }
                if (radicado.PrefCorrEnt.Trim() == TxtRadicado.Text.Substring(0, radicado.PrefCorrEnt.Trim().Length))
                {
                    lcPrefijo = radicado.PrefCorrEnt.Trim();
                }

                if (radicado.prefInter.Trim() == TxtRadicado.Text.Substring(0, radicado.prefInter.Trim().Length))
                {
                    lcPrefijo = radicado.prefInter.Trim();
                }


                int lnRadicado = Convert.ToInt32(TxtRadicado.Text.Substring(lcPrefijo.Length + 4));
                // Ahora miramos si el radicado ya existe
                bool llExiste = true;
                while (llExiste)
                {
                    Workflow ExisteRad = new Workflow();
                    ExisteRad = new WorkFlowManagement().GetWorkflowByRadicado(TxtRadicado.Text);
                    if (ExisteRad.RADICADO == "")
                    {
                        llExiste = false;
                    }
                    else
                    {
                        lnRadicado = lnRadicado + 1;
                        TxtRadicado.Text = lcPrefijo + Convert.ToDateTime(radicado.UltimaFecha).Year.ToString() + lnRadicado.ToString();
                    }
                }
                //
            }



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
            if (Session["idEmisor"] != null)
            {
                DdlEmisor.SelectedValue = Session["idEmisor"].ToString();
                TextBox1.Text = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(DdlEmisor.SelectedValue.ToString())).EMAIL;
            }


        }



        protected void fileUploadControl_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {

        }


        protected void DdlEmisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //EmiRecep emisor= new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
            //EmiRecep receptor= new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(DdlEmisor.SelectedValue)); 
            //TextBox1.Text = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(DdlEmisor.SelectedValue.ToString())).EMAIL;

            
        }

        protected void DdlEmisor_TextChanged(object sender, EventArgs e)
        {
            //TextBox1.Text = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(DdlEmisor.SelectedValue.ToString())).EMAIL;
        }

        protected void BtnEnviar_Click(object sender, EventArgs e)
        {

            if (TextBox1.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No hay destinatarios');", true);
                return;
            }
            DataTable tablaArchivo = (DataTable)Session["tablaArchivo"];

            EmiRecep Emisor = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
            string endereco = "";
            string endereco2 = "";
            foreach (DataRow Fila in tablaArchivo.Rows)
            {
                endereco = proce2.recuperaUbicacion()+"\\" + Emisor.conficor.CAMINODESCARGA + "\\";
                if (endereco2 != "")
                {
                    endereco2 =endereco2+",";
                }
                endereco2 = endereco2 + endereco + Fila["Archivo"];
                



            }
            //endereco2 = endereco2.Substring(0, endereco2.Length - 1);
            
            //EmiRecep Receptor = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(DdlEmisor.SelectedValue.ToString()));

            Mensaje.Value ="\r\n"+"\r\n"+Mensaje.Value+   "\r\n" +"\r\n"+"\r\n"+"\r\n"+"\r\n"+ SessionDocumental.UsuarioInicioSession.NOMBRE;
            string lcMensaje = "\r\n" + "\r\n" + " " + "\r\n" + "RADICADO DE CORREO: " + TxtRadicado.Text + "\r\n" + "EMISOR :" + Emisor.ente.DESCRIPCION + "-" + Emisor.DESCRIPCION.Trim() + "\r\n" + "PARA :" + TextBox1.Text.Trim() + "\r\n" +Mensaje.Value.Trim() ;


            if (proce.enviarCorreo(Emisor.conficor.EMAIL, Emisor.conficor.CONTRASENA, lcMensaje,AsuntoTextBox.Text,TextBox1.Text, endereco2,Emisor.conficor.SERVPOPSALIENTE) == "SI")
            {

                 EmiRecep Receptor = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);


                //crearDocumento();
                //crearWorkfow();




                obtieneRadicado(Emisor.ID, Receptor.ID);
                // new CorreoEntranteManagement().UpdateCorreoEntrantebyId(SessionDocumental.CorreoVer.ID);
                CorreoSaliente CorSal = new CorreoSaliente();
              
                CorSal.FECHA = DateTime.Now;
                CorSal.ASUNTO = AsuntoTextBox.Text;
                CorSal.IDEMISOR = Convert.ToInt32(DdlEmisor.SelectedValue);
                CorSal.IDRECEPTOR = Receptor.ID;
                CorSal.TEXTO = "Correo enviado a "+TextBox1.Text.Trim()+"\r\n"+"\r\n"+Mensaje.Value.Trim();
                if(DdlTipologia.SelectedValue!="")
                {
                CorSal.IDTIPOLOGIA = Convert.ToInt32(DdlTipologia.SelectedValue);
                }
                CorSal.RADICADO = TxtRadicado.Text;

                int LnidCorreo = new CorreoSalienteManagement().InsertCorreoSaliente(CorSal);

            
                foreach (DataRow Fila in tablaArchivo.Rows)
                {
                    Adjunsal AdjuntosSalida = new Adjunsal();

                    AdjuntosSalida.IDCORREO = LnidCorreo;
                    AdjuntosSalida.ARCHIVO = Fila["Archivo"].ToString();
                    AdjuntosSalida.NEWARCHIVO = Fila["Archivo"].ToString();

                    new AdjunsalManagement().InsertAdjunsal(AdjuntosSalida);
                }



                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Correo enviado con Exito..');", true);
                limpiar();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No se pudo enviar el Correo..');", true);
            }
        }

        protected void limpiar()
        {
            TxtRadicado.Text = "";
            AsuntoTextBox.Text = "";
            TextBox1.Text = "";
            Mensaje.Value = "";
            creatablaArchivo();
            

        }

        protected void creatablaArchivo()
        {
            DataTable tablaArchivo = new DataTable();
            tablaArchivo.Clear();
            DataColumn elemento = new DataColumn("archivo");
            elemento.DataType = System.Type.GetType("System.String");
            tablaArchivo.Columns.Add(elemento);

            GridView1.DataSource = tablaArchivo;
            GridView1.DataBind();
            Session.Add("tablaArchivo", tablaArchivo);

          


        }
        protected void crearDocumento()
        {

            EmiRecep emisor = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
            EmiRecep receptor = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(DdlEmisor.SelectedValue));


            string carpetaDestino = receptor.conficor.CAMINODESCARGA;


            Documentos documento = new Documentos();
            
            if (DdlSerie.SelectedValue=="" )
            {
                documento.IDSERIE = Convert.ToInt32(DdlSerie.SelectedValue);
                documento.IDSUBSERIE = Convert.ToInt32(DdlSubserie.SelectedValue);
                documento.IDTIPOLOGIA = Convert.ToInt32(DdlTipologia.SelectedValue); ;
                documento.IDEXPEDIENTE = Convert.ToInt32(DdlExpediente.SelectedValue); ;
            

            }
             
            
            documento.FOLIOS = 1;
            documento.ANEXOS = "";
            documento.DOCUMENTO = fuImagem.FileName;
            documento.CAMINO = emisor.conficor.CAMINODESCARGA;
           

            documento.IDENTE = 0;

            documento.idDOCUMENTOS = new DocumentosManagement().InsertDocumentos(documento);
            SessionDocumental.ObjDocumento = documento;
            //
        }

        protected void crearWorkfow()
        {
            Workflow workflow = new Workflow();

            EmiRecep receptor = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(DdlEmisor.SelectedValue));
            EmiRecep emisor = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);

            workflow.IDENTEORIGEN = Convert.ToInt32(emisor.IDENTE);
            workflow.IDENTEDESTINO = Convert.ToInt32(emisor.IDENTE);
            workflow.IDEMIRECEP = emisor.ID;
            workflow.IDEMIDESTINO = emisor.ID;

            workflow.FECHA = DateTime.Now;
            workflow.iddocumento = SessionDocumental.ObjDocumento.idDOCUMENTOS;
            workflow.RADICADO = TxtRadicado.Text;
            workflow.IDTAREA = 1;
            workflow.IDTIPOLOGIA = 0;
            workflow.DIAS = new ConfigwfManagement().GetConfigwfById(receptor.IDENTE).DIAS;
            workflow.ESTADO = "2. EN PROCESO";
            workflow.OBSERVACION = "CORREO ELECTRONICO ENVIADO A: "+receptor.DESCRIPCION.Trim()+"-"+receptor.EMAIL;
            workflow.TIPO = "C";
            /*
            DataTable tablaArchivo = (DataTable)Session["tablaArchivo"];
             Cadenas cadena = new Cadenas();
                cadena.FECHA = System.DateTime.Now;
                workflow.IDCADENA = new CadenasManagement().InsertCadenas(cadena);
            if (tablaArchivo.Rows.Count > 0)
            {
                foreach

            }
            else
            {
               
                new WorkFlowManagement().InsertWorkflow(workflow);
            }

            */
        }

        protected void Adjuntar_Click(object sender, EventArgs e)
        {
            EmiRecep Emisor = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
            string endereco = "";
            string endereco2 = "";
            if (fuImagem.FileName != "")
            {

                endereco = proce2.recuperaUbicacion() + "\\" + Emisor.conficor.CAMINODESCARGA + "\\";
                endereco2 = endereco + fuImagem.FileName;
                fuImagem.SaveAs(endereco + "\\" + fuImagem.FileName);

                DataTable tablaArchivo = (DataTable)Session["tablaArchivo"];

                DataRow Fila = tablaArchivo.NewRow();
                Fila["Archivo"] = fuImagem.FileName;
                tablaArchivo.Rows.Add(Fila);

                GridView1.DataSource = tablaArchivo;
                GridView1.DataBind();
                Session.Add("tablaArchivo", tablaArchivo);


            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("docpendi.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EmiRecep emisor = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
            EmiRecep receptor = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(DdlEmisor.SelectedValue));
            obtieneRadicado(emisor.ID, receptor.ID);
            if (TextBox1.Text == "")
            {
                TextBox1.Text = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(DdlEmisor.SelectedValue.ToString())).EMAIL;
            }
            else
            {
                TextBox1.Text = TextBox1.Text + ";" + new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(DdlEmisor.SelectedValue.ToString())).EMAIL;
            }

        }
    }
}