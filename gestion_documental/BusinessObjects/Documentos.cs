using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class Documentos
    {
        public Documentos()
        {
         //   serie = new Serie();
           // subserie = new SubSerie();
          //  tipologia = new Tipologia();
         //   expediente = new Expediente();
        }

        public Serie serie { get; set; }
        public SubSerie subserie { get; set; }
        public Tipologia tipologia { get; set; }
        public Expediente expediente { get; set; }
        public DocumentoActividad documentoactividad { get; set; }

        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32 _IDSERIE;
        private System.Int32 _IDSUBSERIE;
        private System.Int32 _IDTIPOLOGIA;
        private System.Int32 _idDOCUMENTOS;
        private System.String _DOCUMENTO;
        private System.String _DESCRIPCION;
        private System.String _CAMINO;
        private System.Int32 _IDEXPEDIENTE;
        private System.Int32 _FOLIOS;
        private System.String _ANEXOS;
        private System.Int32 _IDENTE;
        private System.Int32 _VERSION;
        private System.Int32 _CALIDAD;
        private System.String _NOMSERIE;
        private System.String _NOMSUBSERIE;
        private System.String _NOMTIPOLOGIA;
        private System.String _NOMEXPEDIENTE;
        private System.String _RADICADO;
        private System.Int32 _LOCAL;
        private System.Int32 _ACTUALIZADO;
        private System.Int32 _iddocumentoactividad;

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
        public System.Int32 idDOCUMENTOS
        {
            get
            {
                return _idDOCUMENTOS;
            }
            set
            {
                _idDOCUMENTOS = value;
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



        public System.Int32 VERSION
        {
            get
            {
                return _VERSION;
            }
            set
            {
                _VERSION = value;
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

        public System.String DOCUMENTO
        {
            get
            {
                return ajustarAncho(_DOCUMENTO, 250);
            }
            set
            {
                _DOCUMENTO = value;
            }
        }


        public System.String RADICADO
        {
            get
            {
                return ajustarAncho(_RADICADO, 250);
            }
            set
            {
                _RADICADO = value;
            }
        }


        public System.String DESCRIPCION
        {
            get
            {
                return ajustarAncho(_DESCRIPCION, 250);
            }
            set
            {
                _DESCRIPCION = value;
            }
        }
        public System.String CAMINO
        {
            get
            {
                return ajustarAncho(_CAMINO, 500);
            }
            set
            {
                _CAMINO = value;
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
        public System.Int32 FOLIOS
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

        public System.String ANEXOS
        {
            get
            {
                return ajustarAncho(_ANEXOS, 500);
            }
            set
            {
                _ANEXOS = value;
            }
        }

        public System.Int32 IDENTE
        {
            get
            {
                return _IDENTE;
            }
            set
            {
                _IDENTE = value;
            }
        }
        public System.Int32 CALIDAD
        {
            get
            {
                return _CALIDAD;
            }
            set
            {
                _CALIDAD = value;
            }
        }


        public System.String NOMSERIE
        {
            get
            {
                return ajustarAncho(_NOMSERIE, 50);
            }
            set
            {
                _NOMSERIE= value;
            }
        }
        public System.String NOMSUBSERIE
        {
            get
            {
                return ajustarAncho(_NOMSUBSERIE, 50);
            }
            set
            {
                _NOMSUBSERIE = value;
            }
        }

        public System.String NOMTIPOLOGIA
        {
            get
            {
                return ajustarAncho(_NOMTIPOLOGIA, 50);
            }
            set
            {
                _NOMTIPOLOGIA = value;
            }
        }

        public System.String NOMEXPEDIENTE
        {
            get
            {
                return ajustarAncho(_NOMEXPEDIENTE, 50);
            }
            set
            {
                _NOMEXPEDIENTE = value;
            }
        }

        public System.Int32 LOCAL
        {
            get
            {
                return _LOCAL;
            }
            set
            {
                _LOCAL = value;
            }
        }
        
        public System.Int32 ACTUALIZADO
        {
            get
            {
                return _ACTUALIZADO;
            }
            set
            {
                _ACTUALIZADO = value;
            }
        }

        public System.Int32 iddocumentoactividad
        {
            get
            {
                return _iddocumentoactividad;
            }
            set
            {
                _iddocumentoactividad = value;
            }
        }
    }
}