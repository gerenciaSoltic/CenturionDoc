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
    public class GruposWindowsManagement : ConnectionClass
    {


       
       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of fuel types
        /// <returns>List of Type Fuel Types</returns>
        /// </summary>
        public List<GruposWin> GetAllGrupos()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT c.idgruposwin , c.descripcion FROM gruposwin as c";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<GruposWin> allEntes = new List<GruposWin>();

                while (dr.Read())
                {
                    GruposWin myEnte = new GruposWin();

                    #region Params

                    myEnte.IDGRUPOSWIN = Convert.ToInt32(dr["idgruposwin"]);
                    myEnte.DESCRIPCION = dr["DESCRIPCION"].ToString();
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
        /// <param name="myEnte">Required a filled instance of Ente</param>
        /// </summary>
        public void InsertGruposWin(GruposWin myGruposWin)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

           // cmdInsert.CommandText = "INSERT INTO gruposwin (IDGRUPOSWIN,DESCRIPCION) VALUES (@idgruposwin, @descripcion)";

            cmdInsert.CommandText = "INSERT INTO gruposwin (DESCRIPCION) VALUES (@descripcion)";

            #region params

            //cmdInsert.Parameters.AddWithValue("@idgruposwin", myGruposWin.IDGRUPOSWIN);
            cmdInsert.Parameters.AddWithValue("@descripcion", myGruposWin.DESCRIPCION);

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

        public void UpdateGruposWin(GruposWin myGruposWin)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = "Update gruposwin SET DESCRIPCION=@descripcion where idgruposwin=@idgruposwin";
           // cmdUpdate.CommandText = "Update gruposwin SET IDGRUPOSWIN=@idgruposwin, DESCRIPCION=@descripcion where idgruposwin=@idgruposwin";

            #region params

            cmdUpdate.Parameters.AddWithValue("@idgruposwin", myGruposWin.IDGRUPOSWIN);
            cmdUpdate.Parameters.AddWithValue("@descripcion", myGruposWin.DESCRIPCION);

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
        public GruposWin GetGruposWinById(int idgruposwin)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM gruposwin as c WHERE c.IDGRUPOSWIN = @idgruposwin ";
            cmdSelect.Parameters.AddWithValue("@idgruposwin", idgruposwin);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                GruposWin myGruposWin = new GruposWin();

                while (dr.Read())
                {

                    #region Params

                    myGruposWin.IDGRUPOSWIN = Convert.ToInt32(dr["IDGRUPOSWIN"]);
                    myGruposWin.DESCRIPCION = dr["DESCRIPCION"].ToString();

                    #endregion

                }
                return myGruposWin;
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
        public bool DeleteGruposWin(int idgruposwin)
        {
            MySqlCommand cmdDelete = Connection.CreateCommand();

            cmdDelete.CommandText = "DELETE FROM gruposwin WHERE IDGRUPOSWIN=@idgruposwin";

            #region params

            cmdDelete.Parameters.AddWithValue("@IDGRUPOSWIN", idgruposwin);

            #endregion

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                cmdDelete.ExecuteNonQuery();
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