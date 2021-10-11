using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class Tipocom
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.String _tipocomunicacion;
        private System.Int32 _id;
        private System.Int32  _idgrupo;
     
        //
        // Las propiedades públicas
        // TODO: Revisar los tipos de las propiedades
        public System.String TIPOCOMUNICACION        {
            get
            {
                return _tipocomunicacion;
            }
            set
            {
                _tipocomunicacion = value;
            }
        }


        public System.Int32 ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }


        public System.Int32 IDGRUPO
        {
            get
            {
                return _idgrupo;
            }
            set
            {
                _idgrupo = value;
            }
        }

        
    }
}