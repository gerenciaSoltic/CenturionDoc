using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Data;
using gestion_documental.Utils;
using gestion_documental.BusinessObjects;

namespace gestion_documental.DataAccessLayer
{
    public class CorreoEntranteManagement : ConnectionClass
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
                    c.FECHA,
                    c.PROCESADO,
                    c.auxEmailEmisor
                      FROM correoentrante as c ";

        #endregion

        #region Constructors
        public CorreoEntranteManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of CorreoEntrante
        /// <returns>List of CorreoEntrante Types</returns>
        /// </summary>
        public List<gestion_documental.BusinessObjects.CorreoEntrante> GetAllCorreoEntrante()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = this.DefaultSelect;

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<gestion_documental.BusinessObjects.CorreoEntrante> allEntes = new List<gestion_documental.BusinessObjects.CorreoEntrante>();

                while (dr.Read())
                {
                    gestion_documental.BusinessObjects.CorreoEntrante myEnte = new gestion_documental.BusinessObjects.CorreoEntrante();
                    #region Params

                    myEnte.ID = Convert.ToInt32(dr["ID"]);
                    myEnte.IDEMISOR = Convert.ToInt32(dr["IDEMISOR"]);
                    myEnte.IDRECEPTOR = Convert.ToInt32(dr["IDRECEPTOR"]);
                    myEnte.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"]);
                    myEnte.ASUNTO = dr["ASUNTO"].ToString();
                    myEnte.TEXTO = dr["TEXTO"].ToString();
                    myEnte.RADICADO = dr["RADICADO"].ToString();
                    myEnte.FECHA = Convert.ToDateTime(dr["FECHA"]);
                    myEnte.PROCESADO = Convert.ToInt32(dr["PROCESADO"]);
                    myEnte.auxEmailEmisor = dr["auxEmailEmisor"].ToString();
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
        /// Gets all the details of a CorreoEntrante
        /// <returns>CorreoEntrante</returns>
        /// </summary>
        public gestion_documental.BusinessObjects.CorreoEntrante GetCorreoEntranteById(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE c.ID = @ID ";
            cmdSelect.Parameters.AddWithValue("@ID", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                gestion_documental.BusinessObjects.CorreoEntrante myEnte = new gestion_documental.BusinessObjects.CorreoEntrante();

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
                    myEnte.PROCESADO = Convert.ToInt32(dr["PROCESADO"]);
                    myEnte.auxEmailEmisor = dr["auxEmailEmisor"].ToString();

                   
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
        /// <summary>
        /// Gets all the details of a CorreoEntrante
        /// <returns>CorreoEntrante</returns>
        /// </summary>
        public List<gestion_documental.BusinessObjects.CorreoEntrante> correosNoProcePorIdrecep(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT  c.ID,c.IDEMISOR,e.descripcion as DESCEMISOR,r.DESCRIPCION as DESCRECEPTOR,c.IDRECEPTOR,c.idtipologia,c.radicado,c.procesado,c.asunto,c.texto,c.fecha,c.auxemailemisor FROM correoentrante c,emirecep e,emirecep r WHERE c.idemisor =e.id and c.idreceptor = r.id and procesado <> 1 and  c.idreceptor = @ID ORDER BY fecha DESC";
                    
            cmdSelect.Parameters.AddWithValue("@ID", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<gestion_documental.BusinessObjects.CorreoEntrante> myCorreosNoProcess = new List<gestion_documental.BusinessObjects.CorreoEntrante>();

                while (dr.Read())
                {
                    gestion_documental.BusinessObjects.CorreoEntrante myCorreoEntrante = new gestion_documental.BusinessObjects.CorreoEntrante();
                    
                    #region Params

                    myCorreoEntrante.ID = Convert.ToInt32(dr["ID"]);
                    if (dr["IDEMISOR"] != System.DBNull.Value)
                    myCorreoEntrante.IDEMISOR = Convert.ToInt32(dr["IDEMISOR"]);
                    myCorreoEntrante.DESCEMISOR= dr["DESCEMISOR"].ToString();
                    myCorreoEntrante.DESCRECEPTOR = dr["DESCRECEPTOR"].ToString();
                    myCorreoEntrante.IDRECEPTOR = Convert.ToInt32(dr["IDRECEPTOR"]);
                    myCorreoEntrante.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"]);
                    myCorreoEntrante.ASUNTO = dr["ASUNTO"].ToString();
                    myCorreoEntrante.TEXTO = dr["TEXTO"].ToString();
                    myCorreoEntrante.RADICADO = dr["RADICADO"].ToString();
                    myCorreoEntrante.FECHA = Convert.ToDateTime(dr["FECHA"]);
                    myCorreoEntrante.PROCESADO = Convert.ToInt32(dr["PROCESADO"]);
                    myCorreoEntrante.tipologia = new TipologiaManagement().GetTipologiaById(Convert.ToInt32(dr["IDTIPOLOGIA"]));
                    myCorreoEntrante.auxEmailEmisor = dr["auxEmailEmisor"].ToString();
                    #endregion

                    myCorreosNoProcess.Add(myCorreoEntrante);

                }
                return myCorreosNoProcess;
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
        public string getProximoRadicadoPorFecha(DateTime fecha)
        {
            int consecutivo = 1;
            string radicado = fecha.ToString("yyyyMMdd");
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT MAX(radicado) AS MAX FROM correoentrante WHERE radicado LIKE ('" + fecha.ToString("yyyyMMdd") + "%')";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<gestion_documental.BusinessObjects.CorreoEntrante> myCorreosNoProcess = new List<gestion_documental.BusinessObjects.CorreoEntrante>();

                while (dr.Read())
                {
                    if(dr["MAX"]!= System.DBNull.Value)
                        consecutivo = Convert.ToInt32(Convert.ToString(dr["MAX"]).Substring(8));
                    consecutivo++;

                }
                if (consecutivo < 10)
                {
                    radicado += "000" + consecutivo;
                }
                else if (consecutivo < 100)
                {
                    radicado += "00" + consecutivo;
                }
                else if (consecutivo < 1000)
                {
                    radicado += "0" + consecutivo;
                }
                else
                {
                    radicado = Convert.ToString(consecutivo);
                }
                return radicado;
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
        /// Inserts a new  CorreoEntrante
        /// <param name="myEnte">Required a filled instance of CorreoEntrante</param>
        /// </summary>
        public int InsertCorreoEntrante(gestion_documental.BusinessObjects.CorreoEntrante myEnte)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = @"INSERT INTO correoentrante (";
                
            cmdInsert.CommandText += "    IDEMISOR,                ";
            
            cmdInsert.CommandText += "    IDRECEPTOR,              ";
            
            cmdInsert.CommandText += "    IDTIPOLOGIA,             ";
            cmdInsert.CommandText += "    ASUNTO,                  ";
            cmdInsert.CommandText += "    TEXTO,                   ";
            cmdInsert.CommandText += "    RADICADO,                ";
            cmdInsert.CommandText += "    FECHA,                   ";
            cmdInsert.CommandText += "    PROCESADO,";
            cmdInsert.CommandText += "    auxEmailEmisor) VALUES (      ";
            if (myEnte.IDEMISOR > 0)
            cmdInsert.CommandText += "        @IDEMISOR,           ";
            else
                cmdInsert.CommandText += "       null,           ";
            if (myEnte.IDRECEPTOR > 0)
            cmdInsert.CommandText += "        @IDRECEPTOR,         ";
            else
                cmdInsert.CommandText += "        null,         ";
            if (myEnte.IDTIPOLOGIA > 0)
            cmdInsert.CommandText += "        @IDTIPOLOGIA,        ";
            cmdInsert.CommandText += "        @ASUNTO,             ";
            cmdInsert.CommandText += "        @TEXTO,              ";
            cmdInsert.CommandText += "        @RADICADO,           ";
            cmdInsert.CommandText += "        @FECHA,              ";
            cmdInsert.CommandText += "        @PROCESADO,";
            cmdInsert.CommandText += "        @auxemail) ;SELECT LAST_INSERT_ID()";

            #region params

            //int emi = myEnte.IDEMISOR;
            if (myEnte.IDEMISOR > 0 )
            cmdInsert.Parameters.AddWithValue("@IDEMISOR", myEnte.IDEMISOR);
            //else
              //  cmdInsert.Parameters.AddWithValue("@IDEMISOR", "null");
            if (myEnte.IDRECEPTOR > 0)
            cmdInsert.Parameters.AddWithValue("@IDRECEPTOR", myEnte.IDRECEPTOR );
            //else
              //  cmdInsert.Parameters.AddWithValue("@IDRECEPTOR", "null");
            if (myEnte.IDTIPOLOGIA > 0)
            cmdInsert.Parameters.AddWithValue("@IDTIPOLOGIA", myEnte.IDTIPOLOGIA);
            //else
              //  cmdInsert.Parameters.AddWithValue("@IDTIPOLOGIA", "null");
            cmdInsert.Parameters.AddWithValue("@ASUNTO", myEnte.ASUNTO);
            cmdInsert.Parameters.AddWithValue("@TEXTO", myEnte.TEXTO);
            cmdInsert.Parameters.AddWithValue("@RADICADO", myEnte.RADICADO);
            cmdInsert.Parameters.AddWithValue("@FECHA", myEnte.FECHA.ToString("yyyy-MM-dd HH:mm:ss"));
            cmdInsert.Parameters.AddWithValue("@PROCESADO", myEnte.PROCESADO);
            cmdInsert.Parameters.AddWithValue("@auxemail", myEnte.auxEmailEmisor);
            
            #endregion
            int id = 0;
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();
                id = Convert.ToInt32(cmdInsert.ExecuteScalar());
                //cmdInsert.ExecuteNonQuery();
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

        public void UpdateCorreoEntrante(gestion_documental.BusinessObjects.CorreoEntrante myEnte)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = @"Update correoentrante SET 
                    
                    IDEMISOR=@IDEMISOR,
                    IDRECEPTOR=@IDRECEPTOR,
                    IDTIPOLOGIA=@IDTIPOLOGIA,
                    ASUNTO=@ASUNTO,
                    TEXTO=@TEXTO,
                    RADICADO=@RADICADO,
                    FECHA=@FECHA,
                    PROCESADO=@PROCESADO
                    
                    where ID=@ID";

            #region params

            cmdUpdate.Parameters.AddWithValue("@IDEMISOR", myEnte.IDEMISOR);
            cmdUpdate.Parameters.AddWithValue("@IDRECEPTOR", myEnte.IDRECEPTOR);
            cmdUpdate.Parameters.AddWithValue("@IDTIPOLOGIA", myEnte.IDTIPOLOGIA);
            cmdUpdate.Parameters.AddWithValue("@ASUNTO", myEnte.ASUNTO);
            cmdUpdate.Parameters.AddWithValue("@TEXTO", myEnte.TEXTO);
            cmdUpdate.Parameters.AddWithValue("@RADICADO", myEnte.RADICADO);
            cmdUpdate.Parameters.AddWithValue("@FECHA", myEnte.FECHA);
            cmdUpdate.Parameters.AddWithValue("@PROCESADO", myEnte.PROCESADO);

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





        public void UpdateCorreoEntrantebyId(int Id, string radicado)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = @"Update correoentrante SET procesado = 1,radicado = '"+radicado+"' WHERE id = " + Id.ToString();

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
        /// Delete CorreoEntrante
        /// <param name="id">Required a filled instance of CorreoEntrante</param>
        /// </summary>
        public void DeleteCorreoEntrante(int id)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM correoentrante WHERE ID=@ID";

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
        //
    }
}