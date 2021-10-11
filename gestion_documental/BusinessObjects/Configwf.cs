using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class Configwf
    {

        public Configwf()
        {
            ente = new Ente();
            tipologia = new Tipologia();
            subserie = new SubSerie();
            tareas = new Tareas();
            actividad = new Actividad();
           /* expediente = new Expediente();*/
        }

        public Ente ente { get; set; }
        public Tipologia tipologia { get; set; }
        public SubSerie subserie { get; set; }
        public Tareas tareas { get; set; }
        public Actividad actividad { get; set; }
        //public Expediente expediente { get; set; }

        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32 _ID;
        private System.Int32 _IDENTE;
        private System.Int32 _IDTIPOLOGIA;
        private System.Int32 _ORDEN;
        private System.Int32 _DIAS;
        private System.Int32 _idsubserie;
        private System.Int32 _idtarea;
        private System.Int32 _idserie;
        private System.Int32 _idproceso;
        private System.Int32 _idactividad;
        private System.Int32 _idactividadsiguiente;
        private System.Int32 _idprocesosiguiente;
        private System.Int32 _idemirecep;
        //private System.Int32 _idexpediente;
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
        public System.Int32 IDENTE
        {
            get
            {
                return _IDENTE;
            }
            set
            {
                _IDENTE = value;
            }
        }

        public System.Int32 IDSERIE
        {
            get
            {
                return _idserie;
            }
            set
            {
                _idserie = value;
            }
        }

        public System.Int32 IDTIPOLOGIA
        {
            get
            {
                return _IDTIPOLOGIA;
            }
            set
            {
                _IDTIPOLOGIA = value;
            }
        }
        public System.Int32 ORDEN
        {
            get
            {
                return _ORDEN;
            }
            set
            {
                _ORDEN = value;
            }
        }

        public System.Int32 DIAS
        {
            get
            {
                return _DIAS;
            }
            set
            {
                _DIAS = value;
            }
        }

        public System.Int32 idsubserie
        {
            get
            {
                return _idsubserie;
            }
            set
            {
                _idsubserie = value;
            }
        }

        public System.Int32 idtarea
        {
            get
            {
                return _idtarea;
            }
            set
            {
                _idtarea = value;
            }
        }

        public System.Int32 idproceso
        {
            get
            {
                return _idproceso;
            }
            set
            {
                _idproceso = value;
            }
        }

        public System.Int32 idactividad
        {
            get
            {
                return _idactividad;
            }
            set
            {
                _idactividad = value;
            }
        }

        public System.Int32 idactividadsiguiente
        {
            get
            {
                return _idactividadsiguiente;
            }
            set
            {
                _idactividadsiguiente = value;
            }
        }

        public System.Int32 idprocesosiguiente
        {
            get
            {
                return _idprocesosiguiente;
            }
            set
            {
                _idprocesosiguiente = value;
            }
        }

        public System.Int32 idemirecep
        {
            get
            {
                return _idemirecep;
            }
            set
            {
                _idemirecep = value;
            }
        }
        /* public System.Int32 idexpediente
         {
             get
             {
                 return _idexpediente;
             }
             set
             {
                 _idexpediente = value;
             }
         }
         */
    }
}