using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Data;
using gestion_documental.Utils;
using gestion_documental.BusinessObjects;

namespace gestion_documental.DataAccessLayer
{
    public class CorreoSalienteManagement : ConnectionClass
    {
        #region Sql
        private string DefaultSelect =
                @"SELECT 
                    c.ID,
                    c.IDEMISOR,
                    c.IDRECEPTOR,
                    c.IDTIPOLOGIA,
                    c.ASUNTO,
                    c.TEXTO,
                    c.RADICADO,
                    c.FECHA
                    
                    FROM correosaliente as c ";

        #endregion

        #region Constructors
        public CorreoSalienteManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of CorreoSaliente
        /// <returns>List of CorreoSaliente Types</returns>
        /// </summary>
        public List<gestion_documental.BusinessObjects.CorreoSaliente> GetAllCorreoSaliente()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = this.DefaultSelect;

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<gestion_documental.BusinessObjects.CorreoSaliente> allEntes = new List<gestion_documental.BusinessObjects.CorreoSaliente>();

                while (dr.Read())
                {
                    gestion_documental.BusinessObjects.CorreoSaliente myEnte = new gestion_documental.BusinessObjects.CorreoSaliente();
                    #region Params

                    myEnte.ID = Convert.ToInt32(dr["ID"]);
                    myEnte.IDEMISOR = Convert.ToInt32(dr["IDEMISOR"]);
                    myEnte.IDRECEPTOR = Convert.ToInt32(dr["IDRECEPTOR"]);
                    myEnte.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"]);
                    myEnte.ASUNTO = dr["ASUNTO"].ToString();
                    myEnte.TEXTO = dr["TEXTO"].ToString();
                    myEnte.RADICADO = dr["RADICADO"].ToString();
                    myEnte.FECHA = Convert.ToDateTime(dr["FECHA"]);

                    myEnte.emisor = new EmiRecepManagement().GetEmiRecepById(myEnte.IDEMISOR);
                    myEnte.receptor = new EmiRecepManagement().GetEmiRecepById(myEnte.IDEMISOR);
                    myEnte.tipologia = new TipologiaManagement().GetTipologiaById(myEnte.IDTIPOLOGIA);

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
        /// Gets all the details of a CorreoSaliente
        /// <returns>CorreoSaliente</returns>
        /// </summary>
        public gestion_documental.BusinessObjects.CorreoSaliente GetCorreoSalienteById(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE c.ID = @ID ";
            cmdSelect.Parameters.AddWithValue("@ID", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                gestion_documental.BusinessObjects.CorreoSaliente myEnte = new gestion_documental.BusinessObjects.CorreoSaliente();

                while (dr.Read())
                {

                    #region Params

                    myEnte.ID = Convert.ToInt32(dr["ID"]);
                    myEnte.IDEMISOR = Convert.ToInt32(dr["IDEMISOR"]);
                    myEnte.IDRECEPTOR = Convert.ToInt32(dr["IDRECEPTOR"]);
                    myEnte.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"]);
                    myEnte.ASUNTO = dr["ASUNTO"].ToString();
                    myEnte.TEXTO = dr["TEXTO"].ToString();
                    myEnte.RADICADO = dr["RADICADO"].ToString();
                    myEnte.FECHA = Convert.ToDateTime(dr["FECHA"]);

                    myEnte.emisor = new EmiRecepManagement().GetEmiRecepById(myEnte.IDEMISOR);
                    myEnte.receptor = new EmiRecepManagement().GetEmiRecepById(myEnte.IDEMISOR);
                    myEnte.tipologia = new TipologiaManagement().GetTipologiaById(myEnte.IDTIPOLOGIA);

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
        /// Inserts a new  CorreoSaliente
        /// <param name="myEnte">Required a filled instance of CorreoSaliente</param>
        /// </summary>
        public int InsertCorreoSaliente(gestion_documental.BusinessObjects.CorreoSaliente myEnte)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = @"INSERT INTO correosaliente (
               
                IDEMISOR,
                IDRECEPTOR,
                IDTIPOLOGIA,
                ASUNTO,
                TEXTO,
                RADICADO,
                FECHA) VALUES (
                    @IDEMISOR,
                    @IDRECEPTOR,
                    @IDTIPOLOGIA,
                    @ASUNTO,
                    @TEXTO,
                    @RADICADO,
                    @FECHA) ;SELECT LAST_INSERT_ID()";

            #region params

            cmdInsert.Parameters.AddWithValue("@IDEMISOR", myEnte.IDEMISOR);
            cmdInsert.Parameters.AddWithValue("@IDRECEPTOR", myEnte.IDRECEPTOR);
            cmdInsert.Parameters.AddWithValue("@IDTIPOLOGIA", myEnte.IDTIPOLOGIA);
            cmdInsert.Parameters.AddWithValue("@ASUNTO", myEnte.ASUNTO);
            cmdInsert.Parameters.AddWithValue("@TEXTO", myEnte.TEXTO);
            cmdInsert.Parameters.AddWithValue("@RADICADO", myEnte.RADICADO);
            cmdInsert.Parameters.AddWithValue("@FECHA", myEnte.FECHA);

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

        public void UpdateCorreoSaliente(gestion_documental.BusinessObjects.CorreoSaliente myEnte)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = @"Update correosaliente SET 
                    
                    IDEMISOR=@IDEMISOR,
                    IDRECEPTOR=@IDRECEPTOR,
                    IDTIPOLOGIA=@IDTIPOLOGIA,
                    ASUNTO=@ASUNTO,
                    TEXTO=@TEXTO,
                    RADICADO=@RADICADO,
                    FECHA=@FECHA,
                                      
                    where ID=@ID";

            #region params

            cmdUpdate.Parameters.AddWithValue("@IDEMISOR", myEnte.IDEMISOR);
            cmdUpdate.Parameters.AddWithValue("@IDRECEPTOR", myEnte.IDRECEPTOR);
            cmdUpdate.Parameters.AddWithValue("@IDTIPOLOGIA", myEnte.IDTIPOLOGIA);
            cmdUpdate.Parameters.AddWithValue("@ASUNTO", myEnte.ASUNTO);
            cmdUpdate.Parameters.AddWithValue("@TEXTO", myEnte.TEXTO);
            cmdUpdate.Parameters.AddWithValue("@RADICADO", myEnte.RADICADO);
            cmdUpdate.Parameters.AddWithValue("@FECHA", myEnte.FECHA);

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
        /// Delete CorreoSaliente
        /// <param name="id">Required a filled instance of CorreoSaliente</param>
        /// </summary>
        public void DeleteCorreoSaliente(int id)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM correosaliente WHERE ID=@ID";

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