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
    public class SitioArchivoManagement : ConnectionClass
    {
        #region Sql
        private string DefaultSelect =
                @"SELECT 
                    c.IDSITIOARCHIVO , 
                    c.DESCRIPCION
                     FROM sitioarchivo as c ";

        #endregion

        #region Constructors
        public SitioArchivoManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of Serie
        /// <returns>List of Type Serie</returns>
        /// </summary>
        public List<SitioArchivo> GetAllSitioArchivo()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = this.DefaultSelect;

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<SitioArchivo> allEntes = new List<SitioArchivo>();

                while (dr.Read())
                {
                    SitioArchivo myEnte = new SitioArchivo();

                    #region Params

                    myEnte.IDSITIOARCHIVO = Convert.ToInt32(dr["IDSITIOARCHIVO"]);
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
        public  SitioArchivo GetSitioArchivoById(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE c.IDSITIOARCHIVO = @ID ";
            cmdSelect.Parameters.AddWithValue("@ID", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                SitioArchivo myEnte = new SitioArchivo();

                while (dr.Read())
                {

                    #region Params

                    myEnte.IDSITIOARCHIVO = Convert.ToInt32(dr["IDSITIOARCHIVO"]);
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
        public void InsertSitioArchivo(SitioArchivo myEnte)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "INSERT INTO SitioArchivo (DESCRIPCION) VALUES (@DESCRIPCION)";

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

        public void UpdateSitioArchivo(SitioArchivo myEnte)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = "Update sitioarchivo SET  DESCRIPCION=@DESCRIPCION where IDSITIOARCHIVO =@ID";

            #region params

            cmdUpdate.Parameters.AddWithValue("@ID", myEnte.IDSITIOARCHIVO);
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
        public bool DeleteSitioArchivo(int id)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM SitioArchivo WHERE IDSITIOARCHIVO=@ID";

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