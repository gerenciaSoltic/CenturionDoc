using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class DocumentoActividad
    {
        public DocumentoActividad()
        {
            actividad = new Actividad();
        }

        public Actividad actividad { get; set; }

        private System.Int32 _ID;
        private System.Int32 _IDACTIVIDAD;
        private System.String _NOMBREACTIVIDAD;
        private System.String _NOMBREPROCESO;
        private System.String _NOMBREDOCUMENTO;


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

        public System.Int32 IDACTIVIDAD
        {
            get
            {
                return _IDACTIVIDAD;
            }
            set
            {
                _IDACTIVIDAD = value;
            }
        }

        public System.String NOMBREACTIVIDAD
        {
            get
            {
                return _NOMBREACTIVIDAD;
            }
            set
            {
                _NOMBREACTIVIDAD = value;
            }
        }

        public System.String NOMBREPROCESO
        {
            get
            {
                return _NOMBREPROCESO;
            }
            set
            {
                _NOMBREPROCESO = value;
            }
        }

        public System.String NOMBREDOCUMENTO
        {
            get
            {
                return _NOMBREDOCUMENTO;
            }
            set
            {
                _NOMBREDOCUMENTO = value;
            }
        }

    }
}