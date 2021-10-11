using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class Recepcion
    {
        public Recepcion()
        {
            //radicados = new Radicados();
            //enteorigen = new Ente();
            //entedestino = new Ente();
            //tipologia = new Tipologia();
            //documento = new Documentos();
            //expediente = new Expediente();
            //emirecep = new EmiRecep();
        }

        /*
        public Radicados radicados { get; set; }
        public Ente enteorigen { get; set; }
        public Ente entedestino { get; set; }
        public Tipologia tipologia { get; set; }
        public Documentos documento { get; set; }
        public Expediente expediente { get; set; }
        public EmiRecep emirecep { get; set; }
        */

        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        
        private System.String _fecha;
        private System.String _de;
        private System.String _para;
        private System.String _emisor;
        private System.String _radicado;
        private System.Int32 _iddocumento;
        private System.Int32 _folios;
        private System.String _observacion;
        private System.String _semaforo;
        private System.String _respuesta;
        private System.String _fecharespuesta;
        private System.Int32 _Dias;
        private System.Int32 _DiasLimiteVer;
        private System.Int32 _DiasLimiteNar; 
        private System.Int32 _DiasLimiteRoj;
        private System.String _TipoAlarma;
        private System.String _radicado2;
        private System.String _idcadena;
        private System.String _documento;
        private System.String _estado;
        private System.Int32 _CODIGOUSUARIO;

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
        
        public System.String FECHA
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


        public System.String DE
        {
            get
            {
                return ajustarAncho(_de, 150);
            }
            set
            {
                _de = value;
            }
        }

        public System.String PARA
        {
            get
            {
                return ajustarAncho(_para, 150);
            }
            set
            {
                _para = value;
            }
        }


        public System.String EMISOR
        {
            get
            {
                return ajustarAncho(_emisor, 50);
            }
            set
            {
                _emisor = value;
            }
        }


        public System.String RADICADO
        {
            get
            {
                return ajustarAncho(_radicado, 20);
            }
            set
            {
                _radicado = value;
            }
        }
        public System.String observacion
        {
            get
            {
                return _observacion;
            }
            set
            {
                _observacion = value;
            }
        }

        public System.Int32 IDDOCUMENTO
        {
            get
            {
                return _iddocumento;
            }
            set
            {
                _iddocumento = value;
            }
        }

        public System.Int32 folios
        {
            get
            {
                return _folios;
            }
            set
            {
                _folios = value;
            }
        }

        public System.String SEMAFORO
        {
            get
            {
                return ajustarAncho(_semaforo, 20);
            }
            set
            {
                _semaforo = value;
            }
        }
        public System.String RESPUESTA
        {
            get
            {

                return _respuesta;
            }
            set
            {
                _respuesta = value;
            }
        }

        public System.String FECHARESPUESTA
        {
            get
            {

                return _fecharespuesta;
            }
            set
            {
                _fecharespuesta = value;
            }
        }

        public System.Int32 DIAS
        {
            get
            {
                return _Dias;
            }
            set
            {
                _Dias = value;
            }
        }

        public System.Int32 DIASLIMITEVER
        {
            get
            {
                return _DiasLimiteVer;
            }
            set
            {
                _DiasLimiteVer = value;
            }
        }
        public System.Int32 DIASLIMITENAR
        {
            get
            {
                return _DiasLimiteNar;
            }
            set
            {
                _DiasLimiteNar = value;
            }
        }
        public System.Int32 DIASLIMITEROJ
        {
            get
            {
                return _DiasLimiteRoj;
            }
            set
            {
                _DiasLimiteRoj = value;
            }
        }


        public System.String TIPOALARMA
        {
            get
            {
                return ajustarAncho(_TipoAlarma, 20);
            }
            set
            {
                _TipoAlarma = value;
            }
        }

        public System.String RADICADO2
        {
            get
            {
                return ajustarAncho(_radicado2, 20);
            }
            set
            {
                _radicado2 = value;
            }
        }


        public System.String IDCADENA
        {
            get
            {
                return ajustarAncho(_idcadena, 11);
            }
            set
            {
                _idcadena = value;
            }
        }

        public System.String DOCUMENTO
        {
            get
            {
                return _documento;
            }
            set
            {
                _documento = value;
            }
        }

        public System.String ESTADO
        {
            get
            {
                return _estado;
            }
            set
            {
                _estado = value;
            }
        }


        public System.Int32 CODIGOUSARIO
        {
            get
            {
                return _CODIGOUSUARIO;
            }
            set
            {
                _CODIGOUSUARIO = value;
            }
        }

    }
}