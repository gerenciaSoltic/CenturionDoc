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
    public class UsuariosManagement : ConnectionClass
    {
        #region Constructors
        public UsuariosManagement()
        {

        }
        #endregion

       #region SELECT Commands


        /// <summary>
        /// valida el usuario
        /// <returns>List of Type Fuel Types</returns>
        /// </summary>
        public int CheckLogin(string user, string pass)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * from usuarios where USUARIO =@usuario and CONTRASENA=@contrasena and ACTIVO='True' ";

            cmdSelect.Parameters.AddWithValue("@usuario", user);
            cmdSelect.Parameters.AddWithValue("@contrasena", pass);
            
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);

                int id = 0;
                while (dr.Read())
                {
                    id = Convert.ToInt32(dr["CODIGO"]);

                }
                return id;
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
        /// Gets the whole list of fuel types
        /// <returns>List of Type Fuel Types</returns>
        /// </summary>
        public List<Usuarios> GetAllUsuarios()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            //cmdSelect.CommandText = "SELECT c.CODIGO ,c.NOMBRE, c.USUARIO, c.CONTRASENA, c.ACTIVO FROM Usuarios as c";
            cmdSelect.CommandText = "SELECT c.CODIGO ,c.NOMBRE, c.USUARIO, c.CONTRASENA, c.ACTIVO , c.USUARIOWIN , c.CORREOELECTRONICO , c.CONTRASENACORREO , c.ROL, c.primeravez FROM Usuarios as c";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Usuarios> allUsuarios = new List<Usuarios>();

                while (dr.Read())
                {
                    Usuarios myUsuarios = new Usuarios();

                    #region Params

                    myUsuarios.CODIGO = Convert.ToInt32(dr["CODIGO"]);
                    myUsuarios.NOMBRE = dr["NOMBRE"].ToString();
                    myUsuarios.USUARIO = dr["USUARIO"].ToString();
					myUsuarios.CONTRASENA = dr["CONTRASENA"].ToString();
                    myUsuarios.ACTIVO = dr["ACTIVO"].ToString();

                    myUsuarios.ROL = Convert.ToInt32(dr["ROL"]);
                    myUsuarios.USUARIOWIN = dr["USUARIOWIN"].ToString();
                    myUsuarios.CORREOELECTRONICO = dr["CORREOELECTRONICO"].ToString();
                    myUsuarios.CONTRASENACORREO = dr["CONTRASENACORREO"].ToString();
                    myUsuarios.PRIMERAVEZ = Convert.ToInt32(dr["primeravez"]);
                    #endregion

                    allUsuarios.Add(myUsuarios);

                }
                return allUsuarios;
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
        /// Inserts a new  Usuarios
        /// <param name="myUsuarios">Required a filled instance of Ente</param>
        /// </summary>
        public void InsertUsuarios(Usuarios myUsuarios)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            //cmdInsert.CommandText = "INSERT INTO Usuarios (NOMBRE,USUARIO,CONTRASENA,ACTIVO) VALUES (@nombre, @usuario, @contrasena,@activo)";
            cmdInsert.CommandText = "INSERT INTO Usuarios (NOMBRE,USUARIO,CONTRASENA,ACTIVO,ROL,IDINSTITUCION,USUARIOWIN,CORREOELECTRONICO,CONTRASENACORREO,PRIMERAVEZ) VALUES (@nombre, @usuario, @contrasena,@activo, @rol , @idinstitucion, @usuariowin ,@correoelectronico ,@contrasenacorreo,@PRIMERAVEZ)";


            #region params

            cmdInsert.Parameters.AddWithValue("@nombre", myUsuarios.NOMBRE);
			cmdInsert.Parameters.AddWithValue("@usuario", myUsuarios.USUARIO);
			cmdInsert.Parameters.AddWithValue("@contrasena", myUsuarios.CONTRASENA);
            cmdInsert.Parameters.AddWithValue("@activo", myUsuarios.ACTIVO);

            cmdInsert.Parameters.AddWithValue("@rol", myUsuarios.ROL);
            cmdInsert.Parameters.AddWithValue("@idinstitucion", myUsuarios.IDINSTITUCION);
            cmdInsert.Parameters.AddWithValue("@usuariowin", myUsuarios.USUARIOWIN);
            cmdInsert.Parameters.AddWithValue("@correoelectronico", myUsuarios.CORREOELECTRONICO);
            cmdInsert.Parameters.AddWithValue("@contrasenacorreo", myUsuarios.CONTRASENACORREO);
            cmdInsert.Parameters.AddWithValue("@PRIMERAVEZ", myUsuarios.PRIMERAVEZ);
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

        public void UpdateUsuarios(Usuarios myUsuarios)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

           // cmdUpdate.CommandText = "Update Usuarios SET  NOMBRE=@nombre, USUARIO=@usuario, CONTRASENA=@contrasena, ACTIVO=@activo where CODIGO=@id";
            cmdUpdate.CommandText = "Update Usuarios SET  NOMBRE=@nombre, USUARIO=@usuario, CONTRASENA=@contrasena, ACTIVO=@activo, USUARIOWIN=@usuariowin , CORREOELECTRONICO=@correoelectronico ,CONTRASENACORREO=@contrasenacorreo, ROL = @ROL ,PRIMERAVEZ=@PRIMERAVEZ where CODIGO=@id";

            #region params

            cmdUpdate.Parameters.AddWithValue("@id", myUsuarios.CODIGO);
            cmdUpdate.Parameters.AddWithValue("@nombre", myUsuarios.NOMBRE);
			cmdUpdate.Parameters.AddWithValue("@usuario", myUsuarios.USUARIO);
			cmdUpdate.Parameters.AddWithValue("@contrasena", myUsuarios.CONTRASENA);
            cmdUpdate.Parameters.AddWithValue("@activo", myUsuarios.ACTIVO);

            cmdUpdate.Parameters.AddWithValue("@usuariowin", myUsuarios.USUARIOWIN);
            cmdUpdate.Parameters.AddWithValue("@correoelectronico", myUsuarios.CORREOELECTRONICO);
            cmdUpdate.Parameters.AddWithValue("@contrasenacorreo", myUsuarios.CONTRASENACORREO);
            cmdUpdate.Parameters.AddWithValue("@ROL", myUsuarios.ROL);
            cmdUpdate.Parameters.AddWithValue("@PRIMERAVEZ", myUsuarios.PRIMERAVEZ);
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
        /// Gets all the details of a Usuarios
        /// <returns>Usuarios</returns>
        /// </summary>
        public Usuarios GetUsuariosById(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM Usuarios as c WHERE c.CODIGO = @id ";
            cmdSelect.Parameters.AddWithValue("@id", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                Usuarios myUsuarios = new Usuarios();

                while (dr.Read())
                {

                    #region Params

                    myUsuarios.CODIGO = Convert.ToInt32(dr["CODIGO"]);
                    myUsuarios.NOMBRE = dr["NOMBRE"].ToString();
					myUsuarios.USUARIO = dr["USUARIO"].ToString();
                    myUsuarios.CONTRASENA = dr["CONTRASENA"].ToString();
                    myUsuarios.ACTIVO = dr["ACTIVO"].ToString();
                    myUsuarios.ROL = Convert.ToInt32(dr["ROL"]);
                    myUsuarios.IDINSTITUCION = Convert.ToInt32(dr["idinstitucion"]);

                    myUsuarios.USUARIOWIN = dr["USUARIOWIN"].ToString();
                    myUsuarios.CORREOELECTRONICO = dr["CORREOELECTRONICO"].ToString();
                    myUsuarios.CONTRASENACORREO = dr["CONTRASENACORREO"].ToString();
                    myUsuarios.PRIMERAVEZ = Convert.ToInt32(dr["PRIMERAVEZ"]);
                    #endregion

                }
                return myUsuarios;
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
        /// Delete Usuarios
        /// <param name="id">Required a filled instance of Ente</param>
        /// </summary>
        public bool DeleteUsuarios(int id)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM usuarios WHERE CODIGO=@CODIGO";

            #region params

            cmdInsert.Parameters.AddWithValue("@CODIGO", id);

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



        /// <summary>
        /// valida el usuario Active Directory
        /// <returns>List of Type Fuel Types</returns>
        /// </summary>
        public int CheckLoginWin(string userwin)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT codigo from usuarios where USUARIOWIN =@usuariowin and ACTIVO='True' ";

            cmdSelect.Parameters.AddWithValue("@usuariowin", userwin);


            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);

                int id = 0;
                while (dr.Read())
                {
                    id = Convert.ToInt32(dr["CODIGO"]);

                }
                return id;
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



    }
}