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

namespace gestion_documental
{
    public partial class control_HistoriaLaboral : System.Web.UI.Page
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

                DataColumn primernombre = new DataColumn("primernombre");
                primernombre.DataType = System.Type.GetType("System.String");
                data.Columns.Add(primernombre);

                DataColumn segundonombre = new DataColumn("segundonombre");
                segundonombre.DataType = System.Type.GetType("System.String");
                data.Columns.Add(segundonombre);

                DataColumn primerapellido = new DataColumn("primerapellido");
                primerapellido.DataType = System.Type.GetType("System.String");
                data.Columns.Add(primerapellido);

                DataColumn segundoapellido = new DataColumn("segundoapellido");
                segundoapellido.DataType = System.Type.GetType("System.String");
                data.Columns.Add(segundoapellido);

                DataColumn funcionario = new DataColumn("funcionario");
                funcionario.DataType = System.Type.GetType("System.String");
                data.Columns.Add(funcionario);

                DataColumn identidad = new DataColumn("identidad");
                identidad.DataType = System.Type.GetType("System.String");
                data.Columns.Add(identidad);

                DataColumn tipodocumental = new DataColumn("tipodocumental");
                tipodocumental.DataType = System.Type.GetType("System.String");
                data.Columns.Add(tipodocumental);

                DataColumn folios = new DataColumn("folios");
                folios.DataType = System.Type.GetType("System.String");
                data.Columns.Add(folios);

                DataColumn fecha = new DataColumn("fecha");
                fecha.DataType = System.Type.GetType("System.String");
                data.Columns.Add(fecha);

                DataColumn idinstitucion = new DataColumn("idinstitucion");
                idinstitucion.DataType = System.Type.GetType("System.Double");
                data.Columns.Add(idinstitucion);

                DataColumn seccion = new DataColumn("seccion");
                seccion.DataType = System.Type.GetType("System.String");
                data.Columns.Add(seccion);

                DataColumn serie = new DataColumn("serie");
                serie.DataType = System.Type.GetType("System.String");
                data.Columns.Add(serie);

                DataColumn subserie = new DataColumn("subserie");
                subserie.DataType = System.Type.GetType("System.String");
                data.Columns.Add(subserie);

                DataColumn tipodocumento = new DataColumn("tipodocumento");
                tipodocumento.DataType = System.Type.GetType("System.String");
                data.Columns.Add(tipodocumento);

                DataColumn fechanacimiento = new DataColumn("fechanacimiento");
                fechanacimiento.DataType = System.Type.GetType("System.String");
                data.Columns.Add(fechanacimiento);

                DataColumn genero = new DataColumn("genero");
                genero.DataType = System.Type.GetType("System.String");
                data.Columns.Add(genero);

                DataColumn documento = new DataColumn("documento");
                documento.DataType = System.Type.GetType("System.String");
                data.Columns.Add(documento);

                DataColumn carpeta = new DataColumn("carpeta");
                carpeta.DataType = System.Type.GetType("System.String");
                data.Columns.Add(carpeta);

                Session.Add("dataset", data);

                for (int i = 0; i < 7; i++)
                {
                    DataRow fila = data.NewRow();
                    fila["carpeta"] = 1;
                    data.Rows.Add(fila);
                }
                gvhojadevida.DataSource = data;
                gvhojadevida.DataBind();

                gvescalafon.DataSource = data;
                gvescalafon.DataBind();

                gvprestacionessociales.DataSource = data;
                gvprestacionessociales.DataBind();

