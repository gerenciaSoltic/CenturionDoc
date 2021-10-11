using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class InfWorkflow
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.String _CODENTE;
        private System.String _ENTE;
        private System.String _CODSERIE;
        private System.String _SERIE;
        private System.String _CODSUBSERIE;
        private System.String _SUBSERIE;
        private System.String _CODTIPOLOGIA;
        private System.String _TIPOLOGIA;
        

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

        public System.String CODENTE
        {
            get
            {
                return ajustarAncho(_CODENTE, 10);
            }
            set
            {
                _CODENTE= value;
            }
        }


        public System.String ENTE
        {
            get
            {
                return ajustarAncho(_ENTE, 10);
            }
            set
            {
                _ENTE = value;
            }
        }


        
        public System.String CODSERIE
        {
            get
            {
                return ajustarAncho(_CODSERIE, 10);
            }
            set
            {
                _CODSERIE = value;
            }
        }

        public System.String SERIE
        {
            get
            {
                return ajustarAncho(_SERIE, 255);
            }
            set
            {
                _SERIE = value;
            }
        }

        public System.String CODSUBSERIE
        {
            get
            {
                return ajustarAncho(_CODSUBSERIE, 10);
            }
            set
            {
                _CODSUBSERIE = value;
            }
        }
        public System.String SUBSERIE
        {
            get
            {
                return ajustarAncho(_SUBSERIE, 255);
            }
            set
            {
                _SUBSERIE = value;
            }
        }

        public System.String CODTIPOLOGIA
        {
            get
            {
                return ajustarAncho(_CODTIPOLOGIA, 10);
            }
            set
            {
                _CODTIPOLOGIA = value;
            }
        }

        public System.String TIPOLOGIA
        {
            get
            {
                return ajustarAncho(_TIPOLOGIA, 255);
            }
            set
            {
                _TIPOLOGIA = value;
            }
        }
       
    }
}