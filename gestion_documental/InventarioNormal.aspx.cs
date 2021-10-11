using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using gestion_documental.Utils;
using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.SpreadSheet;
using System.IO;



namespace gestion_documental
{
    public partial class InventarioNormal : System.Web.UI.Page
    {
        Class1 proce = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["stikercajainterno"] = "0";
                Session["numerocaja"] = "0";
                Session["opcion"] = "";
                DataTable data1 = new DataTable();
                proce.consultacamposcondicion("institucion", "imagen", "idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION, data1);
                imagenempresa0.Attributes.Add("src", data1.Rows[0]["imagen"].ToString());

                DataTable data = new DataTable();

                DataColumn caja = new DataColumn("caja");
                caja.DataType = System.Type.GetType("System.String");
                data.Columns.Add(caja);

                DataColumn numeroorden = new DataColumn("numeroorden");
                numeroorden.DataType = System.Type.GetType("System.String");
                data.Columns.Add(numeroorden);

                DataColumn codigo = new DataColumn("codigo");
                codigo.DataType = System.Type.GetType("System.String");
                data.Columns.Add(codigo);

                DataColumn nombreserie = new DataColumn("nombreserie");
                nombreserie.DataType = System.Type.GetType("System.String");
                data.Columns.Add(nombreserie);

                DataColumn fechainicio = new DataColumn("fechainicio");
                fechainicio.DataType = System.Type.GetType("System.String");
                data.Columns.Add(fechainicio);

                DataColumn fechafinal = new DataColumn("fechafinal");
                fechafinal.DataType = System.Type.GetType("System.String");
                data.Columns.Add(fechafinal);

                DataColumn unidadcaja = new DataColumn("unidadcaja");
                unidadcaja.DataType = System.Type.GetType("System.String");
                data.Columns.Add(unidadcaja);

                DataColumn unidadcarpeta = new DataColumn("unidadcarpeta");
                unidadcarpeta.DataType = System.Type.GetType("System.String");
                data.Columns.Add(unidadcarpeta);

                DataColumn unidadtom = new DataColumn("unidadtom");
                unidadtom.DataType = System.Type.GetType("System.String");
                data.Columns.Add(unidadtom);

                DataColumn unidadotros = new DataColumn("unidadotros");
                unidadotros.DataType = System.Type.GetType("System.String");
                data.Columns.Add(unidadotros);

                DataColumn numerofolios = new DataColumn("numerofolios");
                numerofolios.DataType = System.Type.GetType("System.String");
                data.Columns.Add(numerofolios);

                DataColumn soporte = new DataColumn("soporte");
                soporte.DataType = System.Type.GetType("System.String");
                data.Columns.Add(soporte);

                DataColumn volumen = new DataColumn("volumen");
                volumen.DataType = System.Type.GetType("System.String");
                data.Columns.Add(volumen);

                DataColumn expedientelaboral = new DataColumn("observacion");
                expedientelaboral.DataType = System.Type.GetType("System.String");
                data.Columns.Add(expedientelaboral);

                DataColumn color = new DataColumn("color");
                color.DataType = System.Type.GetType("System.String");
                data.Columns.Add(color);

                DataColumn id = new DataColumn("id");
                id.DataType = System.Type.GetType("System.String");
                data.Columns.Add(id);



                Session.Add("dataset", data);

                DataRow fila = data.NewRow();
                data.Rows.Add(fila);

                GVPRINCIPAL.DataSource = data;
                GVPRINCIPAL.DataBind();
                proyectos();
                Session["id"] = "";
                Session["objeto"] = "";

            }




        }
        public void proyectos()
        {
            DataTable proyecto = new DataTable();
            proce.consultacamposcondicion("proyectos", "idproyectos,descripcion,imagen", "idinstitucion =" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION, proyecto);

            DDLproyecto.DataSource = proyecto;
            DDLproyecto.DataTextField = "descripcion";
            DDLproyecto.DataValueField = "idproyectos";
            DDLproyecto.DataBind();
            proyectoentidad();

        }
        protected void GVPRINCIPAL_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        protected void ckfila_CheckedChanged(object sender, EventArgs e)
        {
            Session["opcion"] = "crear";
            crearfila();
        }
        public void crearfila()
        {
            Session["suma"] = 0;
            Session["stikercajaid"] = "";
            Session["stikercarpetaid"] = "";
            Session["carpeta"] = "";
            Session["color"] = "";
            DataTable bloque = Session["dataset"] as DataTable;

            bloque.Clear();

            int i = 0;
            foreach (GridViewRow row in GVPRINCIPAL.Rows)
            {

                if (row.RowType == DataControlRowType.DataRow)
                {

                    CheckBox chkRow = (row.Cells[0].FindControl("ckfila") as CheckBox);
                    CheckBox ckcopi = (row.Cells[0].FindControl("ckcopiarfila") as CheckBox);
                    CheckBox ckcaja = (row.Cells[0].FindControl("ckcaja") as CheckBox);
                    CheckBox cksticker = (row.Cells[0].FindControl("cksticker") as CheckBox);

                    DataRow fila1 = bloque.NewRow();

                    TextBox caja = row.Cells[1].FindControl("txtcaja") as TextBox;
                    fila1["caja"] = caja.Text;
                    TextBox numeroorden = row.Cells[1].FindControl("txtnumeroorden") as TextBox;
                    fila1["numeroorden"] = numeroorden.Text;
                    TextBox codigo = row.Cells[1].FindControl("txtcodigo") as TextBox;
                    fila1["codigo"] = codigo.Text;
                    TextBox nombreserie = row.Cells[1].FindControl("txtnombreserie") as TextBox;
                    fila1["nombreserie"] = nombreserie.Text;
                    TextBox fechainicio = row.Cells[1].FindControl("txtfechainicio") as TextBox;
                    fila1["fechainicio"] = fechainicio.Text;
                    TextBox fechafinal = row.Cells[1].FindControl("txtfechafinal") as TextBox;
                    fila1["fechafinal"] = fechafinal.Text;
                    TextBox unidadcaja = row.Cells[1].FindControl("txtunidadcaja") as TextBox;
                    fila1["unidadcaja"] = unidadcaja.Text;
                    TextBox unidadcarpeta = row.Cells[1].FindControl("txtunidadcarpeta") as TextBox;
                    fila1["unidadcarpeta"] = unidadcarpeta.Text;
                    TextBox unidadtom = row.Cells[1].FindControl("txtunidadtom") as TextBox;
                    fila1["unidadtom"] = unidadtom.Text;
                    TextBox unidadotros = row.Cells[1].FindControl("txtunidadotros") as TextBox;
                    fila1["unidadotros"] = unidadotros.Text;
                    TextBox numerofolios = row.Cells[1].FindControl("txtnumerofolios") as TextBox;
                    fila1["numerofolios"] = numerofolios.Text;
                    TextBox soporte = row.Cells[1].FindControl("txtsoporte") as TextBox;
                    fila1["soporte"] = soporte.Text;
                    TextBox volumen = row.Cells[1].FindControl("txtvolumen") as TextBox;
                    fila1["volumen"] = volumen.Text;
                    TextBox observacion = row.Cells[1].FindControl("txtobservacion") as TextBox;
                    fila1["observacion"] = observacion.Text;
                    TextBox color = row.Cells[1].FindControl("txtcolor") as TextBox;
                    fila1["color"] = color.Text;
                    TextBox id = row.Cells[1].FindControl("txtid") as TextBox;
                    fila1["id"] = id.Text;
                    if (Session["opcion"].ToString() == "todo")
                    {
                        llenarstikert(color, id, caja);
                        bloque.Rows.Add(fila1);

                    }
                    else
                    {

                        if (Session["opcion"].ToString() == "imprimir")
                        {
                            if (cksticker.Checked == true)
                            {
                                llenarstikert(color, id, caja);
                                bloque.Rows.Add(fila1);
                            }

                        }
                        else
                        {
                            if (Session["opcion"].ToString() == "crear")
                            {

                                if (chkRow.Checked)
                                {

                                    bloque.Rows.Add(fila1);
                                    DataRow filanueva = bloque.NewRow();
                                    bloque.Rows.Add(filanueva);

                                }
                                else
                                {
                                    bloque.Rows.Add(fila1);
                                }
                            }
                            else
                            {
                                if (Session["opcion"].ToString() == "copiar")
                                {

                                    if (ckcopi.Checked)
                                    {

                                        bloque.Rows.Add(fila1);
                                        DataRow filanueva1 = bloque.NewRow();



                                        filanueva1["caja"] = fila1["caja"];

                                        filanueva1["numeroorden"] = fila1["numeroorden"];

                                        filanueva1["codigo"] = fila1["codigo"];

                                        filanueva1["nombreserie"] = fila1["nombreserie"];

                                        filanueva1["fechainicio"] = fila1["fechainicio"];

                                        filanueva1["fechafinal"] = fila1["fechafinal"];

                                        filanueva1["unidadcaja"] = fila1["unidadcaja"];

                                        filanueva1["unidadcarpeta"] = fila1["unidadcarpeta"];

                                        filanueva1["unidadtom"] = fila1["unidadtom"];

                                        filanueva1["unidadotros"] = fila1["unidadotros"];

                                        filanueva1["numerofolios"] = fila1["numerofolios"];

                                        filanueva1["soporte"] = fila1["soporte"];

                                        filanueva1["volumen"] = fila1["volumen"];

                                        filanueva1["observacion"] = fila1["observacion"];

                                        proce.insertaralgunos("inventarionormal", "caja,numeroorden,codigo,nombreserie,idoficinaproductora,idinstitucion,fechainicio,fechafinal,numerofolios,volumen,observacion", "'" + fila1["caja"] + "','" + fila1["numeroorden"] + "','" + fila1["codigo"] + "','" + fila1["nombreserie"] + "','" + DDLoficinaproductora.SelectedValue + "','" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + "','" + fila1["fechainicio"] + "','" + fila1["fechafinal"] + "','" + fila1["numerofolios"] + "','" + fila1["volumen"] + "','" + fila1["observacion"] + "'");
                                        bloque.Rows.Add(filanueva1);

                                    }
                                    else
                                    {
                                        bloque.Rows.Add(fila1);
                                    }
                                }
                                else
                                {
                                    if (Session["opcion"].ToString() == "grabar")
                                    {
                                        string unidadconservacion = "";

                                        if (unidadcaja.Text.Trim().Length > 0)
                                        {
                                            unidadconservacion = "caja";
                                        }

                                        if (unidadcarpeta.Text.Trim().Length > 0)
                                        {
                                            unidadconservacion = "carpeta";
                                        }

                                        if (unidadtom.Text.Trim().Length > 0)
                                        {
                                            unidadconservacion = "tom";
                                        }

                                        if (unidadotros.Text.Trim().Length > 0)
                                        {
                                            unidadconservacion = "otros";
                                        }



                                        if (ckeliminacion.Checked == true)
                                        {
                                            Session["objeto"] = "eliminacion";
                                        }
                                        else
                                        {
                                            if (cktransferencia.Checked == true)
                                            {
                                                Session["objeto"] = "transferencia";
                                            }
                                            else
                                            {

                                                if (ckgestion.Checked == true)
                                                {
                                                    Session["objeto"] = "gestion";
                                                }
                                                else
                                                {

                                                }
                                            }
                                        }

                                        proce.editar("oficinaproductora", "year='" + txtano.Text + "', mes='" + txtmes.Text + "', dia = '" + txtdia.Text + "', nt='" + txtnt.Text + "',objeto='" + Session["objeto"].ToString() + "'", "idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and id='" + DDLoficinaproductora.SelectedValue + "'");
                                        proce.insertaralgunos("inventarionormal", "idoficinaproductora,caja,numeroorden,codigo,nombreserie,fechainicio,fechafinal,unidadconservacion,numerofolios,soporte,volumen,observacion,idinstitucion,color", DDLoficinaproductora.SelectedValue + ",'" + caja.Text + "','" + numeroorden.Text + "','" + codigo.Text + "','" + nombreserie.Text + "','" + fechainicio.Text + "','" + fechafinal.Text + "','" + unidadconservacion + "','" + numerofolios.Text + "','" + soporte.Text + "','" + volumen.Text + "','" + observacion.Text + "','" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + "','" + color.Text + "'");

                                    }
                                    else
                                    {
                                        if (Session["opcion"].ToString() == "update")
                                        {
                                            string unidadconservacion = "";


                                            if (unidadcaja.Text.Trim().Length > 0)
                                            {
                                                unidadconservacion = "caja";
                                            }

                                            if (unidadcarpeta.Text.Trim().Length > 0)
                                            {
                                                unidadconservacion = "carpeta";
                                            }

                                            if (unidadtom.Text.Trim().Length > 0)
                                            {
                                                unidadconservacion = "tom";
                                            }

                                            if (unidadotros.Text.Trim().Length > 0)
                                            {
                                                unidadconservacion = "otros";
                                            }

                                            if (ckeliminacion.Checked == true)
                                            {
                                                Session["objeto"] = "eliminacion";
                                            }
                                            else
                                            {
                                                if (cktransferencia.Checked == true)
                                                {
                                                    Session["objeto"] = "transferencia";
                                                }
                                                else
                                                {

                                                    if (ckgestion.Checked == true)
                                                    {
                                                        Session["objeto"] = "gestion";
                                                    }
                                                    else
                                                    {

                                                    }
                                                }
                                            }
                                            if (observacion.Text.Length > 200)
                                            {
                                                observacion.Text = observacion.Text.Substring(0, 199);
                                            }

                                            proce.editar("oficinaproductora", "year='" + txtano.Text + "', mes='" + txtmes.Text + "', dia = '" + txtdia.Text + "', nt='" + txtnt.Text + "',objeto='" + Session["objeto"].ToString() + "'", "idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and id='" + DDLoficinaproductora.SelectedValue + "'");
                                            proce.editar("inventarionormal", "caja='" + caja.Text + "', numeroorden = '" + numeroorden.Text + "', codigo='" + codigo.Text + "',nombreserie='" + nombreserie.Text + "', fechainicio='" + fechainicio.Text + "', fechafinal = '" + fechafinal.Text + "', unidadconservacion='" + unidadconservacion + "',numerofolios='" + numerofolios.Text + "', soporte='" + soporte.Text + "', volumen = '" + volumen.Text + "', observacion='" + observacion.Text + "',color='" + color.Text + "'", "idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and idoficinaproductora='" + DDLoficinaproductora.SelectedValue + "' and id='" + id.Text + "'");

                                        }
                                        else
                                        {
                                            if (Session["opcion"].ToString() == "caja")
                                            {
                                                bloque.Rows.Add(fila1);

                                                if (color.Text.Length > 0 || ckcaja.Checked == true)
                                                {
                                                    if (Session["color"].ToString() == "")
                                                    {

                                                    }
                                                    else
                                                    {
                                                        bloque.Rows[Convert.ToInt32(Session["color"])]["numerofolios"] = Session["suma"];
                                                        bloque.Rows[Convert.ToInt32(Session["color"])]["numeroorden"] = Session["carpeta"];

                                                        numerofolios.Text = "0";
                                                    }
                                                    fila1["color"] = ".";
                                                    Session["suma"] = 0;
                                                    Session["carpeta"] = 0;
                                                    Session["color"] = i;
                                                }
                                                else
                                                {
                                                    if (numerofolios.Text.Length < 1)
                                                    {
                                                        numerofolios.Text = "0";
                                                    }
                                                    Session["carpeta"] = numeroorden.Text;
                                                    Session["suma"] = Convert.ToDouble(Session["suma"]) + Convert.ToDouble(numerofolios.Text);
                                                }


                                                if (i == (GVPRINCIPAL.Rows.Count) - 1)
                                                {
                                                    if (Convert.ToInt32(Session["color"].ToString().Length) > 0)
                                                    {
                                                        bloque.Rows[Convert.ToInt32(Session["color"])]["numerofolios"] = Convert.ToInt32(Session["suma"]);
                                                    }

                                                }

                                            }
                                            else
                                            {
                                                if (Session["opcion"].ToString() == "eliminarr")
                                                {
                                                    if (Convert.ToInt32(Session["index"]) != i)
                                                    {

                                                        bloque.Rows.Add(fila1);

                                                    }
                                                    else
                                                    {
                                                            proce.eliminar("inventarionormal", "id='" + id.Text + "'");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                i = i + 1;
                            }
                        }
                    }
                }
            }




            GVPRINCIPAL.DataSource = bloque;
            GVPRINCIPAL.DataBind();
            for (int g = 0; g < bloque.Rows.Count; g++)
            {
                if (bloque.Rows[g]["color"].ToString().Length > 0)
                {
                    GVPRINCIPAL.Rows[g].BackColor = Color.Blue;
                }


            }

            Session["opcion"] = "";
        }

        public void llenarstikert(TextBox color, TextBox id, TextBox caja)
        {
            Session["stikeroficinaproductora"] = DDLoficinaproductora.SelectedValue;
            Session["stikertabla"] = "inventarionormal";
            Session["stikerobservacion"] = "observacion,color";
            if (color.Text.Length > 0)
            {
                Session["numerocaja"] = caja.Text;
                if (Session["stikercajaid"].ToString().Trim().Length < 1)
                {
                    Session["stikercajaid"] = id.Text;
                    Session["stikercajainterno"] = caja.Text;
                }
                else
                {
                    Session["stikercajaid"] = Session["stikercajaid"].ToString() + "," + id.Text;
                    Session["stikercajainterno"] = Session["stikercajainterno"].ToString() + "," + caja.Text;
                }
            }
            else
            {
                Session["numerocaja"] = "0";
                if (Session["stikercarpetaid"].ToString().Trim().Length < 1)
                {
                    Session["stikercarpetaid"] = id.Text;

                }
                else
                {
                    Session["stikercarpetaid"] = Session["stikercarpetaid"].ToString() + "," + id.Text;

                }


            }
        }
        protected void ckcopiarfila_CheckedChanged(object sender, EventArgs e)
        {
            Session["opcion"] = "copiar";
            crearfila();
        }


        protected void GVPRINCIPAL_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                var db = (LinkButton)e.Row.Cells[18].Controls[0];

                db.OnClientClick = "return confirm('Esta seguro que desea eliminar ?');";
            }
        }

        protected void GVPRINCIPAL_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["opcion"] = "eliminarr";
            Session["index"] = Convert.ToInt32(e.RowIndex);
            crearfila();
        }

        protected void DDLproyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            proyectoentidad();

        }
        public void proyectoentidad()
        {
            DataTable data1 = new DataTable();
            proce.consultacamposcondicion("entidadproductora,proyectos", "entidadproductora.id as id,entidadproductora.nombre as nombre,proyectos.imagen", "entidadproductora.idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and entidadproductora.idproyecto=" + DDLproyecto.SelectedValue + " and entidadproductora.idproyecto=proyectos.idproyectos", data1);
            if (data1.Rows.Count < 1)
            {

                DDLentidadproductora.DataSource = "";
                DDLentidadproductora.DataTextField = "";
                DDLentidadproductora.DataValueField = "";
                DDLentidadproductora.DataBind();
                lbnombreempresa.Text = "";
                imagenempresa.Attributes.Add("src", "");
                DDlunidadadministrativa.DataSource = "";
                DDlunidadadministrativa.DataBind();
                DDLoficinaproductora.DataSource = "";
                DDLoficinaproductora.DataBind();

            }
            else
            {
                DDLentidadproductora.DataSource = data1;
                DDLentidadproductora.DataTextField = "nombre";
                DDLentidadproductora.DataValueField = "id";
                DDLentidadproductora.DataBind();
                lbnombreempresa.Text = data1.Rows[0]["nombre"].ToString();
                imagenempresa.Attributes.Add("src", data1.Rows[0]["imagen"].ToString());
                entidadproductora();
            }
        }

        protected void btgrabar_Click(object sender, EventArgs e)
        {
            if (DDLoficinaproductora.Items.Count > 0)
            {

                DataTable data = new DataTable();
                proce.consultacamposcondicion("inventarionormal", "*", " idinstitucion =" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and idoficinaproductora='" + DDLoficinaproductora.SelectedValue + "'", data);
                if (data.Rows.Count < 1)
                {
                    Session["opcion"] = "caja";
                    crearfila();
                    Session["opcion"] = "grabar";
                    crearfila();
                    blanquearproyecto();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('La Oficina Productora ya Tiene un Registro');", true);
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debes Seleccionar Una Oficiona Productora');", true);
            }

        }

        protected void ckgestion_CheckedChanged(object sender, EventArgs e)
        {
            if (ckgestion.Checked == true)
            {
                cktransferencia.Checked = false;
                ckeliminacion.Checked = false;
                Session["objeto"] = "gestion";
            }
            else
            {

                Session["objeto"] = "";
            }
        }

        protected void cktransferencia_CheckedChanged(object sender, EventArgs e)
        {
            if (cktransferencia.Checked == true)
            {
                ckgestion.Checked = false;
                ckeliminacion.Checked = false;
                Session["objeto"] = "transferencia";
            }
            else
            {

                Session["objeto"] = "";
            }
        }

        protected void ckeliminacion_CheckedChanged(object sender, EventArgs e)
        {
            if (ckeliminacion.Checked == true)
            {
                ckgestion.Checked = false;
                cktransferencia.Checked = false;
                Session["objeto"] = "eliminacion";
            }
            else
            {

                Session["objeto"] = "";
            }
        }

        protected void DDLentidadproductora_SelectedIndexChanged(object sender, EventArgs e)
        {
            entidadproductora();
        }
        public void entidadproductora()
        {
            if (DDLentidadproductora.SelectedItem.ToString().Length > 0)
            {
                DataTable data1 = new DataTable();
                proce.consultacamposcondicion("unidadadministrativa", "id,nombre", " idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and identidadproductora=" + DDLentidadproductora.SelectedValue + " ", data1);
                if (data1.Rows.Count < 1)
                {
                    DDlunidadadministrativa.DataSource = "";
                    DDlunidadadministrativa.DataTextField = "";
                    DDlunidadadministrativa.DataValueField = "";
                    DDlunidadadministrativa.DataBind();
                    lbnombreempresa.Text = "";
                    DDLoficinaproductora.DataSource = "";
                    DDLoficinaproductora.DataBind();
                }
                else
                {
                    DDlunidadadministrativa.DataSource = data1;
                    DDlunidadadministrativa.DataTextField = "nombre";
                    DDlunidadadministrativa.DataValueField = "id";
                    DDlunidadadministrativa.DataBind();
                    unidadadministrativa();
                }
            }

            lbnombreempresa.Text = DDLentidadproductora.SelectedItem.ToString();
        }
        protected void DDlunidadadministrativa_SelectedIndexChanged(object sender, EventArgs e)
        {
            unidadadministrativa();
        }

        public void unidadadministrativa()
        {

            if (DDLentidadproductora.SelectedItem.ToString().Length > 0)
            {


                DataTable data1 = new DataTable();
                proce.consultacamposcondicion("oficinaproductora", "id,nombre,year,mes,dia,nt,objeto", " idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and idunidadadministrativa=" + DDlunidadadministrativa.SelectedValue + " ", data1);
                if (data1.Rows.Count < 1)
                {
                    DDLoficinaproductora.DataSource = "";
                    DDLoficinaproductora.DataTextField = "";
                    DDLoficinaproductora.DataValueField = "";
                    DDLoficinaproductora.DataBind();
                    txtano.Text = "";
                    txtmes.Text = "";
                    txtdia.Text = "";
                    txtnt.Text = "";

                }
                else
                {
                    DDLoficinaproductora.DataSource = data1;
                    DDLoficinaproductora.DataTextField = "nombre";
                    DDLoficinaproductora.DataValueField = "id";
                    DDLoficinaproductora.DataBind();
                    txtano.Text = data1.Rows[0]["year"].ToString();
                    txtmes.Text = data1.Rows[0]["mes"].ToString();
                    txtdia.Text = data1.Rows[0]["dia"].ToString();
                    txtnt.Text = data1.Rows[0]["nt"].ToString();
                    if (data1.Rows[0]["objeto"].ToString() == "gestion")
                    {
                        ckgestion.Checked = true;
                        cktransferencia.Checked = false;
                        ckeliminacion.Checked = false;
                    }
                    else
                    {

                        if (data1.Rows[0]["objeto"].ToString() == "transferencia")
                        {
                            cktransferencia.Checked = true;
                            ckgestion.Checked = false;
                            ckeliminacion.Checked = false;
                        }
                        else
                        {

                            if (data1.Rows[0]["objeto"].ToString() == "eliminacion")
                            {
                                ckeliminacion.Checked = true;
                                ckgestion.Checked = false;
                                cktransferencia.Checked = false;
                            }
                        }
                    }


                }
            }
        }
        public void blanquearproyecto()
        {
            DDLentidadproductora.DataSource = "";
            DDLentidadproductora.DataTextField = "";
            DDLentidadproductora.DataValueField = "";
            DDLentidadproductora.DataBind();
            lbnombreempresa.Text = "";
            imagenempresa.Attributes.Add("src", "");
            DDlunidadadministrativa.DataSource = "";
            DDlunidadadministrativa.DataBind();
            DDLoficinaproductora.DataSource = "";
            DDLoficinaproductora.DataBind();
            txtano.Text = "";
            txtmes.Text = "";
            txtdia.Text = "";
            txtnt.Text = "";
            proyectos();
        }
        protected void btnuevo_Click(object sender, EventArgs e)
        {


            DataTable bloque = Session["dataset"] as DataTable;
            bloque.Clear();
            DataRow filanueva = bloque.NewRow();
            bloque.Rows.Add(filanueva);
            GVPRINCIPAL.DataSource = bloque;
            GVPRINCIPAL.DataBind();
            blanquearproyecto();
            ckeliminacion.Checked = false;
            ckgestion.Checked = false;
            cktransferencia.Checked = false;
        }

        protected void btbuscar_Click(object sender, EventArgs e)
        {
            
            Session["condicionbuscar"] = "";
            if (txtcedula1.Text != "")
            {
                Session["condicionbuscar"] = " and observacion like '%" + txtcedula1.Text + "%'";
            }
            if (txtfechabuscar1.Text != "")
            {
                Session["condicionbuscar"] = " and fechainicio= '" + txtfechabuscar1.Text + "' or fechafinal= '" + txtfechabuscar1.Text + "'";
            }
            if (txtcaja1.Text != "" && txtcaja2.Text != "")
            {
                Session["condicionbuscar"] = " and Cast(caja as Decimal) between '" + txtcaja1.Text + "' and '" + txtcaja2.Text + "'";
            }



            if (DDLoficinaproductora.Items.Count > 0)
            {

                DataTable data = new DataTable();
                proce.consultacamposcondicion("inventarionormal", "*,'     ' as unidadcaja,'      ' as unidadcarpeta,'      ' as unidadtom,'     ' as unidadotros", " idinstitucion =" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and idoficinaproductora='" + DDLoficinaproductora.SelectedValue + "' " + Session["condicionbuscar"].ToString() + " order by caja ASC", data);
                lbcantidad.Text = Convert.ToString(data.Rows.Count);
                if (data.Rows.Count > 0)
                {
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        
                        if (data.Rows[i]["unidadconservacion"].ToString() == "caja")
                        {
                            data.Rows[i]["unidadcaja"] = Convert.ToChar("X");
                        }

                        if (data.Rows[i]["unidadconservacion"].ToString() == "carpeta")
                        {
                            data.Rows[i]["unidadcarpeta"] = Convert.ToChar("X");
                        }

                        if (data.Rows[i]["unidadconservacion"].ToString() == "tom")
                        {
                            data.Rows[i]["unidadtom"] = Convert.ToChar("X");
                        }

                        if (data.Rows[i]["unidadconservacion"].ToString() == "otros")
                        {
                            data.Rows[i]["unidadotros"] = Convert.ToChar("X");
                        }
                        if (i > 60)
                        {
                            data.Rows[i].Delete();
                        }
                    }

                    GVPRINCIPAL.DataSource = data;
                    GVPRINCIPAL.DataBind();
                    Session["opcion"] = "caja";
                    crearfila();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No se Encontro Registros De La Oficiona Productora');", true);
                    GVPRINCIPAL.DataSource = "";
                    GVPRINCIPAL.DataBind();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debes Seleccionar Una Oficiona Productora');", true);
            }
        }

        protected void DDLoficinaproductora_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable data1 = new DataTable();
            proce.consultacamposcondicion("oficinaproductora", "id,nombre,year,mes,dia,nt,objeto", " idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and idunidadadministrativa=" + DDlunidadadministrativa.SelectedValue + " ", data1);
            if (data1.Rows.Count > 0)
            {
                txtano.Text = data1.Rows[0]["year"].ToString();
                txtmes.Text = data1.Rows[0]["mes"].ToString();
                txtdia.Text = data1.Rows[0]["dia"].ToString();
                txtnt.Text = data1.Rows[0]["nt"].ToString();

                if (data1.Rows[0]["objeto"].ToString() == "gestion")
                {
                    ckgestion.Checked = true;
                }
                else
                {

                    if (data1.Rows[0]["objeto"].ToString() == "transferencia")
                    {
                        cktransferencia.Checked = true;
                    }
                    else
                    {

                        if (data1.Rows[0]["objeto"].ToString() == "eliminacion")
                        {
                            ckeliminacion.Checked = true;
                        }
                    }
                }
            }
        }


        protected void bteditar_Click(object sender, EventArgs e)
        {
            if (DDLoficinaproductora.Items.Count > 0)
            {
                Session["opcion"] = "update";
                crearfila();
                blanquearproyecto();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debes Seleccionar Una Oficiona Productora');", true);
            }
        }

        protected void bteliminar_Click(object sender, EventArgs e)
        {
            proce.eliminar("inventarionormal", "idinstitucion =" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and idoficinaproductora ='" + DDLoficinaproductora.SelectedValue + "'");
            blanquearproyecto();
            GVPRINCIPAL.DataSource = "";
            GVPRINCIPAL.DataBind();
        }

        protected void ckcaja_CheckedChanged(object sender, EventArgs e)
        {

            Session["opcion"] = "caja";
            crearfila();

        }

        protected void txtnumerofolios_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btentidadproductora_Click(object sender, EventArgs e)
        {

            DataTable data = new DataTable();
            proce.consultacamposcondicion("proyectos", "idproyectos as id,descripcion as nombre", "idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + "", data);
            Session["tabla"] = "entidadproductora";
            Session["campos"] = "nombre,idproyecto";
            Session["padre"] = "proyecto";
            Session["hijo"] = "unidadadministrativa";
            llenarpanel("entidadproductora", "nombre,idproyecto as padre", "proyecto", Convert.ToString("idproyecto='" + Convert.ToString(DDLproyecto.SelectedValue) + "'"), data);
        }

        protected void gvpanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["id"] = gvpanel.SelectedDataKey.Values[0].ToString();
            txtnombrepanel.Text = gvpanel.SelectedDataKey.Values[1].ToString();
            DDLpanel.SelectedValue = gvpanel.SelectedDataKey.Values[2].ToString();
            Label9_ModalPopupExtender.Show();

        }
        protected void gvpanel_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (Convert.ToInt32(Session["panel"].ToString()) == 0)
            {

            }
            else
            {
                if (Convert.ToInt32(Session["panel"].ToString()) == 1)
                {
                    llenarpanelcondicion();
                }
                else
                {
                }
            }
            gvpanel.PageIndex = e.NewPageIndex;

            Label9_ModalPopupExtender.Show();

        }

        public void llenarpanel(string tabla, string campos, string padre, string datopadre, DataTable data)
        {

            if (data.Rows.Count > 0)
            {
                DDLpanel.DataSource = data;
                DDLpanel.DataTextField = "nombre";
                DDLpanel.DataValueField = "id";
                DDLpanel.DataBind();
            }

            lbpabrepanel.Text = padre;


            DataTable data2 = new DataTable();
            proce.consultacamposcondicion(tabla, "id," + campos, "idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and " + datopadre + "", data2);
            gvpanel.DataSource = data2;
            gvpanel.DataBind();
            Session["panel"] = 0;
            Label9_ModalPopupExtender.Show();
        }

        protected void btcerrar_Click(object sender, EventArgs e)
        {
            proyectos();
            DDLpanel.DataSource = "";
            DDLpanel.DataBind();
            Label9_ModalPopupExtender.Hide();
        }

        protected void btunidadadministrativa_Click(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            proce.consultacamposcondicion("entidadproductora", "id,nombre", "idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and idproyecto='" + DDLproyecto.SelectedValue + "'", data);
            Session["tabla"] = "unidadadministrativa";
            Session["campos"] = "nombre,identidadproductora";
            Session["padre"] = "entidadproductora";
            Session["hijo"] = "oficinaproductora";
            llenarpanel("unidadadministrativa", "nombre,identidadproductora as padre", "Entidad Productora", Convert.ToString("identidadproductora='" + Convert.ToString(DDLentidadproductora.SelectedValue) + "'"), data);

        }

        protected void btoficinaproductora_Click(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            proce.consultacamposcondicion("unidadadministrativa", "id,nombre", "idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and identidadproductora='" + DDLentidadproductora.SelectedValue + "'", data);
            Session["tabla"] = "oficinaproductora";
            Session["campos"] = "nombre,idunidadadministrativa";
            Session["padre"] = "unidadadministrativa";
            Session["hijo"] = "inventarionormal";
            llenarpanel("oficinaproductora", "nombre,idunidadadministrativa as padre", "Unidad Administrativa", Convert.ToString("idunidadadministrativa='" + Convert.ToString(DDlunidadadministrativa.SelectedValue) + "'"), data);
        }

        protected void btncrear_Click(object sender, EventArgs e)
        {
            if (txtnombrepanel.Text != "")
            {
                DataTable data = new DataTable();
                proce.insertaralgunos(Session["tabla"].ToString(), Session["campos"].ToString() + ",idinstitucion", "'" + txtnombrepanel.Text + "','" + DDLpanel.SelectedValue + "'," + SessionDocumental.UsuarioInicioSession.IDINSTITUCION);
                llenarpanel(Session["tabla"].ToString(), Session["campos"].ToString() + " as padre", Session["padre"].ToString(), Convert.ToString("id" + Session["padre"].ToString()), data);
                txtnombrepanel.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe Tener Un Nombre');", true);
                txtnombrepanel.Focus();
            }
            Label9_ModalPopupExtender.Show();
        }

        protected void btneliminar_Click(object sender, EventArgs e)
        {

            if (txtnombrepanel.Text != "")
            {
                string nombrecampo = "id" + Session["tabla"].ToString();
                DataTable _padre = new DataTable();
                proce.consultacamposcondicion(Session["hijo"].ToString(), "*", "idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and " + nombrecampo + " = '" + Session["id"] + "'", _padre);
                if (_padre.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No Se Puede Eliminar Porque Tiene " + Session["hijo"].ToString() + " ');", true);
                }
                else
                {
                    DataTable data = new DataTable();
                    proce.eliminar(Session["tabla"].ToString(), "idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and id ='" + Session["id"] + "'");
                    llenarpanel(Session["tabla"].ToString(), Session["campos"].ToString() + " as padre", Session["padre"].ToString(), Convert.ToString("id" + Session["padre"].ToString()), data);
                    txtnombrepanel.Text = "";
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe Tener Un Nombre');", true);
                txtnombrepanel.Focus();
            }
            Label9_ModalPopupExtender.Show();

        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            Session["panel"] = 1;
            llenarpanelcondicion();

            Label9_ModalPopupExtender.Show();
        }
        public void llenarpanelcondicion()
        {
            if (txtnombrepanel.Text != "")
            {
                DataTable data = new DataTable();
                proce.consultacamposcondicion(Session["tabla"].ToString(), "id," + Session["campos"].ToString() + " as padre", "idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and nombre like'%" + txtnombrepanel.Text + "%'", data);
                gvpanel.DataSource = data;
                gvpanel.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe Tener Un Nombre');", true);
                txtnombrepanel.Focus();
            }

            Label9_ModalPopupExtender.Show();
        }

        protected void btneditar_Click(object sender, EventArgs e)
        {

            if (txtnombrepanel.Text != "")
            {
                DataTable data = new DataTable();
                string nombrepadre = Session["campos"].ToString().Split(',').Last();
                proce.editar(Session["tabla"].ToString(), "nombre='" + txtnombrepanel.Text + "'," + nombrepadre + "='" + DDLpanel.SelectedValue + "'", "idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and id='" + Session["id"].ToString() + "'");
                llenarpanel(Session["tabla"].ToString(), Session["campos"].ToString() + " as padre", Session["padre"].ToString(), Convert.ToString("id" + Session["padre"].ToString()), data);
                txtnombrepanel.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe Tener Un Nombre');", true);
                txtnombrepanel.Focus();
            }
            Label9_ModalPopupExtender.Show();
        }

        protected void cksticker_CheckedChanged(object sender, EventArgs e)
        {



        }

        protected void btnsubir_Click(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            proce.consultacamposcondicion("inventarionormal", "*", " idinstitucion =" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and idoficinaproductora='" + DDLoficinaproductora.SelectedValue + "'", data);
            if (data.Rows.Count < 1)
            {
                if (fuImagem.HasFile)
                {

                    string endereco = Server.MapPath("~\\archivosexcel\\");
                    string nombrearchivo = fuImagem.FileName.Split('.')[0];
                    nombrearchivo = endereco + nombrearchivo + "s.xls";
                    fuImagem.SaveAs(endereco + "\\" + fuImagem.FileName);

                    string nombre = endereco + fuImagem.FileName;

                    //operaxls.Abrirxls(ref nombre, nombrearchivo);
                    // Convert_CSV_To_Excel(ref nombre,nombrearchivo);
                    DataTable nuevo = new DataTable();
                    for (int j = Convert.ToInt32(txthojaini.Text) - 1; j <= Convert.ToInt32(txthojafin.Text) - 1; j++)
                    {
                        nuevo = Cargarhistoriaslaborales(nombre, j);
                        GVPRINCIPAL.DataSource = nuevo;
                        GVPRINCIPAL.DataBind();
                        Session["opcion"] = "grabar";
                        crearfila();
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('El Registro Subio Exitosamente ');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('La oficina ya tiene registros ');", true);
            }
        }

        public DataTable Cargarhistoriaslaborales(string tcArchivo, int j)
        {

            DataTable dtTm = Session["dataset"] as DataTable;
            dtTm.Clear();
            string file = tcArchivo;


            try
            {
                Workbook book = Workbook.Load(file);

                Worksheet sheet = book.Worksheets[j];

                // traverse rows by Index
                for (int rowIndex = sheet.Cells.FirstRowIndex; rowIndex <= sheet.Cells.LastRowIndex; rowIndex++)
                {
                    if (rowIndex > 9)
                    {
                        DataRow Fila = dtTm.NewRow();

                        Row row = sheet.Cells.Rows[rowIndex];
                        for (int colIndex = row.FirstColIndex; colIndex <= row.LastColIndex; colIndex++)
                        {
                            Cell cell = row.GetCell(colIndex);

                            switch (colIndex)
                            {
                                case 0:
                                    if (Convert.ToString(cell.Value) == "")
                                    {
                                        return dtTm;
                                    }
                                    Fila["caja"] = cell.Value;
                                    break;
                                case 1:
                                    Fila["numeroorden"] = cell.Value;
                                    break;
                                case 2:
                                    Fila["codigo"] = cell.Value;
                                    break;
                                case 3:
                                    Fila["nombreserie"] = cell.Value;
                                    break;
                                case 5:
                                    Fila["fechainicio"] = cell.Value;
                                    break;
                                case 6:
                                    Fila["fechafinal"] = cell.Value;
                                    break;
                                case 7:
                                    Fila["unidadcaja"] = cell.Value;
                                    break;
                                case 8:
                                    Fila["unidadcarpeta"] = cell.Value;
                                    break;
                                case 9:
                                    Fila["unidadtom"] = cell.Value;
                                    break;
                                case 10:
                                    Fila["unidadotros"] = cell.Value;
                                    break;
                                case 11:
                                    Fila["numerofolios"] = cell.Value;
                                    if (cell.Format.FormatString == "0")
                                    {
                                        Fila["color"] = ".";
                                    }
                                    break;
                                case 12:
                                    Fila["soporte"] = cell.Value;
                                    break;
                                case 13:
                                    Fila["volumen"] = cell.Value;
                                    break;
                                case 14:
                                    Fila["observacion"] = cell.Value;
                                    break;
                                
                            }

                        }
                        dtTm.Rows.Add(Fila);
                    }
                }
                // validar que existan lo campos requeridos //
            }
            catch (Exception ex)
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('" + ex + "');", true);


            }

            return dtTm;

        }

        protected void cktodo_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btimprimisticker_Click(object sender, EventArgs e)
        {
            DataAccessLayer.stikercajaconsul.idsticker = "";
            obtenerid();
            DataAccessLayer.stikercajaconsul.idsticker = Session["stikercajaid"].ToString();
            DataTable data = new DataTable();
            proce.consultacamposcondicion("institucion", "stickercaja", "idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION, data);


            if (DataAccessLayer.stikercajaconsul.idsticker != "")
            {
                Response.Redirect(data.Rows[0]["stickercaja"].ToString(), "_blank", " menubar=0,scrollbars=1,width=780,height=900,top=10");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debes Seleccionar Minimo una Caja');", true);
            }

        }

        public void obtenerid()
        {
            Session["condicionbuscar"] = "";
            if (txtcedula1.Text != "")
            {
                Session["condicionbuscar"] = " and observacion like = '%" + txtcedula1.Text + "%'";
            }
            if (txtfechabuscar1.Text != "")
            {
                Session["condicionbuscar"] = " and fechainicio= '" + txtfechabuscar1.Text + "' or fechafinal= '" + txtfechabuscar1.Text + "'";
            }
            if (txtcaja1.Text != "" && txtcaja2.Text != "")
            {
                Session["condicionbuscar"] = " and Cast(caja as Decimal) between '" + txtcaja1.Text + "' and '" + txtcaja2.Text + "'";
            }

            DataAccessLayer.stikercajaconsul.tabla = "inventarionormal";
            DataAccessLayer.stikercajaconsul.campo = "observacion,color";
            DataAccessLayer.stikercajaconsul.oficina = DDLoficinaproductora.SelectedValue;
            if (cktodo.Checked == true)
            {

                DataTable consul1 = new DataTable();
                proce.consultacamposcondicion("inventarionormal", "id,caja", "idoficinaproductora ='" + DDLoficinaproductora.SelectedValue + "' and color='.' " + Session["condicionbuscar"].ToString(), consul1);

                for (int j = 0; j < consul1.Rows.Count; j++)
                {
                    if (j == 0)
                    {
                        Session["stikercajaid"] = consul1.Rows[j]["id"];
                        Session["stikercajainterno"] = consul1.Rows[j]["caja"];
                    }
                    else
                    {
                        Session["stikercajaid"] = Session["stikercajaid"].ToString() + "," + consul1.Rows[j]["id"];
                        Session["stikercajainterno"] = Session["stikercajainterno"].ToString() + "," + consul1.Rows[j]["caja"];
                    }

                }
                DataTable consul = new DataTable();
                proce.consultacamposcondicion("inventarionormal", "id", "idoficinaproductora ='" + DDLoficinaproductora.SelectedValue + "' and ( color !='.' or color is null)" + Session["condicionbuscar"].ToString(), consul);

                for (int i = 0; i < consul.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        Session["stikercarpetaid"] = consul.Rows[i]["id"];
                    }
                    else
                    {
                        Session["stikercarpetaid"] = Session["stikercarpetaid"].ToString() + "," + consul.Rows[i]["id"];
                    }

                }
            }
            else
            {
                if (cktodo.Checked == false)
                {
                    Session["opcion"] = "imprimir";
                    crearfila();
                }
            }


        }

        protected void btimprimirstickercarpeta_Click(object sender, EventArgs e)
        {
            DataAccessLayer.stikercajaconsul.idsticker = "";
            obtenerid();
            DataAccessLayer.stikercajaconsul.idsticker = Session["stikercarpetaid"].ToString();
            DataTable data = new DataTable();
            proce.consultacamposcondicion("institucion", "stikercarpeta", "idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION, data);


            if (DataAccessLayer.stikercajaconsul.idsticker != "")
            {
                Response.Redirect(data.Rows[0]["stikercarpeta"].ToString(), "_blank", " menubar=0,scrollbars=1,width=780,height=900,top=10");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debes Seleccionar Minimo una Carpeta');", true);
            }


        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["stikercajainterno"] = "";
            DataAccessLayer.stikercajaconsul.idsticker = "";
            obtenerid();
            DataAccessLayer.stickerinternoconsul.numerocaja = Session["stikercajainterno"].ToString();
            if (DataAccessLayer.stickerinternoconsul.numerocaja != "")
            {
                Response.Redirect("~//reporting/stickerinterios.aspx", "_blank", " menubar=0,scrollbars=1,width=780,height=900,top=10");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debes Seleccionar Minimo una Caja');", true);
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("docPendi.aspx");
        }
    }
}