              ddlserie.DataSource= _serie.GetAllSeries();
              ddlserie.DataTextField = "serie";
              ddlserie.DataValueField = "id";
              ddlserie.DataBind();
              llenarsubserie();
              
            
            }
        }

        protected void btcrear_Click(object sender, EventArgs e)
        {
            Session["estado"]= "";
            DataTable data = new DataTable();
            proce.consultacamposcondicion("controllaboral", "*", "documento='" + txtdocumento.Text + "' and idinstitucion='" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + "'", data);
            if (data.Rows.Count < 1)
            {
                obteenervalores();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Registro Creado');", true);
                blanqueartexto();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('El Documento ya Tiene Registros');", true);
            }

            
        }
        public void obteenervalores()
        {
          
            string fechaanterior = "";
          
           // Session["opcion"] = "duplicar";
            DataTable bloque = Session["dataset"] as DataTable;
            bloque.Clear();
            foreach (GridViewRow row in gvhojadevida.Rows)
            {

                if (row.RowType == DataControlRowType.DataRow)
                {
                    DataRow fila1 = bloque.NewRow();
                    TextBox fecha = row.Cells[1].FindControl("txtfechahojadevida") as TextBox;
                    DropDownList tipodocumental = row.Cells[1].FindControl("txttipodocumentalhojadevida") as DropDownList;
                    if (fecha.Text != "" && tipodocumental.SelectedValue != "")
                    {
                        fila1["fecha"] = fecha.Text;
                       
                        fila1["tipodocumental"] = tipodocumental.SelectedValue;
                        TextBox folios = row.Cells[1].FindControl("txtfolioshojadevida") as TextBox;
                        fila1["folios"] = folios.Text;
                        fechaanterior =fecha.Text;
                        TextBox carpeta = row.Cells[1].FindControl("txtcarpetahojadevida") as TextBox;
                        fila1["carpeta"] = txtcarpeta.Text;
                        fila1["primernombre"] = txtprimernombre.Text;
                        fila1["segundonombre"] = txtsegundonombre.Text;
                        fila1["primerapellido"] = txtprimerapellido.Text;
                        fila1["segundoapellido"] = txtsegundoapellido.Text;
                        fila1["funcionario"] = txtfuncionario.Text;
                        fila1["identidad"] = txtidentidad.Text;
                        fila1["documento"] = txtdocumento.Text;
                        fila1["serie"] = ddlserie.SelectedValue;
                        fila1["subserie"] = ddlsubserie.SelectedValue;
                        fila1["idinstitucion"] = SessionDocumental.UsuarioInicioSession.IDINSTITUCION;
                        fila1["seccion"] = "HISTORIA LABORAL";
                        bloque.Rows.Add(fila1);

                    }
                   
                   

                }
            }

            foreach (GridViewRow row in gvescalafon.Rows)
            {

                if (row.RowType == DataControlRowType.DataRow)
                {
                    DataRow fila1 = bloque.NewRow();
                    TextBox fecha = row.Cells[1].FindControl("txtfechascalafon") as TextBox;
                    DropDownList tipodocumental = row.Cells[1].FindControl("txttipodocumentalscalafon") as DropDownList;
                    if (fecha.Text != "" && tipodocumental.SelectedValue != "")
                    {
                        fila1["fecha"] = fecha.Text;
                      
                        fila1["tipodocumental"] = tipodocumental.SelectedValue;
                        TextBox folios = row.Cells[1].FindControl("txtfoliosscalafon") as TextBox;
                        fila1["folios"] = folios.Text;
                        fechaanterior = fecha.Text;
                        TextBox carpeta = row.Cells[1].FindControl("txtcarpetascalafon") as TextBox;
                        fila1["carpeta"] = txtcarpeta.Text;
                        fila1["primernombre"] = txtprimernombre.Text;
                        fila1["segundonombre"] = txtsegundonombre.Text;
                        fila1["primerapellido"] = txtprimerapellido.Text;
                        fila1["segundoapellido"] = txtsegundoapellido.Text;
                        fila1["funcionario"] = txtfuncionario.Text;
                        fila1["identidad"] = txtidentidad.Text;
                        fila1["documento"] = txtdocumento.Text;
                        fila1["serie"] = ddlserie.SelectedValue;
                        fila1["subserie"] = ddlsubserie.SelectedValue;
                        fila1["idinstitucion"] = SessionDocumental.UsuarioInicioSession.IDINSTITUCION;
                        fila1["seccion"] = "ESCALAFON";
                        bloque.Rows.Add(fila1);

                    }
                   


                }
            }

           foreach (GridViewRow row in gvprestacionessociales.Rows)
            {

                if (row.RowType == DataControlRowType.DataRow)
                {
                    DataRow fila1 = bloque.NewRow();
                    TextBox fecha = row.Cells[1].FindControl("txtfechaprestacionessociales") as TextBox;
                    DropDownList tipodocumental = row.Cells[1].FindControl("txttipodocumentalprestacionessociales") as DropDownList;
                    if (fecha.Text != "" && tipodocumental.SelectedValue != "")
                    {
                        fila1["fecha"] = fecha.Text;
                      
                        fila1["tipodocumental"] = tipodocumental.SelectedValue;
                        TextBox folios = row.Cells[1].FindControl("txtfoliosprestacionessociales") as TextBox;
                        fila1["folios"] = folios.Text;
                       
                        TextBox carpeta = row.Cells[1].FindControl("txtcarpetaprestacionessociales") as TextBox;
                        fila1["carpeta"] = txtcarpeta.Text;
                        fila1["primernombre"] = txtprimernombre.Text;
                        fila1["segundonombre"] = txtsegundonombre.Text;
                        fila1["primerapellido"] = txtprimerapellido.Text;
                        fila1["segundoapellido"] = txtsegundoapellido.Text;
                        fila1["funcionario"] = txtfuncionario.Text;
                        fila1["identidad"] = txtidentidad.Text;
                        fila1["documento"] = txtdocumento.Text;
                        fila1["serie"] = ddlserie.SelectedValue;
                        fila1["subserie"] = ddlsubserie.SelectedValue;
                        fila1["idinstitucion"] = SessionDocumental.UsuarioInicioSession.IDINSTITUCION;
                        fila1["seccion"] = "PRESTACIONES SOCIALES";
                        bloque.Rows.Add(fila1);

                    }
                   

                }

            }

           for (int i = 0; i < bloque.Rows.Count; i++)
           {
               proce.insertaralgunos("controllaboral", "primernombre,funcionario,identidad,documento,fecha,tipodocumental,folios,idinstitucion,seccion,segundonombre,primerapellido,segundoapellido,carpeta,serie,subserie,codusuario,fechacreacion", "'" + bloque.Rows[i]["primernombre"].ToString() + "','" + bloque.Rows[i]["funcionario"].ToString() + "','" + bloque.Rows[i]["identidad"].ToString() + "','" + bloque.Rows[i]["documento"].ToString() + "','" + bloque.Rows[i]["fecha"].ToString() + "','" + bloque.Rows[i]["tipodocumental"].ToString() + "','" + bloque.Rows[i]["folios"].ToString() + "','" + bloque.Rows[i]["idinstitucion"].ToString() + "','" + bloque.Rows[i]["seccion"].ToString() + "','" + bloque.Rows[i]["segundonombre"].ToString() + "','" + bloque.Rows[i]["primerapellido"].ToString() + "','" + bloque.Rows[i]["segundoapellido"].ToString() + "','" + bloque.Rows[i]["carpeta"].ToString() + "','" + bloque.Rows[i]["serie"].ToString() + "','" + bloque.Rows[i]["subserie"].ToString() + "','" + SessionDocumental.UsuarioInicioSession.CODIGO + "','"+DateTime.Now.ToString("dd/MM/yyyy")+"'");
           }
           DataTable data1 = new DataTable();
           proce.consultacamposcondicion("controllaboral", "max(fecha) as fechafin,min(fecha) as fechaini", "documento ='" + txtdocumento.Text + "' and idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION, data1);
           
            Expediente expe=new Expediente();
             if (Session["estado"].ToString() == "editar")
           {
               expe = _expediente.GetExpedientenumerodeidentificacion(txtdocumento.Text);
           expe.idente = 104;
           expe.numerodeidentificacion = txtdocumento.Text;
           expe.idserie = Convert.ToInt32(ddlserie.SelectedValue);
           expe.idsubserie = Convert.ToInt32(ddlsubserie.SelectedValue);
           expe.Fechainicio = Convert.ToDateTime(proce.formateafecha(Convert.ToDateTime(data1.Rows[0]["fechaini"].ToString()),0));
           expe.Fechafinal = Convert.ToDateTime(proce.formateafecha(Convert.ToDateTime(data1.Rows[0]["fechafin"].ToString()),0));
           expe.descripcion = txtprimerapellido.Text + " " + txtsegundoapellido.Text + " " + txtprimernombre.Text + " " + txtsegundonombre.Text;
           _expediente.UpdateExpediente(expe);
           }
           else
           {
               expe.idente = 104;
               expe.numerodeidentificacion = txtdocumento.Text;
               expe.idserie = Convert.ToInt32(ddlserie.SelectedValue);
               expe.idsubserie = Convert.ToInt32(ddlsubserie.SelectedValue);
               expe.Fechainicio = Convert.ToDateTime(proce.formateafecha(Convert.ToDateTime("1901-01-01"),0));
               expe.Fechafinal = Convert.ToDateTime(proce.formateafecha(Convert.ToDateTime("1901-01-01"),0));
               expe.descripcion = txtprimerapellido.Text + " " + txtsegundoapellido.Text + " " + txtprimernombre.Text + " " + txtsegundonombre.Text;
               _expediente.InsertExpediente(expe);
           }
          
            
            DataTable data = new DataTable();
            DataTable dataescalafon = new DataTable();
            DataTable dataprestaciones = new DataTable();
            int numerofolios = 0;
            string identificador = "-";
            int NU = 0;
            proce.consultacampos("controllaboral having id=(select max(id) as id from controllaboral where documento='" + txtdocumento.Text + "' and idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and seccion='HISTORIA LABORAL')", "id,folios as folio,primernombre,segundonombre,primerapellido,segundoapellido", data);
            if (data.Rows.Count > 0)
            {

                NU = data.Rows[0]["folio"].ToString().IndexOf(identificador);
                if (NU > 0)
                {
                    numerofolios = Convert.ToInt32(data.Rows[0]["folio"].ToString().Split('-')[1]);
                }
                else
                {
                    numerofolios = Convert.ToInt32(data.Rows[0]["folio"].ToString());
                }
            }
            //
            int NU1 = 0;
            proce.consultacampos("controllaboral having id=(select max(id) as id from controllaboral where documento='" + txtdocumento.Text + "' and idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and seccion='ESCALAFON')", "id,folios as folio,primernombre,segundonombre,primerapellido,segundoapellido", dataescalafon);

            if (dataescalafon.Rows.Count > 0)
            {
                NU1 = dataescalafon.Rows[0]["folio"].ToString().IndexOf(identificador);

                if (NU1 > 0)
                {
                    numerofolios = numerofolios + Convert.ToInt32(dataescalafon.Rows[0]["folio"].ToString().Split('-')[1]);
                }
                else
                {
                    numerofolios = numerofolios + Convert.ToInt32(dataescalafon.Rows[0]["folio"].ToString());

                }
            }
            //
            int NU2 = 0;
            proce.consultacampos("controllaboral having id=(select max(id) as id from controllaboral where documento='" + txtdocumento.Text + "' and idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and seccion='PRESTACIONES SOCIALES')", "id,folios as folio,primernombre,segundonombre,primerapellido,segundoapellido", dataprestaciones);

            if (dataprestaciones.Rows.Count > 0)
            {
                NU2 = dataprestaciones.Rows[0]["folio"].ToString().IndexOf(identificador);

                if (NU2 > 0)
                {
                    numerofolios = numerofolios + Convert.ToInt32(dataprestaciones.Rows[0]["folio"].ToString().Split('-')[1]);
                }
                else
                {
                    numerofolios = numerofolios + Convert.ToInt32(dataprestaciones.Rows[0]["folio"].ToString());

                }
            }
            string nombrecompleto = txtprimerapellido.Text + "  " + txtsegundoapellido.Text + "  " + txtprimernombre.Text + "  " + txtsegundonombre.Text;
            DataTable data2 = new DataTable();
            proce.consultacamposcondicion("serie", "serie,codigo", "id='" + ddlserie.SelectedValue + "'", data2);
            proce.insertaralgunos("inventario", "cedula,idoficinaproductora,codigo,nombreserie,fechainicio,fechafinal,caja,numeroorden,volumen,numerofolios,expedientelaboral,idinstitucion", "'" + txtdocumento.Text + "','" + 104 + "','" + data2.Rows[0]["codigo"].ToString() + "','" + data2.Rows[0]["serie"].ToString() + "','" + proce.formateafecha(Convert.ToDateTime(expe.Fechainicio),0) + "','" + proce.formateafecha(Convert.ToDateTime(expe.Fechafinal),0) + "','" + 0 + "','" + 0 + "','1/1','" + numerofolios + "','" + nombrecompleto + "','" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + "'");
            
        }

        protected void btbuscar_Click(object sender, EventArgs e)
        {
            txtbucar.Visible = true;
            txtbucar.Focus();
        }
        public void buscar()
        {
            DataTable bloque = Session["dataset"] as DataTable;
            bloque.Clear();
            DataTable data = new DataTable();
            DataTable _hojasdevida =new DataTable();
            DataTable _escalafon = new DataTable();
            DataTable _prestaciones = new DataTable();
            _hojasdevida.Clear();
            _escalafon.Clear();
            _prestaciones.Clear();

            proce.consultacamposcondicion("controllaboral c join usuarios u on c.codusuario=u.codigo", "c.* ,u.nombre as nombreusuario", "c.documento='" + txtbucar.Text + "' and c.idinstitucion='" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + "'", data);
            if (data.Rows.Count > 0)
            {
                txtfuncionario.Text = data.Rows[0]["funcionario"].ToString();
                lbusuario.Text = data.Rows[0]["nombreusuario"].ToString();
                txtprimernombre.Text=data.Rows[0]["primernombre"].ToString();
                txtsegundonombre.Text=data.Rows[0]["segundonombre"].ToString();
                txtprimerapellido.Text=data.Rows[0]["primerapellido"].ToString();
                txtsegundoapellido.Text=data.Rows[0]["segundoapellido"].ToString();
                txtidentidad.Text = data.Rows[0]["identidad"].ToString();
                ddlserie.SelectedValue = data.Rows[0]["serie"].ToString();
                txtdocumento.Text = data.Rows[0]["documento"].ToString();
                llenarsubserie();
                ddlsubserie.SelectedValue = data.Rows[0]["subserie"].ToString();
                proce.consultacamposcondicion("controllaboral", "*", "documento='" + txtdocumento.Text + "' and idinstitucion='" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + "' and seccion='HISTORIA LABORAL'", _hojasdevida);
                proce.consultacamposcondicion("controllaboral", "*", "documento='" + txtdocumento.Text + "' and idinstitucion='" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + "' and seccion='PRESTACIONES SOCIALES'", _prestaciones);
                proce.consultacamposcondicion("controllaboral", "*", "documento='" + txtdocumento.Text + "' and idinstitucion='" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + "' and seccion='ESCALAFON'", _escalafon);
                gvhojadevida.DataSource = _hojasdevida;
                gvhojadevida.DataBind();
                gvescalafon.DataSource = _escalafon;
                gvescalafon.DataBind();
                gvprestacionessociales.DataSource = _prestaciones;
                gvprestacionessociales.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('El Documento No Tiene Registros');", true);
            }
            txtbucar.Visible = false;
        }

        protected void bteditar_Click(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            proce.consultacamposcondicion("controllaboral", "*", "documento='" + txtdocumento.Text + "' and idinstitucion='" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + "'", data);
            if (data.Rows.Count > 0)
            {
                proce.eliminar("controllaboral", "documento='" + txtdocumento.Text + "'");
                //proce.eliminar("expediente", "numerodeidentificacion='" + txtdocumento.Text + "'");
                proce.eliminar("inventario", "cedula='" + txtdocumento.Text + "'");
                Session["estado"] = "editar";
                obteenervalores();
                blanqueartexto();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Registro Actualizado');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('El Documento No se puede Actualizar Porque No Tiene Registros');", true);
            }
        }

        protected void bteliminar_Click(object sender, EventArgs e)
        {
            proce.eliminar("controllaboral", "documento='" + txtdocumento.Text + "'");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Registro Eliminado');", true);
            blanqueartexto();
        }

        protected void ckaddfilahoja_CheckedChanged(object sender, EventArgs e)
        {
            DataTable bloque = Session["dataset"] as DataTable;
            bloque.Clear();
            foreach (GridViewRow row in gvhojadevida.Rows)
            {

                if (row.RowType == DataControlRowType.DataRow)
                {
                    DataRow fila1 = bloque.NewRow();
                    TextBox fecha = row.Cells[1].FindControl("txtfechahojadevida") as TextBox;
                    fila1["fecha"] = fecha.Text;
                    DropDownList tipodocumental = row.Cells[1].FindControl("txttipodocumentalhojadevida") as DropDownList;
                    fila1["tipodocumental"] = tipodocumental.SelectedValue;
                    TextBox folios = row.Cells[1].FindControl("txtfolioshojadevida") as TextBox;
                    fila1["folios"] = folios.Text;
                    TextBox carpeta = row.Cells[1].FindControl("txtcarpetahojadevida") as TextBox;
                    fila1["carpeta"] = carpeta.Text;
                    bloque.Rows.Add(fila1);

                }
            }
            for (int i = 0; i < 7; i++)
            {
                DataRow fila = bloque.NewRow();
                fila["carpeta"] = 1;
                bloque.Rows.Add(fila);
            }
            gvhojadevida.DataSource = bloque;
            gvhojadevida.DataBind();
            ckaddfilahoja.Checked = false;
        }

        protected void ckescalafon_CheckedChanged(object sender, EventArgs e)
        {
            DataTable bloque = Session["dataset"] as DataTable;
            bloque.Clear();
            foreach (GridViewRow row in gvescalafon.Rows)
            {

                if (row.RowType == DataControlRowType.DataRow)
                {
                    DataRow fila1 = bloque.NewRow();
                    TextBox fecha = row.Cells[1].FindControl("txtfechascalafon") as TextBox;
                    fila1["fecha"] = fecha.Text;
                    DropDownList tipodocumental = row.Cells[1].FindControl("txttipodocumentalscalafon") as DropDownList;
                    fila1["tipodocumental"] = tipodocumental.SelectedValue;
                    TextBox folios = row.Cells[1].FindControl("txtfoliosscalafon") as TextBox;
                    fila1["folios"] = folios.Text;
                    TextBox carpeta = row.Cells[1].FindControl("txtcarpetascalafon") as TextBox;
                    fila1["carpeta"] = carpeta.Text;
                    bloque.Rows.Add(fila1);
                }
            }
            for (int i = 0; i < 7; i++)
            {
                DataRow fila = bloque.NewRow();
                fila["carpeta"] = 1;
                bloque.Rows.Add(fila);
            }
            gvescalafon.DataSource = bloque;
            gvescalafon.DataBind();
            ckescalafon.Checked = false;
        }
        public void blanqueartexto()
        {
            txtdocumento.Text="";
            txtfuncionario.Text = "";
            txtidentidad.Text = "";
            txtprimernombre.Text = "";
            txtsegundonombre.Text = "";
            txtprimerapellido.Text = "";
            txtsegundoapellido.Text = "";
            gvescalafon.DataSource = "";
            gvescalafon.DataBind();
            gvhojadevida.DataSource = "";
            gvhojadevida.DataBind();
            gvprestacionessociales.DataSource = "";
            gvprestacionessociales.DataBind();

        }
        protected void ckpretacion_CheckedChanged(object sender, EventArgs e)
        {

            DataTable bloque = Session["dataset"] as DataTable;
            bloque.Clear();
            foreach (GridViewRow row in gvprestacionessociales.Rows)
            {

                if (row.RowType == DataControlRowType.DataRow)
                {
                    DataRow fila1 = bloque.NewRow();
                    TextBox fecha = row.Cells[1].FindControl("txtfechaprestacionessociales") as TextBox;
                    fila1["fecha"] = fecha.Text;
                    DropDownList tipodocumental = row.Cells[1].FindControl("txttipodocumentalprestacionessociales") as DropDownList;
                    fila1["tipodocumental"] = tipodocumental.SelectedValue;
                    TextBox folios = row.Cells[1].FindControl("txtfoliosprestacionessociales") as TextBox;
                    fila1["folios"] = folios.Text;
                    TextBox carpeta = row.Cells[1].FindControl("txtcarpetaprestacionessociales") as TextBox;
                    fila1["carpeta"] = carpeta.Text;
                  
                    bloque.Rows.Add(fila1);
                }
            }
            for (int i = 0; i < 7; i++)
            {
                DataRow fila = bloque.NewRow();
                fila["carpeta"] = 1;
                bloque.Rows.Add(fila);
            }
            gvprestacionessociales.DataSource = bloque;
            gvprestacionessociales.DataBind();
            ckpretacion.Checked = false;
        }

        protected void btimprimir_Click(object sender, EventArgs e)
        {
            controlloboralconsul.documento = txtdocumento.Text;
            Response.Redirect("~//reporting/controllaboral.aspx", "_blank", " menubar=0,scrollbars=1,width=780,height=900,top=10");
        }
        public void llenarsubserie()
        {
          ddlsubserie.DataSource=_subserie.GetAllSubSeriesBySerie(Convert.ToInt32(ddlserie.SelectedValue));
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
            txtbucar.Text = "";
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string lcCamino = nuevabase.recuperaCamino();
            Response.Redirect("docpendi.aspx");
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
    }
}