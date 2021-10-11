using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class LinkDoc
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32 _ID;
        private System.Int32 _IDENTE;
        private System.Int32 _IDDOCUMENTOS;
        private System.Int32 _IDSERIE;
        private System.Int32 _IDSUBSERIE;
        private System.Int32 _IDTIPOLOGIA;
        private System.Int32 _IDEXPEDIENTE;

       
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
                _ID= value;
            }
        }
        
        public System.Int32 IDENTE
        {
            get
            {
                return _IDENTE;
            }
            set
            {
                _IDENTE = value;
            }
        }
        public System.Int32 IDDOCUMENTOS
        {
            get
            {
                return _IDDOCUMENTOS;
            }
            set
            {
                _IDDOCUMENTOS = value;
            }
        }


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


        public System.Int32 IDSUBSERIE
        {
            get
            {
                return _IDSUBSERIE;
            }
            set
            {
                _IDSUBSERIE = value;
            }
        }

        public System.Int32 IDTIPOLOGIA
        {
            get
            {
                return _IDTIPOLOGIA;
            }
            set
            {
                _IDTIPOLOGIA = value;
            }
        }


        public System.Int32 IDEXPEDIENTE
        {
            get
            {
                return _IDEXPEDIENTE;
            }
            set
            {
                _IDEXPEDIENTE = value;
            }
        }
    }
}