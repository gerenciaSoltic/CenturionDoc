using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Word = Microsoft.Office.Interop.Word;
using System.Data;
using gestion_documental.codigo;
using System.IO;
using gestion_documental.Utils;
using gestion_documental.BusinessObjects;
using gestion_documental.DataAccessLayer;

namespace gestion_documental
{
    public partial class EnviarCircular : BasePage
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
        string carpetatemp = "";
        EmiRecep receptor;
        DataTable dataLista = new DataTable();
        string ruta_guardar = "";

        Class1 proc = new Class1();
        string srt_session_list_circular = "zx287jnas";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ConfigurarPadrePostBack(this.Msj, this.usuarioLabel);
            //receptor = new EmiRecepManagement().GetEmiRecepByIdusuario(SessionDocumental.UsuarioInicioSession.CODIGO);
            try
            {
                receptor = new EmiRecepManagement().GetEmiRecepByIdusuario(SessionDocumental.UsuarioInicioSession.CODIGO);
                ruta_guardar = receptor.conficor.CAMINODESCARGA;
                if (ruta_guardar.Trim().Length == 0) { mostrar_mensaje_usuario("El usuario no cuenta con una ruta de archivo para guardar la circular! ..."); }
            }
            catch (Exception error) { string que_paso = error.Message; }

