using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class GruposWin
    {

        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32 _IDGRUPOSWIN;
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
        public System.Int32 IDGRUPOSWIN
        {
            get
            {
                return _IDGRUPOSWIN;
            }
            set
            {
                _IDGRUPOSWIN = value;
            }
        }

        public System.String DESCRIPCION
        {
            get
            {
                return ajustarAncho(_DESCRIPCION, 100);
            }
            set
            {
                _DESCRIPCION = value;
            }
        }
  

    }
}