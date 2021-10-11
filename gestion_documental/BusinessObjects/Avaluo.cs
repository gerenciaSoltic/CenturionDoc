using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class Avaluo
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32 _id;
        private System.String _predio;
        private System.String _anno;
        private System.Int32 _avaluo;
        private System.String _idcontribu;
        private System.String _pago;
        private System.DateTime _fecha;
        private System.Int32 _valor;
        private System.Int32 _porcentaje;
        private System.Int32 _abonocap;
        private System.Int32 _abonoint;
        private System.String _tipopag;
        private System.Int32 _numeropag;
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
        public System.Int32 id
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
        public System.String predio
        {
            get
            {
                return ajustarAncho(_predio, 15);
            }
            set
            {
                _predio = value;
            }
        }
        public System.String anno
        {
            get
            {
                return ajustarAncho(_anno, 4);
            }
            set
            {
                _anno = value;
            }
        }
        public System.Int32 avaluo
        {
            get
            {
                return _avaluo;
            }
            set
            {
                _avaluo = value;
            }
        }
        public System.String idcontribu
        {
            get
            {
                return ajustarAncho(_idcontribu, 20);
            }
            set
            {
                _idcontribu = value;
            }
        }
        public System.String pago
        {
            get
            {
                return ajustarAncho(_pago, 100);
            }
            set
            {
                _pago = value;
            }
        }
        public System.DateTime fecha
        {
            get
            {
                return _fecha;
            }
            set
            {
                _fecha = value;
            }
        }
        public System.Int32 valor
        {
            get
            {
                return _valor;
            }
            set
            {
                _valor = value;
            }
        }
        public System.Int32 porcentaje
        {
            get
            {
                return _porcentaje;
            }
            set
            {
                _porcentaje = value;
            }
        }
        public System.Int32 abonocap
        {
            get
            {
                return _abonocap;
            }
            set
            {
                _abonocap = value;
            }
        }
        public System.Int32 abonoint
        {
            get
            {
                return _abonoint;
            }
            set
            {
                _abonoint = value;
            }
        }
        public System.String tipopag
        {
            get
            {
                return ajustarAncho(_tipopag, 3);
            }
            set
            {
                _tipopag = value;
            }
        }
        public System.Int32 numeropag
        {
            get
            {
                return _numeropag;
            }
            set
            {
                _numeropag = value;
            }
        }
    }
}