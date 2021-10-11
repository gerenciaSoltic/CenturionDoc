using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gestion_documental.Utils;
using MySql.Data.MySqlClient;
using System.Data;
using gestion_documental.BusinessObjects;
using GESTIONDOCUMENTAL.Utils;


namespace gestion_documental.DataAccessLayer
{
    public class DocumentosManagement : ConnectionClass
    {

        public static DateTime Fdesde;
        public static DateTime Fhasta;

        #region Sql
        private string DefaultSelect = @"SELECT 
                                        c.idDOCUMENTOS ,
                                        IF(c.IDSERIE IS NULL, '0', c.IDSERIE) as IDSERIE,
                                        IF(c.IDSUBSERIE IS NULL, '0', c.IDSUBSERIE) as IDSUBSERIE,
                                        IF(c.IDTIPOLOGIA IS NULL, '0', c.IDTIPOLOGIA) as IDTIPOLOGIA,
                                        c.DOCUMENTO,
                                        c.CAMINO,
                                        IF(c.IDEXPEDIENTE IS NULL, '0', c.IDEXPEDIENTE) as IDEXPEDIENTE,
                                        IF(c.FOLIOS IS NULL, '0', c.FOLIOS) as FOLIOS,
                                        c.ANEXOS,c.IDENTE,c.VERSION,
                                        IF(c.CALIDAD IS NULL, '0', c.CALIDAD) as CALIDAD,DESCRIPCION,LOCAL,ACTUALIZADO
                                        c.iddocumentoactividad
                                        FROM documentos as c"
                                   ;

        #endregion
        #region Constructors
        public DocumentosManagement()
        {

        }
        #endregion

        #region SELECT Commands

        /// <summary>
        /// Gets the whole list of fuel types
        /// <returns>List of Type Fuel Types</returns>
        /// </summary>
        public List<Documentos> GetAllDocumentos()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect;

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Documentos> allDocumentos = new List<Documentos>();

                while (dr.Read())
                {
                    Documentos myDocumentos = new Documentos();

                    #region Params

                    myDocumentos.idDOCUMENTOS = Convert.ToInt32(dr["idDOCUMENTOS"]);
                    myDocumentos.IDSERIE = Convert.ToInt32(dr["IDSERIE"]);
                    myDocumentos.IDSUBSERIE = Convert.ToInt32(dr["IDSUBSERIE"].ToString());
                    myDocumentos.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"].ToString());
                    myDocumentos.DOCUMENTO = dr["DOCUMENTO"].ToString();
                    myDocumentos.DESCRIPCION = dr["DESCRIPCION"].ToString();
                    myDocumentos.CAMINO = dr["CAMINO"].ToString();
                    myDocumentos.IDEXPEDIENTE = Convert.ToInt32(dr["IDEXPEDIENTE"].ToString());
                    myDocumentos.FOLIOS = Convert.ToInt32(dr["FOLIOS"].ToString());
                    myDocumentos.ANEXOS = dr["ANEXOS"].ToString();
                    myDocumentos.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myDocumentos.VERSION = Convert.ToInt32(dr["VERSION"]);
                    myDocumentos.CALIDAD = Convert.ToInt32(dr["CALIDAD"]);
                    myDocumentos.LOCAL = Convert.ToInt32(dr["LOCAL"]);
                    myDocumentos.ACTUALIZADO = Convert.ToInt32(dr["ACTUALIZADO"]);
                    myDocumentos.iddocumentoactividad = Convert.ToInt32(dr["iddocumentoactividad"]);
                    

                    Serie serie = new Serie();
                    SubSerie Subserie = new SubSerie();
                    Tipologia Tipologia = new Tipologia();
                    Expediente Expediente = new Expediente();

                    serie = new SerieManagement().GetSerieById(Convert.ToInt32(myDocumentos.IDSERIE));
                    Subserie = new SubSerieManagement().GetSubSerieById(Convert.ToInt32(myDocumentos.IDSUBSERIE));
                    Tipologia = new TipologiaManagement().GetTipologiaById(Convert.ToInt32(myDocumentos.IDTIPOLOGIA));
                    Expediente = new ExpedienteManagement().GetExpedienteById(Convert.ToInt32(myDocumentos.IDTIPOLOGIA));
                    myDocumentos.NOMSERIE = serie.SERIE;
                    myDocumentos.NOMSUBSERIE = Subserie.SUBSERIE;
                    myDocumentos.NOMTIPOLOGIA = Tipologia.TIPOLOGIA;
                    myDocumentos.NOMEXPEDIENTE = Expediente.descripcion;


                    #endregion

                    allDocumentos.Add(myDocumentos);

                }
                return allDocumentos;
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


        public List<Documentos> GetAllDocumentosSinNombre()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " where documento is null or documento = '' ";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Documentos> allDocumentos = new List<Documentos>();

