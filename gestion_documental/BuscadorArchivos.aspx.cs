using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestion_documental.Utils;
using System.Web.SessionState;
using gestion_documental.DataAccessLayer;
using gestion_documental.BusinessObjects;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
using System.Reflection;


namespace gestion_documental
{
    public partial class BuscadorArchivos : BasePage
    {
        SerieManagement _serie = new SerieManagement();
        SubSerieManagement _subserie = new SubSerieManagement();
        subserieIndiceManagement _subserieindice = new subserieIndiceManagement();
        Class1 proce = new Class1();
        //private static string urlDocumentos = Resources.ResourceGlobal.DireccionDocumentosWeb;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ConfigurarPadrePostBack(this.Msj, this.usuarioLabel);
            
            if (!IsPostBack)
            {
                //FillGvrRecepDoc();
                ddlserie.DataSource = _serie.GetAllSeries();
                ddlserie.DataTextField = "serie";
                ddlserie.DataValueField = "id";
                ddlserie.DataBind();
                llenarsubserie();
                DdlTipologia.DataSource = new TipologiaManagement().GetAllTipologias();
                DdlTipologia.DataTextField = "Tipologia";
                DdlTipologia.DataValueField = "id";
                DdlTipologia.DataBind();
                DdlTipologia.Items.Insert(0, new ListItem("Seleccionar", "0"));
                DdlTipologia.SelectedValue = "0";
                
            }

        }

        public void llenarsubserie()
        {
            if (ddlserie.SelectedValue != null)
            {
                ddlSubserie.DataSource = _subserie.GetAllSubSeriesBySerie(Convert.ToInt32(ddlserie.SelectedValue));
                ddlSubserie.DataTextField = "SUBSERIE";
                ddlSubserie.DataValueField = "id";
                ddlSubserie.DataBind();
                llenardatagrid();
            }
        }

