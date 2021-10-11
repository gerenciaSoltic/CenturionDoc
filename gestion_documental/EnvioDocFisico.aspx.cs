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
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;


namespace gestion_documental
{
    public partial class EnvioDocFisico : BasePage
    {

        Radicados radicado;
        Documentos documento;
        Indices indice;
        Workflow workflow;
        EmiRecep De;
        EmiRecep Para;
        Ente enteDe;
        Ente entePara;
        Configwf confDe;
        Configwf confPara;
        string carpetaOrigen = "";
        string carpetaDestino = "";
        EmiRecep receptor;
        DataTable dataLista = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ConfigurarPadrePostBack(this.Msj, this.usuarioLabel);

            if (!IsPostBack)
            {
                FillGvrRecepDoc();

            }
            receptor = new EmiRecepManagement().GetEmiRecepByIdusuario(SessionDocumental.UsuarioInicioSession.CODIGO);
            carpetaOrigen = receptor.conficor.CAMINOSCANNER;
            carpetaDestino = receptor.conficor.CAMINODESCARGA;
        }

        public void FillGvrRecepDoc()
        {
            receptor = new EmiRecepManagement().GetEmiRecepByIdusuario(SessionDocumental.UsuarioInicioSession.CODIGO);
            
            ddlDe.DataSource = new EnteManagement().GetAllEntes(); ;
            ddlDe.DataValueField = "IDENTE";
            ddlDe.DataTextField = "DESCRIPCION";
            ddlDe.DataBind();
            ddlDe.SelectedValue = receptor.IDENTE.ToString();

            ddlPara.DataSource = new EnteManagement().GetAllEntes();
            ddlPara.DataValueField = "IDENTE";
            ddlPara.DataTextField = "DESCRIPCION";
            ddlPara.DataBind();
            ddlPara.Items.Insert(0, new ListItem("Seleccionar", "0"));

            DmpSemaforo.Items.Add("1. URGENTE");
            DmpSemaforo.Items.Add("2. REGULAR");
            DmpSemaforo.Items.Add("3. ORDINARIO");

            DdlEmisor.DataSource = new EmiRecepManagement().GetTipoEmiRecep(2, 3);
            DdlEmisor.DataBind();
            
            

        }

        protected void btnescaner_Click(object sender, EventArgs e)
        {
            
           
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = receptor.conficor.SOFTESCANER;
            proc.Start();
            
            //System.Diagnostics.Process.Start(@receptor.conficor.SOFTESCANER.Trim());

            //Response.Redirect("file://c://codigofuente//Lubrigrasfuentes//lubrigra.exe");

            if (!System.IO.Directory.Exists(carpetaOrigen))
            {
                System.IO.Directory.CreateDirectory(carpetaOrigen);
            }

            if (System.IO.Directory.Exists(carpetaOrigen))
            {
                int cont = 0;
                while (!existeArchivo(carpetaOrigen) && cont<60)
                {
                    lblescaner.Text = "Buscando Archivo....";
                    Thread.Sleep(1000);
                    cont++;
                    
                }
                lblescaner.Text = "";
                
                string[] files = System.IO.Directory.GetFiles(carpetaOrigen);

                foreach (string s in files)
                {
                    string extencion = System.IO.Path.GetExtension(s);
                    if(extencion.ToUpper()==".PDF"){
                    string archivo = System.IO.Path.GetFileName(s);
                    txtDoc.Text = archivo;
                    ManejoArchivos.copyFile(carpetaOrigen+"\\"+archivo, Util.PathDocumentosTEMP+"\\"+archivo);
                    }
                }
            }
            else
            {
                this.PintarMsjError("No se Encuentra Archivos");
            }

        }

