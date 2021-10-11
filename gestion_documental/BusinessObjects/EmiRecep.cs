using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class EmiRecep
    {
        public EmiRecep()
        {
            cargo = new Cargo();
            conficor = new ConfiCor();
            ente = new Ente();
            tipoemisor = new TipoEmiRec();
            usuario = new Usuarios();
            radicados = new Radicados();
        }

        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32 	_ID					;
        private System.String 	_NIT				;
        private System.String 	_DESCRIPCION		;
        private System.String 	_DIRECCIONFISICA	;
        private System.Int32 	_PAIS				;
        private System.Int32 	_DEPARTAMENTO		;
        private System.Int32 	_MUNICIPIO			;
        private System.String 	_EMAIL				;
        private System.String 	_CONTRASENAEMAIL	;
        private System.String 	_FOTO				;
        private System.String 	_TELEFONO			;
        private System.Int32 	_CODIGOUSUARIO		;
        private System.Int32 	_IDTIPOEMISOR		;
        private System.Int32 	_IDCONFICOR			;
        private System.Int32 	_IDENTE				;
        private System.Int32 	_IDCARGO			;
        private System.Int32    _IDRADICADO         ;
        private System.Int32    _LOCAL              ;
        private System.Int32    _ACTUALIZADO        ;
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

        public Cargo cargo { get; set; }
        public ConfiCor conficor { get; set; }
        public Ente ente { get; set; }
        public TipoEmiRec tipoemisor { get; set; }
        public Usuarios usuario { get; set; }
        public Radicados radicados { get; set; }

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
        public System.String NIT
        {
            get
            {
                return ajustarAncho(_NIT, 20);
            }
            set
            {
                _NIT = value;
            }
        }
        public System.String DESCRIPCION
        {
            get
            {
                return ajustarAncho(_DESCRIPCION, 200);
            }
            set
            {
                _DESCRIPCION = value;
            }
        }
        public System.String DIRECCIONFISICA
        {
            get
            {
                return ajustarAncho(_DIRECCIONFISICA, 100);
            }
            set
            {
                _DIRECCIONFISICA = value;
            }
        }
        public System.Int32 PAIS
        {
            get
            {
                return _PAIS;
            }
            set
            {
                _PAIS = value;
            }
        }
        public System.Int32 DEPARTAMENTO
        {
            get
            {
                return _DEPARTAMENTO;
            }
            set
            {
                _DEPARTAMENTO = value;
            }
        }
        public System.Int32 MUNICIPIO
        {
            get
            {
                return _MUNICIPIO;
            }
            set
            {
                _MUNICIPIO = value;
            }
        }
        public System.String EMAIL
        {
            get
            {
                return ajustarAncho(_EMAIL, 200);
            }
            set
            {
                _EMAIL = value;
            }
        }
        public System.String CONTRASENAEMAIL
        {
            get
            {
                return ajustarAncho(_CONTRASENAEMAIL, 20);
            }
            set
            {
                _CONTRASENAEMAIL = value;
            }
        }
        public System.String FOTO
        {
            get
            {
                return ajustarAncho(_FOTO, 100);
            }
            set
            {
                _FOTO = value;
            }
        }
        public System.String TELEFONO
        {
            get
            {
                return ajustarAncho(_TELEFONO, 20);
            }
            set
            {
                _TELEFONO = value;
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
        public System.Int32 IDTIPOEMISOR
        {
            get
            {
                return _IDTIPOEMISOR;
            }
            set
            {
                _IDTIPOEMISOR = value;
            }
        }
        public System.Int32 IDCONFICOR
        {
            get
            {
                return _IDCONFICOR;
            }
            set
            {
                _IDCONFICOR = value;
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
        public System.Int32 IDCARGO
        {
            get
            {
                return _IDCARGO;
            }
            set
            {
                _IDCARGO = value;
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
    }
}