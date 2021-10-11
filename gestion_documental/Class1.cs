using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using gestion_documental.Utils;


    public class Class1
    {


        ConnectionClass conectar = new ConnectionClass();
        MySqlCommand comando;
        MySqlDataAdapter adaptador;

       
        int idd; string errorff;


        public void insertar(string tabla, string valores)
        {


           conectar.Connection.Close();
           conectar.conectar();

           conectar.Connection.Open();
           comando = new MySqlCommand("Insert Into " + tabla + " Values(" + valores + ")", conectar.Connection);
            //MessageBox.Show(comando.CommandText);
            comando.ExecuteNonQuery();
            idd = Convert.ToInt32(comando.LastInsertedId);
            conectar.Connection.Close();


        }


        public int EjecutaSql(string consulta)
        {
           conectar.conectar();

            try
            {
                conectar.Connection.Close();
                conectar.conectar();
                conectar.Connection.Open();
                comando = new MySqlCommand(consulta, conectar.Connection);
                //MessageBox.Show(comando.CommandText);
                comando.ExecuteNonQuery();
                idd = Convert.ToInt32(comando.LastInsertedId);
                conectar.Connection.Close();
                return idd;
            }
            catch (Exception ex)
            {
                errorff = ex.Message;
                errorff = errorff.Replace("'", "");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('El centro de costo  no existe ..oprima el boton de busqueda');", true);
                //MessageBox.Show("No se pudo realizar la insercion por el siguiente motivo: " + ex.Message);
                return 0;
            }

        }



        public int insertaralgunos(string tabla, string campos, string valores)
        {
            //conectar();




            conectar.conectar();
            conectar.Connection.Open();
            //MessageBox.Show(comando.CommandText);
            comando = new MySqlCommand("Insert Into " + tabla + "(" + campos + ") Values(" + valores + ")", conectar.Connection);
            comando.ExecuteNonQuery();
            idd = Convert.ToInt32(comando.LastInsertedId);
            conectar.Connection.Close();
            return idd;


        }


        public void editar(string tabla, string valores, string condicion)
        {


            conectar.Connection.Close();
            conectar.conectar();
            conectar.Connection.Open();
            comando = new MySqlCommand("Update " + tabla + " Set " + valores + " Where " + condicion, conectar.Connection);
            // MessageBox.Show(comando.CommandText);
            idd = comando.ExecuteNonQuery();

            conectar.Connection.Close();

        }
        public void eliminar(string tabla, string condicion)
        {

            try
            {
                conectar.Connection.Close();
                conectar.conectar();
                conectar.Connection.Open();
                comando = new MySqlCommand("Delete From " + tabla + " Where " + condicion, conectar.Connection);
                idd = comando.ExecuteNonQuery();

                conectar.Connection.Close();
            }
            catch (Exception ex)
            {
                errorff = ex.Message;
                errorff = errorff.Replace("'", "");

                MessageBox.Show("No se pudo realizar la eliminacion por el siguiente motivo: " + ex.Message);
                conectar.Connection.Close();
            }
        }
        public void consultacamposcondicion(string tabla, string campos, string condicion, DataTable data)
        {
            data.Clear();

            conectar.conectar();

            adaptador = new MySqlDataAdapter("Select " + campos + " From " + tabla + " Where " + condicion, conectar.Connection);
            adaptador.Fill(data);

        }

        public string consultauncampo(string tabla, string campos, ref string variable)
        {
            conectar.conectar();

            MySqlCommand command = new MySqlCommand("Select " + campos + " From " + tabla, conectar.Connection);
            conectar.Connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                variable = reader.GetString(0);
            }
            reader.Close();
            conectar.Connection.Close();
            return variable;

        }

        public string consultauncampocondicion(string tabla, string campos, string condicion, ref string variable)
        {
            conectar.conectar();

            MySqlCommand command = new MySqlCommand("Select " + campos + " From " + tabla + " Where " + condicion, conectar.Connection);
            conectar.Connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                variable = reader.GetString(0);
            }
            reader.Close();
            conectar.Connection.Close();
            return variable;

        }

        public DataTable llenardatos(DataTable data, string condicion, int idente)
        {
            conectar.conectar();
            adaptador = new MySqlDataAdapter("SELECT d.IDDOCUMENTOS,d.DOCUMENTO,d.DESCRIPCION,d.CAMINO,l.IDEXPEDIENTE,l.IDSERIE,l.IDSUBSERIE,l.IDTIPOLOGIA,d.FOLIOS,d.ANEXOS,d.CALIDAD,d.IMAGENES,d.VERSION FROM indices i join documentos d on i.iddocumento=d.iddocumentos join linkdoc l on i.iddocumento=d.iddocumentos WHERE  (" + condicion + ") and l.idente=" + idente.ToString() + "", conectar.Connection);
            adaptador.Fill(data);
            return data;
        }
        public void eliminarcolomnasdatatable(List<string> campos, ref DataTable data)
        {
            for (int i = 0; i < campos.Count; i++)
            {
                DataColumnCollection columns = data.Columns;

                if (columns.Contains(campos[i]))
                {
                    if (columns.CanRemove(columns[campos[i]]))
                    {
                        columns.Remove(campos[i]);
                    }
                }
            }

        }

        public void consultacampos(string tabla, string campos, DataTable data)
        {
            data.Clear();
            try
            {
                conectar.conectar();
                adaptador = new MySqlDataAdapter("Select " + campos + " From " + tabla, conectar.Connection);
                adaptador.Fill(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ConsultaSql(string sql, DataTable data)
        {
            data.Clear();
            try
            {
                conectar.conectar();
                adaptador = new MySqlDataAdapter(sql, conectar.Connection);
                adaptador.Fill(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void procesararchivocatastro(string direccion)
        {
            try
            {
                StreamReader st = new StreamReader(direccion);
                string dpto, muni, año, predio, tiporeg, numord, total, nombre, estado, tipodoc, nrodoc, direcc, comuna, destino, areat, areac, avaluo, espacios, vigencia, id, valor1, valor2, valor3, valorl1, valorl2, valorl3;
                string linea = "";
                while (linea != null)
                {
                    linea = st.ReadLine();
                    dpto = linea.Substring(0, 2);
                    muni = linea.Substring(2, 3);
                    predio = linea.Substring(5, 15);
                    tiporeg = linea.Substring(20, 1);
                    numord = linea.Substring(21, 3);
                    total = linea.Substring(24, 3);
                    nombre = linea.Substring(27, 33);
                    estado = linea.Substring(60, 1);
                    tipodoc = linea.Substring(61, 1);
                    nrodoc = linea.Substring(62, 12);
                    direcc = linea.Substring(74, 34);
                    comuna = linea.Substring(108, 1);
                    destino = linea.Substring(109, 1);
                    areat = linea.Substring(110, 12);
                    areac = linea.Substring(122, 6);
                    avaluo = linea.Substring(128, 12);
                    espacios = linea.Substring(140, 1);
                    año = linea.Substring(145, 4);
                    vigencia = linea.Substring(141, 8);
                    DataTable data = new DataTable();
                    DataTable data1 = new DataTable();
                    consultacamposcondicion("predios", "id", "predio='" + predio + "'", data1);
                    if (data1.Rows.Count > 0)
                    {
                        id = data1.Rows[0]["id"].ToString();
                        valor1 = "dpto='" + dpto + "',muni='" + muni + "',tiporeg='" + tiporeg + "',direcc='" + direcc + "',comuna='" + comuna + "',destino='" + destino + "',areat='" + areat + "',areac='" + areac + "',espacios='" + espacios + "',vigencia='" + vigencia + "'";
                        editar("predios", valor1, "id=" + id);
                    }
                    else
                    {
                        valor1 = "'" + dpto + "','" + muni + "','" + predio + "','" + tiporeg + "','" + direcc + "','" + comuna + "','" + destino + "','" + areat + "','" + areac + "','" + espacios + "','" + vigencia + "'";
                        insertar("predios (dpto,muni,predio,tiporeg,direcc,comuna,destino,areat,areac,espacios,vigencia)", valor1);

                        valorl1 = "null,'" + convertirfechamysql(DateTime.Today) + "',curdate(),'Por ahora: Diego Alcaraz','Ninguna','subirarchivo-predios-insertar'," + idd + ",'Correcto'";
                        insertar("archivolog", valorl1);

                        consultacamposcondicion("predios", "id", "id=(Select Max(id) From predios)", data);
                        id = data.Rows[0]["id"].ToString();
                        valor2 = "'" + predio + "','" + numord + "'," + total + ",'" + nombre + "','" + estado + "','" + tipodoc + "','" + nrodoc + "','" + id + "'";
                        insertar("propietariop (predio,numord,total,nombre,estado,tipodoc,nrodoc,idcontribu)", valor2);

                        valorl2 = "null,'" + convertirfechamysql(DateTime.Today) + "',curdate(),'Por ahora: Diego Alcaraz','Ninguna','subirarchivo-propietariop-insertar'," + idd + ",'Correcto'";
                        insertar("archivolog", valorl2);

                        valor3 = "'" + predio + "','" + año + "'," + avaluo + ",'" + id + "'";
                        insertar("avaluo (predio,anno,avaluo,idcontribu)", valor3);

                        valorl3 = "null,'" + convertirfechamysql(DateTime.Today) + "',curdate(),'Por ahora: Diego Alcaraz','Ninguna','subirarchivo-avaluo-insertar'," + idd + ",'Correcto'";
                        insertar("archivolog", valorl3);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                errorff = ex.Message;
                errorff = errorff.Replace("'", "");
                string valorerror = "null,'" + convertirfechamysql(DateTime.Today) + "',curdate(),'Por ahora: Diego Alcaraz','Ninguna','subirarchivo-error-insertar'," + idd + ",'" + errorff + "'";
                insertar("archivolog", valorerror);
            }
        }
        string convertirfechamysql(DateTime fecha)
        {
            string textofecha = fecha.Year + "-" + fecha.Month + "-" + fecha.Day;
            return textofecha;
        }
        public int propiedadidd
        {
            get { return idd; }
        }
        public string errorproceso
        {
            get { return errorff; }
        }

        public void Mayorizar(int idInstitucion, string Cuenta, double ValDebito, double ValCredito, string signo, DateTime Fecha, int tipo, DataTable data, string Nit, string codcentro)
        {


            // Definimos los campos a totalizar
            string lcCodcc = codcentro;

            string lcSartaCampos = "'" + Fecha.Year.ToString() + "',";

            insertacampostotmovi(idInstitucion, Cuenta, ValDebito, ValCredito, signo, tipo, Fecha, data, Nit, lcCodcc);

            // Buscamos el centro de costo de la cuenta
            int lnCuentaTotal = Cuenta.Trim().Length;


            if (lnCuentaTotal > 6)
            {
                lnCuentaTotal = lnCuentaTotal - 3;
            }






            string lcCuentanueva = "";
            //Matoyizamos totmovi

            if (lnCuentaTotal > 6)
            {
                for (int lnCuenta = Cuenta.Trim().Length - 3; lnCuenta >= 9; lnCuenta = lnCuenta - 3)
                {
                    lcCuentanueva = Cuenta.Substring(0, lnCuenta);
                    insertacampostotmovi(idInstitucion, lcCuentanueva, ValDebito, ValCredito, signo, tipo, Fecha, data, Nit, lcCodcc);

                }

            }
            if (Cuenta.Length > 6)
            {
                lcCuentanueva = Cuenta.Substring(0, 6);
                insertacampostotmovi(idInstitucion, lcCuentanueva, ValDebito, ValCredito, signo, tipo, Fecha, data, Nit, lcCodcc);
            }
            if (Cuenta.Length > 4)
            {
                lcCuentanueva = Cuenta.Substring(0, 4);
                insertacampostotmovi(idInstitucion, lcCuentanueva, ValDebito, ValCredito, signo, tipo, Fecha, data, Nit, lcCodcc);
            }
            lcCuentanueva = Cuenta.Substring(0, 2);
            insertacampostotmovi(idInstitucion, lcCuentanueva, ValDebito, ValCredito, signo, tipo, Fecha, data, Nit, lcCodcc);

            lcCuentanueva = Cuenta.Substring(0, 1);
            insertacampostotmovi(idInstitucion, lcCuentanueva, ValDebito, ValCredito, signo, tipo, Fecha, data, Nit, lcCodcc);



        }


        private void insertacampostotmovi(int idInstitucion, string HCuenta, double ValDebito, double ValCredito, string signo, int tipo, DateTime Fecha, DataTable data, string tcNit, string tcCodcc)
        {
            string lcSartaCampos = "'" + HCuenta + "','" + Fecha.Year.ToString() + "',";
            string lcSartaCampos1 = "";

            string lcValDebito = reformateaIns(ValDebito.ToString());
            string lcValCredito = reformateaIns(ValCredito.ToString());

            string lcMes = "";
            switch (tipo)
            {
                case 0:
                    switch (Fecha.Month)
                    {
                        case 1:
                            lcMes = "ENE";
                            lcSartaCampos1 = "0,0," + lcValDebito + "," + lcValCredito + ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
                            break;

                        case 2:
                            lcMes = "FEB";
                            lcSartaCampos1 = "0,0,0,0," + lcValDebito + "," + lcValCredito + ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
                            break;

                        case 3:
                            lcMes = "MAR";
                            lcSartaCampos1 = "0,0,0,0,0,0," + lcValDebito + "," + lcValCredito + ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
                            break;

                        case 4:
                            lcMes = "ABR";
                            lcSartaCampos1 = "0,0,0,0,0,0,0,0," + lcValDebito + "," + lcValCredito + ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
                            break;

                        case 5:
                            lcMes = "MAY";
                            lcSartaCampos1 = "0,0,0,0,0,0,0,0,0,0," + lcValDebito + "," + lcValCredito + ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
                            break;

                        case 6:
                            lcMes = "JUN";
                            lcSartaCampos1 = "0,0,0,0,0,0,0,0,0,0,0,0," + lcValDebito + "," + lcValCredito + ",0,0,0,0,0,0,0,0,0,0,0,0,0,0";
                            break;

                        case 7:
                            lcMes = "JUL";
                            lcSartaCampos1 = "0,0,0,0,0,0,0,0,0,0,0,0,0,0," + lcValDebito + "," + lcValCredito + ",0,0,0,0,0,0,0,0,0,0,0,0";
                            break;


                        case 8:
                            lcMes = "AGO";
                            lcSartaCampos1 = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0," + lcValDebito + "," + lcValCredito + ",0,0,0,0,0,0,0,0,0,0";
                            break;

                        case 9:
                            lcMes = "SEP";
                            lcSartaCampos1 = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0," + lcValDebito + "," + lcValCredito + ",0,0,0,0,0,0,0,0";
                            break;

                        case 10:
                            lcMes = "OCT";
                            lcSartaCampos1 = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0," + lcValDebito + "," + lcValCredito + ",0,0,0,0,0,0";
                            break;

                        case 11:
                            lcMes = "NOV";
                            lcSartaCampos1 = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0," + lcValDebito + "," + lcValCredito + ",0,0,0,0";
                            break;

                        case 12:
                            lcMes = "DIC";
                            lcSartaCampos1 = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0," + lcValDebito + "," + lcValCredito + ",0,0";
                            break;
                    }
                    break;
                case 1:
                    lcMes = "INI";
                    lcSartaCampos1 = lcValDebito + "," + lcValCredito + ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
                    break;
                case 2:
                    lcMes = "CIE";
                    lcSartaCampos1 = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0," + lcValDebito + "," + lcValCredito;
                    break;
            }

            string lcCampoMesDeb = "MOV" + lcMes + "DEB";
            string lcCampoMesHab = "MOV" + lcMes + "HAB";
            conectar.conectar();
            conectar.Connection.Open();

            // Empezamos por los totmovi
            data.Clear();
            adaptador = new MySqlDataAdapter("select idtotMovi," + lcCampoMesDeb + "," + lcCampoMesHab + "  from totmovi where cuenta='" + HCuenta + "' and LENGTH(TRIM(CUENTA)) = LENGTH(TRIM('" + HCuenta + "')) AND idinstitucion =" + idInstitucion.ToString() + " and año ='" + Fecha.Year.ToString() + "'", conectar.Connection);
            adaptador.Fill(data);
            if (data.Rows.Count == 0)
            {
                // Insertar la cuenta
                lcSartaCampos = "0," + lcSartaCampos;
                insertar("totmovi", lcSartaCampos + lcSartaCampos1 + "," + idInstitucion.ToString());
            }
            else
            {
                editar("totmovi", lcCampoMesDeb + "= " + lcCampoMesDeb + signo + lcValDebito + "," + lcCampoMesHab + "=" + lcCampoMesHab + signo + lcValCredito, "cuenta='" + HCuenta + "' and LENGTH(TRIM(CUENTA)) = LENGTH(TRIM('" + HCuenta + "')) and  año = '" + Fecha.Year.ToString() + "' and idinstitucion=" + idInstitucion.ToString());

            }

            lcSartaCampos = "'" + tcNit + "','" + HCuenta + "','" + Fecha.Year.ToString() + "',";
            data.Clear();
            // Segiomos con TOTTERCE
            adaptador = new MySqlDataAdapter("select idTOTTERCE," + lcCampoMesDeb + "," + lcCampoMesHab + "  from totterce where cuenta='" + HCuenta + "' and LENGTH(TRIM(CUENTA)) = LENGTH(TRIM('" + HCuenta + "')) AND nit ='" + tcNit + "' and idinstitucion =" + idInstitucion.ToString() + " and año ='" + Fecha.Year.ToString() + "'", conectar.Connection);
            adaptador.Fill(data);
            if (data.Rows.Count == 0)
            {
                // Insertar la cuenta
                lcSartaCampos = "0," + lcSartaCampos;
                insertar("totterce", lcSartaCampos + lcSartaCampos1 + "," + idInstitucion.ToString());
            }
            else
            {
                editar("totterce", lcCampoMesDeb + "= " + lcCampoMesDeb + signo + lcValDebito + "," + lcCampoMesHab + "=" + lcCampoMesHab + signo + lcValCredito, "cuenta='" + HCuenta + "' and LENGTH(TRIM(CUENTA)) = LENGTH(TRIM('" + HCuenta + "')) and  año = '" + Fecha.Year.ToString() + "' AND nit ='" + tcNit + "' and idinstitucion=" + idInstitucion.ToString());

            }



            if (tcCodcc != "")
            {
                data.Clear();
                lcSartaCampos = "'" + tcCodcc + "','" + HCuenta + "','" + Fecha.Year.ToString() + "',";
                // Segiomos con TOTcc
                adaptador = new MySqlDataAdapter("select idTOTcentro," + lcCampoMesDeb + "," + lcCampoMesHab + "  from totcentro where cuenta='" + HCuenta + "' and LENGTH(TRIM(CUENTA)) = LENGTH(TRIM('" + HCuenta + "')) AND idcentro ='" + tcCodcc + "' and idinstitucion =" + idInstitucion.ToString() + " and año ='" + Fecha.Year.ToString() + "'", conectar.Connection);
                adaptador.Fill(data);
                if (data.Rows.Count == 0)
                {
                    // Insertar la cuenta
                    lcSartaCampos = "0," + lcSartaCampos;
                    insertar("totcentro", lcSartaCampos + lcSartaCampos1 + "," + idInstitucion.ToString());
                }
                else
                {
                    editar("totcentro", lcCampoMesDeb + "= " + lcCampoMesDeb + signo + lcValDebito + "," + lcCampoMesHab + "=" + lcCampoMesHab + signo + lcValCredito, "cuenta='" + HCuenta + "' and LENGTH(TRIM(CUENTA)) = LENGTH(TRIM('" + HCuenta + "')) and  año = '" + Fecha.Year.ToString() + "' AND idcentro ='" + tcCodcc + "' and idinstitucion=" + idInstitucion.ToString());

                }

            }


            conectar.Connection.Close();

        }



        public void MayorizarPre(int idInstitucion, string MCuenta, double Valor, string signo, DateTime Fecha, string tipo, DataTable data, string Nit, int tipopre)
        {


            var institucion = new DataTable();
            consultacamposcondicion("institucion", " posfijas,separador  ", "idinstitucion=" + idInstitucion, institucion);


            // Definimos los campos a totalizar

            string lcSartaCampos = "'" + Fecha.Year.ToString() + "',";

            insertacampostotgas(idInstitucion, MCuenta, Valor, signo, tipo, Fecha, data, Nit, tipopre);

            // Buscamos el centro de costo de la cuenta

            string lcCuentanueva = "";
            //Matoyizamos totmovi
            if (institucion.Rows.Count > 0 && institucion.Rows[0]["posfijas"].ToString() == "1")
            {

                for (int lnCuenta = MCuenta.Length - 3; lnCuenta >= 4; lnCuenta = lnCuenta - 3)
                {
                    lcCuentanueva = MCuenta.Substring(0, lnCuenta);
                    insertacampostotgas(idInstitucion, lcCuentanueva, Valor, signo, tipo, Fecha, data, Nit, tipopre);

                }

                lcCuentanueva = MCuenta.Substring(0, 4);
                insertacampostotgas(idInstitucion, lcCuentanueva, Valor, signo, tipo, Fecha, data, Nit, tipopre);

                lcCuentanueva = MCuenta.Substring(0, 2);
                insertacampostotgas(idInstitucion, lcCuentanueva, Valor, signo, tipo, Fecha, data, Nit, tipopre);

                lcCuentanueva = MCuenta.Substring(0, 1);
                insertacampostotgas(idInstitucion, lcCuentanueva, Valor, signo, tipo, Fecha, data, Nit, tipopre);
            }
            else if (institucion.Rows.Count > 0 && institucion.Rows[0]["posfijas"].ToString() == "0")
            {
                var separador = institucion.Rows[0]["separador"].ToString();
                var codesGroups = MCuenta.Split(new[] { separador }, StringSplitOptions.RemoveEmptyEntries);
                int tamGrupos = codesGroups.Length;

                // Obtengo cada cuenta de acuerdo al vector


                for (int lnCuenta = tamGrupos - 1; lnCuenta > 0; lnCuenta = lnCuenta - 1)
                {
                    lcCuentanueva = "";
                    for (int grupos = 0; grupos < lnCuenta; grupos = grupos + 1)
                    {
                        if (grupos == 0)
                        {
                            lcCuentanueva = codesGroups[0];
                        }
                        else
                        {
                            lcCuentanueva = lcCuentanueva + separador + codesGroups[grupos];
                        }



                    }

                    insertacampostotgas(idInstitucion, lcCuentanueva, Valor, signo, tipo, Fecha, data, Nit, tipopre);


                }

            }

        }

        private string ObtieneCuenta(string[] grupo, int posInicial, int posFinal, string separador)
        {
            var result = "";
            for (int i = posInicial; i < posFinal; i++)
            {
                if (result == "")
                    result = result + grupo[i];
                else
                {
                    result = result + separador + grupo[i];
                }
            }
            return result;
        }


        private void insertacampostotgas(int idInstitucion, string TCuenta, double Valor, string signo, string tipo, DateTime Fecha, DataTable data, string tcNit, int tipopre)
        {
            string lcSartaCampos = "'" + TCuenta + "','" + Fecha.Year.ToString() + "',";
            string lcCampoMes = "";
            if (tipo.ToUpper() != "APROBADO")
            {
                string lcMes = "";
                switch (Fecha.Month)
                {
                    case 1:
                        lcMes = "ENE";

                        break;

                    case 2:
                        lcMes = "FEB";

                        break;

                    case 3:
                        lcMes = "MAR";

                        break;

                    case 4:
                        lcMes = "ABR";

                        break;

                    case 5:
                        lcMes = "MAY";

                        break;

                    case 6:
                        lcMes = "JUN";

                        break;

                    case 7:
                        lcMes = "JUL";

                        break;


                    case 8:
                        lcMes = "AGO";

                        break;

                    case 9:
                        lcMes = "SEP";

                        break;

                    case 10:
                        lcMes = "OCT";

                        break;

                    case 11:
                        lcMes = "NOV";

                        break;

                    case 12:
                        lcMes = "DIC";

                        break;
                }


                lcCampoMes = tipo + lcMes;
            }
            else
            {
                lcCampoMes = tipo;
            }


            string lctablapres = "totpresgas";
            switch (tipopre)
            {
                case 1:
                    lctablapres = "totpresgas";
                    break;
                case 2:
                    lctablapres = "totpresing";
                    break;
                case 3:
                    lctablapres = "totcgrgas";
                    break;
                case 4:
                    lctablapres = "totcgring";
                    break;
            }
            conectar.conectar();
            conectar.Connection.Open();
            data.Clear();
            // Empezamos por los totmovi
            adaptador = new MySqlDataAdapter("select id," + lcCampoMes + " from " + lctablapres + " where TRIM(cuenta)='" + TCuenta.Trim() + "' and LENGTH(TRIM(CUENTA)) = LENGTH(TRIM('" + TCuenta.Trim() + "')) AND idinstitucion =" + idInstitucion.ToString() + " and año ='" + Fecha.Year.ToString() + "'", conectar.Connection);
            //adaptador = new MySqlDataAdapter("select id,cdpsjun from totpresgas where TRIM(cuenta)='020202' and LENGTH(TRIM(CUENTA)) = LENGTH(TRIM('020202')) AND idinstitucion =1 and año ='2013'", conexion);
            adaptador.Fill(data);
            conectar.Connection.Close();
            if (data.Rows.Count == 0)
            {

                // Insertar la cuenta

                insertaralgunos(lctablapres, "Año,cuenta,idinstitucion," + lcCampoMes, "'" + Fecha.Year.ToString() + "','" + TCuenta + "'," + idInstitucion.ToString() + "," + Valor.ToString());
            }
            else
            {
                editar(lctablapres, lcCampoMes + "= " + lcCampoMes + signo + Valor.ToString(), "TRIM(cuenta)='" + TCuenta.Trim() + "' and LENGTH(TRIM(CUENTA)) = LENGTH(TRIM('" + TCuenta.Trim() + "')) and  año = '" + Fecha.Year.ToString() + "' and idinstitucion=" + idInstitucion.ToString());



            }



            conectar.Connection.Close();

        }


        public double Saldocuentapres(int idInstitucion, string HCuenta, string signo, string tipo, DateTime Fecha, DataTable data, string tctipo, int tipopre)
        {


            string lctablapres = "totpresgas";
            if (tipopre == 2)
            {
                lctablapres = "totpreing";
            }



            consultacamposcondicion(lctablapres, "*", "cuenta = '" + HCuenta + "' and año = '" + Fecha.Year.ToString() + "' and idinstitucion = " + idInstitucion.ToString(), data);
            double SaldoCuenta = 0;
            double Movimiento = 0;
            if (data.Rows.Count > 0)
            {
                SaldoCuenta = Convert.ToDouble(data.Rows[0]["APROBADO"]);
                for (int lnMes = 1; lnMes <= Fecha.Month; lnMes++)
                {
                    Movimiento = Movimiento + SaldeaPres(lnMes, tctipo, data, Fecha);
                }

                if (tctipo == "cdps")
                {
                    SaldoCuenta = SaldoCuenta + Movimiento;
                }

            }
            else
            {
                SaldoCuenta = 0;
            }

            return SaldoCuenta;
        }

        private double SaldeaPres(int lnMes, string tcTipo, DataTable data, DateTime Fecha)
        {
            double SaldoFinal = 0;
            string lcMes = "";
            switch (lnMes)
            {
                case 1:
                    lcMes = "ENE";

                    break;

                case 2:
                    lcMes = "FEB";

                    break;

                case 3:
                    lcMes = "MAR";

                    break;

                case 4:
                    lcMes = "ABR";

                    break;

                case 5:
                    lcMes = "MAY";

                    break;

                case 6:
                    lcMes = "JUN";

                    break;

                case 7:
                    lcMes = "JUL";

                    break;


                case 8:
                    lcMes = "AGO";

                    break;

                case 9:
                    lcMes = "SEP";

                    break;

                case 10:
                    lcMes = "OCT";

                    break;

                case 11:
                    lcMes = "NOV";

                    break;

                case 12:
                    lcMes = "DIC";

                    break;
            }

            switch (tcTipo)
            {
                case "cdps":

                    SaldoFinal = Convert.ToDouble(data.Rows[0]["Adiciones" + lcMes]) - Convert.ToDouble(data.Rows[0]["reducciones" + lcMes]) + Convert.ToDouble(data.Rows[0]["creditos" + lcMes]) - Convert.ToDouble(data.Rows[0]["contracreditos" + lcMes]) - Convert.ToDouble(data.Rows[0][tcTipo + lcMes]);
                    break;
                case "rps":
                    SaldoFinal = SaldoFinal - Convert.ToDouble(data.Rows[0]["cdps" + lcMes]) - Convert.ToDouble(data.Rows[0][tcTipo + lcMes]);
                    break;
                case "odps":
                    SaldoFinal = Convert.ToDouble(data.Rows[0]["rps" + lcMes]) - Convert.ToDouble(data.Rows[0][tcTipo + lcMes]);
                    break;
                case "pag":
                    SaldoFinal = Convert.ToDouble(data.Rows[0]["odps" + lcMes]) - Convert.ToDouble(data.Rows[0][tcTipo + lcMes]);
                    break;
                default:
                    SaldoFinal = Convert.ToDouble(data.Rows[0]["adiciones" + lcMes]) - Convert.ToDouble(data.Rows[0]["reducciones" + lcMes]) + Convert.ToDouble(data.Rows[0]["creditos" + lcMes]) - Convert.ToDouble(data.Rows[0]["contracreditos" + lcMes]) - Convert.ToDouble(data.Rows[0]["creditos" + lcMes]) - Convert.ToDouble(data.Rows[0]["rps" + lcMes]);
                    break;


            }

            return SaldoFinal;
        }


        private void BuscaContable(string cuentaPres, DataTable DatosCon)
        {
            DatosCon.Clear();
            consultacamposcondicion("plancuenta", "cuentacon,cuentacon2", "codigo = '" + cuentaPres + "'", DatosCon);


        }


        public string calculafecha(int tipo, string mes, string ano)
        {
            string fechain;

            string lcMes = calculanumeromes(mes);

            if (tipo == 1)
            {

                fechain = ano + "-" + lcMes + "-01";

            }
            else
            {
                string lcdia = "";
                switch (lcMes)
                {
                    case "01":
                        lcdia = "31";
                        break;

                    case "02":
                        lcdia = "28";
                        /*
                         if (mod(Convert.ToInt32(ano) , 4))
                         {
                             lcdia = "29";
                         }
                         */

                        break;

                    case "03":
                        lcdia = "31";
                        break;

                    case "04":
                        lcdia = "30";
                        break;

                    case "05":
                        lcdia = "31";
                        break;

                    case "06":
                        lcdia = "30";
                        break;

                    case "07":
                        lcdia = "31";
                        break;

                    case "08":
                        lcdia = "31";
                        break;

                    case "09":
                        lcdia = "30";
                        break;

                    case "10":
                        lcdia = "31";
                        break;

                    case "11":
                        lcdia = "30";
                        break;

                    case "12":
                        lcdia = "31";
                        break;


                }

                fechain = ano + "-" + lcMes + "-" + lcdia;

            }

            return fechain;
        }

        public string calculanumeromes(string mes)
        {
            string lcMes = "";
            switch (mes)
            {
                case "Enero":
                    lcMes = "01";
                    break;
                case "Febrero":
                    lcMes = "02";
                    break;
                case "Marzo":
                    lcMes = "03";
                    break;
                case "Abril":
                    lcMes = "04";
                    break;
                case "Mayo":
                    lcMes = "05";
                    break;
                case "Junio":
                    lcMes = "06";
                    break;
                case "Julio":
                    lcMes = "07";
                    break;
                case "Agosto":
                    lcMes = "08";
                    break;
                case "Septiembre":
                    lcMes = "09";
                    break;
                case "Octubre":
                    lcMes = "10";
                    break;
                case "Noviembre":
                    lcMes = "11";
                    break;
                case "Diciembre":
                    lcMes = "12";
                    break;

            }

            return lcMes;



        }


        public string calculanombremes(int mes)
        {
            string lcMes = "";
            switch (mes)
            {
                case 1:
                    lcMes = "Enero";
                    break;
                case 2:
                    lcMes = "Febrero";
                    break;
                case 3:
                    lcMes = "Marzo";
                    break;
                case 4:
                    lcMes = "Abril";
                    break;
                case 5:
                    lcMes = "Mayo";
                    break;
                case 6:
                    lcMes = "Junio";
                    break;
                case 7:
                    lcMes = "Julio";
                    break;
                case 8:
                    lcMes = "Agosto";
                    break;
                case 9:
                    lcMes = "Septiembre";
                    break;
                case 10:
                    lcMes = "Octubre";
                    break;
                case 11:
                    lcMes = "Noviembre";
                    break;
                case 12:
                    lcMes = "Diciembre";
                    break;

            }

            return lcMes;



        }

        public string devuelvecampostotmovi(string mes)
        {
            string lcSarta = "";
            switch (mes)
            {
                case "Enero":
                    lcSarta = "MOVINIDEB-MOVINIHAB AS SaldoInicial,MOVENEDEB AS MOVDEBITO,MOVENEHAB AS MOVCREDITO,(MOVINIDEB-MOVINIHAB)+(MOVENEDEB-MOVENEHAB) AS SALDOFINAL";
                    break;
                case "Febrero":
                    lcSarta = "(MOVINIDEB-MOVINIHAB)+(MOVENEDEB-MOVENEHAB) AS SaldoInicial,MOVFEBDEB AS MOVDEBITO,MOVFEBHAB AS MOVCREDITO,(MOVINIDEB-MOVINIHAB)+(MOVENEDEB-MOVENEHAB)+(MOVFEBDEB-MOVFEBHAB) AS SALDOFINAL";
                    break;
                case "Marzo":
                    lcSarta = "(MOVINIDEB-MOVINIHAB)+(MOVENEDEB-MOVENEHAB)+(MOVFEBDEB-MOVFEBHAB) AS SaldoInicial,MOVMARDEB AS MOVDEBITO,MOVMARHAB AS MOVCREDITO,(MOVINIDEB-MOVINIHAB)+(MOVENEDEB-MOVENEHAB)+(MOVFEBDEB-MOVFEBHAB)+(MOVMARDEB-MOVMARHAB) AS SALDOFINAL";
                    break;
                case "Abril":
                    lcSarta = "(MOVINIDEB-MOVINIHAB)+(MOVENEDEB-MOVENEHAB)+(MOVFEBDEB-MOVFEBHAB)+(MOVMARDEB-MOVMARHAB) AS SaldoInicial,MOVABRDEB AS MOVDEBITO,MOVABRHAB AS MOVCREDITO,(MOVINIDEB-MOVINIHAB)+(MOVENEDEB-MOVENEHAB)+(MOVFEBDEB-MOVFEBHAB)+(MOVMARDEB-MOVMARHAB)+(MOVABRDEB-MOVABRHAB) AS SALDOFINAL";
                    break;
                case "Mayo":
                    lcSarta = "(MOVINIDEB-MOVINIHAB)+(MOVENEDEB-MOVENEHAB)+(MOVFEBDEB-MOVFEBHAB)+(MOVMARDEB-MOVMARHAB)+(MOVABRDEB-MOVABRHAB) AS SaldoInicial,MOVMAYDEB AS MOVDEBITO,MOVMAYHAB AS MOVCREDITO,(MOVINIDEB-MOVINIHAB)+(MOVENEDEB-MOVENEHAB)+(MOVFEBDEB-MOVFEBHAB)+(MOVMARDEB-MOVMARHAB)+(MOVABRDEB-MOVABRHAB)+(MOVMAYDEB-MOVMAYHAB) AS SALDOFINAL";
                    break;
                case "Junio":
                    lcSarta = "(MOVINIDEB-MOVINIHAB)+(MOVENEDEB-MOVENEHAB)+(MOVFEBDEB-MOVFEBHAB)+(MOVMARDEB-MOVMARHAB)+(MOVABRDEB-MOVABRHAB)+(MOVMAYDEB-MOVMAYHAB) AS SaldoInicial,MOVJUNDEB AS MOVDEBITO,MOVJUNHAB AS MOVCREDITO,(MOVINIDEB-MOVINIHAB)+(MOVENEDEB-MOVENEHAB)+(MOVFEBDEB-MOVFEBHAB)+(MOVMARDEB-MOVMARHAB)+(MOVABRDEB-MOVABRHAB)+(MOVMAYDEB-MOVMAYHAB)+(MOVJUNDEB-MOVJUNHAB) AS SALDOFINAL";
                    break;
                case "Julio":
                    lcSarta = "(MOVINIDEB-MOVINIHAB)+(MOVENEDEB-MOVENEHAB)+(MOVFEBDEB-MOVFEBHAB)+(MOVMARDEB-MOVMARHAB)+(MOVABRDEB-MOVABRHAB)+(MOVMAYDEB-MOVMAYHAB)+(MOVJUNDEB-MOVJUNHAB) AS SaldoInicial,MOVJULDEB AS MOVDEBITO,MOVJULHAB AS MOVCREDITO,(MOVINIDEB-MOVINIHAB)+(MOVENEDEB-MOVENEHAB)+(MOVFEBDEB-MOVFEBHAB)+(MOVMARDEB-MOVMARHAB)+(MOVABRDEB-MOVABRHAB)+(MOVMAYDEB-MOVMAYHAB)+(MOVJUNDEB-MOVJUNHAB)+(MOVJULDEB-MOVJULHAB) AS SALDOFINAL";
                    break;
                case "Agosto":
                    lcSarta = "(MOVINIDEB-MOVINIHAB)+(MOVENEDEB-MOVENEHAB)+(MOVFEBDEB-MOVFEBHAB)+(MOVMARDEB-MOVMARHAB)+(MOVABRDEB-MOVABRHAB)+(MOVMAYDEB-MOVMAYHAB)+(MOVJUNDEB-MOVJUNHAB)+(MOVJULDEB-MOVJULHAB) AS SaldoInicial,MOVAGODEB AS MOVDEBITO,MOVAGOHAB AS MOVCREDITO,(MOVINIDEB-MOVINIHAB)+(MOVENEDEB-MOVENEHAB)+(MOVFEBDEB-MOVFEBHAB)+(MOVMARDEB-MOVMARHAB)+(MOVABRDEB-MOVABRHAB)+(MOVMAYDEB-MOVMAYHAB)+(MOVJUNDEB-MOVJUNHAB)+(MOVJULDEB-MOVJULHAB)+(MOVAGODEB-MOVAGOHAB) AS SALDOFINAL";
                    break;
                case "Septiembre":
                    lcSarta = "(MOVINIDEB-MOVINIHAB)+(MOVENEDEB-MOVENEHAB)+(MOVFEBDEB-MOVFEBHAB)+(MOVMARDEB-MOVMARHAB)+(MOVABRDEB-MOVABRHAB)+(MOVMAYDEB-MOVMAYHAB)+(MOVJUNDEB-MOVJUNHAB)+(MOVJULDEB-MOVJULHAB)+(MOVAGODEB-MOVAGOHAB) AS SaldoInicial,MOVSEPDEB AS MOVDEBITO,MOVSEPHAB AS MOVCREDITO,(MOVINIDEB-MOVINIHAB)+(MOVENEDEB-MOVENEHAB)+(MOVFEBDEB-MOVFEBHAB)+(MOVMARDEB-MOVMARHAB)+(MOVABRDEB-MOVABRHAB)+(MOVMAYDEB-MOVMAYHAB)+(MOVJUNDEB-MOVJUNHAB)+(MOVJULDEB-MOVJULHAB)+(MOVAGODEB-MOVAGOHAB)+(MOVSEPDEB-MOVSEPHAB) AS SALDOFINAL";
                    break;
                case "Octubre":
                    lcSarta = "(MOVINIDEB-MOVINIHAB)+(MOVENEDEB-MOVENEHAB)+(MOVFEBDEB-MOVFEBHAB)+(MOVMARDEB-MOVMARHAB)+(MOVABRDEB-MOVABRHAB)+(MOVMAYDEB-MOVMAYHAB)+(MOVJUNDEB-MOVJUNHAB)+(MOVJULDEB-MOVJULHAB)+(MOVAGODEB-MOVAGOHAB)+(MOVSEPDEB-MOVSEPHAB) AS SaldoInicial,MOVOCTDEB AS MOVDEBITO,MOVOCTHAB AS MOVCREDITO,(MOVINIDEB-MOVINIHAB)+(MOVENEDEB-MOVENEHAB)+(MOVFEBDEB-MOVFEBHAB)+(MOVMARDEB-MOVMARHAB)+(MOVABRDEB-MOVABRHAB)+(MOVMAYDEB-MOVMAYHAB)+(MOVJUNDEB-MOVJUNHAB)+(MOVJULDEB-MOVJULHAB)+(MOVAGODEB-MOVAGOHAB)+(MOVSEPDEB-MOVSEPHAB)+(MOVOCTDEB-MOVOCTHAB) AS SALDOFINAL";
                    break;
                case "Noviembre":
                    lcSarta = "(MOVINIDEB-MOVINIHAB)+(MOVENEDEB-MOVENEHAB)+(MOVFEBDEB-MOVFEBHAB)+(MOVMARDEB-MOVMARHAB)+(MOVABRDEB-MOVABRHAB)+(MOVMAYDEB-MOVMAYHAB)+(MOVJUNDEB-MOVJUNHAB)+(MOVJULDEB-MOVJULHAB)+(MOVAGODEB-MOVAGOHAB)+(MOVSEPDEB-MOVSEPHAB)+(MOVOCTDEB-MOVOCTHAB) AS SaldoInicial,MOVNOVDEB AS MOVDEBITO,MOVNOVHAB AS MOVCREDITO,(MOVINIDEB-MOVINIHAB)+(MOVENEDEB-MOVENEHAB)+(MOVFEBDEB-MOVFEBHAB)+(MOVMARDEB-MOVMARHAB)+(MOVABRDEB-MOVABRHAB)+(MOVMAYDEB-MOVMAYHAB)+(MOVJUNDEB-MOVJUNHAB)+(MOVJULDEB-MOVJULHAB)+(MOVAGODEB-MOVAGOHAB)+(MOVSEPDEB-MOVSEPHAB)+(MOVOCTDEB-MOVOCTHAB)+(MOVNOVDEB-MOVNOVHAB) AS SALDOFINAL";
                    break;
                case "Diciembre":
                    lcSarta = "(MOVINIDEB-MOVINIHAB)+(MOVENEDEB-MOVENEHAB)+(MOVFEBDEB-MOVFEBHAB)+(MOVMARDEB-MOVMARHAB)+(MOVABRDEB-MOVABRHAB)+(MOVMAYDEB-MOVMAYHAB)+(MOVJUNDEB-MOVJUNHAB)+(MOVJULDEB-MOVJULHAB)+(MOVAGODEB-MOVAGOHAB)+(MOVSEPDEB-MOVSEPHAB)+(MOVOCTDEB-MOVOCTHAB)+(MOVNOVDEB-MOVNOVHAB) AS SaldoInicial,MOVDICDEB AS MOVDEBITO,MOVDICHAB AS MOVCREDITO,(MOVINIDEB-MOVINIHAB)+(MOVENEDEB-MOVENEHAB)+(MOVFEBDEB-MOVFEBHAB)+(MOVMARDEB-MOVMARHAB)+(MOVABRDEB-MOVABRHAB)+(MOVMAYDEB-MOVMAYHAB)+(MOVJUNDEB-MOVJUNHAB)+(MOVJULDEB-MOVJULHAB)+(MOVAGODEB-MOVAGOHAB)+(MOVSEPDEB-MOVSEPHAB)+(MOVOCTDEB-MOVOCTHAB)+(MOVNOVDEB-MOVNOVHAB)+(MOVDICDEB-MOVDICHAB) AS SALDOFINAL";
                    break;
                case "Cierre":
                    lcSarta = "(MOVINIDEB-MOVINIHAB)+(MOVENEDEB-MOVENEHAB)+(MOVFEBDEB-MOVFEBHAB)+(MOVMARDEB-MOVMARHAB)+(MOVABRDEB-MOVABRHAB)+(MOVMAYDEB-MOVMAYHAB)+(MOVJUNDEB-MOVJUNHAB)+(MOVJULDEB-MOVJULHAB)+(MOVAGODEB-MOVAGOHAB)+(MOVSEPDEB-MOVSEPHAB)+(MOVOCTDEB-MOVOCTHAB)+(MOVNOVDEB-MOVNOVHAB)+(MOVDICDEB-MOVDICHAB) AS SaldoInicial,MOVCIEDEB AS MOVDEBITO,MOVCIEHAB AS MOVCREDITO,(MOVINIDEB-MOVINIHAB)+(MOVENEDEB-MOVENEHAB)+(MOVFEBDEB-MOVFEBHAB)+(MOVMARDEB-MOVMARHAB)+(MOVABRDEB-MOVABRHAB)+(MOVMAYDEB-MOVMAYHAB)+(MOVJUNDEB-MOVJUNHAB)+(MOVJULDEB-MOVJULHAB)+(MOVAGODEB-MOVAGOHAB)+(MOVSEPDEB-MOVSEPHAB)+(MOVOCTDEB-MOVOCTHAB)+(MOVNOVDEB-MOVNOVHAB)+(MOVDICDEB-MOVDICHAB)+(MOVCIEDEB-MOVCIEHAB) AS SALDOFINAL";
                    break;
            }

            return lcSarta;

        }

        public string formatea(string Texto)
        {
            Texto = reformateaIns(Texto);
            string valorformateado = "";
            string valorentero = "";

            if (Texto.IndexOf(".") != -1)
            {
                valorentero = Texto.ToString().Substring(0, Texto.ToString().IndexOf("."));
            }
            else
            {
                valorentero = Texto;
            }

            string nuevovalor = "";
            if (valorentero.Length > 3)
            {
                for (int lnLetra = valorentero.Length; lnLetra > 0; lnLetra = lnLetra - 3)
                {
                    if (lnLetra <= 3)
                    {
                        nuevovalor = valorentero.Substring(0, lnLetra) + nuevovalor;
                    }
                    else
                    {
                        nuevovalor = "," + valorentero.Substring(lnLetra - 3, 3) + nuevovalor;
                    }
                }



                valorformateado = nuevovalor;
            }
            else
            {
                valorformateado = valorentero;
            }


            if (Texto.IndexOf(".") != -1)
            {
                valorformateado = valorformateado + Texto.ToString().Substring(Texto.ToString().IndexOf("."));
            }

            return valorformateado;
        }

	 public void confirmaringreso(string texto)
        {
            string activeDir = "D://";

            string año = System.IO.Path.Combine(activeDir, "confirmaringreso" + "\\");
            System.IO.Directory.CreateDirectory(año);
            string nombreArchivo = año + "\\Lecturas.txt";

            using (FileStream flujoArchivo = new FileStream(nombreArchivo, FileMode.Create, FileAccess.Write, FileShare.None))
            {

                using (StreamWriter escritor = new StreamWriter(flujoArchivo))
                {

                    escritor.WriteLine(texto);

                }

            }
        }

        public string reformatea(string Texto)
        {
            Texto = Texto.Replace(",", "");
            //Texto = Texto.Replace(",", ".");
            Texto = Texto.Replace("$", "");
            return Texto;

        }

        public string reformateaIns(string Texto)
        {

            Texto = Texto.Replace(",", "");
            if (Texto == "")
            {
                Texto = "0";
            }
            return Texto;

        }


        public string formateafecha(DateTime dfecha, int tipo)
        {
            string cfecha = "";

            int lnMes = dfecha.Month;
            int lnDia = dfecha.Day;

            string lcMes = lnMes.ToString();
            string lcDia = lnDia.ToString();

            if (lnDia < 10)
            {
                lcDia = "0" + lcDia;
            }
            if (lnMes < 10)
            {
                lcMes = "0" + lcMes;
            }


            string lcHora = dfecha.Hour.ToString();
            string lcMinuto = dfecha.Minute.ToString();
            string lcSegundo = dfecha.Second.ToString();

            if (tipo == 1)
            {
                if (lnDia < 10)
                {
                    lcDia = "0" + lcDia;
                }
                if (lnMes < 10)
                {
                    lcMes = "0" + lcMes;
                }
                if (Convert.ToInt32(lcHora) < 10)
                {
                    lcHora = "0" + lcHora;
                }

                if (Convert.ToInt32(lcMinuto) < 10)
                {
                    lcMinuto = "0" + lcMinuto;
                }

                if (Convert.ToInt32(lcSegundo) < 10)
                {
                    lcSegundo = "0" + lcSegundo;
                }


                cfecha = dfecha.Year.ToString() + "-" + lcMes + "-" + lcDia + " " + lcHora + ":" + lcMinuto + ":" + lcSegundo;
            }
            else
            {
                cfecha = dfecha.Year.ToString() + "-" + lcMes + "-" + lcDia;
            }




        




            return cfecha;
        }



        public bool validaconsecutivo(string lcConse, string lcFecha)
        {
            if (lcConse.Substring(0, 4) != lcFecha.Substring(0, 4))
            {
                return false;
            }

            if (lcConse.Substring(4, 2) != lcFecha.Substring(4, 2))
            {
                return false;
            }

            if (lcConse.Length != 9)
            {
                return false;
            }

            return true;
        }

        public string recuperaUbicacion()
        {
            string lcsartaUbicacion = "";

            System.Configuration.Configuration rootWebConfig1 =
                   System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            if (0 < rootWebConfig1.AppSettings.Settings.Count)
            {
                System.Configuration.KeyValueConfigurationElement Ubicacion = rootWebConfig1.AppSettings.Settings["ubicacion"];
                lcsartaUbicacion = Ubicacion.Value;
            }
            return lcsartaUbicacion;
        }

        public string recuperabanner()
        {
            string lcsartabanner = "/encabezado_soft_login.png";

            System.Configuration.Configuration rootWebConfig1 =
                   System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            if (0 < rootWebConfig1.AppSettings.Settings.Count)
            {
                System.Configuration.KeyValueConfigurationElement banner = rootWebConfig1.AppSettings.Settings["banner"];
                lcsartabanner = banner.Value;
            }
            return lcsartabanner;
        }


        public string recuperafirmacertificado()
        {
            string lcsartabanner = "~/Images/firma.png";

            System.Configuration.Configuration rootWebConfig1 =
                   System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            if (0 < rootWebConfig1.AppSettings.Settings.Count)
            {
                System.Configuration.KeyValueConfigurationElement firmacertificado = rootWebConfig1.AppSettings.Settings["firmacertificado"];
                lcsartabanner = firmacertificado.Value;
            }
            return lcsartabanner;
        }


        public string recuperatitulocertificado()
        {
            string lcsartabanner = "LA COORDINADORA DEL GRUPO GESTION DOCUMENTAL- SECRETARIA GENERAL DE LA GOBERANCION DE SANTANDER";

            System.Configuration.Configuration rootWebConfig1 =
                   System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            if (0 < rootWebConfig1.AppSettings.Settings.Count)
            {
                System.Configuration.KeyValueConfigurationElement titulocertificado = rootWebConfig1.AppSettings.Settings["titulocertificado"];
                lcsartabanner = titulocertificado.Value;
            }
            return lcsartabanner;
        }

        public string recuperafirmanombre()
        {
            string lcsartabanner = "MERCEDES MARTINEZ CORREA";

            System.Configuration.Configuration rootWebConfig1 =
                   System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            if (0 < rootWebConfig1.AppSettings.Settings.Count)
            {
                System.Configuration.KeyValueConfigurationElement firmanombre = rootWebConfig1.AppSettings.Settings["firmanombre"];
                lcsartabanner = firmanombre.Value;
            }
            return lcsartabanner;
        }

        public string recuperafirmacargo()
        {
            string lcsartabanner = "Coordinadora  Grupo Gestión Documental";

            System.Configuration.Configuration rootWebConfig1 =
                   System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            if (0 < rootWebConfig1.AppSettings.Settings.Count)
            {
                System.Configuration.KeyValueConfigurationElement firmacargo = rootWebConfig1.AppSettings.Settings["firmacargo"];
                lcsartabanner = firmacargo.Value;
            }
            return lcsartabanner;
        }

        public string recuperatextoestampillas()
        {
            string lcsartabanner = "Se anexa y anula recibo oficial de la Secretaria de Hacienda de la Gobernacion de Santander por concepto de Recaudo de estampillas por el valor de $7.810.00 distribuidas asi: $2.100.00 de Pro Hospital; $900.00 de Pro Desarrollo; $1.100.00 de Pro Electrificacion; $2.100.00 de Pro Cultura y $900.00 de Pro Anciano, $710.00 Ordenanza 012/05 y Decreto 005/06.";

            System.Configuration.Configuration rootWebConfig1 =
                   System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            if (0 < rootWebConfig1.AppSettings.Settings.Count)
            {
                System.Configuration.KeyValueConfigurationElement textoestampillas = rootWebConfig1.AppSettings.Settings["textoestampillas"];
                lcsartabanner = textoestampillas.Value;
            }
            return lcsartabanner;
        }

        public void seteawebconfig(string llave,string valor)
        {
           

            System.Configuration.Configuration rootWebConfig1 =
                   System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            
            rootWebConfig1.AppSettings.Settings[llave].Value = valor;
            rootWebConfig1.Save();
        }

    }
    public enum ViewMode
    {
        NuevoComprobante = 1,
        NuevoRegistro = 2,
        Grabar = 3,
        Deshacer = 4,
        Modificar = 5,
        Eliminar = 6,
        Crear = 7,
        Buscar = 8,
        Impromir = 9,
        Actualizar,
        Salir = 11,
        Seleccion,
        None = 0
    }


    public enum TipoConeccion
    {
        Alcaldias = 1,
        Privadas = 2,
        Empresas_sociales_del_estado = 3
    }

