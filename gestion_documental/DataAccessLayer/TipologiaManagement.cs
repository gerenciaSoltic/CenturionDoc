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
    public class TipologiaManagement : ConnectionClass
    {
        #region Constructors
        public TipologiaManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of fuel types
        /// <returns>List of Type Fuel Types</returns>
        /// </summary>
        public List<Tipologia> GetAllTipologias()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT c.ID ,c.TIPOLOGIA,c.CODIGO FROM Tipologia as c ORDER BY tipologia";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Tipologia> allTipologia = new List<Tipologia>();

                while (dr.Read())
                {
                    Tipologia myTipologia = new Tipologia();

                    #region Params

                    myTipologia.ID = Convert.ToInt32(dr["ID"]);
                   
                    myTipologia.TIPOLOGIA = dr["TIPOLOGIA"].ToString();
                    myTipologia.CODIGO = dr["CODIGO"].ToString();

                   // myTipologia.subserie = new SubSerieManagement().GetSubSerieById(myTipologia.IDSUBSERIE);

                    #endregion

                    allTipologia.Add(myTipologia);

                }
                return allTipologia;
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
        /// Gets the whole list of fuel types
        /// <returns>List of Type Fuel Types</returns>
        /// </summary>
        public List<Tipologia> GetAllTipologiasBySubSerie(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT c.ID , c.TIPOLOGIA,c.CODIGO FROM Tipologia as c";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Tipologia> allTipologia = new List<Tipologia>();

                while (dr.Read())
                {
                    Tipologia myTipologia = new Tipologia();

                    #region Params

                    myTipologia.ID = Convert.ToInt32(dr["ID"]);
                    
                    myTipologia.TIPOLOGIA = dr["TIPOLOGIA"].ToString();
                    myTipologia.CODIGO = dr["CODIGO"].ToString();

                   
                    #endregion

                    allTipologia.Add(myTipologia);

                }
                return allTipologia;
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


        public List<Trd> GetAllTrd(int idserie,int idsubserie)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            string lcsarta = "";
            lcsarta= "SELECT serie.codigo as codserie,serie.serie,subserie.codigo as codsubserie,subserie.subserie,tipologia.codigo as codtipologia,tipologia.tipologia FROM serie,subserie,Tipologia  WHERE  subserie.idserie = serie.id ";
            if (idserie != 0)
            {
                lcsarta = lcsarta + " and serie.id = " + idserie.ToString(); 
            }
            if (idsubserie != 0)
            {
                lcsarta = lcsarta + " and subserie.id = " + idsubserie.ToString();
            }
            cmdSelect.CommandText = lcsarta;


            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Trd> allTrd = new List<Trd>();

                while (dr.Read())
                {
                    Trd myTrd = new Trd();

                    #region Params

                    myTrd.CODSUBSERIE = dr["CODSUBSERIE"].ToString();
                    myTrd.SUBSERIE = dr["SUBSERIE"].ToString();
                    myTrd.CODSERIE = dr["CODSERIE"].ToString();
                    myTrd.SERIE = dr["SERIE"].ToString();
                    myTrd.CODTIPOLOGIA = dr["CODTIPOLOGIA"].ToString();
                    myTrd.TIPOLOGIA = dr["TIPOLOGIA"].ToString();

                    #endregion

                    allTrd.Add(myTrd);

                }
                return allTrd;
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



        public List<InfWorkflow> GetAllWorkFlow(int idente, int idserie, int idsubserie)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            string lcsarta = "";
            lcsarta = "SELECT  ente.codigo as codente,ente.descripcion as ente,serie.codigo as codserie,serie.serie,subserie.codigo as codsubserie,subserie.subserie,tipologia.codigo as codtipologia,tipologia.tipologia FROM configwf,ente,serie,subserie,Tipologia ";
            lcsarta = lcsarta+ " WHERE configwf.idente = ente.idente and configwf.idtipologia = tipologia.id and configwf.idsubserie = subserie.id and configwf.idserie = serie.id and subserie.idserie = serie.id ";

            if (idente != 0)
            {
                lcsarta = lcsarta + " and configwf.idente = " + idente.ToString();
            }
            if (idserie != 0)
            {
                lcsarta = lcsarta + " and serie.id = " + idserie.ToString();
            }
            if (idsubserie != 0)
            {
                lcsarta = lcsarta + " and subserie.id = " + idsubserie.ToString();
            }
            cmdSelect.CommandText = lcsarta;


            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<InfWorkflow> allWorkFlow = new List<InfWorkflow>();

                while (dr.Read())
                {
                    InfWorkflow myInfworkkFlow = new InfWorkflow();

                    #region Params


                    myInfworkkFlow.CODENTE = dr["CODENTE"].ToString();
                    myInfworkkFlow.ENTE = dr["ENTE"].ToString();
                    myInfworkkFlow.CODSUBSERIE = dr["CODSUBSERIE"].ToString();
                    myInfworkkFlow.SUBSERIE = dr["SUBSERIE"].ToString();
                    myInfworkkFlow.CODSERIE = dr["CODSERIE"].ToString();
                    myInfworkkFlow.SERIE = dr["SERIE"].ToString();
                    myInfworkkFlow.CODTIPOLOGIA = dr["CODTIPOLOGIA"].ToString();
                    myInfworkkFlow.TIPOLOGIA = dr["TIPOLOGIA"].ToString();

                    #endregion

                    allWorkFlow.Add(myInfworkkFlow);

                }
                return allWorkFlow;
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



        public List<Tipologia> GetATipologiaEnte(int idSubSerie, int idEnte)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT a.idtipologia as id,a.idsubserie,b.Tipologia FROM configwf as a,tipologia b WHERE  a.idtipologia=b.id and a.idsubserie= " + idSubSerie.ToString() + " and a.idente =" + idEnte.ToString()+" GROUP BY a.idtipologia ,a.idsubserie,b.Tipologia";


            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Tipologia> allEntes = new List<Tipologia>();

                while (dr.Read())
                {
                    Tipologia myEnte = new Tipologia();

                    #region Params

                    myEnte.ID = Convert.ToInt32(dr["ID"]);
                    
                    myEnte.TIPOLOGIA = dr["TIPOLOGIA"].ToString();
                    

                    //myEnte.TIPOLOGIA = new TipologiaManagement().GetAllTipologiasBySubSerie(myEnte.ID);
                    //myEnte.serie = new SerieManagement().GetSerieById(myEnte.IDSERIE);
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
        /// Inserts a new  Ente
        /// <param name="myTipologia">Required a filled instance of Ente</param>
        /// </summary>
        public void InsertTipologia(Tipologia myTipologia)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "INSERT INTO Tipologia (TIPOLOGIA,CODIGO) VALUES ( @tipologia,@codigo)";

            #region params

         
			cmdInsert.Parameters.AddWithValue("@tipologia", myTipologia.TIPOLOGIA);
            cmdInsert.Parameters.AddWithValue("@codigo", myTipologia.CODIGO);


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

        public void UpdateTipologia(Tipologia myTipologia)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = "Update Tipologia SET  TIPOLOGIA=@tipologia,CODIGO =@codigo where ID=@id";

            #region params

            cmdUpdate.Parameters.AddWithValue("@id", myTipologia.ID);
           
			cmdUpdate.Parameters.AddWithValue("@tipologia", myTipologia.TIPOLOGIA);
            cmdUpdate.Parameters.AddWithValue("@codigo", myTipologia.CODIGO);
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
        /// Gets all the details of a Tipologia
        /// <returns>Tipologia</returns>
        /// </summary>
        public Tipologia GetTipologiaById(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM Tipologia as c WHERE c.ID = @id ";
            cmdSelect.Parameters.AddWithValue("@id", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                Tipologia myTipologia = new Tipologia();

                while (dr.Read())
                {

                    #region Params

                    myTipologia.ID = Convert.ToInt32(dr["ID"]);
                 
					myTipologia.TIPOLOGIA = dr["TIPOLOGIA"].ToString();
                    myTipologia.CODIGO = dr["CODIGO"].ToString();

                    

                    #endregion

                }
                return myTipologia;
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
        /// Delete Tipologia
        /// <param name="id">Required a filled instance of Ente</param>
        /// </summary>
        public bool DeleteTipologia(int id)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM tipologia WHERE ID=@ID";

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