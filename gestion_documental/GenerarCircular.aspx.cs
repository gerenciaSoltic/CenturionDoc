using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Word = Microsoft.Office.Interop.Word;
using System.Data;
using gestion_documental.codigo;
using System.IO;
using gestion_documental.Utils;
using gestion_documental.BusinessObjects;
using gestion_documental.DataAccessLayer;
using System.Net;

namespace gestion_documental
{
    public partial class GenerarCircular : BasePage
    {
        EmiRecep Emisor;
        string ruta_guardar = "";
        string ruta_descargar = "";
        string nombre_archivo = "";
        Class1 proce = new Class1();

        protected void Page_Load(object sender, EventArgs e)
        {

            this.ConfigurarPadrePostBack(this.Msj, this.usuarioLabel);



            try
            {
                Emisor = new EmiRecepManagement().GetEmiRecepByIdusuario(SessionDocumental.UsuarioInicioSession.CODIGO);
                ruta_guardar = Emisor.conficor.CAMINODESCARGA;
                if (ruta_guardar.Trim().Length == 0) { mostrar_mensaje_usuario("El usuario no cuenta con una ruta de archivo para guardar la circular! ..."); }
            }
            catch (Exception error) { string que_paso = error.Message; }

            if (!IsPostBack)
            {
                llenar_formulario();
            }

        }


        private void llenar_formulario()
        {
            try
            {



                DataTable dt_consulta = new DataTable();
                proce.consultacamposcondicion("plantilla_doc", "id, nombre", "idinstitucion = '" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION + "' AND idente = '" + Emisor.IDENTE.ToString() + "'", dt_consulta);
                set_DropDowList(ddl_circular_tipo, dt_consulta, "id", "nombre", true);
                lb_consecutivo.Text = string.Empty;




            }
            catch (Exception Error) { string que_paso = Error.Message; }
        }

