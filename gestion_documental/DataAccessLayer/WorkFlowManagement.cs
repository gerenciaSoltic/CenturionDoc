using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestion_documental.Utils;
using MySql.Data.MySqlClient;
using System.Data;
using gestion_documental.BusinessObjects;


namespace gestion_documental.DataAccessLayer
{
    public class WorkFlowManagement : ConnectionClass
    {
        public static string Fdesde;
        public static string Fhasta;
        public static Int32 lnTipo;
        public static string semaforo;
        public static int Ventanilla;
        public static string lcRadicado;
        public static int tipoinforme;
        public static string fechaini;
        public static string fechafin;
        public static int idemi;
        public static string estado;
        public static string tmovimiento;
        public static string testado;
        public static bool confuncionario;
        public static string TIPO;
        Class1 proce = new Class1();
        string host = HttpContext.Current.Request.Url.Host;
        #region Constructors
        public WorkFlowManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of fuel types
        /// <returns>List of Type Fuel Types</returns>
        /// </summary>
        public List<Workflow> GetAllWorkflow()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = @"SELECT 
                                        c.ID ,
                                        IF(c.IDENTEORIGEN IS NULL, '0', c.IDENTEORIGEN) as IDENTEORIGEN,
                                        IF(c.IDENTEDESTINO IS NULL, '0', c.IDENTEDESTINO) as IDENTEDESTINO,
                                        IF(c.IDTIPOLOGIA IS NULL, '0', c.IDTIPOLOGIA) as IDTIPOLOGIA,
                                        IF(c.IDEXPEDIENTE IS NULL, '0', c.IDEXPEDIENTE) as IDEXPEDIENTE,
                                        IF(c.IDEMIRECEP IS NULL, '0', c.IDEMIRECEP) as IDEMIRECEP,
                                        IF(c.iddocumento IS NULL, '0', c.iddocumento) as iddocumento,
                                        c.FECHA,
                                        c.RADICADO,
                                        c.DIAS,
                                        c.OBSERVACION,
                                        c.TIPO,
                                        IF(c.idexpediente IS NULL, '0', c.idexpediente) as idexpediente,
                                        c.ESTADO,
                                        c.SEMAFORO,
                                        c.IDEMIDESTINO,
                                        c.idtarea,
                                        c.idcadena,
                                        c.respuesta,
                                        c.fecharespuesta,
                                        c.radicado2,
                                        c.local,
                                        c.actualizado,
                                        c.codigousuario
                                        c.idactividad
                                        FROM Workflow as c";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Workflow> allWorkflow = new List<Workflow>();

