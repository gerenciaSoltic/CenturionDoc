using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class custodiapequeno
    {
        public string empresa1 { get; set; }
        public string empresa2 { get; set; }
        public string empresa3 { get; set; }
        public string tom1 { get; set; }
        public string tom2 { get; set; }
        public string tom3 { get; set; }
        public string tercero { get; set; }
        public string nit { get; set; }
        public string imagen { get; set; }
        public string codigo { get; set; }

        public custodiapequeno()
        {
            empresa1 = "";
            empresa2 = "";
            empresa3 = "";
            tom1 = "";
            tom2 = "";
            tom3 = "";
            tercero = "";
            nit = "";
            imagen = "";
            codigo="";
        }
    }
}