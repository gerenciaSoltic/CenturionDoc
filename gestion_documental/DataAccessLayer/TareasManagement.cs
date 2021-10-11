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
    public class TareasManagement : ConnectionClass
    {
        #region Sql
        private string DefaultSelect =
                @"SELECT 
                    c.idtareas , 
                    c.descripcion,
                    IF(c.orden IS NULL, '0', c.orden) as orden

                    FROM Tareas as c ";

        #endregion

        #region Constructors
        public TareasManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of Tareas
        /// <returns>List of Type Tareas</returns>
        /// </summary>
        public List<Tareas> GetAllTareas()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = this.DefaultSelect;

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Tareas> allEntes = new List<Tareas>();

                while (dr.Read())
                {
                    Tareas myEnte = new Tareas();

                    #region Params

                    myEnte.idtareas = Convert.ToInt32(dr["idtareas"]);
                    myEnte.descripcion = dr["descripcion"].ToString();
                    myEnte.orden = aEntero(dr["orden"]);

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
        /// Gets all the details of a Tareas
        /// <returns>Tareas</returns>
        /// </summary>
        public Tareas GetTareasById(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE c.idtareas = @idtareas ";
            cmdSelect.Parameters.AddWithValue("@idtareas", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                Tareas myEnte = new Tareas();

                while (dr.Read())
                {

                    #region Params

                    myEnte.idtareas = Convert.ToInt32(dr["idtareas"]);
                    myEnte.descripcion = dr["descripcion"].ToString();
                    myEnte.orden = Convert.ToInt32(dr["orden"]);

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
        /// Inserts a new  Tareas
        /// <param name="myEnte">Required a filled instance of Tareas</param>
        /// </summary>
        public void InsertTareas(Tareas myEnte)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "INSERT INTO Tareas (descripcion,orden) VALUES (@descripcion,@orden)";

            #region params

            cmdInsert.Parameters.AddWithValue("@descripcion", myEnte.descripcion);
            cmdInsert.Parameters.AddWithValue("@orden", myEnte.orden);

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

        public void UpdateTareas(Tareas myEnte)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = "Update Tareas SET  descripcion=@descripcion, orden=@orden where idtareas=@idtareas";

            #region params

            cmdUpdate.Parameters.AddWithValue("@idtareas", myEnte.idtareas);
            cmdUpdate.Parameters.AddWithValue("@descripcion", myEnte.descripcion);
            cmdUpdate.Parameters.AddWithValue("@orden", myEnte.orden);

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
        /// Delete Tareas
        /// <param name="id">Required a filled instance of Tareas</param>
        /// </summary>
        public bool DeleteTareas(int id)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM Tareas WHERE idtareas=@idtareas";

            #region params

            cmdInsert.Parameters.AddWithValue("@idtareas", id);

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