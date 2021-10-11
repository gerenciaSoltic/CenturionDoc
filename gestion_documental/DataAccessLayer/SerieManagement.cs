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
    public class SerieManagement : ConnectionClass
    {
        #region Sql
        private string DefaultSelect =
                @"SELECT 
                    c.ID , 
                    c.SERIE,
                    c.CODIGO
                    FROM serie as c ";

        #endregion

        #region Constructors
        public SerieManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of Serie
        /// <returns>List of Type Serie</returns>
        /// </summary>
        public List<Serie> GetAllSeries()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = this.DefaultSelect+ " order by serie";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Serie> allEntes = new List<Serie>();

                while (dr.Read())
                {
                    Serie myEnte = new Serie();

                    #region Params

                    myEnte.ID = Convert.ToInt32(dr["ID"]);
                    myEnte.SERIE = dr["SERIE"].ToString();
                    myEnte.CODIGO = dr["CODIGO"].ToString();
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



        public List<Serie> GetASeriesEnte(int idEnte)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "select a.idserie as id,b.codigo,b.serie  from configwf a,serie b where a.idserie = b.id and a.idente=" + idEnte.ToString()+" GROUP BY a.idserie,b.codigo,b.serie";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Serie> allEntes = new List<Serie>();

                while (dr.Read())
                {
                    Serie myEnte = new Serie();

                    #region Params

                    myEnte.ID = Convert.ToInt32(dr["ID"]);
                    myEnte.SERIE = dr["SERIE"].ToString();
                    myEnte.CODIGO = dr["CODIGO"].ToString();
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
        public Serie GetSerieById(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE c.ID = @ID ";
            cmdSelect.Parameters.AddWithValue("@ID", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                Serie myEnte = new Serie();

                while (dr.Read())
                {

                    #region Params

                    myEnte.ID = Convert.ToInt32(dr["ID"]);
                    myEnte.SERIE = dr["SERIE"].ToString();
                    myEnte.CODIGO = dr["CODIGO"].ToString();

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
        public void InsertSerie(Serie myEnte)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "INSERT INTO serie (SERIE,CODIGO) VALUES (@SERIE,@CODIGO)";

            #region params

            cmdInsert.Parameters.AddWithValue("@SERIE", myEnte.SERIE);
            cmdInsert.Parameters.AddWithValue("@CODIGO", myEnte.CODIGO);

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

        public void UpdateSerie(Serie myEnte)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = "Update serie SET  SERIE=@SERIE,CODIGO=@CODIGO where ID=@ID";

            #region params

            cmdUpdate.Parameters.AddWithValue("@ID", myEnte.ID);
            cmdUpdate.Parameters.AddWithValue("@SERIE", myEnte.SERIE);
            cmdUpdate.Parameters.AddWithValue("@CODIGO", myEnte.CODIGO);

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
        public bool DeleteSerie(int id)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM serie WHERE ID=@ID";

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