using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class EnteRuta
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32 _IDENTERUTA;
        private System.Int32 _IDENTE;
        private System.String _CONTENEDOR;
        private System.String _NUMERO;
        private System.Int32 _COMPARTIMIENTO;
        
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


        public System.Int32 IDENTERUTA
        {
            get
            {
                return _IDENTERUTA;
            }
            set
            {
                _IDENTERUTA = value;
            }
        }

        public System.String CONTENEDOR
        {
            get
            {
                return ajustarAncho(_CONTENEDOR, 20);
            }
            set
            {
                _CONTENEDOR = value;
            }
        }
        public System.String NUMERO
        {
            get
            {
                return ajustarAncho(_NUMERO, 255);
            }
            set
            {
                _NUMERO = value;
            }
        }

        public System.Int32 COMPARTIMIENTO
        {
            get
            {
                return _COMPARTIMIENTO;
            }
            set
            {
                _COMPARTIMIENTO = value;
            }
        }

    }
}