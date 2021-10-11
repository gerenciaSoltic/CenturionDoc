using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestion_documental.Utils;
using gestion_documental.DataAccessLayer;
using gestion_documental.BusinessObjects;
using MySql.Data.MySqlClient;
using System.Data;

namespace gestion_documental
{
    public partial class ManageExpediente : System.Web.UI.Page
    {
        #region Page Event
        Class1 proce = new Class1();
        UnidadesManagement _unidad = new UnidadesManagement();
        ExpedienteManagement _expediente = new ExpedienteManagement();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
              DDLunidad.DataSource=_unidad.GetAllunidades();
              DDLunidad.DataTextField = "DESCRIPCION";
              DDLunidad.DataValueField = "IDUNIDADES";
              DDLunidad.DataBind();
              DDLunidad.Items.Insert(0, new ListItem("Seleccionar", "0"));

              DDLunidad2.DataSource = _unidad.GetAllunidades();
              DDLunidad2.DataTextField = "DESCRIPCION";
              DDLunidad2.DataValueField = "IDUNIDADES";
              DDLunidad2.DataBind();
              DDLunidad2.Items.Insert(0, new ListItem("Seleccionar", "0"));

                FillGvrExpediente();
            }

        }

        #endregion


        #region Expediente

        protected void FillGvrExpediente()
        {
          //  gvExpediente.DataSource = new ExpedienteManagement().GetAllExpediente();
          //  gvExpediente.DataBind();


            ddlSerie.DataSource = new SerieManagement().GetAllSeries();
            ddlSerie.DataValueField = "ID";
            ddlSerie.DataTextField = "SERIE";

            ddlSerie.DataBind();

            ddlSerie.Items.Insert(0, new ListItem("Seleccionar", "0"));

            ddlSubSerie.Items.Insert(0, new ListItem("Seleccionar", "0"));
            

           /* ddlSubSerie.DataSource = new SubSerieManagement().GetAllSubSeries();
            ddlSubSerie.DataValueField = "ID";
            ddlSubSerie.DataTextField = "SUBSERIE";

            ddlSubSerie.DataBind();
            ddlSubSerie.Items.Insert(0, new ListItem("Seleccionar", "0"));


            ddlTipologia.DataSource = new TipologiaManagement().GetAllTipologias();
            ddlTipologia.DataValueField = "ID";
            ddlTipologia.DataTextField = "TIPOLOGIA";

            ddlTipologia.DataBind();
            ddlTipologia.Items.Insert(0, new ListItem("Seleccionar", "0"));
            */
            DdlEnte.DataSource = new EnteManagement().GetAllEntes();
            DdlEnte.DataValueField = "IDENTE";
            DdlEnte.DataTextField = "DESCRIPCION";
            DdlEnte.DataBind();
            DdlEnte.Items.Insert(0, new ListItem("Seleccionar", "0"));

            cargaContenedor();

        }


        protected void ddlSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSubSerie.DataSource = new SubSerieManagement().GetAllSubSeriesBySerie(Int32.Parse(ddlSerie.SelectedValue));
            ddlSubSerie.DataValueField = "ID";
            ddlSubSerie.DataTextField = "SUBSERIE";
            ddlSubSerie.DataBind();
            ddlSubSerie.Items.Insert(0, new ListItem("Seleccionar", "0"));

            
        }


        protected void ddlSubSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
            

        protected void gvExpediente_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ExpedienteId = Convert.ToInt32(gvExpediente.SelectedDataKey.Value);
            Session["id"] = gvExpediente.SelectedDataKey.Value;
            Expediente Expediente = new ExpedienteManagement().GetExpedienteById(ExpedienteId);
           
            /**********************/
           // ddlSerie.SelectedValue = Expediente.idserie + "";
           // ddlSubSerie.SelectedValue = Expediente.idsubserie + "";
           // ddlTipologia.SelectedValue = Expediente.idtipologia + "";
            /**********************/
                                

            try
            {
                ddlSerie.SelectedValue = Expediente.idserie + "";
            }
            catch (Exception exc1)
            {
                ddlSerie.SelectedValue = "0";

                ddlSubSerie.Items.Clear();
                ddlSubSerie.Items.Insert(0, new ListItem("Seleccionar", "0"));

                ddlSubSerie.SelectedValue = "0";


                
            }

            try
            {
                ddlSubSerie.DataSource = new SubSerieManagement().GetAllSubSeriesBySerie(Expediente.idserie);
                ddlSubSerie.DataValueField = "ID";
                ddlSubSerie.DataTextField = "SUBSERIE";
                ddlSubSerie.DataBind();
                ddlSubSerie.Items.Insert(0, new ListItem("Seleccionar", "0"));

                ddlSubSerie.SelectedValue = Expediente.idsubserie + "";
            }
            catch (Exception exc1)
            {

                ddlSubSerie.SelectedValue = "0";

                
            }


            try
            {
               
            }
            catch (Exception exc1)
            {

               
            }

            txtDescripcion.Text = Expediente.descripcion.ToString();
            txtFechainicio.Text = Expediente.Fechainicio.ToString();
            txtFechafinal.Text = Expediente.Fechafinal.ToString();
            txtcodigoexpediente.Text = Expediente.codigo.ToString();
            DDLfasearchivo.SelectedValue = Expediente.fasearchivo.ToString();
            txtnumerounidad.Text = Expediente.numerounidad.ToString();
            txtnumerounidad2.Text = Expediente.numerounidad2.ToString();
            txtnumerodeidentificacion.Text = Expediente.numerodeidentificacion.ToString();
            btnAddExpediente.Text = "Editar";
            /*
            gvIndicesExpedientes.DataSource = new ExpedienteIndiceManagement().GetAllExpedienteIndice(Expediente.idserie,Expediente.idsubserie,Expediente.idtipologia,ExpedienteId);
           
            
            gvIndicesExpedientes.DataBind();
            gvIndicesExpedientes.Visible = true;
            if (gvIndicesExpedientes.Rows.Count == 0)
            {
                AdicionaAtributos();
            }
            LlenagvIndicesExpedientes();
            */
            DdlEnte.SelectedValue = Expediente.idente.ToString();
            cargaContenedor();
            ddlContenedor.SelectedValue = Expediente.contenedor;
            cargaCompartimiento();
            ddlCompartimiento.SelectedValue = Expediente.compartimiento.ToString();
            DDLunidad.SelectedValue = Expediente.unidad.ToString();
            DDLunidad2.SelectedValue = Expediente.unidad2.ToString();
        }


       

        protected void gvExpediente_DeleteEventHandler(object sender, GridViewDeleteEventArgs e)
        {
            int idExpediente = (int)gvExpediente.DataKeys[Convert.ToInt32(e.RowIndex)].Value;

            if (!new ExpedienteManagement().DeleteExpediente(idExpediente))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Ocurrio un problema al eliminar el registro, quizas este siendo usado');", true);
            }

            FillGvrExpediente();
        }


        protected void gvShowExpediente_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // reference the Delete LinkButton
                LinkButton db = (LinkButton)e.Row.Cells[7].Controls[0];

                db.OnClientClick = "return confirm('Esta seguro que desea eliminar ?');";
            }
        }

        protected void btnClearExpediente_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = string.Empty;
            txtFechainicio.Text = string.Empty;
            txtFechafinal.Text = string.Empty;
            txtnumerodeidentificacion.Text = string.Empty;
            txtnumerounidad.Text = string.Empty;
            txtnumerounidad2.Text = string.Empty;
            btnAddExpediente.Text = "Añadir";

            ddlSerie.SelectedValue = "0";
            
            ddlSubSerie.SelectedValue = "0";
            DDLunidad.SelectedValue = "0";
            DDLunidad2.SelectedValue = "0";
            DdlEnte.SelectedValue = "0";
            ddlContenedor.SelectedValue = "0";
            ddlCompartimiento.SelectedValue = "0";

            gvIndicesExpedientes.Visible = false;
            Label1.Visible = false;
        }

        protected void btnAddExpediente_Click(object sender, EventArgs e)
        {
            if (btnAddExpediente.Text == "Añadir")
            {
                Expediente Expediente = new Expediente();
               
                Expediente.idserie = Convert.ToInt32(ddlSerie.SelectedValue);
                Expediente.idsubserie = Convert.ToInt32(ddlSubSerie.SelectedValue);
                Expediente.idtipologia = 0;
                Expediente.descripcion = txtDescripcion.Text;
                Expediente.Fechainicio =Convert.ToDateTime(proce.formateafecha( Convert.ToDateTime(txtFechainicio.Text),0));
                if (txtFechafinal.Text == "")
                {
                    txtFechafinal.Text = "01/01/001";
                }
                Expediente.Fechafinal =Convert.ToDateTime(proce.formateafecha( Convert.ToDateTime(txtFechafinal.Text),0));
                Expediente.idente = Convert.ToInt32(DdlEnte.SelectedValue);
                Expediente.contenedor = ddlContenedor.SelectedValue;

                if (ddlCompartimiento.SelectedValue != "")
                {
                    Expediente.compartimiento = Convert.ToInt32(ddlCompartimiento.SelectedValue);
                }
                else
                {
                    Expediente.compartimiento = 0;
                }

                Expediente.codigo = txtcodigoexpediente.Text;
                Expediente.fasearchivo = DDLfasearchivo.SelectedValue;
                Expediente.unidad =Convert.ToInt32(DDLunidad.SelectedValue);
                Expediente.unidad2 = Convert.ToInt32(DDLunidad2.SelectedValue);

                if (txtnumerounidad2.Text != "")
                {
                    Expediente.numerounidad2 = Convert.ToInt32(txtnumerounidad2.Text);
                }
                else
                {
                    Expediente.numerounidad2 = 0;
                }

                if (txtnumerounidad.Text != "")
                {
                    Expediente.numerounidad = txtnumerounidad.Text;
                }
                else
                {
                    Expediente.numerounidad = "0";
                }

                Expediente.numerodeidentificacion = txtnumerodeidentificacion.Text;
                new ExpedienteManagement().InsertExpediente(Expediente);
                FillGvrExpediente();
                btnClearExpediente_Click(null, null);
                gvIndicesExpedientes.Visible = false;
                Label1.Visible = false;
            }
            else
            {

                Expediente Expediente = new Expediente();
                Expediente.id = Convert.ToInt32(Session["id"].ToString());
                Expediente.unidad = Convert.ToInt32(DDLunidad.SelectedValue);
                Expediente.idserie = Convert.ToInt32(ddlSerie.SelectedValue);
                Expediente.idsubserie = Convert.ToInt32(ddlSubSerie.SelectedValue);
                Expediente.idtipologia = 0;
                Expediente.descripcion = txtDescripcion.Text;
                Expediente.Fechainicio = Convert.ToDateTime(proce.formateafecha(Convert.ToDateTime(txtFechainicio.Text),0));
                if (txtFechafinal.Text == "")
                {
                    txtFechafinal.Text = "01/01/001";
                }
                Expediente.Fechafinal =Convert.ToDateTime(proce.formateafecha(Convert.ToDateTime(txtFechafinal.Text),0));
                Expediente.idente = Convert.ToInt32(DdlEnte.SelectedValue);
                Expediente.contenedor = ddlContenedor.SelectedValue;
                if (ddlCompartimiento.SelectedValue == "")
                {
                    Expediente.compartimiento = 0;
                }
                else
                {
                    Expediente.compartimiento = Convert.ToInt32(ddlCompartimiento.SelectedValue);
                }
                Expediente.codigo = txtcodigoexpediente.Text;
                Expediente.fasearchivo = DDLfasearchivo.SelectedValue;
                Expediente.unidad2 = Convert.ToInt32(DDLunidad2.SelectedValue);
                Expediente.numerounidad2 = Convert.ToInt32(txtnumerounidad2.Text);
                Expediente.numerounidad = txtnumerounidad.Text;
                Expediente.numerodeidentificacion = txtnumerodeidentificacion.Text;

                new ExpedienteManagement().UpdateExpediente(Expediente);
                FillGvrExpediente();
                btnClearExpediente_Click(null, null);
                gvIndicesExpedientes.Visible = false;
                Label1.Visible = false;
            }
        }

        public void AdicionaAtributos()
        {
            int ExpedienteId = Convert.ToInt32(gvExpediente.SelectedDataKey.Value);
            Expediente Expediente = new ExpedienteManagement().GetExpedienteById(ExpedienteId);
            ListBox lista = new ListBox();
            lista.DataSource = new subserieIndiceManagement().GetAllsubserieIndice(Expediente.idserie,Expediente.idsubserie);
            lista.DataTextField = "ATRIBUTO";
            lista.DataValueField = "ATRIBUTO";
            lista.DataBind();
            ExpedienteIndice ExpedienteIndice = new ExpedienteIndice();
            ExpedienteIndice.IDSERIE = Expediente.idserie;
            ExpedienteIndice.IDSUBSERIE = Expediente.idsubserie;
            ExpedienteIndice.IDEXPEDIENTE = Expediente.id;
            ExpedienteIndice.IDTIPOLOGIA = Expediente.idtipologia;

            foreach (ListItem item in lista.Items)
            {

                
                item.Selected = true;
                ExpedienteIndice.ATRIBUTO = item.Text;

                new ExpedienteIndiceManagement().Insertexpedienteindice(ExpedienteIndice);



            }

            gvIndicesExpedientes.DataSource = new ExpedienteIndiceManagement().GetAllExpedienteIndice(Expediente.idserie, Expediente.idsubserie, Expediente.idtipologia, ExpedienteId);
            gvIndicesExpedientes.DataBind();
            gvIndicesExpedientes.Visible = true;
            Label1.Visible = true;
        }


        #endregion

        protected void gvIndicesExpedientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
                    
            
            gvIndicesExpedientes.EditIndex = e.NewEditIndex;
            LlenagvIndicesExpedientes();

        }

        protected void gvIndicesExpedientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvIndicesExpedientes.EditIndex = -1;
            LlenagvIndicesExpedientes();
            

        }

        protected void LlenagvIndicesExpedientes()
        {

            int ExpedienteId = Convert.ToInt32(gvExpediente.SelectedDataKey.Value);
            Expediente Expediente = new ExpedienteManagement().GetExpedienteById(ExpedienteId);
            ExpedienteIndice ExpedienteIndice = new ExpedienteIndice();
            ExpedienteIndice.IDSERIE = Expediente.idserie;
            ExpedienteIndice.IDSUBSERIE = Expediente.idsubserie;
            ExpedienteIndice.IDEXPEDIENTE = Expediente.id;
            ExpedienteIndice.IDTIPOLOGIA = Expediente.idtipologia;
            gvIndicesExpedientes.DataSource = new ExpedienteIndiceManagement().GetAllExpedienteIndice(Expediente.idserie, Expediente.idsubserie, Expediente.idtipologia, ExpedienteId);
            gvIndicesExpedientes.DataBind();


        }

        protected void gvIndicesExpedientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int ExpedienteId = Convert.ToInt32(gvExpediente.SelectedDataKey.Value.ToString());
            Expediente Expediente = new ExpedienteManagement().GetExpedienteById(ExpedienteId);
            ExpedienteIndice ExpedienteIndice = new ExpedienteIndice();
            Label lblId = (Label)gvIndicesExpedientes.Rows[e.RowIndex].FindControl("lblID");
            ExpedienteIndice.ID = Convert.ToInt32(lblId.Text);
            ExpedienteIndice.IDSERIE= Expediente.idserie;
            ExpedienteIndice.IDSUBSERIE = Expediente.idsubserie;
            ExpedienteIndice.IDTIPOLOGIA = Expediente.idtipologia;
            ExpedienteIndice.IDEXPEDIENTE = Expediente.id;




            Label lblAtri = (Label)gvIndicesExpedientes.Rows[e.RowIndex].FindControl("lblAtributo");
            
           
            TextBox txtIndi = (TextBox)gvIndicesExpedientes.Rows[e.RowIndex].FindControl("txtIndice");
            ExpedienteIndice.ATRIBUTO = lblAtri.Text;
            ExpedienteIndice.INDICE = txtIndi.Text;

            //ExpedienteIndice.INDICE = txtIndice.Text; ;
            
            new ExpedienteIndiceManagement().UpdateExpedienteIndice(ExpedienteIndice);
            gvIndicesExpedientes.EditIndex = -1;

            LlenagvIndicesExpedientes();
            


        }

        protected void gvIndicesExpedientes_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
                        
        }

        protected void gvIndicesExpedientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idExpedienteIndice = (int)gvIndicesExpedientes.DataKeys[Convert.ToInt32(e.RowIndex)].Value;

            if (!new ExpedienteIndiceManagement().DeleteExpedienteIndice(idExpedienteIndice))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Ocurrio un problema al eliminar el registro, quizas este siendo usado');", true);
            }
            LlenagvIndicesExpedientes();

            
        }
        protected void cargaContenedor()
        {
            ddlContenedor.Items.Clear();
            List<EnteRuta> enteRutas = new EnteRutaManagement().GetEnteRutaByIdEnte(Convert.ToInt32(DdlEnte.SelectedValue));
            ListItem lista=new ListItem();
            
            foreach(EnteRuta entRut in enteRutas)
            {
                lista = new ListItem();
                lista.Text=entRut.CONTENEDOR.ToString()+" "+entRut.NUMERO.ToString();
                lista.Value = entRut.IDENTERUTA.ToString();
                //lista.Value = entRut.CONTENEDOR.ToString() + " " + entRut.NUMERO.ToString();
                ddlContenedor.Items.Add(lista);
            }
            ddlContenedor.Items.Insert(0, new ListItem("Seleccionar", "0"));
            ddlContenedor.DataBind();
        }
        protected void cargaCompartimiento()
        {
            ddlCompartimiento.Items.Clear();
            EnteRuta enteRutas = new EnteRutaManagement().GetEnteRutaById(Convert.ToInt32(ddlContenedor.SelectedValue));
            ListItem lista = new ListItem();
            
            int cant = enteRutas.COMPARTIMIENTO;
            for (int i = 1; i <= cant; i++)
            {
                lista = new ListItem();
                lista.Text = i.ToString();
                lista.Value = i.ToString();
                ddlCompartimiento.Items.Add(lista);
            }
            ddlCompartimiento.Items.Insert(0, new ListItem("Seleccionar", "0"));
            ddlCompartimiento.DataBind();
        }

        protected void cambiaContenedor(object sender, EventArgs e)
        {
            cargaCompartimiento();
        }

        protected void cambiaOficina(object sender, EventArgs e)
        {
         ddlContenedor.Items.Clear();
         ddlCompartimiento.Items.Clear();
         cargaContenedor();
         gvExpediente.DataSource=_expediente.GetExpedienteByidente(Convert.ToInt32(DdlEnte.SelectedValue.ToString()));
         gvExpediente.DataBind();

        }

        protected void Btnbuscar_Click(object sender, EventArgs e)
        {
            txtbuscar.Visible = true;
        }

        protected void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            int Idente = new DataAccessLayer.EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO).IDENTE;
         gvExpediente.DataSource=_expediente.GetExpedienteBynumerodeidentificacion(txtbuscar.Text,Idente);
         gvExpediente.DataBind();
         txtbuscar.Visible = false;
        }

        protected void ckinventariohis_CheckedChanged(object sender, EventArgs e)
        {
            proce.eliminar("inventario", "cedula='" + txtnumerodeidentificacion.Text + "'");
            DataTable data =new DataTable();
            DataTable dataescalafon = new DataTable();
            DataTable dataprestaciones = new DataTable();
            int numerofolios =0;
            string identificador = "-";
            int NU =0;
            proce.consultacampos("controllaboral having id=(select max(id) as id from controllaboral where documento='" + txtnumerodeidentificacion.Text + "' and idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and seccion='HISTORIA LABORAL')", "id,folios as folio,primernombre,segundonombre,primerapellido,segundoapellido", data);
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
           proce.consultacampos("controllaboral having id=(select max(id) as id from controllaboral where documento='" + txtnumerodeidentificacion.Text + "' and idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and seccion='ESCALAFON')", "id,folios as folio,primernombre,segundonombre,primerapellido,segundoapellido", dataescalafon);

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
           proce.consultacampos("controllaboral having id=(select max(id) as id from controllaboral where documento='" + txtnumerodeidentificacion.Text + "' and idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + " and seccion='PRESTACIONES SOCIALES')", "id,folios as folio,primernombre,segundonombre,primerapellido,segundoapellido", dataprestaciones);

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
            //


           string nombrecompleto = data.Rows[0]["primerapellido"].ToString() + "  " + data.Rows[0]["segundoapellido"].ToString() + "  " + data.Rows[0]["primernombre"].ToString() + "  " + data.Rows[0]["segundonombre"].ToString(); 
            DataTable data1 =new DataTable();
            proce.consultacamposcondicion("serie","serie,codigo","id='"+ddlSerie.SelectedValue+"'",data1);
            proce.insertaralgunos("inventario", "cedula,idoficinaproductora,codigo,nombreserie,fechainicio,fechafinal,caja,numeroorden,volumen,numerofolios,expedientelaboral,idinstitucion", "'" + txtnumerodeidentificacion.Text + "','" + DdlEnte.SelectedValue + "','" + data1.Rows[0]["codigo"].ToString() + "','" + data1.Rows[0]["serie"].ToString() + "','" +proce.formateafecha(Convert.ToDateTime(txtFechainicio.Text),0) + "','" + proce.formateafecha(Convert.ToDateTime(txtFechafinal.Text),0) + "','" + txtnumerounidad.Text + "','" + txtnumerounidad2.Text + "','1/1','" + numerofolios + "','" + nombrecompleto + "','"+SessionDocumental.UsuarioInicioSession.IDINSTITUCION+"'");
            ckinventariohis.Checked = false;
        }

       
    }
}