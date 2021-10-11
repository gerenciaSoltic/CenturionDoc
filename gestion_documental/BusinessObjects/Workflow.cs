using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class Workflow
    {
        public Workflow()
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
        private System.Int32 _ID;
        private System.DateTime _FECHA;
        private System.String _RADICADO;
        private System.Int32 _IDENTEORIGEN;
        private System.Int32 _IDENTEDESTINO;
        private System.Int32 _DIAS;
        private System.String _OBSERVACION;
        private System.Int32 _IDTIPOLOGIA;
        private System.String _TIPO;
        private System.Int32 _iddocumento;
        private System.Int32 _idexpediente;
        private System.String _estado;
        private System.String _semaforo;
        private System.Int32 _idemirecep;
        private System.String _enteorigen;
        private System.String _entedestino;
        private System.String _emirecep;
        private System.Int32 _idemidestino;
        private System.Int32 _idtarea;
        private System.String _documento;
        private System.Int32 _IDCADENA;
        private System.String _respuesta;
        private System.DateTime _FECHARESPUESTA;
        private System.Int32 _IDRADICADO;
        private System.String _DESTINATARIO;
        private System.String _RADICADO2;
        private System.Int32 _IDTIPOCOM;
        private System.Int32 _LOCAL;
        private System.Int32 _ACTUALIZADO;
        private System.Int32 _CODIGOUSUARIO;
        private System.Int32 _idactividad;
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
        public System.Int32 IDENTEORIGEN
        {
            get
            {
                return _IDENTEORIGEN;
            }
            set
            {
                _IDENTEORIGEN = value;
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

        public System.Int32 IDENTEDESTINO
        {
            get
            {
                return _IDENTEDESTINO;
            }
            set
            {
                _IDENTEDESTINO = value;
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
        public System.String OBSERVACION
        {
            get
            {
                // Seguramente sería mejor sin ajustar el ancho...
                //return ajustarAncho(_OBSERVACION,500);
                return _OBSERVACION;
            }
            set
            {
                _OBSERVACION = value;
            }
        }


        public System.String ESTADO
        {
            get
            {
                // Seguramente sería mejor sin ajustar el ancho...
                //return ajustarAncho(_OBSERVACION,500);
                return _estado;
            }
            set
            {
                _estado = value;
            }
        }



        public System.String SEMAFORO
        {
            get
            {
                // Seguramente sería mejor sin ajustar el ancho...
                //return ajustarAncho(_OBSERVACION,500);
                return _semaforo;
            }
            set
            {
                _semaforo = value;
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
        public System.String TIPO
        {
            get
            {
                return ajustarAncho(_TIPO, 20);
            }
            set
            {
                _TIPO = value;
            }
        }
        public System.Int32 iddocumento
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
        public System.Int32 idexpediente
        {
            get
            {
                return _idexpediente;
            }
            set
            {
                _idexpediente = value;
            }
        }

        public System.Int32 IDTAREA
        {
            get
            {
                return _idtarea;
            }
            set
            {
                _idtarea = value;
            }
        }
        public System.String ENTEORIGEN
        {
            get
            {
                return ajustarAncho(_enteorigen, 20);
            }
            set
            {
                _enteorigen = value;
            }
        }
        public System.String ENTEDESTINO
        {
            get
            {
                return ajustarAncho(_entedestino, 20);
            }
            set
            {
                _entedestino = value;
            }
        }


        public System.String EMIRECEP
        {
            get
            {
                return ajustarAncho(_emirecep, 20);
            }
            set
            {
                _emirecep = value;
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


        public System.Int32 IDCADENA
        {
            get
            {
                return _IDCADENA;
            }
            set
            {
                _IDCADENA = value;
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


        public System.DateTime FECHARESPUESTA
        {
            get
            {
                return _FECHARESPUESTA;
            }
            set
            {
                _FECHARESPUESTA = value;
            }
        }

        public System.Int32 IDRADICADO
        {
            get
            {
                return _IDRADICADO;
            }
            set
            {
                _IDRADICADO = value;
            }
        }

        public System.String DESTINATARIO
        {
            get
            {

                return _DESTINATARIO;
            }
            set
            {
                _DESTINATARIO = value;
            }
        }

        public System.String RADICADO2
        {
            get
            {
                return ajustarAncho(_RADICADO2, 20);
            }
            set
            {
                _RADICADO2 = value;
            }
        }

        public System.Int32 IDTIPOCOM
        {
            get
            {
                return _IDTIPOCOM;
            }
            set
            {
                _IDTIPOCOM = value;
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

        public System.Int32 CODIGOUSUARIO
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

        public System.Int32 idactividad
        {
            get
            {
                return _idactividad;
            }
            set
            {
                _idactividad = value;
            }
        }

    }
}