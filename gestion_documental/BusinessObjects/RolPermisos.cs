using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class RolPermisos
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32    _Id     ;
        private System.Int32    _ROL    ;
        private System.String   _MENU   ;
        private System.String   _MODULO ;
        private System.Int32    _ACTIVO ;
        public RolPermisos()
        { 
        }
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
        public System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }
        public System.Int32 ROL
        {
            get
            {
                return _ROL;
            }
            set
            {
                _ROL = value;
            }
        }
        public System.String MENU
        {
            get
            {
                return ajustarAncho(_MENU, 255);
            }
            set
            {
                _MENU = value;
            }
        }
        public System.String MODULO
        {
            get
            {
                return ajustarAncho(_MODULO, 255);
            }
            set
            {
                _MODULO = value;
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