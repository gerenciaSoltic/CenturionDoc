using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class HistoriaLaboral
    {
        public HistoriaLaboral()
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

        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.DateTime _FECHACARGA;
        private System.String _DESCRIPCION;
        private System.String _DOCUMENTO;

        public System.DateTime FECHACARGA
        {
            get
            {
                return _FECHACARGA;
            }
            set
            {
                _FECHACARGA = value;
            }
        }

        public System.String DESCRIPCION
        {
            get
            {
                return _DESCRIPCION;
            }
            set
            {
                _DESCRIPCION = value;
            }
        }



        public System.String DOCUMENTO
        {
            get
            {
                return _DOCUMENTO;
            }
            set
            {
                _DOCUMENTO = value;
            }
        }

    }
}