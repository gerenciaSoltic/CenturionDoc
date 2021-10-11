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
    public class LinkDocManagement : ConnectionClass
    {
        Class1 proce = new Class1();
        #region Constructors
        public LinkDocManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of fuel types
        /// <returns>List of Type Fuel Types</returns>
        /// </summary>
        public List<LinkDoc> GetAllLinkDoc()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM linkdoc as c";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<LinkDoc> allLinkDoc = new List<LinkDoc>();

                while (dr.Read())
                {
                    LinkDoc myLinkDoc = new LinkDoc();

                    #region Params

                    myLinkDoc.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myLinkDoc.ID = Convert.ToInt32(dr["ID"].ToString());
                    myLinkDoc.IDDOCUMENTOS = Convert.ToInt32(dr["IDDOCUMENTOS"].ToString());
                   

                    #endregion

                    allLinkDoc.Add(myLinkDoc);

                }
                return allLinkDoc;
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

        #region Insert Commands
        /// <summary>
        /// Inserts a new  Ente
        /// <param name="myEnte">Required a filled instance of Ente</param>
        /// </summary>
        public void InsertLinkDoc(LinkDoc myLinkDoc)
        {


            DataTable ExisteLink = new DataTable();
            // Primero Valido que No exiista

            proce.consultacamposcondicion("linkdoc","linkdoc.id","iddocumentos="+myLinkDoc.IDDOCUMENTOS.ToString()+" AND idente = "+myLinkDoc.IDENTE,ExisteLink);




            if (ExisteLink.Rows.Count> 0)
            {
                for (int iLink = 0; iLink < ExisteLink.Rows.Count; iLink++)
                {

                    myLinkDoc.ID = Convert.ToInt32(ExisteLink.Rows[iLink]["ID"].ToString());

                    UpdateLinkDoc(myLinkDoc);
                }

            }


           
                else
                {
            




                MySqlCommand cmdInsert = Connection.CreateCommand();

                cmdInsert.CommandText = "INSERT INTO linkdoc (IDENTE,IDDOCUMENTOS,IDSERIE,IDSUBSERIE,IDTIPOLOGIA,IDEXPEDIENTE) VALUES (@IDENTE, @IDDOCUMENTOS,@IDSERIE,@IDSUBSERIE,@IDTIPOLOGIA,@IDEXPEDIENTE)";

                #region params

                cmdInsert.Parameters.AddWithValue("@IDENTE", myLinkDoc.IDENTE);
                cmdInsert.Parameters.AddWithValue("@IDDOCUMENTOS", myLinkDoc.IDDOCUMENTOS);
                cmdInsert.Parameters.AddWithValue("@IDSERIE", myLinkDoc.IDSERIE);
                cmdInsert.Parameters.AddWithValue("@IDSUBSERIE", myLinkDoc.IDSUBSERIE);
                cmdInsert.Parameters.AddWithValue("@IDTIPOLOGIA", myLinkDoc.IDTIPOLOGIA);
                cmdInsert.Parameters.AddWithValue("@IDEXPEDIENTE", myLinkDoc.IDEXPEDIENTE);


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
        }



        public void InsertLinkDocLocal(LinkDoc myLinkDoc)
        {


            DataTable ExisteLink = new DataTable();
            // Primero Valido que No exiista

            




                MySqlCommand cmdInsert = ConnectionLocal.CreateCommand();

                cmdInsert.CommandText = "INSERT INTO linkdoc (IDENTE,IDDOCUMENTOS,IDSERIE,IDSUBSERIE,IDTIPOLOGIA,IDEXPEDIENTE) VALUES (@IDENTE, @IDDOCUMENTOS,@IDSERIE,@IDSUBSERIE,@IDTIPOLOGIA,@IDEXPEDIENTE)";

                #region params

                cmdInsert.Parameters.AddWithValue("@IDENTE", myLinkDoc.IDENTE);
                cmdInsert.Parameters.AddWithValue("@IDDOCUMENTOS", myLinkDoc.IDDOCUMENTOS);
                cmdInsert.Parameters.AddWithValue("@IDSERIE", myLinkDoc.IDSERIE);
                cmdInsert.Parameters.AddWithValue("@IDSUBSERIE", myLinkDoc.IDSUBSERIE);
                cmdInsert.Parameters.AddWithValue("@IDTIPOLOGIA", myLinkDoc.IDTIPOLOGIA);
                cmdInsert.Parameters.AddWithValue("@IDEXPEDIENTE", myLinkDoc.IDEXPEDIENTE);


                #endregion

                try
                {
                    if (this.ConnectionLocal.State == ConnectionState.Closed)
                        this.ConnectionLocal.Open();

                    cmdInsert.ExecuteNonQuery();
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
            
        }



        #region UPDATE Commands

        public void UpdateLinkDoc(LinkDoc myLinkDoc)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = "Update linkdoc SET  IDENTE=@IDENTE, IDDOCUMENTOS=@IDDOCUMENTOS, IDSERIE = @IDSERIE, IDSUBSERIE = @IDSUBSERIE, IDTIPOLOGIA = @IDTIPOLOGIA, IDEXPEDIENTE = @IDEXPEDIENTE  where ID="+myLinkDoc.ID.ToString();

            #region params

            cmdUpdate.Parameters.AddWithValue("@id", myLinkDoc.ID);
            cmdUpdate.Parameters.AddWithValue("@idente", myLinkDoc.IDENTE);
			cmdUpdate.Parameters.AddWithValue("@iddocumentos", myLinkDoc.IDDOCUMENTOS);
            cmdUpdate.Parameters.AddWithValue("@idserie", myLinkDoc.IDSERIE);
            cmdUpdate.Parameters.AddWithValue("@idsubserie", myLinkDoc.IDSUBSERIE);
            cmdUpdate.Parameters.AddWithValue("@idtipologia", myLinkDoc.IDTIPOLOGIA);
            cmdUpdate.Parameters.AddWithValue("@idexpediente", myLinkDoc.IDEXPEDIENTE);

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
        /// Gets all the details of a Fuel
        /// <returns>Fuel Type</returns>
        /// </summary>
        public LinkDoc GetEnteByIdId(int iddocumentos,int idEnte)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM linkdoc as c WHERE c.IDENTE = @idEnte and c.iddocumentos = @iddocumentos";
            cmdSelect.Parameters.AddWithValue("@idente", idEnte);
            cmdSelect.Parameters.AddWithValue("@iddocumentos", iddocumentos);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                LinkDoc myEnte = new LinkDoc();

                while (dr.Read())
                {

                    #region Params

                    myEnte.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myEnte.IDDOCUMENTOS =  Convert.ToInt32(dr["IDDOCUMENTOS"]);
					myEnte.IDSERIE =  Convert.ToInt32(dr["IDSERIE"]);
                    myEnte.IDSUBSERIE =  Convert.ToInt32(dr["IDSUBSERIE"]);
                    myEnte.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"]);
                    myEnte.IDEXPEDIENTE = Convert.ToInt32(dr["IDEXPEDIENTE"]);
                    myEnte.ID = Convert.ToInt32(dr["ID"]);
                    
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
        

        #region DELETE Commands
        /// <summary>
        /// Delete Ente
        /// <param name="id">Required a filled instance of Ente</param>
        /// </summary>
        public bool DeleteLinkDok(int id)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM linkdoc WHERE ID=@ID";

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

        public void Actualizalinkdoc()
        {
             MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT workkflow.identedestino,workflow.identeorigen FROM  as c";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                {
                    this.Connection.Open();
                }
                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<LinkDoc> allLinkDoc = new List<LinkDoc>();

                while (dr.Read())
                {

                }
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
    }
}