        protected void ddl_circular_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lb_consecutivo.Text = string.Empty;
                if (ddl_circular_tipo.SelectedIndex > 0)
                {
                    string srt_id_plantilla = ddl_circular_tipo.SelectedValue;
                    DataTable dt_consulta = new DataTable();
                    proce.consultacamposcondicion("plantilla_doc", "consecutivo, n_digito, prefijo, firma, cargo", "id = '" + srt_id_plantilla + "'", dt_consulta);

                    if (dt_consulta.Rows.Count > 0)
                    {
                        int srt_consecutivo = get_int(dt_consulta.Rows[0]["consecutivo"].ToString()) + 1;
                        int n_digitos = get_int(dt_consulta.Rows[0]["n_digito"].ToString());
                        string prefijo = dt_consulta.Rows[0]["prefijo"].ToString();
                        string anio = DateTime.Now.Year.ToString();

                        TxtCargo.Text = dt_consulta.Rows[0]["cargo"].ToString();
                        TxtFirma.Text = dt_consulta.Rows[0]["firma"].ToString();

                        lb_consecutivo.Text = (prefijo.Trim().Length > 0 ? prefijo + "-" : "") + anio + get_numeral_consecutivo(srt_consecutivo, n_digitos);
                    }
                }

            }
            catch (Exception error) { string que_paso = error.Message; }
        }

        protected void btn_previo_Click(object sender, EventArgs e)
        {
            generar_documento(1);
            if (nombre_archivo.Trim().Length > 0) { funcion_mostrar_pdf(nombre_archivo); }
        }



        private void generar_documento(int numero)
        {
            string seguimiento = "instancia_word = null";
            GestionWord instancia_word = null;
            try
            {
                if (txt_contenido_doc.Text.Trim().Length > 0 && ddl_circular_tipo.SelectedIndex > 0 && lb_consecutivo.Text.Trim().Length > 0)
                {
                    string srt_id_plantilla = ddl_circular_tipo.SelectedValue;
                    DataTable dt_consulta = new DataTable();
                    proce.consultacamposcondicion("plantilla_doc", "url_file, firma, cargo", "id = " + srt_id_plantilla, dt_consulta);
                    string fichero = dt_consulta.Rows[0]["url_file"].ToString();

                    string firma = TxtFirma.Text.Trim();
                    string cargo = TxtCargo.Text.Trim();

                    //string fichero = "prueba.docx";
                    fichero = HttpContext.Current.Server.MapPath(fichero);

                    if (validarExistenciaArchivo(fichero))
                    {

                        string srt_contenido = txt_contenido_doc.Text.Trim();
                        srt_contenido = srt_contenido.Replace("\n", "\r");


                        instancia_word = new GestionWord();
                        seguimiento += "   new gestionword()";
                        instancia_word.duplicar_word(fichero);
                        seguimiento += "   duplicar archivos";
                        //instancia_word.cargar_fichero_word();
                        string ArchivoTemporal = "";
                        instancia_word.cargar_fichero_word_2(ref ArchivoTemporal);
                        seguimiento += "   fichero cargado";
                        instancia_word.reemplazar_texto_2("Consecutivo", lb_consecutivo.Text.Trim());
                        instancia_word.reemplazar_texto_2("Fecha", DateTime.Now.ToString("dd, MMMM 'de' yyyy"));
                        instancia_word.reemplazar_texto_2("Firma", firma);
                        instancia_word.reemplazar_texto_2("Cargo", cargo);
                        instancia_word.reemplazar_texto_2("Contenido", srt_contenido);

                        instancia_word.SaveDocument_2();

                        
                            // ruta_descargar = instancia_word.export_to_pdf();
                            // Response.Redirect(ArchivoTemporal);
                            string remoteUri = "plantilla//TMP//";
                            string fileName = SessionDocumental.UsuarioInicioSession.CODIGO.ToString() + ".docx";
                            ruta_descargar = remoteUri + "/" + fileName;
                            if (numero == 1)
                            {
                            Response.Redirect("~/" + remoteUri + "/" + fileName, "_blank", "menubar=0,scrollbars=1,width=780,height=900,top=10");
                            //funcion_mostrar_pdf(fileName);
                        }
                        instancia_word.vaciar_tmp();

                        
                        /*
                         
                        
                        // Create a new WebCliee(myStringWebResource, fileName);	
                        
                        // instancia_word.export_to_pdf();
                        
                       // if (ruta_descargar.Trim().Length == 0) { mostrar_mensaje_usuario("NO SE PUDO GENERAR EL PDF, SI PERSISTE POR FAVOR COMUNÍQUESE CON EL DESARROLLADOR"); return; }

                       // nombre_archivo = System.IO.Path.GetFileName(ruta_descargar);

                        //funcion_mostrar_pdf(nombre_archivo);

                        //// funcion_descargar_fichero(ruta_descargar);
                        //if (mostrar) { funcion_mostrar_pdf(nombre_archivo); }
                        //else { funcion_descargar_fichero(ruta_descargar); }

                        */
                    }
                    else { mostrar_mensaje_usuario("NO  SE ENCUENTRA LA PLANTILLA EN EL SISTEMA, POR FAVOR COMUNÍQUESE CON EL ADMINISTRADOR ..."); }
                }
                else { mostrar_mensaje_usuario("POR FAVOR VERIFIQUE TIPO DE PLANTILLA, CONTENIDO DEL DOCUMENTO Y EL CONSECUTIVO SEA VALIDO"); }


            }
            catch (Exception error)
            {
                mostrar_mensaje_usuario(error.Message + "   " + seguimiento);
                //mostrar_mensaje_usuario("ERROR DOCUMENTO");
                if (instancia_word != null) { instancia_word.vaciar_tmp(); }
            }
        }




        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddl_circular_tipo.SelectedIndex > 0)
                {
                    if (lb_consecutivo.Text.Trim().Length == 0) { return; }

                    if (txt_contenido_doc.Text.Trim().Length > 0)
                    {
                        generar_documento(2);

                        ruta_descargar = HttpContext.Current.Server.MapPath(ruta_descargar); 
                        if (ruta_descargar.Trim().Length > 0)
                        {
                            if (validarExistenciaArchivo(ruta_descargar))
                            {
                                string consecutivo = lb_consecutivo.Text.Trim();
                                string file_source = ruta_descargar;
                                string nombre_documento = consecutivo + ".docx";
                                string file_destino = getConcatenarRutaGuardar(nombre_documento);
                                File.Copy(file_source, file_destino, true);

                                if (validarExistenciaArchivo(file_destino))
                                {
                                    string fecha_registro = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");
                                    string camino = Emisor.conficor.CAMINODESCARGA.Trim().Replace("\\", "//");
                                    int id_circular = proce.insertaralgunos("circular", "plantilla, consecutivo, CAMINO, DOCUMENTO, IDENTE, fecregistro, idinstitucion",
                                        "'" + ddl_circular_tipo.SelectedItem.Text.Trim() + "', '" + consecutivo + "', '" + camino + "', '" + nombre_documento + "', '" + Emisor.IDENTE.ToString() + "', '" + fecha_registro + "', '" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION.ToString() + "'");

                                    if (id_circular > 0)
                                    {
                                        //Modificando consecutivo --------------------------------
                                        string srt_id_plantilla = ddl_circular_tipo.SelectedValue;
                                        proce.editar("plantilla_doc", "consecutivo = consecutivo + 1", "id = '" + srt_id_plantilla + "'");
                                        //--------------------------------------------------------
                                        ddl_circular_tipo.SelectedIndex = 0;
                                        lb_consecutivo.Text = string.Empty;
                                        txt_contenido_doc.Text = string.Empty;
                                        TxtFirma.Text = string.Empty;
                                        TxtCargo.Text = string.Empty;

                                        //--------------------------------------------------------
                                        mostrar_mensaje_usuario("SU CIRCULAR ES " + consecutivo);
                                        funcion_descargar_fichero(file_destino);
                                    }
                                    else { mostrar_mensaje_usuario("NO SE PUDO GENERAR EL CIRCULAR"); }
                                }
                                else { mostrar_mensaje_usuario("EL FICHERO NO SE GENERO CORRECTAMENTE"); }
                            }
                            else { mostrar_mensaje_usuario("Archivo no encontrado ..."); }
                        }
                    }
                }
            }
            catch (Exception Error)
            {
                string que_paso = Error.Message;
                mostrar_mensaje_usuario("ERROR EN GENERAR LA CIRCULAR, SI PERSISTE COMUNÍQUESE CON EL DESARROLLADOR DEL SISTEMA ...");
            }
        }


        private void mostrar_mensaje_usuario(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('" + mensaje + "');", true);
        }

        private void set_DropDowList(DropDownList item, DataTable objeto, string id, string text, bool con_select = false)
        {
            item.DataSource = objeto;
            item.DataValueField = id;
            item.DataTextField = text;
            item.DataBind();

            if (con_select)
            {
                item.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }
        }

        private string get_numeral_consecutivo(int numero, int n_digitos = 11)
        {
            string srt_consecutivo = "";
            //int n_digitos = 11;
            int n_digito_numero = numero.ToString().Trim().Length;

            for (int i = 1; i <= n_digitos; i++) { if (n_digito_numero < i) { srt_consecutivo += "0"; } }
            srt_consecutivo += numero.ToString();

            return srt_consecutivo;
        }

        public static string RutaArchivoGeneral = @"~/plantilla/Formatos/";
        //---------------------------------------------------------
        protected string getConcatenarRuta(string fichero)
        {
            string Respuesta = "";
            try
            {
                string ruta_temp = RutaArchivoGeneral;
                if (fichero != null) { ruta_temp = Path.Combine(RutaArchivoGeneral, fichero); }
                Respuesta = HttpContext.Current.Server.MapPath(ruta_temp);
            }
            catch (Exception Error) { string que_paso = Error.Message; Respuesta = ""; }


            return Respuesta;
        }
        protected string getConcatenarRutaGuardar(string fichero)
        {
            string Respuesta = "";
            try
            {
                string ruta_temp = ruta_guardar;
                if (fichero != null) { ruta_temp = Path.Combine(ruta_guardar, fichero); }
                Respuesta = HttpContext.Current.Server.MapPath(ruta_temp);
            }
            catch (Exception Error) { string que_paso = Error.Message; Respuesta = ""; }


            return Respuesta;
        }
        public bool EliminarFichero(string url_completa)
        {
            bool Respuesta = false;
            try
            {
                if (validarExistenciaArchivo(url_completa))
                {
                    string ruta_completa = Path.GetFullPath(url_completa);
                    File.Delete(ruta_completa);
                    Respuesta = true;
                }
            }
            catch (Exception Error) { string que_paso = Error.Message; Respuesta = false; }

            return Respuesta;
        }
        public bool validarExistenciaArchivo(string url_completa)
        {
            bool Respuesta = false;
            try
            {
                string ruta_completa = url_completa;
                Respuesta = File.Exists(ruta_completa);
            }
            catch (Exception error) { string que_paso = error.Message; Respuesta = false; }
            return Respuesta;
        }
        private void funcion_descargar_fichero(string archivo_ruta_completa)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenWindow", "window.open('" + Page.ResolveUrl("~/descargar.aspx?file=" + Server.UrlEncode(archivo_ruta_completa)) + "','_newtab');", true);
        }
        private void funcion_mostrar_pdf(string archivo)
        {
            Response.Redirect("~/plantilla/TMP/" + archivo, "_blank", "menubar=0,scrollbars=1,width=850,height=700,top=10");
        }

        //Funciones para obtener valores sin errores--------------------------------
        private double get_double(string valor)
        {
            try { return (valor.Trim().Length > 0 ? Convert.ToDouble(valor) : 0); }
            catch { return 0; }
        }
        //
        private Int32 get_int(string valor)
        {
            try { return (valor.Trim().Length > 0 ? Convert.ToInt32(valor) : 0); }
            catch { return 0; }
        }


        //--------------------------------------------------------------------------
    }


}