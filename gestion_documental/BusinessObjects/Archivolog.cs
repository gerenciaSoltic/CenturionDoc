using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class Archivolog
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32 _idsesion;
        private System.DateTime _ingresoloc;
        private System.DateTime _ingresoser;
        private System.String _usuario;
        private System.String _entidad;
        private System.String _opcion;
        private System.String _idregistro;
        private System.String _estado;
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
        public System.Int32 idsesion
        {
            get
            {
                return _idsesion;
            }
            set
            {
                _idsesion = value;
            }
        }
        public System.DateTime ingresoloc
        {
            get
            {
                return _ingresoloc;
            }
            set
            {
                _ingresoloc = value;
            }
        }
        public System.DateTime ingresoser
        {
            get
            {
                return _ingresoser;
            }
            set
            {
                _ingresoser = value;
            }
        }
        public System.String usuario
        {
            get
            {
                return ajustarAncho(_usuario, 45);
            }
            set
            {
                _usuario = value;
            }
        }
        public System.String entidad
        {
            get
            {
                return ajustarAncho(_entidad, 20);
            }
            set
            {
                _entidad = value;
            }
        }
        public System.String opcion
        {
            get
            {
                return ajustarAncho(_opcion, 100);
            }
            set
            {
                _opcion = value;
            }
        }
        public System.String idregistro
        {
            get
            {
                return ajustarAncho(_idregistro, 20);
            }
            set
            {
                _idregistro = value;
            }
        }
        public System.String estado
        {
            get
            {
                return ajustarAncho(_estado, 200);
            }
            set
            {
                _estado = value;
            }
        }
    }
}