                while (dr.Read())
                {
                    Documentos myDocumentos = new Documentos();

                    #region Params

                    myDocumentos.idDOCUMENTOS = Convert.ToInt32(dr["idDOCUMENTOS"]);
                    myDocumentos.IDSERIE = Convert.ToInt32(dr["IDSERIE"]);
                    myDocumentos.IDSUBSERIE = Convert.ToInt32(dr["IDSUBSERIE"].ToString());
                    myDocumentos.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"].ToString());
                    myDocumentos.DOCUMENTO = dr["DOCUMENTO"].ToString();
                    myDocumentos.DESCRIPCION = dr["DESCRIPCION"].ToString();
                    myDocumentos.CAMINO = dr["CAMINO"].ToString();
                    myDocumentos.IDEXPEDIENTE = Convert.ToInt32(dr["IDEXPEDIENTE"].ToString());
                    myDocumentos.FOLIOS = Convert.ToInt32(dr["FOLIOS"].ToString());
                    myDocumentos.ANEXOS = dr["ANEXOS"].ToString();
                    myDocumentos.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myDocumentos.VERSION = Convert.ToInt32(dr["VERSION"]);
                    myDocumentos.CALIDAD = Convert.ToInt32(dr["CALIDAD"]);
                    myDocumentos.LOCAL = Convert.ToInt32(dr["LOCAL"]);
                    myDocumentos.ACTUALIZADO = Convert.ToInt32(dr["ACTUALIZADO"]);
                    myDocumentos.iddocumentoactividad = Convert.ToInt32(dr["iddocumentoactividad"]);

                    Serie serie = new Serie();
                    SubSerie Subserie = new SubSerie();
                    Tipologia Tipologia = new Tipologia();
                    Expediente Expediente = new Expediente();

                    serie = new SerieManagement().GetSerieById(Convert.ToInt32(myDocumentos.IDSERIE));
                    Subserie = new SubSerieManagement().GetSubSerieById(Convert.ToInt32(myDocumentos.IDSUBSERIE));
                    Tipologia = new TipologiaManagement().GetTipologiaById(Convert.ToInt32(myDocumentos.IDTIPOLOGIA));
                    Expediente = new ExpedienteManagement().GetExpedienteById(Convert.ToInt32(myDocumentos.IDTIPOLOGIA));
                    myDocumentos.NOMSERIE = serie.SERIE;
                    myDocumentos.NOMSUBSERIE = Subserie.SUBSERIE;
                    myDocumentos.NOMTIPOLOGIA = Tipologia.TIPOLOGIA;
                    myDocumentos.NOMEXPEDIENTE = Expediente.descripcion;


                    #endregion

                    allDocumentos.Add(myDocumentos);

                }
                return allDocumentos;
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




        public List<Documentos> GetDocumentosbyIDExpediente(int idexpediente, int idente)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT documentos.camino,documentos.iddocumentos,documentos.documento,documentos.DESCRIPCION,linkdoc.idserie,linkdoc.idsubserie,linkdoc.idtipologia,linkdoc.idexpediente,documentos.folios,documentos.anexos,linkdoc.idente,documentos.version,documentos.calidad,documentos.local,documentos.actualizado FROM documentos,linkdoc WHERE documentos.iddocumentos = linkdoc.iddocumentos AND linkdoc.idente = @idente AND linkdoc.idexpediente = @idexpediente";

            cmdSelect.Parameters.AddWithValue("@idexpediente", idexpediente);
            cmdSelect.Parameters.AddWithValue("@idente", idente);

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Documentos> DocumentosExpediente = new List<Documentos>();

                while (dr.Read())
                {
                    Documentos myDocumentos = new Documentos();

                    #region Params

                    myDocumentos.idDOCUMENTOS = Convert.ToInt32(dr["idDOCUMENTOS"]);
                    myDocumentos.IDSERIE = Convert.ToInt32(dr["IDSERIE"]);
                    myDocumentos.IDSUBSERIE = Convert.ToInt32(dr["IDSUBSERIE"].ToString());
                    myDocumentos.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"].ToString());
                    myDocumentos.DOCUMENTO = dr["DOCUMENTO"].ToString();
                    myDocumentos.DESCRIPCION = dr["DESCRIPCION"].ToString();
                    myDocumentos.CAMINO = dr["CAMINO"].ToString();
                    myDocumentos.IDEXPEDIENTE = Convert.ToInt32(dr["IDEXPEDIENTE"].ToString());
                    myDocumentos.FOLIOS = Convert.ToInt32(dr["FOLIOS"].ToString());
                    myDocumentos.ANEXOS = dr["ANEXOS"].ToString();

                    myDocumentos.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myDocumentos.VERSION = Convert.ToInt32(dr["VERSION"]);
                    myDocumentos.CALIDAD = Convert.ToInt32(dr["CALIDAD"]);
                    myDocumentos.LOCAL = Convert.ToInt32(dr["LOCAL"]);
                    myDocumentos.ACTUALIZADO = Convert.ToInt32(dr["ACTUALIZADO"]);

                    Serie serie1 = new Serie();
                    SubSerie Subserie1 = new SubSerie();
                    Tipologia Tipologia1 = new Tipologia();
                    Expediente Expediente1 = new Expediente();

                    serie1 = new SerieManagement().GetSerieById(Convert.ToInt32(myDocumentos.IDSERIE));
                    Subserie1 = new SubSerieManagement().GetSubSerieById(Convert.ToInt32(myDocumentos.IDSUBSERIE));
                    Tipologia1 = new TipologiaManagement().GetTipologiaById(Convert.ToInt32(myDocumentos.IDTIPOLOGIA));
                    Expediente1 = new ExpedienteManagement().GetExpedienteById(Convert.ToInt32(myDocumentos.IDEXPEDIENTE));
                    myDocumentos.NOMSERIE = serie1.SERIE;
                    myDocumentos.NOMSUBSERIE = Subserie1.SUBSERIE;
                    myDocumentos.NOMTIPOLOGIA = Tipologia1.TIPOLOGIA;
                    myDocumentos.NOMEXPEDIENTE = Expediente1.descripcion;
                    #endregion

                    DocumentosExpediente.Add(myDocumentos);

                }
                return DocumentosExpediente;
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


        public List<Documentos> GetDocumentosbyListaiD(int idcadena)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT c.iddocumentos,b.idserie,b.idsubserie,b.idtipologia,c.documento,c.descripcion,c.camino,b.idexpediente,c.folios,c.anexos,c.idente,c.version,c.calidad,c.local,c.actualizado from  documentos c,workflow a,linkdoc b WHERE c.iddocumentos = b.iddocumentos and a.iddocumento = c.iddocumentos and a.idcadena = @id GROUP BY c.iddocumentos,b.idserie,b.idsubserie,b.idtipologia,c.documento,c.camino,b.idexpediente,c.folios,c.anexos,c.idente,c.version,c.calidad";

