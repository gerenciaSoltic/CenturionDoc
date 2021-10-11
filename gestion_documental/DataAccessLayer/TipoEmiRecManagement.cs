using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestion_documental.Utils;
using MySql.Data.MySqlClient;
using gestion_documental.BusinessObjects;
using System.Data;

namespace gestion_documental.DataAccessLayer
{
    public class TipoEmiRecManagement:ConnectionClass
    {
        #region Constructors
        public TipoEmiRecManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of fuel types
        /// <returns>List of Type Fuel Types</returns>
        /// </summary>
        public List<TipoEmiRec> GetAllTipoEmiRecs()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT c.ID , c.DESCRIPCION FROM TipoEmiRecas c";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<TipoEmiRec> allTipoEmiRecs = new List<TipoEmiRec>();

                while (dr.Read())
                {
                    TipoEmiRec myTipoEmiRec = new TipoEmiRec();

                    #region Params

                    myTipoEmiRec.ID = Convert.ToInt32(dr["ID"]);
                    myTipoEmiRec.DESCRIPCION = dr["DESCRIPCION"].ToString();
                    myTipoEmiRec.DESCRIPCION = dr["RADRESP"].ToString();

                    #endregion

                    allTipoEmiRecs.Add(myTipoEmiRec);

                }
                return allTipoEmiRecs;
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
        /// Inserts a new  TipoEmiRec
        /// <param name="myTipoEmiRec">Required a filled instance of TipoEmiRec</param>
        /// </summary>
        public void InsertTipoEmiRec(TipoEmiRec myTipoEmiRec)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "INSERT INTO TipoEmiRec (DESCRIPCION) VALUES (@descripcion)";

            #region params

            cmdInsert.Parameters.AddWithValue("@descripcion", myTipoEmiRec.DESCRIPCION);

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

        public void UpdateTipoEmiRec(TipoEmiRec myTipoEmiRec)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = "Update TipoEmiRec SET  DESCRIPCION=@descripcion where id=@id";

            #region params

            cmdUpdate.Parameters.AddWithValue("@id", myTipoEmiRec.ID);
            cmdUpdate.Parameters.AddWithValue("@descripcion", myTipoEmiRec.DESCRIPCION);

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
        public TipoEmiRec GetTipoEmiRecById(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM TipoEmiRec as c WHERE c.ID = @id ";
            cmdSelect.Parameters.AddWithValue("@id", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                TipoEmiRec myTipoEmiRec = new TipoEmiRec();

                while (dr.Read())
                {

                    #region Params

                    myTipoEmiRec.ID = Convert.ToInt32(dr["ID"]);
                    myTipoEmiRec.DESCRIPCION = dr["DESCRIPCION"].ToString();

                    #endregion

                }
                return myTipoEmiRec;
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
    }
}