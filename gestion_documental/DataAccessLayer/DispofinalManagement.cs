using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestion_documental.Utils;
using MySql.Data.MySqlClient;
using gestion_documental.BusinessObjects;
using System.Data;

namespace gestion_documental.DataAccessLayer
{
    public class DispofinalManagement:ConnectionClass
    {

        #region Constructors
        public DispofinalManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of fuel types
        /// <returns>List of Type Fuel Types</returns>
        /// </summary>
        public List<DispoFinal> GetAllDispoFinal()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT c.IDDISPOFINAL , c.DISPOSICION FROM Dispofinal as c";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<DispoFinal> allDispofinal = new List<DispoFinal>();

                while (dr.Read())
                {
                    DispoFinal myDispoFinal = new DispoFinal();

                    #region Params

                    myDispoFinal.IDDISPOFINAL = Convert.ToInt32(dr["IDDISPOFINAL"]);
                    myDispoFinal.DISPOSICION = myDispoFinal.DISPOSICION = dr["DISPOSICION"].ToString();

                    #endregion

                    allDispofinal.Add(myDispoFinal);

                }
                return allDispofinal;
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
        /// Gets all the details of a Fuel
        /// <returns>Fuel Type</returns>
        /// </summary>
        public DispoFinal GetDispoFinalById(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM DispoFinal as c WHERE c.IDDISPOFINAL = @id ";
            cmdSelect.Parameters.AddWithValue("@id", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                DispoFinal myDispoFinal = new DispoFinal();

                while (dr.Read())
                {

                    #region Params

                    myDispoFinal.IDDISPOFINAL = Convert.ToInt32(dr["IDDISPOFINAL"]);
                    myDispoFinal.DISPOSICION = myDispoFinal.DISPOSICION = dr["DISPOSICION"].ToString();

                   
                    #endregion

                }
                return myDispoFinal;
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


    }
}