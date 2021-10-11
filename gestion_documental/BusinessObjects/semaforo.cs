using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class Semaforo
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32  _VERDESDE;
        private System.Int32 _VERHASTA;
        private System.Int32 _NARDESDE;
        private System.Int32 _NARHASTA;
        private System.Int32 _ROJDESDE;
        private System.Int32 _ROJHASTA;
        
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
        public System.Int32 VERDESDE
        {
            get
            {
                return _VERDESDE;
            }
            set
            {
                _VERDESDE = value;
            }
        }
        public System.Int32 VERHASTA
        {
            get
            {
                return _VERHASTA;
            }
            set
            {
                _VERHASTA = value;
            }
        }

        public System.Int32 NARDESDE
        {
            get
            {
                return _NARDESDE;
            }
            set
            {
                _NARDESDE = value;
            }
        }

        public System.Int32 NARHASTA
        {
            get
            {
                return _NARHASTA;
            }
            set
            {
                _NARHASTA = value;
            }
        }

        public System.Int32 ROJDESDE
        {
            get
            {
                return _ROJDESDE;
            }
            set
            {
                _ROJDESDE = value;
            }
        }

        public System.Int32 ROJHASTA
        {
            get
            {
                return _ROJHASTA;
            }
            set
            {
                _ROJHASTA = value;
            }
        }
        
    }
}