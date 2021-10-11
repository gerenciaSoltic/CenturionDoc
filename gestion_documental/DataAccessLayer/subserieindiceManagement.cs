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
    public class subserieIndiceManagement : ConnectionClass
    {
        #region Sql
        private string DefaultSelect =
                @"SELECT 
                    c.id , 
                    c.idserie
                    c.idsubserie,
                    c.Atributo
                    FROM subserieIndice as c ";

        #endregion

        #region Constructors
        public subserieIndiceManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of Indices
        /// <returns>List of Type Indices</returns>
        /// </summary>
        public List<subserieIndice> GetAllsubserieIndice(int idserie,int idsubserie)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = @"SELECT 
                    c.id , 
                    c.idserie,
                    c.idsubserie,
                    c.Atributo
                    FROM subserieIndice as c WHERE idserie="+idserie.ToString()+" AND idsubserie ="+idsubserie.ToString();

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<subserieIndice> allEntes = new List<subserieIndice>();
                

                while (dr.Read())
                {
                    subserieIndice myEnte = new subserieIndice();

                    #region Params

                    myEnte.ID = Convert.ToInt32(dr["id"]);
                    myEnte.IDSERIE = Convert.ToInt32(dr["idserie"]);
                    myEnte.IDSUBSERIE = Convert.ToInt32(dr["idsubserie"]);
                    myEnte.ATRIBUTO = dr["ATRIBUTO"].ToString();
                    myEnte.INDICE = "";

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
        /// Gets all the details of a Indices
        /// <returns>Indices</returns>
        /// </summary>
        public subserieIndice GetsubserieindiceById(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM subserieindice as c WHERE c.id = @id";
            cmdSelect.Parameters.AddWithValue("@id", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                subserieIndice myEnte = new subserieIndice();

                while (dr.Read())
                {

                    #region Params

                    myEnte.ID = Convert.ToInt32(dr["id"]);
                    myEnte.IDSERIE = Convert.ToInt32(dr["idserie"]);
                    myEnte.IDSUBSERIE = Convert.ToInt32(dr["idsubserie"]);
                    myEnte.ATRIBUTO = dr["ATRIBUTO"].ToString();


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
        /// Inserts a new  Indices
        /// <param name="myEnte">Required a filled instance of Indices</param>
        /// </summary>
        public int Insertsubserieindice(subserieIndice myEnte)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "INSERT INTO subserieindice (idserie,idsubserie,atributo) VALUES (@idserie,@idsubserie,@atributo);SELECT LAST_INSERT_ID()";

            #region params

            cmdInsert.Parameters.AddWithValue("@idserie", myEnte.IDSERIE);
            cmdInsert.Parameters.AddWithValue("@idsubserie", myEnte.IDSUBSERIE);
            cmdInsert.Parameters.AddWithValue("@atributo", myEnte.ATRIBUTO);

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

        public void UpdatesubserieIndice(subserieIndice myEnte)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = "Update subserieIndice SET idserie=@idsubserie, atributo=@atributo where id=@id";

            #region params

            cmdUpdate.Parameters.AddWithValue("@id", myEnte.ID);
            cmdUpdate.Parameters.AddWithValue("@idserie", myEnte.IDSERIE);
            cmdUpdate.Parameters.AddWithValue("@idsubserie", myEnte.IDSUBSERIE);
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
        /// Delete Indices
        /// <param name="id">Required a filled instance of Indices</param>
        /// </summary>
        public bool DeletesubserieIndice(int id)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM subserieIndice WHERE id=@id";

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