                while (dr.Read())
                {
                    Workflow myWorkflow = new Workflow();

                    #region Params
                    
                    myWorkflow.ID = Convert.ToInt32(dr["ID"]);
                    myWorkflow.IDENTEORIGEN = Convert.ToInt32(dr["IDENTEORIGEN"]);
                    myWorkflow.IDENTEDESTINO = Convert.ToInt32(dr["IDENTEDESTINO"].ToString());
                    myWorkflow.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"].ToString());
                    myWorkflow.idexpediente = Convert.ToInt32(dr["IDEXPEDIENTE"].ToString());
                    myWorkflow.IDEMIRECEP = Convert.ToInt32(dr["IDEMIRECEP"].ToString());
                    myWorkflow.iddocumento = Convert.ToInt32(dr["iddocumento"].ToString());
                    myWorkflow.FECHA = Convert.ToDateTime(dr["FECHA"].ToString());
                    myWorkflow.RADICADO = dr["RADICADO"].ToString();
                    myWorkflow.DIAS = Convert.ToInt32(dr["DIAS"].ToString());
                    myWorkflow.OBSERVACION = dr["OBSERVACION"].ToString();
                    myWorkflow.TIPO = dr["TIPO"].ToString();
                    myWorkflow.idexpediente = Convert.ToInt32(dr["idexpediente"].ToString());
                    myWorkflow.IDEMIDESTINO = Convert.ToInt32(dr["idemidestino"].ToString());
                    myWorkflow.IDTAREA = Convert.ToInt32(dr["idTAREA"]);
                    myWorkflow.IDCADENA = Convert.ToInt32(dr["idcadena"]);
                    myWorkflow.RESPUESTA = dr["RESPUESTA"].ToString();
                    myWorkflow.FECHARESPUESTA = Convert.ToDateTime(dr["FECHARESPUESTA"].ToString());
                    myWorkflow.RADICADO2 = dr["RADICADO2"].ToString();
                    myWorkflow.LOCAL = Convert.ToInt32(dr["LOCAL"]);
                    myWorkflow.ACTUALIZADO = Convert.ToInt32(dr["ACTUALIZADO"]);
                    myWorkflow.CODIGOUSUARIO = Convert.ToInt32(dr["CODIGOUSUARIO"]);
                    myWorkflow.idactividad = Convert.ToInt32(dr["idactividad"]);
                    /*
                    myWorkflow.enteorigen = new EnteManagement().GetEnteById(myWorkflow.IDENTEORIGEN);
                    myWorkflow.entedestino = new EnteManagement().GetEnteById(myWorkflow.IDENTEDESTINO);
                    myWorkflow.tipologia = new TipologiaManagement().GetTipologiaById(myWorkflow.IDTIPOLOGIA);
                    myWorkflow.documento = new DocumentosManagement().GetDocumentosById(myWorkflow.iddocumento);
                    myWorkflow.expediente = new ExpedienteManagement().GetExpedienteById(myWorkflow.idexpediente);
                    myWorkflow.emirecep = new EmiRecepManagement().GetEmiRecepById(myWorkflow.IDEMIRECEP);
                     */
                    myWorkflow.ESTADO = dr["ESTADO"].ToString();
                    myWorkflow.SEMAFORO = dr["SEMAFORO"].ToString();
                    
                    #endregion

                    allWorkflow.Add(myWorkflow);

                }
                return allWorkflow;
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
        /// Gets all the details of a Workflow
        /// <returns>Workflow</returns>
        /// </summary>
        public Workflow GetWorkflowById(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM Workflow as c WHERE c.ID = @id ";
            cmdSelect.Parameters.AddWithValue("@id", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                Workflow myWorkflow = new Workflow();

                while (dr.Read())
                {

                    #region Params

                    myWorkflow.ID = Convert.ToInt32(dr["ID"]);
                    myWorkflow.IDENTEORIGEN = Convert.ToInt32(dr["IDENTEORIGEN"]);
                    myWorkflow.IDENTEDESTINO = Convert.ToInt32(dr["IDENTEDESTINO"].ToString());
                    myWorkflow.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"].ToString());
                    myWorkflow.idexpediente = Convert.ToInt32(dr["IDEXPEDIENTE"].ToString());
                    myWorkflow.IDEMIRECEP = Convert.ToInt32(dr["IDEMIRECEP"].ToString());
                    myWorkflow.iddocumento = Convert.ToInt32(dr["iddocumento"].ToString());
                    myWorkflow.FECHA = Convert.ToDateTime(dr["FECHA"].ToString());
                    myWorkflow.RADICADO = dr["RADICADO"].ToString();
                    myWorkflow.DIAS = Convert.ToInt32(dr["DIAS"].ToString());
                    myWorkflow.OBSERVACION = dr["OBSERVACION"].ToString();
                    myWorkflow.TIPO = dr["TIPO"].ToString();
                    myWorkflow.idexpediente = Convert.ToInt32(dr["idexpediente"].ToString());
                    myWorkflow.IDEMIDESTINO = Convert.ToInt32(dr["idemidestino"].ToString());
                    myWorkflow.IDTAREA = Convert.ToInt32(dr["idTAREA"]);
                    myWorkflow.IDCADENA = Convert.ToInt32(dr["IDCADENA"]);
                    myWorkflow.RESPUESTA = dr["RESPUESTA"].ToString();
                    myWorkflow.FECHARESPUESTA = Convert.ToDateTime(dr["FECHARESPUESTA"].ToString());
                    myWorkflow.RADICADO2 = dr["RADICADO2"].ToString();
                    myWorkflow.IDRADICADO = Convert.ToInt32(dr["IDRADICADO"].ToString());
                    myWorkflow.IDTIPOCOM = Convert.ToInt32(dr["IDTIPOCOM"].ToString());
                    myWorkflow.LOCAL = Convert.ToInt32(dr["LOCAL"]);
                    myWorkflow.ACTUALIZADO = Convert.ToInt32(dr["ACTUALIZADO"]);
                    myWorkflow.CODIGOUSUARIO = Convert.ToInt32(dr["CODIGOUSUARIO"]);
                    myWorkflow.idactividad = Convert.ToInt32(dr["idactividad"]);
                    /*
                    myWorkflow.enteorigen = new EnteManagement().GetEnteById(myWorkflow.IDENTEORIGEN);
                    myWorkflow.entedestino = new EnteManagement().GetEnteById(myWorkflow.IDENTEDESTINO);
                    myWorkflow.tipologia = new TipologiaManagement().GetTipologiaById(myWorkflow.IDTIPOLOGIA);
                    myWorkflow.documento = new DocumentosManagement().GetDocumentosById(myWorkflow.iddocumento);
                    myWorkflow.expediente = new ExpedienteManagement().GetExpedienteById(myWorkflow.idexpediente);
                    myWorkflow.emirecep = new EmiRecepManagement().GetEmiRecepById(myWorkflow.IDEMIRECEP);
                    */
                    myWorkflow.ESTADO = dr["ESTADO"].ToString();
                    myWorkflow.SEMAFORO = dr["SEMAFORO"].ToString();

                    #endregion

                }
                return myWorkflow;
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


        public Workflow GetWorkflowByIddocumento(int iddocumento)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM Workflow as c WHERE c.IDDOCUMENTO= @iddocumento ";
            cmdSelect.Parameters.AddWithValue("@iddocumento", iddocumento);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                Workflow myWorkflow = new Workflow();

                while (dr.Read())
                {

                    #region Params

                    myWorkflow.ID = Convert.ToInt32(dr["ID"]);
                    myWorkflow.IDENTEORIGEN = Convert.ToInt32(dr["IDENTEORIGEN"]);
                    myWorkflow.IDENTEDESTINO = Convert.ToInt32(dr["IDENTEDESTINO"].ToString());
                    myWorkflow.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"].ToString());
                    myWorkflow.idexpediente = Convert.ToInt32(dr["IDEXPEDIENTE"].ToString());
                    myWorkflow.IDEMIRECEP = Convert.ToInt32(dr["IDEMIRECEP"].ToString());
                    myWorkflow.iddocumento = Convert.ToInt32(dr["iddocumento"].ToString());
                    myWorkflow.FECHA = Convert.ToDateTime(dr["FECHA"].ToString());
                    myWorkflow.RADICADO = dr["RADICADO"].ToString();
                    myWorkflow.DIAS = Convert.ToInt32(dr["DIAS"].ToString());
                    myWorkflow.OBSERVACION = dr["OBSERVACION"].ToString();
                    myWorkflow.TIPO = dr["TIPO"].ToString();
                    myWorkflow.idexpediente = Convert.ToInt32(dr["idexpediente"].ToString());
                    myWorkflow.IDEMIDESTINO = Convert.ToInt32(dr["idemidestino"].ToString());
                    myWorkflow.IDTAREA = Convert.ToInt32(dr["idTAREA"]);
                    myWorkflow.IDCADENA = Convert.ToInt32(dr["IDCADENA"]);
                    myWorkflow.RESPUESTA = dr["RESPUESTA"].ToString();
                    myWorkflow.FECHARESPUESTA = Convert.ToDateTime(dr["FECHARESPUESTA"].ToString());
                    myWorkflow.RADICADO2 = dr["RADICADO2"].ToString();
                    myWorkflow.IDRADICADO = Convert.ToInt32(dr["IDRADICADO"].ToString());
                    myWorkflow.IDTIPOCOM = Convert.ToInt32(dr["IDTIPOCOM"].ToString());
                    myWorkflow.iddocumento = Convert.ToInt32(dr["IDDOCUMENTO"].ToString());
                    myWorkflow.LOCAL = Convert.ToInt32(dr["LOCAL"]);
                    myWorkflow.ACTUALIZADO = Convert.ToInt32(dr["ACTUALIZADO"]);
                    myWorkflow.CODIGOUSUARIO = Convert.ToInt32(dr["CODIGOUSUARIO"]);
                    myWorkflow.idactividad = Convert.ToInt32(dr["idactividad"]);
                    /*
                    myWorkflow.enteorigen = new EnteManagement().GetEnteById(myWorkflow.IDENTEORIGEN);
                    myWorkflow.entedestino = new EnteManagement().GetEnteById(myWorkflow.IDENTEDESTINO);
                    myWorkflow.tipologia = new TipologiaManagement().GetTipologiaById(myWorkflow.IDTIPOLOGIA);
                    myWorkflow.documento = new DocumentosManagement().GetDocumentosById(myWorkflow.iddocumento);
                    myWorkflow.expediente = new ExpedienteManagement().GetExpedienteById(myWorkflow.idexpediente);
                    myWorkflow.emirecep = new EmiRecepManagement().GetEmiRecepById(myWorkflow.IDEMIRECEP);
                    */
                    myWorkflow.ESTADO = dr["ESTADO"].ToString();
                    myWorkflow.SEMAFORO = dr["SEMAFORO"].ToString();

                    #endregion

                }
                return myWorkflow;
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


        public Workflow GetWorkflowByRadicado(string radicado)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM Workflow as c WHERE c.radicado = @radicado ";
            cmdSelect.Parameters.AddWithValue("@radicado", radicado);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                Workflow myWorkflow = new Workflow();

                while (dr.Read())
                {

                    #region Params

                    myWorkflow.ID = Convert.ToInt32(dr["ID"]);
                    myWorkflow.IDENTEORIGEN = Convert.ToInt32(dr["IDENTEORIGEN"]);
                    myWorkflow.IDENTEDESTINO = Convert.ToInt32(dr["IDENTEDESTINO"].ToString());
                    myWorkflow.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"].ToString());
                    myWorkflow.idexpediente = Convert.ToInt32(dr["IDEXPEDIENTE"].ToString());
                    myWorkflow.IDEMIRECEP = Convert.ToInt32(dr["IDEMIRECEP"].ToString());
                    myWorkflow.iddocumento = Convert.ToInt32(dr["iddocumento"].ToString());
                    myWorkflow.FECHA = Convert.ToDateTime(dr["FECHA"].ToString());
                    myWorkflow.RADICADO = dr["RADICADO"].ToString();
                    myWorkflow.DIAS = Convert.ToInt32(dr["DIAS"].ToString());
                    myWorkflow.OBSERVACION = dr["OBSERVACION"].ToString();
                    myWorkflow.TIPO = dr["TIPO"].ToString();
                    myWorkflow.idexpediente = Convert.ToInt32(dr["idexpediente"].ToString());
                    myWorkflow.IDEMIDESTINO = Convert.ToInt32(dr["idemidestino"].ToString());
                    myWorkflow.IDTAREA = Convert.ToInt32(dr["idTAREA"]);
                    myWorkflow.IDCADENA = Convert.ToInt32(dr["IDCADENA"]);
                    myWorkflow.RESPUESTA = dr["RESPUESTA"].ToString();
                    myWorkflow.FECHARESPUESTA = Convert.ToDateTime(dr["FECHARESPUESTA"].ToString());
                    myWorkflow.RADICADO2 = dr["RADICADO2"].ToString();
                    myWorkflow.IDTIPOCOM = Convert.ToInt32(dr["IDTIPOCOM"].ToString());
                    myWorkflow.LOCAL = Convert.ToInt32(dr["LOCAL"]);
                    myWorkflow.ACTUALIZADO = Convert.ToInt32(dr["ACTUALIZADO"]);
                    myWorkflow.CODIGOUSUARIO = Convert.ToInt32(dr["CODIGOUSUARIO"]);
                    myWorkflow.idactividad = Convert.ToInt32(dr["idactividad"]);
                    /*
                    myWorkflow.enteorigen = new EnteManagement().GetEnteById(myWorkflow.IDENTEORIGEN);
                    myWorkflow.entedestino = new EnteManagement().GetEnteById(myWorkflow.IDENTEDESTINO);
                    myWorkflow.tipologia = new TipologiaManagement().GetTipologiaById(myWorkflow.IDTIPOLOGIA);
                    myWorkflow.documento = new DocumentosManagement().GetDocumentosById(myWorkflow.iddocumento);
                    myWorkflow.expediente = new ExpedienteManagement().GetExpedienteById(myWorkflow.idexpediente);
                    myWorkflow.emirecep = new EmiRecepManagement().GetEmiRecepById(myWorkflow.IDEMIRECEP);
                    */
                    myWorkflow.ESTADO = dr["ESTADO"].ToString();
                    myWorkflow.SEMAFORO = dr["SEMAFORO"].ToString();
                    //myWorkflow.IDRADICADO = Convert.ToInt32(dr["IDRADICADO"]);

                    if (dr["IDRADICADO"] != DBNull.Value)
                    {
                        myWorkflow.IDRADICADO = Convert.ToInt32(dr["IDRADICADO"]);
                    }
                    else                    
                    {
                        myWorkflow.IDRADICADO = 0;
                    }

                    #endregion

                }
                return myWorkflow;
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


        public Workflow GetWorkflowByFirstRadicado(string radicado)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM Workflow as c WHERE c.radicado = @radicado limit 1 ";
            cmdSelect.Parameters.AddWithValue("@radicado", radicado);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                Workflow myWorkflow = new Workflow();

                while (dr.Read())
                {

                    #region Params

                    myWorkflow.ID = Convert.ToInt32(dr["ID"]);
                    myWorkflow.IDENTEORIGEN = Convert.ToInt32(dr["IDENTEORIGEN"]);
                    myWorkflow.IDENTEDESTINO = Convert.ToInt32(dr["IDENTEDESTINO"].ToString());
                    myWorkflow.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"].ToString());
                    myWorkflow.idexpediente = Convert.ToInt32(dr["IDEXPEDIENTE"].ToString());
                    myWorkflow.IDEMIRECEP = Convert.ToInt32(dr["IDEMIRECEP"].ToString());
                    myWorkflow.iddocumento = Convert.ToInt32(dr["iddocumento"].ToString());
                    myWorkflow.FECHA = Convert.ToDateTime(dr["FECHA"].ToString());
                    myWorkflow.RADICADO = dr["RADICADO"].ToString();
                    myWorkflow.DIAS = Convert.ToInt32(dr["DIAS"].ToString());
                    myWorkflow.OBSERVACION = dr["OBSERVACION"].ToString();
                    myWorkflow.TIPO = dr["TIPO"].ToString();
                    myWorkflow.idexpediente = Convert.ToInt32(dr["idexpediente"].ToString());
                    myWorkflow.IDEMIDESTINO = Convert.ToInt32(dr["idemidestino"].ToString());
                    myWorkflow.IDTAREA = Convert.ToInt32(dr["idTAREA"]);
                    myWorkflow.IDCADENA = Convert.ToInt32(dr["IDCADENA"]);
                    myWorkflow.RESPUESTA = dr["RESPUESTA"].ToString();
                    myWorkflow.FECHARESPUESTA = Convert.ToDateTime(dr["FECHARESPUESTA"].ToString());
                    myWorkflow.RADICADO2 = dr["RADICADO2"].ToString();
                    myWorkflow.IDTIPOCOM = Convert.ToInt32(dr["IDTIPOCOM"].ToString());
                    myWorkflow.LOCAL = Convert.ToInt32(dr["LOCAL"]);
                    myWorkflow.ACTUALIZADO = Convert.ToInt32(dr["ACTUALIZADO"]);
                    myWorkflow.CODIGOUSUARIO = Convert.ToInt32(dr["CODIGOUSUARIO"]);
                    myWorkflow.idactividad = Convert.ToInt32(dr["idactividad"]);
                    /*
                    myWorkflow.enteorigen = new EnteManagement().GetEnteById(myWorkflow.IDENTEORIGEN);
                    myWorkflow.entedestino = new EnteManagement().GetEnteById(myWorkflow.IDENTEDESTINO);
                    myWorkflow.tipologia = new TipologiaManagement().GetTipologiaById(myWorkflow.IDTIPOLOGIA);
                    myWorkflow.documento = new DocumentosManagement().GetDocumentosById(myWorkflow.iddocumento);
                    myWorkflow.expediente = new ExpedienteManagement().GetExpedienteById(myWorkflow.idexpediente);
                    myWorkflow.emirecep = new EmiRecepManagement().GetEmiRecepById(myWorkflow.IDEMIRECEP);
                    */
                    myWorkflow.ESTADO = dr["ESTADO"].ToString();
                    myWorkflow.SEMAFORO = dr["SEMAFORO"].ToString();
                    //myWorkflow.IDRADICADO = Convert.ToInt32(dr["IDRADICADO"]);

                    if (dr["IDRADICADO"] != DBNull.Value)
                    {
                        myWorkflow.IDRADICADO = Convert.ToInt32(dr["IDRADICADO"]);
                    }
                    else
                    {
                        myWorkflow.IDRADICADO = 0;
                    }

                    #endregion

                }
                return myWorkflow;
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


        public Workflow GetWorkflowByRadicadoconRespuesta(string radicado)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM Workflow as c WHERE c.radicado = @radicado AND RESPUESTA IS NOT NULL AND respuesta <> '' ORDER BY fecha";
            cmdSelect.Parameters.AddWithValue("@radicado", radicado);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                Workflow myWorkflow = new Workflow();

                while (dr.Read())
                {

                    #region Params

                    myWorkflow.ID = Convert.ToInt32(dr["ID"]);
                    myWorkflow.IDENTEORIGEN = Convert.ToInt32(dr["IDENTEORIGEN"]);
                    myWorkflow.IDENTEDESTINO = Convert.ToInt32(dr["IDENTEDESTINO"].ToString());
                    myWorkflow.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"].ToString());
                    myWorkflow.idexpediente = Convert.ToInt32(dr["IDEXPEDIENTE"].ToString());
                    myWorkflow.IDEMIRECEP = Convert.ToInt32(dr["IDEMIRECEP"].ToString());
                    myWorkflow.iddocumento = Convert.ToInt32(dr["iddocumento"].ToString());
                    myWorkflow.FECHA = Convert.ToDateTime(dr["FECHA"].ToString());
                    myWorkflow.RADICADO = dr["RADICADO"].ToString();
                    myWorkflow.DIAS = Convert.ToInt32(dr["DIAS"].ToString());
                    myWorkflow.OBSERVACION = dr["OBSERVACION"].ToString();
                    myWorkflow.TIPO = dr["TIPO"].ToString();
                    myWorkflow.idexpediente = Convert.ToInt32(dr["idexpediente"].ToString());
                    myWorkflow.IDEMIDESTINO = Convert.ToInt32(dr["idemidestino"].ToString());
                    myWorkflow.IDTAREA = Convert.ToInt32(dr["idTAREA"]);
                    myWorkflow.IDCADENA = Convert.ToInt32(dr["IDCADENA"]);
                    myWorkflow.RESPUESTA = dr["RESPUESTA"].ToString();
                    myWorkflow.FECHARESPUESTA = Convert.ToDateTime(dr["FECHARESPUESTA"].ToString());
                    myWorkflow.RADICADO2 = dr["RADICADO2"].ToString();
                    myWorkflow.IDTIPOCOM = Convert.ToInt32(dr["IDTIPOCOM"].ToString());
                    myWorkflow.LOCAL = Convert.ToInt32(dr["LOCAL"]);
                    myWorkflow.ACTUALIZADO = Convert.ToInt32(dr["ACTUALIZADO"]);
                    myWorkflow.CODIGOUSUARIO = Convert.ToInt32(dr["CODIGOUSUARIO"]);
                    myWorkflow.idactividad = Convert.ToInt32(dr["idactividad"]);
                    /*
                    myWorkflow.enteorigen = new EnteManagement().GetEnteById(myWorkflow.IDENTEORIGEN);
                    myWorkflow.entedestino = new EnteManagement().GetEnteById(myWorkflow.IDENTEDESTINO);
                    myWorkflow.tipologia = new TipologiaManagement().GetTipologiaById(myWorkflow.IDTIPOLOGIA);
                    myWorkflow.documento = new DocumentosManagement().GetDocumentosById(myWorkflow.iddocumento);
                    myWorkflow.expediente = new ExpedienteManagement().GetExpedienteById(myWorkflow.idexpediente);
                    myWorkflow.emirecep = new EmiRecepManagement().GetEmiRecepById(myWorkflow.IDEMIRECEP);
                    */
                    myWorkflow.ESTADO = dr["ESTADO"].ToString();
                    myWorkflow.SEMAFORO = dr["SEMAFORO"].ToString();
                    myWorkflow.IDRADICADO = Convert.ToInt32(dr["IDRADICADO"]);

                    #endregion

                }
                return myWorkflow;
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

        public List<Workflow> GetWorkflowByRadicadoList(string radicado)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM Workflow as c WHERE c.radicado = @radicado ";
            cmdSelect.Parameters.AddWithValue("@radicado", radicado);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
            
                List<Workflow> allWorkflow = new List<Workflow>();

                while (dr.Read())
                {
                    Workflow myWorkflow = new Workflow();
                    #region Params

                    myWorkflow.ID = Convert.ToInt32(dr["ID"]);
                    myWorkflow.IDENTEORIGEN = Convert.ToInt32(dr["IDENTEORIGEN"]);
                    myWorkflow.IDENTEDESTINO = Convert.ToInt32(dr["IDENTEDESTINO"].ToString());
                    myWorkflow.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"].ToString());
                    myWorkflow.idexpediente = Convert.ToInt32(dr["IDEXPEDIENTE"].ToString());
                    myWorkflow.IDEMIRECEP = Convert.ToInt32(dr["IDEMIRECEP"].ToString());
                    myWorkflow.iddocumento = Convert.ToInt32(dr["iddocumento"].ToString());
                    myWorkflow.FECHA = Convert.ToDateTime(dr["FECHA"].ToString());
                    myWorkflow.RADICADO = dr["RADICADO"].ToString();
                    myWorkflow.DIAS = Convert.ToInt32(dr["DIAS"].ToString());
                    myWorkflow.OBSERVACION = dr["OBSERVACION"].ToString();
                    myWorkflow.TIPO = dr["TIPO"].ToString();
                    myWorkflow.idexpediente = Convert.ToInt32(dr["idexpediente"].ToString());
                    myWorkflow.IDEMIDESTINO = Convert.ToInt32(dr["idemidestino"].ToString());
                    myWorkflow.IDTAREA = Convert.ToInt32(dr["idTAREA"]);
                    myWorkflow.IDCADENA = Convert.ToInt32(dr["IDCADENA"]);
                    myWorkflow.RESPUESTA = dr["RESPUESTA"].ToString();
                    myWorkflow.FECHARESPUESTA = Convert.ToDateTime(dr["FECHARESPUESTA"].ToString());
                    myWorkflow.RADICADO2 = dr["RADICADO2"].ToString();
                    myWorkflow.IDTIPOCOM = Convert.ToInt32(dr["IDTIPOCOM"].ToString());
                    myWorkflow.LOCAL = Convert.ToInt32(dr["LOCAL"]);
                    myWorkflow.ACTUALIZADO = Convert.ToInt32(dr["ACTUALIZADO"]);
                    myWorkflow.CODIGOUSUARIO = Convert.ToInt32(dr["CODIGOUSUARIO"]);
                    myWorkflow.idactividad = Convert.ToInt32(dr["idactividad"]);
                    /*
                    myWorkflow.enteorigen = new EnteManagement().GetEnteById(myWorkflow.IDENTEORIGEN);
                    myWorkflow.entedestino = new EnteManagement().GetEnteById(myWorkflow.IDENTEDESTINO);
                    myWorkflow.tipologia = new TipologiaManagement().GetTipologiaById(myWorkflow.IDTIPOLOGIA);
                    myWorkflow.documento = new DocumentosManagement().GetDocumentosById(myWorkflow.iddocumento);
                    myWorkflow.expediente = new ExpedienteManagement().GetExpedienteById(myWorkflow.idexpediente);
                    */
                    myWorkflow.DESTINATARIO = new EmiRecepManagement().GetEmiRecepById(myWorkflow.IDEMIDESTINO).DESCRIPCION.ToString();
                   
                    myWorkflow.ESTADO = dr["ESTADO"].ToString();
                    myWorkflow.SEMAFORO = dr["SEMAFORO"].ToString();
                    myWorkflow.IDRADICADO = Convert.ToInt32(dr["IDRADICADO"]);

                    allWorkflow.Add(myWorkflow);
                    #endregion

                }
                return allWorkflow;
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


        public List<Workflow> GetWorkflowByIdEnteDestino(int idEnte, string estado, int idemirecep, string filtro, string filtro2)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            if (!(filtro == ""))
            {
                filtro = " AND c.radicado LIKE '%" + filtro + "%'";
            }
            if (!(filtro2 == ""))
            {
                filtro = filtro+" AND c.fecha between'" + filtro2 + " 00:00:00' and '"+filtro2+" 23:59:59'" ;
            }
            cmdSelect.CommandText = "SELECT c.*,a.descripcion as enteorigen,b.descripcion as entedestino,d.descripcion as emirecep,c.idcadena,c.codigousuario FROM Workflow as c,ente as b,ente as a,emirecep as d WHERE c.identeorigen = a.idente AND c.identedestino = b.idente and c.idemirecep = d.id AND c.IDENTEDESTINO = "+idEnte.ToString()+" AND estado IN ("+estado.ToString()+") AND idemidestino ="+idemirecep.ToString()+ filtro + " GROUP BY radicado ORDER BY estado,semaforo,fecha";
            
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);

                List<Workflow> allWorkflow = new List<Workflow>();
                while (dr.Read())
                {
                    Workflow myWorkflow = new Workflow();
                    #region Params

                    myWorkflow.ID = Convert.ToInt32(dr["ID"]);
                    myWorkflow.IDENTEORIGEN = Convert.ToInt32(dr["IDENTEORIGEN"]);
                    myWorkflow.IDENTEDESTINO = Convert.ToInt32(dr["IDENTEDESTINO"].ToString());
                    myWorkflow.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"].ToString());
                    myWorkflow.idexpediente = Convert.ToInt32(dr["IDEXPEDIENTE"].ToString());
                    myWorkflow.IDEMIRECEP = Convert.ToInt32(dr["IDEMIRECEP"].ToString());
                    myWorkflow.iddocumento = Convert.ToInt32(dr["iddocumento"].ToString());
                    myWorkflow.FECHA = Convert.ToDateTime(dr["FECHA"].ToString());
                    myWorkflow.RADICADO = dr["RADICADO"].ToString();
                    myWorkflow.DIAS = Convert.ToInt32(dr["DIAS"].ToString());
                    myWorkflow.OBSERVACION = dr["OBSERVACION"].ToString();
                    myWorkflow.TIPO = dr["TIPO"].ToString();
                    myWorkflow.idexpediente = Convert.ToInt32(dr["idexpediente"].ToString());
                    myWorkflow.ESTADO = dr["ESTADO"].ToString();
                    myWorkflow.SEMAFORO = dr["SEMAFORO"].ToString();
                    myWorkflow.IDEMIDESTINO = Convert.ToInt32(dr["idemidestino"].ToString());
                    myWorkflow.IDTAREA = Convert.ToInt32(dr["idTAREA"]);
                    myWorkflow.IDCADENA = Convert.ToInt32(dr["idcadena"]);
                    myWorkflow.RESPUESTA = dr["RESPUESTA"].ToString();
                    myWorkflow.RADICADO2 = dr["RADICADO2"].ToString();
                    myWorkflow.FECHARESPUESTA = Convert.ToDateTime(dr["FECHARESPUESTA"].ToString());
                    myWorkflow.ENTEORIGEN = dr["ENTEORIGEN"].ToString();
                    myWorkflow.ENTEDESTINO = dr["ENTEDESTINO"].ToString();
                    myWorkflow.EMIRECEP = dr["EMIRECEP"].ToString();
                    myWorkflow.IDTIPOCOM = Convert.ToInt32(dr["IDTIPOCOM"].ToString());
                    myWorkflow.LOCAL = Convert.ToInt32(dr["LOCAL"]);
                    myWorkflow.ACTUALIZADO = Convert.ToInt32(dr["ACTUALIZADO"]);
                    myWorkflow.CODIGOUSUARIO = Convert.ToInt32(dr["CODIGOUSUARIO"]);
                    myWorkflow.idactividad = Convert.ToInt32(dr["idactividad"]);
                    #endregion
                    allWorkflow.Add(myWorkflow);
                }
                return allWorkflow;
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


        public List<Workflow> GetWorkflowByEstadoIdEnteDestino(int idEnte, string estado, int idemirecep)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT c.*,a.descripcion as enteorigen,b.descripcion as entedestino,d.descripcion as emirecep,concat(e.camino,'/',e.documento) as documento,idcadena,codigousuario FROM Workflow as c,ente as b,ente as a,emirecep as d,documentos as e WHERE c.identeorigen = b.idente AND c.identedestino = a.idente and c.idemirecep = d.id and c.iddocumento  = e.iddocumentos AND c.IDENTEDESTINO = " + idEnte.ToString() + " AND estado IN (" + estado.ToString() + ") AND idemidestino =" + idemirecep.ToString() + " ORDER BY estado,semaforo,fecha";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);

                List<Workflow> allWorkflow = new List<Workflow>();
                while (dr.Read())
                {
                    Workflow myWorkflow = new Workflow();
                    #region Params

                    myWorkflow.ID = Convert.ToInt32(dr["ID"]);
                    myWorkflow.IDENTEORIGEN = Convert.ToInt32(dr["IDENTEORIGEN"]);
                    myWorkflow.IDENTEDESTINO = Convert.ToInt32(dr["IDENTEDESTINO"].ToString());
                    myWorkflow.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"].ToString());
                    myWorkflow.idexpediente = Convert.ToInt32(dr["IDEXPEDIENTE"].ToString());
                    myWorkflow.IDEMIRECEP = Convert.ToInt32(dr["IDEMIRECEP"].ToString());
                    myWorkflow.iddocumento = Convert.ToInt32(dr["iddocumento"].ToString());
                    myWorkflow.FECHA = Convert.ToDateTime(dr["FECHA"].ToString());
                    myWorkflow.RADICADO = dr["RADICADO"].ToString();
                    myWorkflow.DIAS = Convert.ToInt32(dr["DIAS"].ToString());
                    myWorkflow.OBSERVACION = dr["OBSERVACION"].ToString();
                    myWorkflow.TIPO = dr["TIPO"].ToString();
                    myWorkflow.idexpediente = Convert.ToInt32(dr["idexpediente"].ToString());
                    myWorkflow.ESTADO = dr["ESTADO"].ToString();
                    myWorkflow.SEMAFORO = dr["SEMAFORO"].ToString();
                    myWorkflow.IDEMIDESTINO = Convert.ToInt32(dr["idemidestino"].ToString());
                    myWorkflow.IDTAREA = Convert.ToInt32(dr["idTAREA"]);
                    myWorkflow.IDCADENA = Convert.ToInt32(dr["idcadena"]);
                    myWorkflow.RESPUESTA = dr["RESPUESTA"].ToString();
                    myWorkflow.FECHARESPUESTA = Convert.ToDateTime(dr["FECHARESPUESTA"].ToString());
                    myWorkflow.RADICADO2 = dr["RADICADO2"].ToString();
                    myWorkflow.ENTEORIGEN = dr["ENTEORIGEN"].ToString();
                    myWorkflow.ENTEDESTINO = dr["ENTEDESTINO"].ToString();
                    myWorkflow.EMIRECEP = dr["EMIRECEP"].ToString();
                    myWorkflow.DOCUMENTO = dr["DOCUMENTO"].ToString();
                    myWorkflow.IDTIPOCOM = Convert.ToInt32(dr["IDTIPOCOM"].ToString());
                    myWorkflow.LOCAL = Convert.ToInt32(dr["LOCAL"]);
                    myWorkflow.ACTUALIZADO = Convert.ToInt32(dr["ACTUALIZADO"]);
                    myWorkflow.CODIGOUSUARIO = Convert.ToInt32(dr["CODIGOUSUARIO"]);
                    myWorkflow.idactividad = Convert.ToInt32(dr["idactividad"]);
                    #endregion
                    allWorkflow.Add(myWorkflow);
                }
                return allWorkflow;
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
       

        public List<Recepcion> GetWorkflowByfecha()
        {

            MySqlCommand cmdSelect = Connection.CreateCommand();

            string lcSartaFiltro = "";

            string lcGrupo = "group by c.radicado";
            confuncionario = true;
            if (confuncionario)
            {
                lcGrupo = "group by c.radicado,para";
            }

            switch (lnTipo)
            {
                case 1:
                    lcSartaFiltro = "(TRIM(SUBSTRING(c.radicado,1,length(TRIM(r.prefextent)))) = TRIM(r.prefextent)) ";
                    if (tipoinforme == 1)
                    {
                        lcSartaFiltro = lcSartaFiltro + "and ((defun.idtipoemisor = 3 OR defun.idtipoemisor = 5) or (defun.idradicado <> parafun.idradicado))";
                    }
                    break;
                case 2:
                    lcSartaFiltro = "(TRIM(SUBSTRING(c.radicado,1,length( TRIM(r.prefextsal))))= TRIM(r.prefextsal)) ";
                    if (tipoinforme == 1)
                    {
                        lcSartaFiltro = lcSartaFiltro + "and ((parafun.idtipoemisor = 3 OR parafun.idtipoemisor = 5) or (defun.idradicado <> parafun.idradicado))";
                    }
                    break;
                case 3:
                    lcSartaFiltro = "(TRIM(SUBSTRING(c.radicado,1,length(TRIM(r.prefinter)))) = TRIM(r.prefinter))";
                    break;

            }

            string lcSartaSemaforo = "";
            if (semaforo != "0. TODOS")
            {
                lcSartaSemaforo = "AND semaforo IN (" + semaforo + ")";


            }


            EmiRecep usuario = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);


            if (SessionDocumental.UsuarioInicioSession.ROL >= 3)
            {
           
                //cmdSelect.CommandText = "SELECT CAST(c.fecha as CHAR) as fecha,CONCAT(TRIM(b.descripcion),'-',TRIM(defun.descripcion)) as De,CONCAT(TRIM(a.descripcion),'-',TRIM(parafun.descripcion)) as Para,d.descripcion as emisor,c.iddocumento,c.radicado,c.observacion,e.folios,c.semaforo,c.respuesta,c.fecharespuesta,c.Radicado2,c.idcadena FROM Workflow as c,ente as b,ente as a,emirecep as d,documentos e,emirecep as defun,emirecep as parafun,linkdoc ,radicados as r WHERE linkdoc.iddocumentos= e.iddocumentos  and linkdoc.idente = " + Ventanilla.ToString() + " AND c.identeorigen = b.idente AND c.identedestino = a.idente and c.idemirecep = d.id  AND c.iddocumento =e.iddocumentos  AND c.idemirecep = defun.id and c.idemidestino = parafun.id AND c.idradicado = r.idradicados AND " + lcSartaFiltro + lcSartaSemaforo.Trim() + " AND c.fecha BETWEEN '" + Fdesde + " 00:00:00' and '" + Fhasta + " 23:59:59' group by CAST(c.fecha as CHAR) ,CONCAT(TRIM(b.descripcion),'-',TRIM(defun.descripcion)) ,CONCAT(TRIM(a.descripcion),'-',TRIM(parafun.descripcion)) ,d.descripcion ,c.iddocumento,c.radicado,c.observacion,e.folios,c.semaforo,c.respuesta,c.fecharespuesta order by fecha";
                cmdSelect.CommandText = "SELECT CAST(min(c.fecha) as CHAR) as fecha,CONCAT(TRIM(b.descripcion),'-',TRIM(defun.descripcion)) as De,CONCAT(TRIM(a.descripcion),'-',TRIM(parafun.descripcion)) as Para,d.descripcion as emisor,c.iddocumento,c.radicado,c.observacion,e.folios,c.semaforo,c.respuesta,c.fecharespuesta,c.Radicado2,c.idcadena,c.codigousuario FROM Workflow as c,ente as b,ente as a,emirecep as d,documentos e,emirecep as defun,emirecep as parafun,linkdoc ,radicados as r WHERE linkdoc.iddocumentos= e.iddocumentos  and linkdoc.idente = " + Ventanilla.ToString() + " AND c.identeorigen = b.idente AND c.identedestino = a.idente and c.idemirecep = d.id  AND c.iddocumento =e.iddocumentos  AND c.idemirecep = defun.id and c.idemidestino = parafun.id AND c.TIPO = '" + TIPO + "' AND c.idradicado = r.idradicados AND ((" + lcSartaFiltro + lcSartaSemaforo.Trim() + " AND DATE(c.fecha) BETWEEN '" + Fdesde + "' and '" + Fhasta + "') OR c.radicado ='" + lcRadicado + "')  and c.idradicado = "+usuario.IDRADICADO.ToString() +" "+ lcGrupo + " order by c.fecha,c.radicado,c.id";
           
            }
            else
            {
                cmdSelect.CommandText = "SELECT CAST(min(c.fecha) as CHAR) as fecha,CONCAT(TRIM(b.descripcion),'-',TRIM(defun.descripcion)) as De,CONCAT(TRIM(a.descripcion),'-',TRIM(parafun.descripcion)) as Para,d.descripcion as emisor,c.iddocumento,c.radicado,c.observacion,e.folios,c.semaforo,c.respuesta,c.fecharespuesta,c.radicado2,c.idcadena,c.codigousuario FROM Workflow as c,ente as b,ente as a,emirecep as d,documentos e,emirecep as defun,emirecep as parafun,linkdoc,radicados as r WHERE linkdoc.iddocumentos= e.iddocumentos  AND c.identeorigen = b.idente AND c.identedestino = a.idente and c.idemirecep = d.id  AND c.iddocumento =e.iddocumentos  AND c.idemirecep = defun.id and c.idemidestino = parafun.id AND c.idradicado = r.idradicados AND c.TIPO = '" + TIPO + "' AND ((" + lcSartaFiltro + lcSartaSemaforo.Trim() + " AND DATE(c.fecha) BETWEEN '" + Fdesde + "' and '" + Fhasta + "') or c.radicado ='"+lcRadicado+"')  and c.idradicado = "+usuario.IDRADICADO.ToString() +" "+lcGrupo+" order by c.fecha,c.radicado,c.id";
           
               // cmdSelect.CommandText = "SELECT CAST(c.fecha as CHAR) as fecha,CONCAT(TRIM(b.descripcion),'-',TRIM(defun.descripcion)) as De,CONCAT(TRIM(a.descripcion),'-',TRIM(parafun.descripcion)) as Para,d.descripcion as emisor,c.iddocumento,c.radicado,c.observacion,e.folios,c.semaforo,c.respuesta,c.fecharespuesta,c.radicado2,c.idcadena FROM Workflow as c,ente as b,ente as a,emirecep as d,documentos e,emirecep as defun,emirecep as parafun,linkdoc,radicados as r WHERE linkdoc.iddocumentos= e.iddocumentos  AND c.identeorigen = b.idente AND c.identedestino = a.idente and c.idemirecep = d.id  AND c.iddocumento =e.iddocumentos  AND c.idemirecep = defun.id and c.idemidestino = parafun.id AND c.idradicado = r.idradicados AND " + lcSartaFiltro + lcSartaSemaforo.Trim() + " AND c.fecha BETWEEN '" + Fdesde + " 00:00:00' and '" + Fhasta + " 23:59:59' group by CAST(c.fecha as CHAR) ,CONCAT(TRIM(b.descripcion),'-',TRIM(defun.descripcion)) ,CONCAT(TRIM(a.descripcion),'-',TRIM(parafun.descripcion)) ,d.descripcion ,c.iddocumento,c.radicado,c.observacion,e.folios,c.semaforo,c.respuesta,c.fecharespuesta order by fecha";
            }

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);

