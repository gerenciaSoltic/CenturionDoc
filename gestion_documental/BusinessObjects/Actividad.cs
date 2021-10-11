using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class Actividad
    {
        public Actividad()
        {
            proceso = new proceso();
        }

        public proceso proceso { get; set; }

      
        private System.Int32 _ID;
        private System.Int32 _IDPROCESO;
        private System.String _NOMBREPROCESO;
        private System.String _ACTIVIDAD;
        
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

        public System.Int32 IDPROCESO
        {
            get
            {
                return _IDPROCESO;
            }
            set
            {
                _IDPROCESO = value;
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

        public System.String ACTIVIDAD
        {
            get
            {
                return _ACTIVIDAD;
            }
            set
            {
                _ACTIVIDAD = value;
            }
        }

    }
}