using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestion_documental.Utils;
using gestion_documental.BusinessObjects;
using MySql.Data.MySqlClient;

namespace gestion_documental.DataAccessLayer
{
    public class controlloboralconsul
    {
        ConnectionClass conectar = new ConnectionClass();
        #region selec

        public static string documento;
        

        public List<controllaboral> obtenerregistrocondicion()
        {

            conectar.Connection.Close();
            conectar.conectar();

            conectar.Connection.Open();
            List<controllaboral> _control = new List<controllaboral>();
            MySqlCommand _comando = new MySqlCommand("SELECT c.*,t.nombre from controllaboral c join tipodocumento t on c.tipodocumental=t.id where c.idinstitucion='" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + "' and documento='" + documento + "'", conectar.Connection);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                controllaboral _controllaboral = new controllaboral();
                _controllaboral.primernombre = Convert.ToString(_reader.GetString(1));
                _controllaboral.funcionario = Convert.ToString(_reader.GetString(2));
                _controllaboral.identidad = Convert.ToString(_reader.GetString(3));
                _controllaboral.documento = Convert.ToString(_reader.GetString(4));
                _controllaboral.fecha = Convert.ToString(_reader.GetString(5));
                _controllaboral.tipodocumental = Convert.ToString(_reader.GetString(21));
                _controllaboral.folios = Convert.ToString(_reader.GetString(7));
                _controllaboral.seccion = Convert.ToString(_reader.GetString(9));
                _controllaboral.serie = _reader.GetInt32(10);
                _controllaboral.subserie = _reader.GetInt32(11);
                _controllaboral.segundonombre = Convert.ToString(_reader.GetString(12));
                _controllaboral.primerapellido = Convert.ToString(_reader.GetString(13));
                _controllaboral.segundoapellido = Convert.ToString(_reader.GetString(14));
               // _controllaboral.tipodocumento = Convert.ToString(_reader.GetString(15));
               // _controllaboral.fechanacimiento = Convert.ToString(_reader.GetString(16));
               // _controllaboral.genero = Convert.ToString(_reader.GetString(17));
                _controllaboral.carpeta = Convert.ToString(_reader.GetString(18));


                _control.Add(_controllaboral);
            }

            return _control;
        }
        #endregion
    }
}