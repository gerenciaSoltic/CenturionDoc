using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestion_documental.DataAccessLayer;
using MySql.Data.MySqlClient;
using System.Data;
using gestion_documental.Utils;
using System.Data.OleDb;
using gestion_documental.BusinessObjects;
using System.ComponentModel;

namespace gestion_documental
{
    public partial class ConsultaAtenciones : System.Web.UI.Page
    {
        Class1 proce = new Class1();
        string iddocumento;
        string cadena, condicion, condicionAtenciones;
        public string IdCadena;
        //public DataTable dtAtenciones;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UsuarioInicioSession"] == null)
            {
                Response.Redirect("Default.aspx");

            }
            if (!IsPostBack)
            {
                DdlTipo.Items.Add("ENTRANTE");
                DdlTipo.Items.Add("SALIENTE");
                DdlTipo.Items.Add("INTERNA");

                DDLgrupocom.DataSource = new grupocomManagement().GetGrupocomByIdradicado(Convert.ToInt32(new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO).IDRADICADO));
                DDLgrupocom.DataTextField = "nombre";
                DDLgrupocom.DataValueField = "ID";
                DDLgrupocom.DataBind();
                DDLgrupocom.Items.Insert(0, new ListItem("0. TODOS"));
                

                
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
                */
                string lcInforme = Request.QueryString["informe"];
                Session.Add("lcInforme", lcInforme);
            }

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


