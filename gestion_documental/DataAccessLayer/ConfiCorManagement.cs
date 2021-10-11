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
    public class ConfiCorManagement : ConnectionClass
    {
        #region Sql
        private string DefaultSelect =
                @"SELECT 
                    c.ID,
                    c.EMAIL,
                    c.CONTRASENA,
                    c.SERVPOPSALIENTE,
                    c.SERVPOPENTRANTE,
                    c.CAMINODESCARGA,
                    IF(c.ID IS NULL, '0', c.ID) as ID,
                    IF(c.EMAIL IS NULL, '0', c.EMAIL) as EMAIL,
                    IF(c.CONTRASENA IS NULL, '0', c.CONTRASENA) as CONTRASENA,
                    IF(c.SERVPOPSALIENTE IS NULL, '', c.SERVPOPSALIENTE) as SERVPOPSALIENTE,
                    IF(c.SERVPOPENTRANTE IS NULL, '', c.SERVPOPENTRANTE) as SERVPOPENTRANTE,
                    IF(c.CAMINODESCARGA IS NULL, '', c.CAMINODESCARGA) as CAMINODESCARGA,
                    IF(c.CAMINOSCANNER IS NULL, '', c.CAMINOSCANNER) as CAMINOSCANNER,
                    IF(c.SOFTESCANER IS NULL, '', c.SOFTESCANER) as SOFTESCANER,
                    IF(c.CAMINOCALIDAD IS NULL, '', c.CAMINOCALIDAD) as CAMINOCALIDAD,
                    IF(c.CARPETATEMP IS NULL, '', c.CARPETATEMP) as CARPETATEMP,
                    c.FECHAARRANQUE

                    
                    FROM conficor as c ";

        #endregion

        #region Constructors
        public ConfiCorManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of ConfiCor
        /// <returns>List of Type ConfiCor</returns>
        /// </summary>
        public List<ConfiCor> GetAllConficor()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect;

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<ConfiCor> allEntes = new List<ConfiCor>();

                while (dr.Read())
                {
                    ConfiCor myEnte = new ConfiCor();

                    #region Params

                    myEnte.ID               = Convert.ToInt32(dr["ID"]);
                    myEnte.EMAIL            = dr["EMAIL"].ToString();
                    myEnte.CONTRASENA       = dr["CONTRASENA"].ToString();
                    myEnte.SERVPOPSALIENTE  = dr["SERVPOPSALIENTE"].ToString();
                    myEnte.SERVPOPENTRANTE  = dr["SERVPOPENTRANTE"].ToString();
                    myEnte.CAMINODESCARGA   = dr["CAMINODESCARGA"].ToString();
                    myEnte.CAMINOSCANNER    = dr["CAMINOSCANNER"].ToString();
                    myEnte.SOFTESCANER      = dr["SOFTESCANER"].ToString();
                    myEnte.CAMINOCALIDAD    = dr["CAMINOCALIDAD"].ToString();
                    myEnte.CARPETATEMP      = dr["CARPETATEMP"].ToString();
                    if (dr["FECHAARRANQUE"].ToString() != "")
                    {
                        myEnte.FECHAARRANQUE = Convert.ToDateTime(dr["FECHAARRANQUE"].ToString());
                    }
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
        /// Gets all the details of a ConfiCor
        /// <returns>ConfiCor</returns>
        /// </summary>
        public ConfiCor GetConfiCorById(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE c.ID = @ID ";
            cmdSelect.Parameters.AddWithValue("@ID", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                ConfiCor myEnte = new ConfiCor();

                while (dr.Read())
                {

                    #region Params

                    myEnte.ID                = Convert.ToInt32(dr["ID"]);
                    myEnte.EMAIL             = dr["EMAIL"].ToString();
                    myEnte.CONTRASENA        = dr["CONTRASENA"].ToString();
                    myEnte.SERVPOPSALIENTE   = dr["SERVPOPSALIENTE"].ToString();
                    myEnte.SERVPOPENTRANTE   = dr["SERVPOPENTRANTE"].ToString();
                    myEnte.CAMINODESCARGA    = dr["CAMINODESCARGA"].ToString();
                    myEnte.CAMINOSCANNER     = dr["CAMINOSCANNER"].ToString();
                    myEnte.SOFTESCANER       = dr["SOFTESCANER"].ToString();
                    myEnte.CAMINOCALIDAD     = dr["CAMINOCALIDAD"].ToString();
                    myEnte.CARPETATEMP       = dr["CARPETATEMP"].ToString();
                    if (dr["FECHAARRANQUE"] != null && dr["FECHAARRANQUE"].ToString() != "")
                    {
                        myEnte.FECHAARRANQUE = Convert.ToDateTime(dr["FECHAARRANQUE"].ToString());
                    }
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
        /// Inserts a new  ConfiCor
        /// <param name="myEnte">Required a filled instance of ConfiCor</param>
        /// </summary>
        public void InsertConfiCor(ConfiCor myEnte)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = @"INSERT INTO conficor (
                                        EMAIL,
                                        CONTRASENA,
                                        SERVPOPSALIENTE,
                                        SERVPOPENTRANTE,
                                        CAMINODESCARGA,
                                        CAMINOSCANNER,SOFTESCANER,CARPETATEMP,FECHARRANQUE) VALUES (
                                        @EMAIL,
                                        @CONTRASENA,
                                        @SERVPOPSALIENTE,
                                        @SERVPOPENTRANTE,
                                        @CAMINODESCARGA,
                                        @CAMINOSCANNER,
                                        @SOFTESCANER,
                                        @CAMINOCALIDAD,@CARPETATEMP,@FECHAARRANQUE)";

            #region params

            cmdInsert.Parameters.AddWithValue("@EMAIL", myEnte.EMAIL);
            cmdInsert.Parameters.AddWithValue("@CONTRASENA", myEnte.CONTRASENA);
            cmdInsert.Parameters.AddWithValue("@SERVPOPSALIENTE", myEnte.SERVPOPSALIENTE);
            cmdInsert.Parameters.AddWithValue("@SERVPOPENTRANTE", myEnte.SERVPOPENTRANTE);
            cmdInsert.Parameters.AddWithValue("@CAMINODESCARGA", myEnte.CAMINODESCARGA);
            cmdInsert.Parameters.AddWithValue("@CAMINOSCANNER", myEnte.CAMINOSCANNER);
            cmdInsert.Parameters.AddWithValue("@SOFTESCANER", myEnte.SOFTESCANER);
            cmdInsert.Parameters.AddWithValue("@CAMINOCALIDAD", myEnte.CAMINOCALIDAD);
            cmdInsert.Parameters.AddWithValue("@CAPETATEMP", myEnte.CARPETATEMP);
            cmdInsert.Parameters.AddWithValue("@FECHAARANQUE", myEnte.FECHAARRANQUE);

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

        public void UpdateConfiCor(ConfiCor myEnte)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = @"Update conficor SET  
                EMAIL=@EMAIL,
                CONTRASENA=@CONTRASENA,
                SERVPOPSALIENTE=@SERVPOPSALIENTE,
                SERVPOPENTRANTE=@SERVPOPENTRANTE,
                CAMINODESCARGA=@CAMINODESCARGA,
                CAMINOSCANNER=@CAMINOSCANNER,
                SOFTESCANER=@SOFTESCANER,
                SOFTESCANER=@CAMINOCALIDAD,
                CARPETATEMP =@CARPETATEMP,
                FECHAARRANQUE =@FECHAARRANQUE
                where ID=@ID";

            #region params

            cmdUpdate.Parameters.AddWithValue("@ID", myEnte.ID);
            cmdUpdate.Parameters.AddWithValue("@EMAIL", myEnte.EMAIL);
            cmdUpdate.Parameters.AddWithValue("@CONTRASENA", myEnte.CONTRASENA);
            cmdUpdate.Parameters.AddWithValue("@SERVPOPSALIENTE", myEnte.SERVPOPSALIENTE);
            cmdUpdate.Parameters.AddWithValue("@SERVPOPENTRANTE", myEnte.SERVPOPENTRANTE);
            cmdUpdate.Parameters.AddWithValue("@CAMINODESCARGA", myEnte.CAMINODESCARGA);
            cmdUpdate.Parameters.AddWithValue("@CAMINOSCANNER", myEnte.CAMINOSCANNER);
            cmdUpdate.Parameters.AddWithValue("@SOFTESCANER", myEnte.SOFTESCANER);
            cmdUpdate.Parameters.AddWithValue("@CAMINOCALIDAD", myEnte.CAMINOCALIDAD);
            cmdUpdate.Parameters.AddWithValue("@CARPETATEMP", myEnte.CARPETATEMP);
            cmdUpdate.Parameters.AddWithValue("@FECHAARANQUE", myEnte.FECHAARRANQUE);
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
        /// Delete ConfiCor
        /// <param name="id">Required a filled instance of ConfiCor</param>
        /// </summary>
        /// 

        /*
          public void DeleteConfiCor(int id)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM conficor WHERE ID=@ID";

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
         */
        public bool DeleteConfiCor(int id)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM conficor WHERE ID=@ID";

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