        private void MostrarError(string txt)
        {
            Msj.Text = txt;
            Msj.CssClass = "mensajeError";
        }



        

        
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (txtIndice.Text != "")
            {
                EmiRecep Receptor = new EmiRecepManagement().GetEmiRecepByCodUsuario(Convert.ToInt32(SessionDocumental.UsuarioInicioSession.CODIGO.ToString()));
                List<Documentos> documentos = new IndicesManagement().GetAllDocumentos(txtIndice.Text,Receptor.IDENTE);
                ListaDocumentos = documentos;
                this.DocumentosGridView.DataSource = documentos;
                this.DocumentosGridView.DataBind();
                if (Session["documentos"] == null)
                {
                    Session.Add("documentos", documentos);
                }
                else
                {
                    Session["documentos"] = documentos;
                }
                
            }
        }

        protected void ddlserie_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarsubserie();
        }

        protected void ddlSubserie_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenardatagrid();
        }

        public void llenardatagrid()
        {

          gvindices.DataSource=  _subserieindice.GetAllsubserieIndice(Convert.ToInt32(ddlserie.SelectedValue),Convert.ToInt32(ddlSubserie.SelectedValue));
          gvindices.DataBind();
        }
        internal static HttpSessionState Sesion
        {
            get
            {
                var current = HttpContext.Current;
                if (current == null) throw new InvalidOperationException("HttpContext no esta disponible en este punto.");
                var session = current.Session;
                if (session == null) throw new InvalidOperationException("Session no está disponible en el contexto actual..");
                return session;
            }
        }
        internal static List<Documentos> ListaDocumentos
        {
            get
            {
                List<Documentos> retorno = Sesion["ListDocumentos"] as List<Documentos>;

                return retorno;
            }
            set
            {
                if (value == null)
                    Sesion.Remove("ListDocumentos");
                else Sesion["ListDocumentos"] = value;
            }
        }

        protected void DocumentosGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtcodigoex.Text = "";
            txtunidadext.Text = "";
            txtcompartimientoext.Text = "";
            txtcontenedorext.Text = "";
            //Lleno la lista de Documentos del Expediente

            EmiRecep Receptor = new EmiRecepManagement().GetEmiRecepByCodUsuario(Convert.ToInt32(SessionDocumental.UsuarioInicioSession.CODIGO.ToString()));
            Documentos documento = new DocumentosManagement().GetDocumentosById(Convert.ToInt32(DocumentosGridView.SelectedDataKey.Value.ToString()),Receptor.IDENTE);
            
            Expediente expediente = new ExpedienteManagement().GetExpedienteById(documento.IDEXPEDIENTE);

            LblExpediente.Visible = true;
            TxtExpediente.Text = expediente.descripcion;
            TxtExpediente.Visible = true;


            Response.Redirect("~/" + documento.CAMINO.Trim() + documento.DOCUMENTO.Trim(), "_blank", "menubar=0,scrollbars=1,width=780,height=900,top=10");
                if (documento.IDEXPEDIENTE != 0)
                {
                    List<Documentos> documentoexpediente = new DocumentosManagement().GetDocumentosbyIDExpediente(documento.IDEXPEDIENTE, Receptor.IDENTE);

                    txtcodigoex.Text = Convert.ToString(expediente.numerounidad);
                    DataTable data = new DataTable();
                    proce.consultacamposcondicion("unidades", "descripcion", "idunidades='" + expediente.unidad2.ToString() + "'", data);
                    if (data.Rows.Count > 0)
                    {
                        txtunidadext.Text = data.Rows[0]["descripcion"].ToString();
                        txtcompartimientoext.Text = expediente.compartimiento.ToString();
                        txtcontenedorext.Text = expediente.contenedor.ToString();
                    }
                    DocExpediente.DataSource = documentoexpediente;
                    DocExpediente.DataBind();
                    DocExpediente.Visible = true;
                }
            
            // Ahora Abro el documento
            //Response.Write("<script type='text/javascript'>window.open('"+documento.CAMINO.Trim()+"//"+documento.DOCUMENTO.Trim()+"','cal','width=400,height=250,left=270,top=180');</script>");


        }

        protected void DocExpediente_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmiRecep Receptor = new EmiRecepManagement().GetEmiRecepByCodUsuario(Convert.ToInt32(SessionDocumental.UsuarioInicioSession.CODIGO.ToString()));
            Documentos documento = new DocumentosManagement().GetDocumentosById(Convert.ToInt32(DocExpediente.SelectedDataKey.Value.ToString()),Receptor.IDENTE);
            //ClientScript.RegisterStartupScript(this.Page.GetType(), "", "window.open('" + documento.CAMINO.Trim() + "/" + documento.DOCUMENTO.Trim() + "','Graph','height=400,width=500');", true);
            Response.Redirect("~/"+documento.CAMINO.Trim() + documento.DOCUMENTO.Trim(), "_blank", "menubar=0,scrollbars=1,width=780,height=900,top=10");
           

            //Response.Redirect();

        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {

            //Nuevo rediseño Boton Buscar

            
            //creo un datatable dinamico






            // rediseño del botón buscar

            //tomamos l condicion No. 1
            Session["condicion"] = "";
            if (CheckBox1.Checked)
            {
                Session["condicion"] = "(idserie =" + ddlserie.SelectedValue.ToString() + " AND idsubserie =" + ddlSubserie.SelectedValue.ToString() + "  AND idtipologia = " + DdlTipologia.SelectedValue.ToString() + ") and ";
            }

            DataTable matrizIndices  = new DataTable();

            DataColumn IDDOCUMENTO = matrizIndices.Columns.Add("iddocumento", typeof(Int32));

            for (int iindice = 0;iindice < gvindices.Rows.Count;iindice++)
            {
                string lcCampoAtributo = "atributo" + iindice.ToString();
                string lcCampoIndice = "indice" + iindice.ToString();

                matrizIndices.Columns.Add(lcCampoAtributo, typeof(String));
                matrizIndices.Columns.Add(lcCampoIndice, typeof(String));

            }

                    





            string lcPrimeraCondicion = "";



            
            TextBox indice = new TextBox();
            

            int lnPrim = 0;
            foreach (GridViewRow row in gvindices.Rows)
            {

                if (row.RowType == DataControlRowType.DataRow)
                {

                    indice = row.Cells[0].FindControl("txtindicegv") as TextBox;
                    if (indice.Text != "")
                    {
                         
                   
                        break;
                    }

                }
                lnPrim = lnPrim + 1;
            }


            lcPrimeraCondicion =  " atributo ='"+HttpUtility.HtmlDecode(gvindices.Rows[lnPrim].Cells[0].Text) + "' and UPPER(indice) like '%" + indice.Text.ToUpper()+"%'" ;
            string lcCondicionPrim = Session["condicion"].ToString() + lcPrimeraCondicion +" and iddocumento <> 0  order by iddocumento";

            DataTable listaindices = new DataTable();

            proce.consultacamposcondicion("indices", "iddocumento", lcCondicionPrim, listaindices);


            //condicion para traer los demas indices
            if (listaindices.Rows.Count != 0)
            {

                List<Indices> listapordocumento = new List<Indices>();
                List<Indices> listatotalindices = new List<Indices>();

                for (int i = 0; i < listaindices.Rows.Count; i++)
                {

                    listapordocumento = new IndicesManagement().GetIndicesByIdDocumento(Convert.ToInt32(listaindices.Rows[i]["iddocumento"]));
                    for (int j = 0; j < listapordocumento.Count; j++)
                    {
                        listatotalindices.Add(listapordocumento[j]);
                    }

                }


                //pasamos el objeto lista a un datatable para iniciar las subconsultas

                ListtoDataTableConverter converter = new ListtoDataTableConverter();

                DataTable DtListaIndices = converter.ToDataTable(listatotalindices);

                if (DtListaIndices.Rows.Count > 0)
                {
                    int iAtributos = 0;
                    int lnidDoc = Convert.ToInt32(DtListaIndices.Rows[0]["iddocumento"]);

                    for (int itablaindices = 0; itablaindices < DtListaIndices.Rows.Count; itablaindices++)
                    {
                        if (Convert.ToInt32(DtListaIndices.Rows[itablaindices]["iddocumento"]) != lnidDoc)
                        {
                            iAtributos = 0;
                            lnidDoc = Convert.ToInt32(DtListaIndices.Rows[itablaindices]["iddocumento"]);

                        }
                        if (iAtributos == 0)
                        {
                            //Adicionamos Fila

                            DataRow Fila = matrizIndices.NewRow();

                            Fila["iddocumento"] = lnidDoc;
                            matrizIndices.Rows.Add(Fila);

                        }
                        string lcCampoAtri = "atributo" + iAtributos.ToString();
                        string lcCampoIndi = "indice" + iAtributos.ToString();
                        matrizIndices.Rows[matrizIndices.Rows.Count-1 ][lcCampoAtri] = DtListaIndices.Rows[itablaindices]["ATRIBUTO"];
                        matrizIndices.Rows[matrizIndices.Rows.Count-1 ][lcCampoIndi] = DtListaIndices.Rows[itablaindices]["INDICE"];
                        iAtributos++;

                    }


                }


                //Una vez armados amamos la subconsulta

                string lcCondicion = "";
                for (int h = lnPrim + 1; h < gvindices.Rows.Count; h++)
                {
                    indice = gvindices.Rows[h].Cells[0].FindControl("txtindicegv") as TextBox;
                    if (indice.Text != "")
                    {
                        string lcCampoAtri = "atributo" + h.ToString();
                        string lcCampoIndi = "indice" + h.ToString();
                        if (lcCondicion == "")
                        {
                            lcCondicion = lcCampoAtri+ " = '" + HttpUtility.HtmlDecode(gvindices.Rows[h].Cells[0].Text.ToUpper()) + "' AND " + lcCampoIndi.ToUpper() + " LIKE '%" + indice.Text.ToUpper() + "%'";
                        }
                        else
                        {
                            lcCondicion = lcCondicion + " AND " +  lcCampoAtri.ToUpper()  + " = '" + HttpUtility.HtmlDecode(gvindices.Rows[h].Cells[0].Text.ToUpper()) + "' AND " + lcCampoIndi.ToUpper() + " LIKE '%" + indice.Text.ToUpper() + "%'";
                        }
                    }
                }


                DataRow[] foundRows;

                foundRows = matrizIndices.Select(lcCondicion, "iddocumento");

                if (foundRows.Length != 0)
                {

                    matrizIndices = foundRows.CopyToDataTable();

                    EmiRecep Receptor = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
                    List<Documentos> Listadocumentos = new List<Documentos>();
                    for (int k = 0; k < matrizIndices.Rows.Count; k++)
                    {
                        Documentos Doc = new DocumentosManagement().GetDocumentosById2(Convert.ToInt32(matrizIndices.Rows[k]["iddocumento"]));
                        Listadocumentos.Add(Doc);


                    }




                    if (Session["documentos"] == null)
                    {
                        Session.Add("documentos", Listadocumentos);
                    }
                    else
                    {
                        Session["documentos"] = Listadocumentos;
                    }


                    if (Listadocumentos.Count > 0)
                    {
                        this.DocumentosGridView.Visible = true;
                        this.DocumentosGridView.DataSource = Listadocumentos;
                        this.DocumentosGridView.DataBind();
                    }
                    else
                    {
                        this.DocumentosGridView.Visible = false;
                        DocumentosGridView.DataSource = "";
                        //DocumentosGridView.DataBind();
                    }
                }
                else
                {
                    this.DocumentosGridView.Visible = false;
                    DocumentosGridView.DataSource = "";
                    //DocumentosGridView.DataBind();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No hay coincidencias..');", true);

                }
            }
            else
            {
                this.DocumentosGridView.Visible = false;
                DocumentosGridView.DataSource = "";
               // DocumentosGridView.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No hay coincidencias..');", true);
            }

        }

        protected void DocumentosGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
            DocumentosGridView.PageIndex = e.NewPageIndex;
            DocumentosGridView.DataSource = Session["Documentos"];
            DocumentosGridView.DataBind();

            

        }


        public class ListtoDataTableConverter
        {

            public DataTable ToDataTable<T>(List<T> items)
            {

                DataTable dataTable = new DataTable(typeof(T).Name);

                //Get all the properties

                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (PropertyInfo prop in Props)
                {

                    //Setting column names as Property names

                    dataTable.Columns.Add(prop.Name);

                }

                foreach (T item in items)
                {

                    var values = new object[Props.Length];

                    for (int i = 0; i < Props.Length; i++)
                    {

                        //inserting property values to datatable rows

                        values[i] = Props[i].GetValue(item, null);

                    }

                    dataTable.Rows.Add(values);

                }

                //put a breakpoint here and check datatable

                return dataTable;

            }

        }
        

       

        
    }

}