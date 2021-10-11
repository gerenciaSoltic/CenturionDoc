using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class tipodocumento
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }

        public tipodocumento()
        {
            id = "";
            nombre = "";
            tipo = "";
        }
    }
}