                List<Recepcion> allWorkflow = new List<Recepcion>();
                while (dr.Read())
                {
                    Recepcion myWorkflow = new Recepcion();
                    #region Params

                    myWorkflow.FECHA = dr["fecha"].ToString();
                    myWorkflow.DE = dr["de"].ToString();
                    myWorkflow.PARA = dr["para"].ToString();
                    myWorkflow.EMISOR = dr["emisor"].ToString();
                    myWorkflow.RADICADO = dr["radicado"].ToString();
                    myWorkflow.IDDOCUMENTO = Convert.ToInt32(dr["iddocumento"]);
                    myWorkflow.folios = Convert.ToInt32(dr["folios"]);
                    myWorkflow.observacion = dr["observacion"].ToString();
                    myWorkflow.SEMAFORO = dr["semaforo"].ToString();
                    myWorkflow.RESPUESTA = dr["RESPUESTA"].ToString();
                    myWorkflow.RADICADO2 = dr["RADICADO2"].ToString();
                    myWorkflow.IDCADENA = dr["idcadena"].ToString();
                    myWorkflow.CODIGOUSARIO = Convert.ToInt32(dr["CODIGOUSUARIO"]);
                    if (dr["FECHARESPUESTA"].ToString() == "01/01/1901")
                    {
                        myWorkflow.FECHARESPUESTA = "";
                    }
                    else
                    {
                        myWorkflow.FECHARESPUESTA = dr["FECHARESPUESTA"].ToString();
                    }


                    // Buscamos ultima respuesta}

                    DataTable ultresp = new DataTable();
                    proce.consultacamposcondicion("workflow","respuesta,fecharespuesta","radicado ='"+myWorkflow.RADICADO+"' order by fecha",ultresp);
                    for (int iresp = 0;iresp < ultresp.Rows.Count ;iresp++)
                    {

                        myWorkflow.RESPUESTA = ultresp.Rows[iresp]["respuesta"].ToString();
                        myWorkflow.FECHARESPUESTA = ultresp.Rows[iresp]["fecharespuesta"].ToString();
                    }


                    //
                    #endregion
                    allWorkflow.Add(myWorkflow);
                }
                return allWorkflow;
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

