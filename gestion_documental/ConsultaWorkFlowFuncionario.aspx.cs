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
    public partial class ConsultaWorkFlowFuncionario : System.Web.UI.Page
    {
        Class1 proce = new Class1();
        EmiRecep receptor;
        string condicion, busca, radicado, indice;
        string cadena;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UsuarioInicioSession"] == null)
            {
                Response.Redirect("Default.aspx");
            }

            if (!Page.IsPostBack)
            {
                CargarFormulario();
            }
        }

        private void CargarFormulario()
        {
            receptor = new EmiRecepManagement().GetEmiRecepByIdusuario(SessionDocumental.UsuarioInicioSession.CODIGO);

            DdlFuncionario.DataSource = new EmiRecepManagement().GetAllFuncionarios(receptor.IDRADICADO);
            DdlFuncionario.DataValueField = "IDEMIRECEP";
            DdlFuncionario.DataTextField = "FUNCIONARIO";
            DdlFuncionario.DataBind();
            DdlFuncionario.SelectedValue = receptor.ID.ToString();

            DdlEstado.Items.Add("--Seleccionar--");
            DdlEstado.Items.Add("1. PENDIENTE");
            DdlEstado.Items.Add("2. EN PROCESO");
            DdlEstado.Items.Add("3. REENVIADO");
            DdlEstado.Items.Add("4. COMPARTIDO");
            DdlEstado.Items.Add("7. APROBADO Y REENVIAR");
            DdlEstado.Items.Add("5. FINALIZADO");
            DdlEstado.Items.Add("6. REENVIAR A TODOS");
            DdlEstado.Items.Add("8. RECHAZADO Y REENVIAR");
        }

        protected void buscardatos()
        {
            if (Txt_Fecha_Inicio.Text == "" || Txt_Fecha_Fin.Text == "" || DdlFuncionario.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Falta ingresar un filtro ...');", true);
                return;
            }
            else
            {
                DataTable Workflok = new DataTable();

                string fechaini = Txt_Fecha_Inicio.Text;
                string fechafin = Txt_Fecha_Fin.Text;
                int idemi = Convert.ToInt32(DdlFuncionario.SelectedValue);
                string estado = DdlEstado.SelectedValue;
                LblMovimientos.Text = "";
                LblEstado.Text = "";

                DataAccessLayer.WorkFlowManagement.fechaini = fechaini;
                DataAccessLayer.WorkFlowManagement.fechafin = fechafin;
                DataAccessLayer.WorkFlowManagement.idemi = idemi;
                DataAccessLayer.WorkFlowManagement.estado = estado;

                try
                {
                    string TTodos = "";
                    string TEstado = "";
                  
                    condicion = " workflow.fecha BETWEEN '" + fechaini + "' AND '" + fechafin + "' AND workflow.idemidestino = " + idemi;
                    if (!(DdlEstado.SelectedValue == "--Seleccionar--"))
                    {
                        condicion = condicion + " AND workflow.estado = '" + estado + "'";
                    }

                    proce.consultauncampocondicion("workflow LEFT JOIN emirecep ON workflow.idemidestino = emirecep.id", "COUNT(workflow.id) AS TTodos", " emirecep.id =" + idemi, ref TTodos);
                    //proce.consultauncampocondicion("workflow LEFT JOIN emirecep ON workflow.idemirecep = emirecep.id", "COUNT(workflow.id) AS TEstado", " emirecep.id = " + idemi + " AND workflow.fecha between '" + fechaini + "' AND '" + fechafin + "'" + condicionestado, ref TEstado);
                    proce.consultauncampocondicion("workflow LEFT JOIN emirecep ON workflow.idemidestino = emirecep.id", "COUNT(workflow.id) AS TEstado", condicion, ref TEstado);

                    proce.consultacamposcondicion(" workflow LEFT JOIN emirecep ON workflow.idemirecep = emirecep.id LEFT JOIN emirecep AS em ON workflow.idemidestino = em.id LEFT JOIN documentos ON workflow.iddocumento = documentos.iddocumentos",
                        " workflow.fecha,workflow.radicado,emirecep.descripcion AS De,em.descripcion AS Para,workflow.observacion AS asunto, documentos.documento,workflow.respuesta,workflow.fecharespuesta,workflow.radicado2,concat(documentos.camino,'/',documentos.documento) as camino,workflow.estado",
                        condicion + " order by workflow.estado", Workflok);

                    if (Workflok.Rows.Count > 0)
                    {
                        LblMovimientos.Text = TTodos;
                        LblEstado.Text = TEstado;
                        GrvWorkFlow.Visible = true;
                        GrvWorkFlow.DataSource = Workflok;
                        GrvWorkFlow.DataBind();
                        Response.Redirect("ConsultaWorkflowReport.aspx", "_blank", "menubar=0,scrollbars=1,width=780,height=900,top=10");
                    }
                    else
                    {
                        GrvWorkFlow.Visible = false;
                        GrvWorkFlow.DataSource = "";
                        GrvWorkFlow.DataBind();
                        omb.ShowMessage("No Se Encontraron Registros ...");
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('" + ex + "');", true);
                }
            }
        }

        protected void ImgBtnConsulta_Click(object sender, ImageClickEventArgs e)
        {
            buscardatos();
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
            buscardatos();
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
            //TxtRadicado.Text = "";
            GrvWorkFlow.DataSource = "";
            GrvWorkFlow.DataBind();
            GrvWorkFlow.Visible = false;
        }

        protected void ImgBtnBorrarIndice_Click(object sender, ImageClickEventArgs e)
        {
            //TxtIndice.Text = "";
            GrvWorkFlow.DataSource = "";
            GrvWorkFlow.DataBind();
            GrvWorkFlow.Visible = false;
        }

        private void set_DropDownList(DropDownList item, DataTable objeto, string id, string text, bool con_select = false)
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
    }
}