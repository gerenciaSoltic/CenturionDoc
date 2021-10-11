using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class Tareas
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32 _idtareas;
        private System.String _descripcion;
        private System.Int32 _orden;
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
        public System.Int32 idtareas
        {
            get
            {
                return _idtareas;
            }
            set
            {
                _idtareas = value;
            }
        }
        public System.String descripcion
        {
            get
            {
                return ajustarAncho(_descripcion, 45);
            }
            set
            {
                _descripcion = value;
            }
        }
        public System.Int32 orden
        {
            get
            {
                return _orden;
            }
            set
            {
                _orden = value;
            }
        }

        
    }
}