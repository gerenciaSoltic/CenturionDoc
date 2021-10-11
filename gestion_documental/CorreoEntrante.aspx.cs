using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestion_documental.Utils;
using gestion_documental.DataAccessLayer;
using gestion_documental.BusinessObjects;
using GESTIONDOCUMENTAL.Utils;
using System.Data;

using gestion_documental.DataAccessLayer;
using gestion_documental.BusinessObjects;
using GESTIONDOCUMENTAL.Utils;
using System.Data;

using gestion_documental.DataAccessLayer;
using gestion_documental.BusinessObjects;
using GESTIONDOCUMENTAL.Utils;
using System.Data;

using gestion_documental.BusinessObjects;
using gestion_documental.DataAccessLayer;
using gestion_documental.Utils;
using OpenPop.Pop3;
using OpenPop.Mime.Header;
using OpenPop.Mime;
using System.IO;

namespace gestion_documental
{
    public partial class CorreoEntrante : BasePage
    {
        EmiRecep emisorRecep;
        IndicesManagement _indice = new IndicesManagement();
        subserieIndiceManagement _subserie = new subserieIndiceManagement();
        Class1 proce = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ConfigurarPadrePostBack(this.Msj, this.usuarioLabel);

            if (!IsPostBack)
            {
               
                emisorRecep = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
                emisorRecep.conficor = new ConfiCorManagement().GetConfiCorById(emisorRecep.IDCONFICOR);
                DdlSerie.DataSource = new SerieManagement().GetASeriesEnte(emisorRecep.IDENTE);
                DdlSerie.DataBind();
                DdlSerie.Items.Insert(0, new ListItem("Seleccionar", "0"));
                DdlSerie.SelectedValue = "0";

                validarCuenta();
                
            }

        }

        protected void DdlSubserie_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvindices.DataSource = "";
            gvindices.DataBind();

