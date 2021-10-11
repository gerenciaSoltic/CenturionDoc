using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using gestion_documental.Utils;
using gestion_documental.DataAccessLayer;
using gestion_documental.BusinessObjects;
using System.Globalization;

namespace gestion_documental
{
    public partial class HojaControlContratos : System.Web.UI.Page
    {
        Class1 proce = new Class1();
        BasePage nuevabase = new BasePage();
        SerieManagement _serie = new SerieManagement();
        SubSerieManagement _subserie = new SubSerieManagement();
        ExpedienteManagement _expediente = new ExpedienteManagement();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Session["historias"] = "";
                Session["escalafon"] = "";
                Session["prestaciones"] = "";
                Session["estado"] = "";
                txtcarpeta.Text = "1";
                DataTable data = new DataTable();

                DataColumn id = new DataColumn("id");
                id.DataType = System.Type.GetType("System.Double");
                data.Columns.Add(id);

                DataColumn numerocontrato = new DataColumn("numerocontrato");
                numerocontrato.DataType = System.Type.GetType("System.String");
                data.Columns.Add(numerocontrato);

            

              DataColumn idtipologia = new DataColumn("idtipologia");
                idtipologia.DataType = System.Type.GetType("System.String");
                data.Columns.Add(idtipologia);


                
                DataColumn folios = new DataColumn("folios");
                folios.DataType = System.Type.GetType("System.String");
                data.Columns.Add(folios);

                DataColumn fecha = new DataColumn("fecha");
                fecha.DataType = System.Type.GetType("System.String");
                data.Columns.Add(fecha);

              

                DataColumn tipodocumental = new DataColumn("tipodocumental");
                tipodocumental.DataType = System.Type.GetType("System.String");
                data.Columns.Add(tipodocumental);
                              

               
                DataColumn numero = new DataColumn("numero");
                numero.DataType = System.Type.GetType("System.String");
                data.Columns.Add(numero);

               

             
              
                DataColumn carpeta = new DataColumn("carpeta");
                carpeta.DataType = System.Type.GetType("System.String");
                data.Columns.Add(carpeta);

               

                for (int i = 0; i < 30; i++)
                {
                    DataRow fila = data.NewRow();
                    fila["carpeta"] = 1;
                    data.Rows.Add(fila);
                }
                Session.Add("dataset", data);
                gvhojadevida.DataSource = data;
                gvhojadevida.DataBind();

              

                ddlserie.DataSource = _serie.GetAllSeries();
                ddlserie.DataTextField = "serie";
                ddlserie.DataValueField = "id";
                ddlserie.DataBind();
                llenarsubserie();

