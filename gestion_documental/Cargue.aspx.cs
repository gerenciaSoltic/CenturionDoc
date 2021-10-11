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
    public partial class Cargue : System.Web.UI.Page
    {
        ExpedienteManagement _expediente = new ExpedienteManagement();
        DocumentosManagement _Documentos = new DocumentosManagement();
        EnteRutaManagement _enteruta = new EnteRutaManagement();
        UnidadesManagement _unidades = new UnidadesManagement();
        IndicesManagement _indice = new IndicesManagement();
        subserieIndiceManagement _subserie = new subserieIndiceManagement();
        Class1 proce = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DDLOficina.DataSource = new EnteManagement().GetAllEntes();
                DDLOficina.DataValueField = "IDENTE";
                DDLOficina.DataTextField = "DESCRIPCION";
                DDLOficina.DataBind();

                oficina();
            }
        }

        protected void gvprincipal_DeleteEventHandler(object sender, GridViewDeleteEventArgs e)
        {
            int idEnte = (int)gvprincipal.DataKeys[Convert.ToInt32(e.RowIndex)].Values[2];

            if (!new DocumentosManagement().DeleteDocumentos(idEnte))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Ocurrio un problema al eliminar el registro, quizas este siendo usado');", true);
            }
            buscarlibros();


        }


        protected void gvprincipal_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // reference the Delete LinkButton
                LinkButton db = (LinkButton)e.Row.Cells[7].Controls[0];

                db.OnClientClick = "return confirm('Esta seguro que desea eliminar ?');";
            }
        }


        protected void TxtCodigo_TextChanged(object sender, EventArgs e)
        {
            Expediente exped = new Expediente();

            exped = _expediente.GetExpedienteByidenteyid(Convert.ToInt32(DDLOficina.SelectedValue), Convert.ToInt32(TxtCodigo.Text));

            if (exped.id > 0)
            {

                buscarlibros();
            }
            else
            {
                TxtCodigo.Text = "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('El ID del Expediente No Existe');", true);
            }
        }

        public void buscarlibros()
        {
            Expediente exped = new Expediente();
            EnteRuta ent = new EnteRuta();
            unidades uni = new unidades();
            exped = _expediente.GetExpedienteById(Convert.ToInt32(TxtCodigo.Text));

            ent = _enteruta.GetAllEnteRutasid(Convert.ToInt32(exped.contenedor));
            TxtContenedor.Text = ent.CONTENEDOR;
            TxtCompartimiento.Text = Convert.ToString(ent.COMPARTIMIENTO);
            uni = _unidades.GetUnidadesById(exped.idunidad);
            TxtUnidad.Text = uni.DESCRIPCION;
            TxtExpediente.Text = exped.descripcion;
            txtnumerounidad.Text = Convert.ToString(exped.numerounidad);

            gvprincipal.DataSource = _Documentos.GetDocumentosbyIDExpedientesinlink(Convert.ToInt32(TxtCodigo.Text), Convert.ToInt32(DDLOficina.SelectedValue));
            gvprincipal.DataBind();
        }

        protected void gvpanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtCodigo.Text = gvpanel.SelectedDataKey.Values[0].ToString();
            buscarlibros();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            llenarpanel();
        }

        public void llenarpanel()
        {
            Session["condicion"] = 0;
            gvpanel.DataSource = _expediente.GetExpedienteByidente(Convert.ToInt32(DDLOficina.SelectedValue));
            gvpanel.DataBind();
            HiddenField1_ModalPopupExtender.Show();
        }
        protected void btbuscarenelpanel_Click(object sender, EventArgs e)
        {
            buscarpanelcondicion();
        }
        public void buscarpanelcondicion()
        {
            Session["condicion"] = 1;
            gvpanel.DataSource = _expediente.GetExpedienteBycodigo(Txtbuscarenelpanel.Text, Convert.ToInt32(DDLOficina.SelectedValue));
            gvpanel.DataBind();
            HiddenField1_ModalPopupExtender.Show();
        }

        protected void gvpanel_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void gvpanel_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (Convert.ToInt32(Session["condicion"]) == 0)
            {
                llenarpanel();
            }
            else
            {
                if (Convert.ToInt32(Session["condicion"]) == 1)
                {
                    buscarpanelcondicion();
                }
            }

            gvpanel.PageIndex = e.NewPageIndex;
            HiddenField1_ModalPopupExtender.Show();
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            HiddenField1_ModalPopupExtender.Hide();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Documentos doc = new Documentos();
            EmiRecep receptor = new EmiRecepManagement().GetEmiRecepByIdusuario(SessionDocumental.UsuarioInicioSession.CODIGO);

            string lcArchivo = Server.MapPath(receptor.conficor.CAMINODESCARGA.Trim()) + "\\" + ImageButton2.FileName;
            ImageButton2.SaveAs(lcArchivo);

            doc.CAMINO = receptor.conficor.CAMINODESCARGA.Trim().Replace("\\", "//");
            doc.DOCUMENTO = ImageButton2.FileName;
            doc.IDEXPEDIENTE = Convert.ToInt32(TxtCodigo.Text);
            doc.IDENTE = Convert.ToInt32(DDLOficina.SelectedValue);
            doc.IDSERIE = Convert.ToInt32(DDLSerie.SelectedValue);
            doc.IDSUBSERIE = Convert.ToInt32(DDLSubserie.SelectedValue);
            doc.IDTIPOLOGIA = Convert.ToInt32(DDlTipoLogia.SelectedValue);

            int lniddoc = _Documentos.InsertDocumentos(doc);
            LinkDoc nlink = new LinkDoc();
            nlink.IDDOCUMENTOS = lniddoc;
            nlink.IDENTE = Convert.ToInt32(DDLOficina.SelectedValue);
            nlink.IDSERIE = Convert.ToInt32(DDLSerie.SelectedValue);
            nlink.IDSUBSERIE = Convert.ToInt32(DDLSubserie.SelectedValue);
            nlink.IDTIPOLOGIA = Convert.ToInt32(DDlTipoLogia.SelectedValue);
            nlink.IDEXPEDIENTE = Convert.ToInt32(TxtCodigo.Text);
            new LinkDocManagement().InsertLinkDoc(nlink);
            buscarlibros();
        }

        protected void DDLSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            serie();
        }
        public void serie()
        {
            DDLSubserie.DataSource = new SubSerieManagement().GetASubSerieEnte(Convert.ToInt32(DDLSerie.SelectedValue.ToString()), Convert.ToInt32(DDLOficina.SelectedValue.ToString()));
            DDLSubserie.DataValueField = "ID";
            DDLSubserie.DataTextField = "SUBSERIE";
            DDLSubserie.DataBind();
            DDLSubserie.Items.Insert(0, new ListItem("Seleccionar", "0"));
            DDLSubserie.SelectedValue = "0";

        }
        protected void DDLSubserie_SelectedIndexChanged(object sender, EventArgs e)
        {
            subserie();
        }
        public void subserie()
        {
            DDlTipoLogia.DataSource = new TipologiaManagement().GetATipologiaEnte(Convert.ToInt32(DDLSubserie.SelectedValue.ToString()), Convert.ToInt32(DDLOficina.SelectedValue.ToString()));
            DDlTipoLogia.DataValueField = "ID";
            DDlTipoLogia.DataTextField = "TIPOLOGIA";
            DDlTipoLogia.DataBind();
            DDlTipoLogia.Items.Insert(0, new ListItem("Seleccionar", "0"));
            DDlTipoLogia.SelectedValue = "0";
        }
        protected void DDLOficina_SelectedIndexChanged(object sender, EventArgs e)
        {
            oficina();
        }
        public void oficina()
        {
            DDLSerie.DataSource = new SerieManagement().GetASeriesEnte(Convert.ToInt32(DDLOficina.SelectedValue));
            DDLSerie.DataValueField = "ID";
            DDLSerie.DataTextField = "SERIE";
            DDLSerie.DataBind();
            DDLSerie.Items.Insert(0, new ListItem("Seleccionar", "0"));
            DDLSerie.SelectedValue = "0";
        }

        protected void gvprincipal_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void btcerrapanel_Click(object sender, EventArgs e)
        {
            HiddenField2_ModalPopupExtender.Hide();
        }

        protected void btguardarpanelgv_Click(object sender, EventArgs e)
        {
            int contador = 0;
            int VERIFICAR = 0;
            foreach (GridViewRow row in gvindice.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    TextBox indice = (row.Cells[0].FindControl("txtindicepanelgv") as TextBox);
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
                        TextBox indice = (row.Cells[0].FindControl("txtindicepanelgv") as TextBox);

                        if (VERIFICAR == 0)
                        {
                            _indice.DeleteIndicescondicion(Convert.ToInt32(gvprincipal.SelectedDataKey.Values[2].ToString()));
                        }
                        VERIFICAR = 2;

                        Indices insert = new Indices();
                        insert.ATRIBUTO = row.Cells[0].Text;
                        insert.INDICE = indice.Text;
                        insert.iddocumento = Convert.ToInt32(gvprincipal.SelectedDataKey.Values[2].ToString());
                        _indice.InsertIndices(insert);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('actualizacion realizada con exito...');", true);


                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe Ingresar Todos Los Indices...');", true);

            }
        }

        protected void btagregarindicepanel_Click(object sender, EventArgs e)
        {
            if (txtlistapanel.Text != "")
            {
                Indices indice = new Indices();
                indice.ATRIBUTO = "";
                indice.iddocumento = Convert.ToInt32(gvprincipal.SelectedDataKey.Values[2].ToString());
                indice.INDICE = txtlistapanel.Text;
                new IndicesManagement().InsertIndices(indice);
                listpanel.DataValueField = "IDINDICES";
                listpanel.DataTextField = "INDICE";


                listpanel.DataSource = new IndicesManagement().GetIndicesByIdDocumento(Convert.ToInt32(gvprincipal.SelectedDataKey.Values[2].ToString()));
                listpanel.DataBind();
                listpanel.Visible = true;
                HiddenField2_ModalPopupExtender.Show();
            }
        }

        protected void gvprincipal_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe Ingresar Todos Los Indices...');", true);
        }
        protected void btgvprincipal_Click(object sender, EventArgs e)
        {

            if (gvprincipal.SelectedIndex >= 0)
            {
                Response.Redirect("~/" + gvprincipal.SelectedDataKey.Values[3].ToString() + "/" + gvprincipal.SelectedDataKey.Values[4].ToString(), "_blank", "menubar=0,scrollbars=1,width=780,height=900,top=10");

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe seleccionar una fila...');", true);
            }
        }
        protected void btgvprincipalindices_Click(object sender, EventArgs e)
        {
            if (gvprincipal.SelectedIndex >= 0)
            {
                List<subserieIndice> subindices = new List<subserieIndice>();

                subindices = _subserie.GetAllsubserieIndice(Convert.ToInt32(gvprincipal.SelectedDataKey.Values[0].ToString()), Convert.ToInt32(gvprincipal.SelectedDataKey.Values[1].ToString()));
                if (subindices.Count > 0)
                {
                    gvindice.DataSource = subindices;
                    gvindice.DataBind();
                    btguardarpanelgv.Visible = true;
                    listpanel.Visible = false;
                    btagregarindicepanel.Visible = false;
                    txtlistapanel.Visible = false;
                }
                else
                {

                    listpanel.Visible = true;
                    btagregarindicepanel.Visible = true;
                    listpanel.DataSource = new IndicesManagement().GetIndicesByIdDocumento(Convert.ToInt32(gvprincipal.SelectedDataKey.Values[2].ToString()));
                    listpanel.DataValueField = "IDINDICES";
                    listpanel.DataTextField = "INDICE";
                    listpanel.DataBind();
                    txtlistapanel.Visible = true;
                    btguardarpanelgv.Visible = false;
                    gvindice.DataSource = "";
                    gvindice.DataBind();
                }
                HiddenField2_ModalPopupExtender.Show();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe seleccionar una fila...');", true);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            UnirExpediente();


        }


        protected void UnirExpediente()
        {

            /*DataTable Datos1 = Session["Datos1"] as DataTable;/*
     

            /* Armanos cursor con los archivos de salida final ***/
            ManejoPdfs UneArchivos = new ManejoPdfs();
            DataTable Datosfin = new DataTable();
            DataTable Datos1 = new DataTable();

            
            if (gvprincipal.Rows.Count > 0)
            {
                
                DataTable dtResultado = new DataTable();
                 string lcSarta = "";
                 string lcNombredeArchivoFinal="";
                 string lcNombredeArchivoDescarga = ""; 
                 string[] listaArchivos = {""};
                 for (int i = 0; i < gvprincipal.Rows.Count;i++ )
                 {

                     lcNombredeArchivoFinal =proce.recuperaUbicacion()+"\\"+gvprincipal.DataKeys[Convert.ToInt32(i)].Values[3].ToString().Replace(@"/",@"\") + "\\" + TxtExpediente.Text.Trim() + ".pdf";
                     lcNombredeArchivoDescarga = gvprincipal.DataKeys[Convert.ToInt32(i)].Values[3].ToString() + "\\" + TxtExpediente.Text.Trim() + ".pdf";

                     lcSarta = lcSarta + "," + proce.recuperaUbicacion() + "\\" + gvprincipal.DataKeys[Convert.ToInt32(i)].Values[3].ToString().Replace(@"/", @"\") + "\\" + gvprincipal.DataKeys[Convert.ToInt32(i)].Values[4];


                 }
                lcSarta = lcSarta.Substring(1);
                listaArchivos = lcSarta.Split(',');
                dtResultado.Clear();
                dtResultado = UneArchivos.Mezclar(lcNombredeArchivoFinal, listaArchivos);
                Response.Redirect("~/" +lcNombredeArchivoDescarga, "_blank", "menubar=0,scrollbars=1,width=780,height=900,top=10");
            }

        }
    }
}