            cmdSelect.Parameters.AddWithValue("@id", idcadena);

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Documentos> DocumentosExpediente = new List<Documentos>();

                while (dr.Read())
                {
                    Documentos myDocumentos = new Documentos();

                    #region Params

                    myDocumentos.idDOCUMENTOS = Convert.ToInt32(dr["idDOCUMENTOS"]);
                    myDocumentos.IDSERIE = Convert.ToInt32(dr["IDSERIE"]);
                    myDocumentos.IDSUBSERIE = Convert.ToInt32(dr["IDSUBSERIE"].ToString());
                    myDocumentos.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"].ToString());
                    myDocumentos.DOCUMENTO = dr["DOCUMENTO"].ToString();
                    myDocumentos.DESCRIPCION = dr["DESCRIPCION"].ToString();
                    myDocumentos.CAMINO = dr["CAMINO"].ToString();
                    myDocumentos.IDEXPEDIENTE = Convert.ToInt32(dr["IDEXPEDIENTE"].ToString());
                    myDocumentos.FOLIOS = Convert.ToInt32(dr["FOLIOS"].ToString());
                    myDocumentos.ANEXOS = dr["ANEXOS"].ToString();

                    myDocumentos.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myDocumentos.VERSION = Convert.ToInt32(dr["VERSION"]);
                    myDocumentos.CALIDAD = Convert.ToInt32(dr["CALIDAD"]);
                    myDocumentos.LOCAL = Convert.ToInt32(dr["LOCAL"]);
                    myDocumentos.ACTUALIZADO = Convert.ToInt32(dr["ACTUALIZADO"]);


                    Serie serie1 = new Serie();
                    SubSerie Subserie1 = new SubSerie();
                    Tipologia Tipologia1 = new Tipologia();
                    Expediente Expediente1 = new Expediente();

                    serie1 = new SerieManagement().GetSerieById(Convert.ToInt32(myDocumentos.IDSERIE));
                    Subserie1 = new SubSerieManagement().GetSubSerieById(Convert.ToInt32(myDocumentos.IDSUBSERIE));
                    Tipologia1 = new TipologiaManagement().GetTipologiaById(Convert.ToInt32(myDocumentos.IDTIPOLOGIA));
                    Expediente1 = new ExpedienteManagement().GetExpedienteById(Convert.ToInt32(myDocumentos.IDEXPEDIENTE));
                    myDocumentos.NOMSERIE = serie1.SERIE;
                    myDocumentos.NOMSUBSERIE = Subserie1.SUBSERIE;
                    myDocumentos.NOMTIPOLOGIA = Tipologia1.TIPOLOGIA;
                    myDocumentos.NOMEXPEDIENTE = Expediente1.descripcion;

                    #endregion
                    
                    DocumentosExpediente.Add(myDocumentos);

                }
                return DocumentosExpediente;
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

        public List<Documentos> GetDocumentosNombrebyListaiD(int idcadena)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT c.iddocumentos,b.idserie,b.idsubserie,b.idtipologia,c.documento,c.descripcion,c.camino,b.idexpediente,c.folios,c.anexos,c.idente,c.version,c.calidad,c.local,c.actualizado,c.iddocumentoactividad from  documentos c,workflow a,linkdoc b WHERE c.iddocumentos = b.iddocumentos and a.iddocumento = c.iddocumentos and a.idcadena = @id GROUP BY c.iddocumentos,b.idserie,b.idsubserie,b.idtipologia,c.documento,c.camino,b.idexpediente,c.folios,c.anexos,c.idente,c.version,c.calidad";

            cmdSelect.Parameters.AddWithValue("@id", idcadena);

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Documentos> DocumentosExpediente = new List<Documentos>();

                while (dr.Read())
                {
                    Documentos myDocumentos = new Documentos();

                    #region Params

                    myDocumentos.idDOCUMENTOS = Convert.ToInt32(dr["idDOCUMENTOS"]);
                    myDocumentos.IDSERIE = Convert.ToInt32(dr["IDSERIE"]);
                    myDocumentos.IDSUBSERIE = Convert.ToInt32(dr["IDSUBSERIE"].ToString());
                    myDocumentos.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"].ToString());
                    myDocumentos.DOCUMENTO = dr["DOCUMENTO"].ToString();
                    myDocumentos.DESCRIPCION = dr["DESCRIPCION"].ToString();
                    myDocumentos.CAMINO = dr["CAMINO"].ToString();
                    myDocumentos.IDEXPEDIENTE = Convert.ToInt32(dr["IDEXPEDIENTE"].ToString());
                    myDocumentos.FOLIOS = Convert.ToInt32(dr["FOLIOS"].ToString());
                    myDocumentos.ANEXOS = dr["ANEXOS"].ToString();

                    myDocumentos.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myDocumentos.VERSION = Convert.ToInt32(dr["VERSION"]);
                    myDocumentos.CALIDAD = Convert.ToInt32(dr["CALIDAD"]);
                    myDocumentos.LOCAL = Convert.ToInt32(dr["LOCAL"]);
                    myDocumentos.ACTUALIZADO = Convert.ToInt32(dr["ACTUALIZADO"]);
                    myDocumentos.iddocumentoactividad= Convert.ToInt32(dr["iddocumentoactividad"]); 

                    Serie serie1 = new Serie();
                    SubSerie Subserie1 = new SubSerie();
                    Tipologia Tipologia1 = new Tipologia();
                    Expediente Expediente1 = new Expediente();
                    DocumentoActividad DocuementoActividad1 = new DocumentoActividad();

                    serie1 = new SerieManagement().GetSerieById(Convert.ToInt32(myDocumentos.IDSERIE));
                    Subserie1 = new SubSerieManagement().GetSubSerieById(Convert.ToInt32(myDocumentos.IDSUBSERIE));
                    Tipologia1 = new TipologiaManagement().GetTipologiaById(Convert.ToInt32(myDocumentos.IDTIPOLOGIA));
                    Expediente1 = new ExpedienteManagement().GetExpedienteById(Convert.ToInt32(myDocumentos.IDEXPEDIENTE));
                    DocuementoActividad1 = new DocumentoActividadManagement().GetDocumentoActividadById(myDocumentos.iddocumentoactividad);
                    myDocumentos.NOMSERIE = serie1.SERIE;
                    myDocumentos.NOMSUBSERIE = Subserie1.SUBSERIE;
                    myDocumentos.NOMTIPOLOGIA = Tipologia1.TIPOLOGIA;
                    myDocumentos.NOMEXPEDIENTE = Expediente1.descripcion;
                    myDocumentos.documentoactividad = DocuementoActividad1;

                    #endregion

                    DocumentosExpediente.Add(myDocumentos);

                }
                return DocumentosExpediente;
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

