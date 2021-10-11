using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using gestion_documental.BusinessObjects;
using gestion_documental.Utils;
using MySql.Data.MySqlClient;

namespace gestion_documental.DataAccessLayer
{
    public class DocumentoActividadManagement : ConnectionClass
    {

        
        private string DefaultSelect =
                @"SELECT 
                    d.id , 
                    d.idactividad,
                    d.nombredocumento
                    FROM documentoactividad as d ";

        public DocumentoActividadManagement()
        {

        }
       
        public List<DocumentoActividad> GetAllDocumentoActividad()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = this.DefaultSelect;

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<DocumentoActividad> allEntes = new List<DocumentoActividad>();

                while (dr.Read())
                {
                    DocumentoActividad myEnte = new DocumentoActividad();

                    myEnte.ID = Convert.ToInt32(dr["id"]);
                    myEnte.IDACTIVIDAD = Convert.ToInt32(dr["idactividad"]);
                    myEnte.NOMBREDOCUMENTO = dr["nombredocumento"].ToString();

                    myEnte.NOMBREACTIVIDAD = new ActividadManagement().GetActividadById(myEnte.IDACTIVIDAD).ACTIVIDAD;

                    myEnte.NOMBREPROCESO = new ActividadManagement().GetActividadById(myEnte.IDACTIVIDAD).NOMBREPROCESO;

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

      
        public List<DocumentoActividad> GetAllDocumentoByActividad(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = this.DefaultSelect + " WHERE d.idactividad = @ID ";
            cmdSelect.Parameters.AddWithValue("@ID", id);

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<DocumentoActividad> allEntes = new List<DocumentoActividad>();

                while (dr.Read())
                {
                    DocumentoActividad myEnte = new DocumentoActividad();


                    myEnte.ID = Convert.ToInt32(dr["id"]);
                    myEnte.IDACTIVIDAD = Convert.ToInt32(dr["idactividad"]);
                    myEnte.NOMBREDOCUMENTO = dr["nombredocumento"].ToString();

                    myEnte.NOMBREACTIVIDAD = new ActividadManagement().GetActividadById(myEnte.IDACTIVIDAD).ACTIVIDAD;

                    myEnte.NOMBREPROCESO = new ActividadManagement().GetActividadById(myEnte.IDACTIVIDAD).NOMBREPROCESO;


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


        public DocumentoActividad GetDocumentoActividadById(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE d.id = @ID ";
            cmdSelect.Parameters.AddWithValue("@ID", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                DocumentoActividad myEnte = new DocumentoActividad();

                while (dr.Read())
                {

                    myEnte.ID = Convert.ToInt32(dr["id"]);
                    myEnte.IDACTIVIDAD = Convert.ToInt32(dr["idactividad"]);
                    myEnte.NOMBREDOCUMENTO = dr["nombredocumento"].ToString();
                    myEnte.NOMBREACTIVIDAD = new ActividadManagement().GetActividadById(myEnte.IDACTIVIDAD).ACTIVIDAD;
                    myEnte.NOMBREPROCESO = new ActividadManagement().GetActividadById(myEnte.IDACTIVIDAD).NOMBREPROCESO;

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

        public List<DocumentoActividad> GetAllDocumentoByActividadFaltantes(int idactividad,int cadena)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "select doc.id,doc.nombredocumento,doc.idactividad from documentoactividad doc left join (select d.iddocumentoactividad from workflow w join documentos d  on w.iddocumento=d.idDOCUMENTOS where w.idcadena=@IDCADENA ) con1 on doc.id=con1.iddocumentoactividad where doc.idactividad=@IDACTIVIDAD and con1.iddocumentoactividad is null;";
            cmdSelect.Parameters.AddWithValue("@IDACTIVIDAD", idactividad);
            cmdSelect.Parameters.AddWithValue("@IDCADENA", cadena);


            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<DocumentoActividad> allEntes = new List<DocumentoActividad>();

                while (dr.Read())
                {
                    DocumentoActividad myEnte = new DocumentoActividad();


                    myEnte.ID = Convert.ToInt32(dr["id"]);
                    myEnte.IDACTIVIDAD = Convert.ToInt32(dr["idactividad"]);
                    myEnte.NOMBREDOCUMENTO = dr["nombredocumento"].ToString();
                    myEnte.NOMBREACTIVIDAD = new ActividadManagement().GetActividadById(myEnte.IDACTIVIDAD).ACTIVIDAD;

                    myEnte.NOMBREPROCESO = new ActividadManagement().GetActividadById(myEnte.IDACTIVIDAD).NOMBREPROCESO;


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


        public void InsertDocumentoActividad(DocumentoActividad myEnte)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "INSERT INTO documentoactividad (idactividad,nombredocumento) VALUES (@IDACTIVIDAD,@NOMBREDOCUMENTO)";

            cmdInsert.Parameters.AddWithValue("@IDACTIVIDAD", myEnte.IDACTIVIDAD);
            cmdInsert.Parameters.AddWithValue("@NOMBREDOCUMENTO", myEnte.NOMBREDOCUMENTO);

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
       
        public void UpdateDocumentoActividad(DocumentoActividad myEnte)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = "Update documentoactividad SET idactividad=@IDACTIVIDAD, nombredocumento=@NOMBREDOCUMENTO where ID=@ID";

            cmdUpdate.Parameters.AddWithValue("@ID", myEnte.ID);
            cmdUpdate.Parameters.AddWithValue("@IDACTIVIDAD", myEnte.IDACTIVIDAD);
            cmdUpdate.Parameters.AddWithValue("@NOMBREDOCUMENTO", myEnte.NOMBREDOCUMENTO);


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

        public bool DeleteDocumentoActividad(int id)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM documentoactividad WHERE id=@ID";

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