        protected void ddlPara_SelectedIndexChanged(object sender, EventArgs e)
        {
             Para = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(ddlPara.SelectedValue));
            De = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(ddlDe.SelectedValue));

            SessionDocumental.ObjEmisorOrigen = De;
            SessionDocumental.ObjEmisorDestino = Para;

            if (Para != null && De != null)
            {
                radicado = new RadicadosManagement().GetRadicadoActual(De, Para,false);

                txtRadicado.Text = radicado.Radicado;
                SessionDocumental.ObjRadicado = radicado;
            }
            
        }

        protected bool existeArchivo(string carpetaOrigen)
        {
            bool ret = false;
            string[] files = System.IO.Directory.GetFiles(carpetaOrigen);
            if (files.Length > 0)
            {
                foreach (string s in files)
                {
                    string extencion = System.IO.Path.GetExtension(s);
                    if (extencion.ToUpper() == ".PDF")
                    {
                        ret = true;
                    }
                }
            }
            else
            {
                ret = false;
            }
            return ret;
        
        }

        
               
        private void RegistrarScript()
        {
            const string ScriptKey = "ScriptKey";
            if (!ClientScript.IsStartupScriptRegistered(this.GetType(), ScriptKey))
            {
                System.Text.StringBuilder fn = new System.Text.StringBuilder();
                fn.Append("function fnAceptar() { ");
                fn.Append("alert('El Contenido del TextBox es:" + hruta.Value + " '); ");
                fn.Append("}");
                ClientScript.RegisterStartupScript(this.GetType(), ScriptKey, fn.ToString(), true);
            }
        }
        
        protected void btnPrevio_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(Util.DocumentosTEMP + "/" + txtDoc.Text, "_blank", "menubar=0,scrollbars=1,width=780,height=900,top=10");
        }
        
        protected void btnGuardar_Click(object sender, EventArgs e)
        {



            crearDocumento();
            crearWorkfow();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Documento recibido con Exito..');", true);
        }
        protected void crearDocumento()
        {
            documento = new Documentos();
            documento.IDSERIE = 0;
            documento.IDSUBSERIE = 0;
            documento.IDTIPOLOGIA = 0;
            documento.IDEXPEDIENTE = 0;
            documento.FOLIOS = Convert.ToInt32(TxtFolios.Text);
            documento.ANEXOS = txtAnexos.Text;
            documento.DOCUMENTO = txtDoc.Text;
            documento.CAMINO = carpetaDestino ;
            documento.IDENTE = 0;
      
            documento.idDOCUMENTOS = new DocumentosManagement().InsertDocumentos(documento);
            SessionDocumental.ObjDocumento = documento;
            
            //inserta radicados

            new RadicadosManagement().UpdateRadicados(SessionDocumental.ObjRadicado);
            ManejoArchivos.copyFile(carpetaOrigen + "/" + txtDoc.Text, Util.PathDocumentosDESC + "\\" + txtDoc.Text);

            ManejoArchivos.EliminarArchivo(carpetaOrigen, txtDoc.Text);

            ManejoArchivos.EliminarArchivo(Util.PathDocumentosTEMP, txtDoc.Text);

            txtDoc.Text = "";

        }

        
        protected void crearWorkfow()
        {
            workflow = new Workflow();
            workflow.IDENTEORIGEN = Convert.ToInt32(ddlDe.SelectedValue.ToString());
            workflow.IDENTEDESTINO = Convert.ToInt32(ddlPara.SelectedValue.ToString()); 
            workflow.FECHA = DateTime.Now;
            workflow.iddocumento = SessionDocumental.ObjDocumento.idDOCUMENTOS;
            workflow.RADICADO = txtRadicado.Text;
            workflow.IDTIPOLOGIA = 0;
            workflow.DIAS = new ConfigwfManagement().GetConfigwfById(SessionDocumental.ObjEmisorDestino.IDENTE).DIAS;
            workflow.ESTADO = "1. PENDIENTE";
            workflow.SEMAFORO = DmpSemaforo.SelectedValue.ToString();
            workflow.IDEMIRECEP = Convert.ToInt32(DdlEmisor.SelectedValue.ToString());
            workflow.OBSERVACION = TxtObservacion.Text;
            EmiRecep EMIDESTINO = new EmiRecepManagement().GetEmiRecepJefe(Convert.ToInt32(ddlPara.SelectedValue.ToString()));
            workflow.IDEMIDESTINO = EMIDESTINO.ID;

            int idworkflow = new WorkFlowManagement().InsertWorkflow(workflow);
                       
            Response.Redirect("ConfiguraPag1.aspx?idworkflow="+idworkflow);
            Response.Redirect("RecepDocFisico.aspx");
        }

        
        protected void ddlDe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (TxtIndice.Text != "")
            {
                //Workflow workflow = new WorkFlowManagement().GetWorkflowById(Convert.ToInt32(gvPendientes.SelectedValue.ToString()));
                Indices indice = new Indices();
                indice.ATRIBUTO = "";
                indice.iddocumento = workflow.iddocumento;
                indice.INDICE = TxtIndice.Text;
                new IndicesManagement().InsertIndices(indice);
                lista.DataValueField = "IDINDICES";
                lista.DataTextField = "INDICE";


                lista.DataSource = new IndicesManagement().GetIndicesByIdDocumento(workflow.iddocumento);
                lista.DataBind();
                lista.Visible = true;
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //Workflow workflow = new WorkFlowManagement().GetWorkflowById(Convert.ToInt32(gvPendientes.SelectedValue.ToString()));
            new IndicesManagement().DeleteIndices(Convert.ToInt32(lista.SelectedValue.ToString()));
            lista.DataValueField = "IDINDICES";
            lista.DataTextField = "INDICE";

            lista.DataSource = new IndicesManagement().GetIndicesByIdDocumento(workflow.iddocumento);
            lista.DataBind();
            lista.Visible = true;
        }
        
        
    
    
    }
}