        public List<Recepcion> GetWorkflowAlarma()
        {

            MySqlCommand cmdSelect = Connection.CreateCommand();


            Semaforo DatosSemaforo = new Semaforo();
            DatosSemaforo = new SemaforoManagement().GetAllSemaforo();

            if (SessionDocumental.UsuarioInicioSession.ROL >= 3)
            {
                cmdSelect.CommandText = "SELECT CAST(c.fecha as CHAR) as fecha,CONCAT(TRIM(b.descripcion),'-',TRIM(defun.descripcion)) as De,CONCAT(TRIM(a.descripcion),'-',TRIM(parafun.descripcion)) as Para,d.descripcion as emisor,c.iddocumento,c.radicado,c.observacion,e.folios,c.semaforo,c.respuesta,c.fecharespuesta,DATEDIFF(now(),c.fecha) AS DIAS,c.radicado2,c.codigousuario FROM Workflow as c,ente as b,ente as a,emirecep as d,documentos e,emirecep as defun,emirecep as parafun,linkdoc WHERE linkdoc.iddocumentos= e.iddocumentos  and parafun.id = " + Ventanilla.ToString() + " AND c.identeorigen = b.idente AND c.identedestino = a.idente and c.idemirecep = d.id  AND c.iddocumento =e.iddocumentos  AND c.idemirecep = defun.id and c.idemidestino = parafun.id AND c.estado IN('1. PENDIENTE','2. EN PROCESO') group by CAST(c.fecha as CHAR) ,CONCAT(TRIM(b.descripcion),'-',TRIM(defun.descripcion)) ,CONCAT(TRIM(a.descripcion),'-',TRIM(parafun.descripcion)) ,d.descripcion ,c.iddocumento,c.radicado,c.observacion,e.folios,c.semaforo,c.respuesta,c.fecharespuesta order by dias desc";
            }
            else
            {
                cmdSelect.CommandText = "SELECT CAST(c.fecha as CHAR) as fecha,CONCAT(TRIM(b.descripcion),'-',TRIM(defun.descripcion)) as De,CONCAT(TRIM(a.descripcion),'-',TRIM(parafun.descripcion)) as Para,d.descripcion as emisor,c.iddocumento,c.radicado,c.observacion,e.folios,c.semaforo,c.respuesta,c.fecharespuesta,DATEDIFF(now(),c.fecha) AS DIAS,c.radicado2,c.codigousuario FROM Workflow as c,ente as b,ente as a,emirecep as d,documentos e,emirecep as defun,emirecep as parafun,linkdoc WHERE linkdoc.iddocumentos= e.iddocumentos  AND c.identeorigen = b.idente AND c.identedestino = a.idente and c.idemirecep = d.id  AND c.iddocumento =e.iddocumentos  AND c.idemirecep = defun.id and c.idemidestino = parafun.id AND c.estado IN('1. PENDIENTE','2. EN PROCESO') group by CAST(c.fecha as CHAR) ,CONCAT(TRIM(b.descripcion),'-',TRIM(defun.descripcion)) ,CONCAT(TRIM(a.descripcion),'-',TRIM(parafun.descripcion)) ,d.descripcion ,c.iddocumento,c.radicado,c.observacion,e.folios,c.semaforo,c.respuesta,c.fecharespuesta order by dias desc";
            }

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);

