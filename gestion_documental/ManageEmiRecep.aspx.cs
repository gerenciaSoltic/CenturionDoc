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
    public partial class ManageEmiRecep : System.Web.UI.Page
    {
        #region Page Event
        Class1 proce = new Class1();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGvrEmiRecep();
            }

        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SettingsMenu.aspx", false);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SettingsMenu.aspx", false);
        }

        #endregion




        #region EmiRecep

        protected void FillGvrEmiRecep()
        {

            MySqlDataAdapter mda;
            MySqlConnection Con = new MySqlConnection();
            ConnectionClass conclass = new ConnectionClass();
            Con = conclass.Connection;

            if (Con.State == ConnectionState.Closed)
                Con.Open();
            mda = new MySqlDataAdapter(@"
                                            select * from paises; 
                                            select * from departamentos ORDER BY nombre; 
                                            
                                            select * from usuarios; 
                                            select * from tipoemirec; 
                                            select * from conficor; 
                                            select * from ente; 
                                            select * from cargo;
                                            select * from radicados;", Con);

            DataSet ds = new DataSet();

            mda.Fill(ds);

            ddlPais.DataSource = ds.Tables[0];
            ddlPais.DataValueField = "codigo";
            ddlPais.DataTextField = "nombre";
            ddlPais.DataBind();
            ddlPais.Items.Insert(0, new ListItem("Seleccionar", "0"));


            ddlDepartamento.DataSource = ds.Tables[1];
            ddlDepartamento.DataValueField = "CODIGODEP";
            ddlDepartamento.DataTextField = "NOMBRE";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("Seleccionar", "0"));

            /*
            ddlMunicipio.DataSource = ds.Tables[2];
            ddlMunicipio.DataValueField = "codigo";
            ddlMunicipio.DataTextField = "nombre";
            ddlMunicipio.DataBind();
            ddlMunicipio.Items.Insert(0, new ListItem("Seleccionar", "0"));
             * */

            ddlUsuario.DataSource = ds.Tables[2];
            ddlUsuario.DataValueField = "CODIGO";
            ddlUsuario.DataTextField = "NOMBRE";
            ddlUsuario.DataBind();
            ddlUsuario.Items.Insert(0, new ListItem("Seleccionar", "0"));

            ddlTipoEmisor.DataSource = ds.Tables[3];
            ddlTipoEmisor.DataValueField = "ID";
            ddlTipoEmisor.DataTextField = "DESCRIPCION";
            ddlTipoEmisor.DataBind();
            ddlTipoEmisor.Items.Insert(0, new ListItem("Seleccionar", "0"));

            ddlConfiCor.DataSource = ds.Tables[4];
            ddlConfiCor.DataValueField = "ID";
            ddlConfiCor.DataTextField = "EMAIL";
            ddlConfiCor.DataBind();
            ddlConfiCor.Items.Insert(0, new ListItem("Seleccionar", "0"));

            ddlEnte.DataSource = ds.Tables[5];
            ddlEnte.DataValueField = "IDENTE";
            ddlEnte.DataTextField = "DESCRIPCION";
            ddlEnte.DataBind();
            ddlEnte.Items.Insert(0, new ListItem("Seleccionar", "0"));

            ddlCargo.DataSource = ds.Tables[6];
            ddlCargo.DataValueField = "IDCARGO";
            ddlCargo.DataTextField = "DESCRIPCION";
            ddlCargo.DataBind();
            ddlCargo.Items.Insert(0, new ListItem("Seleccionar", "0"));

            ddlRadicado.DataSource = ds.Tables[7];
            ddlRadicado.DataValueField = "idradicados";
            ddlRadicado.DataTextField = "prefInter";
            ddlRadicado.DataBind();
            ddlRadicado.Items.Insert(0, new ListItem("Seleccionar", "0"));

           // gvEmiRecep.DataSource = new EmiRecepManagement().GetAllEmiRecep();

           // gvEmiRecep.DataBind();

        }

        protected void gvEmiRecep_SelectedIndexChanged(object sender, EventArgs e)
        {
            int EmiRecepId = Convert.ToInt32(gvEmiRecep.SelectedDataKey.Value);
            EmiRecep EmiRecep = new EmiRecepManagement().GetEmiRecepById(EmiRecepId);

            txtNit.Text = EmiRecep.NIT;
            txtDescripcion.Text = EmiRecep.DESCRIPCION;
            txtDireccionFisica.Text = EmiRecep.DIRECCIONFISICA;
            txtEmail.Text = EmiRecep.EMAIL;
            //txtContrasena.Text = EmiRecep.CONTRASENAEMAIL;
            //txtFoto.Text = EmiRecep.FOTO;
            txtTelefono.Text = EmiRecep.TELEFONO;

            try
            {
                ddlPais.SelectedValue = EmiRecep.PAIS + ""; 
            } catch (Exception exc) { ddlPais.SelectedValue = "0"; }


            try
            {
                ddlDepartamento.SelectedValue = EmiRecep.DEPARTAMENTO + "";
            }
            catch (Exception exc) { ddlDepartamento.SelectedValue = "0"; }

            try
            {
                DataTable DatosMun = new DataTable();
                proce.consultacamposcondicion("municipios", "codigo,nombre", "codigodep ='" + EmiRecep.DEPARTAMENTO + "' ORDER BY NOMBRE", DatosMun);
                ddlMunicipio.DataSource = DatosMun;
                ddlMunicipio.DataValueField = "codigo";
                ddlMunicipio.DataTextField = "nombre";
                ddlMunicipio.DataBind();
                ddlMunicipio.Items.Insert(0, new ListItem("Seleccionar", "0"));
                ddlMunicipio.SelectedValue = EmiRecep.MUNICIPIO + "";
            }
            catch (Exception exc) { ddlMunicipio.SelectedValue = "0"; }

            try
            {
                ddlUsuario.SelectedValue = EmiRecep.CODIGOUSUARIO + "";
            }
            catch (Exception exc) { ddlUsuario.SelectedValue = "0"; }

            try
            {
                ddlTipoEmisor.SelectedValue = EmiRecep.IDTIPOEMISOR + "";
            }
            catch (Exception exc) { ddlTipoEmisor.SelectedValue = "0"; }

            try
            {
                ddlConfiCor.SelectedValue = EmiRecep.IDCONFICOR + "";
            }
            catch (Exception exc) { ddlConfiCor.SelectedValue = "0"; }

            try
            {
                ddlEnte.SelectedValue = EmiRecep.IDENTE + "";
            }
            catch (Exception exc) { ddlEnte.SelectedValue = "0"; }

            try
            {
                ddlCargo.SelectedValue = EmiRecep.IDCARGO + "";
            }
            catch (Exception exc) { ddlCargo.SelectedValue = "0"; }

            try
            {
                ddlRadicado.SelectedValue = EmiRecep.IDRADICADO + "";
            }
            catch (Exception exc) { ddlRadicado.SelectedValue = "0"; }
            
            btnAddEmiRecep.Text = "Editar";
        }

        protected void gvEmiRecept_DeleteEventHandler(object sender, GridViewDeleteEventArgs e)
        {
            int idEmiRecep = (int)gvEmiRecep.DataKeys[Convert.ToInt32(e.RowIndex)].Value;

            if (!new EmiRecepManagement().DeleteEmiRecep(idEmiRecep))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Ocurrio un problema al eliminar el registro, quizas este siendo usado');", true);
            }

            FillGvrEmiRecep();
        }


        protected void gvShowEmiRecept_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // reference the Delete LinkButton
                LinkButton db = (LinkButton)e.Row.Cells[13].Controls[0];

                db.OnClientClick = "return confirm('Esta seguro que desea eliminar ?');";
            }
        }

        protected void btnClearEmiRecep_Click(object sender, EventArgs e)
        {
            txtEmail.Text = String.Empty;

            txtNit.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            txtDireccionFisica.Text = String.Empty;
            txtEmail.Text = String.Empty;
            //txtContrasena.Text = String.Empty;
            //txtFoto.Text = String.Empty;
            txtTelefono.Text = String.Empty;

            ddlPais.SelectedValue = "0";
            ddlDepartamento.SelectedValue = "0";
            ddlMunicipio.SelectedValue = "0";
            ddlUsuario.SelectedValue = "0";
            ddlTipoEmisor.SelectedValue = "0";
            ddlConfiCor.SelectedValue = "0";
            ddlEnte.SelectedValue = "0";
            ddlCargo.SelectedValue = "0";
            ddlRadicado.SelectedValue = "0";

            btnAddEmiRecep.Text = "Añadir";
        }

        protected void btnAddEmiRecep_Click(object sender, EventArgs e)
        {
            if (btnAddEmiRecep.Text == "Añadir")
            {
                EmiRecep EmiRecep = new EmiRecep();

                EmiRecep.NIT = txtNit.Text;
                EmiRecep.DESCRIPCION = txtDescripcion.Text;
                EmiRecep.DIRECCIONFISICA = txtDireccionFisica.Text;
                EmiRecep.EMAIL = txtEmail.Text;
                //EmiRecep.CONTRASENAEMAIL = txtContrasena.Text;
                //EmiRecep.FOTO = txtFoto.Text;
                EmiRecep.TELEFONO = txtTelefono.Text;

                EmiRecep.PAIS = Convert.ToInt32(ddlPais.SelectedValue);
                EmiRecep.DEPARTAMENTO = Convert.ToInt32(ddlDepartamento.SelectedValue);
                EmiRecep.MUNICIPIO = Convert.ToInt32(ddlMunicipio.SelectedValue);
                EmiRecep.CODIGOUSUARIO = Convert.ToInt32(ddlUsuario.SelectedValue);
                EmiRecep.IDTIPOEMISOR = Convert.ToInt32(ddlTipoEmisor.SelectedValue);
                EmiRecep.IDCONFICOR = Convert.ToInt32(ddlConfiCor.SelectedValue);
                EmiRecep.IDENTE = Convert.ToInt32(ddlEnte.SelectedValue);
                EmiRecep.IDCARGO = Convert.ToInt32(ddlCargo.SelectedValue);
                EmiRecep.IDRADICADO = Convert.ToInt32(ddlRadicado.SelectedValue);

                new EmiRecepManagement().InsertEmiRecep(EmiRecep);
                FillGvrEmiRecep();
                btnClearEmiRecep_Click(null, null);
            }
            else
            {
                EmiRecep EmiRecep = new EmiRecep();

                EmiRecep.ID = Convert.ToInt32(gvEmiRecep.SelectedDataKey.Value);
                EmiRecep.NIT = txtNit.Text;
                EmiRecep.DESCRIPCION = txtDescripcion.Text;
                EmiRecep.DIRECCIONFISICA = txtDireccionFisica.Text;
                EmiRecep.EMAIL = txtEmail.Text;
                //EmiRecep.CONTRASENAEMAIL = txtContrasena.Text;
                //EmiRecep.FOTO = txtFoto.Text;
                EmiRecep.TELEFONO = txtTelefono.Text;

                EmiRecep.PAIS = Convert.ToInt32(ddlPais.SelectedValue);
                EmiRecep.DEPARTAMENTO = Convert.ToInt32(ddlDepartamento.SelectedValue);
                EmiRecep.MUNICIPIO = Convert.ToInt32(ddlMunicipio.SelectedValue);
                EmiRecep.CODIGOUSUARIO = Convert.ToInt32(ddlUsuario.SelectedValue);
                EmiRecep.IDTIPOEMISOR = Convert.ToInt32(ddlTipoEmisor.SelectedValue);
                EmiRecep.IDCONFICOR = Convert.ToInt32(ddlConfiCor.SelectedValue);
                EmiRecep.IDENTE = Convert.ToInt32(ddlEnte.SelectedValue);
                EmiRecep.IDCARGO = Convert.ToInt32(ddlCargo.SelectedValue);
                EmiRecep.IDRADICADO = Convert.ToInt32(ddlRadicado.SelectedValue);

                new EmiRecepManagement().UpdateEmiRecep(EmiRecep);

                FillGvrEmiRecep();
                btnClearEmiRecep_Click(null, null);
            }
        }

        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
            gvEmiRecep.DataSource = new EmiRecepManagement().GetAllEmiRecepNitNombre(TxtBuscar.Text.Trim());
            gvEmiRecep.DataBind();
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable DatosMun = new DataTable();
            proce.consultacamposcondicion("municipios", "codigo,nombre", "codigodep ='" + ddlDepartamento.SelectedValue.ToString() + "' ORDER BY NOMBRE", DatosMun);
            ddlMunicipio.DataSource = DatosMun;
            ddlMunicipio.DataValueField = "codigo";
            ddlMunicipio.DataTextField = "nombre";
            ddlMunicipio.DataBind();
            ddlMunicipio.Items.Insert(0, new ListItem("Seleccionar", "0"));

        }
    }
}