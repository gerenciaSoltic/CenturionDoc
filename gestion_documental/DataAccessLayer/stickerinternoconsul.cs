using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestion_documental.Utils;
using gestion_documental.BusinessObjects;
using MySql.Data.MySqlClient;


namespace gestion_documental.DataAccessLayer
{
    public class stickerinternoconsul
    {


        ConnectionClass conectar = new ConnectionClass();
        #region select

        public static string numerocaja;

        public List<stikerinterno> obtenerstikerinternocondicion()
        {
            int contador = 0;

            var caja = numerocaja.Split(',');

            List<stikerinterno> _stiker = new List<stikerinterno>();
            for (int w = 0; w < caja.Length ; w++)
           {
               contador = 0;

               conectar.Connection.Close();
               conectar.conectar();

               conectar.Connection.Open();
               
               MySqlCommand _comando = new MySqlCommand("SELECT distinct c.documento,c.primerapellido,c.segundoapellido,c.primernombre,c.segundonombre,i.caja,i.numeroorden from controllaboral  c join inventario i on c.documento=i.cedula where i.caja = " + caja[w] + " order by i.caja,i.numeroorden", conectar.Connection);
               MySqlDataReader _reader = _comando.ExecuteReader();
               while (_reader.Read())
               {
                   contador = contador + 1;
                   stikerinterno _stikerinterno = new stikerinterno();
                   _stikerinterno.caja = Convert.ToInt32(_reader.GetString(5));
                   _stikerinterno.nombre = Convert.ToString(_reader.GetString(1)) + " " + Convert.ToString(_reader.GetString(2)) + " " + Convert.ToString(_reader.GetString(3)) + " " + Convert.ToString(_reader.GetString(4));
                   _stikerinterno.cedula = Convert.ToString(_reader.GetString(0));
                   _stikerinterno.numero = Convert.ToInt32(_reader.GetString(6));
                   _stiker.Add(_stikerinterno);

               }


               for (int j = 0; j < _stiker.Count; j++)
               {
                   _stiker[j].numerocarpeta = contador;
               }
              /* for (int i = contador; i < 9; i++)
               {

                   contador = contador + 1;
                   stikerinterno _stikerinterno1 = new stikerinterno();
                   _stikerinterno1.numero = Convert.ToString(contador);
                   _stikerinterno1.caja = Convert.ToString(caja[w]);


                   _stiker.Add(_stikerinterno1);
               }
               */
           }

            conectar.Connection.Close();
            return _stiker;
        }
        #endregion
    }
}