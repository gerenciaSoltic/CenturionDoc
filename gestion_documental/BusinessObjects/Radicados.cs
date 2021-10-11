using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class Radicados
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32 _idradicados;
        private System.Int32 _conseInt;
        private System.Int32 _ConseExtSal;
        private System.Int32 _ConseExtent;
        private System.String _prefInter;
        private System.String _PrefExtSal;
        private System.String _PrefExtEnt;
        private System.DateTime _UltimaFecha;
        private System.String _Radicado;

        private System.Int32 _ConseCorrSal;
        private System.Int32 _ConseCorrEnt;
        private System.String _PrefCorrEnt;
        private System.String _PrefCorrSal;
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
        public System.Int32 idradicados
        {
            get
            {
                return _idradicados;
            }
            set
            {
                _idradicados = value;
            }
        }
        public System.Int32 conseInt
        {
            get
            {
                return _conseInt;
            }
            set
            {
                _conseInt = value;
            }
        }

       
        
        public System.Int32 ConseExtSal
        {
            get
            {
                return _ConseExtSal;
            }
            set
            {
                _ConseExtSal = value;
            }
        }

        public System.Int32 ConseCorrSal
        {
            get
            {
                return _ConseCorrSal;
            }
            set
            {
                _ConseCorrSal = value;
            }
        }

        public System.Int32 ConseCorrEnt
        {
            get
            {
                return _ConseCorrEnt;
            }
            set
            {
                _ConseCorrEnt = value;
            }
        }


        public System.Int32 ConseExtent
        {
            get
            {
                return _ConseExtent;
            }
            set
            {
                _ConseExtent = value;
            }
        }
        public System.String prefInter
        {
            get
            {
                return ajustarAncho(_prefInter, 45);
            }
            set
            {
                _prefInter = value;
            }
        }
        public System.String PrefExtSal
        {
            get
            {
                return ajustarAncho(_PrefExtSal, 45);
            }
            set
            {
                _PrefExtSal = value;
            }
        }

        public System.String PrefCorrSal
        {
            get
            {
                return ajustarAncho(_PrefCorrSal, 45);
            }
            set
            {
                _PrefCorrSal = value;
            }
        }

        public System.String PrefCorrEnt
        {
            get
            {
                return ajustarAncho(_PrefCorrEnt, 45);
            }
            set
            {
                _PrefCorrEnt = value;
            }
        }

        public System.String PrefExtEnt
        {
            get
            {
                return ajustarAncho(_PrefExtEnt, 45);
            }
            set
            {
                _PrefExtEnt = value;
            }
        }
        public System.DateTime UltimaFecha
        {
            get
            {
                return _UltimaFecha;
            }
            set
            {
                _UltimaFecha = value;
            }
        }
        public System.String Radicado
        {
            get
            {
                return ajustarAncho(_Radicado, 100);
            }
            set
            {
                _Radicado = value;
            }
        }
    }
}