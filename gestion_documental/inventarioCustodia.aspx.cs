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
    public partial class inventarioCustodia : System.Web.UI.Page
    {
        Class1 proce = new Class1();
        DataTable tabelpanel = new DataTable();
        protected void Page_Load(Object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["stikercajainterno"] = "0";
                Session["numerocaja"] = "0";
                Session["opcion"] = "";
                DataTable data1 = new DataTable();
                proce.consultacamposcondicion("institucion", "imagen", "idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION, data1);
                imagenempresa0.Attributes.Add("src",Convert.ToString(data1.Rows[0]["imagen"].ToString()));

                DataTable data = new DataTable();

                DataColumn caja = new DataColumn("caja");
                caja.DataType = System.Type.GetType("System.String");
                data.Columns.Add(caja);

                DataColumn cajacliente = new DataColumn("cajacliente");
                cajacliente.DataType = System.Type.GetType("System.String");
                data.Columns.Add(cajacliente);

                DataColumn numeroorden = new DataColumn("numeroorden");
                numeroorden.DataType = System.Type.GetType("System.String");
                data.Columns.Add(numeroorden);

                DataColumn nombreserie = new DataColumn("nombreserie");
                nombreserie.DataType = System.Type.GetType("System.String");
                data.Columns.Add(nombreserie);

                DataColumn fechainicio = new DataColumn("fechainicio");
                fechainicio.DataType = System.Type.GetType("System.String");
                data.Columns.Add(fechainicio);

                DataColumn fechafinal = new DataColumn("fechafinal");
                fechafinal.DataType = System.Type.GetType("System.String");
                data.Columns.Add(fechafinal);


                DataColumn unidadcarpeta = new DataColumn("unidadcarpeta");
                unidadcarpeta.DataType = System.Type.GetType("System.String");
                data.Columns.Add(unidadcarpeta);

                DataColumn unidadtom = new DataColumn("unidadtom");
                unidadtom.DataType = System.Type.GetType("System.String");
                data.Columns.Add(unidadtom);

                DataColumn unidadotros = new DataColumn("unidadotros");
                unidadotros.DataType = System.Type.GetType("System.String");
                data.Columns.Add(unidadotros);

                DataColumn soporte = new DataColumn("soporte");
                soporte.DataType = System.Type.GetType("System.String");
                data.Columns.Add(soporte);

                DataColumn volumen = new DataColumn("volumen");
                volumen.DataType = System.Type.GetType("System.String");
                data.Columns.Add(volumen);

                DataColumn expedientelaboral = new DataColumn("observacion");
                expedientelaboral.DataType = System.Type.GetType("System.String");
                data.Columns.Add(expedientelaboral);

                DataColumn refcaja = new DataColumn("refcaja");
                refcaja.DataType = System.Type.GetType("System.String");
                data.Columns.Add(refcaja);

                DataColumn color = new DataColumn("color");
                color.DataType = System.Type.GetType("System.String");
                data.Columns.Add(color);

                DataColumn prestamo = new DataColumn("prestamo");
                prestamo.DataType = System.Type.GetType("System.String");
                data.Columns.Add(prestamo);

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
            imagenempresa.Attributes.Add("src", Convert.ToString(proyecto.Rows[0]["imagen"].ToString()));
            proyectoentidad();

        }
        protected void GVPRINCIPAL_SelectedIndexChanged(object sender, EventArgs e)
        {

            string prestamo = GVPRINCIPAL.SelectedDataKey.Values[0].ToString();

            DataTable data = new DataTable();
            proce.consultacamposcondicion("prestamo", "*", "id='" + prestamo + "'", data);
            if (data.Rows.Count < 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No tiene prestamo');", true);
                return;
            }

            lbcodigodelprestamo.Text = data.Rows[0]["codigo"].ToString();
            lbrecibio.Text = data.Rows[0]["recibe"].ToString();
            lbcargo.Text = data.Rows[0]["cargo"].ToString();
            lbfechaprestamo.Text = data.Rows[0]["fechaini"].ToString();
            ModalPopupExtender2.Show();

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
                    string prestamoid = "";
                    if (row.Cells[20].Text.Trim() == "&nbsp;")
                    {
                        prestamoid = "";
                    }
                    else
                    {
                        prestamoid = row.Cells[20].Text;
                    }
                    fila1["prestamo"] = prestamoid;
                    TextBox caja = row.Cells[1].FindControl("txtcaja") as TextBox;
                    fila1["caja"] = caja.Text;
                    TextBox cajacliente = row.Cells[1].FindControl("txtcajacliente") as TextBox;
                    fila1["cajacliente"] = cajacliente.Text;
                    TextBox numeroorden = row.Cells[1].FindControl("txtnumeroorden") as TextBox;
                    fila1["numeroorden"] = numeroorden.Text;
                    TextBox nombreserie = row.Cells[1].FindControl("txtnombreserie") as TextBox;
                    fila1["nombreserie"] = nombreserie.Text;
                    TextBox fechainicio = row.Cells[1].FindControl("txtfechainicio") as TextBox;
                    fila1["fechainicio"] = fechainicio.Text;
                    TextBox fechafinal = row.Cells[1].FindControl("txtfechafinal") as TextBox;
                    fila1["fechafinal"] = fechafinal.Text;
                    TextBox unidadcarpeta = row.Cells[1].FindControl("txtunidadcarpeta") as TextBox;
                    fila1["unidadcarpeta"] = unidadcarpeta.Text;
                    TextBox unidadtom = row.Cells[1].FindControl("txtunidadtom") as TextBox;
                    fila1["unidadtom"] = unidadtom.Text;
                    TextBox unidadotros = row.Cells[1].FindControl("txtunidadotros") as TextBox;
                    fila1["unidadotros"] = unidadotros.Text;
                    TextBox soporte = row.Cells[1].FindControl("txtsoporte") as TextBox;
                    fila1["soporte"] = soporte.Text;
                    TextBox volumen = row.Cells[1].FindControl("txtvolumen") as TextBox;
                    fila1["volumen"] = volumen.Text;
                    TextBox observacion = row.Cells[1].FindControl("txtobservacion") as TextBox;
                    fila1["observacion"] = observacion.Text;
                    TextBox refcaja = row.Cells[1].FindControl("txtrefcaja") as TextBox;
                    fila1["refcaja"] = refcaja.Text;
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

                                        filanueva1["cajacliente"] = fila1["cajacliente"];

                                        filanueva1["numeroorden"] = fila1["numeroorden"];

                                        filanueva1["nombreserie"] = fila1["nombreserie"];

                                        filanueva1["fechainicio"] = fila1["fechainicio"];

                                        filanueva1["fechafinal"] = fila1["fechafinal"];

                                        filanueva1["unidadcarpeta"] = fila1["unidadcarpeta"];

                                        filanueva1["unidadtom"] = fila1["unidadtom"];

                                        filanueva1["unidadotros"] = fila1["unidadotros"];

                                        filanueva1["soporte"] = fila1["soporte"];

                                        filanueva1["volumen"] = fila1["volumen"];

                                        filanueva1["observacion"] = fila1["observacion"];

                                        filanueva1["refcaja"] = fila1["refcaja"];

                                        proce.insertaralgunos("inventariocustodia", "cajacliente,caja,numeroorden,nombreserie,idoficinaproductora,tercero,refcaja,idinstitucion,fechainicio,fechafinal,volumen,observacion", "'" + fila1["cajacliente"] + "','" + fila1["caja"] + "','" + fila1["numeroorden"] + "','"+ fila1["nombreserie"] + "','" + DDLoficinaproductora.SelectedValue + "','" + txtnittercero.Text + "','" + fila1["refcaja"] + "','" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + "','" + fila1["fechainicio"] + "','" + fila1["fechafinal"] + "','" + fila1["volumen"] + "','" + fila1["observacion"] + "'");
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
                                        proce.insertaralgunos("inventariocustodia", "idoficinaproductora,caja,cajacliente,tercero,refcaja,numeroorden,nombreserie,fechainicio,fechafinal,unidadconservacion,soporte,volumen,observacion,idinstitucion,color", DDLoficinaproductora.SelectedValue + ",'" + caja.Text + "','" + cajacliente.Text + "','" + txtnittercero.Text + "','" + refcaja.Text + "','" + numeroorden.Text + "','" + nombreserie.Text + "','" + fechainicio.Text + "','" + fechafinal.Text + "','" + unidadconservacion + "','" + soporte.Text + "','" + volumen.Text + "','" + observacion.Text + "','" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + "','" + color.Text + "'");

                                    }
                                    else
                                    {
                                        if (Session["opcion"].ToString() == "update")
                                        {
                                            string unidadconservacion = "";

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
                                            DataTable data = new DataTable();
                                            proce.consultacamposcondicion("inventariocustodia", "caja", "idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and idoficinaproductora='" + DDLoficinaproductora.SelectedValue + "' and id='" + id.Text + "'", data);
                                            if (data.Rows.Count > 0)
                                            {
                                                proce.editar("inventariocustodia", "caja='" + caja.Text + "',cajacliente='" + cajacliente.Text + "', numeroorden = '" + numeroorden.Text + "', refcaja='" + refcaja.Text + "',nombreserie='" + nombreserie.Text + "', fechainicio='" + fechainicio.Text + "', fechafinal = '" + fechafinal.Text + "', unidadconservacion='" + unidadconservacion + "',tercero='" + txtnittercero.Text + "', soporte='" + soporte.Text + "', volumen = '" + volumen.Text + "', observacion='" + observacion.Text + "',color='" + color.Text + "'", "idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and idoficinaproductora='" + DDLoficinaproductora.SelectedValue + "' and id='" + id.Text + "'");

                                            }
                                            else
                                            {
                                                proce.insertaralgunos("inventariocustodia", "idoficinaproductora,caja,cajacliente,tercero,refcaja,numeroorden,nombreserie,fechainicio,fechafinal,unidadconservacion,soporte,volumen,observacion,idinstitucion,color", DDLoficinaproductora.SelectedValue + ",'" + caja.Text + "','" + cajacliente.Text + "','" + txtnittercero.Text + "','" + refcaja.Text + "','" + numeroorden.Text + "','" + nombreserie.Text + "','" + fechainicio.Text + "','" + fechafinal.Text + "','" + unidadconservacion + "','" + soporte.Text + "','" + volumen.Text + "','" + observacion.Text + "','" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + "','" + color.Text + "'");
                                            }
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
                                                      

                                                       
                                                    }
                                                    fila1["color"] = ".";
                                                    Session["suma"] = 0;
                                                    Session["carpeta"] = 0;
                                                    Session["color"] = i;
                                                }
                                                else
                                                {
                                                    
                                                    Session["carpeta"] = numeroorden.Text;
                                                  
                                                }


                                                if (i == (GVPRINCIPAL.Rows.Count) - 1)
                                                {
                                                    if (Convert.ToInt32(Session["color"].ToString().Length) > 0)
                                                    {
                                                      
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
                                                        proce.eliminar("inventariocustodia", "id='" + id.Text + "'");
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
            Session["stikertabla"] = "inventariocustodia";
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

                var db = (LinkButton)e.Row.Cells[17].Controls[0];

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
                //DDLentidadproductora.DataTextField = "";
                //DDLentidadproductora.DataValueField = "";
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
                proce.consultacamposcondicion("inventariocustodia", "*", " idinstitucion =" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and idoficinaproductora='" + DDLoficinaproductora.SelectedValue + "' and tercero='"+txtnittercero.Text+"'", data);
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
            if (txtcajaclienteini.Text != "" && txtcajaclientefin.Text != "")
            {
                Session["condicionbuscar"] = " and Cast(cajacliente as Decimal) between '" + txtcajaclienteini.Text + "' and '" + txtcajaclientefin.Text + "'";
            }
           
            if (txtcaja1.Text != "" && txtcaja2.Text != "")
            {
                Session["condicionbuscar"] = " and Cast(caja as Decimal) between '" + txtcaja1.Text + "' and '" + txtcaja2.Text + "'";
            }



            if (DDLoficinaproductora.Items.Count > 0 && txtnittercero.Text !="")
            {

                DataTable data = new DataTable();
                proce.consultacamposcondicion("inventariocustodia", "*,'      ' as unidadcarpeta,'      ' as unidadtom,'     ' as unidadotros", " idinstitucion =" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and idoficinaproductora='" + DDLoficinaproductora.SelectedValue + "' and tercero='"+txtnittercero.Text+"' " + Session["condicionbuscar"].ToString() + " order by id ASC", data);
                lbcantidad.Text = Convert.ToString(data.Rows.Count);
                if (data.Rows.Count > 0)
                {
                    for (int i = 0; i < data.Rows.Count; i++)
                    {

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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debes Seleccionar Una Oficiona Productora y un tercero');", true);
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
            proce.eliminar("inventariocustodia", "idinstitucion =" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and idoficinaproductora ='" + DDLoficinaproductora.SelectedValue + "' and tercero='"+txtnittercero.Text+"'");
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
            proce.confirmaringreso("1");
            DataTable data = new DataTable();
            proce.consultacamposcondicion("inventariocustodia", "*", " idinstitucion =" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and idoficinaproductora='" + DDLoficinaproductora.SelectedValue + "' and tercero='"+txtnittercero.Text+"'", data);
            proce.confirmaringreso("2");
            if (data.Rows.Count < 1)
            {
                if (fuImagem.HasFile)
                {
                    proce.confirmaringreso("3");
                    string endereco = Server.MapPath("~\\archivosexcel\\");
                    proce.confirmaringreso("4");
                    string nombrearchivo = fuImagem.FileName.Split('.')[0];
                    proce.confirmaringreso("5");
                    nombrearchivo = endereco + nombrearchivo + "s.xls";
                    proce.confirmaringreso("6");
                    fuImagem.SaveAs(endereco + "\\" + fuImagem.FileName);
                    proce.confirmaringreso("7");
                    string nombre = endereco + fuImagem.FileName;
                    proce.confirmaringreso("8");
                    //operaxls.Abrirxls(ref nombre, nombrearchivo);
                    // Convert_CSV_To_Excel(ref nombre,nombrearchivo);
                    DataTable nuevo = new DataTable();
                    for (int j = Convert.ToInt32(txthojaini.Text) - 1; j <= Convert.ToInt32(txthojafin.Text) - 1; j++)
                    {
                        proce.confirmaringreso("9");
                        nuevo = Cargarhistoriaslaborales(nombre, j);
                        proce.confirmaringreso("10");
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
                    
                    if (rowIndex > 0)
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
                                    Fila["numeroorden"] =llenarcodigo(Convert.ToString(cell.Value));
                                    break;
                                case 1:
                                    
                                    Fila["caja"] = cell.Value;
                                    break;
                                case 2:
                                    Fila["cajacliente"] = cell.Value;
                                    break;


                                case 3:
                                    Fila["nombreserie"] = cell.Value;
                                    break;
                                case 4:
                                    Fila["fechainicio"] = cell.Value;
                                    break;
                                case 5:
                                    Fila["fechafinal"] = cell.Value;
                                    break;
                                case 6:
                                    Fila["unidadcarpeta"] = cell.Value;
                                    break;
                                case 7:
                                    Fila["unidadtom"] = cell.Value;
                                    break;
                                case 8:
                                    Fila["unidadotros"] = cell.Value;
                                    break;
                                case 9:
                                    if(Convert.ToString(cell.Value).ToString().Trim().Length==0)
                                    {
                                        Fila["color"] = ".";
                                    }
                                    Fila["soporte"] = cell.Value;
                                    break;
                                case 10:
                                    Fila["volumen"] = cell.Value;
                                    break;
                                case 11:
                                    Fila["observacion"] = cell.Value;
                                    break;
                                case 12:
                                    Fila["refcaja"] = cell.Value;
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
        public string llenarcodigo(string codigo)
        {

            for (int i = codigo.Length; i < 6; i++)
            {
                codigo = "0" + codigo;
            }
            return codigo;
        }

        protected void cktodo_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btimprimisticker_Click(object sender, EventArgs e)
        {
            if (txtnittercero.Text != "")
            {
                DataAccessLayer.stikercajaconsul.idsticker = "";
                DataAccessLayer.stikercajaconsul.tercero = txtnittercero.Text;
                obtenerid();
                DataAccessLayer.stikercajaconsul.idsticker = Session["stikercajaid"].ToString();
                DataTable data = new DataTable();
                proce.consultacamposcondicion("institucion", "stickercaja", "idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION, data);


                if (DataAccessLayer.stikercajaconsul.idsticker != "")
                {
                    Response.Redirect("~/reporting/stickertcustodiacaja.aspx", "_blank", " menubar=0,scrollbars=1,width=780,height=900,top=10");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debes Seleccionar Minimo una Caja');", true);
                }
            }
        }

        public void obtenerid()
        {
            Session["condicionbuscar"] = "";
            if (txtcajaclienteini.Text != "" && txtcajaclientefin.Text != "")
            {
                Session["condicionbuscar"] = " and Cast(cajacliente as Decimal) between '" + txtcajaclienteini.Text + "' and '" + txtcajaclientefin.Text + "'";
            }
            if (txtcaja1.Text != "" && txtcaja2.Text != "")
            {
                Session["condicionbuscar"] = " and Cast(caja as Decimal) between '" + txtcaja1.Text + "' and '" + txtcaja2.Text + "'";
            }

            DataAccessLayer.stikercajaconsul.tabla = "inventariocustodia";
            DataAccessLayer.stikercajaconsul.campo = "observacion,color";
            DataAccessLayer.stikercajaconsul.oficina = DDLoficinaproductora.SelectedValue;
            if (cktodo.Checked == true)
            {

                DataTable consul1 = new DataTable();
                proce.consultacamposcondicion("inventariocustodia", "id,caja", "idoficinaproductora ='" + DDLoficinaproductora.SelectedValue + "' and tercero='"+txtnittercero.Text+"' and color='.' " + Session["condicionbuscar"].ToString(), consul1);

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
                proce.consultacamposcondicion("inventariocustodia", "id", "idoficinaproductora ='" + DDLoficinaproductora.SelectedValue + "' and tercero='"+txtnittercero.Text+"' and ( color !='.' or color is null)" + Session["condicionbuscar"].ToString(), consul);

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
            if (txtnittercero.Text != "")
            {
                DataTable data = new DataTable();
                proce.consultacamposcondicion("terceros", "cantidadtom", "nit='" + txtnittercero.Text + "'", data);
                lbconsecutivo.Text = data.Rows[0]["cantidadtom"].ToString();
                ModalPopupExtender1.Show();
            }
           
          

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("docPendi.aspx");
        }

        protected void txtnittercero_TextChanged(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            proce.consultacamposcondicion("terceros", "nombre", "nit='" + txtnittercero.Text + "'", data);
            if (data.Rows.Count > 0)
            {
                txtnombretercero.Text = data.Rows[0]["nombre"].ToString();
            }
            else
            {
                txtnombretercero.Text = "";
                txtnittercero.Text = "";
                txtnittercero.Focus();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session["panel"] = 2;
            Session["nombre"] = "terceros";
            Session["campos"] = "id as Referencia,nit as Nit,nombre as Nombre,sucursal as Codigo,verifica as Verifica";
            Session["id"] = "nit";
            paneltotal();
            HiddenField1_ModalPopupExtender.Show();
        }
        public void paneltotal()
        {
            proce.consultacamposcondicion(Convert.ToString(Session["nombre"]), Convert.ToString(Session["campos"]), " idinstitucion= " + SessionDocumental.UsuarioInicioSession.IDINSTITUCION, tabelpanel);
            gvpaneltercero.DataSource = tabelpanel;
            gvpaneltercero.DataBind();

        }
        protected void btbuscarenelpanel_Click(object sender, EventArgs e)
        {
            Session["panel"] = 1;
            llenarpanelcondicion2();
            HiddenField1_ModalPopupExtender.Show();
        }
        public void llenarpanelcondicion2()
        {
            DataTable data1 = new DataTable();

            if (Convert.ToString(Session["id"]) == "nit")
            {
                proce.consultacamposcondicion("terceros", Convert.ToString(Session["campos"]), "(nit like'" + Txtbuscarenelpanel.Text + "%' or nombre like'%" + Txtbuscarenelpanel.Text + "%') and idinstitucion=" + Convert.ToString(SessionDocumental.UsuarioInicioSession.IDINSTITUCION), data1);
            }
            gvpaneltercero.DataSource = data1;
            gvpaneltercero.DataBind();

        }
        protected void gvpaneltercero_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (Convert.ToSingle(Session["panel"]) == 1)
            {
                llenarpanelcondicion2();
            }
            if (Convert.ToSingle(Session["panel"]) == 2)
            {
                paneltotal();
            }


            gvpaneltercero.PageIndex = e.NewPageIndex;
            HiddenField1_ModalPopupExtender.Show();
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            btcrear.Visible = false;
            HiddenField1_ModalPopupExtender.Hide();
        }
        protected void gvpaneltercero_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable data = new DataTable();

            txtnittercero.Text = proce.reformateaIns(gvpaneltercero.SelectedDataKey.Values[0].ToString());
            proce.consultacamposcondicion(Convert.ToString(Session["nombre"]), "id as Referencia,nit as codigo,nombre as Nombre,sucursal as Sucursal,verifica as Verifica", " nit = " + Convert.ToDouble(txtnittercero.Text) + " and idinstitucion = " + Convert.ToString(SessionDocumental.UsuarioInicioSession.IDINSTITUCION), data);
            if (data.Rows.Count > 0)
            {
                txtnombretercero.Text = data.Rows[0]["nombre"].ToString();

            }
            else
            {
                txtnittercero.Text = "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('El nit del cliente no existe, usa el buscador : ...');", true);
            }
        }

        protected void btgenerar_Click(object sender, EventArgs e)
        {
            int consecutivofinal;
            if(Convert.ToInt32(Convert.ToInt32(txtconsecutivoagenerar.Text)+Convert.ToInt32(txtcantidadstickert.Text))>Convert.ToInt32(lbconsecutivo.Text))
            {
                consecutivofinal=Convert.ToInt32(Convert.ToInt32(txtconsecutivoagenerar.Text)+Convert.ToInt32(txtcantidadstickert.Text));
            }else
            {
                consecutivofinal=Convert.ToInt32(lbconsecutivo.Text);
            }
            proce.editar("terceros", "cantidadtom='" + consecutivofinal + "'", "nit='" + txtnittercero.Text + "'");
            DataAccessLayer.custodiapequeñoconsul.tercero = txtnittercero.Text;
            DataAccessLayer.custodiapequeñoconsul.cantidad =Convert.ToInt32(txtcantidadstickert.Text);
            DataAccessLayer.custodiapequeñoconsul.consecutivo =Convert.ToInt32(txtconsecutivoagenerar.Text);
            txtcantidadstickert.Text = "";
            txtconsecutivoagenerar.Text = "";
            Response.Redirect("~//reporting/custodiapequeño.aspx", "_blank", " menubar=0,scrollbars=1,width=780,height=900,top=10");
        }

        protected void btsalir_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }

        protected void btreportes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~//reporting/reportescustodia.aspx");
        }
        
    }
}