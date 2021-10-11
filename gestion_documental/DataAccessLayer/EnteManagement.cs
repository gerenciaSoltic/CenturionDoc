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
    public class EnteManagement : ConnectionClass
    {
        #region Constructors
        public EnteManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of fuel types
        /// <returns>List of Type Fuel Types</returns>
        /// </summary>
        public List<Ente> GetAllEntes()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT c.IDENTE ,c.CODIGO, c.DESCRIPCION ,IF(c.Archivadores IS NULL, '0', c.Archivadores) as Archivadores, IF(c.Estantes IS NULL, '0', c.Estantes) as Estantes  ,IF(c.Bandejas IS NULL, '0', c.Bandejas) as Bandejas ,IF(c.Gavetas IS NULL, '0', c.Gavetas) as Gavetas FROM ente as c";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Ente> allEntes = new List<Ente>();

                while (dr.Read())
                {
                    Ente myEnte = new Ente();

                    #region Params

                    myEnte.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myEnte.CODIGO = dr["CODIGO"].ToString();
                    myEnte.DESCRIPCION = dr["DESCRIPCION"].ToString();
                    myEnte.Archivadores = Convert.ToInt32(dr["Archivadores"].ToString());
                    myEnte.Estantes = Convert.ToInt32(dr["Estantes"].ToString());
                    myEnte.Bandejas = Convert.ToInt32(dr["Bandejas"].ToString());
                    myEnte.Gavetas = Convert.ToInt32(dr["Gavetas"].ToString());

                    #endregion

                    allEntes.Add(myEnte);

                }
                return allEntes;
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
        public void InsertEnte(Ente myEnte)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "INSERT INTO ente (CODIGO,DESCRIPCION) VALUES (@codigo, @descripcion)";

            #region params

            cmdInsert.Parameters.AddWithValue("@codigo", myEnte.CODIGO);
			cmdInsert.Parameters.AddWithValue("@descripcion", myEnte.DESCRIPCION);

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

        public void UpdateEnte(Ente myEnte)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = "Update ente SET  CODIGO=@codigo, DESCRIPCION=@descripcion where IDENTE=@id";

            #region params

            cmdUpdate.Parameters.AddWithValue("@id", myEnte.IDENTE);
            cmdUpdate.Parameters.AddWithValue("@codigo", myEnte.CODIGO);
			cmdUpdate.Parameters.AddWithValue("@descripcion", myEnte.DESCRIPCION);

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
        public Ente GetEnteById(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM ente as c WHERE c.IDENTE = @id ";
            cmdSelect.Parameters.AddWithValue("@id", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                Ente myEnte = new Ente();

                while (dr.Read())
                {

                    #region Params

                    myEnte.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myEnte.CODIGO = dr["CODIGO"].ToString();
					myEnte.DESCRIPCION = dr["DESCRIPCION"].ToString();

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

        #endregion


        #region DELETE Commands
        /// <summary>
        /// Delete Ente
        /// <param name="id">Required a filled instance of Ente</param>
        /// </summary>
        public bool DeleteEnte(int id)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM ente WHERE IDENTE=@IDENTE";

            #region params

            cmdInsert.Parameters.AddWithValue("@IDENTE", id);

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