        public List<Documentos> GetDocumentosbyIDExpedientesinlink(int idexpediente, int idente)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT documentos.documento,documentos.camino,documentos.iddocumentos,documentos.descripcion,linkdoc.idente,linkdoc.idserie,linkdoc.idsubserie,linkdoc.idtipologia,linkdoc.idexpediente,documentos.folios,documentos.anexos,documentos.version,documentos.calidad FROM documentos,linkdoc WHERE documentos.iddocumentos = linkdoc.iddocumentos  and linkdoc.idente = @idente AND documentos.idexpediente = @idexpediente";

            cmdSelect.Parameters.AddWithValue("@idexpediente", idexpediente);
            cmdSelect.Parameters.AddWithValue("@idente", idente);

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Documentos> DocumentosExpediente = new List<Documentos>();

                while (dr.Read())
                {
                    Documentos myDocumentos = new Documentos();

                    #region Params

                    myDocumentos.idDOCUMENTOS = Convert.ToInt32(dr["idDOCUMENTOS"]);
                    myDocumentos.IDSERIE = Convert.ToInt32(dr["IDSERIE"]);
                    myDocumentos.IDSUBSERIE = Convert.ToInt32(dr["IDSUBSERIE"].ToString());
                    myDocumentos.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"].ToString());
                    myDocumentos.DOCUMENTO = dr["DOCUMENTO"].ToString();
                    myDocumentos.DESCRIPCION = dr["DESCRIPCION"].ToString();
                    myDocumentos.CAMINO = dr["CAMINO"].ToString();
                    myDocumentos.IDEXPEDIENTE = Convert.ToInt32(dr["IDEXPEDIENTE"].ToString());
                    myDocumentos.FOLIOS = Convert.ToInt32(dr["FOLIOS"].ToString());
                    myDocumentos.ANEXOS = dr["ANEXOS"].ToString();

                    myDocumentos.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myDocumentos.VERSION = Convert.ToInt32(dr["VERSION"]);
                    myDocumentos.CALIDAD = Convert.ToInt32(dr["CALIDAD"]);

                    Serie serie1 = new Serie();
                    SubSerie Subserie1 = new SubSerie();
                    Tipologia Tipologia1 = new Tipologia();
                    Expediente Expediente1 = new Expediente();

                    serie1 = new SerieManagement().GetSerieById(Convert.ToInt32(myDocumentos.IDSERIE));
                    Subserie1 = new SubSerieManagement().GetSubSerieById(Convert.ToInt32(myDocumentos.IDSUBSERIE));
                    Tipologia1 = new TipologiaManagement().GetTipologiaById(Convert.ToInt32(myDocumentos.IDTIPOLOGIA));
                    Expediente1 = new ExpedienteManagement().GetExpedienteById(Convert.ToInt32(myDocumentos.IDEXPEDIENTE));
                    myDocumentos.NOMSERIE = serie1.SERIE;
                    myDocumentos.NOMSUBSERIE = Subserie1.SUBSERIE;
                    myDocumentos.NOMTIPOLOGIA = Tipologia1.TIPOLOGIA;
                    myDocumentos.NOMEXPEDIENTE = Expediente1.descripcion;
                    #endregion

                    DocumentosExpediente.Add(myDocumentos);

                }
                return DocumentosExpediente;
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




        public Documentos GetDocumentosbyNotDigital()
        {

            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT documentos.documento,documentos.camino,documentos.iddocumentos,documentos.descripcion,linkdoc.idente,linkdoc.idserie,linkdoc.idsubserie,linkdoc.idtipologia,linkdoc.idexpediente,documentos.folios,documentos.anexos,documentos.version,documentos.calidad,workflow.radicado FROM documentos,linkdoc,workflow WHERE documentos.iddocumentos = linkdoc.iddocumentos  and documentos.iddocumentos = workflow.iddocumento and (documentos.documento = '' or documentos.documento = null) ";


            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                {
                    this.Connection.Open();
                }
                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);

