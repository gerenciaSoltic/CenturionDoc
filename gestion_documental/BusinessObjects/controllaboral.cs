using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class controllaboral
    {
        public string primernombre { get; set; }
        public string segundonombre { get; set; }
        public string primerapellido { get; set; }
        public string segundoapellido { get; set; }
        public string tipodocumento { get; set; }
        public string fechanacimiento { get; set; }
        public string genero { get; set; }
        public string funcionario { get; set; }
        public string identidad { get; set; }
        public string documento { get; set; }
        public string seccion { get; set; }
        public string fecha { get; set; }
        public string tipodocumental { get; set; }
        public string folios { get; set; }
        public string carpeta { get; set; }
        public int serie { get; set; }
        public int subserie { get; set; }
        public controllaboral()
        {
            primernombre = "";
            segundonombre = "";
            primerapellido = "";
            segundoapellido = "";
            tipodocumento = "";
            fechanacimiento = "";
            genero = "";
            funcionario = "";
            identidad = "";
            documento = "";
            seccion = "";
            fecha = "";
            tipodocumental = "";
            folios = "";
            carpeta = "";
            serie = 0;
            subserie = 0;
        }
    }
}