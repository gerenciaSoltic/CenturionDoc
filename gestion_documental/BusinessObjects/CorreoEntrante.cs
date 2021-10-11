using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace gestion_documental.BusinessObjects
{
    public class CorreoEntrante
    {
        public CorreoEntrante()
        {
            emisor    =new EmiRecep();
            receptor  =new EmiRecep();
            tipologia = new Tipologia();
            adjuntos = new List<Adjuntos>();

        }
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32 _ID;
        private System.Int32 _IDEMISOR ;
        private System.String _DESCEMISOR;
        private System.Int32 _IDRECEPTOR;
        private System.String _DESCRECEPTOR;
        private System.Int32 _IDTIPOLOGIA;
        private System.String _ASUNTO;
        private System.String _TEXTO;
        private System.String _RADICADO;
        private System.DateTime _FECHA;
        private System.Int32 _PROCESADO;




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

        public EmiRecep emisor      { get; set; }
        public EmiRecep receptor    { get; set; }
        public Tipologia tipologia   { get; set; }
        public List< Adjuntos> adjuntos { get; set; }

        public string auxEmailEmisor { get; set; }
        public int index { get; set; }

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
        public System.Int32 IDEMISOR
        {
            get
            {
                return _IDEMISOR;
            }
            set
            {
                _IDEMISOR = value;
            }
        }
        public System.Int32 IDRECEPTOR
        {
            get
            {
                return _IDRECEPTOR;
            }
            set
            {
                _IDRECEPTOR = value;
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
        public System.String ASUNTO
        {
            get
            {
                return ajustarAncho(_ASUNTO, 200);
            }
            set
            {
                _ASUNTO = value;
            }
        }
        
        public System.String RADICADO
        {
            get
            {
                return ajustarAncho(_RADICADO, 20);
            }
            set
            {
                _RADICADO = value;
            }
        }

        public System.String TEXTO
        {
            get
            {
                // Seguramente sería mejor sin ajustar el ancho...
                //return ajustarAncho(_TEXTO,1000);
                return _TEXTO;
            }
            set
            {
                _TEXTO = value;
            }
        }
        public System.String DESCEMISOR
        {
            get
            {
                // Seguramente sería mejor sin ajustar el ancho...
                //return ajustarAncho(_TEXTO,1000);
                return _DESCEMISOR;
            }
            set
            {
                _DESCEMISOR= value;
            }
        }

        public System.String DESCRECEPTOR
        {
            get
            {
                // Seguramente sería mejor sin ajustar el ancho...
                //return ajustarAncho(_TEXTO,1000);
                return _DESCRECEPTOR;
            }
            set
            {
                _DESCRECEPTOR = value;
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
        public System.Int32 PROCESADO
        {
            get
            {
                return _PROCESADO;
            }
            set
            {
                _PROCESADO = value;
            }
        }
    }
}