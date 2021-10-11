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
using System.Threading;


namespace gestion_documental
{
    public partial class digitaliza : BasePage
    {
        EmiRecep receptor ;

        protected void Page_Load(object sender, EventArgs e)
        {
           
                
            if (!IsPostBack)
            {

                DdlEntes.DataValueField = "IDENTE";
                DdlEntes.DataTextField = "DESCRIPCION";

                DdlEntes.DataSource = new EnteManagement().GetAllEntes();
                DdlEntes.DataBind();
                DdlEntes.Enabled = true;
                DdlEntes.Items.Insert(0, new ListItem("Seleccionar", "0"));
                DdlEntes.SelectedValue = "0";    

            }
        }
            
        
        
        protected void DdlSubserie_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlTipologia.DataValueField = "ID";
            DdlTipologia.DataTextField = "TIPOLOGIA";
            DdlTipologia.DataSource = new TipologiaManagement().GetAllTipologiasBySubSerie(Convert.ToInt32(DdlSubserie.SelectedValue.ToString()));
            DdlTipologia.DataBind();
            DdlTipologia.Enabled = true;
            DdlTipologia.Items.Insert(0, new ListItem("Seleccionar", "0"));
            DdlTipologia.SelectedValue = "0";

            DdlExpediente.Enabled = true;
            DdlExpediente.DataValueField = "ID";
            DdlExpediente.DataTextField = "DESCRIPCION";
            DdlExpediente.DataSource = new ExpedienteManagement().GetAllExpedienteBySubserie(Convert.ToInt32(DdlSubserie.SelectedValue.ToString()), Convert.ToInt32(DdlEntes.SelectedValue.ToString()));
            DdlExpediente.DataBind();
            DdlExpediente.Items.Insert(0, new ListItem("Seleccionar", "0"));
            DdlExpediente.SelectedValue = "0";
        }



