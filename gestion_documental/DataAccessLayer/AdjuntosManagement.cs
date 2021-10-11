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
    public class AdjuntosManagement : ConnectionClass
    {
         #region Constructors
        public AdjuntosManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of fuel types
        /// <returns>List of Type Fuel Types</returns>
        /// </summary>
        public List<Adjuntos> GetAllAdjuntoss()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT c.ID ,c.IDCORREO, c.ARCHIVO, c.NEWARCHIVO FROM Adjuntos as c";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Adjuntos> allAdjuntos = new List<Adjuntos>();

                while (dr.Read())
                {
                    Adjuntos myAdjuntos = new Adjuntos();

                    #region Params

                    myAdjuntos.ID = Convert.ToInt32(dr["ID"]);
                    myAdjuntos.IDCORREO = Convert.ToInt32(dr["IDCORREO"]);
                    myAdjuntos.ARCHIVO = dr["ARCHIVO"].ToString();
					myAdjuntos.NEWARCHIVO = dr["NEWARCHIVO"].ToString();

                    #endregion

                    allAdjuntos.Add(myAdjuntos);

                }
                return allAdjuntos;
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
        /// Gets all the details of a Adjuntos
        /// <returns>Adjuntos</returns>
        /// </summary>
        public Adjuntos GetAdjuntosById(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM Adjuntos as c WHERE c.ID = @id ";
            cmdSelect.Parameters.AddWithValue("@id", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                Adjuntos myAdjuntos = new Adjuntos();

                while (dr.Read())
                {

                    #region Params

                    myAdjuntos.ID = Convert.ToInt32(dr["ID"]);
                    myAdjuntos.IDCORREO = Convert.ToInt32(dr["IDCORREO"]);
                    myAdjuntos.ARCHIVO = dr["ARCHIVO"].ToString();
                    myAdjuntos.NEWARCHIVO = dr["NEWARCHIVO"].ToString();

                    #endregion

                }
                return myAdjuntos;
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
        /// Gets all the details of a Adjuntos
        /// <returns>Adjuntos</returns>
        /// </summary>
        public List<Adjuntos> GetAdjuntosByIdCorreo(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM Adjuntos as c WHERE c.IDCORREO = @id ";
            cmdSelect.Parameters.AddWithValue("@id", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Adjuntos> allAdjuntos = new List<Adjuntos>();

                while (dr.Read())
                {
                    Adjuntos myAdjuntos = new Adjuntos();
                    #region Params

                    myAdjuntos.ID = Convert.ToInt32(dr["ID"]);
                    myAdjuntos.IDCORREO = Convert.ToInt32(dr["IDCORREO"]);
                    myAdjuntos.ARCHIVO = dr["ARCHIVO"].ToString();
                    myAdjuntos.NEWARCHIVO = dr["NEWARCHIVO"].ToString();

                    #endregion
                    allAdjuntos.Add(myAdjuntos);
                }
                return allAdjuntos;
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
        /// <param name="myAdjuntos">Required a filled instance of Ente</param>
        /// </summary>
        public void InsertAdjuntos(Adjuntos myAdjuntos)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "INSERT INTO Adjuntos (IDCORREO,ARCHIVO,NEWARCHIVO ) VALUES (@idcorreo, @archivo, @newarchivo)";

            #region params

            cmdInsert.Parameters.AddWithValue("@idcorreo", myAdjuntos.IDCORREO);
			cmdInsert.Parameters.AddWithValue("@archivo", myAdjuntos.ARCHIVO);
			cmdInsert.Parameters.AddWithValue("@newarchivo", myAdjuntos.NEWARCHIVO);


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

        public void UpdateAdjuntos(Adjuntos myAdjuntos)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = "Update Adjuntos SET  IDCORREO=@idcorreo, ARCHIVO=@archivo,NEWARCHIVO=@newarchivo  where ID=@id";

            #region params

            cmdUpdate.Parameters.AddWithValue("@id", myAdjuntos.ID);
            cmdUpdate.Parameters.AddWithValue("@idcorreo", myAdjuntos.IDCORREO);
            cmdUpdate.Parameters.AddWithValue("@archivo", myAdjuntos.ARCHIVO);
            cmdUpdate.Parameters.AddWithValue("@newarchivo", myAdjuntos.NEWARCHIVO);

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