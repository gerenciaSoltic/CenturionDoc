using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestion_documental.Utils;
using gestion_documental.BusinessObjects;
using MySql.Data.MySqlClient;

namespace gestion_documental.DataAccessLayer
{
    public class tipodocumentoconsul
    {
        ConnectionClass conectar = new ConnectionClass();
        #region selec

        public List<tipodocumento> obtenertipohisto()
        {

            conectar.Connection.Close();
            conectar.conectar();

            conectar.Connection.Open();
            List<tipodocumento> _listipodocumento = new List<tipodocumento>();
            MySqlCommand _comando = new MySqlCommand("SELECT ID,TIPOLOGIA from TIPOLOGIA ORDER BY TIPOLOGIA ASC", conectar.Connection);
            MySqlDataReader _reader = _comando.ExecuteReader();
            tipodocumento _tipodoc0 = new tipodocumento();
            _listipodocumento.Add(_tipodoc0);
            while (_reader.Read())
            {
                tipodocumento _tipodoc = new tipodocumento();
                _tipodoc.id = Convert.ToString(_reader.GetString(0));
                _tipodoc.nombre = Convert.ToString(_reader.GetString(1));
                _listipodocumento.Add(_tipodoc);
            }
            conectar.Connection.Close();
            return _listipodocumento;
        }

        public List<tipodocumento> obtenertipoesca()
        {

            conectar.Connection.Close();
            conectar.conectar();

            conectar.Connection.Open();
            List<tipodocumento> _listipodocumento = new List<tipodocumento>();
            MySqlCommand _comando = new MySqlCommand("SELECT * from tipodocumento where idinstitucion='" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + "' and tipo='ESCALAFON' and ocultar='0' ORDER BY nombre ASC", conectar.Connection);
            MySqlDataReader _reader = _comando.ExecuteReader();
            tipodocumento _tipodoc0 = new tipodocumento();
            _listipodocumento.Add(_tipodoc0);
            while (_reader.Read())
            {
                tipodocumento _tipodoc = new tipodocumento();
                _tipodoc.id = Convert.ToString(_reader.GetString(0));
                _tipodoc.nombre = Convert.ToString(_reader.GetString(1));
                _listipodocumento.Add(_tipodoc);
            }
            conectar.Connection.Close();
            return _listipodocumento;
           
        }
        public List<tipodocumento> obtenertipopres()
        {

            conectar.Connection.Close();
            conectar.conectar();

            conectar.Connection.Open();
            List<tipodocumento> _listipodocumento = new List<tipodocumento>();
            MySqlCommand _comando = new MySqlCommand("SELECT * from tipodocumento where idinstitucion='" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + "' and tipo='PRESTACIONES SOCIALES' and ocultar='0' ORDER BY nombre ASC", conectar.Connection);
            MySqlDataReader _reader = _comando.ExecuteReader();
            tipodocumento _tipodoc0 = new tipodocumento();
            _listipodocumento.Add(_tipodoc0);
            while (_reader.Read())
            {
                tipodocumento _tipodoc = new tipodocumento();
                _tipodoc.id = Convert.ToString(_reader.GetString(0));
                _tipodoc.nombre = Convert.ToString(_reader.GetString(1));
                _listipodocumento.Add(_tipodoc);
            }
            conectar.Connection.Close();
            return _listipodocumento;
        }
        #endregion
    }
}