        protected void DdlSerie_SelectedIndexChanged(object sender, EventArgs e)
        {

            DdlSubserie.DataValueField = "ID";
            DdlSubserie.DataTextField = "SUBSERIE";
            DdlSubserie.Enabled = true;

            DdlSubserie.DataSource = new SubSerieManagement().GetASubSerieEnte(Convert.ToInt32(DdlSerie.SelectedValue.ToString()), Convert.ToInt32(DdlEntes.SelectedValue.ToString()));
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

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(Util.DocumentosTEMP + "/" + txtDoc.Text, "_blank", "menubar=0,scrollbars=1,width=780,height=900,top=10");
        }


        


        
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("docpendi.aspx");
        }

        protected void DdlEntes_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlSerie.DataValueField = "ID";
            DdlSerie.DataTextField = "SERIE";
            DdlSerie.DataSource = new SerieManagement().GetASeriesEnte(Convert.ToInt32(DdlEntes.SelectedValue.ToString()));
            DdlSerie.DataBind();
            DdlSerie.Items.Insert(0, new ListItem("Seleccionar", "0"));
            DdlSerie.SelectedValue = "0";
            DdlSerie.Enabled = true;
        }

        protected void btnescaner_Click(object sender, EventArgs e)
        {

            receptor = new EmiRecepManagement().GetEmiRecepByIdusuario(SessionDocumental.UsuarioInicioSession.CODIGO);
            
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = receptor.conficor.SOFTESCANER;
            proc.Start();
            

            //Response.Redirect("file://c://codigofuente//Lubrigrasfuentes//lubrigra.exe");
            
            string carpetaOrigen = receptor.conficor.CAMINOSCANNER;
            string carpetaDestino = receptor.conficor.CAMINODESCARGA;
            if (!System.IO.Directory.Exists(carpetaOrigen))
            {
                System.IO.Directory.CreateDirectory(carpetaOrigen);
            }

            if (System.IO.Directory.Exists(carpetaOrigen))
            {
                int cont = 0;
                while (!existeArchivo(carpetaOrigen) && cont < 60)
                {
                    //lblescaner.Text = "Buscando Archivo....";
                    Thread.Sleep(1000);
                    cont++;

                }
                string[] files = System.IO.Directory.GetFiles(carpetaOrigen);

                foreach (string s in files)
                {
                    string extencion = System.IO.Path.GetExtension(s);
                    if (extencion.ToUpper() == ".PDF")
                    {
                        string archivo = System.IO.Path.GetFileName(s);
                        txtDoc.Text = archivo;
                        ManejoArchivos.copyFile(carpetaOrigen + "\\" + archivo, Util.PathDocumentosTEMP + "\\" + archivo);
                    }
                }
            }
            else
            {
                this.PintarMsjError("No se Encuentra Archivos");
            }

        
        }
        protected bool existeArchivo(string carpetaOrigen)
        {
            bool ret = false;
            string[] files = System.IO.Directory.GetFiles(carpetaOrigen);
            if (files.Length > 0)
            {
                foreach (string s in files)
                {
                    string extencion = System.IO.Path.GetExtension(s);
                    if (extencion.ToUpper() == ".PDF")
                    {
                        ret = true;
                    }
                }
            }
            else
            {
                ret = false;
            }
            return ret;

        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (txtIndice.Text != "")
            {
                LstIndice.Items.Add(txtIndice.Text);
                txtIndice.Text = "";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            LstIndice.Items.Remove(LstIndice.SelectedValue);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Grabamos el documento
            crearDocumento();

        }

        protected void crearDocumento()
        {
            receptor = new EmiRecepManagement().GetEmiRecepByIdusuario(SessionDocumental.UsuarioInicioSession.CODIGO);
            Documentos documento = new Documentos();
             string carpetaOrigen = receptor.conficor.CAMINOSCANNER;
            string carpetaDestino = receptor.conficor.CAMINODESCARGA;
            documento.IDSERIE = Convert.ToInt32(DdlSerie.SelectedValue.ToString());
            documento.IDSUBSERIE = Convert.ToInt32(DdlSubserie.SelectedValue.ToString());;
            documento.IDTIPOLOGIA = Convert.ToInt32(DdlTipologia.SelectedValue.ToString());;
            documento.IDEXPEDIENTE = Convert.ToInt32(DdlExpediente.SelectedValue.ToString());;
            documento.FOLIOS = Convert.ToInt32(TxtFolios.Text);
            documento.ANEXOS = txtAnexos.Text;
            documento.DOCUMENTO = txtDoc.Text;
            documento.CAMINO = carpetaDestino;
            documento.IDENTE = Convert.ToInt32(DdlEntes.SelectedValue.ToString()); 

            documento.idDOCUMENTOS = new DocumentosManagement().InsertDocumentos(documento);
            SessionDocumental.ObjDocumento = documento;

            // Creamos indices
            for (int idoc = 0; idoc < LstIndice.Items.Count; idoc++)
            {
                Indices indice = new Indices();
                indice.ATRIBUTO = "";
                indice.iddocumento = documento.idDOCUMENTOS;
                LstIndice.SelectedIndex = idoc;
                indice.INDICE = LstIndice.SelectedValue.ToString();
                new IndicesManagement().InsertIndices(indice);


            }


            //Mueve el archivo

            ManejoArchivos.copyFile(carpetaOrigen + "/" + txtDoc.Text, Util.PathDocumentosDESC + "\\" + txtDoc.Text);

            ManejoArchivos.EliminarArchivo(carpetaOrigen, txtDoc.Text);

            ManejoArchivos.EliminarArchivo(Util.PathDocumentosTEMP, txtDoc.Text);

            txtDoc.Text = "";
            DdlSerie.SelectedValue = "0";
            DdlSubserie.SelectedValue = "0";
            DdlTipologia.SelectedValue = "0";
            DdlExpediente.SelectedValue = "0";
            txtAnexos.Text = "";
            TxtFolios.Text = "";
            // Limpio el listbox

            for (int idoc = 0; idoc < LstIndice.Items.Count; idoc++)
            {
                LstIndice.SelectedIndex = idoc;
                LstIndice.Items.Remove(LstIndice.SelectedValue);
                
            }
            DdlEntes.Focus();

        }

    }
}