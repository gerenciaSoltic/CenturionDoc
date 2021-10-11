using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using gestion_documental;
using gestion_documental.Utils;

namespace gestion_documental.reporting
{
    public partial class reportescustodia : System.Web.UI.Page
    {
        Class1 proce = new Class1();
        DataTable tabelpanel = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataAccessLayer.inventarioconsul.cliente = "0";
            DataAccessLayer.inventarioconsul.empresa = "0";
        }
        protected void gtngenerar_Click(object sender, EventArgs e)
        {
            if (ckcliente.Checked == true)
            {
                DataAccessLayer.inventarioconsul.cliente = "1";

            }
            else
            {
                DataAccessLayer.inventarioconsul.cliente = "0";
            }
            if (ckempresa.Checked == true)
            {
                DataAccessLayer.inventarioconsul.empresa = "1";
            }
            else
            {
                DataAccessLayer.inventarioconsul.empresa = "0";
            }
            DataAccessLayer.inventarioconsul.nit = txtnittercero.Text;
            ReportViewer1.LocalReport.Refresh();
        }

        protected void btnsalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~//inventarioCustodia.aspx");
        }

        protected void ckempresa_CheckedChanged(object sender, EventArgs e)
        {
            if (ckempresa.Checked == true)
            {
                ckcliente.Checked = false;
            }
            else
            {
                ckcliente.Checked = true;
            }
        }

        protected void ckcliente_CheckedChanged(object sender, EventArgs e)
        {
            if (ckcliente.Checked == true)
            {
                ckempresa.Checked = false;
            }
            else
            {
                ckempresa.Checked = true;
            }
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

        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {
            Session["panel"] = 2;
            Session["nombre"] = "terceros";
            Session["campos"] = "id as Referencia,nit as codigo,nombre as Nombre,sucursal as Sucursal,verifica as Verifica";
            Session["id"] = "nit";
            paneltotal();
            HiddenField1_ModalPopupExtender.Show();
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
    }
}