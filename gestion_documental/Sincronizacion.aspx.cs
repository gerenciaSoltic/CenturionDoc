using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestion_documental.BusinessObjects;
using gestion_documental.DataAccessLayer;
using System.Data;

namespace gestion_documental
{
    public partial class Sincronizacion : System.Web.UI.Page
    {
        Class1 proce = new Class1();
        string host = HttpContext.Current.Request.Url.Host;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                GridView1.DataSource = new EmiRecepManagement().GetEmiRecepLocal();
                GridView1.DataBind();

                GridView2.DataSource = new DocumentosManagement().GetDocumentosLocal();
                GridView2.DataBind();

                GridView3.DataSource = new WorkFlowManagement().GetWorkflowLocal();
                GridView3.DataBind();
            }

        }

        protected void Btn_Sincronizar_Click(object sender, EventArgs e)
        {
            
            if (host != "localhost")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe Estar ubicado en la versión offline..');", true);
            }

            // Validamos si existen los radicados en el server

            // Volvemos a armar el objeto y lo buscamos con la conexiónn remota

            List<Workflow> ListaRadicados = new WorkFlowManagement().GetWorkflowLocal();


            bool ErrorGrave = false;

            foreach (Workflow Unradicado in ListaRadicados)
            {
                Workflow workflowremoto = new WorkFlowManagement().GetWorkflowByRadicadoLocal(Unradicado.RADICADO);
                if (workflowremoto.ID != 0)
                {
                    ErrorGrave = true;
                    break;
                }

            }

            if (ErrorGrave)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('El radicado anterior esta  ya sincronizado..Contacte al administrador');", true);
                return;
            }
            
            // Empezamos añadiendo los emirecep

            List<EmiRecep> ListaEmirecepLocal = new EmiRecepManagement().GetEmiRecepLocal();



            ///Sacamos copia del emirecep
            ///
            //List<EmiRecep> CopiaListaEmirecepLocal = ListaEmirecepLocal;

            ListBox ListaNuevosId = new ListBox();

            // insertamos cada emirecep nuevo y tomamos el nuevoo id

            foreach (EmiRecep unEmirepLocal in ListaEmirecepLocal)
            {
                int idnewemirecep = new EmiRecepManagement().InsertRemoto(unEmirepLocal);

                ListaNuevosId.Items.Add(idnewemirecep.ToString());



            }


            // Ahora Cambiammos los ids de la copia
            int iListaNuevaid = 0;
            /*
            foreach (EmiRecep unEmirecepLocal in CopiaListaEmirecepLocal)
            {
                //unEmirecepLocal.ID = Convert.ToInt32(ListaNuevosId.Items[iListaNuevaid].ToString());
                iListaNuevaid=iListaNuevaid+1;
            }
            */

            // Ahora Insertamos los Documentos 


            // Empezamos añadiendo los documentos

            List<Documentos> ListaDocumentosLocal = new DocumentosManagement().GetDocumentosLocal();



            ///Sacamos copia del documentos
            ///
            //List<Documentos> CopiaListaDocumentosLocal = ListaDocumentosLocal;

            ListBox ListaNuevosIdDoc = new ListBox();

            // insertamos cada DOcummentos nuevo y tomamos el nuevoo id

            foreach (Documentos unDocumentoLocal in ListaDocumentosLocal)
            {
                int idnewDocumento = new DocumentosManagement().InsertDocumentosLocal(unDocumentoLocal);

                ListaNuevosIdDoc.Items.Add(idnewDocumento.ToString());

                
                // Busco el ente en el work flow local
                DataTable DatEnte = new DataTable();

                proce.consultacamposcondicion("workflow","identedestino,identeorigen","iddocumento ="+unDocumentoLocal.idDOCUMENTOS.ToString(),DatEnte);

                 

                LinkDoc Linkdoc = new LinkDoc();
                Linkdoc.IDDOCUMENTOS =idnewDocumento;
                Linkdoc.IDENTE = Convert.ToInt32(DatEnte.Rows[0][0].ToString());
                new LinkDocManagement().InsertLinkDocLocal(Linkdoc);
                
                Linkdoc.IDDOCUMENTOS = idnewDocumento;
                Linkdoc.IDENTE = Convert.ToInt32(DatEnte.Rows[0][1].ToString());
                new LinkDocManagement().InsertLinkDocLocal(Linkdoc);


            }


            // Ahora Cambiammos los ids de la copia de Documentos
            int iListaNuevaidDoc = 0;
            /*
            foreach (Documentos unDocumentoLocal in CopiaListaDocumentosLocal)
            {
                unDocumentoLocal.idDOCUMENTOS = Convert.ToInt32(ListaNuevosIdDoc.Items[iListaNuevaidDoc].ToString());
            }

            */
            //Ahora Barremos de nuevo Workkflow ..cammbiando los idemirecep e idemidestino



            foreach (Workflow Unradicado in ListaRadicados)
            {
                
                // Buscamos el Id para ver si esta entre los que cambiaron

                Workflow workflowremoto = new WorkFlowManagement().GetWorkflowById(Unradicado.ID);

                int Nuevoidemirecep = 0;
                foreach (EmiRecep unEmirecep in ListaEmirecepLocal)
                {
                    if (workflowremoto.IDEMIRECEP == unEmirecep.ID)
                    {
                        workflowremoto.IDEMIRECEP = Convert.ToInt32(ListaNuevosId.Items[Nuevoidemirecep].ToString());
                    }

                    if (workflowremoto.IDEMIDESTINO == unEmirecep.ID)
                    {
                        workflowremoto.IDEMIDESTINO = Convert.ToInt32(ListaNuevosId.Items[Nuevoidemirecep].ToString());
                    }
                    Nuevoidemirecep++;

                }

                int NuevoDocumento = 0;
                foreach (Documentos unDocumento in ListaDocumentosLocal)
                {
                    if (workflowremoto.iddocumento == unDocumento.idDOCUMENTOS)
                    {
                        workflowremoto.iddocumento = Convert.ToInt32(ListaNuevosIdDoc.Items[NuevoDocumento].ToString());

                    }
                    NuevoDocumento++;
                }

                new WorkFlowManagement().InsertWorkflowLocal(workflowremoto);

            }

            // Ahora pasamos los indices

            List<Indices> ListaIndices = new IndicesManagement().GetAllIndicesLocales();


            int NuevoDocumento2 = 0;
            foreach (Documentos unDocumento in ListaDocumentosLocal)
            {
            
                foreach (Indices UnIndice in ListaIndices)
                  {

                             // Buscamos el Id para ver si esta entre los que cambiaron
                       if (UnIndice.iddocumento == unDocumento.idDOCUMENTOS)
                          {
                           UnIndice.iddocumento = Convert.ToInt32(ListaNuevosIdDoc.Items[NuevoDocumento2].ToString());
                            new  IndicesManagement().InsertIndicesRemoto(UnIndice);
                          }
                    
                }

                    NuevoDocumento2++;
              }

                

            
            //Ahora colocamos los locales Actualzados


            proce.editar("emirecep", "actualizado = 1", "id > 0 and actualizado = 0");
            proce.editar("documentos", "actualizado = 1", "iddocumentos > 0 and actualizado = 0");
            proce.editar("workflow", "actualizado = 1", "id > 0 and actualizado = 0");
            proce.editar("indices", "actualizado = 1", "id > 0 and actualizado = 0");

            // Ahora pasamos los archivos 


            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Sincronizacion realizada con Éxito');", true);






        }
    }
}