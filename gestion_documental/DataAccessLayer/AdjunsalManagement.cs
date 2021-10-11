using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestion_documental.Utils;
using MySql.Data.MySqlClient;
using System.Data;
using gestion_documental.BusinessObjects;

namespace gestion_documental.DataAccessLayer
{
    public class AdjunsalManagement : ConnectionClass
    {
         #region Constructors
        public AdjunsalManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of fuel types
        /// <returns>List of Type Fuel Types</returns>
        /// </summary>
        public List<Adjunsal> GetAllAdjunsals()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT c.ID ,c.IDCORREO, c.ARCHIVO, c.NEWARCHIVO FROM Adjunsal as c";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Adjunsal> allAdjunsal = new List<Adjunsal>();

                while (dr.Read())
                {
                    Adjunsal myAdjunsal = new Adjunsal();

                    #region Params

                    myAdjunsal.ID = Convert.ToInt32(dr["ID"]);
                    myAdjunsal.IDCORREO = Convert.ToInt32(dr["IDCORREO"]);
                    myAdjunsal.ARCHIVO = dr["ARCHIVO"].ToString();
					myAdjunsal.NEWARCHIVO = dr["NEWARCHIVO"].ToString();

                    #endregion

                    allAdjunsal.Add(myAdjunsal);

                }
                return allAdjunsal;
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
        /// Gets all the details of a Adjunsal
        /// <returns>Adjunsal</returns>
        /// </summary>
        public Adjunsal GetAdjunsalById(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM Adjunsal as c WHERE c.ID = @id ";
            cmdSelect.Parameters.AddWithValue("@id", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                Adjunsal myAdjunsal = new Adjunsal();

                while (dr.Read())
                {

                    #region Params

                    myAdjunsal.ID = Convert.ToInt32(dr["ID"]);
                    myAdjunsal.IDCORREO = Convert.ToInt32(dr["IDCORREO"]);
                    myAdjunsal.ARCHIVO = dr["ARCHIVO"].ToString();
                    myAdjunsal.NEWARCHIVO = dr["NEWARCHIVO"].ToString();

                    #endregion

                }
                return myAdjunsal;
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
        /// Gets all the details of a Adjunsal
        /// <returns>Adjunsal</returns>
        /// </summary>
        public List<Adjunsal> GetAdjunsalByIdCorreo(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM Adjunsal as c WHERE c.IDCORREO = @id ";
            cmdSelect.Parameters.AddWithValue("@id", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Adjunsal> allAdjunsal = new List<Adjunsal>();

                while (dr.Read())
                {
                    Adjunsal myAdjunsal = new Adjunsal();
                    #region Params

                    myAdjunsal.ID = Convert.ToInt32(dr["ID"]);
                    myAdjunsal.IDCORREO = Convert.ToInt32(dr["IDCORREO"]);
                    myAdjunsal.ARCHIVO = dr["ARCHIVO"].ToString();
                    myAdjunsal.NEWARCHIVO = dr["NEWARCHIVO"].ToString();

                    #endregion
                    allAdjunsal.Add(myAdjunsal);
                }
                return allAdjunsal;
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

        #region insert Commands
        /// <summary>
        /// Inserts a new  Ente
        /// <param name="myAdjunsal">Required a filled instance of Ente</param>
        /// </summary>
        public void InsertAdjunsal(Adjunsal myAdjunsal)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "INSERT INTO Adjunsal (IDCORREO,ARCHIVO,NEWARCHIVO ) VALUES (@idcorreo, @archivo, @newarchivo)";

            #region params

            cmdInsert.Parameters.AddWithValue("@idcorreo", myAdjunsal.IDCORREO);
			cmdInsert.Parameters.AddWithValue("@archivo", myAdjunsal.ARCHIVO);
			cmdInsert.Parameters.AddWithValue("@newarchivo", myAdjunsal.NEWARCHIVO);


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

        public void UpdateAdjunsal(Adjunsal myAdjunsal)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = "Update Adjunsal SET  IDCORREO=@idcorreo, ARCHIVO=@archivo,NEWARCHIVO=@newarchivo  where ID=@id";

            #region params

            cmdUpdate.Parameters.AddWithValue("@id", myAdjunsal.ID);
            cmdUpdate.Parameters.AddWithValue("@idcorreo", myAdjunsal.IDCORREO);
            cmdUpdate.Parameters.AddWithValue("@archivo", myAdjunsal.ARCHIVO);
            cmdUpdate.Parameters.AddWithValue("@newarchivo", myAdjunsal.NEWARCHIVO);

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



    }
}