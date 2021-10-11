using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class DocVersion
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32 _IDDOCVERSION;
        private System.Int32 _IDDOCUMENTO;
        private System.Int32 _VERSION;
        private System.String _ARCHIVO;
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
        public System.Int32 IDDOCVERSION
        {
            get
            {
                return _IDDOCVERSION;
            }
            set
            {
                _IDDOCVERSION = value;
            }
        }
        public System.Int32 IDDOCUMENTO
        {
            get
            {
                return _IDDOCUMENTO;
            }
            set
            {
                _IDDOCUMENTO = value;
            }
        }
        public System.Int32 VERSION
        {
            get
            {
                return _VERSION;
            }
            set
            {
                _VERSION = value;
            }
        }
        public System.String ARCHIVO
        {
            get
            {
                return ajustarAncho(_ARCHIVO, 255);
            }
            set
            {
                _ARCHIVO = value;
            }
        }
  

    }
}