using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class ExpedienteIndice
    {

        public ExpedienteIndice()
        {

            expediente = new Expediente();
            
            
        }

        public ExpedienteIndice indicesexpedientes { get; set; }

        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32 _ID;
        private System.Int32 _IDSERIE;
        private System.Int32 _IDSUBSERIE;
        private System.Int32 _IDTIPOLOGIA;
        private System.Int32 _IDEXPEDIENTE;
        private System.String _ATRIBUTO;
        private System.String _INDICE;

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
        //public List<Tipologia> TIPOLOGIA { get; set; }
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

        public System.Int32 IDSERIE
        {
            get
            {
                return _IDSERIE;
            }
            set
            {
                _IDSERIE = value;
            }
        }

        public System.Int32 IDSUBSERIE
        {
            get
            {
                return _IDSUBSERIE;
            }
            set
            {
                _IDSUBSERIE = value;
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

        
        public System.Int32 IDEXPEDIENTE
        {
            get
            {
                return _IDEXPEDIENTE;
            }
            set
            {
                _IDEXPEDIENTE = value;
            }
        }




        public System.String ATRIBUTO
        {
            get
            {
                return _ATRIBUTO;
            }
            set
            {
                _ATRIBUTO = value;
            }
        }

        public System.String INDICE
        {
            get
            {
                return _INDICE;
            }
            set
            {
                _INDICE = value;
            }
        }


        public Expediente expediente { get; set; }
    }
}