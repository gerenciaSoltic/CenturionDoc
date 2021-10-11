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
    public class ConfigwfManagement : ConnectionClass
    {
        private String DefaultSelect = @"SELECT 
                                        c.ID ,
                                        IF(c.IDENTE IS NULL, '0', c.IDENTE) as IDENTE, 
                                        IF(c.IDTIPOLOGIA IS NULL, '0', c.IDTIPOLOGIA) as IDTIPOLOGIA, 
                                        IF(c.idsubserie IS NULL, '0', c.idsubserie) as idsubserie,
                                        IF(c.idtarea IS NULL, '0', c.idtarea) as idtarea,
                                        IF(c.ORDEN IS NULL, '0', c.ORDEN) as ORDEN,
                                        IF(c.DIAS IS NULL, '0', c.DIAS) as DIAS,
                                        c.idserie,
                                        c.idactividad,
                                        c.idproceso,
                                        c.idactividadsiguiente,
                                        c.idprocesosiguiente,
                                        c.idemirecep
                                        FROM Configwf as c";

        #region Constructors
        public ConfigwfManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of fuel types
        /// <returns>List of Type Fuel Types</returns>
        /// </summary>
        public List<Configwf> GetAllConfigwf()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect;

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Configwf> allConfigwf = new List<Configwf>();

                while (dr.Read())
                {
                    Configwf myConfigwf = new Configwf();

                    #region Params

                    myConfigwf.ID = Convert.ToInt32(dr["ID"]);
                    myConfigwf.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myConfigwf.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"].ToString());
                    myConfigwf.ORDEN = Convert.ToInt32(dr["ORDEN"].ToString());
                    myConfigwf.DIAS = Convert.ToInt32(dr["DIAS"].ToString());
                    myConfigwf.DIAS = Convert.ToInt32(dr["DIAS"].ToString());
                    myConfigwf.idsubserie = Convert.ToInt32(dr["idsubserie"].ToString());
                    myConfigwf.idtarea = Convert.ToInt32(dr["idtarea"].ToString());
                    myConfigwf.IDSERIE = Convert.ToInt32(dr["idserie"]);
                    myConfigwf.idproceso = Convert.ToInt32(dr["idproceso"]);
                    myConfigwf.idactividad = Convert.ToInt32(dr["idactividad"]);
                    myConfigwf.idprocesosiguiente = Convert.ToInt32(dr["idprocesosiguiente"]);
                    myConfigwf.idactividadsiguiente = Convert.ToInt32(dr["idactividadsiguiente"]);
                    myConfigwf.idemirecep = Convert.ToInt32(dr["idemirecep"]);
                    
                    // myConfigwf.idexpediente = Convert.ToInt32(dr["idexpediente"].ToString());


                    myConfigwf.ente = new EnteManagement().GetEnteById(myConfigwf.IDENTE);
                    myConfigwf.tipologia = new TipologiaManagement().GetTipologiaById(myConfigwf.IDTIPOLOGIA);
                    myConfigwf.subserie = new SubSerieManagement().GetSubSerieById(myConfigwf.idsubserie);
                    myConfigwf.tareas = new TareasManagement().GetTareasById(myConfigwf.idtarea);
                    myConfigwf.actividad = new ActividadManagement().GetActividadById(myConfigwf.idactividad);
                    //  myConfigwf.expediente = new ExpedienteManagement().GetExpedienteById(myConfigwf.idexpediente);

                    #endregion

                    allConfigwf.Add(myConfigwf);

                }
                return allConfigwf;
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
        /// Inserts a new  Ente
        /// <param name="myConfigwf">Required a filled instance of Ente</param>
        /// </summary>
        public void InsertConfigwf(Configwf myConfigwf)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = @"INSERT INTO Configwf (IDENTE,IDTIPOLOGIA,ORDEN,DIAS,idsubserie,IDSERIE,idtarea,idproceso,idactividad) VALUES 
                                                        (@IDENTE, @IDTIPOLOGIA,@ORDEN,@DIAS,@idsubserie,@IDSERIE,@idtarea,@idproceso,@idactividad)";

            #region params

            cmdInsert.Parameters.AddWithValue("@IDENTE", myConfigwf.IDENTE);
            cmdInsert.Parameters.AddWithValue("@IDTIPOLOGIA", myConfigwf.IDTIPOLOGIA);
            cmdInsert.Parameters.AddWithValue("@ORDEN", myConfigwf.ORDEN);
            cmdInsert.Parameters.AddWithValue("@DIAS", myConfigwf.DIAS);
            cmdInsert.Parameters.AddWithValue("@idsubserie", myConfigwf.idsubserie);
            cmdInsert.Parameters.AddWithValue("@IDSERIE", myConfigwf.IDSERIE);
            cmdInsert.Parameters.AddWithValue("@idtarea", myConfigwf.idtarea);
            cmdInsert.Parameters.AddWithValue("@idproceso", myConfigwf.idproceso);
            cmdInsert.Parameters.AddWithValue("@idactividad", myConfigwf.idactividad);

            // cmdInsert.Parameters.AddWithValue("@idexpediente", myConfigwf.idexpediente);


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

        public void UpdateConfigwf(Configwf myConfigwf)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = "Update configwf SET  IDENTE=@IDENTE, IDTIPOLOGIA=@IDTIPOLOGIA, ORDEN=@ORDEN, DIAS=@DIAS, idsubserie=@idsubserie, idtarea=@idtarea, idserie=@idserie, idproceso=@idproceso, idactividad=@idactividad where ID=@ID";

            #region params

            cmdUpdate.Parameters.AddWithValue("@ID", myConfigwf.ID);
            cmdUpdate.Parameters.AddWithValue("@IDENTE", myConfigwf.IDENTE);
            cmdUpdate.Parameters.AddWithValue("@IDTIPOLOGIA", myConfigwf.IDTIPOLOGIA);
            cmdUpdate.Parameters.AddWithValue("@ORDEN", myConfigwf.ORDEN);
            cmdUpdate.Parameters.AddWithValue("@DIAS", myConfigwf.DIAS);
            cmdUpdate.Parameters.AddWithValue("@idsubserie", myConfigwf.idsubserie);
            cmdUpdate.Parameters.AddWithValue("@idtarea", myConfigwf.idtarea);
            cmdUpdate.Parameters.AddWithValue("@idserie", myConfigwf.IDSERIE);
            cmdUpdate.Parameters.AddWithValue("@idproceso", myConfigwf.idproceso);
            cmdUpdate.Parameters.AddWithValue("@idactividad", myConfigwf.idactividad);
            // cmdUpdate.Parameters.AddWithValue("@idexpediente", myConfigwf.idexpediente);

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
        /// Gets all the details of a Configwf
        /// <returns>Configwf</returns>
        /// </summary>
        public Configwf GetConfigwfById(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE c.ID = @id ";
            cmdSelect.Parameters.AddWithValue("@id", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                Configwf myConfigwf = new Configwf();

                while (dr.Read())
                {

                    #region Params

                    myConfigwf.ID = Convert.ToInt32(dr["ID"]);
                    myConfigwf.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myConfigwf.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"].ToString());
                    myConfigwf.ORDEN = Convert.ToInt32(dr["ORDEN"].ToString());
                    myConfigwf.DIAS = Convert.ToInt32(dr["DIAS"].ToString());
                    myConfigwf.IDSERIE = Convert.ToInt32(dr["idserie"].ToString());
                    myConfigwf.idsubserie = Convert.ToInt32(dr["idsubserie"].ToString());
                    myConfigwf.idtarea = Convert.ToInt32(dr["idtarea"].ToString());
                    myConfigwf.IDSERIE = Convert.ToInt32(dr["IDSERIE"]);
                    myConfigwf.idproceso = Convert.ToInt32(dr["idproceso"]);
                    myConfigwf.idactividad = Convert.ToInt32(dr["idactividad"]);
                    myConfigwf.idprocesosiguiente = Convert.ToInt32(dr["idprocesosiguiente"]);
                    myConfigwf.idactividadsiguiente = Convert.ToInt32(dr["idactividadsiguiente"]);
                    myConfigwf.idemirecep = Convert.ToInt32(dr["idemirecep"]);
                    // myConfigwf.idexpediente = Convert.ToInt32(dr["idexpediente"].ToString());


                    myConfigwf.ente = new EnteManagement().GetEnteById(myConfigwf.IDENTE);
                    myConfigwf.tipologia = new TipologiaManagement().GetTipologiaById(myConfigwf.IDTIPOLOGIA);
                    myConfigwf.subserie = new SubSerieManagement().GetSubSerieById(myConfigwf.idsubserie);
                   // myConfigwf.expediente = new ExpedienteManagement().GetExpedienteById(myConfigwf.idexpediente);
                    myConfigwf.tareas = new TareasManagement().GetTareasById(myConfigwf.idtarea);
                    myConfigwf.actividad = new ActividadManagement().GetActividadById(myConfigwf.idactividad);
                    #endregion

                }
                return myConfigwf;
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

        public Configwf GetConfigwfByIdactividad(int idactividad)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE c.idactividad = @IDACTIVIDAD ";
            cmdSelect.Parameters.AddWithValue("@IDACTIVIDAD", idactividad);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                Configwf myConfigwf = new Configwf();

                while (dr.Read())
                {

                    #region Params

                    myConfigwf.ID = Convert.ToInt32(dr["ID"]);
                    myConfigwf.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myConfigwf.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"].ToString());
                    myConfigwf.ORDEN = Convert.ToInt32(dr["ORDEN"].ToString());
                    myConfigwf.DIAS = Convert.ToInt32(dr["DIAS"].ToString());
                    myConfigwf.IDSERIE = Convert.ToInt32(dr["idserie"].ToString());
                    myConfigwf.idsubserie = Convert.ToInt32(dr["idsubserie"].ToString());
                    myConfigwf.idtarea = Convert.ToInt32(dr["idtarea"].ToString());
                    myConfigwf.IDSERIE = Convert.ToInt32(dr["IDSERIE"]);
                    myConfigwf.idproceso = Convert.ToInt32(dr["idproceso"]);
                    myConfigwf.idactividad = Convert.ToInt32(dr["idactividad"]);
                    myConfigwf.idprocesosiguiente = Convert.ToInt32(dr["idprocesosiguiente"]);
                    myConfigwf.idactividadsiguiente = Convert.ToInt32(dr["idactividadsiguiente"]);
                    myConfigwf.idemirecep = Convert.ToInt32(dr["idemirecep"]);
                    // myConfigwf.idexpediente = Convert.ToInt32(dr["idexpediente"].ToString());


                    myConfigwf.ente = new EnteManagement().GetEnteById(myConfigwf.IDENTE);
                    myConfigwf.tipologia = new TipologiaManagement().GetTipologiaById(myConfigwf.IDTIPOLOGIA);
                    myConfigwf.subserie = new SubSerieManagement().GetSubSerieById(myConfigwf.idsubserie);
                    // myConfigwf.expediente = new ExpedienteManagement().GetExpedienteById(myConfigwf.idexpediente);
                    myConfigwf.tareas = new TareasManagement().GetTareasById(myConfigwf.idtarea);
                    myConfigwf.actividad = new ActividadManagement().GetActividadById(myConfigwf.idactividad);
                    #endregion

                }
                return myConfigwf;
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

        public Configwf GetConfigwfByIdactividadsiguiente(int idactividad)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "select * from configwf co where co.idactividadsiguiente in (select c.idactividad from configwf c where c.idactividadsiguiente=@IDACTIVIDAD)";
            cmdSelect.Parameters.AddWithValue("@IDACTIVIDAD", idactividad);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                Configwf myConfigwf = new Configwf();

                while (dr.Read())
                {

                    #region Params

                    myConfigwf.ID = Convert.ToInt32(dr["ID"]);
                    myConfigwf.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myConfigwf.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"].ToString());
                    myConfigwf.ORDEN = Convert.ToInt32(dr["ORDEN"].ToString());
                    myConfigwf.DIAS = Convert.ToInt32(dr["DIAS"].ToString());
                    myConfigwf.IDSERIE = Convert.ToInt32(dr["idserie"].ToString());
                    myConfigwf.idsubserie = Convert.ToInt32(dr["idsubserie"].ToString());
                    myConfigwf.idtarea = Convert.ToInt32(dr["idtarea"].ToString());
                    myConfigwf.IDSERIE = Convert.ToInt32(dr["IDSERIE"]);
                    myConfigwf.idproceso = Convert.ToInt32(dr["idproceso"]);
                    myConfigwf.idactividad = Convert.ToInt32(dr["idactividad"]);
                    myConfigwf.idprocesosiguiente = Convert.ToInt32(dr["idprocesosiguiente"]);
                    myConfigwf.idactividadsiguiente = Convert.ToInt32(dr["idactividadsiguiente"]);
                    myConfigwf.idemirecep = Convert.ToInt32(dr["idemirecep"]);
                    // myConfigwf.idexpediente = Convert.ToInt32(dr["idexpediente"].ToString());


                    myConfigwf.ente = new EnteManagement().GetEnteById(myConfigwf.IDENTE);
                    myConfigwf.tipologia = new TipologiaManagement().GetTipologiaById(myConfigwf.IDTIPOLOGIA);
                    myConfigwf.subserie = new SubSerieManagement().GetSubSerieById(myConfigwf.idsubserie);
                    // myConfigwf.expediente = new ExpedienteManagement().GetExpedienteById(myConfigwf.idexpediente);
                    myConfigwf.tareas = new TareasManagement().GetTareasById(myConfigwf.idtarea);
                    myConfigwf.actividad = new ActividadManagement().GetActividadById(myConfigwf.idactividad);
                    #endregion

                }
                return myConfigwf;
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
        /// Gets all the details of a Configwf
        /// <returns>Configwf</returns>
        /// </summary>
        public List<serieconfig> GetConfigwfByIdente(int idente)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "select configwf.idserie,serie.serie from configwf,serie WHERE configwf.idserie = serie.id and configwf.idente = @idente group by configwf.idserie,serie.serie";
            cmdSelect.Parameters.AddWithValue("@idente", idente);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                
                List<serieconfig> allConfigserie = new List<serieconfig>();

                while (dr.Read())
                {
                    serieconfig Configserie = new serieconfig();
                   

                    #region Params
                    
                    Configserie.IDSERIE= Convert.ToInt32(dr["idserie"].ToString());
                    Configserie.SERIE = dr["serie"].ToString();
                  
                    #endregion
                    allConfigserie.Add(Configserie);

                }
                return allConfigserie;
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
        /// Delete Ente
        /// <param name="id">Required a filled instance of Ente</param>
        /// </summary>
        public bool DeleteConfigwf(int id)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM configwf WHERE ID=@ID";

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