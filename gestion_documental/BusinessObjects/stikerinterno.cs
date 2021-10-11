using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class stikerinterno
    {
        public int caja { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public int numero { get; set; }
        public int numerocarpeta { get; set; } 

        public stikerinterno()
        {
            caja =0;
            cedula="";
            nombre = "";
            numero = 0;
            numerocarpeta = 0;
          
        }
    }
}