using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class ConfiCor
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32 _ID;
        private System.String _EMAIL;
        private System.String _CONTRASENA;
        private System.String _SERVPOPSALIENTE;
        private System.String _SERVPOPENTRANTE;
        private System.String _CAMINODESCARGA;
        private System.String _CAMINOSCANNER;
        private System.String _SOFTESCANER;
        private System.String _CAMINOCALIDAD;
        private System.String _CARPETATEMP;
        private System.DateTime _FECHAARRANQUE;

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
        public System.String EMAIL
        {
            get
            {
                return ajustarAncho(_EMAIL, 100);
            }
            set
            {
                _EMAIL = value;
            }
        }
        public System.String CONTRASENA
        {
            get
            {
                return ajustarAncho(_CONTRASENA, 100);
            }
            set
            {
                _CONTRASENA = value;
            }
        }
        public System.String SERVPOPSALIENTE
        {
            get
            {
                return ajustarAncho(_SERVPOPSALIENTE, 100);
            }
            set
            {
                _SERVPOPSALIENTE = value;
            }
        }
        public System.String SERVPOPENTRANTE
        {
            get
            {
                return ajustarAncho(_SERVPOPENTRANTE, 100);
            }
            set
            {
                _SERVPOPENTRANTE = value;
            }
        }
        public System.String CAMINODESCARGA
        {
            get
            {
                return ajustarAncho(_CAMINODESCARGA, 200);
            }
            set
            {
                _CAMINODESCARGA = value;
            }
        }
        public System.String CAMINOSCANNER
        {
            get
            {
                return ajustarAncho(_CAMINOSCANNER, 200);
            }
            set
            {
                _CAMINOSCANNER = value;
            }
        }

        public System.String SOFTESCANER
        {
            get
            {
                return ajustarAncho(_SOFTESCANER, 200);
            }
            set
            {
                _SOFTESCANER = value;
            }
        }
        public System.String CAMINOCALIDAD
        {
            get
            {
                return ajustarAncho(_CAMINOCALIDAD, 200);
            }
            set
            {
                _CAMINOCALIDAD = value;
            }
        }

        public System.String CARPETATEMP
        {
            get
            {
                return ajustarAncho(_CARPETATEMP, 200);
            }
            set
            {
                _CARPETATEMP = value;
            }
        }

        public System.DateTime FECHAARRANQUE
        {
            get
            {
                return _FECHAARRANQUE;
            }
            set
            {
                _FECHAARRANQUE = value;
            }
        }


    }
}