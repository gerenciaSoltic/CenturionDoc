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
    public class RadicadosManagement : ConnectionClass
    {
        public static string lcRadicado;
        #region Sql
        private string DefaultSelect =
                @"SELECT 
                    c.idradicados,
                    c.conseInt,
                    c.ConseExtSal,
                    c.ConseExtent,
                    c.prefInter,
                    c.PrefExtSal,
                    c.PrefExtEnt,
                    c.UltimaFecha
                    FROM radicados as c ";

        #endregion

        #region Constructors
        public RadicadosManagement()
        {

        }
        #endregion

       #region SELECT Commands

        /// <summary>
        /// Gets the whole list of Radicados
        /// <returns>List of Type Radicados</returns>
        /// </summary>
        public List<Radicados> GetAllRadicados()
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = this.DefaultSelect;

            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                List<Radicados> allEntes = new List<Radicados>();

                while (dr.Read())
                {
                    Radicados myEnte = new Radicados();

                    #region Params

                    myEnte.idradicados = Convert.ToInt32(dr["idradicados"]);
                    myEnte.conseInt = Convert.ToInt32(dr["conseInt"].ToString());
                    myEnte.ConseExtSal = Convert.ToInt32(dr["ConseExtSal"].ToString());
                    myEnte.ConseExtent = Convert.ToInt32(dr["ConseExtent"].ToString());
                    myEnte.prefInter = dr["prefInter"].ToString();
                    myEnte.PrefExtSal = dr["PrefExtSal"].ToString();
                    myEnte.PrefExtEnt = dr["PrefExtEnt"].ToString();
                    myEnte.UltimaFecha = Convert.ToDateTime(dr["UltimaFecha"].ToString());

                    myEnte.ConseCorrSal = Convert.ToInt32(dr["ConseCorrSal"].ToString());
                    myEnte.ConseCorrEnt = Convert.ToInt32(dr["ConseCorrent"].ToString());

                    myEnte.PrefCorrSal = dr["PrefCorrSal"].ToString();
                    myEnte.PrefCorrEnt = dr["PrefCorrEnt"].ToString();

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
        /// Gets all the details of a Radicados
        /// <returns>Radicados</returns>
        /// </summary>
        public Radicados GetRadicadosById(int id)
        {
            MySqlCommand cmdSelect = Connection.CreateCommand();

            cmdSelect.CommandText = DefaultSelect + " WHERE c.idradicados = @idradicados ";
            cmdSelect.Parameters.AddWithValue("@idradicados", id);
            try
            {
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                Radicados myEnte = new Radicados();

                while (dr.Read())
                {

                    #region Params

                    myEnte.idradicados = Convert.ToInt32(dr["idradicados"]);
                    myEnte.conseInt = Convert.ToInt32(dr["conseInt"].ToString());
                    myEnte.ConseExtSal = Convert.ToInt32(dr["ConseExtSal"].ToString());
                    myEnte.ConseExtent = Convert.ToInt32(dr["ConseExtent"].ToString());
                    myEnte.prefInter = dr["prefInter"].ToString();
                    myEnte.PrefExtSal = dr["PrefExtSal"].ToString();
                    myEnte.PrefExtEnt = dr["PrefExtEnt"].ToString();
                    myEnte.UltimaFecha = Convert.ToDateTime(dr["UltimaFecha"].ToString());

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
        /// <summary>
        /// Gets all the details of a Radicados
        /// <returns>Radicados</returns>
        /// </summary>
        public Radicados GetRadicadoActual(EmiRecep de, EmiRecep para, Boolean lcorreo)
        {
            try
            {
                Radicados radi = this.GetRadicadosById(para.IDRADICADO);
                
                DateTime hoy = DateTime.Now;

                string prefijo = "";
                int consec = 1;
                string radicado = "";
                string radicadoComplet = "";

                    
                
                if (hoy.ToString("yyyy") == radi.UltimaFecha.ToString("yyyy"))
                {
                    if (de.IDTIPOEMISOR == 3 || de.IDTIPOEMISOR == 5)
                    {
                        if (!lcorreo)
                        {
                            radi.ConseExtent++;
                            consec = radi.ConseExtent;
                            prefijo = radi.PrefExtEnt.Trim();
                        }
                        else
                        {

                            radi.ConseCorrEnt++;
                            consec = radi.ConseCorrEnt;
                            prefijo = radi.PrefCorrEnt.Trim();
                        }
                    }
                    if (para.IDTIPOEMISOR == 3 || para.IDTIPOEMISOR == 5)
                    {
                        if (!lcorreo)
                        {
                            radi.ConseExtSal++;
                            consec = radi.ConseExtSal;
                            prefijo = radi.PrefExtSal.Trim();
                        }
                        else
                        {
                            radi.ConseCorrSal++;
                            consec = radi.ConseCorrSal;
                            prefijo = radi.PrefCorrSal.Trim();

                        }

                    }
                    if (de.IDTIPOEMISOR != 3 && para.IDTIPOEMISOR != 3 && de.IDTIPOEMISOR != 5 && para.IDTIPOEMISOR != 5)
                    { 
                        radi.conseInt++;
                        consec = radi.conseInt;
                        prefijo = radi.prefInter.Trim();
                    }

                }
                else {
                    radi.conseInt = 0;
                    radi.ConseExtSal = 0;
                    radi.ConseExtent = 0;
                    
                    radi.UltimaFecha = hoy;
                    consec = 1;

                    if (de.IDTIPOEMISOR == 3 || de.IDTIPOEMISOR == 5)
                    {
                        if (!lcorreo)
                        {

                            prefijo = radi.PrefExtEnt.Trim();
                            radi.ConseExtent++;
                        }
                        else
                        {
                            prefijo = radi.PrefCorrEnt.Trim();
                            radi.ConseCorrEnt++;
                        }

                    }
                    if (para.IDTIPOEMISOR == 3 || para.IDTIPOEMISOR == 5)
                    {
                        if (!lcorreo)
                        {
                            prefijo = radi.PrefExtSal.Trim();
                            radi.ConseExtSal++;
                        }
                        else
                        {
                            prefijo = radi.PrefCorrSal.Trim();
                            radi.ConseCorrSal++;
                        

                        }

                    }
                    if (de.IDTIPOEMISOR != 3 && para.IDTIPOEMISOR != 3 && de.IDTIPOEMISOR != 5 && para.IDTIPOEMISOR != 5)
                    {
                        radi.conseInt++;
                        prefijo = radi.prefInter.Trim();
                    }
                    radicadoComplet = prefijo + hoy.ToString("yyyyMMdd") + "0001";
                    //this.UpdateRadicados(myEnte);
                    radi.Radicado = radicadoComplet;
                    return radi;
                }

                
                
                if (consec < 10)
                {
                    radicado += "000" + consec;
                }
                else if (consec < 100)
                {
                    radicado += "00" + consec;
                }
                else if (consec < 1000)
                {
                    radicado += "0" + consec;
                }
                else
                {
                    radicado = Convert.ToString(consec);
                }

                radicadoComplet = prefijo + hoy.ToString("yyyy")+ radicado;
                radi.Radicado = radicadoComplet;
                //this.UpdateRadicados(myEnte);
                return radi;
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


        public Radicados GetRadicadoExterno(EmiRecep de, Boolean lcorreo)
        {
            try
            {
                Radicados radi = this.GetRadicadosById(de.IDRADICADO);

                DateTime hoy = DateTime.Now;

                string prefijo = "";
                int consec = 1;
                string radicado = "";
                string radicadoComplet = "";



                if (hoy.ToString("yyyy") == radi.UltimaFecha.ToString("yyyy"))
                {
                        radi.ConseCorrEnt++;
                        consec = radi.ConseCorrEnt;
                        prefijo = radi.PrefCorrEnt.Trim();
                 }
                else
                {
                    radi.conseInt = 0;
                    radi.ConseCorrSal = 0;
                    radi.ConseCorrEnt = 0;

                    radi.UltimaFecha = hoy;
                    consec = 1;

                    
                        prefijo = radi.PrefCorrEnt.Trim();
                        radi.ConseCorrEnt++;
                    
                    radicadoComplet = prefijo + hoy.ToString("yyyyMMdd") + "0001";
                    //this.UpdateRadicados(myEnte);
                    radi.Radicado = radicadoComplet;
                    return radi;
                }



                if (consec < 10)
                {
                    radicado += "000" + consec;
                }
                else if (consec < 100)
                {
                    radicado += "00" + consec;
                }
                else if (consec < 1000)
                {
                    radicado += "0" + consec;
                }
                else
                {
                    radicado = Convert.ToString(consec);
                }

                radicadoComplet = prefijo + hoy.ToString("yyyy") + radicado;
                radi.Radicado = radicadoComplet;
                //this.UpdateRadicados(myEnte);
                return radi;
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


        public Radicados GetRadicadoExternoSalida(EmiRecep de)
        {
            try
            {
                Radicados radi = this.GetRadicadosById(de.IDRADICADO);

                DateTime hoy = DateTime.Now;

                string prefijo = "";
                int consec = 1;
                string radicado = "";
                string radicadoComplet = "";



                if (hoy.ToString("yyyy") == radi.UltimaFecha.ToString("yyyy"))
                {
                    radi.ConseExtSal++;
                    consec = radi.ConseExtSal;
                    prefijo = radi.PrefExtSal.Trim();
                }
                else
                {
                    radi.conseInt = 0;
                    radi.ConseExtSal = 0;
                    radi.ConseExtent = 0;

                    radi.UltimaFecha = hoy;
                    consec = 1;


                    prefijo = radi.PrefExtSal.Trim();
                    radi.ConseExtSal++;

                    radicadoComplet = prefijo + hoy.ToString("yyyyMMdd") + "0001";
                    //this.UpdateRadicados(myEnte);
                    radi.Radicado = radicadoComplet;
                    return radi;
                }



                if (consec < 10)
                {
                    radicado += "000" + consec;
                }
                else if (consec < 100)
                {
                    radicado += "00" + consec;
                }
                else if (consec < 1000)
                {
                    radicado += "0" + consec;
                }
                else
                {
                    radicado = Convert.ToString(consec);
                }

                radicadoComplet = prefijo + hoy.ToString("yyyy") + radicado;
                radi.Radicado = radicadoComplet;
                //this.UpdateRadicados(myEnte);
                return radi;
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

       

        public List<Radicado> GetRadicado()
        {   
            MySqlCommand cmdSelect = Connection.CreateCommand();

                cmdSelect.CommandText ="SELECT * FROM workflow WHERE radicado= @idradicados group by radicado";
                cmdSelect.Parameters.AddWithValue("@idradicados", lcRadicado);
            try
            {
                
          
                if (this.Connection.State == ConnectionState.Closed)
                    this.Connection.Open();

                MySqlDataReader dr = cmdSelect.ExecuteReader(CommandBehavior.CloseConnection);
                Radicado ObjRadicado = new Radicado();
                List<Radicado> Allradicado = new List<Radicado>();
                while (dr.Read())
                {

                    #region Params
                    string lcIdenteDestino = new DataAccessLayer.EnteManagement().GetEnteById(Convert.ToInt32(dr["idEnteDestino"])).DESCRIPCION;
                    string lcIdemirecepDestino = new DataAccessLayer.EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(dr["idemidestino"])).DESCRIPCION;
                    string lcIdente = new DataAccessLayer.EnteManagement().GetEnteById(Convert.ToInt32(dr["idEnteorigen"])).DESCRIPCION;
                    string lcIdemirecep = new DataAccessLayer.EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(dr["idemirecep"])).DESCRIPCION;

                    ObjRadicado.RADICADO = dr["radicado"].ToString();
                    ObjRadicado.FECHAHORA = dr["fecha"].ToString();
                    ObjRadicado.ANEXOS = new DataAccessLayer.DocumentosManagement().GetDocumentosById(Convert.ToInt32(dr["iddocumento"]), Convert.ToInt32(dr["identeorigen"])).ANEXOS;
                    ObjRadicado.DESTINATARIO = lcIdenteDestino + " - " + lcIdemirecepDestino;
                    ObjRadicado.REMITE = lcIdente + " - " + lcIdemirecep;
                    ObjRadicado.FOLIOS = new DataAccessLayer.DocumentosManagement().GetDocumentosById(Convert.ToInt32(dr["iddocumento"]), Convert.ToInt32(dr["identeorigen"])).FOLIOS.ToString();

                    Allradicado.Add(ObjRadicado);
                    #endregion

                }
                return Allradicado;
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
        /// Inserts a new  Radicados
        /// <param name="myEnte">Required a filled instance of Radicados</param>
        /// </summary>
        public void InsertRadicados(Radicados myEnte)
        {
            string sql = @"
            INSERT INTO radicados (conseInt,ConseExtSal,ConseExtent,prefInter,PrefExtSal,PrefExtEnt,UltimaFecha) VALUES 
            (@conseInt,@ConseExtSal,@ConseExtent,@prefInter,@PrefExtSal,@PrefExtEnt,@UltimaFecha)";

            //===============================================CONEXION REMOTA========================================
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = sql;

            #region params
            //radicados idradicados,conseInt,ConseExtSal,ConseExtent,prefInter,PrefExtSal,PrefExtEnt,UltimaFecha
            cmdInsert.Parameters.AddWithValue("@conseInt", myEnte.conseInt);
            cmdInsert.Parameters.AddWithValue("@ConseExtSal", myEnte.ConseExtSal);
            cmdInsert.Parameters.AddWithValue("@ConseExtent", myEnte.ConseExtent);
            cmdInsert.Parameters.AddWithValue("@prefInter", myEnte.prefInter);
            cmdInsert.Parameters.AddWithValue("@PrefExtSal", myEnte.PrefExtSal);
            cmdInsert.Parameters.AddWithValue("@PrefExtEnt", myEnte.PrefExtEnt);
            cmdInsert.Parameters.AddWithValue("@UltimaFecha", myEnte.UltimaFecha);

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

            ////================================================CONEXION LOCAL======================================
            MySqlCommand cmdInsertLocal = ConnectionLocal.CreateCommand();

            cmdInsertLocal.CommandText = sql;

            #region params
            //radicados idradicados,conseInt,ConseExtSal,ConseExtent,prefInter,PrefExtSal,PrefExtEnt,UltimaFecha
            cmdInsertLocal.Parameters.AddWithValue("@conseInt", myEnte.conseInt);
            cmdInsertLocal.Parameters.AddWithValue("@ConseExtSal", myEnte.ConseExtSal);
            cmdInsertLocal.Parameters.AddWithValue("@ConseExtent", myEnte.ConseExtent);
            cmdInsertLocal.Parameters.AddWithValue("@prefInter", myEnte.prefInter);
            cmdInsertLocal.Parameters.AddWithValue("@PrefExtSal", myEnte.PrefExtSal);
            cmdInsertLocal.Parameters.AddWithValue("@PrefExtEnt", myEnte.PrefExtEnt);
            cmdInsertLocal.Parameters.AddWithValue("@UltimaFecha", myEnte.UltimaFecha);

            #endregion

            try
            {
                if (this.ConnectionLocal.State == ConnectionState.Closed)
                    this.ConnectionLocal.Open();

                cmdInsertLocal.ExecuteNonQuery();
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
        }
        #endregion

        #region UPDATE Commands

        public void UpdateRadicados(Radicados myEnte)
        {
            string sql = @"Update Radicados SET  
                    conseInt=@conseInt,
                    ConseExtSal=@ConseExtSal,
                    ConseExtent=@ConseExtent,
                    prefInter=@prefInter,
                    PrefExtSal=@PrefExtSal,
                    PrefExtEnt=@PrefExtEnt,
                    UltimaFecha=@UltimaFecha
                    where idradicados=@idradicados";

            //===============================================CONEXION REMOTA========================================

            MySqlCommand cmdUpdate = Connection.CreateCommand();

            cmdUpdate.CommandText = sql;

            #region params

            cmdUpdate.Parameters.AddWithValue("@idradicados", myEnte.idradicados);

            cmdUpdate.Parameters.AddWithValue("@conseInt", myEnte.conseInt);
            cmdUpdate.Parameters.AddWithValue("@ConseExtSal", myEnte.ConseExtSal);
            cmdUpdate.Parameters.AddWithValue("@ConseExtent", myEnte.ConseExtent);
            cmdUpdate.Parameters.AddWithValue("@prefInter", myEnte.prefInter);
            cmdUpdate.Parameters.AddWithValue("@PrefExtSal", myEnte.PrefExtSal);
            cmdUpdate.Parameters.AddWithValue("@PrefExtEnt", myEnte.PrefExtEnt);
            cmdUpdate.Parameters.AddWithValue("@UltimaFecha", myEnte.UltimaFecha);

            #endregion
            //MySqlTransaction tr;
            try
            {
            if (this.Connection.State == ConnectionState.Closed)
                this.Connection.Open();
                MySqlTransaction tr = this.Connection.BeginTransaction();
            

           
                cmdUpdate.ExecuteNonQuery();
                tr.Commit();

            }
            catch (MySqlException ex)
            {
                MySqlTransaction tr = this.Connection.BeginTransaction();
                tr.Rollback();
                throw ex;
            }
            finally
            {

                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }

            ////================================================CONEXION LOCAL======================================

            MySqlCommand cmdUpdateLocal = ConnectionLocal.CreateCommand();

            cmdUpdateLocal.CommandText = sql;

            try
            {
            #region params

            cmdUpdateLocal.Parameters.AddWithValue("@idradicados", myEnte.idradicados);
            cmdUpdateLocal.Parameters.AddWithValue("@conseInt", myEnte.conseInt);
            cmdUpdateLocal.Parameters.AddWithValue("@ConseExtSal", myEnte.ConseExtSal);
            cmdUpdateLocal.Parameters.AddWithValue("@ConseExtent", myEnte.ConseExtent);
            cmdUpdateLocal.Parameters.AddWithValue("@prefInter", myEnte.prefInter);
            cmdUpdateLocal.Parameters.AddWithValue("@PrefExtSal", myEnte.PrefExtSal);
            cmdUpdateLocal.Parameters.AddWithValue("@PrefExtEnt", myEnte.PrefExtEnt);
            cmdUpdateLocal.Parameters.AddWithValue("@UltimaFecha", myEnte.UltimaFecha);

            #endregion
            if (this.ConnectionLocal.State == ConnectionState.Closed)
                this.ConnectionLocal.Open();

            MySqlTransaction trLocal = this.ConnectionLocal.BeginTransaction();

                cmdUpdateLocal.ExecuteNonQuery();
                trLocal.Commit();

            }
            catch (MySqlException ex)
            {
                 //MySqlTransaction trLocal = this.ConnectionLocal.BeginTransaction();
                //trLocal.Rollback();
                //throw ex;
            }
            finally
            {

                if (ConnectionLocal.State == ConnectionState.Open)
                    ConnectionLocal.Close();
            }
        }

        #endregion

        #region DELETE Commands
        /// <summary>
        /// Delete Radicados
        /// <param name="id">Required a filled instance of Radicados</param>
        /// </summary>
        public bool DeleteRadicados(int id)
        {
            string sql = "DELETE FROM radicados WHERE idradicados=@idradicados";

            //===============================================CONEXION REMOTA========================================
            MySqlCommand cmdInsert = Connection.CreateCommand();

            cmdInsert.CommandText = sql;

            #region params

            cmdInsert.Parameters.AddWithValue("@idradicados", id);

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


            ////================================================CONEXION LOCAL======================================
            MySqlCommand cmdInsertLocal = ConnectionLocal.CreateCommand();

            cmdInsertLocal.CommandText = sql;

            #region params

            cmdInsertLocal.Parameters.AddWithValue("@idradicados", id);

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