                Documentos myDocumentos = new Documentos();
                while (dr.Read())
                {
                    /*
                    #region Params
                    dr.Read();
                    myDocumentos.idDOCUMENTOS = Convert.ToInt32(dr["idDOCUMENTOS"]);
                    myDocumentos.IDSERIE = Convert.ToInt32(dr["IDSERIE"]);
                    myDocumentos.IDSUBSERIE = Convert.ToInt32(dr["IDSUBSERIE"].ToString());
                    myDocumentos.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"].ToString());
                    myDocumentos.DOCUMENTO = dr["DOCUMENTO"].ToString();
                    myDocumentos.DESCRIPCION = dr["DESCRIPCION"].ToString();
                    myDocumentos.CAMINO = dr["CAMINO"].ToString();
                    myDocumentos.IDEXPEDIENTE = Convert.ToInt32(dr["IDEXPEDIENTE"].ToString());
                    myDocumentos.FOLIOS = Convert.ToInt32(dr["FOLIOS"].ToString());
                    myDocumentos.ANEXOS = dr["ANEXOS"].ToString();

                    myDocumentos.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myDocumentos.VERSION = Convert.ToInt32(dr["VERSION"]);
                    myDocumentos.CALIDAD = Convert.ToInt32(dr["CALIDAD"]);
                    myDocumentos.RADICADO = dr["RADICADO"].ToString();

                    Serie serie1 = new Serie();
                    SubSerie Subserie1 = new SubSerie();
                    Tipologia Tipologia1 = new Tipologia();
                    Expediente Expediente1 = new Expediente();

                    serie1 = new SerieManagement().GetSerieById(Convert.ToInt32(myDocumentos.IDSERIE));
                    Subserie1 = new SubSerieManagement().GetSubSerieById(Convert.ToInt32(myDocumentos.IDSUBSERIE));
                    Tipologia1 = new TipologiaManagement().GetTipologiaById(Convert.ToInt32(myDocumentos.IDTIPOLOGIA));
                    Expediente1 = new ExpedienteManagement().GetExpedienteById(Convert.ToInt32(myDocumentos.IDEXPEDIENTE));
                    myDocumentos.NOMSERIE = serie1.SERIE;
                    myDocumentos.NOMSUBSERIE = Subserie1.SUBSERIE;
                    myDocumentos.NOMTIPOLOGIA = Tipologia1.TIPOLOGIA;
                    myDocumentos.NOMEXPEDIENTE = Expediente1.descripcion;
                    #endregion
                    */
                }

                return myDocumentos;
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


        public List<HistoriaLaboral> GetDocumentosExpediente()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT documentos.fechacarga, expediente.descripcion, documentos.DOCUMENTO " +
                                    " FROM documentos " +
                                    " INNER JOIN expediente ON documentos.IDEXPEDIENTE = expediente.id " +
                                    " WHERE documentos.fechacarga >= '" + Fdesde + "' AND documentos.fechacarga <= '" + Fhasta + "' " +
                                    " ORDER BY documentos.fechacarga";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<HistoriaLaboral> DocumentosExpediente = new List<HistoriaLaboral>();

                while (dr.Read())
                {
                    HistoriaLaboral myDocumentos = new HistoriaLaboral();

                    #region Params

                    myDocumentos.FECHACARGA = Convert.ToDateTime(dr["fechacarga"]);
                    myDocumentos.DESCRIPCION = dr["descripcion"].ToString();
                    myDocumentos.DOCUMENTO = dr["DOCUMENTO"].ToString();

                    #endregion

                    DocumentosExpediente.Add(myDocumentos);

                }
                return DocumentosExpediente;

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
















        public List<CalidadDigital> GetDocumentosbyNotCalidad()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = @"select ex.fechainicio as fecha,ex.descripcion, IF(UPPER (RIGHT(documento ,4)) = '.PDF',documento, '') as documento, conf.caminocalidad,doc.idDocumentos from documentos doc,usuarios,emirecep em,conficor conf,expediente ex 
                                         where doc.idexpediente=ex.id and
                                        usuarios.codigo = em.codigousuario and
                                        conf.id=em.idconficor and
                                         doc.documento <> '' and (doc.CALIDAD=0 or doc.CALIDAD is null) and usuarios.codigo=" + SessionDocumental.UsuarioInicioSession.CODIGO.ToString() + " group by fecha,ex.descripcion, documento, conf.caminocalidad,doc.idDocumentos";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<CalidadDigital> allDocumentos = new List<CalidadDigital>();

                while (dr.Read())
                {
                    CalidadDigital myDocumentos = new CalidadDigital();

                    #region Params
                    Workflow wf = new Workflow();
                    int i = wf.DIAS;
                    myDocumentos.FECHA = Convert.ToDateTime(dr["fecha"]);
                    myDocumentos.EXPEDIENTE = dr["descripcion"].ToString();
                    myDocumentos.DOCUMENTO = dr["documento"].ToString();
                    myDocumentos.CAMINOCALIDAD = dr["caminocalidad"].ToString();
                    myDocumentos.RUTA = Util.PathDocumentosDESC + "\\" + dr["documento"].ToString();
                    myDocumentos.IDDOCUMENTO = Convert.ToInt32(dr["idDocumentos"]);

                    #endregion

                    allDocumentos.Add(myDocumentos);

                }
                return allDocumentos;
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



        public List<Documentos> GetDocumentosLocal()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " where local = 1 and actualizado = 0";

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Documentos> allDocumentos = new List<Documentos>();

                while (dr.Read())
                {
                    Documentos myDocumentos = new Documentos();

                    #region Params

                    myDocumentos.idDOCUMENTOS = Convert.ToInt32(dr["idDOCUMENTOS"]);
                    myDocumentos.IDSERIE = Convert.ToInt32(dr["IDSERIE"]);
                    myDocumentos.IDSUBSERIE = Convert.ToInt32(dr["IDSUBSERIE"].ToString());
                    myDocumentos.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"].ToString());
                    myDocumentos.DOCUMENTO = dr["DOCUMENTO"].ToString();
                    myDocumentos.DESCRIPCION = dr["DESCRIPCION"].ToString();
                    myDocumentos.CAMINO = dr["CAMINO"].ToString();
                    myDocumentos.IDEXPEDIENTE = Convert.ToInt32(dr["IDEXPEDIENTE"].ToString());
                    myDocumentos.FOLIOS = Convert.ToInt32(dr["FOLIOS"].ToString());
                    myDocumentos.ANEXOS = dr["ANEXOS"].ToString();
                    myDocumentos.IDENTE = Convert.ToInt32(dr["IDENTE"]);
                    myDocumentos.VERSION = Convert.ToInt32(dr["VERSION"]);
                    myDocumentos.CALIDAD = Convert.ToInt32(dr["CALIDAD"]);
                    myDocumentos.LOCAL = Convert.ToInt32(dr["LOCAL"]);
                    myDocumentos.ACTUALIZADO = Convert.ToInt32(dr["ACTUALIZADO"]);

                    Serie serie = new Serie();
                    SubSerie Subserie = new SubSerie();
                    Tipologia Tipologia = new Tipologia();
                    Expediente Expediente = new Expediente();

                    serie = new SerieManagement().GetSerieById(Convert.ToInt32(myDocumentos.IDSERIE));
                    Subserie = new SubSerieManagement().GetSubSerieById(Convert.ToInt32(myDocumentos.IDSUBSERIE));
                    Tipologia = new TipologiaManagement().GetTipologiaById(Convert.ToInt32(myDocumentos.IDTIPOLOGIA));
                    Expediente = new ExpedienteManagement().GetExpedienteById(Convert.ToInt32(myDocumentos.IDTIPOLOGIA));
                    myDocumentos.NOMSERIE = serie.SERIE;
                    myDocumentos.NOMSUBSERIE = Subserie.SUBSERIE;
                    myDocumentos.NOMTIPOLOGIA = Tipologia.TIPOLOGIA;
                    myDocumentos.NOMEXPEDIENTE = Expediente.descripcion;


                    #endregion

                    allDocumentos.Add(myDocumentos);

                }
                return allDocumentos;
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

