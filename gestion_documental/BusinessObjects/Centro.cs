using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class Centro
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.String _idcentro;
        private System.String _nombre;
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
        public System.String idcentro
        {
            get
            {
                return ajustarAncho(_idcentro, 20);
            }
            set
            {
                _idcentro = value;
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
        public string this[int index]
        {
            // Devuelve el contenido del campo indicado en index
            // (el índice corresponde con la columna de la tabla)
            get
            {
                if (index == 0)
                {
                    return this.idcentro.ToString();
                }
                else if (index == 1)
                {
                    return this.nombre.ToString();
                }
                // Para que no de error el compilador de C#
                return "";
            }
            set
            {
                if (index == 0)
                {
                    this.idcentro = value;
                }
                else if (index == 1)
                {
                    this.nombre = value;
                }
            }
        }
        public string this[string index]
        {
            // Devuelve el contenido del campo indicado en index
            // (el índice corresponde al nombre de la columna)
            get
            {
                if (index == "idcentro")
                {
                    return this.idcentro.ToString();
                }
                else if (index == "nombre")
                {
                    return this.nombre.ToString();
                }
                // Para que no de error el compilador de C#
                return "";
            }
            set
            {
                if (index == "idcentro")
                {
                    this.idcentro = value;
                }
                else if (index == "nombre")
                {
                    this.nombre = value;
                }
            }
        }
    }
}