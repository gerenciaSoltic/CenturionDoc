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
    public class SemaforoManagement : ConnectionClass
    {
        #region Sql
        private string DefaultSelect =
                @"SELECT 
                    *
                FROM semaforo as c ";

        #endregion

        #region Constructors
        public SemaforoManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of Serie
        /// <returns>List of Type Serie</returns>
        /// </summary>
        public Semaforo GetAllSemaforo()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = this.DefaultSelect;

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                
                 Semaforo myEnte = new Semaforo();

                    #region Params
                 dr.Read();
                    myEnte.VERDESDE = Convert.ToInt32(dr["VERDESDE"]);
                    myEnte.VERHASTA = Convert.ToInt32(dr["VERHASTA"]);
                    myEnte.NARDESDE = Convert.ToInt32(dr["NARDESDE"]);
                    myEnte.NARHASTA = Convert.ToInt32(dr["NARHASTA"]);
                    myEnte.ROJDESDE = Convert.ToInt32(dr["VERDESDE"]);
                    myEnte.ROJHASTA = Convert.ToInt32(dr["ROJHASTA"]);
                    #endregion

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



    }
}