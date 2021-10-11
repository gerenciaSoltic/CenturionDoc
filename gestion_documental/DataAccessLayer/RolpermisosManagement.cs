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
    public class RolpermisosManagement:ConnectionClass
    {
         #region Sql
        private string DefaultSelect =
                @"SELECT 
                    c.Id    , 
                    c.ROL   ,
                    c.MENU   ,
                    c.MODULO ,
                    c.ACTIVO 
                    FROM rolpermisos as c ";

        #endregion

        #region Constructors
        public RolpermisosManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of RolPermisos
        /// <returns>List of Type RolPermisos</returns>
        /// </summary>
        public List<RolPermisos> GetAllRolPermisoss()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = this.DefaultSelect;

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<RolPermisos> allPermisoss = new List<RolPermisos>();

                while (dr.Read())
                {
                    RolPermisos myPermisos = new RolPermisos();

                    #region Params

                    myPermisos.Id = Convert.ToInt32(dr["ID"]);
                    myPermisos.ROL = Convert.ToInt32( dr["ROL"].ToString());
                    myPermisos.MENU = dr["MENU"].ToString();
                    myPermisos.MODULO = dr["MODULO"].ToString();
                    myPermisos.ACTIVO = Convert.ToInt32(dr["ACTIVO"].ToString());
                    #endregion

                    allPermisoss.Add(myPermisos);

                }
                return allPermisoss;
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
        /// Gets all the details of a RolPermisosv
        /// <returns>RolPermisos</returns>
        /// </summary>
        public RolPermisos GetRolPermisosByRol(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE c.ROL = @ID ";
            cmdSelect.Parameters.AddWithValue("@ID", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                RolPermisos myPermisos = new RolPermisos();

                while (dr.Read())
                {

                    #region Params

                    myPermisos.Id = Convert.ToInt32(dr["ID"]);
                    myPermisos.ROL = Convert.ToInt32(dr["ROL"].ToString());
                    myPermisos.MENU = dr["MENU"].ToString();
                    myPermisos.MODULO = dr["MODULO"].ToString();
                    myPermisos.ACTIVO = Convert.ToInt32(dr["ACTIVO"].ToString());

                    //myPermisos.SUBRolPermisos = new SubRolPermisosManagement().GetAllSubRolPermisossByRolPermisos(myPermisos.ID);
                    #endregion

                }
                return myPermisos;
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
        /// Gets all the details of a RolPermisosv
        /// <returns>RolPermisos</returns>
        /// </summary>
        public RolPermisos GetRolPermisosByRolAndModulo(int id, string modulo)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE c.ROL = @ID and c.MODULO=@modulo and c.ACTIVO=1";
            cmdSelect.Parameters.AddWithValue("@ID", id);
            cmdSelect.Parameters.AddWithValue("@modulo", modulo);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                RolPermisos myPermisos = new RolPermisos();

                while (dr.Read())
                {

                    #region Params

                    myPermisos.Id = Convert.ToInt32(dr["ID"]);
                    myPermisos.ROL = Convert.ToInt32(dr["ROL"].ToString());
                    myPermisos.MENU = dr["MENU"].ToString();
                    myPermisos.MODULO = dr["MODULO"].ToString();
                    myPermisos.ACTIVO = Convert.ToInt32(dr["ACTIVO"].ToString());

                    //myPermisos.SUBRolPermisos = new SubRolPermisosManagement().GetAllSubRolPermisossByRolPermisos(myPermisos.ID);
                    #endregion

                }
                return myPermisos;
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
        /// Gets all the details of a RolPermisosv
        /// <returns>RolPermisos</returns>
        /// </summary>
        public RolPermisos GetRolPermisosByRolAndMenu(int id, string menu)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE c.ROL = @ID and c.MENU=@menu";
            cmdSelect.Parameters.AddWithValue("@ID", id);
            cmdSelect.Parameters.AddWithValue("@menu", menu);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                RolPermisos myPermisos = new RolPermisos();

                while (dr.Read())
                {

                    #region Params

                    myPermisos.Id = Convert.ToInt32(dr["ID"]);
                    myPermisos.ROL = Convert.ToInt32(dr["ROL"].ToString());
                    myPermisos.MENU = dr["MENU"].ToString();
                    myPermisos.MODULO = dr["MODULO"].ToString();
                    myPermisos.ACTIVO = Convert.ToInt32(dr["ACTIVO"].ToString());

                    //myPermisos.SUBRolPermisos = new SubRolPermisosManagement().GetAllSubRolPermisossByRolPermisos(myPermisos.ID);
                    #endregion

                }
                return myPermisos;
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
        /// Gets all the details of a RolPermisosv
        /// <returns>RolPermisos</returns>
        /// </summary>
        public RolPermisos GetRolPermisosByRolAndMenuModulo(int id, string menu,string modulo)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE c.ROL = @ID and c.MENU=@menu and c.MODULO=@modulo";
            cmdSelect.Parameters.AddWithValue("@ID", id);
            cmdSelect.Parameters.AddWithValue("@menu", menu);
            cmdSelect.Parameters.AddWithValue("@modulo", modulo);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                RolPermisos myPermisos = new RolPermisos();

                while (dr.Read())
                {

                    #region Params

                    myPermisos.Id = Convert.ToInt32(dr["ID"]);
                    myPermisos.ROL = Convert.ToInt32(dr["ROL"].ToString());
                    myPermisos.MENU = dr["MENU"].ToString();
                    myPermisos.MODULO = dr["MODULO"].ToString();
                    myPermisos.ACTIVO = Convert.ToInt32(dr["ACTIVO"].ToString());

                    //myPermisos.SUBRolPermisos = new SubRolPermisosManagement().GetAllSubRolPermisossByRolPermisos(myPermisos.ID);
                    #endregion

                }
                return myPermisos;
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
        /// Inserts a new  RolPermisos
        /// <param name="myPermisos">Required a filled instance of RolPermisos</param>
        /// </summary>
        public void InsertRolPermisos(RolPermisos myPermisos)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "INSERT INTO RolPermisos (ROL, MENU, MODULO, ACTIVO) VALUES (@rol,@menu,@modulo,@activo)";

            #region params

            cmdInsert.Parameters.AddWithValue("@rol", myPermisos.ROL);
            cmdInsert.Parameters.AddWithValue("@menu", myPermisos.MENU);
            cmdInsert.Parameters.AddWithValue("@modulo", myPermisos.MODULO);
            cmdInsert.Parameters.AddWithValue("@activo", myPermisos.ACTIVO);

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

        public void UpdateRolPermisos(RolPermisos myPermisos)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = "Update RolPermisos SET  ROL=@rol,MENU=@menu,MODULO=@modilo,ACTIVO=@ACTIVO     where Id=@id";

            #region params
            cmdUpdate.Parameters.AddWithValue("@id", myPermisos.Id);
            cmdUpdate.Parameters.AddWithValue("@rol", myPermisos.ROL);
            cmdUpdate.Parameters.AddWithValue("@menu", myPermisos.MENU);
            cmdUpdate.Parameters.AddWithValue("@modulo", myPermisos.MODULO);
            cmdUpdate.Parameters.AddWithValue("@activo", myPermisos.ACTIVO);

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
        /// Delete RolPermisos
        /// <param name="id">Required a filled instance of RolPermisos</param>
        /// </summary>
        public bool DeleteRolPermisos(int id)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM RolPermisos WHERE Id=@ID";

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