        protected void BtnConsultar_Click(object sender, EventArgs e)
        {

            /*
            if (txtFechaDesde.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe Ingresar la Fecha...');", true);
                txtFechaDesde.Focus();
                return;
            }

            if (TxtFechaHasta.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe Ingresar la Fecha...');", true);
                TxtFechaHasta.Focus();
                return;
            }

             * */
             // Averiguamos que tipo de radicado debemos FILTRAR

            int lnTipo = 0;
            switch (DdlTipo.SelectedValue.ToString())
            {
                case "ENTRANTE":
                    lnTipo = 1;
                    break;

                case "SALIENTE":
                    lnTipo = 2;
                    break;

                case "INTERNA":
                    lnTipo = 3;
                    break;
            }


            //DataSet ds = new DataSet();
            //ConnectionClass conectar = new ConnectionClass();
            //MySqlDataAdapter adaptador;

            String lcSemaforo = "";
            if (DDLgrupocom.SelectedItem.Value == "0. TODOS")
            {
                lcSemaforo = "0. TODOS";
            }
            else
            {
                for (int i = 0; i < LstTipoCom.Items.Count; i++)
                {
                    if (lcSemaforo == "")
                    {
                        lcSemaforo = "'" + LstTipoCom.Items[i].ToString() + "'";
                    }
                    else
                    {
                        lcSemaforo = lcSemaforo + ",'" + LstTipoCom.Items[i].ToString() + "'";
                    }
                }
            }
                try
                {


                    //proce.consultacamposcondicion("Workflow as c  , emirecep d , emirecep e , documentos f", "c.FECHA Fecha, trim(IF(c.idemirecep IS NULL, '0', c.idemirecep)) as IdDe ,d.descripcion De,trim(IF(c.IDENTEDESTINO IS NULL, '0', c.IDENTEDESTINO)) as IdPara ,e.descripcion Para , trim(c.semaforo) as Tipo,  trim(c.RADICADO) as Radicado , f.folios as F , trim(c.OBSERVACION) as Asunto,  trim(c.respuesta) Respuesta , c.fecharespuesta FecResp,  trim(c.radicado2) RadResp ,  trim(c.idtarea) as idtarea ,  trim(c.idcadena) as idcadena ", " c.idemirecep = d.id and c.identedestino = e.id and c.iddocumento = f.iddocumentos " + condicionAtenciones + " AND fecha between '" + txtFechaDesde.Text + "' AND '" + TxtFechaHasta.Text + "'", dtAtenciones);
               

                    //conectar.conectar();
                    //conectar.Connection.Open();
 
                    //adaptador = new MySqlDataAdapter("SELECT c.FECHA Fecha  " +
                    //            "  ,  trim(IF(c.idemirecep IS NULL, '0', c.idemirecep)) as IdDe " +
                    //            "  ,  d.descripcion De " +
                    //            "  ,  trim(IF(c.IDENTEDESTINO IS NULL, '0', c.IDENTEDESTINO)) as IdPara " +
                    //            "  ,   e.descripcion Para " +
                    //            "  ,  trim(c.semaforo) as Tipo,  trim(c.RADICADO) as Radicado " +
                    //            "  ,  f.folios as F" + 
                    //            "  ,  trim(c.OBSERVACION) as Asunto,  trim(c.respuesta) Respuesta " +
                    //            "  ,  c.fecharespuesta FecResp,  trim(c.radicado2) RadResp " +
                    //            "  ,  trim(c.idtarea) as idtarea ,  trim(c.idcadena) as idcadena " +
                    //            "  FROM Workflow as c  , emirecep d , emirecep e , documentos f " +
                    //            "  WHERE c.idemirecep = d.id " +
                    //            "  and c.identedestino = e.id " +
                    //            "  and c.iddocumento = f.iddocumentos " +

                    //            " " + condicionAtenciones +                                                                  
                    //            // " c.tipo = " + DdlTipo.SelectedValue +
                    //            "  AND fecha between '" + txtFechaDesde.Text + "' AND '" + TxtFechaHasta.Text + "'" ,conectar.Connection);

                    //adaptador.Fill(ds);

                    //DataTable dtAtenciones = ds.Tables[0];


                    DataAccessLayer.WorkFlowManagement.Fdesde = txtFechaDesde.Text;
                    DataAccessLayer.WorkFlowManagement.Fhasta = TxtFechaHasta.Text;
                    DataAccessLayer.WorkFlowManagement.confuncionario = false;

                    switch (DdlTipo.SelectedValue.ToString())
                    {
                        case "ENTRANTE":
                            lnTipo = 1;
                            break;

                        case "SALIENTE":
                            lnTipo = 2;
                            break;

                        case "INTERNA":
                            lnTipo = 3;
                            break;
                    }

                    EmiRecep emisorVentanilla = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
                    DataAccessLayer.WorkFlowManagement.Ventanilla = emisorVentanilla.IDENTE;
                    DataAccessLayer.WorkFlowManagement.lnTipo = lnTipo;
                    DataAccessLayer.WorkFlowManagement.semaforo = lcSemaforo;
                    DataAccessLayer.WorkFlowManagement.lcRadicado = TxtRadicado.Text;
                    DataAccessLayer.WorkFlowManagement.tipoinforme = 1;

                    List<Recepcion> lstAtenciones = new WorkFlowManagement().GetWorkflowByfecha();
                    DataTable dtAtenciones = ConvertToDataTable(lstAtenciones);

                    if (dtAtenciones.Rows.Count > 0)
                    {
                        
                        GrvAtenciones.Visible = true;
                        GrvAtenciones.DataSource = dtAtenciones;
                        GrvAtenciones.DataBind();
                        
                    }
                    else
                    {
                        GrvAtenciones.Visible = false;
                        GrvAtenciones.DataSource = dtAtenciones;
                        GrvAtenciones.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('" + ex + "');", true);
                }


            //conectar.Connection.Close();

        }

        protected void GrvAtenciones_SelectedIndexChanged(object sender, EventArgs e)
        {
     
           //IdCadena = this.GrvAtenciones.Rows[GrvAtenciones.SelectedIndex].Cells[10].Text;
            IdCadena = this.GrvAtenciones.SelectedDataKey.Value.ToString();
  
           //DataSet ds = new DataSet();
           //ConnectionClass conectar = new ConnectionClass();
           //MySqlDataAdapter adaptador;

           try
           {
               //conectar.conectar();
               //conectar.Connection.Open();

               DataTable dt = new DataTable();
               proce.consultacamposcondicion("Workflow as c ", "c.iddocumento,trim(c.idcadena) as idcadena", "c.idcadena = '" + IdCadena + "'", dt);

               //adaptador = new MySqlDataAdapter("SELECT c.iddocumento,  " +
               //           "  trim(c.idcadena) as idcadena " +
               //           "  FROM Workflow as c  " +
               //           "  WHERE c.idcadena = '" + IdCadena + "'", conectar.Connection);

               //adaptador.Fill(ds);
               //conectar.Connection.Close();

               //DataTable dt = ds.Tables[0];

               foreach (DataRow record in dt.Rows)
               {
                   iddocumento = record["iddocumento"].ToString();
                   cadena += "," + iddocumento;
               }

               int startIndex = 1;
               int length = cadena.Length;
               String doc = cadena.Substring(startIndex, length - startIndex);

               condicion = " documentos.IDDOCUMENTOS in  (" + doc + ")";

               DataTable DtDocumentos = new DataTable();
               proce.consultacamposcondicion("documentos", "documentos.documento as Documento , documentos.folios as Folios, SUBSTRING(documentos.descripcion,1,50) as Descripcion, concat(documentos.camino,'/',documentos.documento) as camino", "" + condicion, DtDocumentos);

               if (DtDocumentos.Rows.Count > 0)
               {
                   GridView2.Visible = true;
                   GridView2.DataSource = DtDocumentos;
                   GridView2.DataBind();
               }
               else
               {
                   GridView2.Visible = false;
                   GridView2.DataSource = "";
                   GridView2.DataBind();
               }

               HiddenField1_ModalPopupExtender.Show();

           }
           catch (Exception ex)
           {
               ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('" + ex + "');", true);
           }


           //conectar.Connection.Close();
           
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            HiddenField1_ModalPopupExtender.Hide();
        }

        protected void GrvAtenciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {


            //DataSet ds = new DataSet();
            //ConnectionClass conectar = new ConnectionClass();
            //MySqlDataAdapter adaptador;

            String lcSemaforo = "";
            if (DDLgrupocom.SelectedItem.Value == "0. TODOS")
            {
                lcSemaforo = "0. TODOS";
            }
            else
            {
                for (int i = 0; i < LstTipoCom.Items.Count; i++)
                {
                    if (lcSemaforo == "")
                    {
                        lcSemaforo = "'" + LstTipoCom.Items[i].ToString() + "'";
                    }
                    else
                    {
                        lcSemaforo = lcSemaforo + ",'" + LstTipoCom.Items[i].ToString() + "'";
                    }
                }
            }

            try
            {

                //DataTable dtAtenciones = new DataTable();
                //proce.consultacamposcondicion("Workflow as c  , emirecep d , emirecep e , documentos f", "c.FECHA Fecha, trim(IF(c.idemirecep IS NULL, '0', c.idemirecep)) as IdDe ,d.descripcion De,trim(IF(c.IDENTEDESTINO IS NULL, '0', c.IDENTEDESTINO)) as IdPara ,e.descripcion Para , trim(c.semaforo) as Tipo,  trim(c.RADICADO) as Radicado , f.folios as F , trim(c.OBSERVACION) as Asunto,  trim(c.respuesta) Respuesta , c.fecharespuesta FecResp,  trim(c.radicado2) RadResp ,  trim(c.idtarea) as idtarea ,  trim(c.idcadena) as idcadena ", " c.idemirecep = d.id and c.identedestino = e.id and c.iddocumento = f.iddocumentos " + condicionAtenciones + " AND fecha between '" + txtFechaDesde.Text + "' AND '" + TxtFechaHasta.Text + "'", dtAtenciones);


                //conectar.conectar();
                //conectar.Connection.Open();

                //adaptador = new MySqlDataAdapter("SELECT c.FECHA Fecha  " +
                //           "  ,  trim(IF(c.idemirecep IS NULL, '0', c.idemirecep)) as IdDe " +
                //           "  ,  d.descripcion De " +
                //           "  ,  trim(IF(c.IDENTEDESTINO IS NULL, '0', c.IDENTEDESTINO)) as IdPara " +
                //           "  ,   e.descripcion Para " +
                //           "  ,  trim(c.semaforo) as Tipo,  trim(c.RADICADO) as Radicado " +
                //           "  ,  f.folios as F" +
                //           "  ,  trim(c.OBSERVACION) as Asunto,  trim(c.respuesta) Respuesta " +
                //           "  ,  c.fecharespuesta FecResp,  trim(c.radicado2) RadResp " +
                //           "  ,  trim(c.idtarea) as idtarea ,  trim(c.idcadena) as idcadena " +
                //           "  FROM Workflow as c  , emirecep d , emirecep e , documentos f " +
                //           "  WHERE c.idemirecep = d.id " +
                //           "  and c.identedestino = e.id " +
                //           "  and c.iddocumento = f.iddocumentos " +

                //           " " + condicionAtenciones +  
                //            // " c.tipo = " + DdlTipo.SelectedValue +
                //           "  AND fecha between '" + txtFechaDesde.Text + "' AND '" + TxtFechaHasta.Text + "'", conectar.Connection);


                //adaptador.Fill(ds);



                DataAccessLayer.WorkFlowManagement.Fdesde = txtFechaDesde.Text;
                DataAccessLayer.WorkFlowManagement.Fhasta = TxtFechaHasta.Text;

                int lnTipo = 0;
                switch (DdlTipo.SelectedValue.ToString())
                {
                    case "ENTRANTE":
                        lnTipo = 1;
                        break;

                    case "SALIENTE":
                        lnTipo = 2;
                        break;

                    case "INTERNA":
                        lnTipo = 3;
                        break;
                }
                EmiRecep emisorVentanilla = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
                DataAccessLayer.WorkFlowManagement.Ventanilla = emisorVentanilla.IDENTE;
                    
                DataAccessLayer.WorkFlowManagement.lnTipo = lnTipo;
                DataAccessLayer.WorkFlowManagement.semaforo = lcSemaforo;

                List<Recepcion> lstAtenciones = new WorkFlowManagement().GetWorkflowByfecha();
                DataTable dtAtenciones = ConvertToDataTable(lstAtenciones);

                GrvAtenciones.DataSource = dtAtenciones;
                GrvAtenciones.DataBind();
                //conectar.Connection.Close();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('" + ex + "');", true);
            }


            GrvAtenciones.PageIndex = e.NewPageIndex;
            
        }

        protected void DDLgrupocom_SelectedIndexChanged(object sender, EventArgs e)
        {
            DmpSemaforo.DataSource = new TipocomManagement().GetTipoComById(Convert.ToInt32(DDLgrupocom.SelectedItem.Value));
            DmpSemaforo.DataTextField = "Tipocomunicacion";
            DmpSemaforo.DataValueField = "Tipocomunicacion";
            DmpSemaforo.DataBind();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            LstTipoCom.Items.Add(DmpSemaforo.SelectedItem.Value.ToString());


        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (LstTipoCom.SelectedValue == null)
            {

            }
            else
            {
                LstTipoCom.Items.Remove(LstTipoCom.SelectedItem);
            }


        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            ListBox TempoTipos = new ListBox();
            TempoTipos.DataValueField = "Tipocomunicacion";
            TempoTipos.DataSource = new TipocomManagement().GetTipoComById(Convert.ToInt32(DDLgrupocom.SelectedItem.Value));

            TempoTipos.DataBind();

            for (int i = 0; i < TempoTipos.Items.Count; i++)
            {
                LstTipoCom.Items.Add(TempoTipos.Items[i].ToString());
            }
        }

    }
}