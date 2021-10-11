using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestion_documental.Utils;
using gestion_documental.BusinessObjects;
using MySql.Data.MySqlClient;
using System.Data;

namespace gestion_documental.DataAccessLayer
{
    public class EnteRutaManagement : ConnectionClass
    {
        #region Constructors
        public EnteRutaManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of fuel types
        /// <returns>List of Type Fuel Types</returns>
        /// </summary>
        public List<EnteRuta> GetAllEnteRutas()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM enteruta as c";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<EnteRuta> allEnteRutas = new List<EnteRuta>();

                while (dr.Read())
                {
                    EnteRuta myEnte = new EnteRuta();

                    #region Params

                    myEnte.IDENTERUTA = Convert.ToInt32(dr["IDENTERUTA"]);
                    myEnte.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myEnte.CONTENEDOR = dr["CONTENEDOR"].ToString();
                    myEnte.NUMERO = dr["NUMERO"].ToString();
                    myEnte.COMPARTIMIENTO = Convert.ToInt32(dr["COMPARTIMIENTO"]);

                    #endregion

                    allEnteRutas.Add(myEnte);

                }
                return allEnteRutas;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
        }
        public EnteRuta GetAllEnteRutasid(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM enteruta as c where c.identeruta='"+id+"'";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                EnteRuta myEnte = new EnteRuta();

                while (dr.Read())
                {
                    

                    #region Params

                    myEnte.IDENTERUTA = Convert.ToInt32(dr["IDENTERUTA"]);
                    myEnte.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myEnte.CONTENEDOR = dr["CONTENEDOR"].ToString();
                    myEnte.NUMERO = dr["NUMERO"].ToString();
                    myEnte.COMPARTIMIENTO = Convert.ToInt32(dr["COMPARTIMIENTO"]);

                    #endregion

                   

                }
                return myEnte;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
        }


        /// <summary>
        /// Inserts a new  Ente
        /// <param name="myEnte">Required a filled instance of Ente</param>
        /// </summary>
        public void InsertEnteRuta(EnteRuta myEnte)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "INSERT INTO enteruta (IDENTE,CONTENEDOR,NUMERO,COMPARTIMIENTO) VALUES (@IDENTE,@CONTENEDOR,@NUMERO,@COMPARTIMIENTO)";

            #region params

            cmdInsert.Parameters.AddWithValue("@IDENTE", myEnte.IDENTE);
			cmdInsert.Parameters.AddWithValue("@CONTENEDOR", myEnte.CONTENEDOR);
            cmdInsert.Parameters.AddWithValue("@NUMERO", myEnte.NUMERO);
            cmdInsert.Parameters.AddWithValue("@COMPARTIMIENTO", myEnte.COMPARTIMIENTO);
            #endregion

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                cmdInsert.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
        }

        #region UPDATE Commands

        public void UpdateEnte(EnteRuta myEnte)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = "Update enteruta SET  IDENTE=@IDENTE,CONTENEDOR=@CONTENEDOR,NUMERO=@NUMERO,COMPARTIMIENTO = @COMPARTIMIENTO where IDENTERUTA=@IDENTERUTA";

            #region params

            cmdUpdate.Parameters.AddWithValue("@IDENTERUTA", myEnte.IDENTERUTA);
            cmdUpdate.Parameters.AddWithValue("@IDENTE", myEnte.IDENTE);
            cmdUpdate.Parameters.AddWithValue("@CONTENEDOR", myEnte.CONTENEDOR);
            cmdUpdate.Parameters.AddWithValue("@NUMERO", myEnte.NUMERO);
            cmdUpdate.Parameters.AddWithValue("@COMPARTIMIENTO", myEnte.COMPARTIMIENTO);
            #endregion

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                cmdUpdate.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
        }

        #endregion





        /// <summary>
        /// Gets all the details of a Fuel
        /// <returns>Fuel Type</returns>
        /// </summary>
        public EnteRuta GetEnteRutaById(int identeRuta)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM enteruta as c WHERE c.IDENTERUTA = @IDENTERUTA ";
            cmdSelect.Parameters.AddWithValue("@IDENTERUTA", identeRuta);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                EnteRuta myEnte = new EnteRuta();

                while (dr.Read())
                {

                    #region Params
                    myEnte.IDENTERUTA = Convert.ToInt32(dr["IDENTERUTA"]);
                    myEnte.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myEnte.CONTENEDOR = dr["CONTENEDOR"].ToString();
                    myEnte.NUMERO = dr["NUMERO"].ToString();
                    myEnte.COMPARTIMIENTO = Convert.ToInt32(dr["COMPARTIMIENTO"]);
                    #endregion

                }
                return myEnte;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
        }



        public List<EnteRuta> GetEnteRutaByIdEnte(int idente)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM enteruta as c WHERE c.IDENTE = @IDENTE ";
            cmdSelect.Parameters.AddWithValue("@IDENTE", idente);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                
                List<EnteRuta> allEnteRutas = new List<EnteRuta>();
                while (dr.Read())
                {

                    #region Params
                    EnteRuta myEnte = new EnteRuta();
                    myEnte.IDENTERUTA = Convert.ToInt32(dr["IDENTERUTA"]);
                    myEnte.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myEnte.CONTENEDOR = dr["CONTENEDOR"].ToString();
                    myEnte.NUMERO = dr["NUMERO"].ToString();
                    myEnte.COMPARTIMIENTO = Convert.ToInt32(dr["COMPARTIMIENTO"]);
                    #endregion
                    allEnteRutas.Add(myEnte);
                }
                return allEnteRutas;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
        }




        #endregion


        #region DELETE Commands
        /// <summary>
        /// Delete Ente
        /// <param name="id">Required a filled instance of Ente</param>
        /// </summary>
        public bool DeleteEnteRuta(int idEnteRuta)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM enteruta WHERE IDENTERUTA=@IDENTERUTA";

            #region params

            cmdInsert.Parameters.AddWithValue("@IDENTERUTA", idEnteRuta);

            #endregion

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                cmdInsert.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                return false;
                throw ex;
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }

            return true;
        }
        #endregion
    }
}