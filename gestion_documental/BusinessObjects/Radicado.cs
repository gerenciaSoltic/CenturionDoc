using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class Radicado
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.String _RADICADO;
        private System.String _FECHAHORA;
        private System.String _REMITE;
        private System.String _DESTINATARIO;
        private System.String _ANEXOS;
        private System.String _FOLIOS;


        //
        // Las propiedades públicas
        // TODO: Revisar los tipos de las propiedades
        


        public System.String RADICADO
        {
            get
            {
                return _RADICADO;
            }
            set
            {
                _RADICADO = value;
            }
        }

        public System.String FECHAHORA
        {
            get
            {
                return _FECHAHORA;
            }
            set
            {
                _FECHAHORA = value;
            }
        }

        public System.String REMITE
        {
            get
            {
                return _REMITE;
            }
            set
            {
                _REMITE = value;
            }
        }

        public System.String DESTINATARIO
        {
            get
            {
                return _DESTINATARIO;
            }
            set
            {
                _DESTINATARIO = value;
            }
        }

        public System.String ANEXOS
        {
            get
            {
                return _ANEXOS;
            }
            set
            {
                _ANEXOS = value;
            }
        }

        public System.String FOLIOS
        {
            get
            {
                return _FOLIOS;
            }
            set
            {
                _FOLIOS = value;
            }
        }


    }
}