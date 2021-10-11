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
    public class AtributosManagement : ConnectionClass
    {
        #region Sql
        private string DefaultSelect =
                @"SELECT 
                    c.id , 
                    c.atributo 
                    
                    FROM atributos as c ";

        #endregion

        #region Constructors
        public AtributosManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of Cargo
        /// <returns>List of Type Cargo</returns>
        /// </summary>
        public List<Atributos> GetAllAtributos()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = this.DefaultSelect;

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Atributos> allAtributos = new List<Atributos>();

                while (dr.Read())
                {
                    Atributos myEnte = new Atributos();

                    #region Params

                    myEnte.ID = Convert.ToInt32(dr["ID"]);
                    myEnte.ATRIBUTO = dr["ATRIBUTO"].ToString();

                    #endregion

                    allAtributos.Add(myEnte);

                }
                return allAtributos;
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
        public Atributos GetAtributosById(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE c.id = @id ";
            cmdSelect.Parameters.AddWithValue("@id", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                Atributos myEnte = new Atributos();

                while (dr.Read())
                {

                    #region Params

                    myEnte.ID = Convert.ToInt32(dr["id"]);
                    myEnte.ATRIBUTO = dr["atributo"].ToString();

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
        public void InsertAtributos(Atributos myEnte)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "INSERT INTO atributos (atributo) VALUES (@atributo)";

            #region params

            cmdInsert.Parameters.AddWithValue("@atributo", myEnte.ATRIBUTO);

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
        #endregion

        #region UPDATE Commands

        public void UpdateAtributos(Atributos myEnte)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = "Update atributos SET  atributo=@atributo where id=@id";

            #region params

            cmdUpdate.Parameters.AddWithValue("@id", myEnte.ID);
            cmdUpdate.Parameters.AddWithValue("@atributo", myEnte.ATRIBUTO);

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
        public bool DeleteAtributos(int id)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM atributos WHERE id=@id";

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