                List<Recepcion> allWorkflow = new List<Recepcion>();
                while (dr.Read())
                {
                    Recepcion myWorkflow = new Recepcion();
                    #region Params

                    myWorkflow.FECHA = dr["fecha"].ToString();
                    myWorkflow.DE = dr["de"].ToString();
                    myWorkflow.PARA = dr["para"].ToString();
                    myWorkflow.EMISOR = dr["emisor"].ToString();
                    myWorkflow.RADICADO = dr["radicado"].ToString();
                    myWorkflow.IDDOCUMENTO = Convert.ToInt32(dr["iddocumento"]);
                    myWorkflow.folios = Convert.ToInt32(dr["folios"]);
                    myWorkflow.observacion = dr["observacion"].ToString();
                    myWorkflow.SEMAFORO = dr["semaforo"].ToString();
                    myWorkflow.RESPUESTA = dr["RESPUESTA"].ToString();
                    myWorkflow.DIAS = Convert.ToInt32(dr["dias"]);
                    myWorkflow.DIASLIMITEVER = DatosSemaforo.VERHASTA;
                    myWorkflow.DIASLIMITENAR = DatosSemaforo.NARHASTA;
                    myWorkflow.DIASLIMITEROJ = DatosSemaforo.ROJHASTA;
                    myWorkflow.RADICADO2 = dr["RADICADO2"].ToString();
                    myWorkflow.CODIGOUSARIO = Convert.ToInt32(dr["CODIGOUSUARIO"]);

                    if (dr["FECHARESPUESTA"].ToString() != "1901-01-01 00:00:00")
                    {
                        myWorkflow.FECHARESPUESTA = "";
                    }

                    if (myWorkflow.DIAS <= myWorkflow.DIASLIMITEVER)
                    {
                        myWorkflow.TIPOALARMA = "LEVE";
                    }

                    if (myWorkflow.DIAS > myWorkflow.DIASLIMITEVER & myWorkflow.DIAS <= myWorkflow.DIASLIMITENAR)
                    {
                        myWorkflow.TIPOALARMA = "MEDIA";
                    }

                    if (myWorkflow.DIAS > myWorkflow.DIASLIMITENAR )
                    {
                        myWorkflow.TIPOALARMA = "GRAVE";
                    }

                    #endregion
                    allWorkflow.Add(myWorkflow);
                }
                return allWorkflow;
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

