using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class Formatos
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32 _IDFORMATOS;
        private System.Int32 _IDENTE;
        private System.String _DESCRIPCION;
        private System.String _ARCHIVO;
        private System.Int32 _ACTIVO;
        
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


        public System.Int32 IDFORMATOS
        {
            get
            {
                return _IDFORMATOS;
            }
            set
            {
                _IDFORMATOS = value;
            }
        }

        public System.String DESCRIPCION
        {
            get
            {
                return ajustarAncho(_DESCRIPCION, 20);
            }
            set
            {
                _DESCRIPCION = value;
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

        public System.Int32 ACTIVO
        {
            get
            {
                return _ACTIVO;
            }
            set
            {
                _ACTIVO = value;
            }
        }

    }
}