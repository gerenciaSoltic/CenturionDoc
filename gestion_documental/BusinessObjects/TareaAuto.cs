using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class TareaAuto
    {
        private System.Int32 _ID;
        private System.DateTime _FECHAINICIA;
        private System.DateTime _ULTIMAFECHA;
        private System.Int32 _DIAS;
        private System.String _ACCION;
        private System.Int32 _idemirecep;
        private System.Int32 _idemidestino;

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
        public System.DateTime FECHAINICIA
        {
            get
            {
                return _FECHAINICIA;
            }
            set
            {
                _FECHAINICIA = value;
            }
        }
        public System.DateTime ULTIMAFECHA
        {
            get
            {
                return _ULTIMAFECHA;
            }
            set
            {
                _ULTIMAFECHA = value;
            }
        }


        public System.Int32 DIAS
        {
            get
            {
                return _DIAS;
            }
            set
            {
                _DIAS = value;
            }
        }

        public System.String ACCION
        {
            get
            {
                // Seguramente sería mejor sin ajustar el ancho...
                //return ajustarAncho(_OBSERVACION,500);
                return _ACCION;
            }
            set
            {
                _ACCION = value;
            }
        }
        public System.Int32 IDEMIDESTINO
        {
            get
            {
                return _idemidestino;
            }
            set
            {
                _idemidestino = value;
            }
        }

        public System.Int32 IDEMIRECEP
        {
            get
            {
                return _idemirecep;
            }
            set
            {
                _idemirecep = value;
            }
        }

    }



}