using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using gestion_documental.BusinessObjects;
using gestion_documental.DataAccessLayer;
using System.Web.SessionState;
using gestion_documental.Utils;
using System.Web.SessionState;
using MySql.Data.MySqlClient;
//using System.DirectoryServices;
using System.Text;
using System.Collections;
//using System.DirectoryServices.ActiveDirectory;
using System.ComponentModel;
using System.Security.Principal;
using System.Net.NetworkInformation;


namespace gestion_documental
{
    public partial class ConsultaWorkFlow : System.Web.UI.Page
    {
        Class1 proce = new Class1();
        string condicion, busca,radicado,indice;
        string cadena;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UsuarioInicioSession"] == null)
            {
                Response.Redirect("Default.aspx");

            }

            if (!Page.IsPostBack)
            {
              
            }
        }


        protected void buscaradicado()
        {
            if (TxtRadicado.Text == "")
            {
                TxtRadicado.Focus();
                return;
            }
            else
            {
                DataTable Workflok = new DataTable();

                try
                {
                    //and  workflow.radicado ='INT20150017'
                    condicion = " and workflow.radicado = '" + TxtRadicado.Text.Trim() + "'";

                    proce.consultacamposcondicion("workflow , documentos , emirecep , emirecep dest,usuarios", "workflow.radicado,workflow.FECHA ,emirecep.descripcion as de , dest.descripcion as para , workflow.OBSERVACION ASUNTO ,  workflow.respuesta , documentos.documento , concat(documentos.camino,'/',documentos.documento) as camino,usuarios.nombre ", " workflow.IDDOCUMENTO = documentos.idDOCUMENTOS and workflow.IDEMIRECEP = emirecep.id and workflow.codigousuario = usuarios.codigo and workflow.IDEMIDESTINO = dest.id " + condicion + " ", Workflok);

                    if (Workflok.Rows.Count > 0)
                    {
                        GrvWorkFlow.Visible = true;
                        GrvWorkFlow.DataSource = Workflok;
                        GrvWorkFlow.DataBind();
                    }
                    else
                    {
                        GrvWorkFlow.Visible = false;
                        GrvWorkFlow.DataSource = "";
                        GrvWorkFlow.DataBind();
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No Se Encontraron Registros ...');", true);
                        omb.ShowMessage("No Se Encontraron Registros ...");
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('" + ex + "');", true);
                }
            }
        }

        protected void buscaindice()
        {


            if (TxtIndice.Text != "")
            {

                List<Documentos> documentos = new IndicesManagement().GetAllDocumentos(TxtIndice.Text, 0);

                DataTable Datos = ConvertToDataTable(documentos);


                try
                {
                    cadena = "";
                    if (cadena != "")
                    {
                        foreach (DataRow record in Datos.Rows)
                        {
                            busca = record["idDOCUMENTOS"].ToString();
                            //and  workflow.radicado ='INT20150017'

                            cadena += "," + busca;




                        }

                        int startIndex = 1;
                        int length = cadena.Length;
                        String doc = cadena.Substring(startIndex, length - startIndex);

                        condicion = " and workflow.IDDOCUMENTO in  (" + doc + ")";

                        DataTable Workflok = new DataTable();
                        proce.consultacamposcondicion("workflow , documentos , emirecep , emirecep dest,usuarios", "workflow.FECHA ,workflow.radicado, emirecep.descripcion as de , dest.descripcion as para , workflow.OBSERVACION ASUNTO ,  workflow.respuesta , documentos.documento , concat(documentos.camino,'/',documentos.documento) as camino,usuarios.nombre", " workflow.IDDOCUMENTO = documentos.idDOCUMENTOS and workflow.IDEMIRECEP = emirecep.id and workflow.IDEMIDESTINO = dest.id and workflow.codigousuario=usuarios.codigo " + condicion + " order by workflow.radicado ", Workflok);

                        if (Workflok.Rows.Count > 0)
                        {
                            GrvWorkFlow.Visible = true;
                            GrvWorkFlow.DataSource = Workflok;
                            GrvWorkFlow.DataBind();

                        }
                        else
                        {
                            GrvWorkFlow.Visible = true;
                            GrvWorkFlow.DataSource = "";
                            GrvWorkFlow.DataBind();
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No Se Encontraron Registros ...');", true);
                            omb.ShowMessage("No Se Encontraron Registros ...");
                        }
                    }

                    else
                    {
                        GrvWorkFlow.Visible = true;
                        GrvWorkFlow.DataSource = "";
                        GrvWorkFlow.DataBind();
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No Se Encontraron Registros ...');", true);
                        omb.ShowMessage("No Se Encontraron Registros ...");

                    }


                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('" + ex + "');", true);
                    omb.ShowMessage("Error..." + ex);
                }


            }


        }

        protected void ImgBtnRadicado_Click(object sender, ImageClickEventArgs e)
        {

            indice = "0";
            radicado = "1";

            buscaradicado();

        }

        protected void ImgBtnIndice_Click(object sender, ImageClickEventArgs e)
        {
            indice = "1";
            radicado = "";

            buscaindice();

        }



        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }



        protected void GrvWorkFlow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (radicado == "1")
            {
                buscaradicado();
            }

            if (indice == "1")
            {
                buscaradicado();
            }

            GrvWorkFlow.PageIndex = e.NewPageIndex;
        }


      
        protected void GrvWorkFlow_SelectedIndexChanged(object sender, EventArgs e)
        {
            string enlace = GrvWorkFlow.DataKeys[GrvWorkFlow.PageIndex].Value.ToString();
        }




        public class Documen
        {

            public string iddocumento { get; set; }
            public string fecha { get; set; }
            public string radicado { get; set; }
            public string de { get; set; }
            public string para { get; set; }
            public string asunto { get; set; }
            public string respuesta { get; set; }            
            public string documento { get; set; }
            public string camino { get; set; }

        }

        protected void ImgBtnBorrarRadicado_Click(object sender, ImageClickEventArgs e)
        {
            TxtRadicado.Text = "";
            GrvWorkFlow.DataSource = "";
            GrvWorkFlow.DataBind();
            GrvWorkFlow.Visible = false;
        }

        protected void ImgBtnBorrarIndice_Click(object sender, ImageClickEventArgs e)
        {
            TxtIndice.Text = "";
            GrvWorkFlow.DataSource = "";
            GrvWorkFlow.DataBind();
            GrvWorkFlow.Visible = false;
        }


    }
}