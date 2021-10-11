using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class proceso
    {
        public proceso()
        {
            
        }
        private System.Int32 _ID;
        private System.String _PROCESO;

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
        public System.String PROCESO
        {
            get
            {
                return _PROCESO;
            }
            set
            {
                _PROCESO = value;
            }
        }


        
    }
}