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
using gestion_documental;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using System.IO;

namespace gestion_documental
{
    public partial class ArchivoRecepcion : BasePage
    {

        Radicados radicado;
        Documentos documento;
        Indices indice;
        Workflow workflow;
        EmiRecep De;
        EmiRecep Para;

        Correo Enviar = new Correo();

        Ente enteDe;
        Ente entePara;
        Configwf confDe;
        Configwf confPara;
        string carpetaOrigen = "";
        string carpetaDestino = "";
        string carpetatemp = "";
        EmiRecep receptor;
        DataTable dataLista = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               

                ddlProceso.DataSource = new ProcesoManagement().GetAllProcesos();
                ddlProceso.DataValueField = "ID";
                ddlProceso.DataTextField = "PROCESO";

                ddlProceso.DataBind();

                ddlProceso.Items.Insert(0, new ListItem("Seleccionar", "0"));
                ddlActividad.Items.Insert(0, new ListItem("Seleccionar", "0"));
                ddlDocumentoActividad.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }

        }

        protected void btnescaner_Click(object sender, EventArgs e)
        {

            string lcCaminoOrigen = Server.MapPath(carpetaOrigen);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('"+lcCaminoOrigen+"');", true);
            if (!System.IO.Directory.Exists(lcCaminoOrigen))
            {
                System.IO.Directory.CreateDirectory(lcCaminoOrigen);
            }

            if (System.IO.Directory.Exists(lcCaminoOrigen))
            {

                int cont = 0;
                while (!existeArchivo(lcCaminoOrigen) && cont < 60)
                {
                    lblescaner.Text = "Buscando Archivo....";
                    Thread.Sleep(1000);
                    cont++;

                }

                lblescaner.Text = "";

                string[] files = System.IO.Directory.GetFiles(lcCaminoOrigen);

                foreach (string s in files)
                {
                    string extencion = System.IO.Path.GetExtension(s);
                    if (extencion.ToUpper() == ".PDF")
                    {

                        string archivo = System.IO.Path.GetFileName(s);
                        txtDoc.Text = archivo;
                        /*
                        string lcOrigen = @carpetaOrigen;
                        string lcDestino = @Util.PathDocumentosTEMP;
                        if (carpetatemp != "")
                        {
                            lcDestino = lcDestino + "//" + carpetatemp;
                        }

                        lcOrigen = lcOrigen.Replace("//", "\\");
                        lcDestino = lcDestino.Replace("//", "\\");
                        string sourcefile = System.IO.Path.Combine(lcOrigen, archivo);
                        string targetfile = System.IO.Path.Combine(lcDestino, archivo);
                        System.IO.File.Copy(sourcefile, targetfile, true);
                        */

                    }

                }
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

        protected void btnPrevio_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/" + carpetatemp + "/" + txtDoc.Text, "_blank", "menubar=0,scrollbars=1,width=780,height=900,top=10");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (ddlDocumentoActividad.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe seleccionar un nombre de documento');", true);
                return;
            }
            if (txtDoc.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe oprimir el botón Scanear');", true);
                return;

            }
            SessionDocumental.ObjDocumento.DOCUMENTO = txtDoc.Text;
            SessionDocumental.ObjDocumento.iddocumentoactividad =Convert.ToInt32(ddlDocumentoActividad.SelectedValue);
            Documentos documento = SessionDocumental.ObjDocumento as Documentos;
            
            new DocumentosManagement().UpdateDocumentos(documento);
            string lcCaminoOrigen = Server.MapPath(carpetaOrigen);
            lcCaminoOrigen = lcCaminoOrigen.Replace("\\", "//");
            string lcCaminoDestino = Server.MapPath(carpetaDestino);

            ManejoArchivos.copyFile(lcCaminoOrigen + "//" + txtDoc.Text, lcCaminoDestino + "\\" + txtDoc.Text);

            ManejoArchivos.EliminarArchivo(lcCaminoOrigen, txtDoc.Text);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Proceso realizado con exito..');", true);
            if (CheckBox1.Checked)
            {

                enviarcorreo(lcCaminoDestino + "\\" + txtDoc.Text);
            }
            Workflow WorkflowDoc = new WorkFlowManagement().GetWorkflowByIddocumento(SessionDocumental.ObjDocumento.idDOCUMENTOS);
            gvDocumento.DataSource = new DocumentosManagement().GetDocumentosNombrebyListaiD(WorkflowDoc.IDCADENA).Where(y => y.documentoactividad.NOMBREDOCUMENTO != null).Select(x => new { TIPODOC = x.documentoactividad.NOMBREDOCUMENTO, NOMBREDOC = x.DOCUMENTO }).ToList();
            gvDocumento.DataBind();
            llenarDocumentoActividad();
            file_upload.Enabled = true;
            btnFileUpload.Enabled = true;
            Button5.Enabled = false;
            btnescaner.Enabled = false;
            Button1.Enabled = true;
        }


        protected void enviarcorreo(string lcAdjunto)
        {

            // Buscamos el workflow

            Workflow myWorkFlow = new WorkFlowManagement().GetWorkflowByIddocumento(SessionDocumental.ObjDocumento.idDOCUMENTOS);

            Radicados objRadicado = new RadicadosManagement().GetRadicadosById(myWorkFlow.IDRADICADO);
            //Miramos si es entrante o saliente
            string lcRadicado = "";
            if (SessionDocumental.ObjRadicado.Radicado == "")
            {
                lcRadicado = SessionDocumental.ObjDocumento.RADICADO;
            }
            else
            {
                lcRadicado = SessionDocumental.ObjRadicado.Radicado;
            }

            objRadicado.Radicado = lcRadicado;

            string lcTipoRadicado = "";
            string lcMail = "";
            EmiRecep DatosCorreo = new EmiRecep();
            if (objRadicado.PrefExtEnt.Trim() == myWorkFlow.RADICADO.Substring(0, objRadicado.PrefExtEnt.Trim().Length))
            {
                lcTipoRadicado = "ENTRANTE";

                DatosCorreo = new EmiRecepManagement().GetEmiRecepById(myWorkFlow.IDEMIDESTINO);
                lcMail = DatosCorreo.EMAIL;
            }

            if (objRadicado.PrefExtSal.Trim() ==myWorkFlow.RADICADO.Substring(0, objRadicado.PrefExtSal.Trim().Length))
            {
                lcTipoRadicado = "SALIENTE";
                DatosCorreo = new EmiRecepManagement().GetEmiRecepById(myWorkFlow.IDEMIRECEP);
                lcMail = DatosCorreo.EMAIL;
            }
            if (objRadicado.prefInter.Trim() == myWorkFlow.RADICADO.Substring(0, objRadicado.prefInter.Trim().Length))
            {
                lcTipoRadicado = "INTERNO";
                DatosCorreo = new EmiRecepManagement().GetEmiRecepById(myWorkFlow.IDEMIDESTINO);
                lcMail = DatosCorreo.EMAIL;
            }


            char x = '@';
            if (lcMail.IndexOf(x) == 0)
            {
                return;
            }


            string lcMensaje = "";
            string lcAsunto = "";
            switch (lcTipoRadicado)
            {
                case "ENTRANTE":
                    lcAsunto = myWorkFlow.SEMAFORO;
                    lcMensaje =  "\r\n" + " Estimado(a) :" + DatosCorreo.DESCRIPCION + "\r\n" + "Direccion: " + DatosCorreo.DIRECCIONFISICA + "  " + DatosCorreo.MUNICIPIO + "-" + DatosCorreo.DEPARTAMENTO + "\r\n" + "Telefono:" + DatosCorreo.TELEFONO + "\r\n" + " Radicado de Entrada: " + lcRadicado;
                    lcMensaje = lcMensaje + "\r\n" + "\r\n" + "Ud ha tramitado una Solicitud a travéz de nuestra Ventanilla VENTANILLA UNICA DE CORRESPONDENCIA FISICA Con  el siguiente Asunto: ";
                    lcMensaje = lcMensaje + "\r\n" + "\r\n" + "Tipo de Correspondencia :" + myWorkFlow.SEMAFORO;
                    lcMensaje = lcMensaje + "\r\n" + "\r\n" + "Dirigido a :" + myWorkFlow.ENTEDESTINO;
                    lcMensaje = lcMensaje + "\r\n" + "\r\n" + "Asunto :" + myWorkFlow.OBSERVACION;
                    lcMensaje = lcMensaje + "\r\n" + "\r\n" + "En este correo viene adjunto el archivo que nos envio para el estudio de su caso";
                    lcMensaje = lcMensaje + "\r\n" + "\r\n" + "Le daremos respuesta via correo electronico a su email :" + DatosCorreo.EMAIL + " ó si prefirio de forma fisica la respuesta estará en nuestras instalaciones con un tiempo no superior a 15 dias habiles calendario";
                    lcMensaje = lcMensaje + "\r\n" + "\r\n";
                    lcMensaje = lcMensaje + "\r\n" + "\r\n" + "Gracias por su Atencion";
                    break;

                case "SALIENTE":
                    lcAsunto = "Respuesta a " + myWorkFlow.SEMAFORO;
                    lcMensaje = "\r\n" + " Estimado(a) :" + DatosCorreo.DESCRIPCION + "\r\n" + "Direccion: " + DatosCorreo.DIRECCIONFISICA + "  " + DatosCorreo.MUNICIPIO + "-" + DatosCorreo.DEPARTAMENTO + "\r\n" + "Telefono:" + DatosCorreo.TELEFONO + "\r\n" + " Radicado de Entrada: " + myWorkFlow.RADICADO2;
                    lcMensaje = lcMensaje + "\r\n" + "\r\n" + "Ud ha realizado un envio de correspondencia a traves de nuestra VENTANILLA UNICA DE CORRESPONDENCIA FISICA Con  el siguiente Asunto: ";
                    lcMensaje = lcMensaje + "\r\n" + "\r\n" + "Tipo de Correspondencia : RESPUESTA " + myWorkFlow.SEMAFORO;
                    lcMensaje = lcMensaje + "\r\n" + "\r\n" + "Dirigido a :" + myWorkFlow.ENTEDESTINO;
                    lcMensaje = lcMensaje + "\r\n" + "\r\n" + "Asunto :" + myWorkFlow.OBSERVACION;
                    lcMensaje = lcMensaje + "\r\n" + "\r\n" + "Nosotros ya tramitamos la respuesta a su solicitud con el número de radicado saliente :" + lcRadicado;
                    lcMensaje = lcMensaje + "\r\n" + "\r\n" + "Con la respuesta siguiente :" + myWorkFlow.RESPUESTA;
                    lcMensaje = lcMensaje + "\r\n" + "\r\n" + "Se adjunta documento oficial de la respuesta ";
                    lcMensaje = lcMensaje + "\r\n" + "\r\n" + "El documento escrito se encuentra en nuestras instalaciones para que pase por el en cualquier momento";
                    lcMensaje = lcMensaje + "\r\n" + "\r\n";
                    lcMensaje = lcMensaje + "\r\n" + "\r\n" + "Gracias por su Atencion";



                    break;


            }

            string lcEnvio = Enviar.enviarCorreo(DatosCorreo.conficor.EMAIL, DatosCorreo.conficor.CONTRASENA, lcMensaje, lcAsunto, DatosCorreo.EMAIL, lcAdjunto,DatosCorreo.conficor.SERVPOPSALIENTE);


        }

        protected void btn_cargar_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(@"C:\gestion_documental_WF\gestion_documental_WF.application");
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            Process.Start(startInfo);
        }

        protected void btn_actualizar_Click(object sender, EventArgs e)
        {
            DirectoryInfo folder = new DirectoryInfo(Server.MapPath(SessionDocumental.UsuarioInicioSession.USUARIO));
            DataTable dt_archivos = new DataTable("archivos");
            dt_archivos.Columns.Add("archivo");
            foreach (FileInfo file in folder.GetFiles())
            {
                dt_archivos.Rows.Add(file.Name);
            }
            grd_archivos.DataSource = dt_archivos;
            grd_archivos.DataBind();
        }

        protected void btn_registrar_Click(object sender, EventArgs e)
        {
            DirectoryInfo folder = new DirectoryInfo(Server.MapPath(SessionDocumental.UsuarioInicioSession.USUARIO));
            foreach (FileInfo file in folder.GetFiles())
            {
                // AQUI SE DEBE INSERTAR EN LA BASE DE DATOS LA INFORMACION DE LOS DOCUMENTOS




                Workflow NuevoWorkflow = new WorkFlowManagement().GetWorkflowByIddocumento(SessionDocumental.ObjDocumento.idDOCUMENTOS);

                //Creamos DOcumentos


                
                Documentos Docsinicial = SessionDocumental.ObjDocumento as Documentos;




                Documentos Docs = new Documentos();
                Docs.CAMINO = carpetaDestino;
                Docs.DESCRIPCION = "Anexos " + NuevoWorkflow.RADICADO;
                Docs.DOCUMENTO = file.Name.Substring(0, file.Name.ToString().Length - 4) + "-" + NuevoWorkflow.RADICADO + file.Name.Substring(file.Name.ToString().Length - 3,3);
                Docs.FOLIOS = 0;
                Docs.ANEXOS = "";
                Docs.IDENTE = NuevoWorkflow.IDENTEDESTINO;
                Docs.IDEXPEDIENTE = Docsinicial.IDEXPEDIENTE;
               

                int idddocs = new DocumentosManagement().InsertDocumentos(Docs);
 

                // Creamos Lindock
                LinkDoc LinkdocAdicional = new LinkDoc();
                LinkdocAdicional.IDDOCUMENTOS = idddocs;
                LinkdocAdicional.IDENTE = Docsinicial.IDENTE;
                
                new LinkDocManagement().InsertLinkDoc(LinkdocAdicional);

                // Creamos Workflow

                ;

                NuevoWorkflow.iddocumento = idddocs;

                new WorkFlowManagement().InsertWorkflow(NuevoWorkflow);
                string lcArchivoDestino = Server.MapPath(carpetaDestino) + "\\" + file.Name.Substring(0, file.Name.ToString().Length - 4) + "-" + NuevoWorkflow.RADICADO + file.Name.Substring(file.Name.ToString().Length - 3, 3);

                file.MoveTo(lcArchivoDestino);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
         {
            Workflow WorkflowDoc = new WorkFlowManagement().GetWorkflowByIddocumento(SessionDocumental.ObjDocumento.idDOCUMENTOS);

            var listaDocumentosPorCargar = new DocumentoActividadManagement().GetAllDocumentoByActividadFaltantes(Convert.ToInt32(ddlActividad.SelectedValue), WorkflowDoc.IDCADENA);

            if(listaDocumentosPorCargar.Count()==0)
            {
                Response.Redirect("RecepDocFisico.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe Adjuntar todos los documentos del radicado');", true);
            }
            //Documentos DocSinNombre = new DocumentosManagement().GetDocumentosById2(SessionDocumental.ObjDocumento.idDOCUMENTOS);
            //if (DocSinNombre.DOCUMENTO != "")
            //{
            //    Response.Redirect("RecepDocFisico.aspx");
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe Adjuntar el pdf radicado');", true);
            //}

        }


        protected void btnFileUpload_Click1(object sender, EventArgs e)
        {
            if (ddlDocumentoActividad.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe seleccionar un nombre de documento');", true);
                return;
            }
            Workflow NuevoWorkflow = new WorkFlowManagement().GetWorkflowByIddocumento(SessionDocumental.ObjDocumento.idDOCUMENTOS);

            //Creamos DOcumentos



            Documentos Docsinicial = SessionDocumental.ObjDocumento as Documentos;




            Documentos Docs = new Documentos();
            Docs.CAMINO = carpetaDestino;
            Docs.DESCRIPCION = "Anexos " + NuevoWorkflow.RADICADO;
            Docs.DOCUMENTO = file_upload.FileName.Substring(0, file_upload.FileName.ToString().IndexOf(".")) + "-" + NuevoWorkflow.RADICADO + file_upload.FileName.Substring(file_upload.FileName.ToString().IndexOf("."));
            Docs.FOLIOS = 0;
            Docs.ANEXOS = "";
            Docs.IDENTE = NuevoWorkflow.IDENTEDESTINO;
            Docs.IDEXPEDIENTE = Docsinicial.IDEXPEDIENTE;
            Docs.iddocumentoactividad =Convert.ToInt32(ddlDocumentoActividad.SelectedValue);

            int idddocs = new DocumentosManagement().InsertDocumentos(Docs);


            // Creamos Lindock
            LinkDoc LinkdocAdicional = new LinkDoc();
            LinkdocAdicional.IDDOCUMENTOS = idddocs;
            LinkdocAdicional.IDENTE = Docsinicial.IDENTE;

            new LinkDocManagement().InsertLinkDoc(LinkdocAdicional);

            // Creamos Workflow

            ;

            NuevoWorkflow.iddocumento = idddocs;

            new WorkFlowManagement().InsertWorkflow(NuevoWorkflow);
            string lcArchivoDestino = Server.MapPath(carpetaDestino) + "\\" + file_upload.FileName.Substring(0, file_upload.FileName.ToString().IndexOf(".")) + "-" + NuevoWorkflow.RADICADO + file_upload.FileName.Substring(file_upload.FileName.ToString().IndexOf(".")); 

            file_upload.SaveAs(lcArchivoDestino);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Archivo Anexado con Exito..');", true);
            gvDocumento.DataSource = new DocumentosManagement().GetDocumentosNombrebyListaiD(NuevoWorkflow.IDCADENA).Where(y=>y.documentoactividad.NOMBREDOCUMENTO!=null).Select(x => new { TIPODOC = x.documentoactividad.NOMBREDOCUMENTO, NOMBREDOC = x.DOCUMENTO } ).ToList();
            gvDocumento.DataBind();
            llenarDocumentoActividad();

        }

        protected void ddlProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlActividad.DataSource = new ActividadManagement().GetAllActividadByProceso(Convert.ToInt32(ddlProceso.SelectedValue));
            ddlActividad.DataValueField = "ID";
            ddlActividad.DataTextField = "ACTIVIDAD";

            ddlActividad.DataBind();

            ddlActividad.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }

        public void llenarDocumentoActividad()
        {
            ddlDocumentoActividad.DataSource = null;
            Workflow WorkflowDoc = new WorkFlowManagement().GetWorkflowByIddocumento(SessionDocumental.ObjDocumento.idDOCUMENTOS);
            var ListaDocumentos = new DocumentoActividadManagement().GetAllDocumentoByActividadFaltantes(Convert.ToInt32(ddlActividad.SelectedValue),WorkflowDoc.IDCADENA);
            ddlDocumentoActividad.DataSource = ListaDocumentos;
            ddlDocumentoActividad.DataValueField = "ID";
            ddlDocumentoActividad.DataTextField = "NOMBREDOCUMENTO";

            ddlDocumentoActividad.DataBind();

            ddlDocumentoActividad.Items.Insert(0, new ListItem("Seleccionar", "0"));

            if(ListaDocumentos.Count()==0)
            {
                Button1.Enabled = true;
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            llenarDocumentoActividad();
            DivContenidoCargarDocumento.Enabled = true;
            if (SessionDocumental.ObjDocumento.idDOCUMENTOS != 0)
            {

                Label1.Text = "NO SE HA DIGITALIZADO EL DOCUMENTO DEL RADICADO :" + SessionDocumental.ObjDocumento.RADICADO;

            }
            else
            {
                Label1.Text = "";
            }
            Workflow WorkflowDoc = new WorkFlowManagement().GetWorkflowByIddocumento(SessionDocumental.ObjDocumento.idDOCUMENTOS);
            WorkflowDoc.idactividad =Convert.ToInt32(ddlActividad.SelectedValue);
            new WorkFlowManagement().UpdateWorkflow(WorkflowDoc);
            receptor = new EmiRecepManagement().GetEmiRecepByIdusuario(SessionDocumental.UsuarioInicioSession.CODIGO);
            carpetaOrigen = receptor.conficor.CAMINOSCANNER;
            carpetaDestino = receptor.conficor.CAMINODESCARGA;
            carpetatemp = receptor.conficor.CARPETATEMP;
            if (SessionDocumental.ObjWorkflow != null)
            {
                gvDocumento.DataSource = new DocumentosManagement().GetDocumentosNombrebyListaiD(SessionDocumental.ObjWorkflow.IDCADENA).Where(y => y.documentoactividad.NOMBREDOCUMENTO != null).Select(x => new { TIPODOC = x.documentoactividad.NOMBREDOCUMENTO, NOMBREDOC = x.DOCUMENTO }).ToList();
                gvDocumento.DataBind();
            }
        }





        //protected void crearDocumento()
        //{

        //    EmiRecep receptor = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(ddlDe.SelectedValue.ToString()));
        //    EmiRecep receptornuevo = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(ddlPara.SelectedValue.ToString()));
        //    EmiRecep receptorventanilla = new EmiRecepManagement().GetEmiRecepByCodUsuario(Convert.ToInt32(SessionDocumental.UsuarioInicioSession.CODIGO.ToString()));
        //    carpetaDestino = receptorventanilla.conficor.CAMINODESCARGA;

        //    documento = new Documentos();
        //    documento.IDSERIE = 0;
        //    documento.IDSUBSERIE = 0;
        //    documento.IDTIPOLOGIA = 0;
        //    documento.IDEXPEDIENTE = 0;
        //    documento.FOLIOS = Convert.ToInt32(TxtFolios.Text);
        //    documento.ANEXOS = txtAnexos.Text;
        //    documento.DOCUMENTO = "";// txtDoc.Text;
        //    documento.CAMINO = carpetaDestino.Replace("\\", "/");
        //    documento.DESCRIPCION = TxtObservacion.Text;

        //    documento.IDENTE = 0;

        //    documento.idDOCUMENTOS = new DocumentosManagement().InsertDocumentos(documento);

        //    SessionDocumental.ObjDocumento = documento;


        //    // Inserta indices
        //    for (int iInd = 0; iInd < lista.Items.Count; iInd++)
        //    {
        //        Indices indice = new Indices();
        //        indice.ATRIBUTO = "";
        //        indice.iddocumento = documento.idDOCUMENTOS;
        //        indice.INDICE = lista.Items[iInd].Text;
        //        new IndicesManagement().InsertIndices(indice);
        //    }


        //    // Insertamos en links el de la ventanilla y el nuevo

        //    //de            
        //    LinkDoc links = new LinkDoc();
        //    links.IDDOCUMENTOS = documento.idDOCUMENTOS;
        //    links.IDENTE = receptor.IDENTE;
        //    new LinkDocManagement().InsertLinkDoc(links);

        //    //Ventanilla 
        //    links = new LinkDoc();
        //    links.IDDOCUMENTOS = documento.idDOCUMENTOS;
        //    links.IDENTE = receptorventanilla.IDENTE;
        //    new LinkDocManagement().InsertLinkDoc(links);

        //    /*
        //    string lcDestino = @Util.PathDocumentosTEMP;
        //    if (carpetatemp != "")
        //    {
        //        lcDestino = lcDestino + "//" + carpetatemp;
        //    }
        //    ManejoArchivos.EliminarArchivo(lcDestino, txtDoc.Text);
        //    */
        //}

        //protected int crearWorkfow(int lnIdCadena, EmiRecep receptorDestino)
        //{

        //    workflow = new Workflow();

        //    EmiRecep receptorOrigen = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(ddlDe.SelectedValue.ToString()));

        //    workflow.IDENTEORIGEN = Convert.ToInt32(receptorOrigen.IDENTE);
        //    workflow.IDENTEDESTINO = Convert.ToInt32(receptorDestino.IDENTE);

        //    workflow.FECHA = DateTime.Now;
        //    workflow.iddocumento = SessionDocumental.ObjDocumento.idDOCUMENTOS;
        //    workflow.RADICADO = txtRadicado.Text;
        //    workflow.IDRADICADO = SessionDocumental.ObjRadicado.idradicados;
        //    workflow.IDTAREA = 1;
        //    workflow.IDTIPOLOGIA = 0;
        //    workflow.DIAS = new ConfigwfManagement().GetConfigwfById(SessionDocumental.ObjEmisorDestino.IDENTE).DIAS;
        //    workflow.ESTADO = "1. PENDIENTE";
        //    workflow.SEMAFORO = new TipocomManagement().GetTipocomIdPrincipal(Convert.ToInt32(DmpSemaforo.SelectedItem.Value)).TIPOCOMUNICACION;
        //    workflow.IDTIPOCOM = Convert.ToInt32(DmpSemaforo.SelectedItem.Value);
        //    workflow.CODIGOUSUARIO = SessionDocumental.UsuarioInicioSession.CODIGO;

        //    if (Session["idcadena"] == null)
        //    {
        //        workflow.IDCADENA = lnIdCadena;
        //    }
        //    else
        //    {
        //        workflow.IDCADENA = Convert.ToInt32(Session["idcadena"]);
        //    }

        //    if (receptorOrigen.IDTIPOEMISOR == 3 || receptorOrigen.IDTIPOEMISOR == 5)
        //    {
        //        workflow.IDEMIRECEP = Convert.ToInt32(DdlEmisor.Text);
        //    }
        //    else
        //    {
        //        workflow.IDEMIRECEP = Convert.ToInt32(ddlDe.SelectedValue.ToString());
        //    }

        //    workflow.OBSERVACION = TxtObservacion.Text;
        //    //EmiRecep EMIDESTINO = new EmiRecepManagement().GetEmiRecepJefe(Convert.ToInt32(ddlPara.SelectedValue.ToString()));

        //    if (receptorDestino.IDTIPOEMISOR == 3 || receptorDestino.IDTIPOEMISOR == 5)
        //    {
        //        workflow.IDEMIDESTINO = Convert.ToInt32(DdlEmisor.Text);
        //    }
        //    else
        //    {
        //        workflow.IDEMIDESTINO = Convert.ToInt32(receptorDestino.ID);
        //    }
        //    workflow.RESPUESTA = TextBox2.Text;
        //    workflow.FECHARESPUESTA = System.DateTime.Now;
        //    workflow.RADICADO2 = TextBox1.Text;
        //    if (host == "localhost")
        //    {
        //        workflow.LOCAL = 1;
        //    }
        //    else
        //    {
        //        workflow.LOCAL = 0;
        //    }
        //    int idworkflow = new WorkFlowManagement().InsertWorkflow(workflow);
        //    SessionDocumental.ObjWorkflow = workflow;

        //    //** Si tiene respuesta actualizamos la respuesta
        //    if (Convert.ToInt32(Session["idworkrespuesta"].ToString()) != 0)
        //    {
        //        Workflow Workflowrespuesta = new Workflow();
        //        Workflowrespuesta = new WorkFlowManagement().GetWorkflowById(Convert.ToInt32(Session["idworkrespuesta"].ToString()));
        //        Workflowrespuesta.RADICADO2 = txtRadicado.Text;
        //        Workflowrespuesta.RESPUESTA = TextBox2.Text;
        //        Workflowrespuesta.FECHARESPUESTA = System.DateTime.Now;

        //        new WorkFlowManagement().UpdateWorkflow(Workflowrespuesta);
        //        // Con esto correjimos lo de workflow

        //        proce.editar("workflow", "respuesta='" + TextBox2.Text + "',radicado2='" + txtRadicado.Text + "',fecharespuesta='" + proce.formateafecha(System.DateTime.Now) + "',estado = '5. FINALIZADO'", "radicado ='" + TextBox1.Text + "'");

        //    }

        //    // Para la nueva oficina

        //    LinkDoc links = new LinkDoc();
        //    links.IDDOCUMENTOS = SessionDocumental.ObjDocumento.idDOCUMENTOS;
        //    links.IDENTE = receptorDestino.IDENTE;
        //    new LinkDocManagement().InsertLinkDoc(links);

        //    //Response.Redirect("RecepDocFisico.aspx");
        //    return idworkflow;
        //}
    }
}