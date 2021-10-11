using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestion_documental.Utils;
using gestion_documental.BusinessObjects;
using System.Data;
using System.Reflection;


namespace gestion_documental.DataAccessLayer
{
    public class RInventarioContratacion
    {
        Class1 proce = new Class1();
        
        #region selec

        public static DateTime fechaentrega;
        public static Int32 idproyecto;
        public static string numerotransferencia;
      
        

        public List<RBInventarioContratacion> obtenerInventarioEntrega()
        {
            List<RBInventarioContratacion> ListHoja = new List<RBInventarioContratacion>();
          DataTable Dathoja = new DataTable();
          proce.consultacamposcondicion("inventariocontratacion", "oficina,fechaentrega,caja,numeroorden,codigo,CONCAT(trim(nombreserie),'-',TRIM(subserie)) as serie,fechainicio,fechafinal,numerofolios,soporte,volumen,CONCAT(subserie,':',TRIM(numerocontrato),'-',trim(nombrecontratista)) as observaciones,numerotransferencia","fechaentrega = '"+fechaentrega.Year.ToString()+"-"+fechaentrega.Month.ToString()+"-"+fechaentrega.Day.ToString() +"' AND  idproyecto= "+idproyecto.ToString()+" and idinstitucion =" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION.ToString()+" and numerotransferencia = '"+numerotransferencia+"' ORDER BY año,caja*1", Dathoja);


          for (int i = 0; i < Dathoja.Rows.Count; i++)
          {
              RBInventarioContratacion Hoja = new RBInventarioContratacion();
              Hoja.caja = Dathoja.Rows[i]["caja"].ToString();
              Hoja.codigo = Dathoja.Rows[i]["codigo"].ToString();
              Hoja.fecfinal = Dathoja.Rows[i]["fechafinal"].ToString();
              Hoja.fechaentrega = Convert.ToDateTime(Dathoja.Rows[i]["fechaentrega"].ToString());
              Hoja.fecinicial = Dathoja.Rows[i]["fechainicio"].ToString();
              Hoja.folios = Convert.ToInt32(Dathoja.Rows[i]["numerofolios"]);
              Hoja.numeroorden = Convert.ToInt32(Dathoja.Rows[i]["numeroorden"]);
              Hoja.observaciones = Dathoja.Rows[i]["observaciones"].ToString();
              Hoja.oficinaproductora = Dathoja.Rows[i]["oficina"].ToString();
              Hoja.serie = Dathoja.Rows[i]["serie"].ToString();
              Hoja.volumen = Dathoja.Rows[i]["volumen"].ToString();
              Hoja.numeroentrega = Dathoja.Rows[i]["numerotransferencia"].ToString();
              
             
              ListHoja.Add(Hoja);
          }

        
     

            return ListHoja;
        }
        #endregion

        
    }


}