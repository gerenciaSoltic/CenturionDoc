using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class RBHojaControlContratos
    {
        public string codigo { get; set; }
        public string serie  {get; set;}
        public string subserie { get; set; }
        public string numerocontrato { get; set; }
        public string carpeta { get; set; }
        public string nombrecontratista { get; set; }
        public string oficina { get; set; }
        public string tipodocumental { get; set; }
        public string folios { get; set; }
      
        public string numero  {get; set;}
        public string fecha { get; set; }
        
        public RBHojaControlContratos()
        {
            codigo = "";
            serie = "";
            subserie = "";
            numerocontrato = "";
            nombrecontratista = "";
            oficina = "";
            tipodocumental = "";
            numero = "";
            folios = "";
            carpeta = "";
            fecha = "";
        }
    }
}