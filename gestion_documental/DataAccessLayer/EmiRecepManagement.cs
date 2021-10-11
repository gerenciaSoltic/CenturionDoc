using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestion_documental.Utils;
using System.Data;
using MySql.Data.MySqlClient;
using gestion_documental.BusinessObjects;

namespace gestion_documental.DataAccessLayer
{
    public class EmiRecepManagement: ConnectionClass
    {
        string host = HttpContext.Current.Request.Url.Host;

        #region Sql
        private string DefaultSelect =
                @"SELECT 
                    c.ID                ,
                    c.NIT               ,
                    c.DESCRIPCION       ,
                    c.DIRECCIONFISICA   ,
                    c.EMAIL             ,
                    c.CONTRASENAEMAIL   ,
					c.FOTO              ,
					c.TELEFONO          ,
					c.CODIGOUSUARIO     ,
                    IF(c.PAIS IS NULL, '0', c.PAIS) as PAIS,
                    IF(c.DEPARTAMENTO IS NULL, '0', c.DEPARTAMENTO) as DEPARTAMENTO,
                    IF(c.MUNICIPIO IS NULL, '0', c.MUNICIPIO) as MUNICIPIO,
					IF(c.CODIGOUSUARIO IS NULL, '0', c.CODIGOUSUARIO) as CODIGOUSUARIO,
					IF(c.IDTIPOEMISOR IS NULL, '0', c.IDTIPOEMISOR) as IDTIPOEMISOR,
                    IF(c.IDCONFICOR IS NULL, '0', c.IDCONFICOR) as IDCONFICOR,
					IF(c.IDENTE IS NULL, '0', c.IDENTE) as IDENTE,
					IF(c.IDCARGO IS NULL, '0', c.IDCARGO) as IDCARGO,
                    IF(c.IDRADICADO IS NULL, '0', c.IDRADICADO) as IDRADICADO,
                    IF(c.LOCAL IS NULL, '0', c.LOCAL) as LOCAL,
                    IF(c.ACTUALIZADO IS NULL, '0', c.ACTUALIZADO) as ACTUALIZADO
                    FROM EmiRecep as c ";

        #endregion

        #region Constructors
        public EmiRecepManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of EmiRecep
        /// <returns>List of EmiRecep Types</returns>
        /// </summary>
        public List<EmiRecep> GetAllEmiRecep()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = this.DefaultSelect+ " order by descripcion";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<EmiRecep> allEmiRecep = new List<EmiRecep>();

                while (dr.Read())
                {
                    EmiRecep myEmiRecep = new EmiRecep();
                    #region Params

					myEmiRecep.ID              =Convert.ToInt32(dr["ID"]);
					myEmiRecep.NIT             =dr["NIT"].ToString();
					myEmiRecep.DESCRIPCION     =dr["DESCRIPCION"].ToString();
                    myEmiRecep.DIRECCIONFISICA = dr["DIRECCIONFISICA"].ToString();
					myEmiRecep.PAIS            =Convert.ToInt32(dr["PAIS"]);
					myEmiRecep.DEPARTAMENTO    =Convert.ToInt32(dr["DEPARTAMENTO"]);
					myEmiRecep.MUNICIPIO       =Convert.ToInt32(dr["MUNICIPIO"]);
					myEmiRecep.EMAIL           =dr["EMAIL"].ToString();
					myEmiRecep.CONTRASENAEMAIL =dr["CONTRASENAEMAIL"].ToString();
					myEmiRecep.FOTO            =dr["FOTO"].ToString();
					myEmiRecep.TELEFONO        =dr["TELEFONO"].ToString();
					myEmiRecep.CODIGOUSUARIO   =Convert.ToInt32(dr["CODIGOUSUARIO"]);
					myEmiRecep.IDTIPOEMISOR    =Convert.ToInt32(dr["IDTIPOEMISOR"]);
					myEmiRecep.IDCONFICOR      =Convert.ToInt32(dr["IDCONFICOR"]);
					myEmiRecep.IDENTE          =Convert.ToInt32(dr["IDENTE"]);
					myEmiRecep.IDCARGO         =Convert.ToInt32(dr["IDCARGO"]);
                    myEmiRecep.IDRADICADO      = Convert.ToInt32(dr["IDRADICADO"]);
                    myEmiRecep.LOCAL           = Convert.ToInt32(dr["LOCAL"]);
                    myEmiRecep.ACTUALIZADO     = Convert.ToInt32(dr["ACTUALIZADO"]);

                    myEmiRecep.cargo = new CargoManagement().GetCargoById(myEmiRecep.IDCARGO);
                    myEmiRecep.conficor = new ConfiCorManagement().GetConfiCorById(myEmiRecep.IDCONFICOR);
                    myEmiRecep.ente = new EnteManagement().GetEnteById(myEmiRecep.IDENTE);
                    myEmiRecep.tipoemisor = new TipoEmiRecManagement().GetTipoEmiRecById(myEmiRecep.IDTIPOEMISOR);
                    myEmiRecep.usuario = new UsuariosManagement().GetUsuariosById(myEmiRecep.CODIGOUSUARIO);
                    myEmiRecep.radicados = new RadicadosManagement().GetRadicadosById(myEmiRecep.IDRADICADO);


                    #endregion

                    allEmiRecep.Add(myEmiRecep);

                }
                return allEmiRecep;
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



        
        public List<EmiRecep> GetAllEmiRecepNitNombre(string Valor)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = this.DefaultSelect + "WHERE c.Nit like '"+Valor+"' OR  c.descripcion LIKE '%"+Valor+"%' order by descripcion";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<EmiRecep> allEmiRecep = new List<EmiRecep>();

                while (dr.Read())
                {
                    EmiRecep myEmiRecep = new EmiRecep();
                    #region Params

                    myEmiRecep.ID = Convert.ToInt32(dr["ID"]);
                    myEmiRecep.NIT = dr["NIT"].ToString();
                    myEmiRecep.DESCRIPCION = dr["DESCRIPCION"].ToString();
                    myEmiRecep.EMAIL = dr["EMAIL"].ToString();
                   


                    #endregion

                    allEmiRecep.Add(myEmiRecep);

                }
                return allEmiRecep;
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



        public List<EmiRecep> GetEmiRecepEnte(int IdEnte)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = this.DefaultSelect + " where idente ="+IdEnte.ToString()+" order by descripcion";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<EmiRecep> allEmiRecep = new List<EmiRecep>();

