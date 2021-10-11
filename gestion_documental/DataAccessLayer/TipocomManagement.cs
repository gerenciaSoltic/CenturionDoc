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
    public class TipocomManagement : ConnectionClass
    {
        #region Sql
        private string DefaultSelect =
                @"SELECT 
                    *
                    
                    FROM tipocom  as c ";

        #endregion

        #region Constructors
        public TipocomManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of Cargo
        /// <returns>List of Type Cargo</returns>
        /// </summary>
        public List<Tipocom> GetAllTipoCom()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = this.DefaultSelect+ " order by id";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Tipocom> allEntes = new List<Tipocom>();

                while (dr.Read())
                {
                    Tipocom myEnte = new Tipocom();

                    #region Params

                    myEnte.TIPOCOMUNICACION = dr["TIPOCOMUNICACION"].ToString();
                    myEnte.ID = Convert.ToInt32(dr["ID"]);
                    myEnte.IDGRUPO = Convert.ToInt32(dr["IDGRUPO"]);

                    
                    

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


        public List<Tipocom> GetTipoComById( int Idgrupo)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = this.DefaultSelect + " where idgrupo = @Idgrupo  order by id";
            cmdSelect.Parameters.AddWithValue("@idgrupo", Idgrupo);

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Tipocom> allEntes = new List<Tipocom>();

                while (dr.Read())
                {
                    Tipocom myEnte = new Tipocom();

                    #region Params

                    myEnte.TIPOCOMUNICACION = dr["TIPOCOMUNICACION"].ToString();
                    myEnte.ID = Convert.ToInt32(dr["ID"]);
                    myEnte.IDGRUPO = Convert.ToInt32(dr["IDGRUPO"]);




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




        public Tipocom GetTipocomIdPrincipal(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM tipocom as c WHERE c.ID = @id ";
            cmdSelect.Parameters.AddWithValue("@id", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                Tipocom myEnte = new Tipocom();

                while (dr.Read())
                {

                    #region Params

                    myEnte.TIPOCOMUNICACION = dr["TIPOCOMUNICACION"].ToString();
                    myEnte.ID = Convert.ToInt32(dr["ID"]);
                    myEnte.IDGRUPO = Convert.ToInt32(dr["IDGRUPO"]);


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
        /// Gets all the details of a Cargo
        /// <returns>Cargo</returns>
        /// </summary>
        /// 
        
        #endregion
        /*
        #region INSERT Commands
        /// <summary>
        /// Inserts a new  Cargo
        /// <param name="myEnte">Required a filled instance of Cargo</param>
        /// </summary>
        public int InsertTipocom(Tipocom myEnte)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "INSERT INTO tipocom (tipocom) VALUES (@tipocomunicacion);SELECT LAST_INSERT_ID()";

            #region params

            cmdInsert.Parameters.AddWithValue("@tipocomunicacion", myEnte.TIPOCOMUNICACION);
           
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

        /*
        #region UPDATE Commands

        public void UpdateTipocom(Tipocom myEnte)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = "Update tipocom SET  tipocom=@tipocom where tipocom=@tipocom";

            #region params

            cmdUpdate.Parameters.AddWithValue("@tipocom", myEnte.TIPOCOM);
            
            
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
        public bool DeleteCadenas(int id)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM cadenas WHERE id=@id";

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
         * */
    }
}