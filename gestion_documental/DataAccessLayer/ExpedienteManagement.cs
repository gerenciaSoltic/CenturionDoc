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
    public class ExpedienteManagement : ConnectionClass
    {
        #region Sql
        private string DefaultSelect ="SELECT  id,idserie,idsubserie,idtipologia,descripcion,Fechainicio,Fechafinal,fasearchivo,IF(contenedor IS NULL,'0',contenedor)as contenedor,IF(compartimiento IS NULL,'0',compartimiento)as compartimiento,IF(idunidad IS NULL,'0',idunidad)as idunidad,IF(idente IS NULL,'0',idente)as idente,IF(codigo IS NULL,'0',codigo)as codigo,IF(fasearchivo IS NULL,'0',fasearchivo)as fasearchivo,IF(idunidad IS NULL,'0',idunidad)as idunidad,IF(numerounidad IS NULL,'0',numerounidad)as numerounidad,IF(idunidad2 IS NULL,'0',idunidad2)as idunidad2,IF(numerounidad2 IS NULL,'0',numerounidad2)as numerounidad2,IF(numerodeidentificacion IS NULL,'0',numerodeidentificacion)as numerodeidentificacion FROM expediente";

        #endregion

        #region Constructors
        public ExpedienteManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of Expediente
        /// <returns>List of Type Expediente</returns>
        /// </summary>
        public List<Expediente> GetAllExpediente()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = this.DefaultSelect;
            
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Expediente> allEntes = new List<Expediente>();

                while (dr.Read())
                {
                    Expediente myEnte = new Expediente();

                    #region Params

                    myEnte.id = Convert.ToInt32(dr["id"]);
                    myEnte.idserie = Convert.ToInt32(dr["idserie"].ToString());
                    myEnte.idsubserie = Convert.ToInt32(dr["idsubserie"].ToString());
                    myEnte.idtipologia = Convert.ToInt32(dr["idtipologia"].ToString());
                    myEnte.idente = Convert.ToInt32(dr["idente"].ToString());
                    myEnte.descripcion = dr["descripcion"].ToString();
                    myEnte.Fechainicio = Convert.ToDateTime(dr["Fechainicio"].ToString());
                    myEnte.Fechafinal = Convert.ToDateTime(dr["Fechafinal"].ToString());
                    myEnte.contenedor = dr["contenedor"].ToString();
                    myEnte.compartimiento = Convert.ToInt32(dr["compartimiento"].ToString());
                    myEnte.idunidad = Convert.ToInt32(dr["idunidad"].ToString());
                    myEnte.idente = Convert.ToInt32(dr["idente"].ToString());
                    myEnte.codigo = dr["codigo"].ToString();
                    myEnte.fasearchivo = dr["fasearchivo"].ToString();
                    myEnte.unidad =Convert.ToInt32(dr["idunidad"].ToString());
                    myEnte.numerounidad =dr["numerounidad"].ToString();
                    myEnte.unidad2 = Convert.ToInt32(dr["idunidad2"].ToString());
                    myEnte.numerounidad2 = Convert.ToInt32(dr["numerounidad2"].ToString());
                    myEnte.numerodeidentificacion = Convert.ToString(dr["numerodeidentificacion"].ToString());
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
        /// Gets all the details of a Expediente
        /// <returns>Expediente</returns>
        /// </summary>
        public Expediente GetExpedienteById(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE id = @id ";
            cmdSelect.Parameters.AddWithValue("@id", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                Expediente myEnte = new Expediente();

                while (dr.Read())
                {

                    #region Params
 
                    myEnte.id = Convert.ToInt32(dr["id"]);
                    myEnte.idserie = Convert.ToInt32(dr["idserie"].ToString());
                    myEnte.idsubserie = Convert.ToInt32(dr["idsubserie"].ToString());
                    myEnte.idtipologia = Convert.ToInt32(dr["idtipologia"].ToString());
                    myEnte.idente = Convert.ToInt32(dr["idente"].ToString());
                    myEnte.descripcion = dr["descripcion"].ToString();
                    myEnte.Fechainicio = Convert.ToDateTime(dr["Fechainicio"].ToString());
                    myEnte.Fechafinal = Convert.ToDateTime(dr["Fechafinal"].ToString());
                    myEnte.contenedor = dr["contenedor"].ToString();
                    myEnte.compartimiento = Convert.ToInt32(dr["compartimiento"].ToString());
                    myEnte.idunidad = Convert.ToInt32(dr["idunidad"].ToString());
                    myEnte.idente = Convert.ToInt32(dr["idente"].ToString());
                    myEnte.codigo = dr["codigo"].ToString();
                    myEnte.fasearchivo = dr["fasearchivo"].ToString();
                    myEnte.unidad = Convert.ToInt32(dr["idunidad"].ToString());
                    myEnte.numerounidad = dr["numerounidad"].ToString();
                    myEnte.unidad2 = Convert.ToInt32(dr["idunidad2"].ToString());
                    myEnte.numerounidad2 = Convert.ToInt32(dr["numerounidad2"].ToString());
                    myEnte.numerodeidentificacion = Convert.ToString(dr["numerodeidentificacion"].ToString());
                    

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
        //
                        
        public Expediente GetExpedientenumerodeidentificacion(string numero)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE numerodeidentificacion = @numero ";
            cmdSelect.Parameters.AddWithValue("@numero", numero);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                Expediente myEnte = new Expediente();

                while (dr.Read())
                {

                    #region Params

                    myEnte.id = Convert.ToInt32(dr["id"]);
                    myEnte.idserie = Convert.ToInt32(dr["idserie"].ToString());
                    myEnte.idsubserie = Convert.ToInt32(dr["idsubserie"].ToString());
                    myEnte.idtipologia = Convert.ToInt32(dr["idtipologia"].ToString());
                    myEnte.idente = Convert.ToInt32(dr["idente"].ToString());
                    myEnte.descripcion = dr["descripcion"].ToString();
                    myEnte.Fechainicio = Convert.ToDateTime(dr["Fechainicio"].ToString());
                    myEnte.Fechafinal = Convert.ToDateTime(dr["Fechafinal"].ToString());
                    myEnte.contenedor = dr["contenedor"].ToString();
                    myEnte.compartimiento = Convert.ToInt32(dr["compartimiento"].ToString());
                    myEnte.idunidad = Convert.ToInt32(dr["idunidad"].ToString());
                    myEnte.idente = Convert.ToInt32(dr["idente"].ToString());
                    myEnte.codigo = dr["codigo"].ToString();
                    myEnte.fasearchivo = dr["fasearchivo"].ToString();
                    myEnte.unidad = Convert.ToInt32(dr["idunidad"].ToString());
                    myEnte.numerounidad =dr["numerounidad"].ToString();
                    myEnte.unidad2 = Convert.ToInt32(dr["idunidad2"].ToString());
                    myEnte.numerounidad2 = Convert.ToInt32(dr["numerounidad2"].ToString());
                    myEnte.numerodeidentificacion = Convert.ToString(dr["numerodeidentificacion"].ToString());


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
        //
        public Expediente GetExpedienteByidenteyid(int idente,int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE idente = @idente and id = @id ";
            cmdSelect.Parameters.AddWithValue("@idente", idente);
            cmdSelect.Parameters.AddWithValue("@id", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);

                Expediente myEnte = new Expediente();
                while (dr.Read())
                {
                    

                    #region Params

                    myEnte.id = Convert.ToInt32(dr["id"]);
                    myEnte.idserie = Convert.ToInt32(dr["idserie"].ToString());
                    myEnte.idsubserie = Convert.ToInt32(dr["idsubserie"].ToString());
                    myEnte.idtipologia = Convert.ToInt32(dr["idtipologia"].ToString());
                    myEnte.idente = Convert.ToInt32(dr["idente"].ToString());
                    myEnte.descripcion = dr["descripcion"].ToString();
                    myEnte.Fechainicio = Convert.ToDateTime(dr["Fechainicio"].ToString());
                    myEnte.Fechafinal = Convert.ToDateTime(dr["Fechafinal"].ToString());
                    myEnte.contenedor = dr["contenedor"].ToString();
                    myEnte.compartimiento = Convert.ToInt32(dr["compartimiento"].ToString());
                    myEnte.idunidad = Convert.ToInt32(dr["idunidad"].ToString());
                    myEnte.idente = Convert.ToInt32(dr["idente"].ToString());
                    myEnte.codigo = dr["codigo"].ToString();
                    myEnte.fasearchivo = dr["fasearchivo"].ToString();
                    myEnte.unidad = Convert.ToInt32(dr["idunidad"].ToString());
                    myEnte.numerounidad = dr["numerounidad"].ToString();
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

        public List<Expediente> GetExpedienteByidente(int idente)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE idente = @idente ";
            cmdSelect.Parameters.AddWithValue("@idente", idente);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Expediente> allEntes = new List<Expediente>();

                while (dr.Read())
                {
                    Expediente myEnte = new Expediente();

                    #region Params

                    myEnte.id = Convert.ToInt32(dr["id"]);
                    myEnte.idserie = Convert.ToInt32(dr["idserie"].ToString());
                    myEnte.idsubserie = Convert.ToInt32(dr["idsubserie"].ToString());
                    myEnte.idtipologia = Convert.ToInt32(dr["idtipologia"].ToString());
                    myEnte.idente = Convert.ToInt32(dr["idente"].ToString());
                    myEnte.descripcion = dr["descripcion"].ToString();
                    myEnte.Fechainicio = Convert.ToDateTime(dr["Fechainicio"].ToString());
                    myEnte.Fechafinal = Convert.ToDateTime(dr["Fechafinal"].ToString());
                    myEnte.contenedor = dr["contenedor"].ToString();
                    myEnte.compartimiento = Convert.ToInt32(dr["compartimiento"].ToString());
                    myEnte.idunidad = Convert.ToInt32(dr["idunidad"].ToString());
                    myEnte.idente = Convert.ToInt32(dr["idente"].ToString());
                    myEnte.codigo = dr["codigo"].ToString();
                    myEnte.fasearchivo = dr["fasearchivo"].ToString();
                    myEnte.unidad = Convert.ToInt32(dr["idunidad"].ToString());
                    myEnte.numerounidad = dr["numerounidad"].ToString();
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


        public List<Expediente> GetExpedienteBycodigo(string codigo,int ente)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE idente='" + ente + "' and  (codigo like '%" + codigo + "%' or descripcion like'%" + codigo + "%' or numerodeidentificacion like '%" + codigo + "%') ";
            cmdSelect.Parameters.AddWithValue("@condicion", codigo);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Expediente> allEntes = new List<Expediente>();

                while (dr.Read())
                {
                    Expediente myEnte = new Expediente();

                    #region Params

                    myEnte.id = Convert.ToInt32(dr["id"]);
                    myEnte.idserie = Convert.ToInt32(dr["idserie"].ToString());
                    myEnte.idsubserie = Convert.ToInt32(dr["idsubserie"].ToString());
                    myEnte.idtipologia = Convert.ToInt32(dr["idtipologia"].ToString());
                    myEnte.idente = Convert.ToInt32(dr["idente"].ToString());
                    myEnte.descripcion = dr["descripcion"].ToString();
                    // myEnte.Fechainicio = Convert.ToDateTime(dr["Fechainicio"].);
                    //myEnte.Fechafinal = Convert.ToDateTime(dr["Fechafinal"].ToString());
                    myEnte.contenedor = dr["contenedor"].ToString();
                    myEnte.compartimiento = Convert.ToInt32(dr["compartimiento"].ToString());
                    myEnte.idunidad = Convert.ToInt32(dr["idunidad"].ToString());
                    myEnte.idente = Convert.ToInt32(dr["idente"].ToString());
                    myEnte.codigo = dr["codigo"].ToString();
                    myEnte.fasearchivo = dr["fasearchivo"].ToString();
                    myEnte.unidad = Convert.ToInt32(dr["idunidad"].ToString());
                    myEnte.unidad = Convert.ToInt32(dr["numerounidad"].ToString());
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
        //
        public List<Expediente> GetExpedienteBynumerodeidentificacion(string codigo, int idente)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();
            if (SessionDocumental.UsuarioInicioSession.ROL >= 3)
            {
                cmdSelect.CommandText = DefaultSelect + " WHERE (numerodeidentificacion like '%" + codigo + "%' or descripcion like'%" + codigo + "%') and idente= " + idente.ToString();
            }
            else
            {
                cmdSelect.CommandText = DefaultSelect + " WHERE (numerodeidentificacion like '%" + codigo + "%' or descripcion like'%" + codigo + "%') ";
            }
                cmdSelect.Parameters.AddWithValue("@condicion", codigo);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Expediente> allEntes = new List<Expediente>();

                while (dr.Read())
                {
                    Expediente myEnte = new Expediente();

                    #region Params

                    myEnte.id = Convert.ToInt32(dr["id"]);
                    myEnte.idserie = Convert.ToInt32(dr["idserie"].ToString());
                    myEnte.idsubserie = Convert.ToInt32(dr["idsubserie"].ToString());
                    myEnte.idtipologia = Convert.ToInt32(dr["idtipologia"].ToString());
                    myEnte.idente = Convert.ToInt32(dr["idente"].ToString());
                    myEnte.descripcion = dr["descripcion"].ToString();
                    // myEnte.Fechainicio = Convert.ToDateTime(dr["Fechainicio"].);
                    //myEnte.Fechafinal = Convert.ToDateTime(dr["Fechafinal"].ToString());
                    myEnte.contenedor = dr["contenedor"].ToString();
                    myEnte.compartimiento = Convert.ToInt32(dr["compartimiento"].ToString());
                    myEnte.idunidad = Convert.ToInt32(dr["idunidad"].ToString());
                    myEnte.idente = Convert.ToInt32(dr["idente"].ToString());
                    myEnte.codigo = dr["codigo"].ToString();
                    myEnte.fasearchivo = dr["fasearchivo"].ToString();
                    myEnte.unidad = Convert.ToInt32(dr["idunidad"].ToString());
                    myEnte.unidad = Convert.ToInt32(dr["numerounidad"].ToString());
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
        #endregion


        public List<Expediente> GetAllExpedienteBySubserie(int id, int idente)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();
            string lcSarta = "";
            if (idente != 0)
            {
                lcSarta = " AND c.idente = "+idente;
            }
            cmdSelect.CommandText = "SELECT c.id ,c.idtipologia, c.descripcion FROM Expediente as c where c.idSubserie=" + id + lcSarta;

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Expediente> allExpediente = new List<Expediente>();

                while (dr.Read())
                {
                    Expediente myExpediente = new Expediente();

                    #region Params

                    myExpediente.id = Convert.ToInt32(dr["id"]);
                    myExpediente.idtipologia = Convert.ToInt32(dr["idtipologia"]);
                    myExpediente.descripcion = dr["descripcion"].ToString();

                    myExpediente.tipologia = new TipologiaManagement().GetTipologiaById(myExpediente.idtipologia);
                    #endregion

                    allExpediente.Add(myExpediente);

                }
                return allExpediente;
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
        
        #region INSERT Commands
        /// <summary>
        /// Inserts a new  Expediente
        /// <param name="myEnte">Required a filled instance of Expediente</param>
        /// </summary>
        public void InsertExpediente(Expediente myEnte)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            //cmdInsert.CommandText = "INSERT INTO Tipologia (IDSUBSERIE,TIPOLOGIA) VALUES (@idsubserie, @tipologia)";

            cmdInsert.CommandText = @"
            INSERT INTO expediente (idserie, idsubserie, idtipologia, descripcion, Fechainicio, Fechafinal,contenedor,compartimiento,idunidad, idente,codigo,fasearchivo,numerounidad,numerounidad2,idunidad2,numerodeidentificacion) VALUES 
                    (@idserie,@idsubserie,@idtipologia,@descripcion,@Fechainicio,@Fechafinal,@contenedor,@compartimiento, @idunidad,@idente,@codigo,@fasearchivo,@numerounidad,@numerounidad2,@idunidad2,@numerodeidentificacion)";

            #region params
            //radicados idradicados,conseInt,ConseExtSal,ConseExtent,prefInter,PrefExtSal,PrefExtEnt,UltimaFecha
            cmdInsert.Parameters.AddWithValue("@idserie", myEnte.idserie);
            cmdInsert.Parameters.AddWithValue("@idsubserie", myEnte.idsubserie);
            cmdInsert.Parameters.AddWithValue("@idtipologia", myEnte.idtipologia);
            cmdInsert.Parameters.AddWithValue("@descripcion", myEnte.descripcion);
            cmdInsert.Parameters.AddWithValue("@Fechainicio", myEnte.Fechainicio);
            cmdInsert.Parameters.AddWithValue("@Fechafinal", myEnte.Fechafinal);
            cmdInsert.Parameters.AddWithValue("@contenedor", myEnte.contenedor);
            cmdInsert.Parameters.AddWithValue("@compartimiento", myEnte.compartimiento);
            cmdInsert.Parameters.AddWithValue("@idunidad",myEnte.unidad);
            cmdInsert.Parameters.AddWithValue("@idente", myEnte.idente);
            cmdInsert.Parameters.AddWithValue("@codigo", myEnte.codigo);
            cmdInsert.Parameters.AddWithValue("@fasearchivo", myEnte.fasearchivo);
            cmdInsert.Parameters.AddWithValue("@numerounidad", myEnte.numerounidad);
            cmdInsert.Parameters.AddWithValue("@numerounidad2", myEnte.numerounidad2);
            cmdInsert.Parameters.AddWithValue("@idunidad2", myEnte.unidad2);
            cmdInsert.Parameters.AddWithValue("@numerodeidentificacion", myEnte.numerodeidentificacion);

            
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

        public void UpdateExpediente(Expediente myEnte)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = @"Update Expediente SET  
                    idserie=@idserie,
                    idsubserie=@idsubserie,
                    idtipologia=@idtipologia,
                    descripcion=@descripcion,
                    Fechainicio=@Fechainicio,
                    Fechafinal=@Fechafinal,
                    contenedor=@contenedor,
                    compartimiento=@compartimiento,
                    idente=@idente,
                    codigo=@codigo,
                    fasearchivo=@fasearchivo,
                    idunidad=@idunidad,
                    idunidad2=@idunidad2,
                    numerounidad=@numerounidad,
                    numerounidad2=@numerounidad2,
                    numerodeidentificacion=@numerodeidentificacion

                    where id=@id";

            #region params

            cmdUpdate.Parameters.AddWithValue("@id", myEnte.id);

            cmdUpdate.Parameters.AddWithValue("@idserie", myEnte.idserie);
            cmdUpdate.Parameters.AddWithValue("@idsubserie", myEnte.idsubserie);
            cmdUpdate.Parameters.AddWithValue("@idtipologia", myEnte.idtipologia);
            cmdUpdate.Parameters.AddWithValue("@descripcion", myEnte.descripcion);
            cmdUpdate.Parameters.AddWithValue("@Fechainicio", myEnte.Fechainicio);
            cmdUpdate.Parameters.AddWithValue("@Fechafinal", myEnte.Fechafinal);
            cmdUpdate.Parameters.AddWithValue("@contenedor", myEnte.contenedor);
            cmdUpdate.Parameters.AddWithValue("@compartimiento", myEnte.compartimiento);
            cmdUpdate.Parameters.AddWithValue("@idente", myEnte.idente);
            cmdUpdate.Parameters.AddWithValue("@codigo", myEnte.codigo);
            cmdUpdate.Parameters.AddWithValue("@fasearchivo", myEnte.fasearchivo);
            cmdUpdate.Parameters.AddWithValue("@idunidad", myEnte.unidad);
            cmdUpdate.Parameters.AddWithValue("@numerounidad", myEnte.numerounidad);
            cmdUpdate.Parameters.AddWithValue("@idunidad2", myEnte.unidad2);
            cmdUpdate.Parameters.AddWithValue("@numerounidad2", myEnte.numerounidad2);
            cmdUpdate.Parameters.AddWithValue("@numerodeidentificacion", myEnte.numerodeidentificacion);
       

           
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
        /// Delete Radicados
        /// <param name="id">Required a filled instance of Radicados</param>
        /// </summary>
        public bool DeleteExpediente(int id)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM expediente WHERE id=@id";

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