using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using gestion_documental.BusinessObjects;

namespace gestion_documental.DataAccessLayer
{

    public class reportemax200consul
    {
        Class1 proce = new Class1();
        public static string documento;

        public List<reportemax200> obtenerdocumentos()
        {
            List<reportemax200> _reporte = new List<reportemax200>();
            DataTable data = new DataTable();
            DataTable datafinal = new DataTable();
            proce.consultacamposcondicion("documentos", "sum(folios) as totalfolios,idexpediente", " iddocumentos >0 group by idexpediente having totalfolios >200", data);
            for (int i = 0; i < data.Rows.Count; i++)
            {

                proce.consultacamposcondicion("documentos d join expediente e on d.idexpediente=e.id", "d.documento as documento,e.numerodeidentificacion as cedula,e.descripcion as nombre,d.folios,d.idtipologia,d.idexpediente", "d.idexpediente='" + data.Rows[i]["idexpediente"].ToString() + "'", datafinal);
                for (int w = 0; w < datafinal.Rows.Count; w++)
                {
                    reportemax200 _re = new reportemax200();
                    _re.cedula = Convert.ToString(datafinal.Rows[w]["cedula"]);
                    _re.nombre = datafinal.Rows[w]["nombre"].ToString();
                    _re.idexpediente =Convert.ToDouble(datafinal.Rows[w]["idexpediente"]);
                    _re.documento = Convert.ToString(datafinal.Rows[w]["documento"]);
                    _re.folios=Convert.ToDouble(datafinal.Rows[w]["folios"].ToString());
                    _re.tipologia = datafinal.Rows[w]["idtipologia"].ToString();
                    _re.total = data.Rows.Count;
                    _reporte.Add(_re);
                }

            }
            return _reporte;
        }
    }
}