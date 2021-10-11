using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestion_documental.Utils;
using System.Data;
using gestion_documental.BusinessObjects;

namespace gestion_documental.DataAccessLayer
{
    public class inventarioconsul
    {
        Class1 proce = new Class1();
    
        public static DataTable datafinal;
        public static string nit;
        public static string cliente;
        public static string empresa;
        

        public List<inventario> obtenerestados()
        {

            List<inventario> _inventario = new List<inventario>();
            for (int i = 1; i < datafinal.Rows.Count; i++)
            {
                if (datafinal.Rows[i]["caja"] != null && datafinal.Rows[i]["caja"].ToString() != "")
                {
                    if (i == 3838)
                    {
                        string caja = datafinal.Rows[i]["caja"].ToString();
                    }
                   

                        inventario _inv = new inventario();
                        _inv.caja = Convert.ToInt32(datafinal.Rows[i]["caja"].ToString());
                        _inv.orden = Convert.ToString(datafinal.Rows[i]["numeroorden"].ToString());
                        _inv.codigo = Convert.ToString(datafinal.Rows[i]["codigo"].ToString());
                        _inv.nombre = Convert.ToString(datafinal.Rows[i]["nombreserie"].ToString());
                        _inv.fechaini = Convert.ToString(datafinal.Rows[i]["fechainicio"].ToString());
                        _inv.fechafinal = Convert.ToString(datafinal.Rows[i]["fechafinal"].ToString());
                        _inv.ucaja = Convert.ToString(datafinal.Rows[i]["soporte"].ToString());
                        _inv.ucarpeta = Convert.ToString(datafinal.Rows[i]["objeto"].ToString());
                        _inv.utom = Convert.ToString(datafinal.Rows[i]["unidadtom"].ToString());
                        _inv.uotros = Convert.ToString(datafinal.Rows[i]["unidadotros"].ToString());
                        _inv.folios = Convert.ToString(datafinal.Rows[i]["numerofolios"].ToString());
                        _inv.volumen = Convert.ToString(datafinal.Rows[i]["volumen"].ToString());
                        _inv.expediente = Convert.ToString(datafinal.Rows[i]["expedientelaboral"].ToString());
                        _inv.cedula = Convert.ToString(datafinal.Rows[i]["cedula"].ToString());

                        _inventario.Add(_inv);
                    }

            }
            return _inventario;
        }

        public List<inventario> obternerinventariocustodia()
        {
            
            DataTable datacantidad = new DataTable();
            DataTable data=new DataTable();
            DataTable datamin = new DataTable();
            string condicion="";
            if (nit != null)
            {
                if (nit.ToString().Trim().Length > 0)
                {
                    condicion = " and tercero='" + nit + "'";
                   
                }
            }

            proce.consultacamposcondicion("inventariocustodia i join terceros t on i.tercero=t.nit", "i.*,upper(t.nombre) as nombrecliente", "i.id>0 and i.color!='.' " + condicion, data);
            proce.consultacamposcondicion("inventariocustodia", "max(CONVERT(caja,UNSIGNED INTEGER)) as max,min(CONVERT(caja,UNSIGNED INTEGER)) as min", "id>0" + condicion, datamin);
            proce.consultacamposcondicion("inventariocustodia", "distinct caja,tercero,cajacliente", "id>0 " + condicion, datacantidad);

            List<inventario> _inventario = new List<inventario>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (data.Rows[i]["caja"] != null && data.Rows[i]["caja"].ToString() != "")
                {
                     inventario _inv = new inventario();
                    _inv.caja = Convert.ToInt32(data.Rows[i]["caja"].ToString());
                    _inv.cajacliente = Convert.ToInt32(data.Rows[i]["cajacliente"].ToString());
                    _inv.orden = Convert.ToString(data.Rows[i]["numeroorden"].ToString());
                    _inv.nombre = Convert.ToString(data.Rows[i]["nombreserie"].ToString());
                    _inv.fechaini = Convert.ToString(data.Rows[i]["fechainicio"].ToString());
                    _inv.fechafinal = Convert.ToString(data.Rows[i]["fechafinal"].ToString());
                    if (data.Rows[i]["unidadconservacion"].ToString() == "carpeta")
                    {
                        _inv.ucarpeta = "X";
                    }

                    if (data.Rows[i]["unidadconservacion"].ToString() == "tom")
                    {
                        _inv.utom = "X";
                    }

                    if (data.Rows[i]["unidadconservacion"].ToString() == "otros")
                    {
                        _inv.uotros ="X";
                    }
                    _inv.soporte = Convert.ToString(data.Rows[i]["soporte"].ToString());
                    _inv.volumen = Convert.ToString(data.Rows[i]["volumen"].ToString());
                    _inv.observacion = Convert.ToString(data.Rows[i]["observacion"].ToString());
                    _inv.refcaja = Convert.ToString(data.Rows[i]["refcaja"].ToString());
                    _inv.cantidadcajas = Convert.ToString(datacantidad.Rows.Count);
                    _inv.cajaini = Convert.ToString(datamin.Rows[0]["min"].ToString());
                    _inv.cajafin = Convert.ToString(datamin.Rows[0]["max"].ToString());
                    _inv.cantidadtercero = data.Rows[i]["tercero"].ToString();
                    _inv.expediente = data.Rows[i]["color"].ToString();
                    _inv.informe = empresa;
                    _inv.cliente = cliente;
                    _inv.nombrecliente = data.Rows[i]["nombrecliente"].ToString();
                    _inventario.Add(_inv);
                }


            }
            return _inventario;
        }
    }
}