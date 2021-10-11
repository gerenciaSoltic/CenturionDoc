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
    public class IndicesManagement : ConnectionClass
    {
        #region Sql
        private string DefaultSelect =
                @"SELECT 
                    c.idINDICES , 
                    c.INDICE,
                    c.atributo,
                    IF(c.iddocumento IS NULL, '0', c.iddocumento) as iddocumento,local,actualizado
                    
                    FROM Indices as c ";

        #endregion

        #region Constructors
        public IndicesManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of Indices
        /// <returns>List of Type Indices</returns>
        /// </summary>
        public List<Indices> GetAllIndices()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = this.DefaultSelect;

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Indices> allEntes = new List<Indices>();

                while (dr.Read())
                {
                    Indices myEnte = new Indices();

                    #region Params

                    myEnte.idINDICES = Convert.ToInt32(dr["idINDICES"]);
                    myEnte.iddocumento = Convert.ToInt32(dr["iddocumento"]);
                    myEnte.INDICE = dr["INDICE"].ToString();
                    myEnte.ATRIBUTO = dr["ATRIBUTO"].ToString();
                    myEnte.local = Convert.ToInt32(dr["local"]);
                    myEnte.actualizado = Convert.ToInt32(dr["actualizado"]);

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


        public List<Indices> GetAllIndicesLocales()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * from indices where local = 1 and actualizado = 0";

            try
            { 
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Indices> allEntes = new List<Indices>();

                while (dr.Read())
                {
                    Indices myEnte = new Indices();

                    #region Params

                    myEnte.idINDICES = Convert.ToInt32(dr["id"]);
                    myEnte.iddocumento = Convert.ToInt32(dr["iddocumento"]);
                    myEnte.INDICE = dr["INDICE"].ToString();
                    myEnte.ATRIBUTO = dr["ATRIBUTO"].ToString();
                    myEnte.local = Convert.ToInt32(dr["local"]);
                    myEnte.actualizado = Convert.ToInt32(dr["actualizado"]);

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
        public Indices GetIndicesById(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM indices as c WHERE c.idINDICES = @id";
            cmdSelect.Parameters.AddWithValue("@id", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                Indices myEnte = new Indices();

                while (dr.Read())
                {

                    #region Params

                    myEnte.idINDICES = Convert.ToInt32(dr["idINDICES"]);
                    myEnte.iddocumento = Convert.ToInt32(dr["iddocumento"]);
                    myEnte.INDICE = dr["INDICE"].ToString();
                    myEnte.ATRIBUTO = dr["ATRIBUTO"].ToString();


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


        public List<Indices> GetIndicesByIdDocumento(int idDocumento)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT id,iddocumento,indice,atributo FROM indices as c WHERE c.idDocumento = @idDocumento group by atributo,indice order by id";
            cmdSelect.Parameters.AddWithValue("@idDocumento", idDocumento);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Indices> allEntes = new List<Indices>();

                while (dr.Read())
                {
                    Indices myEnte = new Indices();
                    #region Params

                    myEnte.idINDICES = Convert.ToInt32(dr["id"]);
                    myEnte.iddocumento = Convert.ToInt32(dr["iddocumento"]);
                    myEnte.INDICE = dr["INDICE"].ToString();
                    myEnte.ATRIBUTO = dr["ATRIBUTO"].ToString();

                    allEntes.Add(myEnte);
                    #endregion

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
        /// Gets Documentos por Indices
        /// <returns>List of Documentos</returns>
        /// </summary>
        public List<Documentos> GetAllDocumentos(string texto,int idente)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();
            cmdSelect.CommandText = "SELECT IDDOCUMENTO FROM indices as c WHERE c.INDICE like '%"+texto+"%' AND iddocumento IS NOT NULL GROUP BY IDDOCUMENTO";
            //cmdSelect.Parameters.AddWithValue("@text", texto);

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                
                List<Documentos> allDocumentos = new List<Documentos>();

                while (dr.Read())
                {

                    Documentos mydocument = new DocumentosManagement().GetDocumentosById(Convert.ToInt32(dr["iddocumento"]),idente);
                    if (mydocument.idDOCUMENTOS != 0)
                    {
                        allDocumentos.Add(mydocument);
                    }

                }
                return allDocumentos;
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
        
        //
        public List<Documentos> GetAllDocumentosCondicion(string condicion,int idente)
        {




            MySqlCommand cmdSelect = Connection.CreateCommand();
            cmdSelect.CommandText = "SELECT iddocumento FROM indices as c WHERE  (" + condicion + ") group by iddocumento";
            //cmdSelect.Parameters.AddWithValue("@text", texto);

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);

                List<Documentos> allDocumentos = new List<Documentos>();

                while (dr.Read())
                {

                    Documentos mydocument = new DocumentosManagement().GetDocumentosById(Convert.ToInt32(dr["iddocumento"]), idente);

                    allDocumentos.Add(mydocument);

                }
                return allDocumentos;
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
        //

        public List<Indices> GetIndicesByidserie(int idserie, int idsubserie)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM indices as c WHERE c.idserie = @idserie and c.idsubserie=@idsubserie";
            cmdSelect.Parameters.AddWithValue("@idserie", idserie);
            cmdSelect.Parameters.AddWithValue("@idsubserie", idsubserie);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Indices> filtrado = new List<Indices>();

                while (dr.Read())
                {
                    Indices myEnte = new Indices();
                    #region Params
                    myEnte.INDICE = dr["INDICE"].ToString();
                    myEnte.ATRIBUTO = dr["ATRIBUTO"].ToString();
                    filtrado.Add(myEnte);
                    #endregion

                }
                return filtrado;
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
        public int InsertIndices(Indices myEnte)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "INSERT INTO Indices (iddocumento ,INDICE,ATRIBUTO,LOCAL) VALUES (@iddocumento,@INDICE,@ATRIBUTO,@LOCAL);SELECT LAST_INSERT_ID()";

            #region params
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            if (url.ToUpper().Contains("LOCALHOST"))
            {

                myEnte.local = 1;
            }
            else
            {

                myEnte.local = 0;
            }

            cmdInsert.Parameters.AddWithValue("@iddocumento", myEnte.iddocumento);
            cmdInsert.Parameters.AddWithValue("@INDICE", myEnte.INDICE);
            cmdInsert.Parameters.AddWithValue("@ATRIBUTO", myEnte.ATRIBUTO);
            cmdInsert.Parameters.AddWithValue("@LOCAL", myEnte.local);


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


        public int InsertIndicesRemoto(Indices myEnte)
        {
            MySqlCommand cmdInsert = ConnectionLocal.CreateCommand();

            cmdInsert.CommandText = "INSERT INTO Indices (iddocumento ,INDICE,ATRIBUTO,LOCAL) VALUES (@iddocumento,@INDICE,@ATRIBUTO,@LOCAL);SELECT LAST_INSERT_ID()";

            #region params
           

            cmdInsert.Parameters.AddWithValue("@iddocumento", myEnte.iddocumento);
            cmdInsert.Parameters.AddWithValue("@INDICE", myEnte.INDICE);
            cmdInsert.Parameters.AddWithValue("@ATRIBUTO", myEnte.ATRIBUTO);
            cmdInsert.Parameters.AddWithValue("@LOCAL", myEnte.local);
            #endregion
            int id = 0;
            try
            {
                if (this.ConnectionLocal.State == ConnectionState.Closed)
                    this.ConnectionLocal.Open();
                id = Convert.ToInt32(cmdInsert.ExecuteScalar());

            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (ConnectionLocal.State == ConnectionState.Open)
                    ConnectionLocal.Close();
            }
            return id;
        }


        #endregion

        #region UPDATE Commands

        public void UpdateIndices(Indices myEnte)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = "Update Indices SET iddocumento=@iddocumento, INDICE=@INDICE,ATRIBUTO= @ATRIBUTO where idINDICES=@idINDICES";

            #region params

            cmdUpdate.Parameters.AddWithValue("@idINDICES", myEnte.idINDICES);
            cmdUpdate.Parameters.AddWithValue("@iddocumento", myEnte.iddocumento);
            cmdUpdate.Parameters.AddWithValue("@INDICE", myEnte.INDICE);
            cmdUpdate.Parameters.AddWithValue("@ATRIBUTO", myEnte.ATRIBUTO);

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
        public bool DeleteIndices(int id)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM indices WHERE id=@idINDICES";

            #region params

            cmdInsert.Parameters.AddWithValue("@idINDICES", id);

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

        public bool DeleteIndicescondicion(int id)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM indices WHERE atributo!='' and iddocumento=@iddocumento";

            #region params

            cmdInsert.Parameters.AddWithValue("@iddocumento", id);

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