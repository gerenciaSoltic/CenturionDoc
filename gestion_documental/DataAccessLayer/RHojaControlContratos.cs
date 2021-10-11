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
    public class RHojacontrolContratos
    {
        Class1 proce = new Class1();
        
        #region selec

        public static string numerocontrato;
        public static string carpeta;
       
        

        public List<RBHojaControlContratos> obtenerHojacontratos()
        {
            List<RBHojaControlContratos> ListHoja = new List<RBHojaControlContratos>();
          DataTable Dathoja = new DataTable();
          proce.consultacamposcondicion("hojacontrolcontratos", "*", "numerocontrato ='" + numerocontrato + "' and carpeta='" + carpeta + "' and idinstitucion =" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION.ToString(), Dathoja);


          for (int i = 0; i < Dathoja.Rows.Count; i++)
          {
              RBHojaControlContratos Hoja = new RBHojaControlContratos();
              Hoja.carpeta = Dathoja.Rows[i]["carpeta"].ToString();
              Hoja.codigo = Dathoja.Rows[i]["codigo"].ToString();
              Hoja.fecha = Dathoja.Rows[i]["fecha"].ToString();
              Hoja.folios = Dathoja.Rows[i]["Folios"].ToString();
              Hoja.nombrecontratista =Dathoja.Rows[i]["nombrecontratista"].ToString();
              Hoja.numero = Dathoja.Rows[i]["numero"].ToString();
              Hoja.numerocontrato=Dathoja.Rows[i]["numerocontrato"].ToString(); 
              Hoja.oficina =Dathoja.Rows[i]["oficina"].ToString();
              Hoja.serie = Dathoja.Rows[i]["serie"].ToString();
              Hoja.subserie = Dathoja.Rows[i]["subserie"].ToString();
              Hoja.tipodocumental = Dathoja.Rows[i]["tipodocumental"].ToString();
              
             
              ListHoja.Add(Hoja);
          }

        
          for (int faltan = 0; faltan < (24 - Dathoja.Rows.Count); faltan++)
          {
              RBHojaControlContratos Hoja = new RBHojaControlContratos();
             
              ListHoja.Add(Hoja);
          }
     

            return ListHoja;
        }
        #endregion

        
    }


}