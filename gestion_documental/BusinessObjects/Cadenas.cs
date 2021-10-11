using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class Cadenas
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32 _ID;
        private System.DateTime _FECHA;
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

        public System.DateTime FECHA
        {
            get
            {
                return _FECHA;
            }
            set
            {
                _FECHA = value;
            }
        }

        
    }
}