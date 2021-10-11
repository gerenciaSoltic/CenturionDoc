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
    public class SubSerieManagement : ConnectionClass
    {
        #region Sql
        private string DefaultSelect =
                @"SELECT 
                    c.ID , 
                    c.IDSERIE,
                    c.SUBSERIE,
                    c.CODIGO,
                    IF(c.IDDISPOFINAL IS NULL, '0', c.IDDISPOFINAL) as IDDISPOFINAL,
                    IF(c.TIEMPOGESTION IS NULL, '0', c.TIEMPOGESTION) as TIEMPOGESTION,
                    IF(c.TIEMPOCENTRAL IS NULL, '0', c.TIEMPOCENTRAL) as TIEMPOCENTRAL,
                    IF(c.TIEMPOHISTORICO IS NULL, '0', c.TIEMPOHISTORICO) as TIEMPOHISTORICO
                    FROM subserie as c ";

        #endregion

        #region Constructors
        public SubSerieManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of SubSerie
        /// <returns>List of Type SubSerie</returns>
        /// </summary>
        public List<SubSerie> GetAllSubSeries()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = this.DefaultSelect;

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<SubSerie> allEntes = new List<SubSerie>();

                while (dr.Read())
                {
                    SubSerie myEnte = new SubSerie();

                    #region Params

                    myEnte.ID = Convert.ToInt32(dr["ID"]);
                    myEnte.IDSERIE = Convert.ToInt32(dr["IDSERIE"]);
                    myEnte.SUBSERIE = dr["SUBSERIE"].ToString();
                    myEnte.CODIGO = dr["CODIGO"].ToString();
                    myEnte.IDDISPOFINAL    = Convert.ToInt32(dr["IDDISPOFINAL"]);
                    myEnte.TIEMPOGESTION   = Convert.ToInt32(dr["TIEMPOGESTION"]);
                    myEnte.TIEMPOCENTRAL   = Convert.ToInt32(dr["TIEMPOCENTRAL"]);
                    myEnte.TIEMPOHISTORICO = Convert.ToInt32(dr["TIEMPOHISTORICO"]);

                    //Serie clasSerie = new Serie();

                    //Serie clasSerie = new SerieManagement().GetSerieById(myEnte.IDSERIE);

                    myEnte.NOMBRESERIE = new SerieManagement().GetSerieById(myEnte.IDSERIE).SERIE;
                      //  clasSerie.SERIE.ToString();

                    //myEnte.serie = clasSerie.SERIE.ToString();
                        // new SerieManagement().GetSerieById(myEnte.IDSERIE);
                    
                    myEnte.DISPOSICION = new DispofinalManagement().GetDispoFinalById(myEnte.IDDISPOFINAL).DISPOSICION;

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
        /// Gets the whole list of SubSerie
        /// <returns>List of Type SubSerie</returns>
        /// </summary>
        public List<SubSerie> GetAllSubSeriesBySerie(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = this.DefaultSelect + " WHERE c.IDSERIE = @ID ";
            cmdSelect.Parameters.AddWithValue("@ID", id);

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<SubSerie> allEntes = new List<SubSerie>();

                while (dr.Read())
                {
                    SubSerie myEnte = new SubSerie();

                    #region Params

                    myEnte.ID = Convert.ToInt32(dr["ID"]);
                    myEnte.IDSERIE = Convert.ToInt32(dr["IDSERIE"]);
                    myEnte.SUBSERIE = dr["SUBSERIE"].ToString();
                    myEnte.CODIGO = dr["CODIGO"].ToString();
                    myEnte.IDDISPOFINAL = Convert.ToInt32(dr["IDDISPOFINAL"]);
                    myEnte.IDDISPOFINAL = Convert.ToInt32(dr["IDDISPOFINAL"]);
                    myEnte.TIEMPOGESTION = Convert.ToInt32(dr["TIEMPOGESTION"]);
                    myEnte.TIEMPOCENTRAL = Convert.ToInt32(dr["TIEMPOCENTRAL"]);
                    myEnte.TIEMPOHISTORICO = Convert.ToInt32(dr["TIEMPOHISTORICO"]);

                    myEnte.serie = new SerieManagement().GetSerieById(myEnte.IDSERIE);
                    myEnte.DISPOSICION = new DispofinalManagement().GetDispoFinalById(myEnte.IDDISPOFINAL).DISPOSICION;

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


        public List<SubSerie> GetASubSerieEnte(int idSerie, int idEnte)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT a.idsubserie as id,a.idserie,b.subserie,b.codigo,IF(b.IDDISPOFINAL IS NULL, '0', b.IDDISPOFINAL) as IDDISPOFINAL, IF(b.TIEMPOGESTION IS NULL, '0', b.TIEMPOGESTION) as TIEMPOGESTION,IF(b.TIEMPOCENTRAL IS NULL, '0', b.TIEMPOCENTRAL) as TIEMPOCENTRAL,IF(b.TIEMPOHISTORICO IS NULL, '0', b.TIEMPOHISTORICO) as TIEMPOHISTORICO FROM configwf as a,subserie b WHERE a.idserie = b.idserie and a.idsubserie=b.id and a.idserie= "+idSerie.ToString()+" and a.idente ="+idEnte.ToString()+" GROUP BY a.idsubserie ,a.idserie,b.subserie,b.codigo";
            

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<SubSerie> allEntes = new List<SubSerie>();

                while (dr.Read())
                {
                    SubSerie myEnte = new SubSerie();

                    #region Params

                    myEnte.ID = Convert.ToInt32(dr["ID"]);
                    myEnte.IDSERIE = Convert.ToInt32(dr["IDSERIE"]);
                    myEnte.SUBSERIE = dr["SUBSERIE"].ToString();
                    myEnte.CODIGO = dr["CODIGO"].ToString();
                    myEnte.IDDISPOFINAL = Convert.ToInt32(dr["IDDISPOFINAL"]);
                    myEnte.IDDISPOFINAL = Convert.ToInt32(dr["IDDISPOFINAL"]);
                    myEnte.TIEMPOGESTION = Convert.ToInt32(dr["TIEMPOGESTION"]);
                    myEnte.TIEMPOCENTRAL = Convert.ToInt32(dr["TIEMPOCENTRAL"]);
                    myEnte.TIEMPOHISTORICO = Convert.ToInt32(dr["TIEMPOHISTORICO"]);

                    myEnte.serie = new SerieManagement().GetSerieById(myEnte.IDSERIE);
                    myEnte.DISPOSICION = new DispofinalManagement().GetDispoFinalById(myEnte.IDDISPOFINAL).DISPOSICION;
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
        /// Gets all the details of a SubSerie
        /// <returns>SubSerie</returns>
        /// </summary>
        public SubSerie GetSubSerieById(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE c.ID = @ID ";
            cmdSelect.Parameters.AddWithValue("@ID", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                SubSerie myEnte = new SubSerie();

                while (dr.Read())
                {

                    #region Params

                    myEnte.ID = Convert.ToInt32(dr["ID"]);
                    myEnte.IDSERIE = Convert.ToInt32(dr["IDSERIE"]);
                    myEnte.SUBSERIE = dr["SUBSERIE"].ToString();
                    myEnte.CODIGO = dr["CODIGO"].ToString();
                    myEnte.IDDISPOFINAL = Convert.ToInt32(dr["IDDISPOFINAL"]);
                    
                    myEnte.TIEMPOGESTION = Convert.ToInt32(dr["TIEMPOGESTION"]);
                    myEnte.TIEMPOCENTRAL = Convert.ToInt32(dr["TIEMPOCENTRAL"]);
                    myEnte.TIEMPOHISTORICO = Convert.ToInt32(dr["TIEMPOHISTORICO"]);

                    myEnte.serie = new SerieManagement().GetSerieById(myEnte.IDSERIE);
                    myEnte.DISPOSICION = new DispofinalManagement().GetDispoFinalById(myEnte.IDDISPOFINAL).DISPOSICION;

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
        /// Inserts a new  SubSerie
        /// <param name="myEnte">Required a filled instance of SubSerie</param>
        /// </summary>
        public void InsertSubSerie(SubSerie myEnte)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "INSERT INTO subserie (IDSERIE,SUBSERIE,CODIGO,IDDISPOFINAL,TIEMPOGESTION,TIEMPOCENTRAL,TIEMPOHISTORICO) VALUES (@IDSERIE,@SUBSERIE,@CODIGO,@IDDISPOFINAL,@TIEMPOGESTION,@TIEMPOCENTRAL,@TIEMPOHISTORICO)";

            #region params

            cmdInsert.Parameters.AddWithValue("@IDSERIE", myEnte.IDSERIE);
            cmdInsert.Parameters.AddWithValue("@SUBSERIE", myEnte.SUBSERIE);
            cmdInsert.Parameters.AddWithValue("@CODIGO", myEnte.CODIGO);
            cmdInsert.Parameters.AddWithValue("@IDDISPOFINAL", myEnte.IDDISPOFINAL);
            cmdInsert.Parameters.AddWithValue("@TIEMPOGESTION", myEnte.TIEMPOGESTION);
            cmdInsert.Parameters.AddWithValue("@TIEMPOCENTRAL", myEnte.TIEMPOCENTRAL);
            cmdInsert.Parameters.AddWithValue("@TIEMPOHISTORICO", myEnte.TIEMPOHISTORICO);
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

        public void UpdateSubSerie(SubSerie myEnte)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = "Update subserie SET IDSERIE=@IDSERIE, SUBSERIE=@SUBSERIE,CODIGO =@CODIGO,IDDISPOFINAL= @IDDISPOFINAL,TIEMPOGESTION=@TIEMPOGESTION,TIEMPOCENTRAL=@TIEMPOCENTRAL,TIEMPOHISTORICO=@TIEMPOHISTORICO where ID=@ID";

            #region params

            cmdUpdate.Parameters.AddWithValue("@ID", myEnte.ID);
            cmdUpdate.Parameters.AddWithValue("@IDSERIE", myEnte.IDSERIE);
            cmdUpdate.Parameters.AddWithValue("@SUBSERIE", myEnte.SUBSERIE);
            cmdUpdate.Parameters.AddWithValue("@CODIGO", myEnte.CODIGO);
            cmdUpdate.Parameters.AddWithValue("@IDDISPOFINAL", myEnte.IDDISPOFINAL);
            cmdUpdate.Parameters.AddWithValue("@TIEMPOGESTION", myEnte.TIEMPOGESTION);
            cmdUpdate.Parameters.AddWithValue("@TIEMPOCENTRAL", myEnte.TIEMPOCENTRAL);
            cmdUpdate.Parameters.AddWithValue("@TIEMPOHISTORICO", myEnte.TIEMPOHISTORICO);

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
        /// Delete SubSerie
        /// <param name="id">Required a filled instance of SubSerie</param>
        /// </summary>
        public bool DeleteSubSerie(int id)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM subserie WHERE ID=@ID";

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