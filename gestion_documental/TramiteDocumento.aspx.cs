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
    public partial class TramiteDocumento : BasePage
    {
        Class1 proce = new Class1();
        EmiRecep receptor;
        IndicesManagement _indice = new IndicesManagement();
        subserieIndiceManagement _subserie = new subserieIndiceManagement();
        int lnDias;
        protected void Page_Load(object sender, EventArgs e)
        {

            this.ConfigurarPadrePostBack(this.Msj, this.usuarioLabel);
            if (!IsPostBack)
            {
                DdlEstados.Items.Add("--Seleccionar--");
                DdlEstados.Items.Add("1. PENDIENTE");
                DdlEstados.Items.Add("2. EN PROCESO");
                DdlEstados.Items.Add("3. REENVIADO");
                DdlEstados.Items.Add("4. COMPARTIDO");
                DdlEstados.Items.Add("5. FINALIZADO");
                DdlEstados.Items.Add("6. REENVIAR A TODOS");
                DdlEstados.Items.Add("7. APROBADO Y REENVIAR");
                DdlEstados.Items.Add("8. RECHAZADO Y REENVIAR");

                FillTodo();
                Session["parametro"] = 2;
                DdlTarea.DataSource = new TareasManagement().GetAllTareas();
                DdlTarea.DataBind();

            }
        }
        public void FillTodo()
        {

            receptor = new EmiRecepManagement().GetEmiRecepByIdusuario(SessionDocumental.UsuarioInicioSession.CODIGO);
            int idente = Convert.ToInt32(receptor.IDENTE.ToString());
            string filtro = txt_buscar.Text;
            string filtro2 = Txt_Fecha.Text;



            //emisorRecep.conficor = new ConfiCorManagement().GetConfiCorById(receptor.IDCONFICOR);
            DdlSerie.DataSource = new SerieManagement().GetASeriesEnte(receptor.IDENTE);
            DdlSerie.DataBind();
            DdlSerie.Items.Insert(0, new ListItem("Seleccionar", "0"));
            DdlSerie.SelectedValue = "0";

            gvPendientes.DataSource = new WorkFlowManagement().GetWorkflowByIdEnteDestino(idente, "'1. PENDIENTE','2. EN PROCESO'", receptor.ID, filtro, filtro2);
            gvPendientes.DataBind();

        }

        protected void DdlEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            Workflow workflow = new WorkFlowManagement().GetWorkflowById(Convert.ToInt32(gvPendientes.SelectedDataKey.Value.ToString()));
            DdlTarea.SelectedValue = workflow.IDTAREA.ToString();

            switch (DdlEstados.SelectedValue)
            {


                case "3. REENVIADO":
                    receptor = new EmiRecepManagement().GetEmiRecepByIdusuario(SessionDocumental.UsuarioInicioSession.CODIGO);
                    DdLEnviar.Enabled = true;
                    DdLEnviar.DataSource = new EmiRecepManagement().GetAllFuncionarios(receptor.IDRADICADO);
                    DdLEnviar.DataTextField = "funcionario";
                    DdLEnviar.DataValueField = "idemirecep";
                    DdLEnviar.DataBind();




                    break;
                case "7. APROBADO Y REENVIAR":
                    receptor = new EmiRecepManagement().GetEmiRecepByIdusuario(SessionDocumental.UsuarioInicioSession.CODIGO);
                    //DdLEnviar.Enabled = true;
                    //DdLEnviar.DataSource = new EmiRecepManagement().GetAllFuncionarios(receptor.IDRADICADO);
                    //DdLEnviar.DataTextField = "funcionario";
                    //DdLEnviar.DataValueField = "idemirecep";

                    //DdLEnviar.DataBind();


                    break;
                case "8. RECHAZADO Y REENVIAR":
                    receptor = new EmiRecepManagement().GetEmiRecepByIdusuario(SessionDocumental.UsuarioInicioSession.CODIGO);
                    //DdLEnviar.Enabled = true;
                    //DdLEnviar.DataSource = new EmiRecepManagement().GetAllFuncionarios(receptor.IDRADICADO);
                    //DdLEnviar.DataTextField = "funcionario";
                    //DdLEnviar.DataValueField = "idemirecep";
                    //DdLEnviar.DataBind();



                    break;
                case "2. EN PROCESO":
                    ImageButton2.Enabled = true;

                    DdLEnviar.Enabled = false;

                    DdlTarea.Enabled = true;
                    // DdlTarea.DataSource = new TareasManagement().GetAllTareas();
                    //DdlTarea.DataBind();


                    break;
                case "4. COMPARTIDO":
                    receptor = new EmiRecepManagement().GetEmiRecepByIdusuario(SessionDocumental.UsuarioInicioSession.CODIGO);
                    DdLEnviar.Enabled = true;
                    DdLEnviar.DataSource = new EmiRecepManagement().GetAllFuncionarios(receptor.IDRADICADO);
                    DdLEnviar.DataBind();
                    ImageButton2.Enabled = true;
                    DdlTarea.Enabled = true;
                    //DdlTarea.DataSource = new TareasManagement().GetAllTareas();
                    //DdlTarea.DataBind();

                    break;



            }

        }

        protected void gvPendientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvindice.DataSource = "";
            gvindice.DataBind();

            Workflow Workflow = new WorkFlowManagement().GetWorkflowById(Convert.ToInt32(gvPendientes.SelectedDataKey.Value.ToString()));

            Actividad ActividadSelec = new ActividadManagement().GetActividadById(Convert.ToInt32(Workflow.idactividad));
            LbProceso.Text = ActividadSelec.NOMBREPROCESO;
            LbActividad.Text = ActividadSelec.ACTIVIDAD;

            GridView1.DataSource = new DocumentosManagement().GetDocumentosNombrebyListaiD(Workflow.IDCADENA).ToList();
            GridView1.DataBind();

            TxtRadicado.Text = Workflow.RADICADO.ToString();
            if (Workflow.TIPO == "C")
            {
                DataTable datTexto = new DataTable();
                proce.consultacamposcondicion("correoentrante", "texto", "radicado='" + TxtRadicado.Text + "'", datTexto);
                if (datTexto.Rows.Count > 0)
                {
                    txtTextoCorreo.Text = StripHTML(datTexto.Rows[0]["texto"].ToString());

                }
                else
                {
                    proce.consultacamposcondicion("correosaliente", "texto", "radicado='" + TxtRadicado.Text + "'", datTexto);
                    if (datTexto.Rows.Count > 0)
                    {
                        txtTextoCorreo.Text = StripHTML(datTexto.Rows[0]["texto"].ToString());

                    }
                    else
                    {
                        txtTextoCorreo.Text = "";
                    }
                }

            }
            else
            {
                txtTextoCorreo.Text = "";
            }

            DdlEstados.Enabled = true;
            DdlTarea.SelectedValue = Workflow.IDTAREA.ToString();
            TxtDias.Text = Workflow.DIAS.ToString();
            switch (Workflow.ESTADO)
            {


                case "3. REENVIADO":
                    receptor = new EmiRecepManagement().GetEmiRecepByIdusuario(SessionDocumental.UsuarioInicioSession.CODIGO);
                    DdLEnviar.Enabled = true;
                    DdLEnviar.DataSource = new EmiRecepManagement().GetAllFuncionarios(receptor.IDRADICADO);
                    DdLEnviar.DataBind();
                    DdLEnviar.SelectedValue = Workflow.IDEMIDESTINO.ToString();



                    break;
                case "2. EN PROCESO":
                    ImageButton2.Enabled = true;

                    DdLEnviar.Enabled = false;




                    break;
                case "4. COMPARTIDO":
                    receptor = new EmiRecepManagement().GetEmiRecepByIdusuario(SessionDocumental.UsuarioInicioSession.CODIGO);
                    DdLEnviar.Enabled = true;
                    DdLEnviar.DataSource = new EmiRecepManagement().GetAllFuncionarios(receptor.IDRADICADO);
                    DdLEnviar.DataBind();
                    ImageButton2.Enabled = true;


                    break;




            }


            if (Workflow.IDTAREA.ToString() == "")
            {
                Workflow.IDTAREA = 1;
            }

            EmiRecep Emisor = new EmiRecepManagement().GetEmiRecepById(Workflow.IDEMIRECEP);

            txtDocumento.Text = Emisor.NIT;
            txtNombre.Text = Emisor.DESCRIPCION;
            txtDireccion.Text = Emisor.DIRECCIONFISICA;
            txtTelefono.Text = Emisor.TELEFONO;
            txtMail.Text = Emisor.EMAIL;
            TxtRespuesta.Text = Workflow.RESPUESTA;

            DdlTarea.SelectedValue = Workflow.IDTAREA.ToString();

            DdlEstados.SelectedValue = Workflow.ESTADO;
            TxtObserva.Text = Workflow.OBSERVACION;
            TxtRespuesta.Text = Workflow.RESPUESTA;
            DdlSerie.Enabled = true;
            DdlSerie.DataSource = new SerieManagement().GetASeriesEnte(Workflow.IDENTEDESTINO);
            DdlSerie.Items.Add("0. Seleccionar");
            DdlSerie.DataBind();


            // Buscamos workflow Inicial

            Workflow WFInicial = new WorkFlowManagement().GetWorkflowByFirstRadicado(TxtRadicado.Text);

            EmiRecep EmisorInicial = new EmiRecepManagement().GetEmiRecepById(WFInicial.IDEMIRECEP);

            txtDocumentoInicial.Text = EmisorInicial.NIT;
            txtNombreInicial.Text = EmisorInicial.DESCRIPCION;
            txtDireccionInicial.Text = EmisorInicial.DIRECCIONFISICA;
            txtTelefonoinicial.Text = EmisorInicial.TELEFONO;
            txtEmailInicial.Text = EmisorInicial.EMAIL;
            llenarDocumento(Workflow.idactividad, Workflow.IDCADENA);




        }

        public void llenarDocumento(int idactividad, int idcadena)
        {
            ddlTipoDocumento.DataSource = new DocumentoActividadManagement().GetAllDocumentoByActividadFaltantes(idactividad,idcadena);
            ddlTipoDocumento.DataBind();
            ddlTipoDocumento.Items.Insert(0, new ListItem("Seleccionar", "0"));
            ddlTipoDocumento.SelectedValue = "0";

        }

        protected void gvPendientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPendientes.PageIndex = e.NewPageIndex;
            receptor = new EmiRecepManagement().GetEmiRecepByIdusuario(SessionDocumental.UsuarioInicioSession.CODIGO);

            if (TxtClave.Text == "")
            {

                int idente = Convert.ToInt32(receptor.IDENTE.ToString());
                string filtro = txt_buscar.Text;
                string filtro2 = Txt_Fecha.Text;

                gvPendientes.DataSource = new WorkFlowManagement().GetWorkflowByIdEnteDestino(idente, "'1. PENDIENTE','2. EN PROCESO'", receptor.ID, filtro, filtro2);
                gvPendientes.DataBind();
            }
            else
            {
                string lcTablas = "Workflow as c INNER JOIN ente as b ON c.identedestino = b.idente INNER JOIN emirecep as d ON c.idemirecep = d.id INNER JOIN emirecep emi ON c.idemidestino = emi.id INNER JOIN ente a ON c.identeorigen = a.idente LEFT JOIN correoentrante co ON (c.radicado =  co.radicado and c.idemidestino = co.idreceptor)  ";
                string lcCampos = "c.*,a.descripcion as enteorigen,b.descripcion as entedestino,d.descripcion as emirecep,c.idcadena,c.codigousuario";
                string lcCondicion = " c.IDENTEDESTINO = " + receptor.IDENTE.ToString() + " AND estado IN ('1. PENDIENTE','2. EN PROCESO') AND idemidestino =" + receptor.ID.ToString() + " AND (emi.descripcion like '%" + TxtClave.Text.Trim() + "%' OR co.asunto like '%" + TxtClave.Text.Trim() + "%' OR co.Texto like '%" + TxtClave.Text.Trim() + "%' OR c.observacion like '%" + TxtClave.Text.Trim() + "%' )   GROUP BY c.radicado ORDER BY c.estado,c.semaforo,c.fecha";
                DataTable Datpendientes = new DataTable();
                proce.consultacamposcondicion(lcTablas, lcCampos, lcCondicion, Datpendientes);
                gvPendientes.DataSource = Datpendientes;
                gvPendientes.DataBind();
            }

        }

        protected void DdlEstados_TextChanged(object sender, EventArgs e)
        {

        }
        public void llenartopologia()
        {
            Workflow workflow = new WorkFlowManagement().GetWorkflowById(Convert.ToInt32(gvPendientes.SelectedDataKey.Value.ToString()));
            DdlTipologia.Enabled = true;

            DdlTipologia.DataSource = new TipologiaManagement().GetATipologiaEnte(Convert.ToInt32(DdlSubserie.SelectedValue.ToString()), workflow.IDENTEDESTINO);
            DdlTipologia.DataBind();
            DdlTipologia.Items.Insert(0, new ListItem("Seleccionar", "0"));
            DdlTipologia.SelectedValue = "0";

            DdlExpediente.DataSource = new ExpedienteManagement().GetAllExpedienteBySubserie(Convert.ToInt32(DdlSubserie.SelectedValue.ToString()), workflow.IDENTEDESTINO);
            DdlExpediente.DataBind();
            DdlExpediente.Items.Insert(0, new ListItem("Seleccionar", "0"));
            DdlExpediente.SelectedValue = "0";
            DdlExpediente.Enabled = true;

            List<Indices> indicess = new List<Indices>();
            List<subserieIndice> subindices = new List<subserieIndice>();
            indicess = _indice.GetIndicesByIdDocumento(workflow.iddocumento);

            List<Indices> list = indicess.Where(x => x.ATRIBUTO.ToString().Trim().Length >= 1).ToList();
            btactualizarindices.Visible = true;
            btneliminar.Visible = true;

            if (list.Count > 0)
            {

                gvindice.DataKeyNames = new string[] { "idindices", "indice", "atributo" };
                gvindice.DataSource = list;
                gvindice.DataBind();
                desabilitarcontroles();
                Session["parametro"] = 0;
            }
            else
            {
                subindices = _subserie.GetAllsubserieIndice(Convert.ToInt32(DdlSerie.SelectedValue.ToString()), Convert.ToInt32(DdlSubserie.SelectedValue.ToString()));

                if (subindices.Count > 0)
                {
                    gvindice.DataKeyNames = new string[] { "indice", "atributo" };

                    gvindice.DataSource = subindices;
                    gvindice.DataBind();
                    desabilitarcontroles();
                    Session["parametro"] = 1;
                }
                else
                {
                    btactualizarindices.Visible = false;
                    btneliminar.Visible = false;
                    gvindice.DataSource = "";
                    gvindice.DataBind();
                    habilitarcontroles();
                    Session["parametro"] = 2;
                }
            }
        }


        protected void DdlSubserie_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenartopologia();
        }

        public void desabilitarcontroles()
        {
            lista.Enabled = false;
            TxtIndice.Enabled = false;
            Button3.Enabled = false;
            Button4.Enabled = false;
        }
        public void habilitarcontroles()
        {
            lista.Enabled = true;
            TxtIndice.Enabled = true;
            Button3.Enabled = true;
            Button4.Enabled = true;
        }

        protected void DdlSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarsubserie();
        }
        public void llenarsubserie()
        {
            Workflow workflow = new WorkFlowManagement().GetWorkflowById(Convert.ToInt32(gvPendientes.SelectedDataKey.Value.ToString()));
            DdlSubserie.Enabled = true;

            DdlSubserie.DataSource = new SubSerieManagement().GetASubSerieEnte(Convert.ToInt32(DdlSerie.SelectedValue.ToString()), workflow.IDENTEDESTINO);
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





        public void AdicionaAtributos()
        {

            Workflow workflow = new WorkFlowManagement().GetWorkflowById(Convert.ToInt32(gvPendientes.SelectedValue.ToString()));


            lista.DataSource = new IndicesManagement().GetIndicesByIdDocumento(Convert.ToInt32(workflow.iddocumento.ToString()));
            lista.DataTextField = "INDICE";
            lista.DataValueField = "IDINDICES";
            lista.DataBind();

            lista.Visible = true;
            Label1.Visible = true;
        }




        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("docpendi.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (TxtIndice.Text != "")
            {
                Workflow workflow = new WorkFlowManagement().GetWorkflowById(Convert.ToInt32(gvPendientes.SelectedValue.ToString()));
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
            Workflow workflow = new WorkFlowManagement().GetWorkflowById(Convert.ToInt32(gvPendientes.SelectedValue.ToString()));
            new IndicesManagement().DeleteIndices(Convert.ToInt32(lista.SelectedValue.ToString()));
            lista.DataValueField = "IDINDICES";
            lista.DataTextField = "INDICE";

            lista.DataSource = new IndicesManagement().GetIndicesByIdDocumento(workflow.iddocumento);
            lista.DataBind();
            lista.Visible = true;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (GridView1.SelectedDataKey.Values[0].ToString().ToUpper().IndexOf(".PDF") < 0)
            {
                Response.Redirect("~/" + GridView1.SelectedDataKey.Values[1].ToString() + "/" + GridView1.SelectedDataKey.Values[0].ToString(), "_blank", "menubar=0,scrollbars=1,width=780,height=900,top=10");
            }
            else
            {
                Response.Redirect("~/" + GridView1.SelectedDataKey.Values[1].ToString() + "/" + GridView1.SelectedDataKey.Values[0].ToString(), "_blank", "menubar=0,scrollbars=1,width=780,height=900,top=10");
            }
            Workflow Workflow = new Workflow();
            Workflow = new WorkFlowManagement().GetWorkflowById(Convert.ToInt32(gvPendientes.SelectedValue));

            DdlSerie.Enabled = true;
            DdlSerie.DataSource = new SerieManagement().GetASeriesEnte(Workflow.IDENTEDESTINO);
            DdlSerie.DataBind();
            DdlSerie.Items.Insert(0, new ListItem("Seleccionar", "0"));
            DdlSerie.SelectedValue = "0";

            if (Convert.ToInt32(GridView1.SelectedDataKey.Values[3]) > 0)
            {
                DdlSerie.SelectedItem.Text = GridView1.SelectedDataKey.Values[6].ToString();


                DdlSubserie.DataSource = new SubSerieManagement().GetASubSerieEnte(Convert.ToInt32(GridView1.SelectedDataKey.Values[3]), Workflow.IDENTEDESTINO);
                DdlSubserie.DataBind();

                if (Convert.ToInt32(GridView1.SelectedDataKey.Values[4]) > 0)
                {


                    DdlSerie.SelectedItem.Text = GridView1.SelectedDataKey.Values[7].ToString();


                    DdlTipologia.DataSource = new TipologiaManagement().GetATipologiaEnte(Convert.ToInt32(GridView1.SelectedDataKey.Values[4]), Workflow.IDENTEDESTINO);
                    DdlTipologia.DataBind();

                    if (Convert.ToInt32(GridView1.SelectedDataKey.Values[5]) > 0)
                    {
                        DdlTipologia.SelectedItem.Text = GridView1.SelectedDataKey.Values[8].ToString();
                    }
                }

                if (Convert.ToInt32(GridView1.SelectedDataKey.Values[9]) > 0)
                {
                    DdlExpediente.DataSource = new ExpedienteManagement().GetAllExpedienteBySubserie(Convert.ToInt32(GridView1.SelectedDataKey.Values[4]), 0);
                    DdlExpediente.DataBind();
                    DdlExpediente.SelectedItem.Text = GridView1.SelectedDataKey.Values[10].ToString();

                }
            }

            // llenartopologia();
            /*
            lista.DataValueField = "IDINDICES";
            lista.DataTextField = "INDICE";
            lista.DataSource = new IndicesManagement().GetIndicesByIdDocumento(Workflow.iddocumento);
            lista.DataBind();
            lista.Visible = true;
            */

            Button8.Enabled = true;
        }



        protected void Button5_Click1(object sender, EventArgs e)
        {
            receptor = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
            Response.Redirect("/soltic/home/plantillas/?oficina_id=" + receptor.IDENTE.ToString(), "_blank", "menubar=0,scrollbars=1,width=780,height=900,top=10");
        }

        protected void btactualizarindices_Click(object sender, EventArgs e)
        {
            Workflow workflow = new WorkFlowManagement().GetWorkflowById(Convert.ToInt32(gvPendientes.SelectedValue.ToString()));
            int contador = 0;
            int VERIFICAR = 0;
            foreach (GridViewRow row in gvindice.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    TextBox indice = (row.Cells[0].FindControl("txtdescripcion") as TextBox);
                    if (indice.Text.ToString().Trim().Length < 1)
                    {
                        contador = 1;

                    }
                }
            }
            if (contador == 0)
            {


                foreach (GridViewRow row in gvindice.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        TextBox indice = (row.Cells[0].FindControl("txtdescripcion") as TextBox);

                        if (Convert.ToInt32(Session["parametro"]) == 0)
                        {
                            if (VERIFICAR == 0)
                            {
                                _indice.DeleteIndicescondicion(workflow.iddocumento);
                            }
                            VERIFICAR = 2;

                            Indices insert = new Indices();
                            insert.ATRIBUTO = row.Cells[0].Text;
                            insert.INDICE = indice.Text;
                            insert.iddocumento = workflow.iddocumento;

                            _indice.InsertIndices(insert);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('actualizacion realizada con exito...');", true);
                        }
                        else
                        {
                            if (Convert.ToInt32(Session["parametro"]) == 1)
                            {
                                Indices insert = new Indices();
                                insert.ATRIBUTO = row.Cells[0].Text;
                                insert.INDICE = indice.Text;
                                insert.iddocumento = workflow.iddocumento;
                                _indice.InsertIndices(insert);
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('actualizacion realizada con exito...');", true);

                            }
                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe Ingresar Todos Los Indices...');", true);

            }
            lista.DataSource = new IndicesManagement().GetIndicesByIdDocumento(workflow.iddocumento);
            lista.DataBind();
            lista.Visible = true;
        }

        protected void btneliminar_Click(object sender, EventArgs e)
        {
            Workflow workflow = new WorkFlowManagement().GetWorkflowById(Convert.ToInt32(gvPendientes.SelectedValue.ToString()));
            _indice.DeleteIndicescondicion(workflow.iddocumento);
            lista.DataSource = new IndicesManagement().GetIndicesByIdDocumento(workflow.iddocumento);
            lista.DataBind();
            lista.Visible = true;
            gvindice.DataSource = "";
            gvindice.DataBind();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Eliminacion con exito...');", true);
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            Workflow workflow = new WorkFlowManagement().GetWorkflowById(Convert.ToInt32(gvPendientes.SelectedValue.ToString()));

            Documentos ActDoc = new Documentos();
            ActDoc = new DocumentosManagement().GetDocumentosById2(Convert.ToInt32(GridView1.SelectedDataKey.Values[2].ToString()));
            ActDoc.IDSERIE = Convert.ToInt32(DdlSerie.SelectedValue);
            ActDoc.IDSUBSERIE = Convert.ToInt32(DdlSubserie.SelectedValue);
            ActDoc.IDTIPOLOGIA = Convert.ToInt32(DdlTipologia.SelectedValue);
            ActDoc.IDEXPEDIENTE = Convert.ToInt32(DdlExpediente.SelectedValue);
            new DocumentosManagement().UpdateDocumentos(ActDoc);
            LinkDoc ListaDoc = new LinkDocManagement().GetEnteByIdId(ActDoc.idDOCUMENTOS, workflow.IDENTEDESTINO);
            ListaDoc.IDSERIE = Convert.ToInt32(DdlSerie.SelectedValue);
            ListaDoc.IDSUBSERIE = Convert.ToInt32(DdlSubserie.SelectedValue);
            ListaDoc.IDTIPOLOGIA = Convert.ToInt32(DdlTipologia.SelectedValue);
            ListaDoc.IDEXPEDIENTE = Convert.ToInt32(DdlExpediente.SelectedValue);
            new LinkDocManagement().UpdateLinkDoc(ListaDoc);


            GridView1.DataSource = new DocumentosManagement().GetDocumentosNombrebyListaiD(workflow.IDCADENA).ToList();
            GridView1.DataBind();


        }

        protected void Button6_Click1(object sender, EventArgs e)
        {
            if (ddlTipoDocumento.SelectedValue != "0")
            {
                Workflow workflow = new WorkFlowManagement().GetWorkflowById(Convert.ToInt32(gvPendientes.SelectedValue.ToString()));
                EmiRecep Emisor = new EmiRecepManagement().GetEmiRecepByCodUsuario(Convert.ToInt32(SessionDocumental.UsuarioInicioSession.CODIGO.ToString()));
                // Grabamdo el Archivo
                string lcArchivo = proce.recuperaUbicacion() + "\\" + Emisor.conficor.CAMINODESCARGA.Trim() + "\\" + ImageButton2.FileName;
                ImageButton2.SaveAs(lcArchivo);


                Documentos NewDoc = new Documentos();

                if (DdlSubserie.SelectedValue != "")
                {
                    NewDoc.IDSERIE = Convert.ToInt32(DdlSerie.SelectedValue);
                    NewDoc.IDSUBSERIE = Convert.ToInt32(DdlSubserie.SelectedValue);
                    NewDoc.IDTIPOLOGIA = Convert.ToInt32(DdlTipologia.SelectedValue);
                    NewDoc.IDEXPEDIENTE = Convert.ToInt32(DdlExpediente.SelectedValue);
                }
                NewDoc.iddocumentoactividad = Convert.ToInt32(ddlTipoDocumento.SelectedValue);
                NewDoc.IDENTE = Emisor.IDENTE;
                NewDoc.ANEXOS = "1";
                NewDoc.FOLIOS = 1;
                NewDoc.CAMINO = Emisor.conficor.CAMINODESCARGA.Trim().Replace("\\", "//");
                NewDoc.DOCUMENTO = ImageButton2.FileName;
                int lnIddocumentos = new DocumentosManagement().InsertDocumentos(NewDoc);
                NewDoc.idDOCUMENTOS = lnIddocumentos;

                SessionDocumental.ObjDocumento = NewDoc;
                LinkDoc link3 = new LinkDoc();
                link3.IDDOCUMENTOS = NewDoc.idDOCUMENTOS;
                link3.IDENTE = workflow.IDENTEDESTINO;
                if (DdlSubserie.SelectedValue != "")
                {
                    link3.IDSERIE = NewDoc.IDSERIE;
                    link3.IDSUBSERIE = NewDoc.IDSUBSERIE;
                    link3.IDTIPOLOGIA = NewDoc.IDTIPOLOGIA;
                    link3.IDEXPEDIENTE = NewDoc.IDEXPEDIENTE;
                }
                new LinkDocManagement().InsertLinkDoc(link3);
                workflow.iddocumento = NewDoc.idDOCUMENTOS;

                new WorkFlowManagement().InsertWorkflow(workflow);


                GridView1.DataSource = new DocumentosManagement().GetDocumentosNombrebyListaiD(workflow.IDCADENA).ToList();
                GridView1.DataBind();

                llenarDocumento(workflow.idactividad, workflow.IDCADENA);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Debe seleccionar el documento a cargar...');", true);

            }

        }

        private void crealinkdocs(EmiRecep Emisor)
        {
            // Primero Averiguo cuantos
            Workflow workflow2 = new WorkFlowManagement().GetWorkflowById(Convert.ToInt32(gvPendientes.SelectedValue.ToString()));

            List<Documentos> tDocumentos = new DocumentosManagement().GetDocumentosbyListaiD(workflow2.IDCADENA);


            for (var index = 0; index < tDocumentos.Count; index++)
            {
                // busco Si ya existe en Linnkdoc
                LinkDoc ListaDoc = new LinkDocManagement().GetEnteByIdId(Emisor.IDENTE, tDocumentos[index].idDOCUMENTOS);
                if (ListaDoc.IDDOCUMENTOS == null)
                {
                    ListaDoc.IDDOCUMENTOS = tDocumentos[index].idDOCUMENTOS;
                    ListaDoc.IDENTE = tDocumentos[index].IDENTE;
                    ListaDoc.IDSERIE = tDocumentos[index].IDSERIE;
                    ListaDoc.IDTIPOLOGIA = tDocumentos[index].IDTIPOLOGIA;
                    ListaDoc.IDEXPEDIENTE = tDocumentos[index].IDEXPEDIENTE;
                    ListaDoc.IDSUBSERIE = tDocumentos[index].IDSUBSERIE;
                    new LinkDocManagement().InsertLinkDoc(ListaDoc);

                }
                else
                {
                    ListaDoc.IDDOCUMENTOS = tDocumentos[index].idDOCUMENTOS;
                    ListaDoc.IDENTE = tDocumentos[index].IDENTE;
                    ListaDoc.IDSERIE = tDocumentos[index].IDSERIE;
                    ListaDoc.IDTIPOLOGIA = tDocumentos[index].IDTIPOLOGIA;
                    ListaDoc.IDEXPEDIENTE = tDocumentos[index].IDEXPEDIENTE;
                    ListaDoc.IDSUBSERIE = tDocumentos[index].IDSUBSERIE;

                    new LinkDocManagement().UpdateLinkDoc(ListaDoc);

                }


            }



        }

        //protected void btnCerrar_Click(object sender, ImageClickEventArgs e)
        //{
        //    //this.mpeMensaje.Hide();
        //}



        protected void btnAceptarMensaje_Click(object sender, EventArgs e)
        {
            // mostrar el cuadro de mensaje
            this.mpeMensaje.Hide();
            Response.Redirect("TramiteDocumento.aspx");
        }

        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            receptor = new EmiRecepManagement().GetEmiRecepByIdusuario(SessionDocumental.UsuarioInicioSession.CODIGO);

            if (TxtClave.Text == "")
            {

                int idente = Convert.ToInt32(receptor.IDENTE.ToString());
                string filtro = txt_buscar.Text;
                string filtro2 = Txt_Fecha.Text;

                gvPendientes.DataSource = new WorkFlowManagement().GetWorkflowByIdEnteDestino(idente, "'1. PENDIENTE','2. EN PROCESO'", receptor.ID, filtro, filtro2);
                gvPendientes.DataBind();
            }
            else
            {
                string lcTablas = "Workflow as c INNER JOIN ente as b ON c.identedestino = b.idente INNER JOIN emirecep as d ON c.idemirecep = d.id INNER JOIN emirecep emi ON c.idemidestino = emi.id INNER JOIN ente a ON c.identeorigen = a.idente LEFT JOIN correoentrante co ON (c.radicado =  co.radicado and c.idemidestino = co.idreceptor)  ";
                string lcCampos = "c.*,a.descripcion as enteorigen,b.descripcion as entedestino,d.descripcion as emirecep,c.idcadena,c.codigousuario";
                string lcCondicion = " c.IDENTEDESTINO = " + receptor.IDENTE.ToString() + " AND estado IN ('1. PENDIENTE','2. EN PROCESO') AND idemidestino =" + receptor.ID.ToString() + " AND (emi.descripcion like '%" + TxtClave.Text.Trim() + "%' OR co.asunto like '%" + TxtClave.Text.Trim() + "%' OR co.Texto like '%" + TxtClave.Text.Trim() + "%' OR c.observacion like '%" + TxtClave.Text.Trim() + "%' )   GROUP BY c.radicado ORDER BY c.estado,c.semaforo,c.fecha";
                DataTable Datpendientes = new DataTable();
                proce.consultacamposcondicion(lcTablas, lcCampos, lcCondicion, Datpendientes);
                gvPendientes.DataSource = Datpendientes;
                gvPendientes.DataBind();
            }
        }

        protected void BtnRegistrarCorreo_Click(object sender, EventArgs e)
        {
            Workflow workflow = new Workflow();
            Workflow workflowactual = new WorkFlowManagement().GetWorkflowById(Convert.ToInt32(gvPendientes.SelectedValue.ToString()));
            EmiRecep Emisor = new EmiRecepManagement().GetEmiRecepByCodUsuario(Convert.ToInt32(SessionDocumental.UsuarioInicioSession.CODIGO.ToString()));

            Documentos documento = new DocumentosManagement().GetDocumentosById(workflowactual.iddocumento, Emisor.IDENTE);
            EmiRecep jefe = new EmiRecepManagement().GetEmiRecepJefe(0);

            var listaDocumentosPorCargar = new DocumentoActividadManagement().GetAllDocumentoByActividadFaltantes(workflowactual.idactividad, workflowactual.IDCADENA);

            if (TxtDias.Text == "")
            {
                TxtDias.Text = "0";
            }

            if (DdlEstados.SelectedValue.ToString() != "8. RECHAZADO REENVIAR" && DdlEstados.SelectedValue.ToString() != "5. FINALIZADO" && DdlEstados.SelectedValue.ToString() != "7. APROBADO Y REENVIAR" && DdlEstados.SelectedValue.ToString() != "2. EN PROCESO")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Esta opción es solo para estados 2,5,7 y 8');", true);
                return;
            }

            switch (DdlEstados.SelectedValue.ToString())
            {

                case "2. EN PROCESO":
                    // Actualziamos el estado en proceso y los datos tanto en documentos como en Workflow


                    workflow.IDENTEDESTINO = workflowactual.IDENTEDESTINO;
                    workflow.IDENTEORIGEN = workflowactual.IDENTEORIGEN;
                    workflow.IDEMIRECEP = workflowactual.IDEMIRECEP;


                    if (DdlExpediente.SelectedValue != null & DdlExpediente.SelectedValue != "")
                    {
                        workflow.idexpediente = Convert.ToInt32(DdlExpediente.SelectedValue.ToString());
                    }
                    if (DdlTipologia.SelectedValue != null & DdlTipologia.SelectedValue != "")
                    {
                        workflow.IDTIPOLOGIA = Convert.ToInt32(DdlTipologia.SelectedValue.ToString());
                    }
                    Console.WriteLine("Los dias");
                    lnDias = 0;
                    if (TxtDias.Text != null)
                    {
                        lnDias = Convert.ToInt32(TxtDias.Text);
                    }

                    workflow.DIAS = lnDias;

                    workflow.ESTADO = "2. EN PROCESO";
                    workflow.RESPUESTA = TxtRespuesta.Text;
                    workflow.iddocumento = workflowactual.iddocumento;
                    workflow.IDCADENA = workflowactual.IDCADENA;
                    workflow.IDEMIDESTINO = workflowactual.IDEMIDESTINO;
                    workflow.OBSERVACION = TxtObserva.Text;
                    workflow.RADICADO = workflowactual.RADICADO;
                    workflow.SEMAFORO = workflowactual.SEMAFORO;
                    workflow.TIPO = workflowactual.TIPO;
                    workflow.IDTAREA = Convert.ToInt32(DdlTarea.SelectedValue.ToString());
                    workflow.ID = workflowactual.ID;

                    bool actualiza = false;
                    if (TxtRespuesta.Text != "" && workflowactual.RESPUESTA.Trim() != TxtRespuesta.Text.Trim())
                    {
                        workflow.RESPUESTA = TxtRespuesta.Text.Trim();
                        workflow.FECHARESPUESTA = System.DateTime.Now;
                        actualiza = true;
                    }


                    workflow.FECHA = workflowactual.FECHA;
                    workflow.IDCADENA = workflowactual.IDCADENA;
                    workflow.IDRADICADO = workflow.IDRADICADO;
                    workflow.IDCADENA = workflowactual.IDCADENA;
                    workflow.IDRADICADO = workflowactual.IDRADICADO;
                    Console.WriteLine("Vamos a actualizar");
                    workflow.CODIGOUSUARIO = SessionDocumental.UsuarioInicioSession.CODIGO;
                    new WorkFlowManagement().UpdateWorkflow(workflow);
                    proce.editar("workflow", "estado = '2. EN PROCESO'", "radicado ='" + workflow.RADICADO + "', idemidestino = " + workflow.IDEMIDESTINO);

                    FillTodo();

                    break;

                case "8. RECHAZADO REENVIAR":
                    Configwf configwfacterior = new ConfigwfManagement().GetConfigwfByIdactividadsiguiente(workflowactual.idactividad);
                    //if (DdLEnviar.SelectedValue.ToString() == "")
                    //{
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Debe selecionar a quien reenvia el trámite');", true);
                    //    DdLEnviar.Focus();
                    //    return;

                    //}
                    //else
                    //{
                    EmiRecep ReceptorR = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(configwfacterior.idemirecep));
                    // Grabamos nuevo workflow a quien se lo envian

                    workflow.FECHA = DateTime.Now;
                    workflow.IDENTEDESTINO = ReceptorR.IDENTE;
                    workflow.IDENTEORIGEN = workflowactual.IDENTEDESTINO;
                    workflow.IDEMIRECEP = workflowactual.IDEMIDESTINO;

                    workflow.IDCADENA = workflowactual.IDCADENA;
                    workflow.IDRADICADO = workflowactual.IDRADICADO;
                    lnDias = 0;
                    if (TxtDias.Text != null)
                    {
                        lnDias = Convert.ToInt32(TxtDias.Text);
                    }

                    workflow.DIAS = lnDias;
                    workflow.ESTADO = "1. PENDIENTE";
                    workflow.iddocumento = workflowactual.iddocumento;

                    workflow.IDEMIDESTINO = Convert.ToInt32(configwfacterior.idemirecep);
                    workflow.OBSERVACION = TxtObserva.Text;
                    workflow.RADICADO = workflowactual.RADICADO;
                    workflow.SEMAFORO = workflowactual.SEMAFORO;
                    workflow.TIPO = workflowactual.TIPO;
                    workflow.IDTAREA = Convert.ToInt32(DdlTarea.SelectedValue);
                    workflow.RESPUESTA = TxtRespuesta.Text;
                    workflow.FECHARESPUESTA = System.DateTime.Now;

                    workflow.RESPUESTA = TxtRespuesta.Text.Trim();
                    workflow.FECHARESPUESTA = System.DateTime.Now;
                    workflow.CODIGOUSUARIO = SessionDocumental.UsuarioInicioSession.CODIGO;
                    workflow.idactividad = configwfacterior.idactividadsiguiente;

                    new WorkFlowManagement().InsertWorkflow(workflow);


                    // Actualizamos el work Actual
                    workflowactual.ESTADO = DdlEstados.SelectedValue;
                    new WorkFlowManagement().UpdateWorkflow(workflowactual);
                    proce.editar("workflow", "estado = '" + DdlEstados.SelectedValue + "'", "radicado ='" + TxtRadicado.Text.Trim() + "' and identeorigen =" + workflowactual.IDENTEORIGEN.ToString() + " and identedestino=" + workflowactual.IDENTEDESTINO.ToString());

                    crealinkdocs(ReceptorR);
                    FillTodo();

                    //}

                    break;

                case "7. APROBADO Y REENVIAR":


                    if (listaDocumentosPorCargar.Count == 0)
                    {
                        Configwf configwf = new ConfigwfManagement().GetConfigwfByIdactividad(workflowactual.idactividad);
                        Configwf configwf2 = new ConfigwfManagement().GetConfigwfByIdactividad(configwf.idactividadsiguiente);

                        //if (DdLEnviar.SelectedValue.ToString() == "")
                        //{
                        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Debe selecionar a quien reenvia el trámite');", true);
                        //    DdLEnviar.Focus();
                        //    return;

                        //}
                        //else
                        //{
                        EmiRecep Receptor = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(configwf.idemirecep));
                        // Grabamos nuevo workflow a quien se lo envian

                        workflow.FECHA = DateTime.Now;
                        workflow.IDENTEDESTINO = Receptor.IDENTE;
                        workflow.IDENTEORIGEN = workflowactual.IDENTEDESTINO;
                        workflow.IDEMIRECEP = workflowactual.IDEMIDESTINO;
                        workflow.IDCADENA = workflowactual.IDCADENA;
                        lnDias = 0;
                        if (TxtDias.Text != null)
                        {
                            lnDias = Convert.ToInt32(TxtDias.Text);
                        }

                        workflow.DIAS = lnDias;
                        workflow.ESTADO = "1. PENDIENTE";
                        workflow.iddocumento = workflowactual.iddocumento;

                        workflow.IDEMIDESTINO = Convert.ToInt32(configwf2.idemirecep);
                        workflow.OBSERVACION = TxtObserva.Text;
                        workflow.RADICADO = workflowactual.RADICADO;
                        workflow.SEMAFORO = workflowactual.SEMAFORO;
                        workflow.TIPO = workflowactual.TIPO;

                        workflow.IDTAREA = Convert.ToInt32(DdlTarea.SelectedValue);
                        workflow.IDCADENA = workflowactual.IDCADENA;
                        workflow.IDRADICADO = workflowactual.IDRADICADO;
                        workflow.OBSERVACION = TxtObserva.Text;

                        workflow.RESPUESTA = TxtRespuesta.Text.Trim();
                        workflow.FECHARESPUESTA = System.DateTime.Now;
                        workflow.CODIGOUSUARIO = SessionDocumental.UsuarioInicioSession.CODIGO;
                        workflow.idactividad = configwf.idactividadsiguiente;

                        new WorkFlowManagement().InsertWorkflow(workflow);



                        // Actualizamos el work Actual
                        workflowactual.ESTADO = DdlEstados.SelectedValue;

                        new WorkFlowManagement().UpdateWorkflow(workflowactual);
                        proce.editar("workflow", "estado = '" + DdlEstados.SelectedValue + "'", "radicado ='" + TxtRadicado.Text.Trim() + "' and identeorigen =" + workflowactual.IDENTEORIGEN.ToString() + " and identedestino=" + workflowactual.IDENTEDESTINO.ToString());
                        crealinkdocs(Receptor);
                        FillTodo();

                        //}
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe cargar todos los documentos requeridos...');", true);
                    }
                    break;
                case "5. FINALIZADO":

                    if (listaDocumentosPorCargar.Count() == 0)
                    {
                        if (TxtRespuesta.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Debe digitar una respuesta..');", true);
                            TxtRespuesta.Focus();
                            return;

                        }

                        workflowactual.ESTADO = DdlEstados.SelectedValue;


                        workflowactual.OBSERVACION = TxtObserva.Text;

                        new WorkFlowManagement().UpdateWorkflow(workflowactual);

                        proce.editar("workflow", "estado = '" + DdlEstados.SelectedValue + "'", "radicado ='" + TxtRadicado.Text.Trim() + "' and identeorigen =" + workflowactual.IDENTEORIGEN.ToString() + " and identedestino=" + workflowactual.IDENTEDESTINO.ToString());
                        // proce.editar("workflow", "estado ='5. FINALIZADO',respuesta ='" + TxtRespuesta.Text + "',fecharespuesta='" + proce.formateafecha(System.DateTime.Now) + "'", "radicado = '" + workflowactual.RADICADO + "' and estado <> '5. FINALIZADO'");
                        FillTodo();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe cargar todos los documentos requeridos...');", true);
                    }
                    break;




            }
            Radicados radicado = new Radicados();
            SessionDocumental.ObjRadicado = radicado;
            SessionDocumental.ObjRadicado.Radicado = workflowactual.RADICADO.ToString();
            Response.Redirect("TramiteCorreo.aspx");



            // Se debe redirecionar al momento de dar cerrar o aceptar en el popup
            // Button Evento : btnAceptarMensaje_Click
            // Response.Redirect("TramiteDocumento.aspx");

        }



        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            Workflow workflow = new Workflow();
            Workflow workflowactual = new WorkFlowManagement().GetWorkflowById(Convert.ToInt32(gvPendientes.SelectedValue.ToString()));
            EmiRecep Emisor = new EmiRecepManagement().GetEmiRecepByCodUsuario(Convert.ToInt32(SessionDocumental.UsuarioInicioSession.CODIGO.ToString()));

            Documentos documento = new DocumentosManagement().GetDocumentosById(workflowactual.iddocumento, Emisor.IDENTE);
            EmiRecep jefe = new EmiRecepManagement().GetEmiRecepJefe(0);

            var listaDocumentosPorCargar = new DocumentoActividadManagement().GetAllDocumentoByActividadFaltantes(workflowactual.idactividad,workflowactual.IDCADENA);


            if (TxtDias.Text == "")
            {
                TxtDias.Text = "0";
            }

            Console.WriteLine("Entrando..");
            switch (DdlEstados.SelectedValue.ToString())
            {

                case "1. PENDIENTE":
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('No puede dejar pendiente este trámite');", true);
                    return;
                case "3. REENVIADO":
                    int lnDias;
                    if (DdLEnviar.SelectedValue.ToString() == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Debe selecionar a quien reenvia el trámite');", true);
                        DdLEnviar.Focus();
                        return;

                    }
                    else
                    {
                        EmiRecep Receptor3 = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(DdLEnviar.SelectedValue));
                        // Grabamos nuevo workflow a quien se lo envian

                        workflow.FECHA = DateTime.Now;
                        workflow.IDENTEDESTINO = Receptor3.IDENTE;
                        workflow.IDENTEORIGEN = workflowactual.IDENTEDESTINO;
                        workflow.IDEMIRECEP = workflowactual.IDEMIDESTINO;
                        workflow.IDCADENA = workflowactual.IDCADENA;
                        workflow.CODIGOUSUARIO = SessionDocumental.UsuarioInicioSession.CODIGO;
                        workflow.IDRADICADO = workflowactual.IDRADICADO;
                        lnDias = Convert.ToInt32(TxtDias.Text);
                        if (TxtDias.Text != null)
                        {
                            lnDias = Convert.ToInt32(TxtDias.Text);
                        }

                        workflow.DIAS = lnDias;
                        workflow.ESTADO = "1. PENDIENTE";
                        workflow.iddocumento = workflowactual.iddocumento;

                        workflow.IDEMIDESTINO = Convert.ToInt32(DdLEnviar.SelectedValue);
                        workflow.OBSERVACION = TxtObserva.Text;
                        workflow.RADICADO = workflowactual.RADICADO;
                        workflow.SEMAFORO = workflowactual.SEMAFORO;
                        workflow.TIPO = workflowactual.TIPO;

                        workflow.IDRADICADO = workflowactual.IDRADICADO;
                        workflow.IDTAREA = Convert.ToInt32(DdlTarea.SelectedValue);

                        workflow.RESPUESTA = TxtRespuesta.Text.Trim();
                        workflow.FECHARESPUESTA = System.DateTime.Now;





                        new WorkFlowManagement().InsertWorkflow(workflow);



                        // Actualizamos el work Actual
                        workflowactual.ESTADO = DdlEstados.SelectedValue;

                        new WorkFlowManagement().UpdateWorkflow(workflowactual);
                        proce.editar("workflow", "estado = '" + DdlEstados.SelectedValue + "'", "radicado ='" + TxtRadicado.Text.Trim() + "' and identeorigen =" + workflowactual.IDENTEORIGEN.ToString() + " and identedestino=" + workflowactual.IDENTEDESTINO.ToString());
                        crealinkdocs(Receptor3);

                        FillTodo();
                        //omb.ShowMessage("No Se Encontraron Registros ...");
                    }

                    break;



                case "7. APROBADO Y REENVIAR":
                    if (listaDocumentosPorCargar.Count() == 0)
                    {
                        Configwf configwf = new ConfigwfManagement().GetConfigwfByIdactividad(workflowactual.idactividad);
                        Configwf configwf2 = new ConfigwfManagement().GetConfigwfByIdactividad(configwf.idactividadsiguiente);

                        //if (DdLEnviar.SelectedValue.ToString() == "")
                        //{
                        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Debe selecionar a quien reenvia el trámite');", true);
                        //    DdLEnviar.Focus();
                        //    return;

                        //}
                        //else
                        //{
                        EmiRecep Receptor7 = new EmiRecepManagement().GetEmiRecepById(configwf.idemirecep);
                        // Grabamos nuevo workflow a quien se lo envian

                        workflow.FECHA = DateTime.Now;
                        workflow.IDENTEDESTINO = Receptor7.IDENTE;
                        workflow.IDENTEORIGEN = workflowactual.IDENTEDESTINO;
                        workflow.IDEMIRECEP = workflowactual.IDEMIDESTINO;
                        workflow.IDCADENA = workflowactual.IDCADENA;
                        lnDias = 0;
                        if (TxtDias.Text != null)
                        {
                            lnDias = Convert.ToInt32(TxtDias.Text);
                        }

                        workflow.DIAS = lnDias;
                        workflow.ESTADO = "1. PENDIENTE";
                        workflow.iddocumento = workflowactual.iddocumento;

                        workflow.IDEMIDESTINO = Convert.ToInt32(configwf2.idemirecep);
                        workflow.OBSERVACION = TxtObserva.Text;
                        workflow.RADICADO = workflowactual.RADICADO;
                        workflow.SEMAFORO = workflowactual.SEMAFORO;
                        workflow.TIPO = workflowactual.TIPO;

                        workflow.IDTAREA = Convert.ToInt32(DdlTarea.SelectedValue);
                        workflow.IDCADENA = workflowactual.IDCADENA;
                        workflow.IDRADICADO = workflowactual.IDRADICADO;
                        workflow.OBSERVACION = TxtObserva.Text;

                        workflow.RESPUESTA = TxtRespuesta.Text.Trim();
                        workflow.FECHARESPUESTA = System.DateTime.Now;
                        workflow.CODIGOUSUARIO = SessionDocumental.UsuarioInicioSession.CODIGO;
                        workflow.idactividad = configwf.idactividadsiguiente;

                        new WorkFlowManagement().InsertWorkflow(workflow);



                        // Actualizamos el work Actual
                        workflowactual.ESTADO = DdlEstados.SelectedValue;
                        new WorkFlowManagement().UpdateWorkflow(workflowactual);
                        proce.editar("workflow", "estado = '" + DdlEstados.SelectedValue + "'", "radicado ='" + TxtRadicado.Text.Trim() + "' and idemirecep =" + workflowactual.IDEMIRECEP.ToString() + " and idemidestino=" + workflowactual.IDEMIDESTINO.ToString());
                        crealinkdocs(Receptor7);
                        FillTodo();

                        //}
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe cargar todos los documentos requeridos...');", true);
                    }
                    break;

                case "8. RECHAZADO Y REENVIAR":
                    Configwf configwfacterior = new ConfigwfManagement().GetConfigwfByIdactividadsiguiente(workflowactual.idactividad);
                    //if (DdLEnviar.SelectedValue.ToString() == "")
                    //{
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Debe selecionar a quien reenvia el trámite');", true);
                    //    DdLEnviar.Focus();
                    //    return;

                    //}
                    //else
                    //{
                    EmiRecep Receptor = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(configwfacterior.idemirecep));
                    // Grabamos nuevo workflow a quien se lo envian

                    workflow.FECHA = DateTime.Now;
                    workflow.IDENTEDESTINO = Receptor.IDENTE;
                    workflow.IDENTEORIGEN = workflowactual.IDENTEDESTINO;
                    workflow.IDEMIRECEP = workflowactual.IDEMIDESTINO;

                    workflow.IDCADENA = workflowactual.IDCADENA;
                    workflow.IDRADICADO = workflowactual.IDRADICADO;
                    lnDias = 0;
                    if (TxtDias.Text != null)
                    {
                        lnDias = Convert.ToInt32(TxtDias.Text);
                    }

                    workflow.DIAS = lnDias;
                    workflow.ESTADO = "1. PENDIENTE";
                    workflow.iddocumento = workflowactual.iddocumento;

                    workflow.IDEMIDESTINO = Convert.ToInt32(configwfacterior.idemirecep);
                    workflow.OBSERVACION = TxtObserva.Text;
                    workflow.RADICADO = workflowactual.RADICADO;
                    workflow.SEMAFORO = workflowactual.SEMAFORO;
                    workflow.TIPO = workflowactual.TIPO;
                    workflow.IDTAREA = Convert.ToInt32(DdlTarea.SelectedValue);
                    workflow.RESPUESTA = TxtRespuesta.Text;
                    workflow.FECHARESPUESTA = System.DateTime.Now;

                    workflow.RESPUESTA = TxtRespuesta.Text.Trim();
                    workflow.FECHARESPUESTA = System.DateTime.Now;
                    workflow.CODIGOUSUARIO = SessionDocumental.UsuarioInicioSession.CODIGO;
                    workflow.idactividad = configwfacterior.idactividadsiguiente;

                    new WorkFlowManagement().InsertWorkflow(workflow);


                    // Actualizamos el work Actual
                    workflowactual.ESTADO = DdlEstados.SelectedValue;
                    new WorkFlowManagement().UpdateWorkflow(workflowactual);
                    proce.editar("workflow", "estado = '" + DdlEstados.SelectedValue + "'", "radicado ='" + TxtRadicado.Text.Trim() + "' and identeorigen =" + workflowactual.IDENTEORIGEN.ToString() + " and identedestino=" + workflowactual.IDENTEDESTINO.ToString());
                    crealinkdocs(Receptor);
                    FillTodo();

                    ////}

                    break;
                case "2. EN PROCESO":
                    // Actualziamos el estado en proceso y los datos tanto en documentos como en Workflow

                    workflow.FECHA = workflowactual.FECHA;
                    workflow.IDENTEDESTINO = workflowactual.IDENTEDESTINO;
                    workflow.IDENTEORIGEN = workflowactual.IDENTEORIGEN;
                    workflow.IDEMIRECEP = workflowactual.IDEMIRECEP;
                    Console.WriteLine("Los ddls");

                    if (DdlExpediente.SelectedValue != null & DdlExpediente.SelectedValue != "")
                    {
                        workflow.idexpediente = Convert.ToInt32(DdlExpediente.SelectedValue.ToString());
                    }
                    if (DdlTipologia.SelectedValue != null & DdlTipologia.SelectedValue != "")
                    {
                        workflow.IDTIPOLOGIA = Convert.ToInt32(DdlTipologia.SelectedValue.ToString());
                    }

                    lnDias = 0;
                    if (TxtDias.Text != null)
                    {
                        lnDias = Convert.ToInt32(TxtDias.Text);
                    }

                    workflow.DIAS = lnDias;

                    workflow.ESTADO = "2. EN PROCESO";
                    workflow.RESPUESTA = TxtRespuesta.Text;
                    workflow.iddocumento = workflowactual.iddocumento;
                    workflow.IDCADENA = workflowactual.IDCADENA;
                    workflow.IDEMIDESTINO = workflowactual.IDEMIDESTINO;
                    workflow.OBSERVACION = TxtObserva.Text;
                    workflow.RADICADO = workflowactual.RADICADO;
                    workflow.SEMAFORO = workflowactual.SEMAFORO;
                    workflow.TIPO = workflowactual.TIPO;
                    workflow.IDTAREA = Convert.ToInt32(DdlTarea.SelectedValue.ToString());
                    workflow.ID = workflowactual.ID;

                    bool actualiza = false;
                    if (TxtRespuesta.Text != "" && workflowactual.RESPUESTA.Trim() != TxtRespuesta.Text.Trim())
                    {
                        workflow.RESPUESTA = TxtRespuesta.Text.Trim();
                        workflow.FECHARESPUESTA = System.DateTime.Now;
                        actualiza = true;
                    }



                    workflow.IDCADENA = workflowactual.IDCADENA;
                    workflow.IDRADICADO = workflow.IDRADICADO;
                    workflow.IDCADENA = workflowactual.IDCADENA;
                    workflow.IDRADICADO = workflowactual.IDRADICADO;
                    Console.WriteLine("Vamos a actualizar");
                    workflow.CODIGOUSUARIO = SessionDocumental.UsuarioInicioSession.CODIGO;
                    new WorkFlowManagement().UpdateWorkflow(workflow);
                    proce.editar("workflow", "estado = '" + DdlEstados.SelectedValue + "'", "radicado ='" + TxtRadicado.Text.Trim() + "' and identeorigen =" + workflowactual.IDENTEORIGEN.ToString() + " and identedestino=" + workflowactual.IDENTEDESTINO.ToString());

                    FillTodo();

                    break;
                case "4. COMPARTIDO":

                    // Actualziamos el estado en proceso y los datos tanto en documentos como en Workflow

                    workflow.IDENTEDESTINO = workflowactual.IDENTEDESTINO;
                    workflow.IDENTEORIGEN = workflowactual.IDENTEORIGEN;
                    workflow.IDEMIRECEP = workflowactual.IDEMIRECEP;
                    workflow.idexpediente = Convert.ToInt32(DdlExpediente.SelectedValue.ToString());
                    workflow.IDTIPOLOGIA = Convert.ToInt32(DdlTipologia.SelectedValue.ToString());
                    workflow.IDCADENA = workflowactual.IDCADENA;
                    lnDias = 0;
                    if (TxtDias.Text != null)
                    {
                        lnDias = Convert.ToInt32(TxtDias.Text);
                    }

                    workflow.DIAS = lnDias;
                    workflow.ESTADO = "2. EN PROCESO";
                    workflow.iddocumento = workflowactual.iddocumento;

                    workflow.IDEMIDESTINO = workflowactual.IDEMIRECEP;
                    workflow.OBSERVACION = TxtObserva.Text;
                    workflow.RADICADO = workflowactual.RADICADO;
                    workflow.SEMAFORO = workflowactual.SEMAFORO;
                    workflow.TIPO = workflowactual.TIPO;
                    workflow.IDTAREA = Convert.ToInt32(DdlTarea.SelectedValue.ToString());

                    workflow.IDEMIDESTINO = workflowactual.IDEMIDESTINO;
                    workflow.ID = workflowactual.ID;
                    workflow.IDCADENA = workflowactual.IDCADENA;
                    workflow.IDRADICADO = workflowactual.IDRADICADO;

                    new WorkFlowManagement().UpdateWorkflow(workflow);




                    //aHORA CREAMOS EL NUEVO
                    EmiRecep Receptor2 = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(DdLEnviar.SelectedValue));
                    workflow.FECHA = DateTime.Now;
                    workflow.IDENTEDESTINO = Receptor2.IDENTE;
                    workflow.IDENTEORIGEN = workflowactual.IDENTEDESTINO;
                    workflow.IDEMIRECEP = workflowactual.IDEMIDESTINO;
                    workflow.IDEMIDESTINO = jefe.ID;
                    workflow.idexpediente = 0;
                    workflow.IDTIPOLOGIA = 0;
                    workflow.IDCADENA = workflowactual.IDCADENA;
                    lnDias = 0;
                    if (TxtDias.Text != null)
                    {
                        lnDias = Convert.ToInt32(TxtDias.Text);
                    }

                    workflow.DIAS = lnDias;
                    workflow.ESTADO = "1. PENDIENTE";
                    workflow.iddocumento = workflowactual.iddocumento;


                    workflow.OBSERVACION = TxtRespuesta.Text;
                    workflow.RADICADO = workflowactual.RADICADO;
                    workflow.SEMAFORO = workflowactual.SEMAFORO;
                    workflow.TIPO = workflowactual.TIPO;

                    workflow.IDCADENA = workflowactual.IDCADENA;
                    workflow.IDRADICADO = workflowactual.IDRADICADO;
                    workflow.IDTAREA = Convert.ToInt32(DdlTarea.SelectedValue.ToString());
                    if (TxtRespuesta.Text != "" && workflowactual.RESPUESTA.Trim() != TxtRespuesta.Text.Trim())
                    {
                        workflow.RESPUESTA = TxtRespuesta.Text.Trim();
                        workflow.FECHARESPUESTA = System.DateTime.Now;
                    }
                    workflow.CODIGOUSUARIO = SessionDocumental.UsuarioInicioSession.CODIGO;
                    new WorkFlowManagement().InsertWorkflow(workflow);
                    crealinkdocs(Receptor2);




                    FillTodo();



                    break;
                case "5. FINALIZADO":
                    if (listaDocumentosPorCargar.Count() == 0)
                    {
                        if (TxtRespuesta.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Debe digitar una respuesta..');", true);
                            TxtRespuesta.Focus();
                            return;

                        }

                        workflowactual.ESTADO = "5. FINALIZADO";

                        if (TxtRespuesta.Text != "" && workflowactual.RESPUESTA.Trim() != TxtRespuesta.Text.Trim())
                        {
                            workflowactual.RESPUESTA = TxtRespuesta.Text.Trim();
                            workflowactual.FECHARESPUESTA = System.DateTime.Now;
                        }
                        workflowactual.ESTADO = DdlEstados.SelectedValue;

                        workflowactual.OBSERVACION = TxtObserva.Text;

                        new WorkFlowManagement().UpdateWorkflow(workflowactual);
                        proce.editar("workflow", "estado = '" + DdlEstados.SelectedValue + "'", "radicado ='" + TxtRadicado.Text.Trim() + "' and identeorigen =" + workflowactual.IDENTEORIGEN.ToString() + " and identedestino=" + workflowactual.IDENTEDESTINO.ToString());
                        // proce.editar("workflow", "estado ='5. FINALIZADO',respuesta ='" + TxtRespuesta.Text + "',fecharespuesta='" + proce.formateafecha(System.DateTime.Now) + "'", "radicado = '" + workflowactual.RADICADO + "' and estado <> '5. FINALIZADO'");
                        FillTodo();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe cargar todos los documentos requeridos...');", true);
                    }
                    break;
                case "6. REENVIAR A TODOS":
                    DdLEnviar.DataSource = new EmiRecepManagement().GetAllFuncionarios(Emisor.IDRADICADO);
                    DdLEnviar.DataBind();
                    // Empezamos a crear un registro en WorkFlow a cada Ennte
                    for (int lnEnviar = 0; lnEnviar < DdLEnviar.Items.Count; lnEnviar++)
                    {
                        DdLEnviar.SelectedIndex = lnEnviar;
                        workflow = workflowactual;
                        EmiRecep Receptor1 = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(DdLEnviar.SelectedValue.ToString()));

                        workflow.IDENTEORIGEN = Emisor.IDENTE;
                        workflow.IDENTEDESTINO = Receptor1.IDENTE;
                        workflow.IDEMIRECEP = Emisor.ID;
                        workflow.IDEMIDESTINO = Receptor1.ID;
                        workflow.FECHA = DateTime.Now;
                        lnDias = 0;
                        if (TxtDias.Text != null)
                        {
                            lnDias = Convert.ToInt32(TxtDias.Text);
                        }

                        workflow.DIAS = lnDias;
                        if (TxtRespuesta.Text != "" && workflowactual.RESPUESTA.Trim() != TxtRespuesta.Text.Trim())
                        {
                            workflow.RESPUESTA = TxtRespuesta.Text.Trim();
                            workflow.FECHARESPUESTA = System.DateTime.Now;


                        }
                        workflow.OBSERVACION = TxtObserva.Text;
                        workflow.IDCADENA = workflowactual.IDCADENA;
                        workflow.IDRADICADO = workflowactual.IDRADICADO;
                        workflow.CODIGOUSUARIO = SessionDocumental.UsuarioInicioSession.CODIGO;
                        new WorkFlowManagement().InsertWorkflow(workflow);



                        workflowactual.RESPUESTA = TxtRespuesta.Text.Trim();
                        workflowactual.FECHARESPUESTA = System.DateTime.Now;



                        workflowactual.OBSERVACION = TxtObserva.Text;

                        new WorkFlowManagement().UpdateWorkflow(workflowactual);

                        crealinkdocs(Receptor1);


                    }
                    FillTodo();

                    break;

            }




            // mostrar el cuadro de mensaje
            this.mpeMensaje.Show();

            // Se debe redirecionar al momento de dar cerrar o aceptar en el popup
            // Button Evento : btnAceptarMensaje_Click
            // Response.Redirect("TramiteDocumento.aspx");
        }


        private string StripHTML(string source)
        {
            try
            {
                string result;

                // Remove HTML Development formatting
                // Replace line breaks with space
                // because browsers inserts space
                result = source;
                // Remove repeating spaces because browsers ignore them
                result = System.Text.RegularExpressions.Regex.Replace(result,
                                                                      @"( )+", " ");

                // Remove the header (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*head([^>])*>", "<head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*head( )*>)", "</head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<head>).*(</head>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all scripts (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*script([^>])*>", "<script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*script( )*>)", "</script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                //result = System.Text.RegularExpressions.Regex.Replace(result,
                //         @"(<script>)([^(<script>\.</script>)])*(</script>)",
                //         string.Empty,
                //         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<script>).*(</script>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all styles (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*style([^>])*>", "<style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*style( )*>)", "</style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<style>).*(</style>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert tabs in spaces of <td> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*td([^>])*>", "\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line breaks in places of <BR> and <LI> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*br( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*li( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line paragraphs (double line breaks) in place
                // if <P>, <DIV> and <TR> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*div([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*tr([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*p([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // Remove remaining tags like <a>, links, images,
                // comments etc - anything that's enclosed inside < >
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<[^>]*>", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // replace special characters:
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @" ", " ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&bull;", " * ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&lsaquo;", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&rsaquo;", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&trade;", "(tm)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&frasl;", "/",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&lt;", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&gt;", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&copy;", "(c)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&reg;", "(r)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&(.{2,6});", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // for testing
                //System.Text.RegularExpressions.Regex.Replace(result,
                //       this.txtRegex.Text,string.Empty,
                //       System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // make line breaking consistent
                result = result.Replace("\n", "\r");

                // Remove extra line breaks and tabs:
                // replace over 2 breaks with 2 and over 4 tabs with 4.
                // Prepare first to remove any whitespaces in between
                // the escaped characters and remove redundant tabs in between line breaks
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\t)", "\t\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\r)", "\t\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\t)", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove redundant tabs
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove multiple tabs following a line break with just one tab
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Initial replacement target string for line breaks
                string breaks = "\r\r\r";
                // Initial replacement target string for tabs
                string tabs = "\t\t\t\t\t";
                for (int index = 0; index < result.Length; index++)
                {
                    result = result.Replace(breaks, "\r\r");
                    result = result.Replace(tabs, "\t\t\t\t");
                    breaks = breaks + "\r";
                    tabs = tabs + "\t";
                }

                // That's it.
                return result;
            }
            catch
            {
                return source;
            }
        }

    }
}