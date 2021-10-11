using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using gestion_documental;
using GESTIONDOCUMENTAL;
using gestion_documental.codigo;
using gestion_documental.BusinessObjects;
using gestion_documental.DataAccessLayer;
using gestion_documental.Utils;
using System.Data;

namespace gestion_documental
{
    public partial class listacorsal : System.Web.UI.Page
    {
        Class1 proce = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            EmiRecep receptor = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
            string lcCondicion = "";
            llenaGrid(lcCondicion,receptor.ID);
        }


        protected void llenaGrid(string condicion,int idreceptor)
        {
            string lcTablas = "correosaliente c,emirecep e";
            string lcCampos = "c.id,c.fecha,e.descripcion as Emisor,c.asunto,c.texto,c.Radicado";
            string lccondicion= "c.idemisor = e.id and c.idreceptor= "+idreceptor.ToString();

            DataTable DatSaliente = new DataTable();
            proce.consultacamposcondicion(lcTablas, lcCampos, lccondicion + condicion, DatSaliente);
            GridView1.DataSource = DatSaliente;
            GridView1.DataBind();



        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = GridView1.SelectedDataKey.Values[1].ToString();

           DataTable DatAjunto = new DataTable();
            proce.consultacamposcondicion("Adjunsal","archivo","idcorreo="+Convert.ToInt32( GridView1.SelectedDataKey.Values[0]).ToString(),DatAjunto);

            GridView2.DataSource = DatAjunto;
            GridView2.DataBind();


 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string lcCondicion = "";
            if (TextBox1.Text == "")
            {
                 lcCondicion = "";
            }
            else
            {
                 lcCondicion = " and (e.descripcion like '%" + TextBox1.Text + "%' OR e.nit like '%" + TextBox1.Text + "%' OR c.asunto like '%" + TextBox1.Text + "%'  OR c.texto like '%" + TextBox1.Text + "%')";  

            }
            EmiRecep receptor = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
            llenaGrid(lcCondicion,receptor.ID);
            
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string lcCondicion = "";
            GridView1.PageIndex = e.NewPageIndex;
            if (TextBox1.Text == "")
            {
                lcCondicion = "";
            }
            else
            {
                lcCondicion = " and (e.descripcion like '%" + TextBox1.Text + "%' OR e.nit like '%" + TextBox1.Text + "%' OR c.asunto like '%" + TextBox1.Text + "%'  OR c.texto like '%" + TextBox1.Text + "%')";

            }
            EmiRecep receptor = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
            llenaGrid(lcCondicion, receptor.ID);


        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmiRecep receptor = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
            Response.Redirect("~/" +receptor.conficor.CAMINODESCARGA + "/" + GridView2.SelectedDataKey.Value.ToString(), "_blank", "menubar=0,scrollbars=1,width=780,height=900,top=10");
        }

        
    }
}