using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class CalidadDigital
    {
        private DateTime _fecha;
        private string _expediente;
        private string _documento;
        private string _caminoCalidad;
        private string _ruta;
        private int _idDocumento;

        public CalidadDigital()
        { 
        }
        public System.DateTime FECHA
        {
            get
            {
                return _fecha;
            }
            set
            {
                _fecha = value;
            }
        }
        public System.String EXPEDIENTE
        {
            get
            {
                return _expediente;
            }
            set
            {
                _expediente = value;
            }
        }
        public System.String DOCUMENTO
        {
            get
            {
                return _documento;
            }
            set
            {
                _documento = value;
            }
        }
        public System.String CAMINOCALIDAD
        {
            get
            {
                return _caminoCalidad;
            }
            set
            {
                _caminoCalidad = value;
            }
        }
        public System.String RUTA
        {
            get
            {
                return _ruta;
            }
            set
            {
                _ruta = value;
            }
        }
        public Int32 IDDOCUMENTO
        {
            get
            {
                return _idDocumento;
            }
            set
            {
                _idDocumento = value;
            }
        }

    }
}