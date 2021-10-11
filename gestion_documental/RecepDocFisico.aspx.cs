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
using System.ComponentModel;



namespace gestion_documental
{
    public partial class RecepDocFisico : BasePage
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
        string host = HttpContext.Current.Request.Url.Host;
        Class1 proce = new Class1();

        protected void Page_Load(object sender, EventArgs e)
        {

            this.ConfigurarPadrePostBack(this.Msj, this.usuarioLabel);

            Documentos mydocumento = new DocumentosManagement().GetDocumentosbyNotDigital();

            if (mydocumento.idDOCUMENTOS != 0)
            {
                SessionDocumental.ObjDocumento = mydocumento;
                Response.Redirect("ArchivoRecepcion.aspx");
            }
            if (!IsPostBack)
            {
                if (Session["idworkrespesta"] == null)
                {
                    Session.Add("idworkrespuesta", 0);

                }
                else
                {
                    Session["idworkrespuesta"] = 0;
                }

                FillGvrRecepDoc();

            }
            receptor = new EmiRecepManagement().GetEmiRecepByIdusuario(SessionDocumental.UsuarioInicioSession.CODIGO);
            carpetaOrigen = receptor.conficor.CAMINOSCANNER;
            carpetaDestino = receptor.conficor.CAMINODESCARGA;
            carpetatemp = receptor.conficor.CARPETATEMP;
        }

        public void FillGvrRecepDoc()
        {
            receptor = new EmiRecepManagement().GetEmiRecepByIdusuario(SessionDocumental.UsuarioInicioSession.CODIGO);

            ddlDe.DataSource = new EmiRecepManagement().GetAllFuncionarios(receptor.IDRADICADO);
            ddlDe.DataValueField = "IDEMIRECEP";
            ddlDe.DataTextField = "FUNCIONARIO";
            ddlDe.DataBind();
            ddlDe.SelectedValue = receptor.ID.ToString();

            ddlPara.DataSource = new EmiRecepManagement().GetAllFuncionarios(receptor.IDRADICADO);
            ddlPara.DataValueField = "IDEMIRECEP";
            ddlPara.DataTextField = "FUNCIONARIO";
            ddlPara.DataBind();
            ddlPara.Items.Insert(0, new ListItem("Seleccionar", "0"));

            DDLGrupoCom.DataTextField = "nombre";
            DDLGrupoCom.DataValueField = "id";
            DDLGrupoCom.DataSource = new grupocomManagement().GetGrupocomByIdradicado(receptor.IDRADICADO);

            DDLGrupoCom.DataBind();
            DDLGrupoCom.Items.Insert(0, new ListItem("0. Seleccionar"));

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
            **/
        }

        protected void ddlPara_SelectedIndexChanged(object sender, EventArgs e)
        {
            obtieneRadicado();
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


        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            
            if (DmpSemaforo.SelectedValue.ToString() == "0. Seleccionar")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe elegir un tipo de Documento..');", true);
                return;
            }
            if (lista.Items.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe Registrar al menos una palabra clave de indice..');", true);
                return;
            }
            if (TxtFolios.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe Indicar el numero de folios..');", true);
                return;
            }
            if (DdlEmisor.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe Seleccionar un Emisor..');", true);
                return;
            }
            if (TxtObservacion.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe ingresar un asunto..');", true);
                return;
            }

