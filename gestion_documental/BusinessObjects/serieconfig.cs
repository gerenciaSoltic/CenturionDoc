using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class serieconfig
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32 _IDSERIE;
        private System.String _SERIE;
     

        
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
    
        public System.Int32 IDSERIE
        {
            get
            {
                return _IDSERIE;
            }
            set
            {
                _IDSERIE = value;
            }
        }
        public System.String SERIE
        {
            get
            {
                return _SERIE;
            }
            set
            {
                _SERIE = value;
            }
        }


       
        
    }
}