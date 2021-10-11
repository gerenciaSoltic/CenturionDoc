using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class unidades
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32 _IDUNIDADES;
        private System.String _DESCRIPCION;
        

        
        //
        // Este método se usará para ajustar los anchos de las propiedades
        private string ajustarAncho(string cadena, int ancho)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
            // devolver la cadena quitando los espacios en blanco
            // esto asegura que no se devolverá un tamaño mayor ni espacios "extras"
            return (cadena + sb.ToString()).Substring(0, ancho).Trim();
        }
        //
        // Las propiedades públicas
        // TODO: Revisar los tipos de las propiedades
        //public List<SubSerie> SUBSERIE { get; set; }
        public System.Int32 IDUNIDADES
        {
            get
            {
                return _IDUNIDADES;
            }
            set
            {
                _IDUNIDADES = value;
            }
        }
        public System.String DESCRIPCION
        {
            get
            {
                return _DESCRIPCION;
            }
            set
            {
                _DESCRIPCION = value;
            }
        }


        
    }
}