        public void UpdateDocumentos(Documentos myDocumentos)
        {
            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = "Update Documentos SET  IDSERIE=@IDSERIE, IDSUBSERIE=@IDSUBSERIE, IDTIPOLOGIA=@IDTIPOLOGIA, DOCUMENTO=@DOCUMENTO, CAMINO=@CAMINO,FOLIOS = @FOLIOS,ANEXOS = @ANEXOS,IDEXPEDIENTE = @IDEXPEDIENTE, CALIDAD=@CALIDAD,DESCRIPCION=@DESCRIPCION,iddocumentoactividad=@IDDOCUMENTOACTIVIDAD where idDOCUMENTOS=@idDOCUMENTOS and VERSION=@VERSION";

            #region params

            cmdUpdate.Parameters.AddWithValue("@idDOCUMENTOS", myDocumentos.idDOCUMENTOS);
            cmdUpdate.Parameters.AddWithValue("@IDSERIE", myDocumentos.IDSERIE);
            cmdUpdate.Parameters.AddWithValue("@IDSUBSERIE", myDocumentos.IDSUBSERIE);
            cmdUpdate.Parameters.AddWithValue("@IDTIPOLOGIA", myDocumentos.IDTIPOLOGIA);
            cmdUpdate.Parameters.AddWithValue("@DOCUMENTO", myDocumentos.DOCUMENTO);
            cmdUpdate.Parameters.AddWithValue("@CAMINO", myDocumentos.CAMINO);
            cmdUpdate.Parameters.AddWithValue("@FOLIOS", myDocumentos.FOLIOS);
            cmdUpdate.Parameters.AddWithValue("@ANEXOS", myDocumentos.ANEXOS);
            cmdUpdate.Parameters.AddWithValue("@IDEXPEDIENTE", myDocumentos.IDEXPEDIENTE);
            cmdUpdate.Parameters.AddWithValue("@VERSION", myDocumentos.VERSION);
            cmdUpdate.Parameters.AddWithValue("@CALIDAD", myDocumentos.CALIDAD);
            cmdUpdate.Parameters.AddWithValue("@DESCRIPCION", myDocumentos.DESCRIPCION);
            cmdUpdate.Parameters.AddWithValue("@IDDOCUMENTOACTIVIDAD", myDocumentos.iddocumentoactividad);
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
        /// Gets all the details of a Documentos
        /// <returns>Documentos</returns>
        /// </summary>
        public Documentos GetDocumentosById(int id, int idente)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();
            if (SessionDocumental.UsuarioInicioSession.ROL >= 3)
            {
                cmdSelect.CommandText = "SELECT documentos.IDDOCUMENTOS,documentos.DOCUMENTO,documentos.DESCRIPCION,documentos.CAMINO,linkdoc.IDEXPEDIENTE,linkdoc.IDSERIE,linkdoc.IDSUBSERIE,linkdoc.IDTIPOLOGIA,documentos.FOLIOS,documentos.ANEXOS,documentos.CALIDAD,documentos.IMAGENES,documentos.VERSION FROM documentos,linkdoc WHERE documentos.iddocumentos = linkdoc.iddocumentos and linkdoc.idente = @idente and  documentos.idDOCUMENTOS = @idDOCUMENTOS GROUP BY documentos.IDDOCUMENTOS,documentos.DOCUMENTO,documentos.CAMINO,documentos.IDEXPEDIENTE,documentos.IDSERIE,documentos.IDSUBSERIE,documentos.IDTIPOLOGIA,documentos.FOLIOS,documentos.ANEXOS,documentos.CALIDAD,documentos.IMAGENES,documentos.VERSION";
                cmdSelect.Parameters.AddWithValue("@idDOCUMENTOS", id);
                cmdSelect.Parameters.AddWithValue("@idente", idente);
            }
            else
            {
                cmdSelect.CommandText = "SELECT documentos.IDDOCUMENTOS,documentos.DOCUMENTO,documentos.DESCRIPCION,documentos.CAMINO,linkdoc.IDEXPEDIENTE,linkdoc.IDSERIE,linkdoc.IDSUBSERIE,linkdoc.IDTIPOLOGIA,documentos.FOLIOS,documentos.ANEXOS,documentos.CALIDAD,documentos.IMAGENES,documentos.VERSION FROM documentos,linkdoc WHERE documentos.iddocumentos = linkdoc.iddocumentos  and  documentos.idDOCUMENTOS = @idDOCUMENTOS GROUP BY documentos.IDDOCUMENTOS,documentos.DOCUMENTO,documentos.CAMINO,documentos.IDEXPEDIENTE,documentos.IDSERIE,documentos.IDSUBSERIE,documentos.IDTIPOLOGIA,documentos.FOLIOS,documentos.ANEXOS,documentos.CALIDAD,documentos.IMAGENES,documentos.VERSION";
                cmdSelect.Parameters.AddWithValue("@idDOCUMENTOS", id);

            }

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                Documentos myDocumentos = new Documentos();

                while (dr.Read())
                {

                    #region Params

                    myDocumentos.idDOCUMENTOS = Convert.ToInt32(dr["idDOCUMENTOS"]);
                    myDocumentos.IDSERIE = Convert.ToInt32(dr["IDSERIE"]);
                    myDocumentos.IDSUBSERIE = Convert.ToInt32(dr["IDSUBSERIE"].ToString());
                    myDocumentos.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"].ToString());
                    myDocumentos.DOCUMENTO = dr["DOCUMENTO"].ToString();
                    myDocumentos.DESCRIPCION = dr["DESCRIPCION"].ToString();
                    myDocumentos.CAMINO = dr["CAMINO"].ToString();
                    myDocumentos.IDEXPEDIENTE = Convert.ToInt32(dr["IDEXPEDIENTE"].ToString());
                    myDocumentos.FOLIOS = Convert.ToInt32(dr["FOLIOS"].ToString());
                    myDocumentos.ANEXOS = dr["ANEXOS"].ToString();
                    myDocumentos.VERSION = Convert.ToInt32(dr["VERSION"].ToString());
                    myDocumentos.CALIDAD = Convert.ToInt32(dr["CALIDAD"].ToString());

                    Serie serie1 = new Serie();
                    SubSerie Subserie1 = new SubSerie();
                    Tipologia Tipologia1 = new Tipologia();
                    Expediente Expediente1 = new Expediente();

                    serie1 = new SerieManagement().GetSerieById(Convert.ToInt32(myDocumentos.IDSERIE));
                    Subserie1 = new SubSerieManagement().GetSubSerieById(Convert.ToInt32(myDocumentos.IDSUBSERIE));
                    Tipologia1 = new TipologiaManagement().GetTipologiaById(Convert.ToInt32(myDocumentos.IDTIPOLOGIA));
                    Expediente1 = new ExpedienteManagement().GetExpedienteById(Convert.ToInt32(myDocumentos.IDEXPEDIENTE));
                    myDocumentos.NOMSERIE = serie1.SERIE;
                    myDocumentos.NOMSUBSERIE = Subserie1.SUBSERIE;
                    myDocumentos.NOMTIPOLOGIA = Tipologia1.TIPOLOGIA;
                    myDocumentos.NOMEXPEDIENTE = Expediente1.descripcion;

                    #endregion

                }
                return myDocumentos;
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


        public Documentos GetDocumentosById2(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = "SELECT documentos.IDDOCUMENTOS,documentos.DOCUMENTO,documentos.DESCRIPCION,documentos.CAMINO,documentos.IDEXPEDIENTE,documentos.IDSERIE,documentos.IDSUBSERIE,documentos.IDTIPOLOGIA,documentos.FOLIOS,documentos.ANEXOS,documentos.CALIDAD,documentos.IMAGENES,documentos.VERSION FROM documentos WHERE documentos.idDOCUMENTOS = @idDOCUMENTOS GROUP BY documentos.IDDOCUMENTOS,documentos.DOCUMENTO,documentos.CAMINO,documentos.IDEXPEDIENTE,documentos.IDSERIE,documentos.IDSUBSERIE,documentos.IDTIPOLOGIA,documentos.FOLIOS,documentos.ANEXOS,documentos.CALIDAD,documentos.IMAGENES,documentos.VERSION";
            cmdSelect.Parameters.AddWithValue("@idDOCUMENTOS", id);

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                Documentos myDocumentos = new Documentos();

                while (dr.Read())
                {

                    #region Params

                    myDocumentos.idDOCUMENTOS = Convert.ToInt32(dr["idDOCUMENTOS"]);
                    myDocumentos.IDSERIE = Convert.ToInt32(dr["IDSERIE"]);
                    myDocumentos.IDSUBSERIE = Convert.ToInt32(dr["IDSUBSERIE"].ToString());
                    myDocumentos.IDTIPOLOGIA = Convert.ToInt32(dr["IDTIPOLOGIA"].ToString());
                    myDocumentos.DOCUMENTO = dr["DOCUMENTO"].ToString();
                    myDocumentos.DESCRIPCION = dr["DESCRIPCION"].ToString();
                    myDocumentos.CAMINO = dr["CAMINO"].ToString();
                    myDocumentos.IDEXPEDIENTE = Convert.ToInt32(dr["IDEXPEDIENTE"].ToString());
                    myDocumentos.FOLIOS = Convert.ToInt32(dr["FOLIOS"].ToString());
                    myDocumentos.ANEXOS = dr["ANEXOS"].ToString();
                    myDocumentos.VERSION = Convert.ToInt32(dr["VERSION"].ToString());
                    myDocumentos.CALIDAD = Convert.ToInt32(dr["CALIDAD"].ToString());

                    myDocumentos.serie = new SerieManagement().GetSerieById(myDocumentos.IDSERIE);
                    myDocumentos.subserie = new SubSerieManagement().GetSubSerieById(myDocumentos.IDSUBSERIE);
                    myDocumentos.tipologia = new TipologiaManagement().GetTipologiaById(myDocumentos.IDTIPOLOGIA);
                    myDocumentos.expediente = new ExpedienteManagement().GetExpedienteById(myDocumentos.IDEXPEDIENTE);

                    #endregion

                }
                return myDocumentos;
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
        #region insert
        /// <summary>
        /// Inserts a new  Ente
        /// <param name="myDocumentos">Required a filled instance of Ente</param>
        /// </summary>
        public int InsertDocumentos(Documentos myDocumentos)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "INSERT INTO Documentos (IDSERIE,IDSUBSERIE,IDTIPOLOGIA,DOCUMENTO,CAMINO,IDEXPEDIENTE, FOLIOS, ANEXOS,IDENTE,VERSION,CALIDAD,DESCRIPCION,LOCAL,iddocumentoactividad) VALUES (@IDSERIE,@IDSUBSERIE,@IDTIPOLOGIA,@DOCUMENTO,@CAMINO,@IDEXPEDIENTE, @FOLIOS, @ANEXOS,@IDENTE,@VERSION,@CALIDAD,@DESCRIPCION,@LOCAL,@IDDOCUMENTOACTIVIDAD) ;SELECT LAST_INSERT_ID()";

            //myDocumentos.iddocumentoactividad = Convert.ToInt32(dr["iddocumentoactividad"]);

            string url = HttpContext.Current.Request.Url.AbsoluteUri;

            if (url.ToUpper().Contains("LOCALHOST"))
            {

                myDocumentos.LOCAL = 1;
            }
            else
            {

                myDocumentos.LOCAL = 0;
            }
            #region params

            cmdInsert.Parameters.AddWithValue("@IDSERIE", myDocumentos.IDSERIE);
            cmdInsert.Parameters.AddWithValue("@IDSUBSERIE", myDocumentos.IDSUBSERIE);
            cmdInsert.Parameters.AddWithValue("@IDTIPOLOGIA", myDocumentos.IDTIPOLOGIA);
            cmdInsert.Parameters.AddWithValue("@DOCUMENTO", myDocumentos.DOCUMENTO);
            cmdInsert.Parameters.AddWithValue("@DESCRIPCION", myDocumentos.DESCRIPCION);
            cmdInsert.Parameters.AddWithValue("@CAMINO", myDocumentos.CAMINO);
            cmdInsert.Parameters.AddWithValue("@IDEXPEDIENTE", myDocumentos.IDEXPEDIENTE);
            cmdInsert.Parameters.AddWithValue("@FOLIOS", myDocumentos.FOLIOS);
            cmdInsert.Parameters.AddWithValue("@ANEXOS", myDocumentos.ANEXOS);
            cmdInsert.Parameters.AddWithValue("@IDENTE", myDocumentos.IDENTE);
            cmdInsert.Parameters.AddWithValue("@VERSION", myDocumentos.VERSION);
            cmdInsert.Parameters.AddWithValue("@CALIDAD", myDocumentos.CALIDAD);
            cmdInsert.Parameters.AddWithValue("@LOCAL", myDocumentos.LOCAL);
            cmdInsert.Parameters.AddWithValue("@IDDOCUMENTOACTIVIDAD",Convert.ToInt32(myDocumentos.iddocumentoactividad));
            
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


        public int InsertDocumentosLocal(Documentos myDocumentos)
        {
            MySqlCommand cmdInsert = ConnectionLocal.CreateCommand();

            cmdInsert.CommandText = "INSERT INTO Documentos (IDSERIE,IDSUBSERIE,IDTIPOLOGIA,DOCUMENTO,CAMINO,IDEXPEDIENTE, FOLIOS, ANEXOS,IDENTE,VERSION,CALIDAD,DESCRIPCION,iddocumentoactividad) VALUES (@IDSERIE,@IDSUBSERIE,@IDTIPOLOGIA,@DOCUMENTO,@CAMINO,@IDEXPEDIENTE, @FOLIOS, @ANEXOS,@IDENTE,@VERSION,@CALIDAD,@DESCRIPCION,@IDDOCUMENTOACTIVIDAD) ;SELECT LAST_INSERT_ID()";


            string url = HttpContext.Current.Request.Url.AbsoluteUri;

            if (url.ToUpper().Contains("LOCALHOST"))
            {

                myDocumentos.LOCAL = 1;
            }
            else
            {

                myDocumentos.LOCAL = 0;
            }
            #region params

            cmdInsert.Parameters.AddWithValue("@IDSERIE", myDocumentos.IDSERIE);
            cmdInsert.Parameters.AddWithValue("@IDSUBSERIE", myDocumentos.IDSUBSERIE);
            cmdInsert.Parameters.AddWithValue("@IDTIPOLOGIA", myDocumentos.IDTIPOLOGIA);
            cmdInsert.Parameters.AddWithValue("@DOCUMENTO", myDocumentos.DOCUMENTO);
            cmdInsert.Parameters.AddWithValue("@DESCRIPCION", myDocumentos.DESCRIPCION);
            cmdInsert.Parameters.AddWithValue("@CAMINO", myDocumentos.CAMINO);
            cmdInsert.Parameters.AddWithValue("@IDEXPEDIENTE", myDocumentos.IDEXPEDIENTE);
            cmdInsert.Parameters.AddWithValue("@FOLIOS", myDocumentos.FOLIOS);
            cmdInsert.Parameters.AddWithValue("@ANEXOS", myDocumentos.ANEXOS);
            cmdInsert.Parameters.AddWithValue("@IDENTE", myDocumentos.IDENTE);
            cmdInsert.Parameters.AddWithValue("@VERSION", myDocumentos.VERSION);
            cmdInsert.Parameters.AddWithValue("@CALIDAD", myDocumentos.CALIDAD);
            cmdInsert.Parameters.AddWithValue("@LOCAL", myDocumentos.CALIDAD);
            cmdInsert.Parameters.AddWithValue("@IDDOCUMENTOACTIVIDAD", myDocumentos.iddocumentoactividad);
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

        #region DELETE Commands
        /// <summary>
        /// Delete Documento
        /// <param name="id">Required a filled instance of Documento</param>
        /// </summary>
        public bool DeleteDocumentos(int id)
        {
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = "DELETE FROM documentos WHERE idDOCUMENTOS=@idDOCUMENTOS";

            #region params

            cmdInsert.Parameters.AddWithValue("@idDOCUMENTOS", id);

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