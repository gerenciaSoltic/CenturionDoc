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
    public class CadenasManagement : ConnectionClass
    {
        #region Sql
        private string DefaultSelect =
                @"SELECT 
                    *
                    
                    FROM cadenas as c ";

        #endregion

        #region Constructors
        public CadenasManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of Cargo
        /// <returns>List of Type Cargo</returns>
        /// </summary>
        public List<Cadenas> GetAllCadenas()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = this.DefaultSelect;

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Cadenas> allEntes = new List<Cadenas>();

                while (dr.Read())
                {
                    Cadenas myEnte = new Cadenas();

                    #region Params

                    myEnte.ID = Convert.ToInt32(dr["ID"]);
                    myEnte.FECHA = Convert.ToDateTime(dr["FECHA"].ToString());
                    

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
        /// Gets all the details of a Cargo
        /// <returns>Cargo</returns>
        /// </summary>
        public Cadenas GetCadenasById(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE c.id = @id ";
            cmdSelect.Parameters.AddWithValue("@id", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                Cadenas myEnte = new Cadenas();

                while (dr.Read())
                {

                    #region Params

                    myEnte.ID = Convert.ToInt32(dr["ID"]);
                    myEnte.FECHA = Convert.ToDateTime(dr["FECHA"].ToString());
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
        
        #region INSERT Commands
        /// <summary>
        /// Inserts a new  Cargo
        /// <param name="myEnte">Required a filled instance of Cargo</param>
        /// </summary>
        public int InsertCadenas(Cadenas myEnte)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "INSERT INTO cadenas (fecha) VALUES (@fecha);SELECT LAST_INSERT_ID()";

            #region params

            cmdInsert.Parameters.AddWithValue("@fecha", myEnte.FECHA);
           
            #endregion
            int id = 0;
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                id = Convert.ToInt32(cmdInsert.ExecuteScalar());
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
            return id;
        }
        #endregion

        #region UPDATE Commands

        public void UpdateCadenas(Cadenas myEnte)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = "Update cadenas SET  FECHA=@FECHA where id=@id";

            #region params

            cmdUpdate.Parameters.AddWithValue("@id", myEnte.ID);
            cmdUpdate.Parameters.AddWithValue("@FECHA", myEnte.FECHA);
            
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


        #region DELETE Commands
        /// <summary>
        /// Delete Cargo
        /// <param name="id">Required a filled instance of Cargo</param>
        /// </summary>
        public bool DeleteCadenas(int id)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM cadenas WHERE id=@id";

            #region params

            cmdInsert.Parameters.AddWithValue("@id", id);

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
            return true;
        }
        #endregion
    }
}