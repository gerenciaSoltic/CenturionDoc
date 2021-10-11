using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion_documental.BusinessObjects
{
    public class Ente
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.Int32 _IDENTE;
        private System.String _CODIGO;
        private System.String _DESCRIPCION;
        private System.Int32 _Archivadores;
        private System.Int32 _Estantes;
        private System.Int32 _Bandejas;
        private System.Int32 _Gavetas;
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
        public System.String CODIGO
        {
            get
            {
                return ajustarAncho(_CODIGO, 20);
            }
            set
            {
                _CODIGO = value;
            }
        }
        public System.String DESCRIPCION
        {
            get
            {
                return ajustarAncho(_DESCRIPCION, 255);
            }
            set
            {
                _DESCRIPCION = value;
            }
        }
        public System.Int32 Archivadores
        {
            get
            {
                return _Archivadores;
            }
            set
            {
                _Archivadores = value;
            }
        }
        public System.Int32 Estantes
        {
            get
            {
                return _Estantes;
            }
            set
            {
                _Estantes = value;
            }
        }
        public System.Int32 Bandejas
        {
            get
            {
                return _Bandejas;
            }
            set
            {
                _Bandejas = value;
            }
        }
        public System.Int32 Gavetas
        {
            get
            {
                return _Gavetas;
            }
            set
            {
                _Gavetas = value;
            }
        }
    }
}