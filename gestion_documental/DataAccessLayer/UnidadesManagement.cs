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
    public class UnidadesManagement : ConnectionClass
    {
        #region Sql
        private string DefaultSelect =
                @"SELECT 
                    c.IDUNIDADES , 
                    c.DESCRIPCION
                     FROM unidades as c ";

        #endregion

        #region Constructors
        public UnidadesManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of Serie
        /// <returns>List of Type Serie</returns>
        /// </summary>
        public List<unidades> GetAllunidades()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = this.DefaultSelect;

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<unidades> allEntes = new List<unidades>();

                while (dr.Read())
                {
                    unidades myEnte = new unidades();

                    #region Params

                    myEnte.IDUNIDADES = Convert.ToInt32(dr["IDUNIDADES"]);
                    myEnte.DESCRIPCION = dr["DESCRIPCION"].ToString();
                    
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
        /// Gets all the details of a Seriev
        /// <returns>Serie</returns>
        /// </summary>
        public unidades GetUnidadesById(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE c.IDUNIDADES = @ID ";
            cmdSelect.Parameters.AddWithValue("@ID", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                unidades myEnte = new unidades();

                while (dr.Read())
                {

                    #region Params

                    myEnte.IDUNIDADES = Convert.ToInt32(dr["IDUNIDADES"]);
                    myEnte.DESCRIPCION = dr["DESCRIPCION"].ToString();
                    

                    //myEnte.SUBSERIE = new SubSerieManagement().GetAllSubSeriesBySerie(myEnte.ID);
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
        /// Inserts a new  Serie
        /// <param name="myEnte">Required a filled instance of Serie</param>
        /// </summary>
        public void InsertUnidades(unidades myEnte)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "INSERT INTO unidades (DESCRIPCION) VALUES (@DESCRIPCION)";

            #region params

            cmdInsert.Parameters.AddWithValue("@DESCRIPCION", myEnte.DESCRIPCION);
            

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

        public void UpdateUnidades(unidades myEnte)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = "Update unidades SET  DESCRIPCION=@DESCRIPCION where IDUNIDADES=@ID";

            #region params

            cmdUpdate.Parameters.AddWithValue("@ID", myEnte.IDUNIDADES);
            cmdUpdate.Parameters.AddWithValue("@DESCRIPCION", myEnte.DESCRIPCION);
            

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
        /// Delete Serie
        /// <param name="id">Required a filled instance of Serie</param>
        /// </summary>
        public bool DeleteUnidades(int id)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM serie WHERE IDUNIDADES=@ID";

            #region params

            cmdInsert.Parameters.AddWithValue("@ID", id);

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