using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class inventario
    {
        public int cajacliente { get; set; }
        public int caja { get; set; }
        public string orden { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string fechaini { get; set; }
        public string fechafinal { get; set; }
        public string ucaja { get; set; }
        public string ucarpeta { get; set; }
        public string utom { get; set; }
        public string uotros { get; set; }
        public string folios { get; set; }
        public string volumen { get; set; }
        public string soporte { get; set; }
        public string expediente { get; set; }
        public string cedula { get; set; }
        public string mcaja { get; set; }
        public string observacion { get; set; }
        public string refcaja { get; set; }
        public string cantidadtercero { get; set; }
        public string cantidadcajas { get; set; }
        public string cajaini { get; set; }
        public string cajafin { get; set; }
        public string informe { get; set; }
        public string cliente { get; set; }
        public string nombrecliente { get; set; }

        public inventario()
        {
            cajacliente = 0;
            caja = 0;
            orden = "";
            codigo = "";
            nombre = "";
            fechaini = "";
            fechaini = "";
            ucaja = "";
            ucarpeta = "";
            utom = "";
            uotros = "";
            volumen = "";
            expediente = "";
            cedula = "";
            mcaja = "";
            folios = "";
            observacion="";
            refcaja = "";
            soporte = "";
            cantidadtercero = "";
            cantidadcajas = "";
            cajaini = "";
            cajafin = "";
            informe = "";
            cliente = "";
            nombrecliente = "";
        }

    }
}