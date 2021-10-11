using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class CalidadDigitalizacion
    {
        private DateTime _fecha;
        private string _expediente;
        private string _documento;

        public CalidadDigitalizacion()
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

    }
}