using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestion_documental.BusinessObjects;
using System.Data;

namespace gestion_documental.DataAccessLayer
{
    public class custodiapequeñoconsul
    {
        Class1 proce = new Class1();
        public static string tercero;
        public static int consecutivo;
        public static int cantidad;

        public List<custodiapequeno> obtenerconsecutivo()
        {
            DataTable data = new DataTable();
            proce.consultacamposcondicion("terceros", "nombre1,sucursal", "nit='" + tercero + "'", data);
            List<custodiapequeno> _custodia = new List<custodiapequeno>();
            for (int i = consecutivo; i < cantidad+consecutivo; i=i+3)
            {
                custodiapequeno _cus = new custodiapequeno();
                _cus.empresa1 = data.Rows[0]["nombre1"].ToString();
                _cus.tom1 =llenarnumero(Convert.ToString(i));
                _cus.empresa2 = data.Rows[0]["nombre1"].ToString();
                _cus.tom2 = llenarnumero(Convert.ToString(i+1));
                _cus.empresa3 = data.Rows[0]["nombre1"].ToString();
                _cus.tom3 = llenarnumero(Convert.ToString(i+2));
                _cus.codigo = data.Rows[0]["sucursal"].ToString();
                _cus.nit = tercero;
            //    _cus.imagen = "D:\\gestion_documental\\trunk\\gestion_documental\\imagenesInstitucion\\isso";
                _custodia.Add(_cus);
            }
            return _custodia;
        }

        public string llenarnumero(string numero)
        {
            string numerosalida = numero;
            
            for (int i = numero.ToString().Trim().Length; i < 6; i++)
            {
                numerosalida = "0" + numerosalida;
            }
            return numerosalida;
        }
    }
}