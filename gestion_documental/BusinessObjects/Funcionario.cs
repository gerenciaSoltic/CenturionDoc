using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class Funcionario
    {
        
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32 	_IDEMIRECEP			;
        private System.String 	_FUNCIONARIO		;
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

        
        
        public System.Int32 IDEMIRECEP
        {
            get
            {
                return _IDEMIRECEP;
            }
            set
            {
                _IDEMIRECEP = value;
            }
        }
        public System.String FUNCIONARIO
        {
            get
            {
                return ajustarAncho(_FUNCIONARIO, 150);
            }
            set
            {
                _FUNCIONARIO = value;
            }
        }
        
    }
}