                while (dr.Read())
                {
                    EmiRecep myEmiRecep = new EmiRecep();
                    #region Params

                    myEmiRecep.ID = Convert.ToInt32(dr["ID"]);
                    myEmiRecep.NIT = dr["NIT"].ToString();
                    myEmiRecep.DESCRIPCION = dr["DESCRIPCION"].ToString();
                    myEmiRecep.DIRECCIONFISICA = dr["DIRECCIONFISICA"].ToString();
                    myEmiRecep.PAIS = Convert.ToInt32(dr["PAIS"]);
                    myEmiRecep.DEPARTAMENTO = Convert.ToInt32(dr["DEPARTAMENTO"]);
                    myEmiRecep.MUNICIPIO = Convert.ToInt32(dr["MUNICIPIO"]);
                    myEmiRecep.EMAIL = dr["EMAIL"].ToString();
                    myEmiRecep.CONTRASENAEMAIL = dr["CONTRASENAEMAIL"].ToString();
                    myEmiRecep.FOTO = dr["FOTO"].ToString();
                    myEmiRecep.TELEFONO = dr["TELEFONO"].ToString();
                    myEmiRecep.CODIGOUSUARIO = Convert.ToInt32(dr["CODIGOUSUARIO"]);
                    myEmiRecep.IDTIPOEMISOR = Convert.ToInt32(dr["IDTIPOEMISOR"]);
                    myEmiRecep.IDCONFICOR = Convert.ToInt32(dr["IDCONFICOR"]);
                    myEmiRecep.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myEmiRecep.IDCARGO = Convert.ToInt32(dr["IDCARGO"]);
                    myEmiRecep.IDRADICADO = Convert.ToInt32(dr["IDRADICADO"]);
                    myEmiRecep.LOCAL = Convert.ToInt32(dr["LOCAL"]);
                    myEmiRecep.ACTUALIZADO = Convert.ToInt32(dr["ACTUALIZADO"]);

                    myEmiRecep.cargo = new CargoManagement().GetCargoById(myEmiRecep.IDCARGO);
                    myEmiRecep.conficor = new ConfiCorManagement().GetConfiCorById(myEmiRecep.IDCONFICOR);
                    myEmiRecep.ente = new EnteManagement().GetEnteById(myEmiRecep.IDENTE);
                    myEmiRecep.tipoemisor = new TipoEmiRecManagement().GetTipoEmiRecById(myEmiRecep.IDTIPOEMISOR);
                    myEmiRecep.usuario = new UsuariosManagement().GetUsuariosById(myEmiRecep.CODIGOUSUARIO);
                    myEmiRecep.radicados = new RadicadosManagement().GetRadicadosById(myEmiRecep.IDRADICADO);


                    #endregion

                    allEmiRecep.Add(myEmiRecep);

                }
                return allEmiRecep;
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




        public List<EmiRecep> GetTipoEmiRecep(int tntipo1,int tntipo2)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = this.DefaultSelect + " order by descripcion";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<EmiRecep> allEmiRecep = new List<EmiRecep>();

                while (dr.Read())
                {
                    EmiRecep myEmiRecep = new EmiRecep();
                    #region Params

                    myEmiRecep.ID = Convert.ToInt32(dr["ID"]);
                    myEmiRecep.NIT = dr["NIT"].ToString();
                    myEmiRecep.DESCRIPCION = dr["DESCRIPCION"].ToString();
                    myEmiRecep.DIRECCIONFISICA = dr["DIRECCIONFISICA"].ToString();
                    myEmiRecep.PAIS = Convert.ToInt32(dr["PAIS"]);
                    myEmiRecep.DEPARTAMENTO = Convert.ToInt32(dr["DEPARTAMENTO"]);
                    myEmiRecep.MUNICIPIO = Convert.ToInt32(dr["MUNICIPIO"]);
                    myEmiRecep.EMAIL = dr["EMAIL"].ToString();
                    myEmiRecep.CONTRASENAEMAIL = dr["CONTRASENAEMAIL"].ToString();
                    myEmiRecep.FOTO = dr["FOTO"].ToString();
                    myEmiRecep.TELEFONO = dr["TELEFONO"].ToString();
                    myEmiRecep.CODIGOUSUARIO = Convert.ToInt32(dr["CODIGOUSUARIO"]);
                    myEmiRecep.IDTIPOEMISOR = Convert.ToInt32(dr["IDTIPOEMISOR"]);
                    myEmiRecep.IDCONFICOR = Convert.ToInt32(dr["IDCONFICOR"]);
                    myEmiRecep.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myEmiRecep.IDCARGO = Convert.ToInt32(dr["IDCARGO"]);
                    myEmiRecep.IDRADICADO = Convert.ToInt32(dr["IDRADICADO"]);
                    myEmiRecep.LOCAL = Convert.ToInt32(dr["LOCAL"]);
                    myEmiRecep.ACTUALIZADO = Convert.ToInt32(dr["ACTUALIZADO"]);

                    myEmiRecep.cargo = new CargoManagement().GetCargoById(myEmiRecep.IDCARGO);
                    myEmiRecep.conficor = new ConfiCorManagement().GetConfiCorById(myEmiRecep.IDCONFICOR);
                    myEmiRecep.ente = new EnteManagement().GetEnteById(myEmiRecep.IDENTE);
                    myEmiRecep.tipoemisor = new TipoEmiRecManagement().GetTipoEmiRecById(myEmiRecep.IDTIPOEMISOR);
                    myEmiRecep.usuario = new UsuariosManagement().GetUsuariosById(myEmiRecep.CODIGOUSUARIO);
                    myEmiRecep.radicados = new RadicadosManagement().GetRadicadosById(myEmiRecep.IDRADICADO);


                    #endregion

                    allEmiRecep.Add(myEmiRecep);

                }
                return allEmiRecep;
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




        // Devuelve listado de funcionarios


        public List<Funcionario> GetAllFuncionarios( int idradicado)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT CONCAT(trim(ente.descripcion),' - ',trim(emirecep.descripcion)) as Funcionario,emirecep.id FROM ente,emirecep WHERE ente.idente = emirecep.idente and emirecep.idtipoemisor in (1,4,5) and idradicado ="+idradicado+" and inactivo <> 1 ORDER BY ente.descripcion,emirecep.descripcion";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Funcionario> allFuncionario = new List<Funcionario>();

