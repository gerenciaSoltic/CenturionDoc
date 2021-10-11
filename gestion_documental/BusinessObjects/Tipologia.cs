using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class Tipologia
    {
        public Tipologia()
        {
            subserie = new SubSerie();
            
        }
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32 _ID;
        
        private System.String _TIPOLOGIA;
        private System.String _CODIGO;

        //
        // Este método se usará para ajustar los anchos de las propiedades
        private string ajustarAncho(string cadena, int ancho)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
            // devolver la cadena quitando los espacios en blanco
            // esto asegura que no se devolverá un tamaño mayor ni espacios "extras"
            return (cadena + sb.ToString()).Substring(0, ancho).Trim();
        }

        public SubSerie subserie { get; set; }
        //
        // Las propiedades públicas
        // TODO: Revisar los tipos de las propiedades
        public System.Int32 ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
        public System.String TIPOLOGIA
        {
            get
            {
                return ajustarAncho(_TIPOLOGIA, 255);
            }
            set
            {
                _TIPOLOGIA = value;
            }
        }


        public System.String CODIGO
        {
            get
            {
                return ajustarAncho(_CODIGO, 255);
            }
            set
            {
                _CODIGO = value;
            }
        }

    }
}