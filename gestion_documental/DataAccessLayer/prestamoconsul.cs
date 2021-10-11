using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using gestion_documental.BusinessObjects;
namespace gestion_documental.DataAccessLayer
{
    public class prestamoconsul
    {

        Class1 proce = new Class1();
        public static string numeroprestamo;

        public List<BusinessObjects.prestamo> obtenerprestamo()
        {
            DataTable dataprestamo = new DataTable();
             List<BusinessObjects.prestamo> _prestamo = new List<BusinessObjects.prestamo>();
            proce.consultacamposcondicion("prestamo ", "*", "codigo='" + numeroprestamo + "'", dataprestamo);
            if (dataprestamo.Rows.Count > 0)
            {
               

                for (int i = 0; i < dataprestamo.Rows.Count; i=i+2)
                {
                   BusinessObjects.prestamo _pre = new BusinessObjects.prestamo();
                   _pre.recibe = dataprestamo.Rows[i]["recibe"].ToString();
                   _pre.fechasolicitud  = dataprestamo.Rows[i]["fechaini"].ToString();
                   _pre.tipo = dataprestamo.Rows[i]["tipo"].ToString();
                   _pre.numero = dataprestamo.Rows[i]["numero"].ToString();
                   if (dataprestamo.Rows.Count > (i + 1))
                   {
                       _pre.tipo2 = dataprestamo.Rows[i + 1]["tipo"].ToString();
                       _pre.numero2 = dataprestamo.Rows[i + 1]["numero"].ToString();
                   }
                   _pre.folios = "";//dataprestamo.Rows[i]["numerofolios"].ToString();
                   _pre.chequeo = "";//dataprestamo.Rows[i]["recibe"].ToString();
                   _pre.observacion = dataprestamo.Rows[i]["detalle"].ToString();
                   _pre.id = i+1;
                   _pre.id2 = i + 2;
                   _pre.numeroprestamo =Convert.ToDouble( numeroprestamo);
                   _prestamo.Add(_pre);
                }

            }
            int cantidadpar;
            Int32 cantidad = _prestamo.Count();
            if (cantidad % 2 == 0)
            {
                cantidadpar = 1;
            }
            else
            {
                cantidadpar = 2;
            }
            for (int j = cantidad; j < 15; j++)
            {
                BusinessObjects.prestamo _pre2 = new BusinessObjects.prestamo();
                if (cantidadpar == 1)
                {
                    _pre2.id = (j * 2);
                    _pre2.id2 = (j * 2) + 1;
                }
                else
                {
                    _pre2.id = (j * 2)+1;
                    _pre2.id2 = (j * 2) + 2;
                }
                _pre2.numeroprestamo = Convert.ToDouble(numeroprestamo);
                _prestamo.Add(_pre2);
            }
            return _prestamo;

        }

    }
}