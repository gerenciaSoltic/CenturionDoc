using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class RBInventarioContratacion
    {
        public Int32 numeroorden { get; set; }
        public string caja  {get; set;}
        public string codigo { get; set; }
        public string serie { get; set; }

        public string fecinicial { get; set; }
        public string fecfinal { get; set; }
        public Int32 folios { get; set; }
        public string volumen { get; set; }
        public string observaciones { get; set; }
        public string oficinaproductora { get; set; }
        public DateTime fechaentrega { get; set; }
        public string numeroentrega { get; set; }
       
        public RBInventarioContratacion()
        {
          numeroorden =0;
        caja = "";
        codigo = "";
        serie = "";
        fecinicial ="";
        fecfinal = "";
        folios =0;
        volumen ="";
        observaciones = "";
        oficinaproductora = "";
        fechaentrega = System.DateTime.Now;
        numeroentrega = "";
       
        }
    }
}