        public List<Recepcion> GetConsultaWorkflow()
        {

            MySqlCommand cmdSelect = Connection.CreateCommand();


            Semaforo DatosSemaforo = new Semaforo();
            DatosSemaforo = new SemaforoManagement().GetAllSemaforo();

            string condicion = "";
            if (!(fechaini.ToString() == "" && fechafin.ToString() == "" && idemi.ToString()==""))
            {
                condicion = " workflow.fecha BETWEEN '" + fechaini + "' AND '" + fechafin + "' AND workflow.idemidestino = " + idemi;
                if (!(estado == "--Seleccionar--"))
                {
                    condicion = condicion + " AND workflow.estado = '" + estado + "'";
                }
            }
            cmdSelect.CommandText = "SELECT workflow.fecha,workflow.radicado,emirecep.descripcion AS De,em.descripcion AS Para,workflow.observacion AS asunto, documentos.documento,workflow.respuesta,workflow.fecharespuesta,workflow.radicado2,concat(documentos.camino,'/',documentos.documento) as camino,workflow.estado,workflow.codigousuario FROM " +
                    " workflow LEFT JOIN emirecep ON workflow.idemirecep = emirecep.id LEFT JOIN emirecep AS em ON workflow.idemidestino = em.id LEFT JOIN documentos ON workflow.iddocumento = documentos.iddocumentos" + 
                    " WHERE " + condicion + " order by workflow.estado";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);

                List<Recepcion> allWorkflow = new List<Recepcion>();
                while (dr.Read())
                {
                    Recepcion myWorkflow = new Recepcion();
                    #region Params

                    myWorkflow.FECHA = dr["fecha"].ToString();
                    myWorkflow.DE = dr["de"].ToString();
                    myWorkflow.PARA = dr["para"].ToString();
                    myWorkflow.RADICADO = dr["radicado"].ToString();
                    myWorkflow.DOCUMENTO = dr["documento"].ToString();
                    myWorkflow.observacion = dr["asunto"].ToString();
                    myWorkflow.RESPUESTA = dr["RESPUESTA"].ToString();
                    myWorkflow.ESTADO = dr["estado"].ToString();
                    myWorkflow.RADICADO2 = dr["radicado2"].ToString();
                    myWorkflow.CODIGOUSARIO = Convert.ToInt32(dr["CODIGOUSUARIO"]);
                    if (dr["FECHARESPUESTA"].ToString() != "1901-01-01 00:00:00")
                    {
                        myWorkflow.FECHARESPUESTA = "";
                    }

                    #endregion
                    allWorkflow.Add(myWorkflow);
                }
                return allWorkflow;
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

        public List<Recepcion> GetWorkflowByfechaIdEnteDestino(int idEnte,string Fdesde, string Fhasta, int lnTipo)
        {

            MySqlCommand cmdSelect = Connection.CreateCommand();

            string lcSartaFiltro = "";

            switch (lnTipo)
            {
                case 1:
                    lcSartaFiltro = "(defun.idtipoemisor = 5 OR defun.idtipoemisor = 3)";
                    break;
                case 2:
                    lcSartaFiltro = "(defun.idtipoemisor <>3 AND defun.idtipoemisor <> 5) AND (parafun.idtipoemisor = 5 OR parafun.idtipoemisor = 3)";
                    break;
                case 3:
                    lcSartaFiltro = "(defun.idtipoemisor <>3 AND defun.idtipoemisor <> 5) AND (parafun.idtipoemisor <> 5 AND parafun.idtipoemisor <> 3)";
                    break;

            }




            cmdSelect.CommandText = "SELECT CAST(c.fecha as CHAR) as fecha,CONCAT(TRIM(b.descripcion),'-',TRIM(defun.descripcion)) as De,CONCAT(TRIM(a.descripcion),'-',TRIM(parafun.descripcion)) as Para,d.descripcion as emisor,c.iddocumento,c.radicado,c.observacion,e.folios,c.radicado2,c.codigousuario FROM Workflow as c,ente as b,ente as a,emirecep as d,documentos e,emirecep as defun,emirecep as parafun WHERE c.identeorigen = b.idente AND c.identedestino = a.idente and c.idemirecep = d.id  AND c.iddocumento =e.iddocumentos  AND c.idemirecep = defun.id and c.idemidestino = parafun.id AND " + lcSartaFiltro + " AND c.IDENTEDESTINO = "+idEnte.ToString()+" AND c.fecha BETWEEN '" + Fdesde + "' and '" + Fhasta + "' order by fecha";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);

                List<Recepcion> allWorkflow = new List<Recepcion>();
                while (dr.Read())
                {
                    Recepcion myWorkflow = new Recepcion();
                    #region Params

                    myWorkflow.FECHA = dr["fecha"].ToString();
                    myWorkflow.DE = dr["de"].ToString();
                    myWorkflow.PARA = dr["para"].ToString();
                    myWorkflow.EMISOR = dr["emisor"].ToString();
                    myWorkflow.RADICADO = dr["radicado"].ToString();
                    myWorkflow.IDDOCUMENTO = Convert.ToInt32(dr["iddocumento"]);
                    myWorkflow.folios = Convert.ToInt32(dr["folios"]);
                    myWorkflow.RESPUESTA = dr["RESPUESTA"].ToString();
                    myWorkflow.FECHARESPUESTA = dr["FECHARESPUESTA"].ToString();
                    myWorkflow.RADICADO2 = dr["RADICADO2"].ToString();
                    myWorkflow.CODIGOUSARIO = Convert.ToInt32(dr["CODIGOUSUARIO"]);
                    #endregion
                    allWorkflow.Add(myWorkflow);
                }
                return allWorkflow;
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


        public List<Workflow> GetWorkflowLocal()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = @"SELECT 
                                        c.ID ,
                                        IF(c.IDENTEORIGEN IS NULL, '0', c.IDENTEORIGEN) as IDENTEORIGEN,
                                        IF(c.IDENTEDESTINO IS NULL, '0', c.IDENTEDESTINO) as IDENTEDESTINO,
                                        IF(c.IDTIPOLOGIA IS NULL, '0', c.IDTIPOLOGIA) as IDTIPOLOGIA,
                                        IF(c.IDEXPEDIENTE IS NULL, '0', c.IDEXPEDIENTE) as IDEXPEDIENTE,
                                        IF(c.IDEMIRECEP IS NULL, '0', c.IDEMIRECEP) as IDEMIRECEP,
                                        IF(c.iddocumento IS NULL, '0', c.iddocumento) as iddocumento,
                                        c.FECHA,
                                        c.RADICADO,
                                        c.DIAS,
                                        c.OBSERVACION,
                                        c.TIPO,
                                        IF(c.idexpediente IS NULL, '0', c.idexpediente) as idexpediente,
                                        c.ESTADO,
                                        c.SEMAFORO,
                                        c.IDEMIDESTINO,
                                        c.idtarea,
                                        c.idcadena,
                                        c.respuesta,
                                        c.fecharespuesta,
                                        c.radicado2,
                                        c.local,
                                        c.actualizado,
                                        c.codigousuario
                                        FROM Workflow as c where Local = 1 and actualizado = 0 ";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Workflow> allWorkflow = new List<Workflow>();

