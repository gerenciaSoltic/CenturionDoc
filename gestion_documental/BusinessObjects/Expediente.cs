using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class Expediente
    {

        public Expediente()
        {
            serie = new Serie();
            tipologia = new Tipologia();
            subserie = new SubSerie();
            
        }

        public Serie serie { get; set; }
        public Tipologia tipologia { get; set; }
        public SubSerie subserie { get; set; }
       

        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32 _id;
        private System.Int32 _idserie;
        private System.Int32 _idsubserie;
        private System.Int32 _idtipologia;
        private System.String _descripcion;
        private System.DateTime _Fechainicio;
        private System.DateTime _Fechafinal;
        private System.String _fasearchivo;
        private System.String _contenedor;
        private System.Int32 _compartimiento;
        private System.Int32 _idunidad;
        private System.Int32 _idente;
        private System.String _codigo;
        private System.Int32 _unidad;
        private System.String _numerounidad;
        private System.Int32 _unidad2;
        private System.Int32 _numerounidad2;
        private System.String _numerodeidentificacion;
        
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
        public System.Int32 idserie
        {
            get
            {
                return _idserie;
            }
            set
            {
                _idserie = value;
            }
        }
        public System.Int32 idsubserie
        {
            get
            {
                return _idsubserie;
            }
            set
            {
                _idsubserie = value;
            }
        }
        public System.Int32 idtipologia
        {
            get
            {
                return _idtipologia;
            }
            set
            {
                _idtipologia = value;
            }
        }


        public System.String descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                _descripcion = value;
            }
        }


        public System.DateTime Fechainicio
        {
            get
            {
                return _Fechainicio;
            }
            set
            {
                _Fechainicio = value;
            }
        }


        public System.DateTime Fechafinal
        {
            get
            {
                return _Fechafinal;
            }
            set
            {
                _Fechafinal = value;
            }
        }

        public System.Int32 compartimiento
        {
            get
            {
                return _compartimiento;
            }
            set
            {
                _compartimiento = value;
            }
        }

        public System.Int32 idunidad
        {
            get
            {
                return _idunidad;
            }
            set
            {
                _idunidad = value;
            }
        }

        public System.Int32 idente
        {
            get
            {
                return _idente;
            }
            set
            {
                _idente = value;
            }
        }


        public System.String contenedor
        {
            get
            {
                return _contenedor;
            }
            set
            {
                _contenedor = value;
            }
        }

        public System.String fasearchivo
        {
            get
            {
                return _fasearchivo;
            }
            set
            {
                _fasearchivo = value;
            }
        }
        public System.String codigo
        {
            get
            {
                return _codigo;
            }
            set
            {
                _codigo = value;
            }
        }
        public System.Int32 unidad
        {
            get
            {
                return _unidad;
            }
            set
            {
                _unidad = value;
            }
        }
        public System.String numerounidad
        {
            get
            {
                return _numerounidad;
            }
            set
            {
                _numerounidad = value;
            }
        }
        public System.Int32 numerounidad2
        {
            get
            {
                return _numerounidad2;
            }
            set
            {
                _numerounidad2 = value;
            }
        }
        public System.Int32 unidad2
        {
            get
            {
                return _unidad2;
            }
            set
            {
                _unidad2 = value;
            }
        }
        public System.String numerodeidentificacion
        {
            get
            {
                return _numerodeidentificacion;
            }
            set
            {
                _numerodeidentificacion = value;
            }
        }

        
    }
}