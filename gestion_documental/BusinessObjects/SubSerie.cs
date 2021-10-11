using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class SubSerie
    {

        public SubSerie()
        {
            serie = new Serie();
            TIPOLOGIA = new List<Tipologia>();
            
        }

        public Serie serie { get; set; }

        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32 _ID;
        private System.Int32 _IDSERIE;
        private System.String _SUBSERIE;
        private System.String _CODIGO;
        private System.Int32 _IDDISPOFINAL;
        private System.Int32 _TIEMPOGESTION;
        private System.Int32 _TIEMPOCENTRAL;
        private System.Int32 _TIEMPOHISTORICO;
        private System.String _DISPOSICION;
        private System.String _NOMBRESERIE;
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
        public List<Tipologia> TIPOLOGIA { get; set; }

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

        public System.Int32 IDSERIE
        {
            get
            {
                return _IDSERIE;
            }
            set
            {
                _IDSERIE = value;
            }
        }

        public System.String SUBSERIE
        {
            get
            {
                return _SUBSERIE;
            }
            set
            {
                _SUBSERIE = value;
            }
        }

        public System.String CODIGO
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



        public System.Int32 IDDISPOFINAL {
            get {
                return _IDDISPOFINAL;
            }
            set 
            { _IDDISPOFINAL = value;

            }
        }

        public System.Int32 TIEMPOGESTION {
            get
            {
                return _TIEMPOGESTION;
            }
            set
            {
                _TIEMPOGESTION = value;

            }
        }

        public System.Int32 TIEMPOCENTRAL {
            get
            {
                return _TIEMPOCENTRAL;
            }
            set
            {
                _TIEMPOCENTRAL = value;

            }
        }

        public System.Int32 TIEMPOHISTORICO
        {
            get
            {
                return _TIEMPOHISTORICO;
            }
            set
            {
               _TIEMPOHISTORICO = value;

            }
            
        }


        public System.String DISPOSICION
        {
            get
            {
                return _DISPOSICION;
            }
            set
            {
                _DISPOSICION = value;
            }
        }

        public System.String NOMBRESERIE
        {
            get
            {
                return _NOMBRESERIE;
            }
            set
            {
                _NOMBRESERIE = value;
            }
        }
    }
}