using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class Cargo
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32 _IDCARGO;
        private System.String _DESCRIPCION;
        private System.Int32 _LIDER;
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
        public System.Int32 IDCARGO
        {
            get
            {
                return _IDCARGO;
            }
            set
            {
                _IDCARGO = value;
            }
        }

        public System.Int32 LIDER
        {
            get
            {
                return _LIDER;
            }
            set
            {
                _LIDER = value;
            }
        }

        public System.String DESCRIPCION
        {
            get
            {
                return ajustarAncho(_DESCRIPCION, 255);
            }
            set
            {
                _DESCRIPCION = value;
            }
        }
    }
}