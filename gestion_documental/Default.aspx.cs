using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestion_documental.codigo;
using gestion_documental.BusinessObjects;
using gestion_documental.DataAccessLayer;
using gestion_documental.Utils;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    Class1 proce = new Class1();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            //llamadaagenda();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        string cClave = TxtClave.Text;
         string cUsuario = TxtUsuario.Text;
        
         int codigo = new UsuariosManagement().CheckLogin(cUsuario, cClave);
         if (codigo != 0)
         {
             Usuarios usuario = new UsuariosManagement().GetUsuariosById(codigo);
             SessionDocumental.UsuarioInicioSession = usuario;
             SessionDocumental.UsuarioInicioSession.fechaIngreso = DateTime.Now;
             Response.Redirect("docPendi.aspx");
         }
         else
         {
             SessionDocumental.UsuarioInicioSession = null;
             //throw new Exception("No coincide usuario o contraseña");
         }


    }

    protected void llamadaagenda()
    {
        string lcFechaHoy = proce.formateafecha(DateTime.Now.Date,0);
        DataTable DatAgenda = new DataTable();
        proce.consultacamposcondicion("generaWorkflow", "*", "activo = 1 and (ultimafecha < '" + lcFechaHoy + "' OR ultimafecha is null)", DatAgenda);
        if (DatAgenda.Rows.Count > 0)
        {
           
          
            
            foreach(DataRow Fila in DatAgenda.Rows)
            {

                string lcfechaInicial = proce.formateafecha(Convert.ToDateTime(Fila["fechaini"].ToString()),0);
                  string lcultimafecha = Fila["ultimafecha"].ToString();
                  if (lcFechaHoy == lcfechaInicial && lcultimafecha == "")
                  {

                      llenaWorkflow(Fila);
                  }

                  else

                  {
                      int lnDiasAsumar = 0;
                switch (Fila["repetir"].ToString())
                {
                    case "DIARIO":
                         lnDiasAsumar=1;
                        break;
                    case "SEMANAL":
                        lnDiasAsumar = 7;
                        break;
                    case "QUINCENAL":
                        lnDiasAsumar = 15;
                        break;

                    case "MENSUAL":
                        lnDiasAsumar = 30;
                        break;
                    case "BIMESTRAL":
                        lnDiasAsumar = 60;
                        break;
                    case "TRIMESTRAL":
                        lnDiasAsumar = 90;
                        break;
                    case "CUATRIMESTRALL":
                        lnDiasAsumar = 120;
                        break;

                    case "SEMESTRAL":
                        lnDiasAsumar = 180;
                        break;
                    case "ANUAL":
                        lnDiasAsumar = 365;
                        break;

                }
                       DateTime ldNuevaFecha; 
                if (Fila["ultimafecha"].ToString() == "")
                {
                   ldNuevaFecha = Convert.ToDateTime(Fila["fechaini"].ToString());
                }
                else
                {

                 ldNuevaFecha = Convert.ToDateTime(Fila["ultimafecha"].ToString()).AddDays(lnDiasAsumar);
                }
                if (proce.formateafecha(ldNuevaFecha,0) == lcFechaHoy)
                {

                    llenaWorkflow(Fila);
                }


            }
          }


        }

    }

    protected void llenaWorkflow(DataRow Fila)
    {

        Cadenas MyCadena = new Cadenas();
        MyCadena.FECHA = DateTime.Now;
        int lnIdCadena = new CadenasManagement().InsertCadenas(MyCadena);

        if (Fila["caminodoc"].ToString() != " ")
        {
            crearDocumento( Fila);
        }


        
        EmiRecep receptor = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(Fila["idemidestino"].ToString()));
        EmiRecep Emisor = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(Fila["idemirecep"].ToString()));

        obtieneRadicado(Emisor.ID,receptor.ID);

        Workflow workflow = new Workflow();

        workflow.IDENTEORIGEN = Convert.ToInt32(Emisor.IDENTE);
        workflow.IDENTEDESTINO = Convert.ToInt32(receptor.IDENTE);
        workflow.IDEMIRECEP = Emisor.ID;
        workflow.IDEMIDESTINO = receptor.ID;

        workflow.FECHA = DateTime.Now;
        workflow.iddocumento = 0;
        if (SessionDocumental.ObjDocumento != null) workflow.iddocumento = SessionDocumental.ObjDocumento.idDOCUMENTOS;

        workflow.RADICADO = TxtRadicado.Value;
        workflow.IDTAREA = Convert.ToInt32(Fila["idtarea"]);
        workflow.IDTIPOLOGIA = 0;
        workflow.DIAS = Convert.ToInt32(Fila["DIAS"]);
        workflow.ESTADO = "1. PENDIENTE";
        workflow.OBSERVACION = Fila["ASUNTO"].ToString();
        workflow.TIPO = "";
        workflow.IDCADENA = lnIdCadena;
       
        new WorkFlowManagement().InsertWorkflow(workflow);

        if (Convert.ToInt32(Fila["idemidestino2"].ToString()) != 0)
        {
        EmiRecep receptor2 = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(Fila["idemidestino2"].ToString()));
        workflow.IDEMIDESTINO = receptor2.ID;
        workflow.IDENTEDESTINO = receptor2.IDENTE;

        new WorkFlowManagement().InsertWorkflow(workflow);
        }
        proce.editar("generaWorkflow", "ultimafecha = '" + proce.formateafecha(DateTime.Now,0) + "'", "id = " + Fila["id"].ToString());

    }


    protected void crearDocumento(DataRow Fila)
    {


        EmiRecep receptor = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(Fila["idemidestino"].ToString()));
        EmiRecep emisor = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(Fila["idemirecep"].ToString()));

        string carpetaDestino = receptor.conficor.CAMINODESCARGA;

            Documentos documento = new Documentos();
            /*
            documento.IDSERIE = Convert.ToInt32(DdlSerie.SelectedValue);
            documento.IDSUBSERIE = Convert.ToInt32(DdlSubserie.SelectedValue);
            documento.IDTIPOLOGIA = Convert.ToInt32(DdlTipologia.SelectedValue); ;
            documento.IDEXPEDIENTE = Convert.ToInt32(DdlExpediente.SelectedValue); 
             * */
            documento.FOLIOS = 1;
            documento.ANEXOS = "";
            documento.DOCUMENTO = Fila["caminodoc"].ToString();
            documento.CAMINO = carpetaDestino.Replace("\\", "//");

            documento.IDENTE = 0;

            documento.idDOCUMENTOS = new DocumentosManagement().InsertDocumentos(documento);
            SessionDocumental.ObjDocumento = documento;

            LinkDoc links = new LinkDoc();
            links.IDDOCUMENTOS = documento.idDOCUMENTOS;
            links.IDENTE = receptor.IDENTE;
            new LinkDocManagement().InsertLinkDoc(links);
            

                    

            
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
            radicado = new RadicadosManagement().GetRadicadoActual(De, Para,false);
            TxtRadicado.Value = radicado.Radicado;
            string lcPrefijo = "";
            if (radicado.PrefExtSal.Trim() == TxtRadicado.Value.Substring(0, radicado.PrefExtSal.Trim().Length))
            {
                lcPrefijo = radicado.PrefExtSal.Trim();
            }
            if (radicado.PrefExtEnt.Trim() == TxtRadicado.Value.Substring(0, radicado.PrefExtEnt.Trim().Length))
            {
                lcPrefijo = radicado.PrefExtEnt.Trim();
            }

            if (radicado.prefInter.Trim() == TxtRadicado.Value.Substring(0, radicado.prefInter.Trim().Length))
            {
                lcPrefijo = radicado.prefInter.Trim();
            }


            int lnRadicado = Convert.ToInt32(TxtRadicado.Value.Substring(lcPrefijo.Length + 4));
            // Ahora miramos si el radicado ya existe
            bool llExiste = true;
            while (llExiste)
            {
                Workflow ExisteRad = new Workflow();
                ExisteRad = new WorkFlowManagement().GetWorkflowByRadicado(TxtRadicado.Value);
                if (ExisteRad.RADICADO == "")
                {
                    llExiste = false;
                }
                else
                {
                    TxtRadicado.Value = lcPrefijo + Convert.ToDateTime(radicado.UltimaFecha).Year.ToString();
                    if (lnRadicado.ToString().Length < 4)
                    {
                        TxtRadicado.Value = TxtRadicado.Value + lnRadicado.ToString().PadLeft(4, '0');
                    }
                }
            }
            //
        }



    }
           
    
}
