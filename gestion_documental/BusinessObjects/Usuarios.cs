using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class Usuarios
    {

        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32 _CODIGO;
        private System.String _NOMBRE;
        private System.String _USUARIO;
        private System.String _CONTRASENA;
        private System.Int32 _IDINSTITUCION;
        private System.String _ACTIVO;
        public DateTime fechaIngreso { get; set; }
        private System.Int32 _ROL;
        private System.String _USUARIOWIN;
        private System.String _CORREOELECTRONICO;
        private System.String _CONTRASENACORREO;
        private System.Int32 _primeravez;

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
        public System.Int32 CODIGO
        {
            get
            {
                return _CODIGO;
            }
            set
            {
                _CODIGO = value;
            }
        }
        public System.String NOMBRE
        {
            get
            {
                return ajustarAncho(_NOMBRE, 100);
            }
            set
            {
                _NOMBRE = value;
            }
        }
        public System.String USUARIO
        {
            get
            {
                return ajustarAncho(_USUARIO, 20);
            }
            set
            {
                _USUARIO = value;
            }
        }
        public System.String CONTRASENA
        {
            get
            {
                return ajustarAncho(_CONTRASENA, 20);
            }
            set
            {
                _CONTRASENA = value;
            }
        }

        public System.String ACTIVO
        {
            get
            {
                return ajustarAncho(_ACTIVO, 5);
            }
            set
            {
                _ACTIVO = value;
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
        public System.Int32 IDINSTITUCION
        {
            get
            {
                return _IDINSTITUCION;
            }
            set
            {
                _IDINSTITUCION = value;
            }
        }


        public System.String USUARIOWIN
        {
            get
            {
                return ajustarAncho(_USUARIOWIN, 100);
            }
            set
            {
                _USUARIOWIN = value;
            }
        }

        public System.String CORREOELECTRONICO
        {
            get
            {
                return ajustarAncho(_CORREOELECTRONICO, 100);
            }
            set
            {
                _CORREOELECTRONICO = value;
            }
        }


        public System.String CONTRASENACORREO
        {
            get
            {
                return ajustarAncho(_CONTRASENACORREO, 100);
            }
            set
            {
                _CONTRASENACORREO = value;
            }
        }


        public System.Int32 PRIMERAVEZ
        {
            get
            {
                return _primeravez;
            }
            set
            {
                _primeravez = value;
            }
        }

    }
}