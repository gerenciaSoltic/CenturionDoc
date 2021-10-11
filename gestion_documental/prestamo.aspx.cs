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
    public partial class prestamo : System.Web.UI.Page
    {
        Class1 proce = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void buscartipo(ref string tipo, ref string tipoarticulo, ref string numero, ref string empresa, ref string condicion,string codigo)
        {
            string[] separators = { ",", ".", "¡", "?", ";", ":", "+" };
            string value = codigo;
            string[] words = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            if (words.Count()>1)
            {
              
                numero = words[1];
                empresa = words[0];
                tipo = "CAJA";
                tipoarticulo = "CAJA";
                condicion = " and prestamo is null";

            }
            else
            {
                numero = codigo.Substring(0, 6);
                empresa = codigo.Substring(6, Convert.ToInt32(Convert.ToInt32(codigo.ToString().Length) - 6));
                tipo = "NUMEROORDEN";
                tipoarticulo = "UNIDAD";
                condicion = " and color !='.'";
            }
        }
        protected void btnprestamo_Click(object sender, EventArgs e)
        {

            if (txtrecibe.Text == "" || txtcargopersona.Text == "" || txtnumero.Text=="")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Todos los campos son obligatorios');", true);
                return;
            }
            string estanprestados = "";
            string tipo = "";
            string tipoarticulo = "";
            string numero = "";
            string empresa = "";
            string condicion = "";
            string[] separators = { "\n" };
            string value = txtnumero.Text;
          
            string[] words = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int consecutivo = 0;
            DataTable dataconsecutivo = new DataTable();

            proce.consultacamposcondicion("consecutivos", "*", "idinstitucion='" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + "' and tipo='PRE' ", dataconsecutivo);
            if (dataconsecutivo.Rows.Count < 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No se encontro el consecutivo PRE');", true);
                return;
            }
            for (int i = 0; i < words.Count(); i++)
            {



                buscartipo(ref tipo, ref tipoarticulo, ref numero, ref empresa, ref condicion, words[i]);

                DataTable data = new DataTable();
                proce.consultacamposcondicion("inventariocustodia i join terceros t on i.tercero=t.nit", "i.id,i.prestamo,i.idoficinaproductora,i.tercero", "t.sucursal='" + empresa + "' and i." + tipo + "='" + numero + "' and i.prestamo is null group by i.idoficinaproductora", data);


                if (data.Rows.Count < 1)
                {
                    estanprestados = estanprestados +" ; "+ words[i];
                }
                else
                {
                   
                   int id= proce.insertaralgunos("prestamo", "empresa,tipo,numero,recibe,cargo,fechaini,detalle,codigo", "'" + empresa + "','" + tipoarticulo + "','" + numero + "','" + txtrecibe.Text + "','" + txtcargopersona.Text + "','" + DateTime.Now.ToString("yyy/MM/dd") + "','" + txtdetalle.Text + "','" + dataconsecutivo.Rows[0]["consecuti"].ToString() + "'");

                    
                    proce.editar("inventariocustodia", "prestamo='" + id + "'", "idoficinaproductora='" + data.Rows[0]["idoficinaproductora"].ToString() + "' and id>0 and tercero='" + data.Rows[0]["tercero"].ToString() + "' and " + tipo + "='" + numero + "'" + condicion);
                }
            }

            consecutivo = (Convert.ToInt32(dataconsecutivo.Rows[0]["consecuti"].ToString()) + 1);
            proce.editar("consecutivos", "consecuti='" + consecutivo+ "'", "tipo='PRE' and id>0");
            if (estanprestados.ToString().Trim().Length > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No todos los prestamos se ralizaron con exito.... No se realizaron los siguientes" + estanprestados + "');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Prestamo realizado con exito');", true);
            }
            DataAccessLayer.prestamoconsul.numeroprestamo = dataconsecutivo.Rows[0]["consecuti"].ToString();
            Response.Redirect("~/reporting/prestamofinal.aspx", "_blank", " menubar=0,scrollbars=1,width=780,height=900,top=10");
            limpiar();
           
        }
        public void limpiar()
        {
            txtdetalle.Text = "";
            txtrecibe.Text = "";
            txtcargopersona.Text = "";
            txtnumero.Text = "";
        }
        protected void btnentrega_Click(object sender, EventArgs e)
        {
            if (txtrecibe.Text == "" || txtcargopersona.Text == "" || txtnumero.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Todos los campos son obligatorios');", true);
                return;
            }
            List<string> prestados=new List<string>();
            string noestanprestados = "";
            string tipo = "";
            string tipoarticulo = "";
            string numero = "";
            string empresa = "";
            string condicion = "";
            string[] separators = { "\n" };
            string value = txtnumero.Text;
          
            string[] words = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
           

            string codigoprestamo = "";
            for (int i = 0; i < words.Count(); i++)
            {
                buscartipo(ref tipo, ref tipoarticulo, ref numero, ref empresa, ref condicion, words[i]);
                DataTable dataprestamo = new DataTable();
                proce.consultacamposcondicion("prestamo", "id,codigo", "empresa='" + empresa + "' and tipo='" + tipoarticulo + "' and numero='" + numero + "' and fechafin is null", dataprestamo);
                if (dataprestamo.Rows.Count < 1)
                {
                    noestanprestados = noestanprestados + " ; " + words[i];
                }
                else
                {
                    DataTable data = new DataTable();
                    proce.consultacamposcondicion("inventariocustodia i join terceros t on i.tercero=t.nit", "i.id,i.prestamo,i.idoficinaproductora,i.tercero", "t.sucursal='" + empresa + "' and i." + tipo + "='" + numero + "' and i.prestamo is not null group by i.idoficinaproductora", data);
                    if (data.Rows.Count < 1)
                    {

                    }
                    else
                    {
                        proce.editar("prestamo", "fechafin='" + DateTime.Now.ToString("yyy/MM/dd") + "',recibefinal='" + txtrecibe.Text + "',cargofinal='" + txtcargopersona.Text + "'", "id='" + dataprestamo.Rows[0]["id"].ToString() + "'");
                        proce.editar("inventariocustodia", "prestamo = null", "prestamo='" + dataprestamo.Rows[0]["id"].ToString() + "' and id>0");
                    }
                }
            }
            if (noestanprestados.ToString().Trim().Length > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No todos los prestamos se ralizaron con exito.... No se realizaron los siguientes" + noestanprestados + "');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Prestamo realizado con exito');", true);
            }
            limpiar();
           

        }

        protected void txtnumero_TextChanged(object sender, EventArgs e)
        {

        }

    }
}