            EmiRecep ObjEmirecep = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);

            DdlTipologia.Enabled = true;

            DdlTipologia.DataSource = new TipologiaManagement().GetATipologiaEnte(Convert.ToInt32(DdlSubserie.SelectedValue.ToString()), ObjEmirecep.IDENTE);
            DdlTipologia.DataBind();
            DdlTipologia.Items.Insert(0, new ListItem("Seleccionar", "0"));
            DdlTipologia.SelectedValue = "0";

            DdlExpediente.DataSource = new ExpedienteManagement().GetAllExpedienteBySubserie(Convert.ToInt32(DdlSubserie.SelectedValue.ToString()), ObjEmirecep.IDENTE);
            DdlExpediente.DataBind();
            DdlExpediente.Items.Insert(0, new ListItem("Seleccionar", "0"));
            DdlExpediente.SelectedValue = "0";
            DdlExpediente.Enabled = true;

            List<subserieIndice> subindices = new List<subserieIndice>();

            subindices = _subserie.GetAllsubserieIndice(Convert.ToInt32(DdlSerie.SelectedValue.ToString()), Convert.ToInt32(DdlSubserie.SelectedValue.ToString()));
            gvindices.DataSource = subindices;
            gvindices.DataBind();

        }



        protected void DdlSerie_SelectedIndexChanged(object sender, EventArgs e)
        {

            EmiRecep ObjEmirecep = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
            DdlSubserie.Enabled = true;

            DdlSubserie.DataSource = new SubSerieManagement().GetASubSerieEnte(Convert.ToInt32(DdlSerie.SelectedValue.ToString()), ObjEmirecep.IDENTE);
            DdlSubserie.DataBind();
            DdlSubserie.Items.Insert(0, new ListItem("Seleccionar", "0"));
            DdlSubserie.SelectedValue = "0";
        }

        protected void DdlExpediente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DdlTipologia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void validarCuenta()
        {
            try
            {
                using (Pop3Client client = new Pop3Client())
                {
                    // Connect to the server
                    client.Connect(
                        emisorRecep.conficor.SERVPOPENTRANTE.Split(':')[0],
                        Convert.ToInt32(emisorRecep.conficor.SERVPOPENTRANTE.Split(':')[1]), true);

                    // Authenticate ourselves towards the server
                    client.Authenticate(
                        emisorRecep.conficor.EMAIL.ToString(),
                        emisorRecep.conficor.CONTRASENA.ToString());

                    procesarCorreos(client);
                }
            }
            catch (Exception ex)
            {
                this.textoMensaje.Visible = false;
                
                BtnRegistrar   .Visible = false;
                this.PintarMsjError("Imposible Conectar al servidor."+ex.Message.ToString());
            }
        }
        protected void procesarCorreos( Pop3Client cliente )
        {
            List<gestion_documental.BusinessObjects.CorreoEntrante> correos = new List<gestion_documental.BusinessObjects.CorreoEntrante>();
            EmiRecep receptor = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
           // correos = new  CorreoEntranteManagement().correosNoProcePorIdrecep(Convert.ToInt32(receptor.ID));
            
            int cant= cliente.GetMessageCount();
            for (int i = cant; i > 0; i--)
            {
               
                MessageHeader cabecera = cliente.GetMessageHeaders(i);

                receptor = new EmiRecep();
                receptor = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
                DateTime ldFechaCorreo = cabecera.DateSent.ToLocalTime();
                if ( ldFechaCorreo< receptor.conficor.FECHAARRANQUE)
                {
                    i = 0;
                } 

                if (cabecera.DateSent >=  receptor.conficor.FECHAARRANQUE && i != 0)
                {
                   
                    DataTable YACORREO = new DataTable();
                    proce.consultacamposcondicion("correoentrante", "id", "idreceptor =" + receptor.ID + " AND fecha = '" + proce.formateafecha(ldFechaCorreo, 1) + "' AND auxEmailEmisor ='" + cabecera.From.Address.Trim() + "' AND asunto='" + cabecera.Subject.ToString() + "'", YACORREO);
                    if (YACORREO.Rows.Count != 0)
                    {
                        i = 0;
                    }

                    if (YACORREO.Rows.Count ==0)
                    {
                Message message = cliente.GetMessage(i);

                System.Net.Mail.MailMessage mailMessage = message.ToMailMessage();

                gestion_documental.BusinessObjects.CorreoEntrante correo = null;

                if ((cabecera != null && message != null) || (cabecera.From.Address.Trim() != receptor.conficor.EMAIL.Trim()))
                {
                    try
                    {

                        correo = new gestion_documental.BusinessObjects.CorreoEntrante();
                        correo.ASUNTO = cabecera.Subject;
                        correo.FECHA = ldFechaCorreo;
                        correo.DESCRECEPTOR = receptor.DESCRIPCION;
                        correo.IDTIPOLOGIA = 1;
                        correo.RADICADO = "";
                        correo.PROCESADO = 0;
                        correo.IDRECEPTOR = receptor.ID;
                        correo.auxEmailEmisor = cabecera.From.Address.Trim();
                        //correo.index = i;

                        int longitud = mailMessage.Body.Length;
                        if (longitud > 1000)
                        {
                            correo.TEXTO = StripHTML(mailMessage.Body);
                        }
                        else
                        {

                            correo.TEXTO = StripHTML(mailMessage.Body);

                        }
                        // correo.TEXTO = mailMessage.Body;
                        EmiRecep emisor = new EmiRecepManagement().GetEmiRecepByEmail(cabecera.From.Address);
                        if (emisor.ID > 0)
                        {
                            correo.IDEMISOR = emisor.ID;
                            correo.DESCEMISOR = emisor.DESCRIPCION;


                        }
                        else
                        {
                            emisor.DESCRIPCION = cabecera.From.Address;
                            emisor.NIT = "x";
                            emisor.IDTIPOEMISOR = 3;
                            emisor.IDRADICADO = receptor.IDRADICADO;
                            emisor.IDENTE = 64;
                            emisor.EMAIL = cabecera.From.Address;
                            correo.IDEMISOR = new EmiRecepManagement().InsertEmiRecep(emisor);
                            correo.auxEmailEmisor = cabecera.From.Address;
                            correo.DESCEMISOR = emisor.DESCRIPCION;




                        }

                        if (correo.IDEMISOR != correo.IDRECEPTOR)
                        {
                            correo.ID = new CorreoEntranteManagement().InsertCorreoEntrante(correo);
                        }
                    }


                    catch
                    {
                        int a = 0;
                    }

                    if (message != null && correo.IDEMISOR != correo.IDRECEPTOR)
                    {
                        try
                        {
                            Adjuntos archivo;

                            int lnAdjuntos = message.FindAllAttachments().Count;
                            for (int j = 0; j < lnAdjuntos; j++)
                            {
                                MessagePart attachment = message.FindAllAttachments().ElementAt(j);
                                if (attachment.FileName != "(no name)")
                                {

                                    archivo = new Adjuntos();
                                    archivo.IDCORREO = correo.ID;
                                    archivo.ARCHIVO = attachment.FileName;
                                    archivo.NEWARCHIVO = correo.RADICADO + (j < 10 ? "_0" : "_") + j + Path.GetExtension(attachment.FileName);

                                    /*if (!System.IO.Directory.Exists(Server.MapPath("\\")+"\\"+  emisorRecep.conficor.CAMINODESCARGA))*/

                                    if (!System.IO.Directory.Exists(Server.MapPath("~") + "\\" + emisorRecep.conficor.CAMINODESCARGA))
                                    {
                                        System.IO.Directory.CreateDirectory(Server.MapPath("~") + "\\" + emisorRecep.conficor.CAMINODESCARGA);
                                    }
                                    File.WriteAllBytes(Server.MapPath("~") + "\\" + emisorRecep.conficor.CAMINODESCARGA + "\\" + archivo.ARCHIVO, attachment.Body);

                                    new AdjuntosManagement().InsertAdjuntos(archivo);
                                }
                            }




                            correos.Insert(0, correo);
                        }
                        catch
                        {
                            int a = 0;
                        }

                    }
                }

                }
            
        }
            
    }
            SessionDocumental.CorreosElectronicos = correos;
            SessionDocumental.CountMensajes = correos.Count;
            cargarCorreosElectronicos();     
        }
            
        
     
        private void cargarCorreosElectronicos( )
        {
            //List<gestion_documental.BusinessObjects.CorreoEntrante> correos = new List<gestion_documental.BusinessObjects.CorreoEntrante>();
            EmiRecep receptor = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
            //correos = new CorreoEntranteManagement().correosNoProcePorIdrecep(Convert.ToInt32(receptor.ID));
            DataTable correos = new DataTable();
            proce.ConsultaSql("SELECT  c.ID,c.IDEMISOR,e.descripcion as DESCEMISOR,r.DESCRIPCION as DESCRECEPTOR,c.IDRECEPTOR,c.idtipologia,c.radicado,c.procesado,c.asunto,c.texto,c.fecha,c.auxemailemisor FROM correoentrante c,emirecep e,emirecep r WHERE c.idemisor =e.id and c.idreceptor = r.id and c.procesado <> 1 and c.idreceptor = "+receptor.ID.ToString()+ " and c.eliminado = 0 ORDER BY fecha DESC",correos);
            correosGridView.DataSource = correos;
            correosGridView.DataBind();
        }
        private void cargarArchivosPorCorreo()
        {
            AdjuntosGridView.DataSource = SessionDocumental.ArchivosPorCorreo;
            AdjuntosGridView.DataBind();
        }
        protected void AdjuntosGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
            

        }


        protected void AdjuntosdGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            SessionDocumental.CorreoVer = SessionDocumental.CorreosElectronicos.ElementAt(Convert.ToInt32(e.CommandArgument));
            switch (e.CommandName)
            {
                case "Descargar":


                    break;
            }
        }
        


        protected void CorreosGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerCorreo" || e.CommandName == "ReenviarButton" || e.CommandName == "EliminarButton")
            SessionDocumental.CorreoVer = SessionDocumental.CorreosElectronicos.ElementAt(Convert.ToInt32(e.CommandArgument));

            emisorRecep = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
            switch (e.CommandName)
            {
                case "VerCorreo":
                    List<Adjuntos> archivos = new AdjuntosManagement().GetAdjuntosByIdCorreo(SessionDocumental.CorreoVer.ID);

                    SessionDocumental.CorreoVer.adjuntos = archivos;
                    SessionDocumental.ArchivosPorCorreo = archivos;
                    textoMensaje.Value = StripHTML(SessionDocumental.CorreoVer.TEXTO);
                    TxtRadicado.Text = new RadicadosManagement().GetRadicadoExterno(emisorRecep,true).Radicado;
                    cargarArchivosPorCorreo();
                    break;
                case "ReenviarButton":
                    Reenviar();
                    break;
                case "EliminarButton":
                    Eliminar();
                    break;

            }
        }
        private void Reenviar()
        {
            if (SessionDocumental.CorreoVer != null)
            {
                SessionDocumental.CorreoReenvio = SessionDocumental.CorreoVer;
                SessionDocumental.CorreoVer = null;

                Session.Add("Asunto", SessionDocumental.CorreoReenvio.ASUNTO.ToString());
                Session.Add("TextoMail", SessionDocumental.CorreoReenvio.TEXTO.ToString());
                Session.Add("idEmisor", SessionDocumental.CorreoReenvio.IDEMISOR);

                String TxtAsunto = SessionDocumental.CorreoReenvio.ASUNTO.ToString();
                String TxtCuerpo = SessionDocumental.CorreoReenvio.TEXTO.ToString();

                Response.Redirect("Corrsal.aspx");

                Session.Remove("idEmisor");
            }
            

            
        }

        private void Eliminar()
        {


            proce.editar("correoentrante", "eliminado= 1", "id =" + correosGridView.SelectedDataKey.Values[0].ToString());
                 cargarCorreosElectronicos();
                //Response.Redirect(Resources.ResourceGlobal.UrlBase + Resources.ResourceGlobal.UrlCorreoSaliente);
                
           
        }

       

        

        protected void AdjuntosGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
        }

        private string StripHTML(string source)
        {
            try
            {
                string result;

                // Remove HTML Development formatting
                // Replace line breaks with space
                // because browsers inserts space
                result = source;
                // Replace line breaks with space
                // because browsers inserts space
              
                // Remove repeating spaces because browsers ignore them
                result = System.Text.RegularExpressions.Regex.Replace(result,
                                                                      @"( )+", " ");

                // Remove the header (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*head([^>])*>", "<head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*head( )*>)", "</head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<head>).*(</head>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all scripts (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*script([^>])*>", "<script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*script( )*>)", "</script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                //result = System.Text.RegularExpressions.Regex.Replace(result,
                //         @"(<script>)([^(<script>\.</script>)])*(</script>)",
                //         string.Empty,
                //         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<script>).*(</script>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all styles (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*style([^>])*>", "<style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*style( )*>)", "</style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<style>).*(</style>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert tabs in spaces of <td> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*td([^>])*>", "\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line breaks in places of <BR> and <LI> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*br( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*li( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line paragraphs (double line breaks) in place
                // if <P>, <DIV> and <TR> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*div([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*tr([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*p([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // Remove remaining tags like <a>, links, images,
                // comments etc - anything that's enclosed inside < >
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<[^>]*>", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // replace special characters:
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @" ", " ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&bull;", " * ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&lsaquo;", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&rsaquo;", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&trade;", "(tm)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&frasl;", "/",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&lt;", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&gt;", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&copy;", "(c)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&reg;", "(r)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&(.{2,6});", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // for testing
                //System.Text.RegularExpressions.Regex.Replace(result,
                //       this.txtRegex.Text,string.Empty,
                //       System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // make line breaking consistent
                result = result.Replace("\n", "\r");

                // Remove extra line breaks and tabs:
                // replace over 2 breaks with 2 and over 4 tabs with 4.
                // Prepare first to remove any whitespaces in between
                // the escaped characters and remove redundant tabs in between line breaks
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\t)", "\t\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\r)", "\t\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\t)", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove redundant tabs
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove multiple tabs following a line break with just one tab
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Initial replacement target string for line breaks
                string breaks = "\r\r\r";
                // Initial replacement target string for tabs
                string tabs = "\t\t\t\t\t";
                for (int index = 0; index < result.Length; index++)
                {
                    result = result.Replace(breaks, "\r\r");
                    result = result.Replace(tabs, "\t\t\t\t");
                    breaks = breaks + "\r";
                    tabs = tabs + "\t";
                }

                // That's it.
                return result;
            }
            catch
            {
                return source;
            }
        }

        protected void AdjuntosGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            emisorRecep = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
            emisorRecep.conficor = new ConfiCorManagement().GetConfiCorById(emisorRecep.IDCONFICOR);
            string lcArchivo = AdjuntosGridView.SelectedDataKey.Value.ToString(); 
            Response.Redirect("~/" + emisorRecep.conficor.CAMINODESCARGA.ToString() + "/" +lcArchivo, "_blank", "menubar=0,scrollbars=1,width=780,height=900,top=10");
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {

            
            int contador = 0;
            bool okAtributos = true;

            foreach (GridViewRow row in gvindices.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    TextBox indice = (row.Cells[0].FindControl("txtatributo") as TextBox);
                    if (indice.Text.ToString().Trim().Length < 1)
                    {
                        contador = 1;

                    }
                }
            }
           

            if (contador == 0 )
            {
                /*  validar que esten seleccionados la serie y etc  */

            
           
                if (DdlSerie.SelectedValue == "0" || DdlSerie.SelectedValue == "") okAtributos = false;
                if (DdlSubserie.SelectedValue == "0" || DdlSubserie.SelectedValue == "") okAtributos = false;
                if (DdlTipologia.SelectedValue == "0" || DdlTipologia.SelectedValue == "") okAtributos = false;
                if (DdlExpediente.SelectedValue == "0" || DdlExpediente.SelectedValue == "") okAtributos = false;
               
                okAtributos = true;
                if (okAtributos)
                {
                   
                    EmiRecep receptor = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
                    Cadenas MyCadena = new Cadenas();
                    MyCadena.FECHA = DateTime.Now;
                   int lnIdCadena = new CadenasManagement().InsertCadenas(MyCadena);


                    // Radicado

                   gestion_documental.BusinessObjects.CorreoEntrante listacorreo = new CorreoEntranteManagement().GetCorreoEntranteById(Convert.ToInt32(correosGridView.SelectedDataKey.Values[0]));

                   emisorRecep = new EmiRecepManagement().GetEmiRecepById(listacorreo.IDEMISOR);
                   
                  



                   textoMensaje.Value = StripHTML(listacorreo.TEXTO);
                   obtieneRadicado(emisorRecep.ID, receptor.ID);

                   crearDocumento();
                   crearWorkfow(lnIdCadena);
                   new RadicadosManagement().UpdateRadicados(new RadicadosManagement().GetRadicadoExterno(receptor,true));
                   new CorreoEntranteManagement().UpdateCorreoEntrantebyId(Convert.ToInt32(correosGridView.SelectedDataKey.Values[0]),TxtRadicado.Text);
                  
               
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Correo Integrado a Gestión documental con Exito..');", true);
                }
                else
                     ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe Ingresar Serie,subserie,tipologia.....');", true);


            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe Ingresar Todos Los Indices...');", true);

            }


            validarCuenta();


        }


        protected void crearDocumento()
        {

            EmiRecep receptor = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
            EmiRecep emisor = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(correosGridView.SelectedDataKey.Values[1]));
            
            List<Adjuntos> CorreAdjun = new AdjuntosManagement().GetAdjuntosByIdCorreo(Convert.ToInt32(correosGridView.SelectedDataKey.Values[0]));
            string carpetaDestino = receptor.conficor.CAMINODESCARGA;

            for (int iAdjuntos = 0 ;iAdjuntos < CorreAdjun.Count;iAdjuntos++)
            {
                Documentos documento = new Documentos();
               
                documento.IDSERIE = Convert.ToInt32(DdlSerie.SelectedValue);
                documento.IDSUBSERIE = Convert.ToInt32(DdlSubserie.SelectedValue);
                documento.IDTIPOLOGIA = Convert.ToInt32(DdlTipologia.SelectedValue); ;
                documento.IDEXPEDIENTE = Convert.ToInt32(DdlExpediente.SelectedValue); 
                
                documento.FOLIOS = 1;
                documento.ANEXOS = "";
                documento.DOCUMENTO = CorreAdjun[iAdjuntos].ARCHIVO;
                 documento.CAMINO = carpetaDestino.Replace("\\","//");

                documento.IDENTE = 0;
      
                 documento.idDOCUMENTOS = new DocumentosManagement().InsertDocumentos(documento);
                 SessionDocumental.ObjDocumento = documento;

                 LinkDoc links = new LinkDoc();
                 links.IDDOCUMENTOS = documento.idDOCUMENTOS;
                 links.IDENTE = receptor.IDENTE;

                 links.IDSERIE = Convert.ToInt32(DdlSerie.SelectedValue);
                 links.IDSUBSERIE = Convert.ToInt32(DdlSubserie.SelectedValue);
                 links.IDTIPOLOGIA = Convert.ToInt32(DdlTipologia.SelectedValue); ;
                 links.IDEXPEDIENTE = Convert.ToInt32(DdlExpediente.SelectedValue); 
                

                 new LinkDocManagement().InsertLinkDoc(links);
                //
                 int contador = 0;

                 foreach (GridViewRow row in gvindices.Rows)
                 {
                     if (row.RowType == DataControlRowType.DataRow)
                     {
                         TextBox indice = (row.Cells[0].FindControl("txtatributo") as TextBox);
                         if (indice.Text.ToString().Trim().Length < 1)
                         {
                             contador = 1;

                         }
                     }
                 }
                 if (contador == 0)
                 {


                     foreach (GridViewRow row in gvindices.Rows)
                     {
                         if (row.RowType == DataControlRowType.DataRow)
                         {
                           TextBox indice = (row.Cells[0].FindControl("txtatributo") as TextBox);
                            Indices insert = new Indices();
                            insert.ATRIBUTO = row.Cells[0].Text;
                            insert.INDICE = indice.Text;
                            insert.iddocumento = documento.idDOCUMENTOS;
                            _indice.InsertIndices(insert);

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('actualizacion realizada con exito...');", true);

                              
                             
                         }
                     }
                 }
                 else
                 {
                     ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe Ingresar Todos Los Indices...');", true);

                 }
                //

                /*
                  //Inserta indices
                 for (int iInd = 0; iInd < lista.Items.Count; iInd++)
                    {
                    Indices indice = new Indices();
                     indice.ATRIBUTO = "";
                     indice.iddocumento = documento.idDOCUMENTOS;
                     indice.INDICE = lista.Items[iInd].Text;
                     new IndicesManagement().InsertIndices(indice);
                    

                    }
                 
                */
            }
        }

        protected void obtieneRadicado(int tcIdDe, int tcIdPara)
        {
            EmiRecep Para = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(tcIdPara));
            EmiRecep De = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(tcIdDe));
            Radicados radicado = new Radicados();
            SessionDocumental.ObjEmisorOrigen = De;
            SessionDocumental.ObjEmisorDestino = Para;

            if (Para.ID != 0 && De.ID != 0)
            {
                radicado = new RadicadosManagement().GetRadicadoActual(De, Para,true);
                TxtRadicado.Text = radicado.Radicado;
                string lcPrefijo = "";
                if (radicado.PrefCorrSal.Trim() == TxtRadicado.Text.Substring(0, radicado.PrefCorrSal.Trim().Length))
                {
                    lcPrefijo = radicado.PrefCorrSal.Trim();
                }
                if (radicado.PrefCorrEnt.Trim() == TxtRadicado.Text.Substring(0, radicado.PrefCorrEnt.Trim().Length))
                {
                    lcPrefijo = radicado.PrefCorrEnt.Trim();
                }

                if (radicado.prefInter.Trim() == TxtRadicado.Text.Substring(0, radicado.prefInter.Trim().Length))
                {
                    lcPrefijo = radicado.prefInter.Trim();
                }


                int lnRadicado = Convert.ToInt32(TxtRadicado.Text.Substring(lcPrefijo.Length + 4));
                // Ahora miramos si el radicado ya existe
                bool llExiste = true;
                while (llExiste)
                {
                    Workflow ExisteRad = new Workflow();
                    ExisteRad = new WorkFlowManagement().GetWorkflowByRadicado(TxtRadicado.Text);
                    if (ExisteRad.RADICADO == "")
                    {
                        llExiste = false;
                    }
                    else
                    {
                        lnRadicado = lnRadicado + 1;
                        TxtRadicado.Text = lcPrefijo + Convert.ToDateTime(radicado.UltimaFecha).Year.ToString();
                        if (lnRadicado.ToString().Length < 4)
                        {
                            TxtRadicado.Text =TxtRadicado.Text+lnRadicado.ToString().PadLeft(4,'0');
                        }
                    }
                }
                //
            }



        }
           

           // Insertamos en links el de la ventanilla y el nuevo

           




            //inserta radicados
           
           
         
           

      

        
        protected void crearWorkfow(int lnIdCadena)
        {
            Workflow  workflow = new Workflow();

            EmiRecep emisor = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(correosGridView.SelectedDataKey.Values[1]));
            EmiRecep receptor = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
          
            workflow.IDENTEORIGEN = Convert.ToInt32(emisor.IDENTE);
            workflow.IDENTEDESTINO = Convert.ToInt32(receptor.IDENTE);
            workflow.IDEMIRECEP = emisor.ID;
            workflow.IDEMIDESTINO = receptor.ID;

            workflow.FECHA = Convert.ToDateTime(correosGridView.SelectedDataKey.Values[2].ToString());
            workflow.iddocumento = 0;
            if (SessionDocumental.ObjDocumento != null) workflow.iddocumento = SessionDocumental.ObjDocumento.idDOCUMENTOS;

            workflow.RADICADO = TxtRadicado.Text;  
            workflow.IDTAREA = 1;
            workflow.IDTIPOLOGIA = 0;
            workflow.DIAS = new ConfigwfManagement().GetConfigwfById(receptor.IDENTE).DIAS;
            workflow.ESTADO = "2. EN PROCESO";
            workflow.OBSERVACION = "CORREO ELECTRONICO";
            workflow.TIPO = "C";
            workflow.IDCADENA = lnIdCadena;

            new WorkFlowManagement().InsertWorkflow(workflow);
            

        }

        protected void correosGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
           
        }

        protected void correosGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        
           gestion_documental.BusinessObjects.CorreoEntrante listacorreo = new CorreoEntranteManagement().GetCorreoEntranteById(Convert.ToInt32(correosGridView.SelectedDataKey.Values[0]));

           //emisorRecep = new EmiRecepManagement().GetEmiRecepById(listacorreo.IDEMISOR);
                    List<Adjuntos> archivos = new AdjuntosManagement().GetAdjuntosByIdCorreo(Convert.ToInt32(correosGridView.SelectedDataKey.Values[0]));
                    //EmiRecep receptor = new EmiRecepManagement().GetEmiRecepByCodUsuario(listacorreo.IDRECEPTOR);

                  
                     
                    textoMensaje.Value = StripHTML(listacorreo.TEXTO);
                    obtieneRadicado(listacorreo.IDEMISOR, listacorreo.IDRECEPTOR);

                    AdjuntosGridView.DataSource = archivos;
                    AdjuntosGridView.DataBind();
             
        }

        protected void correosGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            correosGridView.PageIndex = e.NewPageIndex;
            cargarCorreosElectronicos();
        }

        protected void correosGridView_PageIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void correosGridView_Init(object sender, EventArgs e)
        {

        }

        protected void correosGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           
        }

        protected void correosGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // reference the Delete LinkButton
                LinkButton db = (LinkButton)e.Row.Cells[4].Controls[0];

                db.OnClientClick = "return confirm('Esta seguro que desea eliminar ?');";
            }
        }

        protected void correosGridView_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
           
        }

        protected void correosGridView_DeleteEventHandler(object sender, GridViewDeleteEventArgs e)
        {
            Eliminar();
        }

       





      

        
      
    }
} 
