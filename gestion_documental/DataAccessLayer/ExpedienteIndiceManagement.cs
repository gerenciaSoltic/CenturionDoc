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
    public class ExpedienteIndiceManagement : ConnectionClass
    {
        #region Sql
        private string DefaultSelect =
                @"SELECT 
                    c.id , 
                    c.idserie
                    c.idsubserie,
                    c.idtipologia,
                    c.idexpediente,
                    c.atributo,
                    c.Indice
                    FROM indicesexpediente as c ";

        #endregion

        #region Constructors
        public ExpedienteIndiceManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of Indices
        /// <returns>List of Type Indices</returns>
        /// </summary>
        public List<ExpedienteIndice> GetAllExpedienteIndice(int idserie,int idsubserie, int idtipologia,int idexpediente)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = @"SELECT 
                    c.id , 
                    c.idserie,
                    c.idsubserie,
                    c.idtipologia,
                    c.idexpediente,
                    c.atributo,
                    c.indice
                    FROM indicesexpediente as c WHERE idserie="+idserie.ToString()+" AND idsubserie ="+idsubserie.ToString()+" AND idtipologia = "+idtipologia.ToString()+" AND idexpediente="+idexpediente.ToString();

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<ExpedienteIndice> allEntes = new List<ExpedienteIndice>();

                while (dr.Read())
                {
                    ExpedienteIndice myEnte = new ExpedienteIndice();

                    #region Params

                    myEnte.ID = Convert.ToInt32(dr["id"]);
                    myEnte.IDSERIE = Convert.ToInt32(dr["idserie"]);
                    myEnte.IDSUBSERIE = Convert.ToInt32(dr["idsubserie"]);
                    myEnte.IDTIPOLOGIA = Convert.ToInt32(dr["idtipologia"]);
                    myEnte.IDEXPEDIENTE = Convert.ToInt32(dr["idexpediente"]);
                    myEnte.ATRIBUTO = dr["atributo"].ToString();
                    myEnte.INDICE = dr["indice"].ToString();

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





        public List<Expediente> GetAllBuscaExpediente(string Buscar)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = @"SELECT expediente.* from expediente,indicesexpediente where expediente.idserie = indicesexpediente.idserie AND expediente.idsubserie= indicesexpediente.idsubserie  and expediente.idtipologia = indicesexpediente.idtipologia AND expediente.id = indicesexpediente.idexpediente and indice LIKE '%" + Buscar + "%'";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Expediente> allEntes = new List<Expediente>();

                while (dr.Read())
                {
                    Expediente myEnte = new Expediente();

                    #region Params

                    myEnte.id = Convert.ToInt32(dr["id"]);
                    myEnte.idserie = Convert.ToInt32(dr["idserie"]);
                    myEnte.idsubserie = Convert.ToInt32(dr["idsubserie"]);
                    myEnte.idtipologia = Convert.ToInt32(dr["idtipologia"]);
                    myEnte.descripcion = dr["descripcion"].ToString();
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
        /// Gets all the details of a Indices
        /// <returns>Indices</returns>
        /// </summary>
        public ExpedienteIndice GetexpedienteindiceById(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM indicesexpediente as c WHERE c.id = @id";
            cmdSelect.Parameters.AddWithValue("@id", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                ExpedienteIndice myEnte = new ExpedienteIndice();

                while (dr.Read())
                {

                    #region Params

                    myEnte.ID = Convert.ToInt32(dr["id"]);
                    myEnte.IDSERIE = Convert.ToInt32(dr["idserie"]);
                    myEnte.IDSUBSERIE = Convert.ToInt32(dr["idsubserie"]);
                    myEnte.IDTIPOLOGIA = Convert.ToInt32(dr["idtipologia"]);
                    myEnte.IDEXPEDIENTE = Convert.ToInt32(dr["idexpediente"]);
                    myEnte.ATRIBUTO = dr["ATRIBUTO"].ToString();
                    myEnte.INDICE = dr["INDICE"].ToString();


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
        /// Inserts a new  Indices
        /// <param name="myEnte">Required a filled instance of Indices</param>
        /// </summary>
        public int Insertexpedienteindice(ExpedienteIndice myEnte)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "INSERT INTO indicesexpediente (idserie,idsubserie,idtipologia,idexpediente,atributo,indice) VALUES (@idserie,@idsubserie,@idtipologia,@idexpediente,@atributo,@indice);SELECT LAST_INSERT_ID()";

            #region params

            cmdInsert.Parameters.AddWithValue("@idserie", myEnte.IDSERIE);
            cmdInsert.Parameters.AddWithValue("@idsubserie", myEnte.IDSUBSERIE);
            cmdInsert.Parameters.AddWithValue("@idtipologia", myEnte.IDTIPOLOGIA);
            cmdInsert.Parameters.AddWithValue("@idexpediente", myEnte.IDEXPEDIENTE);
            cmdInsert.Parameters.AddWithValue("@atributo", myEnte.ATRIBUTO);
            cmdInsert.Parameters.AddWithValue("@indice", myEnte.INDICE);

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

        public void UpdateExpedienteIndice(ExpedienteIndice myEnte)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = "Update indicesexpediente SET indice=@indice where id=@id";

            #region params

            cmdUpdate.Parameters.AddWithValue("@id", myEnte.ID);
            cmdUpdate.Parameters.AddWithValue("@indice", myEnte.INDICE);

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
        /// Delete Indices
        /// <param name="id">Required a filled instance of Indices</param>
        /// </summary>
        public bool DeleteExpedienteIndice(int id)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM indicesexpediente WHERE id=@id";

            #region params

            cmdInsert.Parameters.AddWithValue("@id", id);

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