                while (dr.Read())
                {
                    Workflow myWorkflow = new Workflow();

                    #region Params

                    myWorkflow.ID = Convert.ToInt32(dr["ID"]);
                    myWorkflow.IDENTEORIGEN = Convert.ToInt32(dr["IDENTEORIGEN"]);
                    myWorkflow.IDENTEDESTINO = Convert.ToInt32(dr["IDENTEDESTINO"].ToString());
                    myWorkflow.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"].ToString());
                    myWorkflow.idexpediente = Convert.ToInt32(dr["IDEXPEDIENTE"].ToString());
                    myWorkflow.IDEMIRECEP = Convert.ToInt32(dr["IDEMIRECEP"].ToString());
                    myWorkflow.iddocumento = Convert.ToInt32(dr["iddocumento"].ToString());
                    myWorkflow.FECHA = Convert.ToDateTime(dr["FECHA"].ToString());
                    myWorkflow.RADICADO = dr["RADICADO"].ToString();
                    myWorkflow.DIAS = Convert.ToInt32(dr["DIAS"].ToString());
                    myWorkflow.OBSERVACION = dr["OBSERVACION"].ToString();
                    myWorkflow.TIPO = dr["TIPO"].ToString();
                    myWorkflow.idexpediente = Convert.ToInt32(dr["idexpediente"].ToString());
                    myWorkflow.IDEMIDESTINO = Convert.ToInt32(dr["idemidestino"].ToString());
                    myWorkflow.IDTAREA = Convert.ToInt32(dr["idTAREA"]);
                    myWorkflow.IDCADENA = Convert.ToInt32(dr["idcadena"]);
                    myWorkflow.RESPUESTA = dr["RESPUESTA"].ToString();
                    myWorkflow.FECHARESPUESTA = Convert.ToDateTime(dr["FECHARESPUESTA"].ToString());
                    myWorkflow.RADICADO2 = dr["RADICADO2"].ToString();
                    myWorkflow.LOCAL = Convert.ToInt32(dr["LOCAL"]);
                    myWorkflow.ACTUALIZADO = Convert.ToInt32(dr["ACTUALIZADO"]);
                    myWorkflow.CODIGOUSUARIO = Convert.ToInt32(dr["CODIGOUSUARIO"]);
                    /*
                    myWorkflow.enteorigen = new EnteManagement().GetEnteById(myWorkflow.IDENTEORIGEN);
                    myWorkflow.entedestino = new EnteManagement().GetEnteById(myWorkflow.IDENTEDESTINO);
                    myWorkflow.tipologia = new TipologiaManagement().GetTipologiaById(myWorkflow.IDTIPOLOGIA);
                    myWorkflow.documento = new DocumentosManagement().GetDocumentosById(myWorkflow.iddocumento);
                    myWorkflow.expediente = new ExpedienteManagement().GetExpedienteById(myWorkflow.idexpediente);
                    myWorkflow.emirecep = new EmiRecepManagement().GetEmiRecepById(myWorkflow.IDEMIRECEP);
                     */
                    myWorkflow.ESTADO = dr["ESTADO"].ToString();
                    myWorkflow.SEMAFORO = dr["SEMAFORO"].ToString();

                    #endregion

                    allWorkflow.Add(myWorkflow);

                }
                return allWorkflow;
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



