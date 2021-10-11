using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class grupocom
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32 _id;
        private System.String _nombre;
        private System.Int32 _idradicado;

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
        public System.Int32 id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public System.Int32 idradicado
        {
            get
            {
                return _idradicado;
            }
            set
            {
                _idradicado = value;
            }
        }

        public System.String nombre
        {
            get
            {
                return ajustarAncho(_nombre, 80);
            }
            set
            {
                _nombre = value;
            }
        }
        //
        
    }
}