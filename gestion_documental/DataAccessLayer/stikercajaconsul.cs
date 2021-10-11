using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestion_documental.Utils;
using gestion_documental.BusinessObjects;
using MySql.Data.MySqlClient;
using System.Data;
///
namespace gestion_documental.DataAccessLayer
{
    public class stikercajaconsul
    {
        Class1 proce = new Class1();
        ConnectionClass conectar = new ConnectionClass();
        #region select
        
       public static string idsticker;
       public static string tabla;
       public static string oficina;
       public static string campo;
       public static string tercero;

        public List<stikerCaja> obtenerstikercondicion()
        {
           


            conectar.Connection.Close();
            conectar.conectar();

            conectar.Connection.Open();
            List<stikerCaja> _stiker = new List<stikerCaja>();
            MySqlCommand _comando = new MySqlCommand("SELECT i.numeroorden,i.caja,i.codigo,i.nombreserie,i.fechainicio,i.fechafinal,i.volumen,i.numerofolios,i."+campo+", ins.imagen,o.nombre,p.imagen,en.nombre,i.cajacliente from "+tabla+"  i join institucion ins on i.idinstitucion=ins.idinstitucion join oficinaproductora o on i.idoficinaproductora=o.id join unidadadministrativa un on o.idunidadadministrativa=un.id join entidadproductora en on un.identidadproductora=en.id join proyectos p on en.idproyecto=p.idproyectos where i.idinstitucion='" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + "' and i.idoficinaproductora='"+oficina+"' and i.id in ("+idsticker+")", conectar.Connection);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                stikerCaja _stikercaja = new stikerCaja();
                _stikercaja.imagenempresa = Convert.ToString(_reader.GetString(10));
                _stikercaja.imagenproyecto = Convert.ToString(_reader.GetString(12));
                _stikercaja.proyecto = Convert.ToString(_reader.GetString(13));
                _stikercaja.oficina = Convert.ToString(_reader.GetString(11));
                _stikercaja.serie = Convert.ToString(_reader.GetString(2)) + "  " + Convert.ToString(_reader.GetString(3));
                _stikercaja.fechaini = Convert.ToString(_reader.GetString(4));
                _stikercaja.fechafin = Convert.ToString(_reader.GetString(5));
                _stikercaja.observacion = Convert.ToString(_reader.GetString(8)) +" "+Convert.ToString(_reader.GetString(9));
                _stikercaja.caja = Convert.ToString(_reader.GetString(14));
                _stikercaja.orden = Convert.ToString(_reader.GetString(0));
                _stikercaja.volumen = Convert.ToString(_reader.GetString(6));
                _stikercaja.folios = Convert.ToString(_reader.GetString(7));
                _stikercaja.numerodeidentificacion=Convert.ToString(_reader.GetString(9));



                _stiker.Add(_stikercaja);
            }
            conectar.Connection.Close();
            return _stiker;
        }

        public List<stikerCaja> obtenersticketcustodia()
        {

            DataTable data = new DataTable();
            proce.consultacamposcondicion("terceros", "nombre1,sucursal", "nit='" + tercero + "'", data);
            List<stikerCaja> _caja = new List<stikerCaja>();
            DataTable datastickert = new DataTable();
            proce.consultacamposcondicion("inventariocustodia", "*", "idinstitucion='" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + "' and idoficinaproductora='" + oficina + "' and id in (" + idsticker + ") and tercero='" + tercero + "'", datastickert);
            for (int i = 0;i< datastickert.Rows.Count; i++)
            {
                DataTable datatomo = new DataTable();
                proce.consultacamposcondicion("inventariocustodia", "max(numeroorden) as maximo,min(numeroorden) as menor", "caja='" + datastickert.Rows[i]["cajacliente"].ToString() + "' and idinstitucion='" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + "' and idoficinaproductora='" + oficina + "'  and tercero='" + tercero + "' and color!='.'", datatomo);
                stikerCaja _ca = new stikerCaja();
                _ca.caja = datastickert.Rows[i]["cajacliente"].ToString();
                _ca.nombretercero = data.Rows[0]["nombre1"].ToString();
                _ca.volumen = data.Rows[0]["sucursal"].ToString();
                _ca.folios =Convert.ToString(Convert.ToInt32(datastickert.Rows[i]["numeroorden"].ToString()));
                _ca.numerodeidentificacion = tercero;
              //  _ca.serie = datastickert.Rows[i]["nombreserie"].ToString();
                _ca.fechaini = datastickert.Rows[i]["fechainicio"].ToString();
                _ca.fechafin = datastickert.Rows[i]["fechafinal"].ToString();
                if (datastickert.Rows[i]["observacion"].ToString().Length > 45)
                {
                    _ca.observacion = datastickert.Rows[i]["observacion"].ToString().Substring(0,45);
                }
                else
                {
                    _ca.observacion = datastickert.Rows[i]["observacion"].ToString();
                }
                //
                if (datastickert.Rows[i]["nombreserie"].ToString().Length > 30)
                {
                    _ca.serie = datastickert.Rows[i]["nombreserie"].ToString().Substring(0, 30)+" ..";
                }
                else
                {
                    _ca.serie = datastickert.Rows[i]["nombreserie"].ToString();
                }
                //
              
                _ca.orden = datatomo.Rows[0]["menor"].ToString() + "-" + datatomo.Rows[0]["maximo"].ToString();
                _caja.Add(_ca);
            }
            return _caja;
        }
        #endregion
    }
}