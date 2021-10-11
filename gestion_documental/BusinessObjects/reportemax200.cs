using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class reportemax200
    {
     
        public double idexpediente { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string documento { get; set; }
        public string tipologia { get; set; }
        public double folios { get; set; }
        public double total { get; set; }
     
        public reportemax200()
        {
            nombre = "";
            folios = 0;
            tipologia = "";
            documento = "";
            idexpediente = 0;
            cedula = "";
            total = 0;
        }
    }
}