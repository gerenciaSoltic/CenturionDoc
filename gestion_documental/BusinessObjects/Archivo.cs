using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class Archivo
    {
        public int      idArchivo       { get; set; }
        public string   nombreReal      { get; set; }
        public string   nombreAlmacenado { get; set; }
        public int      idCorreo        { get; set; }
    }
}