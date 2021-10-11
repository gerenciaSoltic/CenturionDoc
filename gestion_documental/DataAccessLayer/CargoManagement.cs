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
    public class CargoManagement : ConnectionClass
    {
        #region Sql
        private string DefaultSelect =
                @"SELECT 
                    c.idcargo , 
                    c.descripcion,
                    c.lider 
                    
                    FROM cargo as c ";

        #endregion

        #region Constructors
        public CargoManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of Cargo
        /// <returns>List of Type Cargo</returns>
        /// </summary>
        public List<Cargo> GetAllCargos()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = this.DefaultSelect;

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Cargo> allEntes = new List<Cargo>();

                while (dr.Read())
                {
                    Cargo myEnte = new Cargo();

                    #region Params

                    myEnte.IDCARGO = Convert.ToInt32(dr["IDCARGO"]);
                    myEnte.DESCRIPCION = dr["DESCRIPCION"].ToString();
                    myEnte.LIDER = Convert.ToInt32(dr["LIDER"]);

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
        /// Gets all the details of a Cargo
        /// <returns>Cargo</returns>
        /// </summary>
        public Cargo GetCargoById(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE c.idcargo = @idcargo ";
            cmdSelect.Parameters.AddWithValue("@idcargo", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                Cargo myEnte = new Cargo();

                while (dr.Read())
                {

                    #region Params

                    myEnte.IDCARGO = Convert.ToInt32(dr["idcargo"]);
                    myEnte.DESCRIPCION = dr["descripcion"].ToString();
                    myEnte.LIDER = Convert.ToInt32(dr["LIDER"]);
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
        /// Inserts a new  Cargo
        /// <param name="myEnte">Required a filled instance of Cargo</param>
        /// </summary>
        public void InsertCargo(Cargo myEnte)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "INSERT INTO cargo (descripcion,lider) VALUES (@descripcion,@LIDER)";

            #region params

            cmdInsert.Parameters.AddWithValue("@descripcion", myEnte.DESCRIPCION);
            cmdInsert.Parameters.AddWithValue("@LIDER", myEnte.LIDER);
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

        public void UpdateCargo(Cargo myEnte)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = "Update cargo SET  descripcion=@descripcion,lider=@LIDER where idcargo=@idcargo";

            #region params

            cmdUpdate.Parameters.AddWithValue("@idcargo", myEnte.IDCARGO);
            cmdUpdate.Parameters.AddWithValue("@descripcion", myEnte.DESCRIPCION);
            cmdUpdate.Parameters.AddWithValue("@lider", myEnte.LIDER);
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
        /// Delete Cargo
        /// <param name="id">Required a filled instance of Cargo</param>
        /// </summary>
        public bool DeleteCargo(int id)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM cargo WHERE idcargo=@idcargo";

            #region params

            cmdInsert.Parameters.AddWithValue("@idcargo", id);

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
            return true;
        }
        #endregion
    }
}