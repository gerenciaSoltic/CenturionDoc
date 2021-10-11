using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using gestion_documental.Utils;

namespace gestion_documental
{
    public partial class terceros : System.Web.UI.Page
    {
        Class1 proce = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillFormularios();
                TxtNit.Attributes.Add("onkeypress", "javascript:return ValidNum(event);");
            }
        }
        protected void FillFormularios()
        {
            DataTable data = new DataTable();
            proce.consultacamposcondicion("terceros", "distinct tipodoc", "idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION, data);
            DDLTipoDoc.DataSource = data;
            DDLTipoDoc.DataTextField = "tipodoc";
            DDLTipoDoc.DataValueField = "tipodoc";
            DDLTipoDoc.DataBind();
            DDLTipoDoc.Items.Insert(0, new ListItem("Seleccionar", "0"));
            if (data.Rows.Count < 2)
            {
                DDLTipoDoc.Items.Insert(1, new ListItem("NIT", "NIT"));
                DDLTipoDoc.Items.Insert(2, new ListItem("CC", "CC"));
            }
          

            DataTable tTerceros = new DataTable();
            proce.consultacamposcondicion("terceros", "id,nit,verifica,nombre,direccion,telefono,email,nombre1,nombre2,apellido1,apellido2, nomdepto, nommuni,sucursal,sector", "idinstitucion = " + SessionDocumental.UsuarioInicioSession.IDINSTITUCION.ToString() + " order by nombre ASC limit 20 ", tTerceros);
            GridView1.DataSource = tTerceros;
            GridView1.DataBind();

            var departamentos = new DataTable();
            proce.consultacampos("departamento", " codigo,nombre ", departamentos);
            ddlDepartamento.DataSource = departamentos;
            ddlDepartamento.DataValueField = "codigo";
            ddlDepartamento.DataTextField = "nombre";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("Seleccionar", "0"));

            var municipios = new DataTable();
            proce.consultacampos("municipios", " codigo,nombre ", municipios);
            ddlMunicipio.DataSource = municipios;
            ddlMunicipio.DataValueField = "codigo";
            ddlMunicipio.DataTextField = "nombre";
            ddlMunicipio.DataBind();
            ddlMunicipio.Items.Insert(0, new ListItem("Seleccionar", "0"));

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            string lcWhere = "";
            if (TxtNit.Text != "")
            {
                lcWhere = "nit like '" + TxtNit.Text.Trim() + "%'";

            }
            if (TxtNombre1.Text != "")
            {
                if (lcWhere != "")
                {
                    lcWhere = lcWhere + " and nombre1 LIKE '" + TxtNombre1.Text.Trim() + "%'";
                }
                else
                {
                    lcWhere = "nombre1 LIKE '" + TxtNombre1.Text.Trim() + "%'";
                }
            }

            if (TxtNombre2.Text != "")
            {
                if (lcWhere != "")
                {
                    lcWhere = lcWhere + " and nombre2 LIKE '" + TxtNombre2.Text.Trim() + "%'";
                }
                else
                {
                    lcWhere = "nombre2 LIKE '" + TxtNombre2.Text.Trim() + "%'";
                }
            }

            if (TxtApellido1.Text != "")
            {
                if (lcWhere != "")
                {
                    lcWhere = lcWhere + " and apellido1 LIKE '" + TxtApellido1.Text.Trim() + "%'";
                }
                else
                {
                    lcWhere = "apellido1 LIKE '" + TxtApellido1.Text.Trim() + "%'";
                }
            }

            if (TxtApellido2.Text != "")
            {
                if (lcWhere != "")
                {
                    lcWhere = lcWhere + " and apellido2 LIKE '" + TxtApellido2.Text.Trim() + "%'";
                }
                else
                {
                    lcWhere = "apellido2 LIKE '" + TxtApellido2.Text.Trim() + "%'";
                }
            }

            if (TxtDireccion.Text != "")
            {
                if (lcWhere != "")
                {
                    lcWhere = lcWhere + " and direccion LIKE '" + TxtDireccion.Text.Trim() + "%'";
                }
                else
                {
                    lcWhere = "direccion LIKE '" + TxtDireccion.Text.Trim() + "%'";
                }
            }


            if (Txttelefono.Text != "")
            {
                if (lcWhere != "")
                {
                    lcWhere = lcWhere + " and telefono LIKE '" + Txttelefono.Text.Trim() + "%'";
                }
                else
                {
                    lcWhere = "telefono LIKE '" + Txttelefono.Text.Trim() + "%'";
                }
            }
            if (txtsucursal.Text != "")
            {
                if (lcWhere != "")
                {
                    lcWhere = lcWhere + " and sucursal LIKE '" + txtsucursal.Text.Trim() + "%'";
                }
                else
                {
                    lcWhere = "sucursal LIKE '" + txtsucursal.Text.Trim() + "%'";
                }
            }

            if (TxtMail.Text != "")
            {
                if (lcWhere != "")
                {
                    lcWhere = lcWhere + " and email LIKE '" + TxtMail.Text.Trim() + "%'";
                }
                else
                {
                    lcWhere = "email LIKE '" + TxtMail.Text.Trim() + "%'";
                }
            }

            if (lcWhere != "")
            {
                lcWhere = lcWhere + " and idinstitucion =" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION.ToString();
            }
            else
            {
                lcWhere = "idinstitucion =" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION.ToString();
            }


            DataTable Tterceros = new DataTable();
            Tterceros.Clear();
            proce.consultacamposcondicion("terceros", "id,nit, verifica,nombre,direccion,telefono,email,nombre1,nombre2,apellido1,apellido2, nomdepto, nommuni,sucursal,sector", lcWhere + " order by nombre ASC limit 20", Tterceros);
            limpiar();
            GridView1.DataSource = Tterceros;
            GridView1.DataBind();


        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/docPendi.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            limpiar();
            FillFormularios();
            TxtNit.Enabled = true;
        }

        private void limpiar()
        {

            TxtNit.Text = "";
            TxtNombre1.Text = "";
            TxtNombre2.Text = "";
            TxtApellido1.Text = "";
            TxtApellido2.Text = "";
            txtsucursal.Text = "";
            TxtDireccion.Text = "";
            TxtMail.Text = "";
            Txttelefono.Text = "";
            ckprivado.Checked = false;
            ckpublico.Checked = false;
            Button1.Text = "Añadir";
            TxtNit.Focus();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sector = "";
            if (ckpublico.Checked == true)
            {
                sector = "publico";
            }
            else
            {
                if (ckprivado.Checked == true)
                {
                    sector = "privado";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('debe tener un tipo de cliente');", true);
                    return;
                }
            }
            if (Button1.Text == "Añadir")
            {

                // Almenos el nit y un campo nombre 
                if (TxtNit.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Falta el numero de documento');", true);
                    TxtNombre1.Focus();
                }

                if (TxtNombre1.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('debe tener al menos un nombre');", true);
                    TxtNombre1.Focus();
                }




                // Validamos si existe el nit
                DataTable tRegistro = new DataTable();
                proce.consultacamposcondicion("terceros", "*", "nit = '" + TxtNit.Text.Trim() + "' and idinstitucion = " + SessionDocumental.UsuarioInicioSession.IDINSTITUCION.ToString(), tRegistro);
                if (tRegistro.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('El Documento Ya existe.. Registro no guardado ');", true);
                    TxtNit.Focus();
                }
                else
                {
                    proce.insertaralgunos("terceros", "NIT,NOMBRE1,NOMBRE2,APELLIDO1,APELLIDO2,NOMBRE,DIRECCION,TELEFONO,EMAIL,IDINSTITUCION,TIPODOC, depto, municipio,nomdepto,nommuni,verifica,sucursal,sector,cantidadtom",
                        "'" + TxtNit.Text.Trim() + "','" + TxtNombre1.Text.Trim() + "','" + TxtNombre2.Text.Trim() + "','" + TxtApellido1.Text.Trim() +
                        "','" + TxtApellido2.Text.Trim() + "','" + TxtNombre1.Text.Trim() + " " + TxtNombre2.Text.Trim() + " " + TxtApellido1.Text.Trim() +
                        " " + TxtApellido2.Text.Trim() + "','" + TxtDireccion.Text.Trim() + "','" + Txttelefono.Text.Trim() + "','" + TxtMail.Text.Trim() + "'," + SessionDocumental.UsuarioInicioSession.IDINSTITUCION.ToString() +
                        ",'" + DDLTipoDoc.SelectedValue.ToString() + "', '" + ddlDepartamento.SelectedValue + "','" + ddlMunicipio.SelectedValue + "','" + ddlDepartamento.SelectedItem.Text + "','" + ddlMunicipio.SelectedItem.Text + "'," + ObtieneFormulaNit(TxtNit.Text.Trim()) + ",'" + txtsucursal.Text.Trim() + "','" + sector + "','0'");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Tercero creado con Exito');", true);
                    limpiar();
                }


            }
            else
            {

                int lnId = Convert.ToInt32(GridView1.SelectedDataKey[0].ToString());
                proce.editar("terceros", "tipodoc = '" + DDLTipoDoc.Text + "', sucursal='" + txtsucursal.Text.Trim() + "', nit= '" + TxtNit.Text.Trim() + "',nombre1='" + TxtNombre1.Text + "',nombre2='" + TxtNombre2.Text + "',apellido1='" + TxtApellido1.Text +
                    "',apellido2='" + TxtApellido2.Text + "', nombre = '" + TxtNombre1.Text.Trim() + " " + TxtNombre2.Text.Trim() +
                    " " + TxtApellido1.Text.Trim() + " " + TxtApellido2.Text.Trim() + "', verifica=" + ObtieneFormulaNit(TxtNit.Text.Trim()) + "  ,direccion= '" + TxtDireccion.Text.Trim() + "',email= '" + TxtMail.Text.Trim() + "' " + ", depto='" + ddlDepartamento.SelectedValue + "', municipio='" + ddlMunicipio.SelectedValue + "', nomdepto='" + ddlDepartamento.SelectedItem.Text + "', nommuni='" + ddlMunicipio.SelectedItem.Text + "', telefono='" + Txttelefono.Text + "', sector='" + sector + "'",
                    "id =" + lnId.ToString() + " and idinstitucion = " + SessionDocumental.UsuarioInicioSession.IDINSTITUCION);
                limpiar();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Tercero editado con Exito');", true);

                TxtNit.Enabled = true;
            }

            Button1.Text = "Añadir";
            FillFormularios();
        }

        private string ObtieneFormulaNit(string nit)
        {
            string result = "";

            nit = nit.PadLeft(15, '0');



            var calculo = ((Convert.ToInt32(nit.Substring(14, 1)) * 3 + Convert.ToInt32(nit.Substring(13, 1)) * 7 + Convert.ToInt32(nit.Substring(12, 1)) * 13 +
                           Convert.ToInt32(nit.Substring(11, 1)) * 17 + Convert.ToInt32(nit.Substring(10, 1)) * 19 + Convert.ToInt32(nit.Substring(9, 1)) * 23 +
                           Convert.ToInt32(nit.Substring(8, 1)) * 29 + Convert.ToInt32(nit.Substring(7, 1)) * 37 + Convert.ToInt32(nit.Substring(6, 1)) * 41 +
                           Convert.ToInt32(nit.Substring(5, 1)) * 43 + Convert.ToInt32(nit.Substring(4, 1)) * 47 + Convert.ToInt32(nit.Substring(3, 1)) * 53 +
                           Convert.ToInt32(nit.Substring(2, 1)) * 59 + Convert.ToInt32(nit.Substring(1, 1)) * 67 + Convert.ToInt32(nit.Substring(0, 1)) * 71) % 11);

            var vr = 0;
            switch (calculo)
            {
                case 0:
                    vr = 0;
                    break;
                case 1:
                    vr = 1;
                    break;
                default:
                    vr = 11 - calculo;
                    break;
            }


            return vr.ToString();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int lnId = Convert.ToInt32(GridView1.SelectedDataKey.Values[0]);
            DataTable tSel = new DataTable();
            proce.consultacamposcondicion("terceros", "*", "id=" + lnId.ToString(), tSel);
            if (tSel.Rows.Count > 0)
            {
                DDLTipoDoc.Text = string.IsNullOrEmpty(tSel.Rows[0]["tipodoc"].ToString()) ? "NIT" : tSel.Rows[0]["tipodoc"].ToString();
                TxtNit.Text = tSel.Rows[0]["nit"].ToString();
                TxtNombre1.Text = tSel.Rows[0]["nombre1"].ToString();
                TxtNombre2.Text = tSel.Rows[0]["nombre2"].ToString();
                TxtApellido1.Text = tSel.Rows[0]["apellido1"].ToString();
                TxtApellido2.Text = tSel.Rows[0]["apellido2"].ToString();
                TxtDireccion.Text = tSel.Rows[0]["direccion"].ToString();
                Txttelefono.Text = tSel.Rows[0]["telefono"].ToString();
                TxtMail.Text = tSel.Rows[0]["email"].ToString();
                txtsucursal.Text = tSel.Rows[0]["sucursal"].ToString();
                if (tSel.Rows[0]["sector"].ToString() == "publico")
                {
                    ckpublico.Checked = true;
                    ckprivado.Checked = false;
                }
                if (tSel.Rows[0]["sector"].ToString() == "privado")
                {
                    ckprivado.Checked = true;
                    ckpublico.Checked = false;
                }

                ddlDepartamento.SelectedValue = string.IsNullOrEmpty(tSel.Rows[0]["depto"].ToString()) ? "0" : tSel.Rows[0]["depto"].ToString();
                ddlMunicipio.SelectedValue = string.IsNullOrEmpty(tSel.Rows[0]["municipio"].ToString()) ? "0" : tSel.Rows[0]["municipio"].ToString();
                Button1.Text = "Editar";
                TxtNit.Enabled = false;
            }



        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        protected void TxtNit_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMunicipio.Items.Clear();
            var municipios = new DataTable();
            proce.consultacamposcondicion("municipios", " codigo,nombre ", " codigodep= " + ddlDepartamento.SelectedValue, municipios);
            ddlMunicipio.DataSource = municipios;
            ddlMunicipio.DataValueField = "codigo";
            ddlMunicipio.DataTextField = "nombre";
            ddlMunicipio.DataBind();
            ddlMunicipio.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var dataKey = GridView1.DataKeys[Convert.ToInt32(e.RowIndex)];
            if (dataKey != null)
            {
                var id = Convert.ToInt32(dataKey.Value);

                EliminaDetalle(id);
            }
            limpiar();
            FillFormularios();
        }
        private void EliminaDetalle(int id)
        {
            DataTable data = new DataTable();
            proce.consultacamposcondicion("terceros t join inventariocustodia i on t.nit=i.tercero", "nit", "t.id='" + id + "' and t.idinstitucion=" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION, data);
          
            if (data.Rows.Count < 1)
            {
                var sql = @"DELETE FROM 
                       terceros WHERE id=" + id + ";";
                proce.EjecutaSql(sql);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('El tercero tiene inventario y no se puede eliminar');", true);

            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                var db = (LinkButton)e.Row.Cells[11].Controls[0];

                db.OnClientClick = "return confirm('Esta seguro que desea eliminar ?');";
            }
        }

        protected void ckprivado_CheckedChanged(object sender, EventArgs e)
        {
            if (ckprivado.Checked == true)
            {
                ckpublico.Checked = false;
            }
        }

        protected void ckpublico_CheckedChanged(object sender, EventArgs e)
        {
            if (ckpublico.Checked == true)
            {
                ckprivado.Checked = false;
            }
        }


    }
}