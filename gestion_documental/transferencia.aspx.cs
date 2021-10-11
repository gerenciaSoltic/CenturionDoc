using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using gestion_documental;
using gestion_documental.Utils;
using gestion_documental.DataAccessLayer;
using gestion_documental.BusinessObjects;
using System.Globalization;

namespace gestion_documental
{
    public partial class transferencia : System.Web.UI.Page
    {
        Class1 proce = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable DatProyecto = new DataTable();
                proce.consultacamposcondicion("proyectos", "*", "idinstitucion = 1", DatProyecto);

                ddlProyecto.DataSource = DatProyecto;
                ddlProyecto.DataTextField = "descripcion";
                ddlProyecto.DataValueField = "idproyectos";
                ddlProyecto.DataBind();

                DataTable transferencias = creatabla();

                Session.Add("transferencias", transferencias);

            }

        }



        protected DataTable creatabla()
        {
            DataTable DatTrans = new DataTable();

            DataColumn proyecto = new DataColumn("proyecto");
            proyecto.DataType = System.Type.GetType("System.String");
            DatTrans.Columns.Add(proyecto);

            DataColumn año = new DataColumn("año");
            año.DataType = System.Type.GetType("System.String");
            DatTrans.Columns.Add(año);

            DataColumn cajasdesde = new DataColumn("cajasdesde");
            cajasdesde.DataType = System.Type.GetType("System.String");
            DatTrans.Columns.Add(cajasdesde);

            DataColumn cajashasta = new DataColumn("cajashasta");
            cajashasta.DataType = System.Type.GetType("System.String");
            DatTrans.Columns.Add(cajashasta);

            DataColumn cantidadcajas = new DataColumn("cantidadcajas");
            cantidadcajas.DataType = System.Type.GetType("System.Int32"); 
            DatTrans.Columns.Add(cantidadcajas);

            DataColumn cantidadcarpetas = new DataColumn("cantidadcarpetas");
            cantidadcarpetas.DataType = System.Type.GetType("System.Int32");
            DatTrans.Columns.Add(cantidadcarpetas);

            DataColumn cantidadcontratos = new DataColumn("cantidadcontratos");
            cantidadcontratos.DataType = System.Type.GetType("System.Int32");
            DatTrans.Columns.Add(cantidadcontratos);

            DataColumn totalfolios = new DataColumn("totalfolios");
            totalfolios.DataType = System.Type.GetType("System.Int32");
            DatTrans.Columns.Add(totalfolios);

            DataColumn idproyecto = new DataColumn("idproyecto");
            idproyecto.DataType = System.Type.GetType("System.Int32");
            DatTrans.Columns.Add(idproyecto);

            DataColumn fdesde = new DataColumn("fdesde");
            fdesde.DataType = System.Type.GetType("System.String");
            DatTrans.Columns.Add(fdesde);

            DataColumn fhasta = new DataColumn("fhasta");
            fhasta.DataType = System.Type.GetType("System.String");
            DatTrans.Columns.Add(fhasta);


            return DatTrans;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            // Calculamos la informacion

            DataTable DatProceso = new DataTable();

            proce.consultacamposcondicion("inventariocontratacion", "COUNT(DISTINCT caja) AS cantidadcajas,SUM(numerofolios) as totalfolios,MIN(Fechainicio) as  fdesde ,MAX(fechafinal) as fhasta,COUNT(*) AS cantidadcarpetas,COUNT(DISTINCT numerocontrato) as cantidadcontratos", "caja*1 BETWEEN '" + txtCajaDesde.Text.Trim() + "' and '" + txtCajaHasta.Text + "' and año = '" + txtAño.Text + "' and idproyecto =" + ddlProyecto.SelectedValue.ToString() + " AND fechaentrega IS NULL GROUP BY idproyecto,año", DatProceso);

            if (DatProceso.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No existen registros pendientes por entregar de esta selección');", true);
                return;
            }
            
            DataTable transferencias = Session["transferencias"] as DataTable;
           
            DataRow Fila = transferencias.NewRow();
            Fila["proyecto"] = ddlProyecto.SelectedItem.Text;
            Fila["año"] = txtAño.Text;
            Fila["cajasdesde"] = txtCajaDesde.Text;
            Fila["cajashasta"] = txtCajaHasta.Text;
            Fila["cantidadcajas"] = Convert.ToInt32(DatProceso.Rows[0]["cantidadcajas"]);
            Fila["cantidadcarpetas"] = Convert.ToInt32(DatProceso.Rows[0]["cantidadcarpetas"]);
            Fila["cantidadcontratos"] = Convert.ToInt32(DatProceso.Rows[0]["cantidadcontratos"]);
            Fila["totalfolios"] = Convert.ToInt32(DatProceso.Rows[0]["totalfolios"]);
            Fila["idproyecto"] = Convert.ToInt32(ddlProyecto.SelectedValue);
            Fila["fdesde"] = DatProceso.Rows[0]["fdesde"].ToString();
            Fila["fhasta"] = DatProceso.Rows[0]["fhasta"].ToString();
            transferencias.Rows.Add(Fila);

            Session["transferencias"] = transferencias;

            GridView1.DataSource = transferencias;
            GridView1.DataBind();

            // sumamos

            sumartotales();
        }


        protected void sumartotales()
        {
            DataTable transferencias = Session["transferencias"] as DataTable;

            int cantidadcajas = 0;
            int cantidadcarpetas = 0;
            int cantidadcontratos = 0;
            int totalfolios = 0;
            string lcFDesde = transferencias.Rows[0]["fdesde"].ToString();
            string lcFHasta = transferencias.Rows[0]["fhasta"].ToString(); ;

            foreach (DataRow fila in transferencias.Rows)
            {
                cantidadcajas += Convert.ToInt32(fila["cantidadcajas"]);
                cantidadcarpetas += Convert.ToInt32(fila["cantidadcarpetas"]);
                cantidadcontratos += Convert.ToInt32(fila["cantidadcontratos"]);
                totalfolios += Convert.ToInt32(fila["totalfolios"]);
                if (Convert.ToDateTime(fila["fdesde"].ToString()) <= Convert.ToDateTime(lcFDesde))
                {
                    lcFDesde = fila["fdesde"].ToString();
                }

                if (Convert.ToDateTime(fila["fhasta"].ToString()) <= Convert.ToDateTime(lcFHasta))
                {
                    lcFHasta = fila["fhasta"].ToString();
                }

            }

            txtCatidadCajas.Text = cantidadcajas.ToString();
            txtCantidadCarpetas.Text = cantidadcarpetas.ToString();
            txtCantidadContratos.Text = cantidadcontratos.ToString();
            txtTotalFolios.Text = totalfolios.ToString();
            txtFDesde.Text = lcFDesde;
            txtFHasta.Text = lcFHasta;



        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable transferencias = Session["transferencias"] as DataTable;
            if (GridView1.SelectedIndex >= 0)
            {
                

                transferencias.Rows[GridView1.SelectedIndex].Delete();
                transferencias.AcceptChanges();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe seleccionar un registro antes..');", true);
                return;
            }

            Session["transferencias"] = transferencias;
            GridView1.DataSource = transferencias;
            GridView1.DataBind();

            sumartotales();



        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No hay registros para entregar..');", true);
                return;
            }

            if (txtFechaEntrega.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Falta Fecha de Entrega..');", true);
                return;
            }

            DataTable transferencias = Session["transferencias"] as DataTable;

            foreach (DataRow fila in transferencias.Rows)
            {
                proce.insertaralgunos("transferencias", "fechatra,año,cajasdesde,cajashasta,cantidadcajas,cantidadcarpetas,cantidadcontratos,totalfolios,fdesde,fhasta,idproyecto,idinstitucion", "'" + txtFechaEntrega.Text + "','" +fila["año"].ToString() + "','" + fila["cajasdesde"].ToString() + "','" + fila["cajashasta"].ToString() + "'," + fila["cantidadcajas"].ToString() + "," +fila["cantidadcarpetas"].ToString()+","+ fila["cantidadcontratos"].ToString() + "," + fila["totalfolios"] + ",'" + fila["fdesde"].ToString() + "','" + fila["fhasta"].ToString() + "'," + ddlProyecto.SelectedValue.ToString()+","+SessionDocumental.UsuarioInicioSession.IDINSTITUCION.ToString());
                proce.editar("inventariocontratacion", "fechaentrega ='" + txtFechaEntrega.Text + "', numerotransferencia = '"+txtNumeroEntrega.Text+"'", "idproyecto = " + ddlProyecto.SelectedValue.ToString() + " and año = '" + fila["año"].ToString() + "' and caja*1 between '" + fila["cajasdesde"].ToString() + "' and '" + fila["cajashasta"].ToString() + "' and idinstitucion = "+SessionDocumental.UsuarioInicioSession.IDINSTITUCION.ToString());

            }

            transferencias.Clear();
            GridView1.DataSource = transferencias;
            GridView1.DataBind();
            Session["transferencias"] = transferencias;
           
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (txtFechaEntrega.Text == "")
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Falta Fecha de Entrega..');", true);
                return;
            }

            RInventarioContratacion.fechaentrega = Convert.ToDateTime(txtFechaEntrega.Text);
            RInventarioContratacion.idproyecto = Convert.ToInt32(ddlProyecto.SelectedValue);
            RInventarioContratacion.numerotransferencia = txtNumeroEntrega.Text;

            Response.Redirect("~//reporting/RinventarioContratacion.aspx", "_blank", " menubar=0,scrollbars=1,width=780,height=900,top=10");

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            DataTable DatProceso = new DataTable();

            proce.consultacamposcondicion("inventariocontratacion", "año,COUNT(DISTINCT caja) AS cantidadcajas,SUM(numerofolios) as totalfolios,MIN(Fechainicio) as  fdesde ,MAX(fechafinal) as fhasta,COUNT(*) AS cantidadcarpetas,COUNT(DISTINCT numerocontrato) as cantidadcontratos", "idproyecto =" + ddlProyecto.SelectedValue.ToString() + " AND fechaentrega = '"+txtFechaEntrega.Text+"' and numerotransferencia ='"+txtNumeroEntrega.Text+"'  GROUP BY fechaentrega,numerotransferencia,año", DatProceso);

            if (DatProceso.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No existen registros pendientes por entregar de esta selección');", true);
                return;
            }

            int cantidadcajas = 0;
            int cantidadcarpetas = 0;
            int cantidadcontratos = 0;
            int totalfolios = 0;
            string lcFDesde = DatProceso.Rows[0]["fdesde"].ToString();
            string lcFHasta = DatProceso.Rows[0]["fhasta"].ToString(); ;      
            foreach (DataRow fila in DatProceso.Rows)
            {
                cantidadcajas += Convert.ToInt32(fila["cantidadcajas"]);
                cantidadcarpetas += Convert.ToInt32(fila["cantidadcarpetas"]);
                cantidadcontratos += Convert.ToInt32(fila["cantidadcontratos"]);
                totalfolios += Convert.ToInt32(fila["totalfolios"]);
                if (Convert.ToDateTime(fila["fdesde"].ToString()) <= Convert.ToDateTime(lcFDesde))
                {
                    lcFDesde = fila["fdesde"].ToString();
                }

                if (Convert.ToDateTime(fila["fhasta"].ToString()) <= Convert.ToDateTime(lcFHasta))
                {
                    lcFHasta = fila["fhasta"].ToString();
                }

            }

            txtCatidadCajas.Text = cantidadcajas.ToString();
            txtCantidadCarpetas.Text = cantidadcarpetas.ToString();
            txtCantidadContratos.Text = cantidadcontratos.ToString();
            txtTotalFolios.Text = totalfolios.ToString();
            txtFDesde.Text = lcFDesde;
            txtFHasta.Text = lcFHasta;


        }
    }
}