                while (dr.Read())
                {
                    Funcionario MyFuncionario = new Funcionario();
                    #region Params

                    MyFuncionario.IDEMIRECEP = Convert.ToInt32(dr["id"].ToString());
                    MyFuncionario.FUNCIONARIO = dr["funcionario"].ToString();

                    #endregion

                    allFuncionario.Add(MyFuncionario);

                }
                return allFuncionario;
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
        /// Gets all the details of a CorreoEntrante
        /// <returns>EmiRecep</returns>
        /// </summary>
        public EmiRecep GetEmiRecepById(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE c.ID = @ID ";
            cmdSelect.Parameters.AddWithValue("@ID", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                EmiRecep myEmiRecep = new EmiRecep();

                while (dr.Read())
                {

                    #region Params

					myEmiRecep.ID              =Convert.ToInt32(dr["ID"]);
					myEmiRecep.NIT             =dr["NIT"].ToString();
					myEmiRecep.DESCRIPCION     =dr["DESCRIPCION"].ToString();
                    myEmiRecep.DIRECCIONFISICA = dr["DIRECCIONFISICA"].ToString();
					myEmiRecep.PAIS            =Convert.ToInt32(dr["PAIS"]);
					myEmiRecep.DEPARTAMENTO    =Convert.ToInt32(dr["DEPARTAMENTO"]);
					myEmiRecep.MUNICIPIO       =Convert.ToInt32(dr["MUNICIPIO"]);
					myEmiRecep.EMAIL           =dr["EMAIL"].ToString();
					myEmiRecep.CONTRASENAEMAIL =dr["CONTRASENAEMAIL"].ToString();
					myEmiRecep.FOTO            =dr["FOTO"].ToString();
					myEmiRecep.TELEFONO        =dr["TELEFONO"].ToString();
					myEmiRecep.CODIGOUSUARIO   =Convert.ToInt32(dr["CODIGOUSUARIO"]);
					myEmiRecep.IDTIPOEMISOR    =Convert.ToInt32(dr["IDTIPOEMISOR"]);
					myEmiRecep.IDCONFICOR      =Convert.ToInt32(dr["IDCONFICOR"]);
					myEmiRecep.IDENTE          =Convert.ToInt32(dr["IDENTE"]);
					myEmiRecep.IDCARGO         =Convert.ToInt32(dr["IDCARGO"]);
                    myEmiRecep.IDRADICADO      = Convert.ToInt32(dr["IDRADICADO"]);
                    myEmiRecep.LOCAL           = Convert.ToInt32(dr["LOCAL"]);
                    myEmiRecep.ACTUALIZADO     = Convert.ToInt32(dr["ACTUALIZADO"]);

                    myEmiRecep.cargo = new CargoManagement().GetCargoById(myEmiRecep.IDCARGO);
                    myEmiRecep.conficor = new ConfiCorManagement().GetConfiCorById(myEmiRecep.IDCONFICOR);
                    myEmiRecep.ente = new EnteManagement().GetEnteById(myEmiRecep.IDENTE);
                    myEmiRecep.tipoemisor = new TipoEmiRecManagement().GetTipoEmiRecById(myEmiRecep.IDTIPOEMISOR);
                    myEmiRecep.usuario = new UsuariosManagement().GetUsuariosById(myEmiRecep.CODIGOUSUARIO);
                    myEmiRecep.radicados = new RadicadosManagement().GetRadicadosById(myEmiRecep.IDRADICADO);

                    #endregion

                }
                return myEmiRecep;
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



        public EmiRecep GetEmiRecepByIdEnte(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE c.IDente = @ID ";
            cmdSelect.Parameters.AddWithValue("@ID", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                EmiRecep myEmiRecep = new EmiRecep();

                while (dr.Read())
                {

                    #region Params

                    myEmiRecep.ID = Convert.ToInt32(dr["ID"]);
                    myEmiRecep.NIT = dr["NIT"].ToString();
                    myEmiRecep.DESCRIPCION = dr["DESCRIPCION"].ToString();
                    myEmiRecep.DIRECCIONFISICA = dr["DIRECCIONFISICA"].ToString();
                    myEmiRecep.PAIS = Convert.ToInt32(dr["PAIS"]);
                    myEmiRecep.DEPARTAMENTO = Convert.ToInt32(dr["DEPARTAMENTO"]);
                    myEmiRecep.MUNICIPIO = Convert.ToInt32(dr["MUNICIPIO"]);
                    myEmiRecep.EMAIL = dr["EMAIL"].ToString();
                    myEmiRecep.CONTRASENAEMAIL = dr["CONTRASENAEMAIL"].ToString();
                    myEmiRecep.FOTO = dr["FOTO"].ToString();
                    myEmiRecep.TELEFONO = dr["TELEFONO"].ToString();
                    myEmiRecep.CODIGOUSUARIO = Convert.ToInt32(dr["CODIGOUSUARIO"]);
                    myEmiRecep.IDTIPOEMISOR = Convert.ToInt32(dr["IDTIPOEMISOR"]);
                    myEmiRecep.IDCONFICOR = Convert.ToInt32(dr["IDCONFICOR"]);
                    myEmiRecep.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myEmiRecep.IDCARGO = Convert.ToInt32(dr["IDCARGO"]);
                    myEmiRecep.IDRADICADO = Convert.ToInt32(dr["IDRADICADO"]);
                    myEmiRecep.LOCAL = Convert.ToInt32(dr["LOCAL"]);
                    myEmiRecep.ACTUALIZADO = Convert.ToInt32(dr["ACTUALIZADO"]);

                    myEmiRecep.cargo = new CargoManagement().GetCargoById(myEmiRecep.IDCARGO);
                    myEmiRecep.conficor = new ConfiCorManagement().GetConfiCorById(myEmiRecep.IDCONFICOR);
                    myEmiRecep.ente = new EnteManagement().GetEnteById(myEmiRecep.IDENTE);
                    myEmiRecep.tipoemisor = new TipoEmiRecManagement().GetTipoEmiRecById(myEmiRecep.IDTIPOEMISOR);
                    myEmiRecep.usuario = new UsuariosManagement().GetUsuariosById(myEmiRecep.CODIGOUSUARIO);
                    myEmiRecep.radicados = new RadicadosManagement().GetRadicadosById(myEmiRecep.IDRADICADO);

                    #endregion

                }
                return myEmiRecep;
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


        public EmiRecep GetEmiRecepByIdusuario(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE c.CODIGOUSUARIO = @ID ";
            cmdSelect.Parameters.AddWithValue("@ID", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                EmiRecep myEmiRecep = new EmiRecep();

                while (dr.Read())
                {

                    #region Params

                    myEmiRecep.ID = Convert.ToInt32(dr["ID"]);
                    myEmiRecep.NIT = dr["NIT"].ToString();
                    myEmiRecep.DESCRIPCION = dr["DESCRIPCION"].ToString();
                    myEmiRecep.DIRECCIONFISICA = dr["DIRECCIONFISICA"].ToString();
                    myEmiRecep.PAIS = Convert.ToInt32(dr["PAIS"]);
                    myEmiRecep.DEPARTAMENTO = Convert.ToInt32(dr["DEPARTAMENTO"]);
                    myEmiRecep.MUNICIPIO = Convert.ToInt32(dr["MUNICIPIO"]);
                    myEmiRecep.EMAIL = dr["EMAIL"].ToString();
                    myEmiRecep.CONTRASENAEMAIL = dr["CONTRASENAEMAIL"].ToString();
                    myEmiRecep.FOTO = dr["FOTO"].ToString();
                    myEmiRecep.TELEFONO = dr["TELEFONO"].ToString();
                    myEmiRecep.CODIGOUSUARIO = Convert.ToInt32(dr["CODIGOUSUARIO"]);
                    myEmiRecep.IDTIPOEMISOR = Convert.ToInt32(dr["IDTIPOEMISOR"]);
                    myEmiRecep.IDCONFICOR = Convert.ToInt32(dr["IDCONFICOR"]);
                    myEmiRecep.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myEmiRecep.IDCARGO = Convert.ToInt32(dr["IDCARGO"]);
                    myEmiRecep.IDRADICADO = Convert.ToInt32(dr["IDRADICADO"]);
                    myEmiRecep.LOCAL = Convert.ToInt32(dr["LOCAL"]);
                    myEmiRecep.ACTUALIZADO = Convert.ToInt32(dr["ACTUALIZADO"]);

                    myEmiRecep.cargo = new CargoManagement().GetCargoById(myEmiRecep.IDCARGO);
                    myEmiRecep.conficor = new ConfiCorManagement().GetConfiCorById(myEmiRecep.IDCONFICOR);
                    myEmiRecep.ente = new EnteManagement().GetEnteById(myEmiRecep.IDENTE);
                    myEmiRecep.tipoemisor = new TipoEmiRecManagement().GetTipoEmiRecById(myEmiRecep.IDTIPOEMISOR);
                    myEmiRecep.usuario = new UsuariosManagement().GetUsuariosById(myEmiRecep.CODIGOUSUARIO);
                    myEmiRecep.radicados = new RadicadosManagement().GetRadicadosById(myEmiRecep.IDRADICADO);

                    #endregion

                }
                return myEmiRecep;
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

        public EmiRecep GetEmiRecepJefe(int idEnte)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT emirecep.* FROM emirecep,cargo WHERE emirecep.idcargo = cargo.idcargo AND cargo.lider = 1 and emirecep.IDENTE = @IdEnte ";
            cmdSelect.Parameters.AddWithValue("@idEnte", idEnte);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                EmiRecep myEmiRecep = new EmiRecep();

                while (dr.Read())
                {

                    #region Params

                    myEmiRecep.ID = Convert.ToInt32(dr["ID"]);
                    myEmiRecep.NIT = dr["NIT"].ToString();
                    myEmiRecep.DESCRIPCION = dr["DESCRIPCION"].ToString();
                    myEmiRecep.DIRECCIONFISICA = dr["DIRECCIONFISICA"].ToString();
                    myEmiRecep.PAIS = Convert.ToInt32(dr["PAIS"]);
                    myEmiRecep.DEPARTAMENTO = Convert.ToInt32(dr["DEPARTAMENTO"]);
                    myEmiRecep.MUNICIPIO = Convert.ToInt32(dr["MUNICIPIO"]);
                    myEmiRecep.EMAIL = dr["EMAIL"].ToString();
                    myEmiRecep.CONTRASENAEMAIL = dr["CONTRASENAEMAIL"].ToString();
                    myEmiRecep.FOTO = dr["FOTO"].ToString();
                    myEmiRecep.TELEFONO = dr["TELEFONO"].ToString();
                    myEmiRecep.CODIGOUSUARIO = Convert.ToInt32(dr["CODIGOUSUARIO"]);
                    myEmiRecep.IDTIPOEMISOR = Convert.ToInt32(dr["IDTIPOEMISOR"]);
                    myEmiRecep.IDCONFICOR = Convert.ToInt32(dr["IDCONFICOR"]);
                    myEmiRecep.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myEmiRecep.IDCARGO = Convert.ToInt32(dr["IDCARGO"]);
                    myEmiRecep.IDRADICADO = Convert.ToInt32(dr["IDRADICADO"]);
                    myEmiRecep.LOCAL = Convert.ToInt32(dr["LOCAL"]);
                    myEmiRecep.ACTUALIZADO = Convert.ToInt32(dr["ACTUALIZADO"]);

                    myEmiRecep.cargo = new CargoManagement().GetCargoById(myEmiRecep.IDCARGO);
                    myEmiRecep.conficor = new ConfiCorManagement().GetConfiCorById(myEmiRecep.IDCONFICOR);
                    myEmiRecep.ente = new EnteManagement().GetEnteById(myEmiRecep.IDENTE);
                    myEmiRecep.tipoemisor = new TipoEmiRecManagement().GetTipoEmiRecById(myEmiRecep.IDTIPOEMISOR);
                    myEmiRecep.usuario = new UsuariosManagement().GetUsuariosById(myEmiRecep.CODIGOUSUARIO);
                    myEmiRecep.radicados = new RadicadosManagement().GetRadicadosById(myEmiRecep.IDRADICADO);

                    #endregion

                }
                return myEmiRecep;
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
        /// Gets all the details of a CorreoEntrante
        /// <returns>EmiRecep</returns>
        /// </summary>
        public EmiRecep GetEmiRecepByCodUsuario(int codUsuario)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE c.CODIGOUSUARIO = @cod ";
            cmdSelect.Parameters.AddWithValue("@cod", codUsuario);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                EmiRecep myEmiRecep = new EmiRecep();

                while (dr.Read())
                {

                    #region Params

                    myEmiRecep.ID = Convert.ToInt32(dr["ID"]);
                    myEmiRecep.NIT = dr["NIT"].ToString();
                    myEmiRecep.DESCRIPCION = dr["DESCRIPCION"].ToString();
                    myEmiRecep.DIRECCIONFISICA = dr["DIRECCIONFISICA"].ToString();
                    myEmiRecep.PAIS = Convert.ToInt32(dr["PAIS"]);
                    myEmiRecep.DEPARTAMENTO = Convert.ToInt32(dr["DEPARTAMENTO"]);
                    myEmiRecep.MUNICIPIO = Convert.ToInt32(dr["MUNICIPIO"]);
                    myEmiRecep.EMAIL = dr["EMAIL"].ToString();
                    myEmiRecep.CONTRASENAEMAIL = dr["CONTRASENAEMAIL"].ToString();
                    myEmiRecep.FOTO = dr["FOTO"].ToString();
                    myEmiRecep.TELEFONO = dr["TELEFONO"].ToString();
                    myEmiRecep.CODIGOUSUARIO = Convert.ToInt32(dr["CODIGOUSUARIO"]);
                    myEmiRecep.IDTIPOEMISOR = Convert.ToInt32(dr["IDTIPOEMISOR"]);
                    myEmiRecep.IDCONFICOR = Convert.ToInt32(dr["IDCONFICOR"]);
                    myEmiRecep.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myEmiRecep.IDCARGO = Convert.ToInt32(dr["IDCARGO"]);
                    myEmiRecep.IDRADICADO = Convert.ToInt32(dr["IDRADICADO"]);
                    myEmiRecep.LOCAL = Convert.ToInt32(dr["LOCAL"]);
                    myEmiRecep.ACTUALIZADO = Convert.ToInt32(dr["ACTUALIZADO"]);

                    myEmiRecep.cargo = new CargoManagement().GetCargoById(myEmiRecep.IDCARGO);
                    myEmiRecep.conficor = new ConfiCorManagement().GetConfiCorById(myEmiRecep.IDCONFICOR);
                    myEmiRecep.ente = new EnteManagement().GetEnteById(myEmiRecep.IDENTE);
                    myEmiRecep.tipoemisor = new TipoEmiRecManagement().GetTipoEmiRecById(myEmiRecep.IDTIPOEMISOR);
                    myEmiRecep.usuario = new UsuariosManagement().GetUsuariosById(myEmiRecep.CODIGOUSUARIO);
                    myEmiRecep.radicados = new RadicadosManagement().GetRadicadosById(myEmiRecep.IDRADICADO);

                    #endregion

                }
                return myEmiRecep;
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


        public EmiRecep GetEmiRecepByIdTipoEmisor(int tipoEmisor)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE c.IDTIPOEMISOR = @cod ";
            cmdSelect.Parameters.AddWithValue("@cod", tipoEmisor);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                EmiRecep myEmiRecep = new EmiRecep();

                while (dr.Read())
                {

                    #region Params

                    myEmiRecep.ID = Convert.ToInt32(dr["ID"]);
                    myEmiRecep.NIT = dr["NIT"].ToString();
                    myEmiRecep.DESCRIPCION = dr["DESCRIPCION"].ToString();
                    myEmiRecep.DIRECCIONFISICA = dr["DIRECCIONFISICA"].ToString();
                    myEmiRecep.PAIS = Convert.ToInt32(dr["PAIS"]);
                    myEmiRecep.DEPARTAMENTO = Convert.ToInt32(dr["DEPARTAMENTO"]);
                    myEmiRecep.MUNICIPIO = Convert.ToInt32(dr["MUNICIPIO"]);
                    myEmiRecep.EMAIL = dr["EMAIL"].ToString();
                    myEmiRecep.CONTRASENAEMAIL = dr["CONTRASENAEMAIL"].ToString();
                    myEmiRecep.FOTO = dr["FOTO"].ToString();
                    myEmiRecep.TELEFONO = dr["TELEFONO"].ToString();
                    myEmiRecep.CODIGOUSUARIO = Convert.ToInt32(dr["CODIGOUSUARIO"]);
                    myEmiRecep.IDTIPOEMISOR = Convert.ToInt32(dr["IDTIPOEMISOR"]);
                    myEmiRecep.IDCONFICOR = Convert.ToInt32(dr["IDCONFICOR"]);
                    myEmiRecep.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myEmiRecep.IDCARGO = Convert.ToInt32(dr["IDCARGO"]);
                    myEmiRecep.IDRADICADO = Convert.ToInt32(dr["IDRADICADO"]);
                    myEmiRecep.LOCAL = Convert.ToInt32(dr["LOCAL"]);
                    myEmiRecep.ACTUALIZADO = Convert.ToInt32(dr["ACTUALIZADO"]);

                    myEmiRecep.cargo = new CargoManagement().GetCargoById(myEmiRecep.IDCARGO);
                    myEmiRecep.conficor = new ConfiCorManagement().GetConfiCorById(myEmiRecep.IDCONFICOR);
                    myEmiRecep.ente = new EnteManagement().GetEnteById(myEmiRecep.IDENTE);
                    myEmiRecep.tipoemisor = new TipoEmiRecManagement().GetTipoEmiRecById(myEmiRecep.IDTIPOEMISOR);
                    myEmiRecep.usuario = new UsuariosManagement().GetUsuariosById(myEmiRecep.CODIGOUSUARIO);
                    myEmiRecep.radicados = new RadicadosManagement().GetRadicadosById(myEmiRecep.IDRADICADO);

                    #endregion

                }
                return myEmiRecep;
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
        /// Gets all the details of a CorreoEntrante
        /// <returns>EmiRecep</returns>
        /// </summary>
        /// 
     
        public EmiRecep GetEmiRecepByEmail(String email)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE c.EMAIL = @email ";
            cmdSelect.Parameters.AddWithValue("@email", email);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                EmiRecep myEmiRecep = new EmiRecep();

                while (dr.Read())
                {

                    #region Params

                    myEmiRecep.ID = Convert.ToInt32(dr["ID"]);
                    myEmiRecep.NIT = dr["NIT"].ToString();
                    myEmiRecep.DESCRIPCION = dr["DESCRIPCION"].ToString();
                    myEmiRecep.DIRECCIONFISICA = dr["DIRECCIONFISICA"].ToString();
                    myEmiRecep.PAIS = Convert.ToInt32(dr["PAIS"]);
                    myEmiRecep.DEPARTAMENTO = Convert.ToInt32(dr["DEPARTAMENTO"]);
                    myEmiRecep.MUNICIPIO = Convert.ToInt32(dr["MUNICIPIO"]);
                    myEmiRecep.EMAIL = dr["EMAIL"].ToString();
                    myEmiRecep.CONTRASENAEMAIL = dr["CONTRASENAEMAIL"].ToString();
                    myEmiRecep.FOTO = dr["FOTO"].ToString();
                    myEmiRecep.TELEFONO = dr["TELEFONO"].ToString();
                    myEmiRecep.CODIGOUSUARIO = Convert.ToInt32(dr["CODIGOUSUARIO"]);
                    myEmiRecep.IDTIPOEMISOR = Convert.ToInt32(dr["IDTIPOEMISOR"]);
                    myEmiRecep.IDCONFICOR = Convert.ToInt32(dr["IDCONFICOR"]);
                    myEmiRecep.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myEmiRecep.IDCARGO = Convert.ToInt32(dr["IDCARGO"]);
                    myEmiRecep.IDRADICADO = Convert.ToInt32(dr["IDRADICADO"]);
                    myEmiRecep.LOCAL = Convert.ToInt32(dr["LOCAL"]);
                    myEmiRecep.ACTUALIZADO = Convert.ToInt32(dr["ACTUALIZADO"]);

                    myEmiRecep.cargo = new CargoManagement().GetCargoById(myEmiRecep.IDCARGO);
                    myEmiRecep.conficor = new ConfiCorManagement().GetConfiCorById(myEmiRecep.IDCONFICOR);
                    myEmiRecep.ente = new EnteManagement().GetEnteById(myEmiRecep.IDENTE);
                    myEmiRecep.tipoemisor = new TipoEmiRecManagement().GetTipoEmiRecById(myEmiRecep.IDTIPOEMISOR);
                    myEmiRecep.usuario = new UsuariosManagement().GetUsuariosById(myEmiRecep.CODIGOUSUARIO);
                    myEmiRecep.radicados = new RadicadosManagement().GetRadicadosById(myEmiRecep.IDRADICADO);

                    #endregion

                }
                return myEmiRecep;
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



        public List<EmiRecep> GetAllEmiRecepByEmail()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE c.EMAIL <> '' AND c.email IS NOT NULL AND EMAIL LIKE '%@%' ORDER BY DESCRIPCION";
           
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                
                List<EmiRecep> allEmirecep = new List<EmiRecep>();

                while (dr.Read())
                {

                    #region Params
                    EmiRecep myEmiRecep = new EmiRecep();
                    myEmiRecep.ID = Convert.ToInt32(dr["ID"]);
                    myEmiRecep.NIT = dr["NIT"].ToString();
                    myEmiRecep.DESCRIPCION = dr["DESCRIPCION"].ToString();
                    myEmiRecep.DIRECCIONFISICA = dr["DIRECCIONFISICA"].ToString();
                    myEmiRecep.PAIS = Convert.ToInt32(dr["PAIS"]);
                    myEmiRecep.DEPARTAMENTO = Convert.ToInt32(dr["DEPARTAMENTO"]);
                    myEmiRecep.MUNICIPIO = Convert.ToInt32(dr["MUNICIPIO"]);
                    myEmiRecep.EMAIL = dr["EMAIL"].ToString();
                    myEmiRecep.CONTRASENAEMAIL = dr["CONTRASENAEMAIL"].ToString();
                    myEmiRecep.FOTO = dr["FOTO"].ToString();
                    myEmiRecep.TELEFONO = dr["TELEFONO"].ToString();
                    myEmiRecep.CODIGOUSUARIO = Convert.ToInt32(dr["CODIGOUSUARIO"]);
                    myEmiRecep.IDTIPOEMISOR = Convert.ToInt32(dr["IDTIPOEMISOR"]);
                    myEmiRecep.IDCONFICOR = Convert.ToInt32(dr["IDCONFICOR"]);
                    myEmiRecep.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myEmiRecep.IDCARGO = Convert.ToInt32(dr["IDCARGO"]);
                    myEmiRecep.IDRADICADO = Convert.ToInt32(dr["IDRADICADO"]);
                    myEmiRecep.LOCAL = Convert.ToInt32(dr["LOCAL"]);
                    myEmiRecep.ACTUALIZADO = Convert.ToInt32(dr["ACTUALIZADO"]);
                    /*
                    myEmiRecep.cargo = new CargoManagement().GetCargoById(myEmiRecep.IDCARGO);
                    myEmiRecep.conficor = new ConfiCorManagement().GetConfiCorById(myEmiRecep.IDCONFICOR);
                    myEmiRecep.ente = new EnteManagement().GetEnteById(myEmiRecep.IDENTE);
                    myEmiRecep.tipoemisor = new TipoEmiRecManagement().GetTipoEmiRecById(myEmiRecep.IDTIPOEMISOR);
                    myEmiRecep.usuario = new UsuariosManagement().GetUsuariosById(myEmiRecep.CODIGOUSUARIO);
                    myEmiRecep.radicados = new RadicadosManagement().GetRadicadosById(myEmiRecep.IDRADICADO);
                    */
                    allEmirecep.Add(myEmiRecep);
                    #endregion

                }
                return allEmirecep;
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


        public List<EmiRecep> GetEmiRecepLocal()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = this.DefaultSelect + " where local = 1 and actualizado = 0 order by descripcion";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<EmiRecep> allEmiRecep = new List<EmiRecep>();

                while (dr.Read())
                {
                    EmiRecep myEmiRecep = new EmiRecep();
                    #region Params

                    myEmiRecep.ID = Convert.ToInt32(dr["ID"]);
                    myEmiRecep.NIT = dr["NIT"].ToString();
                    myEmiRecep.DESCRIPCION = dr["DESCRIPCION"].ToString();
                    myEmiRecep.DIRECCIONFISICA = dr["DIRECCIONFISICA"].ToString();
                    myEmiRecep.PAIS = Convert.ToInt32(dr["PAIS"]);
                    myEmiRecep.DEPARTAMENTO = Convert.ToInt32(dr["DEPARTAMENTO"]);
                    myEmiRecep.MUNICIPIO = Convert.ToInt32(dr["MUNICIPIO"]);
                    myEmiRecep.EMAIL = dr["EMAIL"].ToString();
                    myEmiRecep.CONTRASENAEMAIL = dr["CONTRASENAEMAIL"].ToString();
                    myEmiRecep.FOTO = dr["FOTO"].ToString();
                    myEmiRecep.TELEFONO = dr["TELEFONO"].ToString();
                    myEmiRecep.CODIGOUSUARIO = Convert.ToInt32(dr["CODIGOUSUARIO"]);
                    myEmiRecep.IDTIPOEMISOR = Convert.ToInt32(dr["IDTIPOEMISOR"]);
                    myEmiRecep.IDCONFICOR = Convert.ToInt32(dr["IDCONFICOR"]);
                    myEmiRecep.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myEmiRecep.IDCARGO = Convert.ToInt32(dr["IDCARGO"]);
                    myEmiRecep.IDRADICADO = Convert.ToInt32(dr["IDRADICADO"]);
                    myEmiRecep.LOCAL = Convert.ToInt32(dr["LOCAL"]);
                    myEmiRecep.ACTUALIZADO = Convert.ToInt32(dr["ACTUALIZADO"]);

                    myEmiRecep.cargo = new CargoManagement().GetCargoById(myEmiRecep.IDCARGO);
                    myEmiRecep.conficor = new ConfiCorManagement().GetConfiCorById(myEmiRecep.IDCONFICOR);
                    myEmiRecep.ente = new EnteManagement().GetEnteById(myEmiRecep.IDENTE);
                    myEmiRecep.tipoemisor = new TipoEmiRecManagement().GetTipoEmiRecById(myEmiRecep.IDTIPOEMISOR);
                    myEmiRecep.usuario = new UsuariosManagement().GetUsuariosById(myEmiRecep.CODIGOUSUARIO);
                    myEmiRecep.radicados = new RadicadosManagement().GetRadicadosById(myEmiRecep.IDRADICADO);


                    #endregion

                    allEmiRecep.Add(myEmiRecep);

                }
                return allEmiRecep;
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
        /// Inserts a new  CorreoEntrante
        /// <param name="myEmiRecep">Required a filled instance of CorreoEntrante</param>
        /// </summary>
        public int InsertEmiRecep(EmiRecep myEmiRecep)
        {
            string sql = @"INSERT INTO EmiRecep (
				ID              ,
				NIT             ,
				DESCRIPCION     ,
				DIRECCIONFISICA ,
				PAIS            ,
				DEPARTAMENTO    ,
				MUNICIPIO       ,
				EMAIL           ,
				CONTRASENAEMAIL ,
				FOTO            ,
				TELEFONO        ,
				CODIGOUSUARIO   ,
				IDTIPOEMISOR    ,
				IDCONFICOR      ,
				IDENTE          ,
				IDCARGO         ,
                IDRADICADO      ,
                LOCAL           ,
                ACTUALIZADO     ) VALUES (
					@ID               ,
					@NIT              ,
					@DESCRIPCION      ,
					@DIRECCIONFISICA  ,
					@PAIS             ,
					@DEPARTAMENTO     ,
					@MUNICIPIO        ,
					@EMAIL            ,
					@CONTRASENAEMAIL  ,
					@FOTO             ,
					@TELEFONO         ,
					@CODIGOUSUARIO    ,
					@IDTIPOEMISOR     ,
					@IDCONFICOR       ,
					@IDENTE           ,
					@IDCARGO          ,
                    @IDRADICADO       ,
                    @LOCAL            ,
                    @ACTUALIZADO
				);SELECT LAST_INSERT_ID()";
            
            int id = 0;

            //===============================================CONEXION REMOTA========================================

            //bool Sinred = false;

            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            
            if (url.ToUpper().Contains("LOCALHOST"))
            {

                myEmiRecep.LOCAL = 1;
            }
            MySqlCommand cmdInsert = Connection.CreateCommand();

            try
            {
            cmdInsert.CommandText = sql;

            #region params

            cmdInsert.Parameters.AddWithValue("@ID", myEmiRecep.ID);
            cmdInsert.Parameters.AddWithValue("@NIT", myEmiRecep.NIT);
            cmdInsert.Parameters.AddWithValue("@DESCRIPCION", myEmiRecep.DESCRIPCION);
            cmdInsert.Parameters.AddWithValue("@DIRECCIONFISICA", myEmiRecep.DIRECCIONFISICA);
            cmdInsert.Parameters.AddWithValue("@PAIS", myEmiRecep.PAIS);
            cmdInsert.Parameters.AddWithValue("@DEPARTAMENTO", myEmiRecep.DEPARTAMENTO);
            cmdInsert.Parameters.AddWithValue("@MUNICIPIO", myEmiRecep.MUNICIPIO);
            cmdInsert.Parameters.AddWithValue("@EMAIL", myEmiRecep.EMAIL);
            cmdInsert.Parameters.AddWithValue("@CONTRASENAEMAIL", myEmiRecep.CONTRASENAEMAIL);
            cmdInsert.Parameters.AddWithValue("@FOTO", myEmiRecep.FOTO);
            cmdInsert.Parameters.AddWithValue("@TELEFONO", myEmiRecep.TELEFONO);
            cmdInsert.Parameters.AddWithValue("@CODIGOUSUARIO", myEmiRecep.CODIGOUSUARIO);
            cmdInsert.Parameters.AddWithValue("@IDTIPOEMISOR", myEmiRecep.IDTIPOEMISOR);
            cmdInsert.Parameters.AddWithValue("@IDCONFICOR", myEmiRecep.IDCONFICOR);
            cmdInsert.Parameters.AddWithValue("@IDENTE", myEmiRecep.IDENTE);
            cmdInsert.Parameters.AddWithValue("@IDCARGO", myEmiRecep.IDCARGO);
            cmdInsert.Parameters.AddWithValue("@IDRADICADO", myEmiRecep.IDRADICADO);
            cmdInsert.Parameters.AddWithValue("@LOCAL", myEmiRecep.LOCAL);
            cmdInsert.Parameters.AddWithValue("@ACTUALIZADO", myEmiRecep.ACTUALIZADO);
            #endregion
            
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();
                id = Convert.ToInt32(cmdInsert.ExecuteNonQuery());
            }
            catch (MySqlException ex)
            {
                // nada
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }

           

            return id;
  
        }



        public int InsertRemoto(EmiRecep myEmiRecep)
        {
            string sql = @"INSERT INTO EmiRecep (
			    NIT             ,
				DESCRIPCION     ,
				DIRECCIONFISICA ,
				PAIS            ,
				DEPARTAMENTO    ,
				MUNICIPIO       ,
				EMAIL           ,
				CONTRASENAEMAIL ,
				FOTO            ,
				TELEFONO        ,
				CODIGOUSUARIO   ,
				IDTIPOEMISOR    ,
				IDCONFICOR      ,
				IDENTE          ,
				IDCARGO         ,
                IDRADICADO      ,
                LOCAL           ,
                ACTUALIZADO     ) VALUES (
					@NIT              ,
					@DESCRIPCION      ,
					@DIRECCIONFISICA  ,
					@PAIS             ,
					@DEPARTAMENTO     ,
					@MUNICIPIO        ,
					@EMAIL            ,
					@CONTRASENAEMAIL  ,
					@FOTO             ,
					@TELEFONO         ,
					@CODIGOUSUARIO    ,
					@IDTIPOEMISOR     ,
					@IDCONFICOR       ,
					@IDENTE           ,
					@IDCARGO          ,
                    @IDRADICADO       ,
                    @LOCAL            ,
                    @ACTUALIZADO
				);SELECT LAST_INSERT_ID()";
            
            int id = 0;

            //===============================================CONEXION REMOTA========================================

            //bool Sinred = false;

            MySqlCommand cmdInsert = ConnectionLocal.CreateCommand();

            try
            {
            cmdInsert.CommandText = sql;

            #region params

            cmdInsert.Parameters.AddWithValue("@NIT", myEmiRecep.NIT);
            cmdInsert.Parameters.AddWithValue("@DESCRIPCION", myEmiRecep.DESCRIPCION);
            cmdInsert.Parameters.AddWithValue("@DIRECCIONFISICA", myEmiRecep.DIRECCIONFISICA);
            cmdInsert.Parameters.AddWithValue("@PAIS", myEmiRecep.PAIS);
            cmdInsert.Parameters.AddWithValue("@DEPARTAMENTO", myEmiRecep.DEPARTAMENTO);
            cmdInsert.Parameters.AddWithValue("@MUNICIPIO", myEmiRecep.MUNICIPIO);
            cmdInsert.Parameters.AddWithValue("@EMAIL", myEmiRecep.EMAIL);
            cmdInsert.Parameters.AddWithValue("@CONTRASENAEMAIL", myEmiRecep.CONTRASENAEMAIL);
            cmdInsert.Parameters.AddWithValue("@FOTO", myEmiRecep.FOTO);
            cmdInsert.Parameters.AddWithValue("@TELEFONO", myEmiRecep.TELEFONO);
            cmdInsert.Parameters.AddWithValue("@CODIGOUSUARIO", myEmiRecep.CODIGOUSUARIO);
            cmdInsert.Parameters.AddWithValue("@IDTIPOEMISOR", myEmiRecep.IDTIPOEMISOR);
            cmdInsert.Parameters.AddWithValue("@IDCONFICOR", myEmiRecep.IDCONFICOR);
            cmdInsert.Parameters.AddWithValue("@IDENTE", myEmiRecep.IDENTE);
            cmdInsert.Parameters.AddWithValue("@IDCARGO", myEmiRecep.IDCARGO);
            cmdInsert.Parameters.AddWithValue("@IDRADICADO", myEmiRecep.IDRADICADO);
            cmdInsert.Parameters.AddWithValue("@LOCAL", myEmiRecep.LOCAL);
            cmdInsert.Parameters.AddWithValue("@ACTUALIZADO", myEmiRecep.ACTUALIZADO);
            #endregion
            
                if (this.ConnectionLocal.State == ConnectionState.Closed)
                    this.ConnectionLocal.Open();
                id = Convert.ToInt32(cmdInsert.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                // nada
            }
            finally
            {
                if (ConnectionLocal.State == ConnectionState.Open)
                    ConnectionLocal.Close();
            }
            return id;

        }




        #endregion





        #region UPDATE Commands

        public void UpdateEmiRecep(EmiRecep myEmiRecep)
        {
            string sql = @"Update EmiRecep SET        
					ID 				=@ID             ,             
					NIT             =@NIT            , 
					DESCRIPCION     =@DESCRIPCION    , 
					DIRECCIONFISICA =@DIRECCIONFISICA, 
					PAIS            =@PAIS           , 
					DEPARTAMENTO    =@DEPARTAMENTO   , 
					MUNICIPIO       =@MUNICIPIO      , 
					EMAIL           =@EMAIL          , 
					CONTRASENAEMAIL =@CONTRASENAEMAIL, 
					FOTO            =@FOTO           , 
					TELEFONO        =@TELEFONO       , 
					CODIGOUSUARIO   =@CODIGOUSUARIO  , 
					IDTIPOEMISOR    =@IDTIPOEMISOR   , 
					IDCONFICOR      =@IDCONFICOR     , 
					IDENTE          =@IDENTE         , 
					IDCARGO         =@IDCARGO        ,
                    IDRADICADO      =@IDRADICADO     ,
                    LOCAL           =@LOCAL          ,
                    ACTUALIZADO     =@ACTUALIZADO     
                    where ID=@ID";

            //===============================================CONEXION REMOTA========================================
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = sql;

            #region params
            cmdUpdate.Parameters.AddWithValue("@ID", myEmiRecep.ID);
            cmdUpdate.Parameters.AddWithValue("@NIT", myEmiRecep.NIT);
            cmdUpdate.Parameters.AddWithValue("@DESCRIPCION", myEmiRecep.DESCRIPCION);
            cmdUpdate.Parameters.AddWithValue("@DIRECCIONFISICA", myEmiRecep.DIRECCIONFISICA);
            cmdUpdate.Parameters.AddWithValue("@PAIS", myEmiRecep.PAIS);
            cmdUpdate.Parameters.AddWithValue("@DEPARTAMENTO", myEmiRecep.DEPARTAMENTO);
            cmdUpdate.Parameters.AddWithValue("@MUNICIPIO", myEmiRecep.MUNICIPIO);
            cmdUpdate.Parameters.AddWithValue("@EMAIL", myEmiRecep.EMAIL);
            cmdUpdate.Parameters.AddWithValue("@CONTRASENAEMAIL", myEmiRecep.CONTRASENAEMAIL);
            cmdUpdate.Parameters.AddWithValue("@FOTO", myEmiRecep.FOTO);
            cmdUpdate.Parameters.AddWithValue("@TELEFONO", myEmiRecep.TELEFONO);
            cmdUpdate.Parameters.AddWithValue("@CODIGOUSUARIO", myEmiRecep.CODIGOUSUARIO);
            cmdUpdate.Parameters.AddWithValue("@IDTIPOEMISOR", myEmiRecep.IDTIPOEMISOR);
            cmdUpdate.Parameters.AddWithValue("@IDCONFICOR", myEmiRecep.IDCONFICOR);
            cmdUpdate.Parameters.AddWithValue("@IDENTE", myEmiRecep.IDENTE);
            cmdUpdate.Parameters.AddWithValue("@IDCARGO", myEmiRecep.IDCARGO);
            cmdUpdate.Parameters.AddWithValue("@IDRADICADO", myEmiRecep.IDRADICADO);
            cmdUpdate.Parameters.AddWithValue("@LOCAL", myEmiRecep.LOCAL);
            cmdUpdate.Parameters.AddWithValue("@ACTUALIZADO", myEmiRecep.ACTUALIZADO);

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
        /// Delete CorreoEntrante
        /// <param name="id">Required a filled instance of CorreoEntrante</param>
        /// </summary>
        public bool DeleteEmiRecep(int id)
        {
            string sql= "DELETE FROM EmiRecep WHERE ID=@ID";

            //================================================CONEXION REMOTA=======================================================

            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = sql;

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
            
            //================================================CONEXION LOCAL=======================================================

            MySqlCommand cmdInsertLocal = ConnectionLocal.CreateCommand();

            cmdInsertLocal.CommandText = sql;

            #region params

            cmdInsertLocal.Parameters.AddWithValue("@ID", id);

            #endregion

            try
            {
                if (this.ConnectionLocal.State == ConnectionState.Closed)
                    this.ConnectionLocal.Open();

                cmdInsertLocal.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                return false;
                throw ex;
            }
            finally
            {
                if (ConnectionLocal.State == ConnectionState.Open)
                    ConnectionLocal.Close();
            }

            return true;
        }
        #endregion
    }
}