        public Workflow GetWorkflowByRadicadoLocal(string radicado)
        {
            MySqlCommand cmdSelect = ConnectionLocal.CreateCommand();

            cmdSelect.CommandText = "SELECT * FROM Workflow as c WHERE c.radicado = @radicado ";
            cmdSelect.Parameters.AddWithValue("@radicado", radicado);
            try
            {
                if (this.ConnectionLocal.State == ConnectionState.Closed)
                    this.ConnectionLocal.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                Workflow myWorkflow = new Workflow();

                while (dr.Read())
                {

                    #region Params

                    myWorkflow.ID = Convert.ToInt32(dr["ID"]);
                    myWorkflow.IDENTEORIGEN = Convert.ToInt32(dr["IDENTEORIGEN"]);
                    myWorkflow.IDENTEDESTINO = Convert.ToInt32(dr["IDENTEDESTINO"].ToString());
                    myWorkflow.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"].ToString());
                    myWorkflow.idexpediente = Convert.ToInt32(dr["IDEXPEDIENTE"].ToString());
                    myWorkflow.IDEMIRECEP = Convert.ToInt32(dr["IDEMIRECEP"].ToString());
                    myWorkflow.iddocumento = Convert.ToInt32(dr["iddocumento"].ToString());
                    myWorkflow.FECHA = Convert.ToDateTime(dr["FECHA"].ToString());
                    myWorkflow.RADICADO = dr["RADICADO"].ToString();
                    myWorkflow.DIAS = Convert.ToInt32(dr["DIAS"].ToString());
                    myWorkflow.OBSERVACION = dr["OBSERVACION"].ToString();
                    myWorkflow.TIPO = dr["TIPO"].ToString();
                    myWorkflow.idexpediente = Convert.ToInt32(dr["idexpediente"].ToString());
                    myWorkflow.IDEMIDESTINO = Convert.ToInt32(dr["idemidestino"].ToString());
                    myWorkflow.IDTAREA = Convert.ToInt32(dr["idTAREA"]);
                    myWorkflow.IDCADENA = Convert.ToInt32(dr["IDCADENA"]);
                    myWorkflow.RESPUESTA = dr["RESPUESTA"].ToString();
                    myWorkflow.FECHARESPUESTA = Convert.ToDateTime(dr["FECHARESPUESTA"].ToString());
                    myWorkflow.RADICADO2 = dr["RADICADO2"].ToString();
                    myWorkflow.IDTIPOCOM = Convert.ToInt32(dr["IDTIPOCOM"].ToString());
                    myWorkflow.LOCAL = Convert.ToInt32(dr["LOCAL"]);
                    myWorkflow.ACTUALIZADO = Convert.ToInt32(dr["ACTUALIZADO"]);
                    myWorkflow.CODIGOUSUARIO = Convert.ToInt32(dr["CODIGOUSUARIO"]);
                    /*
                    myWorkflow.enteorigen = new EnteManagement().GetEnteById(myWorkflow.IDENTEORIGEN);
                    myWorkflow.entedestino = new EnteManagement().GetEnteById(myWorkflow.IDENTEDESTINO);
                    myWorkflow.tipologia = new TipologiaManagement().GetTipologiaById(myWorkflow.IDTIPOLOGIA);
                    myWorkflow.documento = new DocumentosManagement().GetDocumentosById(myWorkflow.iddocumento);
                    myWorkflow.expediente = new ExpedienteManagement().GetExpedienteById(myWorkflow.idexpediente);
                    myWorkflow.emirecep = new EmiRecepManagement().GetEmiRecepById(myWorkflow.IDEMIRECEP);
                    */
                    myWorkflow.ESTADO = dr["ESTADO"].ToString();
                    myWorkflow.SEMAFORO = dr["SEMAFORO"].ToString();
                    //myWorkflow.IDRADICADO = Convert.ToInt32(dr["IDRADICADO"]);

                    if (dr["IDRADICADO"] != DBNull.Value)
                    {
                        myWorkflow.IDRADICADO = Convert.ToInt32(dr["IDRADICADO"]);
                    }
                    else
                    {
                        myWorkflow.IDRADICADO = 0;
                    }

                    #endregion

                }
                return myWorkflow;
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
        /// Delete Ente
        /// <param name="id">Required a filled instance of Ente</param>
        /// </summary>
        public bool DeleteWorkflow(int id)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM workflow WHERE ID=@ID";

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

            return true;
        }
        #endregion

        #region UPDATE Commands

        public void UpdateWorkflow(Workflow myWorkflow)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = @"Update Workflow SET  IDENTEORIGEN=@IDENTEORIGEN, IDENTEDESTINO=@IDENTEDESTINO, 
                                IDTIPOLOGIA=@IDTIPOLOGIA, IDEXPEDIENTE=@IDEXPEDIENTE,iddocumento=@iddocumento, FECHA=@FECHA, RADICADO=@RADICADO,
                                DIAS=@DIAS, OBSERVACION=@OBSERVACION, TIPO=@TIPO,ESTADO=@ESTADO,SEMAFORO=@SEMAFORO,IDEMIRECEP=@IDEMIRECEP, IDEMIDESTINO=@IDEMIdestino,IDTAREA=@IDTAREA,IDCADENA = @IDCADENA,RESPUESTA =@RESPUESTA,FECHARESPUESTA = @FECHARESPUESTA,IDRADICADO = @IDRADICADO, RADICADO2 = @RADICADO2, IDTIPOCOM = @IDTIPOCOM, idactividad= @IDACTIVIDAD where ID=@ID";

            #region params

            cmdUpdate.Parameters.AddWithValue("@ID", myWorkflow.ID);
            cmdUpdate.Parameters.AddWithValue("@IDENTEORIGEN", myWorkflow.IDENTEORIGEN);
            cmdUpdate.Parameters.AddWithValue("@IDENTEDESTINO", myWorkflow.IDENTEDESTINO);
            cmdUpdate.Parameters.AddWithValue("@IDTIPOLOGIA", myWorkflow.IDTIPOLOGIA);
            cmdUpdate.Parameters.AddWithValue("@IDEXPEDIENTE", myWorkflow.idexpediente);
            cmdUpdate.Parameters.AddWithValue("@iddocumento", myWorkflow.iddocumento);
            cmdUpdate.Parameters.AddWithValue("@FECHA", myWorkflow.FECHA);
            cmdUpdate.Parameters.AddWithValue("@RADICADO", myWorkflow.RADICADO);
            cmdUpdate.Parameters.AddWithValue("@DIAS", myWorkflow.DIAS);
            cmdUpdate.Parameters.AddWithValue("@OBSERVACION", myWorkflow.OBSERVACION);
            cmdUpdate.Parameters.AddWithValue("@TIPO", myWorkflow.TIPO);
            cmdUpdate.Parameters.AddWithValue("@ESTADO", myWorkflow.ESTADO);
            cmdUpdate.Parameters.AddWithValue("@SEMAFORO", myWorkflow.SEMAFORO);
            cmdUpdate.Parameters.AddWithValue("@IDEMIRECEP", myWorkflow.IDEMIRECEP);
            cmdUpdate.Parameters.AddWithValue("@IDEMIDESTINO", myWorkflow.IDEMIDESTINO);
            cmdUpdate.Parameters.AddWithValue("@IDTAREA", myWorkflow.IDTAREA);
            cmdUpdate.Parameters.AddWithValue("@IDCADENA", myWorkflow.IDCADENA);
            cmdUpdate.Parameters.AddWithValue("@RESPUESTA", myWorkflow.RESPUESTA);
            cmdUpdate.Parameters.AddWithValue("@FECHARESPUESTA", myWorkflow.FECHARESPUESTA);
            cmdUpdate.Parameters.AddWithValue("@IDRADICADO", myWorkflow.IDRADICADO);
            cmdUpdate.Parameters.AddWithValue("@RADICADO2", myWorkflow.RADICADO2);
            cmdUpdate.Parameters.AddWithValue("@IDTIPOCOM", myWorkflow.IDTIPOCOM);
            cmdUpdate.Parameters.AddWithValue("@IDACTIVIDAD", myWorkflow.idactividad);
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
        
        #region INSERT Comands
        /// <summary>
        /// Inserts a new  Ente
        /// <param name="myWorkflow">Required a filled instance of Ente</param>
        /// </summary>
        public int InsertWorkflow(Workflow myWorkflow)
        {

            MySqlCommand cmdInsert = Connection.CreateCommand();
            

            cmdInsert.CommandText = @"INSERT INTO Workflow (IDENTEORIGEN,IDENTEDESTINO,IDTIPOLOGIA,IDEXPEDIENTE,iddocumento,FECHA,RADICADO,DIAS,OBSERVACION,TIPO,ESTADO,SEMAFORO,IDEMIRECEP,IDEMIDESTINO,IDTAREA,IDCADENA,RESPUESTA,FECHARESPUESTA,IDRADICADO,RADICADO2,IDTIPOCOM,LOCAL,CODIGOUSUARIO,idactividad) VALUES 
                                                        (@IDENTEORIGEN,@IDENTEDESTINO,@IDTIPOLOGIA,@IDEXPEDIENTE,@iddocumento,@FECHA,@RADICADO,@DIAS,@OBSERVACION,@TIPO,@ESTADO,@SEMAFORO,@IDEMIRECEP,@IDEMIDESTINO,@IDTAREA,@IDCADENA,@RESPUESTA,@FECHARESPUESTA,@IDRADICADO,@RADICADO2,@IDTIPOCOM,@LOCAL,@CODIGOUSUARIO,@IDACTIVIDAD) ;SELECT LAST_INSERT_ID()";




            string url = HttpContext.Current.Request.Url.AbsoluteUri;

            if (url.ToUpper().Contains("LOCALHOST"))
            {

                myWorkflow.LOCAL = 1;
            }
            #region params

            cmdInsert.Parameters.AddWithValue("@IDENTEORIGEN", myWorkflow.IDENTEORIGEN);
            cmdInsert.Parameters.AddWithValue("@IDENTEDESTINO", myWorkflow.IDENTEDESTINO);
            cmdInsert.Parameters.AddWithValue("@IDTIPOLOGIA", myWorkflow.IDTIPOLOGIA);
            cmdInsert.Parameters.AddWithValue("@IDEXPEDIENTE", myWorkflow.idexpediente);
            cmdInsert.Parameters.AddWithValue("@iddocumento", myWorkflow.iddocumento);
            cmdInsert.Parameters.AddWithValue("@FECHA", myWorkflow.FECHA);
            cmdInsert.Parameters.AddWithValue("@RADICADO", myWorkflow.RADICADO);
            cmdInsert.Parameters.AddWithValue("@DIAS", myWorkflow.DIAS);
            cmdInsert.Parameters.AddWithValue("@OBSERVACION", myWorkflow.OBSERVACION);
            cmdInsert.Parameters.AddWithValue("@TIPO", myWorkflow.TIPO);
            cmdInsert.Parameters.AddWithValue("@ESTADO", myWorkflow.ESTADO);
            cmdInsert.Parameters.AddWithValue("@SEMAFORO", myWorkflow.SEMAFORO);
            cmdInsert.Parameters.AddWithValue("@IDEMIRECEP", myWorkflow.IDEMIRECEP);
            cmdInsert.Parameters.AddWithValue("@IDEMIDESTINO", myWorkflow.IDEMIDESTINO);
            cmdInsert.Parameters.AddWithValue("@IDTAREA", myWorkflow.IDTAREA);
            cmdInsert.Parameters.AddWithValue("@IDCADENA", myWorkflow.IDCADENA);
            cmdInsert.Parameters.AddWithValue("@RESPUESTA", myWorkflow.RESPUESTA);
            cmdInsert.Parameters.AddWithValue("@FECHARESPUESTA", myWorkflow.FECHARESPUESTA);
            cmdInsert.Parameters.AddWithValue("@IDRADICADO", myWorkflow.IDRADICADO);
            cmdInsert.Parameters.AddWithValue("@RADICADO2", myWorkflow.RADICADO2);
            cmdInsert.Parameters.AddWithValue("@IDTIPOCOM", myWorkflow.IDTIPOCOM);
            cmdInsert.Parameters.AddWithValue("@LOCAL", myWorkflow.LOCAL);
            cmdInsert.Parameters.AddWithValue("@CODIGOUSUARIO", myWorkflow.CODIGOUSUARIO);
            cmdInsert.Parameters.AddWithValue("@IDACTIVIDAD", myWorkflow.idactividad);
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



        public int InsertWorkflowLocal(Workflow myWorkflow)
        {

            MySqlCommand cmdInsert = ConnectionLocal.CreateCommand();


            cmdInsert.CommandText = @"INSERT INTO Workflow (IDENTEORIGEN,IDENTEDESTINO,IDTIPOLOGIA,IDEXPEDIENTE,iddocumento,FECHA,RADICADO,DIAS,OBSERVACION,TIPO,ESTADO,SEMAFORO,IDEMIRECEP,IDEMIDESTINO,IDTAREA,IDCADENA,RESPUESTA,FECHARESPUESTA,IDRADICADO,RADICADO2,IDTIPOCOM,LOCAL,CODIGOUSUARIO) VALUES 
                                                        (@IDENTEORIGEN,@IDENTEDESTINO,@IDTIPOLOGIA,@IDEXPEDIENTE,@iddocumento,@FECHA,@RADICADO,@DIAS,@OBSERVACION,@TIPO,@ESTADO,@SEMAFORO,@IDEMIRECEP,@IDEMIDESTINO,@IDTAREA,@IDCADENA,@RESPUESTA,@FECHARESPUESTA,@IDRADICADO,@RADICADO2,@IDTIPOCOM,@LOCAL,@CODIGOUSUARIO) ;SELECT LAST_INSERT_ID()";




            

            
            #region params

            cmdInsert.Parameters.AddWithValue("@IDENTEORIGEN", myWorkflow.IDENTEORIGEN);
            cmdInsert.Parameters.AddWithValue("@IDENTEDESTINO", myWorkflow.IDENTEDESTINO);
            cmdInsert.Parameters.AddWithValue("@IDTIPOLOGIA", myWorkflow.IDTIPOLOGIA);
            cmdInsert.Parameters.AddWithValue("@IDEXPEDIENTE", myWorkflow.idexpediente);
            cmdInsert.Parameters.AddWithValue("@iddocumento", myWorkflow.iddocumento);
            cmdInsert.Parameters.AddWithValue("@FECHA", myWorkflow.FECHA);
            cmdInsert.Parameters.AddWithValue("@RADICADO", myWorkflow.RADICADO);
            cmdInsert.Parameters.AddWithValue("@DIAS", myWorkflow.DIAS);
            cmdInsert.Parameters.AddWithValue("@OBSERVACION", myWorkflow.OBSERVACION);
            cmdInsert.Parameters.AddWithValue("@TIPO", myWorkflow.TIPO);
            cmdInsert.Parameters.AddWithValue("@ESTADO", myWorkflow.ESTADO);
            cmdInsert.Parameters.AddWithValue("@SEMAFORO", myWorkflow.SEMAFORO);
            cmdInsert.Parameters.AddWithValue("@IDEMIRECEP", myWorkflow.IDEMIRECEP);
            cmdInsert.Parameters.AddWithValue("@IDEMIDESTINO", myWorkflow.IDEMIDESTINO);
            cmdInsert.Parameters.AddWithValue("@IDTAREA", myWorkflow.IDTAREA);
            cmdInsert.Parameters.AddWithValue("@IDCADENA", myWorkflow.IDCADENA);
            cmdInsert.Parameters.AddWithValue("@RESPUESTA", myWorkflow.RESPUESTA);
            cmdInsert.Parameters.AddWithValue("@FECHARESPUESTA", myWorkflow.FECHARESPUESTA);
            cmdInsert.Parameters.AddWithValue("@IDRADICADO", myWorkflow.IDRADICADO);
            cmdInsert.Parameters.AddWithValue("@RADICADO2", myWorkflow.RADICADO2);
            cmdInsert.Parameters.AddWithValue("@IDTIPOCOM", myWorkflow.IDTIPOCOM);
            cmdInsert.Parameters.AddWithValue("@LOCAL", myWorkflow.LOCAL);
            cmdInsert.Parameters.AddWithValue("@CODIGOUSUARIO", myWorkflow.CODIGOUSUARIO);
            #endregion
            int id = 0;
            try
            {
                if (this.ConnectionLocal.State == ConnectionState.Closed)
                    this.ConnectionLocal.Open();
                id = Convert.ToInt32(cmdInsert.ExecuteScalar());

            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (ConnectionLocal.State == ConnectionState.Open)
                    ConnectionLocal.Close();
            }
            return id;
        }

        #endregion



        
    }
}