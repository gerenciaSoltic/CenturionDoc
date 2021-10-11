using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class stikerCaja
    {
        public string imagenempresa { get; set; }
        public string imagenproyecto { get; set; }
        public string proyecto { get; set; }
        public string oficina { get; set; }
        public string serie { get; set; }
        public string fechaini { get; set; }
        public string fechafin { get; set; }
        public string observacion { get; set; }
        public string caja { get; set; }
        public string orden { get; set; }
        public string volumen { get; set; }
        public string folios { get; set; }
        public string numerodeidentificacion { get; set; }
        public string nombretercero { get; set; }

        public stikerCaja()
        {
            imagenempresa="";
            imagenproyecto = "";
            proyecto = "";
            oficina = "";
            serie = "";
            fechaini = "";
            fechafin = "";
            observacion = "";
            caja = "";
            orden = "";
            volumen = "";
            folios = "";
            numerodeidentificacion = "";

        }
    }
}