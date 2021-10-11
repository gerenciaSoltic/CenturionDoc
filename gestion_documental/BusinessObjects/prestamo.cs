using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class prestamo
    {
        public int id { get; set; }
        public int id2 { get; set; }
        public double numeroprestamo { get; set; }
        public string recibe { get; set; }
        public string fechasolicitud { get; set; }
        public string tipo { get; set; }
        public string numero { get; set; }
        public string tipo2 { get; set; }
        public string numero2 { get; set; }
        public string folios { get; set; }
        public string chequeo { get; set; }
        public string observacion { get; set; }
      

        public prestamo()
        {
            recibe="";
            fechasolicitud = "";
            tipo = "";
            numero = "";
            tipo2 = "";
            numero2 = "";
            folios = "";
            chequeo = "";
            observacion = "";
            observacion = "";
          

        }
    }
}