                ddlEnte.DataSource = new DataAccessLayer.EnteManagement().GetAllEntes();
                ddlEnte.DataTextField = "descripcion";
                ddlEnte.DataValueField = "idente";
                ddlEnte.DataBind();


            }
        }

        protected void btcrear_Click(object sender, EventArgs e)
        {
            
            Session["estado"] = "";
            DataTable data = new DataTable();
            proce.consultacamposcondicion("hojacontrolcontratos", "*", "numerocontrato='" + txtNumeroContrato.Text + "' and carpeta = '"+  txtcarpeta.Text+"' and idinstitucion='" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + "'", data);
            if (data.Rows.Count < 1)
            {
                if (obteenervalores())
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Registro Creado');", true);
                    //blanqueartexto();
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('El Documento ya Tiene Registros');", true);
            }

            

        }
        public bool obteenervalores()
        {

            string fechaanterior = "";

            // Session["opcion"] = "duplicar";
            DataTable bloque = Session["dataset"] as DataTable;
            bloque.Clear();
            bool llSihay = false;
            foreach (GridViewRow row in gvhojadevida.Rows)
            {

                if (row.RowType == DataControlRowType.DataRow)
                {

                    DataRow fila1 = bloque.NewRow();
                    TextBox fecha = row.Cells[1].FindControl("txtfecha") as TextBox;
                    DropDownList tipodocumental = row.Cells[1].FindControl("txttipodocumental") as DropDownList;
                    if (fecha.Text != "" && tipodocumental.SelectedValue != "")
                    {

                        llSihay = true;
                        
                        fila1["fecha"] = fecha.Text;
                        fila1["idtipologia"] = tipodocumental.SelectedValue.ToString();
                        fila1["tipodocumental"] = tipodocumental.SelectedItem.Text;
                        TextBox folios = row.Cells[1].FindControl("txtfolios") as TextBox;
                        fila1["folios"] = folios.Text;
                        fechaanterior = fecha.Text;
                        TextBox carpeta = row.Cells[1].FindControl("txtcarpeta") as TextBox;
                        fila1["carpeta"] = txtcarpeta.Text;
                        TextBox numero = row.Cells[1].FindControl("txtNumero") as TextBox;

                                              
                        fila1["numero"] = numero.Text;
                       
                        bloque.Rows.Add(fila1);

                    }



                }
            }

            if (!llSihay)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No hay registros para grabar');", true);
                return false;
            }

            DataTable datserie = new DataTable();
            proce.consultacamposcondicion("serie", "codigo", "id = " + ddlserie.SelectedValue.ToString(), datserie);
            for (int i = 0; i < bloque.Rows.Count; i++)
            {
                proce.insertaralgunos("hojacontrolcontratos", "numerocontrato,idente,idserie,idsubserie,idtipologia,fecha,numero,folios,nombrecontratista,carpeta,serie,subserie,tipodocumental,oficina,idinstitucion,fecregistro,usuario,codigo", "'" + txtNumeroContrato.Text+ "','" +ddlEnte.SelectedValue.ToString()+"','"+ ddlserie.SelectedValue.ToString() + "','" +ddlsubserie.SelectedValue.ToString() + "','" + bloque.Rows[i]["idtipologia"].ToString() + "','" +  bloque.Rows[i]["fecha"].ToString() + "','" + bloque.Rows[i]["numero"].ToString() + "','" + bloque.Rows[i]["folios"].ToString() + "','" + txtNombreContratista.Text + "','" + bloque.Rows[i]["carpeta"].ToString() + "','" + ddlserie.SelectedItem.Text + "','" + ddlsubserie.SelectedItem.Text + "','" + bloque.Rows[i]["tipodocumental"].ToString() + "','" + ddlEnte.SelectedItem.Text+ "','" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION.ToString() + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','"+SessionDocumental.UsuarioInicioSession.USUARIO+"','"+datserie.Rows[0]["codigo"].ToString()+"'");
            }
            DataTable data1 = new DataTable();
            proce.consultacamposcondicion("hojacontrolcontratos", "max(fecha) as fechafin,min(fecha) as fechaini", "numerocontrato ='" + txtNumeroContrato.Text + "' and carpeta = '"+txtcarpeta.Text+"' and idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION, data1);

            Expediente expe = new Expediente();
            if (Session["estado"].ToString() == "editar")
            {
                expe = _expediente.GetExpedientenumerodeidentificacion(txtNumeroContrato.Text);
                expe.idente = Convert.ToInt32(ddlEnte.SelectedValue);
                expe.numerodeidentificacion = txtNumeroContrato.Text;
                expe.idserie = Convert.ToInt32(ddlserie.SelectedValue);
                expe.idsubserie = Convert.ToInt32(ddlsubserie.SelectedValue);
                expe.Fechainicio = Convert.ToDateTime(proce.formateafecha(Convert.ToDateTime(data1.Rows[0]["fechaini"].ToString()),0));
                expe.Fechafinal = Convert.ToDateTime(proce.formateafecha(Convert.ToDateTime(data1.Rows[0]["fechafin"].ToString()),0));
                expe.descripcion = ddlsubserie.Text+" "+txtNumeroContrato.Text;
                _expediente.UpdateExpediente(expe);
            }
            else
            {
              
                expe.idente = Convert.ToInt32(ddlEnte.SelectedValue);
                expe.numerodeidentificacion = txtNumeroContrato.Text;
                expe.idserie = Convert.ToInt32(ddlserie.SelectedValue);
                expe.idsubserie = Convert.ToInt32(ddlsubserie.SelectedValue);
                expe.Fechainicio = Convert.ToDateTime(proce.formateafecha(Convert.ToDateTime(data1.Rows[0]["fechaini"].ToString()),0));
                expe.Fechafinal = Convert.ToDateTime(proce.formateafecha(Convert.ToDateTime(data1.Rows[0]["fechafin"].ToString()),0));
                expe.descripcion = ddlsubserie.Text+" "+txtNumeroContrato.Text;
                _expediente.InsertExpediente(expe);
            }


            DataTable data = new DataTable();
          
          
            
            int numerofolios = 0;
            string identificador = "-";
            int NU = 0;
            proce.consultacamposcondicion("hojacontrolcontratos", "max(id) as id,folios", "numerocontrato='" + txtNumeroContrato.Text + "' and carpeta = '"+txtcarpeta.Text+"' and idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION.ToString(), data);
            if (data.Rows.Count > 0)
            {

                NU = data.Rows[0]["folios"].ToString().IndexOf(identificador);
                if (NU > 0)
                {
                    numerofolios = Convert.ToInt32(data.Rows[0]["folios"].ToString().Split('-')[1]);
                }
                else
                {
                    numerofolios = Convert.ToInt32(data.Rows[0]["folios"].ToString());
                }
            }
            //
           
           
            // Primero miro si ya existe

            DataTable DatHoja = new DataTable();
            proce.consultacamposcondicion("inventariocontratacion", "id", "numerocontrato ='" + txtNumeroContrato.Text + "' and volumen ='"+txtcarpeta.Text+"' and idinstitucion = "+SessionDocumental.UsuarioInicioSession.IDINSTITUCION.ToString(), DatHoja);

            if (DatHoja.Rows.Count > 0)
            {
                proce.editar("inventariocontratacion","numerofolios ="+numerofolios+",nombrecontratista='"+txtNombreContratista.Text+"',idsubserie ='"+ddlsubserie.SelectedValue.ToString()+"',subserie ='"+ddlsubserie.SelectedItem.Text+"'","id="+DatHoja.Rows[0][0].ToString());
            }
            else
            {
            proce.insertaralgunos("inventariocontratacion", "idoficinaproductora,codigo,nombreserie,idserie,unidadconservacion,numerofolios,volumen,nombrecontratista,numerocontrato,oficina,idsubserie,subserie,idinstitucion,usuario", "'" + ddlEnte.SelectedValue.ToString() + "','" + datserie.Rows[0]["codigo"].ToString() + "','" + ddlserie.SelectedItem.Text + "','" + ddlserie.SelectedValue.ToString() + "','CARPETA'," +numerofolios  + ",'" + txtcarpeta.Text + "','" + txtNombreContratista.Text+ "','" + txtNumeroContrato.Text + "','" +ddlEnte.SelectedItem.Text +"','"+ ddlsubserie.SelectedValue.ToString()+"','"+ddlsubserie.SelectedItem.Text+"','"+  SessionDocumental.UsuarioInicioSession.IDINSTITUCION.ToString() + "','"+SessionDocumental.UsuarioInicioSession.USUARIO+"'");
            }
            return true;
        }

       
        public void buscar()
        {
            DataTable bloque = Session["dataset"] as DataTable;
            bloque.Clear();
            DataTable data = new DataTable();


            data.Clear();

            proce.consultacamposcondicion("hojacontrolcontratos c", "*,tipodocumental as nombre", "c.numerocontrato='" +txtNumeroContrato.Text+ "' and carpeta ='"+txtcarpeta.Text+"' and c.idinstitucion='" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + "'", data);
            if (data.Rows.Count > 0)
            {
                         
                gvhojadevida.DataSource = data;
                gvhojadevida.DataBind();
                Session["dataset"] = data;
            }
            else
            {
                for (int i = 0; i < 30; i++)
                {
                    DataRow fila = data.NewRow();
                    fila["carpeta"] = 1;
                    data.Rows.Add(fila);
                }
                Session.Add("dataset", data);
                gvhojadevida.DataSource = data;
                gvhojadevida.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('El Documento No Tiene Registros');", true);


            }
           
        }

        protected void bteditar_Click(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            proce.consultacamposcondicion("hojacontrolcontratos", "*", "numerocontrato='" + txtNumeroContrato.Text + "' and carpeta= '"+ txtcarpeta.Text+"' and idinstitucion='" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + "'", data);
            if (data.Rows.Count > 0)
            {
                proce.eliminar("hojacontrolcontratos", "numerocontrato='" + txtNumeroContrato.Text + "' and carpeta= '" + txtcarpeta.Text + "' and idinstitucion='" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION+"'");

                proce.eliminar("inventariocontratacion", "numerocontrato='" + txtNumeroContrato.Text + "' and volumen= '" + txtcarpeta.Text + "' and idinstitucion='" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + "'");
                Session["estado"] = "editar";
                obteenervalores();
               // blanqueartexto();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Registro Actualizado');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('El Documento No se puede Actualizar Porque No Tiene Registros');", true);
            }
        }

        protected void bteliminar_Click(object sender, EventArgs e)
        {
            proce.eliminar("hojacontrolcontratos", "numerocontrato='" + txtNumeroContrato.Text + "' and carpeta= '" + txtcarpeta.Text + "' and idinstitucion='" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + "'");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Registro Eliminado');", true);
            blanqueartexto();
        }

        protected void ckaddfilahoja_CheckedChanged(object sender, EventArgs e)
        {
            DataTable bloque = Session["dataset"] as DataTable;
            obteenervalores();
            /*
            bloque.Clear();
            foreach (GridViewRow row in gvhojadevida.Rows)
            {

                if (row.RowType == DataControlRowType.DataRow)
                {
                    DataRow fila1 = bloque.NewRow();
                    TextBox fecha = row.Cells[1].FindControl("txtfecha") as TextBox;
                    fila1["fecha"] = fecha.Text;
                    DropDownList tipodocumental = row.Cells[1].FindControl("txttipodocumental") as DropDownList;
                    fila1["tipodocumental"] = tipodocumental.SelectedValue;
                    TextBox folios = row.Cells[1].FindControl("txtfolios") as TextBox;
                    fila1["folios"] = folios.Text;
                    TextBox carpeta = row.Cells[1].FindControl("txtcarpeta") as TextBox;
                    fila1["carpeta"] = carpeta.Text;
                    bloque.Rows.Add(fila1);

                }
            }
             **/
            for (int i = 0; i < 30; i++)
            {
                DataRow fila = bloque.NewRow();
                fila["carpeta"] = txtcarpeta.Text;
                bloque.Rows.Add(fila);
            }
            gvhojadevida.DataSource = bloque;
            gvhojadevida.DataBind();
            ckaddfilahoja.Checked = false;
        }

       
        public void blanqueartexto()
        {

            txtNombreContratista.Text = "";
            txtNumeroContrato.Text = "";
            txtcarpeta.Text = "";

          
            gvhojadevida.DataSource = "";
            gvhojadevida.DataBind();
          
        }
       

        protected void btimprimir_Click(object sender, EventArgs e)
        {
            RHojacontrolContratos.numerocontrato = txtNumeroContrato.Text;
            RHojacontrolContratos.carpeta = txtcarpeta.Text;
            Response.Redirect("~//reporting/RHojaControlContratos.aspx", "_blank", " menubar=0,scrollbars=1,width=780,height=900,top=10");
        }
        public void llenarsubserie()
        {
            ddlsubserie.DataSource = _subserie.GetAllSubSeriesBySerie(Convert.ToInt32(ddlserie.SelectedValue));
            ddlsubserie.DataTextField = "SUBSERIE";
            ddlsubserie.DataValueField = "id";
            ddlsubserie.DataBind();
        }

        protected void ddlserie_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarsubserie();
        }

        protected void txtbucar_TextChanged(object sender, EventArgs e)
        {
            buscar();
          

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string lcCamino = nuevabase.recuperaCamino();
            Response.Redirect("DocPendi.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            blanqueartexto();
        }

        protected void txtfolioshojadevida_TextChanged(object sender, EventArgs e)
        {


        }

        protected void txtfoliosscalafon_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtfoliosprestacionessociales_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //Buscamos el contrato y miramos si existe datos predigitados

            DataTable DatHoja = new DataTable();
            proce.consultacamposcondicion("inventariocontratacion", "idserie,idsubserie,nombreserie,subserie,nombrecontratista,idoficinaproductora,oficina", "numerocontrato ='" + txtNumeroContrato.Text + "' and volumen ='"+txtcarpeta.Text+"' and idinstitucion = "+SessionDocumental.UsuarioInicioSession.IDINSTITUCION.ToString(), DatHoja);
            if (DatHoja.Rows.Count > 0)
            {
                ddlEnte.SelectedValue = DatHoja.Rows[0]["idoficinaproductora"].ToString();
                ddlserie.SelectedValue = DatHoja.Rows[0]["idserie"].ToString();
                llenarsubserie();
                ddlsubserie.SelectedValue = DatHoja.Rows[0]["idsubserie"].ToString();
                txtNombreContratista.Text = DatHoja.Rows[0]["nombrecontratista"].ToString(); 


            }
           
            buscar();
        }

        protected void gvhojadevida_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Primero Busco el Expediente
            DataTable DatExpediente = new DataTable();
            DataTable DatDocumento = new DataTable();
            proce.consultacamposcondicion("expediente", "id", "numerodeidentificacion ='" + txtNumeroContrato.Text + "'", DatExpediente);
            if (DatExpediente.Rows.Count > 0)
            {
                DropDownList tipodocumental = gvhojadevida.Rows[gvhojadevida.SelectedIndex].Cells[1].FindControl("txttipodocumental") as DropDownList;
                proce.consultacamposcondicion("documentos", "camino,documento", "idtipologia = " + tipodocumental.SelectedValue + " and idexpediente=" + DatExpediente.Rows[0]["id"].ToString(), DatDocumento);

                if (DatDocumento.Rows.Count == 0)
                {
                    proce.consultacamposcondicion("documentos", "camino,documento", "idexpediente=" + DatExpediente.Rows[0]["id"].ToString(), DatDocumento);
                }

                TextBox tcFolios = gvhojadevida.Rows[gvhojadevida.SelectedIndex].Cells[3].FindControl("txtfolios") as TextBox;

                if (DatDocumento.Rows.Count != 0)
                {
                    string lcPagina = "";
                    if (tcFolios.Text.IndexOf("-") > 0)
                    {
                        lcPagina = tcFolios.Text.Substring(0,tcFolios.Text.IndexOf("-"));
                    }
                    else
                    {
                        lcPagina = tcFolios.Text;
                    }

                    Response.Redirect("~/" + DatDocumento.Rows[0]["camino"].ToString().Trim() + "/" + DatDocumento.Rows[0]["documento"].ToString().Trim()+"#page="+lcPagina, "_blank", "menubar=0,scrollbars=1,width=780,height=900,top=10");
                }
            }

        }

        protected void gvhojadevida_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            if (gvhojadevida.SelectedIndex.ToString().ToUpper() == "NULL")
            {
                return;
            }
            // Primero Busco el Expediente
            DataTable DatExpediente = new DataTable();
            DataTable DatDocumento = new DataTable();
            proce.consultacamposcondicion("expediente", "id", "numerodeidentificacion ='" + txtNumeroContrato.Text + "'", DatExpediente);
            if (DatExpediente.Rows.Count > 0)
            {
                DropDownList tipodocumental = gvhojadevida.Rows[gvhojadevida.SelectedIndex].Cells[1].FindControl("txttipodocumental") as DropDownList;
                proce.consultacamposcondicion("documentos", "camino,documento", "idtipologia = " + tipodocumental.SelectedValue + " and idexpediente=" + DatExpediente.Rows[0]["id"].ToString(), DatDocumento);

                if (DatDocumento.Rows.Count == 0)
                {
                    proce.consultacamposcondicion("documentos", "camino,documento", "idexpediente=" + DatExpediente.Rows[0]["id"].ToString(), DatDocumento);
                }

                TextBox tcFolios = gvhojadevida.Rows[gvhojadevida.SelectedIndex].Cells[3].FindControl("txtfolios") as TextBox;
                string lcArchivoaDescargar =  tipodocumental.SelectedItem.Text;
                if (DatDocumento.Rows.Count != 0)
                {
                    string lcPaginaInicial = "";
                    string lcPaginaFinal = "";
                    if (tcFolios.Text.IndexOf("-") > 0)
                    {
                        lcPaginaInicial = tcFolios.Text.Substring(0, tcFolios.Text.IndexOf("-"));
                        lcPaginaFinal = tcFolios.Text.Substring(tcFolios.Text.IndexOf("-")+1);
                    }
                    else
                    {
                        lcPaginaInicial = tcFolios.Text;
                        lcPaginaFinal = tcFolios.Text;
                    }
                    DataTable dtResultado = new DataTable();
                   
                    string lcCaminoInicial = proce.recuperaUbicacion() + "\\" + DatDocumento.Rows[0]["camino"].ToString().Replace(@"/", @"\") + "\\" + DatDocumento.Rows[0]["documento"].ToString().Trim();
                    string lcSarta = "," + lcPaginaInicial + "-" + lcPaginaFinal;
                    lcSarta = lcSarta.Substring(1);
                    string[] listaArchivos = lcSarta.Split(',');


                    ManejoPdfs DivideArchivos = new ManejoPdfs();
                    dtResultado.Clear();

                    dtResultado = DivideArchivos.Dividir(lcCaminoInicial, listaArchivos,lcArchivoaDescargar);


                    Response.Redirect("~/" + DatDocumento.Rows[0]["camino"].ToString().Trim() + "/" + DatDocumento.Rows[0]["documento"].ToString().Trim().Replace(".pdf","")+"_"+lcArchivoaDescargar+"_1.pdf" , "_blank", "menubar=0,scrollbars=1,width=780,height=900,top=10");
                }
            }
   
        }

       
    }
}