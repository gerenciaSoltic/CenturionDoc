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
    public class ProcesoManagement : ConnectionClass
    {

        private string DefaultSelect =
                @"SELECT 
                    p.id , 
                    p.Proceso
                    FROM procesos as p ";

        public ProcesoManagement()
        {

        }
        
        public List<proceso> GetAllProcesos()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = this.DefaultSelect + " order by Proceso";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<proceso> allEntes = new List<proceso>();

                while (dr.Read())
                {
                    proceso myEnte = new proceso();


                    myEnte.ID = Convert.ToInt32(dr["id"]);
                    myEnte.PROCESO = dr["Proceso"].ToString();

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

        
        public proceso GetProcesosById(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE p.id = @ID ";
            cmdSelect.Parameters.AddWithValue("@ID", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                proceso myEnte = new proceso();

                while (dr.Read())
                {


                    myEnte.ID = Convert.ToInt32(dr["id"]);
                    myEnte.PROCESO = dr["Proceso"].ToString();

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

        public void InsertProceso(proceso myEnte)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "INSERT INTO procesos (Proceso) VALUES (@PROCESO)";

            cmdInsert.Parameters.AddWithValue("@PROCESO", myEnte.PROCESO);

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

        public void UpdateProceso(proceso myEnte)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = "Update procesos SET  Proceso=@PROCESO where id=@ID";

            cmdUpdate.Parameters.AddWithValue("@ID", myEnte.ID);
            cmdUpdate.Parameters.AddWithValue("@PROCESO", myEnte.PROCESO);

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

        public bool DeleteProceso(int id)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM procesos WHERE id=@ID";

            cmdInsert.Parameters.AddWithValue("@ID", id);

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
    }
}
    
