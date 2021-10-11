using gestion_documental.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestion_documental.BusinessObjects;
using MySql.Data.MySqlClient;
using System.Data;

namespace gestion_documental.DataAccessLayer
{
    public class ActividadManagement : ConnectionClass
    {
        private string DefaultSelect =
                @"SELECT 
                    a.id , 
                    a.idproceso,
                    a.actividad
                    FROM actividad as a ";

       
        public ActividadManagement()
        {

        }
       
       
        public List<Actividad> GetAllActividad()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = this.DefaultSelect;

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Actividad> allEntes = new List<Actividad>();

                while (dr.Read())
                {
                    Actividad myEnte = new Actividad();

                   
                    myEnte.ID = Convert.ToInt32(dr["id"]);
                    myEnte.IDPROCESO = Convert.ToInt32(dr["idproceso"]);
                    myEnte.ACTIVIDAD = dr["actividad"].ToString();
                   
                    

                    myEnte.NOMBREPROCESO = new ProcesoManagement().GetProcesosById(myEnte.IDPROCESO).PROCESO;


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

        
        public List<Actividad> GetAllActividadByProceso(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = this.DefaultSelect + " WHERE a.idproceso = @ID ";
            cmdSelect.Parameters.AddWithValue("@ID", id);

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Actividad> allEntes = new List<Actividad>();

                while (dr.Read())
                {
                    Actividad myEnte = new Actividad();

                    myEnte.ID = Convert.ToInt32(dr["id"]);
                    myEnte.IDPROCESO = Convert.ToInt32(dr["idproceso"]);
                    myEnte.ACTIVIDAD = dr["actividad"].ToString();
                    myEnte.proceso = new ProcesoManagement().GetProcesosById(myEnte.IDPROCESO);
                    myEnte.NOMBREPROCESO = new ProcesoManagement().GetProcesosById(myEnte.IDPROCESO).PROCESO;

                   

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

       
        public Actividad GetActividadById(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE a.id = @ID ";
            cmdSelect.Parameters.AddWithValue("@ID", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                Actividad myEnte = new Actividad();

                while (dr.Read())
                {

                    myEnte.ID = Convert.ToInt32(dr["id"]);
                    myEnte.IDPROCESO = Convert.ToInt32(dr["idproceso"]);
                    myEnte.ACTIVIDAD = dr["actividad"].ToString();
                    myEnte.proceso = new ProcesoManagement().GetProcesosById(myEnte.IDPROCESO);
                    myEnte.NOMBREPROCESO = new ProcesoManagement().GetProcesosById(myEnte.IDPROCESO).PROCESO;

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

        public void InsertActividad(Actividad myEnte)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "INSERT INTO actividad (idproceso,actividad) VALUES (@IDPROCESO,@ACTIVIDAD)";


            cmdInsert.Parameters.AddWithValue("@IDPROCESO", myEnte.IDPROCESO);
            cmdInsert.Parameters.AddWithValue("@ACTIVIDAD", myEnte.ACTIVIDAD);
           

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

        public void UpdateActividad(Actividad myEnte)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = "Update actividad SET idproceso=@IDPROCESO, actividad=@ACTIVIDAD where ID=@ID";


            cmdUpdate.Parameters.AddWithValue("@ID", myEnte.ID);
            cmdUpdate.Parameters.AddWithValue("@IDPROCESO", myEnte.IDPROCESO);
            cmdUpdate.Parameters.AddWithValue("@ACTIVIDAD", myEnte.ACTIVIDAD);
            


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

       
        public bool DeleteActividad(int id)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM actividad WHERE id=@ID";


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