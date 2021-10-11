using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class Adjunsal
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32 _ID;
        private System.Int32 _IDCORREO;
        private System.String _ARCHIVO;
        private System.String _NEWARCHIVO;
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
        public System.Int32 ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
        public System.Int32 IDCORREO
        {
            get
            {
                return _IDCORREO;
            }
            set
            {
                _IDCORREO = value;
            }
        }
        public System.String ARCHIVO
        {
            get
            {
                return ajustarAncho(_ARCHIVO, 200);
            }
            set
            {
                _ARCHIVO = value;
            }
        }
        public System.String NEWARCHIVO
        {
            get
            {
                return ajustarAncho(_NEWARCHIVO, 200);
            }
            set
            {
                _NEWARCHIVO = value;
            }
        }
    }
}