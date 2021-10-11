using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class Indices
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32 _idINDICES;
        private System.String _INDICE;
        private System.String _ATRIBUTO;
        private System.Int32 _iddocumento;
        private System.Int32 _local;
        private System.Int32 _actualizado;

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
        public System.Int32 idINDICES
        {
            get
            {
                return _idINDICES;
            }
            set
            {
                _idINDICES = value;
            }
        }
        public System.String INDICE
        {
            get
            {
                return ajustarAncho(_INDICE, 45);
            }
            set
            {
                _INDICE = value;
            }
        }
        public System.Int32 iddocumento
        {
            get
            {
                return _iddocumento;
            }
            set
            {
                _iddocumento = value;
            }
        }

        public System.String ATRIBUTO
        {
            get
            {
                return ajustarAncho(_ATRIBUTO, 45);
            }
            set
            {
                _ATRIBUTO = value;
            }
        }


        public System.Int32 local
        {
            get
            {
                return _local;
            }
            set
            {
                _local = value;
            }
        }

        public System.Int32 actualizado
        {
            get
            {
                return _actualizado;
            }
            set
            {
                _local = value;
            }
        }

    }
}