            EmiRecep RecepDestino = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(ddlPara.SelectedValue.ToString()));
            string radrespemi = "";
            proce.consultauncampocondicion("tipoemirec", "radresp", " id=" + RecepDestino.IDTIPOEMISOR, ref radrespemi);

            string radrespcom = "";
            proce.consultauncampocondicion("grupocom", "radresp", " id=" + DDLGrupoCom.SelectedValue, ref radrespcom);

            if (radrespemi == "1")
            {
                if (TextBox1.Text == "" || TextBox2.Text == "")
                {
                    if (radrespcom == "1")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe ingresar un radicado de respuesta..');", true);
                        return;
                    }
                }
            }

            btnGuardar.Enabled = false;

            Cadenas MyCadena = new Cadenas();
            MyCadena.FECHA = DateTime.Now;
            int lnIdCadena = new CadenasManagement().InsertCadenas(MyCadena);
            crearDocumento();
            int idworkflow = 0;
            obtieneRadicado();
            if (LstDestinos.Items.Count == 0)
            {
                EmiRecep receptorDestino = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(ddlPara.SelectedValue.ToString()));
                idworkflow = crearWorkfow(lnIdCadena, receptorDestino);
            }
            else
            {
                for (int ides = 0; ides < LstDestinos.Items.Count; ides++)
                {
                    EmiRecep receptorDestino = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(LstDestinos.Items[ides].Text.Substring(0, LstDestinos.Items[ides].Text.IndexOf("-"))));
                    idworkflow = crearWorkfow(lnIdCadena, receptorDestino);
                }
            }
            //inserta radicados
            new RadicadosManagement().UpdateRadicados(SessionDocumental.ObjRadicado);

            //deshabilitamos el boton


            Response.Redirect("ConfiguraPag1.aspx?idworkflow=" + idworkflow);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Radicado Exitoso..');", true);
            DmpSemaforo.SelectedItem.Text = "0. Seleccionar";
            Session["idcadena"] = null;
            Session["idworkrespuesta"] = 0;
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
            documento.FOLIOS = Convert.ToInt32(TxtFolios.Text);
            documento.ANEXOS = txtAnexos.Text;
            documento.DOCUMENTO = "";// txtDoc.Text;
            documento.CAMINO = carpetaDestino.Replace("\\", "/");
            documento.DESCRIPCION = TxtObservacion.Text;

            documento.IDENTE = 0;

            documento.idDOCUMENTOS = new DocumentosManagement().InsertDocumentos(documento);

            SessionDocumental.ObjDocumento = documento;


            // Inserta indices
            for (int iInd = 0; iInd < lista.Items.Count; iInd++)
            {
                Indices indice = new Indices();
                indice.ATRIBUTO = "";
                indice.iddocumento = documento.idDOCUMENTOS;
                indice.INDICE = lista.Items[iInd].Text;
                new IndicesManagement().InsertIndices(indice);
            }


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

            /*
            string lcDestino = @Util.PathDocumentosTEMP;
            if (carpetatemp != "")
            {
                lcDestino = lcDestino + "//" + carpetatemp;
            }
            ManejoArchivos.EliminarArchivo(lcDestino, txtDoc.Text);
            */
        }

        protected int crearWorkfow(int lnIdCadena, EmiRecep receptorDestino)
        {

            workflow = new Workflow();

            EmiRecep receptorOrigen = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(ddlDe.SelectedValue.ToString()));

            workflow.IDENTEORIGEN = Convert.ToInt32(receptorOrigen.IDENTE);
            workflow.IDENTEDESTINO = Convert.ToInt32(receptorDestino.IDENTE);

            workflow.FECHA = DateTime.Now;
            workflow.iddocumento = SessionDocumental.ObjDocumento.idDOCUMENTOS;
            workflow.RADICADO = txtRadicado.Text;
            workflow.IDRADICADO = SessionDocumental.ObjRadicado.idradicados;
            workflow.IDTAREA = 1;
            workflow.IDTIPOLOGIA = 0;
            workflow.DIAS = new ConfigwfManagement().GetConfigwfById(SessionDocumental.ObjEmisorDestino.IDENTE).DIAS;
            workflow.ESTADO = "1. PENDIENTE";
            workflow.SEMAFORO = new TipocomManagement().GetTipocomIdPrincipal(Convert.ToInt32(DmpSemaforo.SelectedItem.Value)).TIPOCOMUNICACION;
            workflow.IDTIPOCOM = Convert.ToInt32(DmpSemaforo.SelectedItem.Value);
            workflow.CODIGOUSUARIO = SessionDocumental.UsuarioInicioSession.CODIGO;

            if (Session["idcadena"] == null)
            {
                workflow.IDCADENA = lnIdCadena;
            }
            else
            {
                workflow.IDCADENA = Convert.ToInt32(Session["idcadena"]);
            }

            if (receptorOrigen.IDTIPOEMISOR == 3 || receptorOrigen.IDTIPOEMISOR == 5)
            {
                workflow.IDEMIRECEP = Convert.ToInt32(DdlEmisor.Text);
            }
            else
            {
                workflow.IDEMIRECEP = Convert.ToInt32(ddlDe.SelectedValue.ToString());
            }

            workflow.OBSERVACION = TxtObservacion.Text;
            //EmiRecep EMIDESTINO = new EmiRecepManagement().GetEmiRecepJefe(Convert.ToInt32(ddlPara.SelectedValue.ToString()));

            if (receptorDestino.IDTIPOEMISOR == 3 || receptorDestino.IDTIPOEMISOR == 5)
            {
                workflow.IDEMIDESTINO = Convert.ToInt32(DdlEmisor.Text);
            }
            else
            {
                workflow.IDEMIDESTINO = Convert.ToInt32(receptorDestino.ID);
            }
            workflow.RESPUESTA = TextBox2.Text;
            workflow.FECHARESPUESTA = System.DateTime.Now;
            workflow.RADICADO2 = TextBox1.Text;
            if (host == "localhost")
            {
                workflow.LOCAL = 1;
            }
            else
            {
                workflow.LOCAL = 0;
            }
            int idworkflow = new WorkFlowManagement().InsertWorkflow(workflow);
            SessionDocumental.ObjWorkflow = workflow;

            //** Si tiene respuesta actualizamos la respuesta
            if (Convert.ToInt32(Session["idworkrespuesta"].ToString()) != 0)
            {
                Workflow Workflowrespuesta = new Workflow();
                Workflowrespuesta = new WorkFlowManagement().GetWorkflowById(Convert.ToInt32(Session["idworkrespuesta"].ToString()));
                Workflowrespuesta.RADICADO2 = txtRadicado.Text;
                Workflowrespuesta.RESPUESTA = TextBox2.Text;
                Workflowrespuesta.FECHARESPUESTA = System.DateTime.Now;

                new WorkFlowManagement().UpdateWorkflow(Workflowrespuesta);
                // Con esto correjimos lo de workflow

                proce.editar("workflow", "respuesta='" + TextBox2.Text + "',radicado2='" + txtRadicado.Text + "',fecharespuesta='" + proce.formateafecha(System.DateTime.Now,0) + "',estado = '5. FINALIZADO'", "radicado ='" + TextBox1.Text + "'");

            }

            // Para la nueva oficina

            LinkDoc links = new LinkDoc();
            links.IDDOCUMENTOS = SessionDocumental.ObjDocumento.idDOCUMENTOS;
            links.IDENTE = receptorDestino.IDENTE;
            new LinkDocManagement().InsertLinkDoc(links);

            //Response.Redirect("RecepDocFisico.aspx");
            return idworkflow;
        }


        protected void ddlDe_SelectedIndexChanged(object sender, EventArgs e)
        {


            obtieneRadicado();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (TxtIndice.Text != "")
            {
                //Workflow workflow = new WorkFlowManagement().GetWorkflowById(Convert.ToInt32(gvPendientes.SelectedValue.ToString()));
                lista.Items.Add(TxtIndice.Text);
            }
            TxtIndice.Text = "";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //Workflow workflow = new WorkFlowManagement().GetWorkflowById(Convert.ToInt32(gvPendientes.SelectedValue.ToString()));
            lista.Items.Remove(lista.SelectedItem);
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["idemisor"] == null)
            {
                Session.Add("idemisor", 0);
                Session.Add("nomemisor", "");

            }
            else
            {
                Session["idemisor"] = 0;
                Session["nommemisor"] = "";
            }

            ModalPopupExtender1.Show();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
            DdlEmisor.Text = Session["idemisor"].ToString();
            TxtNomemisor.Text = Session["nomemisor"].ToString();
            // DdlEmisor.DataSource = new EmiRecepManagement().GetTipoEmiRecep(2, 3);
            //DdlEmisor.DataBind();

        }

        protected void btbuscarenelpanel_Click(object sender, EventArgs e)
        {
            Session["panel"] = 1;
            llenarpanelcondicion();
            HiddenField1_ModalPopupExtender.Show();
        }
        public void llenarpanelcondicion()
        {


            gvpanel.DataSource = new EmiRecepManagement().GetAllEmiRecepNitNombre(Txtbuscarenelpanel.Text);
            gvpanel.DataBind();

        }
        protected void gvpanel_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (Convert.ToSingle(Session["panel"]) == 1)
            {
                llenarpanelcondicion();
            }
            if (Convert.ToSingle(Session["panel"]) == 2)
            {
                paneltotal();
            }


            gvpanel.PageIndex = e.NewPageIndex;
            HiddenField1_ModalPopupExtender.Show();
        }
        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            btcrear.Visible = false;
            HiddenField1_ModalPopupExtender.Hide();
        }


        public void paneltotal()
        {

            //gvpanel.DataSource = new EmiRecepManagement().GetAllEmiRecep();
            //gvpanel.DataBind();

        }
        protected void btnBuscaEmisor_Click(object sender, ImageClickEventArgs e)
        {
            Session["panel"] = 2;
            paneltotal();
            HiddenField1_ModalPopupExtender.Show();
        }

        protected void btcrear_Click(object sender, EventArgs e)
        {

        }

        protected void gvpanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlEmisor.Text = gvpanel.SelectedDataKey.Values[2].ToString();
            TxtNomemisor.Text = gvpanel.SelectedDataKey.Values[1].ToString();
            txtMail.Text = gvpanel.SelectedDataKey.Values[3].ToString();
            lista.Items.Add(TxtNomemisor.Text);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Workflow WorkRespuesta = new Workflow();
            WorkRespuesta = new WorkFlowManagement().GetWorkflowByRadicadoconRespuesta(TextBox1.Text.Trim());
            if (WorkRespuesta.ID == 0)
            {
                WorkRespuesta = new WorkFlowManagement().GetWorkflowByRadicado(TextBox1.Text.Trim());
                if (WorkRespuesta.ID == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Radicado No existe..');", true);
                }
            }

            string lcDescrip = new EmiRecepManagement().GetEmiRecepById(WorkRespuesta.IDEMIRECEP).DESCRIPCION;
            Label3.Text = WorkRespuesta.OBSERVACION.Trim() + ' ' + lcDescrip;
            TextBox2.Text = WorkRespuesta.RESPUESTA;
            if (Session["idworkrespesta"] == null)
            {
                Session.Add("idworkrespuesta", 0);
                Session.Add("idcadena", 0);
            }
            else
            {
                Session["idworkrespuesta"] = 0;
                Session["idccadena"] = 0;
            }
            if (WorkRespuesta.ID != null)
            {
                Session["idworkrespuesta"] = WorkRespuesta.ID;
                Session["idcadena"] = WorkRespuesta.IDCADENA;
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            LstDestinos.Items.Add(ddlPara.SelectedValue + "-" + ddlPara.SelectedItem.Text);
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            LstDestinos.Items.Remove(LstDestinos.SelectedItem);
        }

        protected void obtieneRadicado()
        {
            Para = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(ddlPara.SelectedValue.ToString()));
            De = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(ddlDe.SelectedValue.ToString()));

            SessionDocumental.ObjEmisorOrigen = De;
            SessionDocumental.ObjEmisorDestino = Para;

            if (Para.ID != 0 && De.ID != 0)
            {
                radicado = new RadicadosManagement().GetRadicadoActual(De, Para,false);
                txtRadicado.Text = radicado.Radicado;
                string lcPrefijo = "";
                if (radicado.PrefExtSal.Trim() == txtRadicado.Text.Substring(0, radicado.PrefExtSal.Trim().Length))
                {
                    lcPrefijo = radicado.PrefExtSal.Trim();
                }
                if (radicado.PrefExtEnt.Trim() == txtRadicado.Text.Substring(0, radicado.PrefExtEnt.Trim().Length))
                {
                    lcPrefijo = radicado.PrefExtEnt.Trim();
                }

                if (radicado.prefInter.Trim() == txtRadicado.Text.Substring(0, radicado.prefInter.Trim().Length))
                {
                    lcPrefijo = radicado.prefInter.Trim();
                }

               
                SessionDocumental.ObjRadicado = radicado;
                int lnRadicado = Convert.ToInt32(txtRadicado.Text.Substring(lcPrefijo.Length+4));
                // Ahora miramos si el radicado ya existe
                bool llExiste = true;
                while (llExiste)
                {
                  DataTable TabExiste =new DataTable();
                  //txtRadicado.Text = lcPrefijo + Convert.ToDateTime(radicado.UltimaFecha).Year.ToString();
                  proce.consultacamposcondicion("workflow", "id", "radicado='" + txtRadicado.Text+"'", TabExiste);
                    if (TabExiste.Rows.Count== 0)
                    {
                        llExiste = false;
                    }
                    else
                    {
                        
                        if (lnRadicado.ToString().Length < 4)
                        {
                            lnRadicado++;
                            txtRadicado.Text =lcPrefijo+ Convert.ToDateTime(radicado.UltimaFecha).Year.ToString()+ lnRadicado.ToString().PadLeft(4, '0');
                        }
                        else
                        {
                            lnRadicado++;
                            txtRadicado.Text = lcPrefijo + Convert.ToDateTime(radicado.UltimaFecha).Year.ToString()+ lnRadicado.ToString();
                        }

                    }
                }
                //
            }

            lista.Items.Add(txtRadicado.Text);
        }

        protected void DDLGrupoCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            DmpSemaforo.DataSource = new TipocomManagement().GetTipoComById(Convert.ToInt32(DDLGrupoCom.SelectedItem.Value));

            DmpSemaforo.DataTextField = "Tipocomunicacion";
            DmpSemaforo.DataValueField = "id";
            DmpSemaforo.DataBind();

            DmpSemaforo.Items.Insert(0, new ListItem("0. Seleccionar"));

        }

        protected void TxtObservacion_TextChanged(object sender, EventArgs e)
        {
            lista.Items.Add(TxtObservacion.Text);
        }

    }


    public static class ResponseHelper
    {
        public static void Redirect(this HttpResponse response, string url, string target, string windowFeatures)
        {

            if ((String.IsNullOrEmpty(target) || target.Equals("_self", StringComparison.OrdinalIgnoreCase)) && String.IsNullOrEmpty(windowFeatures))
            {
                response.Redirect(url);
            }
            else
            {
                Page page = (Page)HttpContext.Current.Handler;

                if (page == null)
                {
                    throw new InvalidOperationException("Cannot redirect to new window outside Page context.");
                }
                url = page.ResolveClientUrl(url);

                string script;
                if (!String.IsNullOrEmpty(windowFeatures))
                {
                    script = @"window.open(""{0}"", ""{1}"", ""{2}"");";
                }
                else
                {
                    script = @"window.open(""{0}"", ""{1}"");";
                }
                script = String.Format(script, url, target, windowFeatures);
                ScriptManager.RegisterStartupScript(page, typeof(Page), "Redirect", script, true);
            }
        }
    }
}