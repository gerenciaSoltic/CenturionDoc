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
    public partial class creaemisor : System.Web.UI.Page
    {
        #region Page Event
        Class1 proce = new Class1();
        string host = HttpContext.Current.Request.Url.Host;

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


            //gvEmiRecep.DataSource = new EmiRecepManagement().GetAllEmiRecep();

            //gvEmiRecep.DataBind();

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
                if (host == "localhost")
                {
                    EmiRecep.LOCAL = 1;
                }
                else
                {
                    EmiRecep.LOCAL = 0;
                }
                int lnId = new EmiRecepManagement().InsertEmiRecep(EmiRecep);
                Session["idemisor"] =lnId;
                Session["nomemisor"] = EmiRecep.DESCRIPCION;
                FillGvrEmiRecep();
                btnClearEmiRecep_Click(null, null);
            }  
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