            if (!IsPostBack) { llenar_formulario(); }
        }


        private void llenar_formulario()
        {
            try
            {

                ddlDe.DataSource = new EmiRecepManagement().GetAllFuncionarios(receptor.IDRADICADO);
                ddlDe.DataValueField = "IDEMIRECEP";
                ddlDe.DataTextField = "FUNCIONARIO";
                ddlDe.DataBind();
                ddlDe.SelectedValue = receptor.ID.ToString();
                ddlDe.Items.Insert(0, new ListItem("Seleccionar", "0"));


                ddlPara.DataSource = new EmiRecepManagement().GetAllFuncionarios(receptor.IDRADICADO);
                ddlPara.DataValueField = "IDEMIRECEP";
                ddlPara.DataTextField = "FUNCIONARIO";
                ddlPara.DataBind();
                ddlPara.Items.Insert(0, new ListItem("Seleccionar", "0"));

            }
            catch (Exception Error) { string que_paso = Error.Message; }
        }





        protected void btn_agregar_envio_Click(object sender, EventArgs e)
        {
            if (ddlPara.SelectedIndex > 0)
            {
                var srt_found = LstDestinos.Items.FindByValue(ddlPara.SelectedValue);

                if (srt_found == null)
                {
                    LstDestinos.Items.Add(new ListItem { Value = ddlPara.SelectedValue, Text = ddlPara.SelectedValue + " - " + ddlPara.SelectedItem.Text });
                }
            }
        }

        protected void btn_quitar_envio_Click(object sender, EventArgs e)
        {
            if (LstDestinos.SelectedIndex >= 0)
            {
                LstDestinos.Items.RemoveAt(LstDestinos.SelectedIndex);
            }
        }

        protected void btn_buscarcircular_Click(object sender, ImageClickEventArgs e)
        {
            buscar_circular();
        }

        protected void btbuscarenelpanel_Click(object sender, EventArgs e)
        {
            buscar_circular(Txtbuscarenelpanel.Text.Trim());
        }

        private void buscar_circular(string buscar = "")
        {
            try
            {


                DataTable dt_consulta = new DataTable();
                proc.consultacamposcondicion("circular", "id, plantilla, consecutivo, substring(fecregistro,1,10) AS fecha", "idinstitucion = '" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION.ToString() + "' AND IDENTE = '" + receptor.IDENTE.ToString() + "'   " +
                    (buscar.Trim().Length > 0 ? "AND (plantilla LIKE '%" + buscar.Trim() + "%' OR consecutivo LIKE '%" + buscar.Trim() + "%')" : ""), dt_consulta);

                Session[srt_session_list_circular] = dt_consulta;
                gvpanel.DataSource = dt_consulta;
                gvpanel.DataBind();

                HiddenField1_ModalPopupExtender.Show();
            }
            catch (Exception error)
            {
                string que_paso = error.Message;
                mostrar_mensaje_usuario("ERROR BÚSQUEDA DE CIRCULARES ...");
            }
        }

        protected void gvpanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvpanel.SelectedIndex >= 0)
            {
                txtRadicado.Text = gvpanel.SelectedDataKey["consecutivo"].ToString();
                hidde_id_circular.Value = gvpanel.SelectedDataKey["id"].ToString();
            }
        }

        protected void gvpanel_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                if (Session[srt_session_list_circular] != null)
                {
                    gvpanel.PageIndex = e.NewPageIndex;
                    gvpanel.DataSource = (DataTable)Session[srt_session_list_circular];
                    gvpanel.DataBind();
                    HiddenField1_ModalPopupExtender.Show();
                }
            }
            catch (Exception error) { string que_paso = error.Message; }
        }


        protected void btn_enviar_Click(object sender, EventArgs e)
        {

            try
            {
                if (!(hidde_id_circular.Value.Trim().Length > 0)) { mostrar_mensaje_usuario("No hay circular seleccionado! ..."); return; }
                if (!(ddlDe.SelectedIndex > 0)) { mostrar_mensaje_usuario("Seleccione el remitente ..."); return; }

                if (LstDestinos.Items.Count == 0)
                {
                    if (!(ddlPara.SelectedIndex > 0)) { mostrar_mensaje_usuario("Seleccione el destino ..."); return; }
                }

                if (!(txt_Asunto.Text.Trim().Length > 0)) { mostrar_mensaje_usuario("Especifique el asunto ..."); return; }

                if (FileUpload1.HasFile)
                {
                    string nombre_archivo = txtRadicado.Text.Trim() + ".pdf";
                    string ruta_completa = getConcatenarRutaGuardar(nombre_archivo);


                    EliminarFichero(ruta_completa);//Eliminamos la que esta sin firma
                    FileUpload1.SaveAs(ruta_completa); //Reemplazamos por la que tiene firma, escaneada

                    if (validarExistenciaArchivo(ruta_completa))
                    {

                        Cadenas MyCadena = new Cadenas();
                        MyCadena.FECHA = DateTime.Now;
                        int lnIdCadena = new CadenasManagement().InsertCadenas(MyCadena);
                        crearDocumento();
                        int idworkflow = 0;


                        if (LstDestinos.Items.Count == 0)
                        {
                            EmiRecep receptorDestino = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(ddlPara.SelectedValue.ToString()));
                            idworkflow = crearWorkfow(lnIdCadena, receptorDestino);
                        }
                        else
                        {
                            for (int ides = 0; ides < LstDestinos.Items.Count; ides++)
                            {
                                string srt_cadena = LstDestinos.Items[ides].Value;
                                EmiRecep receptorDestino = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(srt_cadena));
                                idworkflow = crearWorkfow(lnIdCadena, receptorDestino);
                            }
                        }

                        hidde_id_circular.Value = string.Empty;
                        txtRadicado.Text = string.Empty;
                        ddlDe.SelectedIndex = 0;
                        ddlPara.SelectedIndex = 0;
                        LstDestinos.Items.Clear();
                        txt_Asunto.Text = string.Empty;

                        mostrar_mensaje_usuario("El documento ( " + nombre_archivo + ")" + ", ha sido enviado ...");
                    }
                    else { mostrar_mensaje_usuario("No se pudo subir el archivo ..."); }
                }
                else
                {
                    mostrar_mensaje_usuario("POR FAVOR SELECCIONE LE PDF ESCANEADO CON LA FIRMA ...");
                }

            }
            catch (Exception Error) { string que_paso = Error.Message; mostrar_mensaje_usuario("SE PRESENTO UN ERROR EN ENVIO ..."); }
        }

        protected void crearDocumento()
        {

            EmiRecep receptor = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(ddlDe.SelectedValue.ToString()));
            EmiRecep receptornuevo = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(ddlPara.SelectedValue.ToString()));
            EmiRecep receptorventanilla = new EmiRecepManagement().GetEmiRecepByCodUsuario(Convert.ToInt32(SessionDocumental.UsuarioInicioSession.CODIGO.ToString()));
            carpetaDestino = receptorventanilla.conficor.CAMINODESCARGA;

            documento = new Documentos();
            documento.IDSERIE = 0;
            documento.IDSUBSERIE = 0;
            documento.IDTIPOLOGIA = 0;
            documento.IDEXPEDIENTE = 0;
            documento.FOLIOS = 0;
            documento.ANEXOS = "";
            documento.DOCUMENTO = txtRadicado.Text.Trim() + "pdf"; ;
            documento.CAMINO = carpetaDestino.Replace("\\", "/");
            documento.DESCRIPCION = txt_Asunto.Text.Trim();
            documento.IDENTE = 0;
            documento.idDOCUMENTOS = new DocumentosManagement().InsertDocumentos(documento);

            SessionDocumental.ObjDocumento = documento;

            //// Inserta indices
            //for (int iInd = 0; iInd < lista.Items.Count; iInd++)
            //{
            Indices indice = new Indices();
            indice.ATRIBUTO = "";
            indice.iddocumento = documento.idDOCUMENTOS;
            indice.INDICE = "CIRCULAR";
            new IndicesManagement().InsertIndices(indice);

            indice = new Indices();
            indice.ATRIBUTO = "";
            indice.iddocumento = documento.idDOCUMENTOS;
            indice.INDICE = txtRadicado.Text.Trim().ToUpper();
            new IndicesManagement().InsertIndices(indice);

            indice = new Indices();
            indice.ATRIBUTO = "";
            indice.iddocumento = documento.idDOCUMENTOS;
            indice.INDICE = txt_Asunto.Text.Trim().ToUpper();
            new IndicesManagement().InsertIndices(indice);
            //}

            // Insertamos en links el de la ventanilla y el nuevo

            //de            
            LinkDoc links = new LinkDoc();
            links.IDDOCUMENTOS = documento.idDOCUMENTOS;
            links.IDENTE = receptor.IDENTE;
            new LinkDocManagement().InsertLinkDoc(links);

            //Ventanilla 
            links = new LinkDoc();
            links.IDDOCUMENTOS = documento.idDOCUMENTOS;
            links.IDENTE = receptorventanilla.IDENTE;
            new LinkDocManagement().InsertLinkDoc(links);

            string id_circular = hidde_id_circular.Value.Trim();
            proc.editar("circular", "iddocumento = '" + documento.idDOCUMENTOS.ToString() + "'", "id = '" + id_circular + "'");
        }

        protected int crearWorkfow(int lnIdCadena, EmiRecep receptorDestino)
        {

            workflow = new Workflow();


            EmiRecep receptorOrigen = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(ddlDe.SelectedValue.ToString()));


            workflow.IDENTEORIGEN = Convert.ToInt32(receptorOrigen.IDENTE);
            workflow.IDENTEDESTINO = Convert.ToInt32(receptorDestino.IDENTE);

            workflow.FECHA = DateTime.Now;
            workflow.iddocumento = SessionDocumental.ObjDocumento.idDOCUMENTOS;
            workflow.RADICADO = txtRadicado.Text.Trim();
            workflow.IDRADICADO = 0;
            workflow.IDTAREA = 1;
            workflow.IDTIPOLOGIA = 0;
            if (SessionDocumental.ObjEmisorDestino != null)
            {
                workflow.DIAS = new ConfigwfManagement().GetConfigwfById(SessionDocumental.ObjEmisorDestino.IDENTE).DIAS;
            }
            else { workflow.DIAS = 0; }

            workflow.ESTADO = "1. PENDIENTE";
            workflow.SEMAFORO = new TipocomManagement().GetTipocomIdPrincipal(71).TIPOCOMUNICACION;
            workflow.IDTIPOCOM = 0;

            if (Session["idcadena"] == null) { workflow.IDCADENA = lnIdCadena; }
            else { workflow.IDCADENA = Convert.ToInt32(Session["idcadena"]); }


            //if (receptorOrigen.IDTIPOEMISOR == 3 || receptorOrigen.IDTIPOEMISOR == 5)
            //{
            //    workflow.IDEMIRECEP = Convert.ToInt32(DdlEmisor.Text);
            //}
            //else
            //{
            workflow.IDEMIRECEP = Convert.ToInt32(ddlDe.SelectedValue.ToString());
            //}
            workflow.OBSERVACION = txt_Asunto.Text.Trim();
            //EmiRecep EMIDESTINO = new EmiRecepManagement().GetEmiRecepJefe(Convert.ToInt32(ddlPara.SelectedValue.ToString()));

            //if (receptorDestino.IDTIPOEMISOR == 3 || receptorDestino.IDTIPOEMISOR == 5)
            //{
            //    workflow.IDEMIDESTINO = Convert.ToInt32(DdlEmisor.Text);
            //}
            //else
            //{
            workflow.IDEMIDESTINO = Convert.ToInt32(receptorDestino.ID);
            //}

            //workflow.RESPUESTA = TextBox2.Text;
            //workflow.FECHARESPUESTA = System.DateTime.Now;
            //workflow.RADICADO2 = TextBox1.Text;
            int idworkflow = new WorkFlowManagement().InsertWorkflow(workflow);
            SessionDocumental.ObjWorkflow = workflow;

            ////** Si tiene respuesta actualziamos la resuesta
            //if (Convert.ToInt32(Session["idworkrespuesta"].ToString()) != 0)
            //{
            //    Workflow Workflowrespuesta = new Workflow();
            //    Workflowrespuesta = new WorkFlowManagement().GetWorkflowById(Convert.ToInt32(Session["idworkrespuesta"].ToString()));
            //    Workflowrespuesta.RADICADO2 = txtRadicado.Text;
            //    //Workflowrespuesta.RESPUESTA = TextBox2.Text;
            //    Workflowrespuesta.FECHARESPUESTA = System.DateTime.Now;

            //    new WorkFlowManagement().UpdateWorkflow(Workflowrespuesta);
            //}

            // Para la nueva oficina


            LinkDoc links = new LinkDoc();
            links.IDDOCUMENTOS = SessionDocumental.ObjDocumento.idDOCUMENTOS;
            links.IDENTE = receptorDestino.IDENTE;
            new LinkDocManagement().InsertLinkDoc(links);

            //Response.Redirect("RecepDocFisico.aspx");
            return idworkflow;
        }

        private void mostrar_mensaje_usuario(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('" + mensaje + "');", true);
        }

        private void set_DropDowList(DropDownList item, DataTable objeto, string id, string text, bool con_select = false)
        {
            item.DataSource = objeto;
            item.DataValueField = id;
            item.DataTextField = text;
            item.DataBind();

            if (con_select)
            {
                item.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }
        }

        private string get_numeral_consecutivo(int numero, int n_digitos = 11)
        {
            string srt_consecutivo = "";
            //int n_digitos = 11;
            int n_digito_numero = numero.ToString().Trim().Length;

            for (int i = 1; i <= n_digitos; i++) { if (n_digito_numero < i) { srt_consecutivo += "0"; } }
            srt_consecutivo += numero.ToString();

            return srt_consecutivo;
        }

        //---------------------------------------------------------
        protected string getConcatenarRutaGuardar(string fichero)
        {
            string Respuesta = "";
            try
            {
                string ruta_temp = ruta_guardar;
                if (fichero != null) { ruta_temp = Path.Combine(ruta_guardar, fichero); }
                Respuesta = HttpContext.Current.Server.MapPath(ruta_temp);
            }
            catch (Exception Error) { string que_paso = Error.Message; Respuesta = ""; }


            return Respuesta;
        }
        public bool EliminarFichero(string url_completa)
        {
            bool Respuesta = false;
            try
            {
                if (validarExistenciaArchivo(url_completa))
                {
                    string ruta_completa = Path.GetFullPath(url_completa);
                    File.Delete(ruta_completa);
                    Respuesta = true;
                }
            }
            catch (Exception Error) { string que_paso = Error.Message; Respuesta = false; }

            return Respuesta;
        }
        public bool validarExistenciaArchivo(string url_completa)
        {
            bool Respuesta = false;
            try
            {
                string ruta_completa = Path.GetFullPath(url_completa);
                Respuesta = File.Exists(ruta_completa);
            }
            catch (Exception error) { string que_paso = error.Message; Respuesta = false; }
            return Respuesta;
        }
        private void funcion_descargar_fichero(string archivo_ruta_completa)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenWindow", "window.open('" + Page.ResolveUrl("~/descargar.aspx?file=" + Server.UrlEncode(archivo_ruta_completa)) + "','_newtab');", true);
        }
        private void funcion_mostrar_pdf(string archivo)
        {
            Response.Redirect("~/plantilla/TMP/" + archivo, "_blank", "menubar=0,scrollbars=1,width=850,height=700,top=10");
        }

        //Funciones para obtener valores sin errores--------------------------------
        private double get_double(string valor)
        {
            try { return (valor.Trim().Length > 0 ? Convert.ToDouble(valor) : 0); }
            catch { return 0; }
        }
        //
        private Int32 get_int(string valor)
        {
            try { return (valor.Trim().Length > 0 ? Convert.ToInt32(valor) : 0); }
            catch { return 0; }
        }













        //--------------------------------------------------------------------------
    }
}