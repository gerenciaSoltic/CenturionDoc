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
    public class FormatosManagement : ConnectionClass
    {
        #region Constructors
        public FormatosManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of fuel types
        /// <returns>List of Type Fuel Types</returns>
        /// </summary>
        public List<Formatos> GetAllFormatos()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM formatos as c";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Formatos> allFormatos = new List<Formatos>();

                while (dr.Read())
                {
                    Formatos myEnte = new Formatos();

                    #region Params

                    myEnte.IDFORMATOS = Convert.ToInt32(dr["IDFORMATOS"]);
                    myEnte.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myEnte.DESCRIPCION = dr["DESCRIPCION"].ToString();
                    myEnte.ARCHIVO = dr["ARCHIVO"].ToString();
                    myEnte.ACTIVO = Convert.ToInt32(dr["ACTIVO"]);

                    #endregion

                    allFormatos.Add(myEnte);

                }
                return allFormatos;
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
        /// <param name="myEnte">Required a filled instance of Ente</param>
        /// </summary>
        public void InsertFormatos(Formatos myEnte)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "INSERT INTO Formatos (IDENTE,DESCRIPCION,ARCHIVO,ACTIVO) VALUES (@IDENTE,@DESCRIPCION,@ARCHIVO,@ACTIVO)";

            #region params

            cmdInsert.Parameters.AddWithValue("@IDENTE", myEnte.IDENTE);
			cmdInsert.Parameters.AddWithValue("@DESCRIPCION", myEnte.DESCRIPCION);
            cmdInsert.Parameters.AddWithValue("@ARCHIVO", myEnte.ARCHIVO);
            cmdInsert.Parameters.AddWithValue("@ACTIVO", myEnte.ACTIVO);
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

        public void UpdateFormatos(Formatos myEnte)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = "Update Formatos SET  IDENTE=@IDENTE,DESCRIPCION=@DESCRIPCION,ARCHIVO=@ARCHIVO,ACTIVO = @ACTIVO where IDFORMATOS=@IDFORMATOS";

            #region params

            cmdUpdate.Parameters.AddWithValue("@IDFORMATOS", myEnte.IDFORMATOS);
            cmdUpdate.Parameters.AddWithValue("@IDENTE", myEnte.IDENTE);
            cmdUpdate.Parameters.AddWithValue("@DESCRIPCION", myEnte.DESCRIPCION);
            cmdUpdate.Parameters.AddWithValue("@ARCHIVO", myEnte.ARCHIVO);
            cmdUpdate.Parameters.AddWithValue("@ACTIVO", myEnte.ACTIVO);
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
        public Formatos GetFormatosById(int idFormatos)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM Formatos as c WHERE c.IDFormatos = @IDFORMATOS ";
            cmdSelect.Parameters.AddWithValue("@IDFORMATOS", idFormatos);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                Formatos myEnte = new Formatos();

                while (dr.Read())
                {

                    #region Params
                    myEnte.IDFORMATOS = Convert.ToInt32(dr["IDFORMATOS"]);
                    myEnte.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myEnte.DESCRIPCION= dr["DESCRIPCION"].ToString();
                    myEnte.ARCHIVO = dr["ARCHIVO"].ToString();
                    myEnte.ACTIVO = Convert.ToInt32(dr["ACTIVO"]);
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



        public List<Formatos> GetFormatosByIdEnte(int idente)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM Formatos as c WHERE c.IDENTE = @IDENTE AND ACTIVO = 1";
            cmdSelect.Parameters.AddWithValue("@IDENTE", idente);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                
                List<Formatos> allFormatos = new List<Formatos>();
                while (dr.Read())
                {

                    #region Params
                    Formatos myEnte = new Formatos();
                    myEnte.IDFORMATOS = Convert.ToInt32(dr["IDFORMATOS"]);
                    myEnte.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myEnte.DESCRIPCION = dr["DESCRIPCION"].ToString();
                    myEnte.ARCHIVO = dr["ARCHIVO"].ToString();
                    myEnte.ACTIVO = Convert.ToInt32(dr["ACTIVO"]);
                    #endregion
                    allFormatos.Add(myEnte);
                }
                return allFormatos;
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
        public bool DeleteFormatos(int idFormatos)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM formatos WHERE IDFORMATOS=@IDFORMATOS";

            #region params

            cmdInsert.Parameters.AddWithValue("@IDFORMATOS", idFormatos);

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