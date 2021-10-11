using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestion_documental.BusinessObjects;
using gestion_documental.DataAccessLayer;
using gestion_documental.Utils;

namespace gestion_documental
{
    public partial class RecibidoConformidad : System.Web.UI.Page
    {
        Class1 proce = new Class1();
        DocumentosManagement _Documentos = new DocumentosManagement();
        EmiRecep receptor;
        public Int32 iddocumento;
        public Int32 idcadena;
        public Int32 idemisor;
        public Int32 idreceptor;
        public string Semaforos;
        public Int32 idtarea;
        public Int32 idradicado;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                
            }


        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {

            Workflow WorkRespuesta = new Workflow();
            WorkRespuesta = new WorkFlowManagement().GetWorkflowByRadicado(TextBox1.Text.Trim());
            if (WorkRespuesta.ID !=0)
            {
            iddocumento = WorkRespuesta.iddocumento;
            idcadena = WorkRespuesta.IDCADENA;
            Semaforos = WorkRespuesta.SEMAFORO;
            idradicado = WorkRespuesta.IDRADICADO;
            idtarea = WorkRespuesta.IDTAREA;
            EmiRecep Emisor = new EmiRecepManagement().GetEmiRecepById(WorkRespuesta.IDEMIRECEP);
            EmiRecep Receptor = new EmiRecepManagement().GetEmiRecepById(WorkRespuesta.IDEMIDESTINO);
                Label3.Text = "De       : " + Emisor.DESCRIPCION;
                Label4.Text = "Para     : " + Receptor.DESCRIPCION;
                Label5.Text = "Asunto   : " + WorkRespuesta.OBSERVACION;
                Label6.Text = "Respuesta: " + WorkRespuesta.RESPUESTA;
            }
            else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('El Radicado No existe');", true);
                    TextBox1.Text = "";
                return;

                }

        }

       

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

            if (ImageButton2.FileName == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe adjuntar un documento ...');", true);
                return;
            }


            Workflow WorkRespuesta = new Workflow();
            WorkRespuesta = new WorkFlowManagement().GetWorkflowByRadicado(TextBox1.Text.Trim());
            iddocumento = WorkRespuesta.iddocumento;
            idcadena = WorkRespuesta.IDCADENA;
            Semaforos = WorkRespuesta.SEMAFORO;
            idradicado = WorkRespuesta.IDRADICADO;
            idtarea = WorkRespuesta.IDTAREA;

            // TABLA: DOCUMENTOS
            //iddocumentos,idserie,idsubserie,idtipologia,documento,camino,idexpediente,folios,anexo,idworkflow,idente,version,calidad,imagenes,descripcion
            Documentos doc = new Documentos();


            EmiRecep usureceptor = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);

            string lcArchivo = Server.MapPath(usureceptor.conficor.CAMINODESCARGA.Trim()) + "\\" + ImageButton2.FileName;
            ImageButton2.SaveAs(lcArchivo);        
            
            doc.DOCUMENTO = ImageButton2.FileName;
            doc.CAMINO = usureceptor.conficor.CAMINODESCARGA.Trim().Replace("\\", "//");
            doc.DESCRIPCION = TxtDescripcion.Text;
            int lniddoc = _Documentos.InsertDocumentos(doc);
            
            // TABLA : linkdoc
            //id,idente,iddocumentos,idserie,idsubserie,idtipologia,idespediente
            LinkDoc nlink = new LinkDoc();
            
            //De:
            nlink.IDENTE = WorkRespuesta.IDENTEORIGEN;   // identeorigen
            nlink.IDDOCUMENTOS = lniddoc;             
            new LinkDocManagement().InsertLinkDoc(nlink);
            
            //Para:
            nlink.IDENTE = WorkRespuesta.IDENTEDESTINO;  // identedestino
            nlink.IDDOCUMENTOS = lniddoc;
            new LinkDocManagement().InsertLinkDoc(nlink);


            // TABLA: Workflow
            // id,fecha,radicado,identeorigen,identedestino,dias,observacion,idtipologia,tipo,iddocumento,estado,semaforo,idexpediente,idemirecep,idemidestino,idtarea,idcadena,respuesta,fecharespuesta,idradicado,idradicado2

            //De:
            
            WorkRespuesta.FECHA = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            WorkRespuesta.RADICADO = TextBox1.Text;
            WorkRespuesta.DIAS = 0;
            WorkRespuesta.OBSERVACION = TxtDescripcion.Text;
            WorkRespuesta.IDTIPOLOGIA = 0;
            WorkRespuesta.iddocumento = lniddoc;
            WorkRespuesta.ESTADO = "5. FINALIZADO";
            WorkRespuesta.SEMAFORO = Semaforos;
            WorkRespuesta.idexpediente = 0;
            WorkRespuesta.IDRADICADO = idradicado;

            TextBox1.Text = "";
            Label3.Text = "";
            Label4.Text = "";
            Label5.Text = "";
            Label6.Text = "";
                        
            new WorkFlowManagement().InsertWorkflow(WorkRespuesta);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Proceso Finalizado...');", true);
        }

   

       
    }
}