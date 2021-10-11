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
using System.IO;



namespace gestion_documental
{
    public partial class TramiteCorreo : System.Web.UI.Page
    {
        Class1 proce = new Class1();
        Correo ManejoCorreo = new Correo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioInicioSession"] == null)
            {
                Response.Redirect("Default.aspx");

            }
            if (!IsPostBack)
            {
                EmiRecep receptor = new EmiRecepManagement().GetEmiRecepByIdusuario(SessionDocumental.UsuarioInicioSession.CODIGO);
                int idente = Convert.ToInt32(receptor.IDENTE.ToString());

                Workflow WorkCorreo = new WorkFlowManagement().GetWorkflowByFirstRadicado(SessionDocumental.ObjRadicado.Radicado);
                EmiRecep EmiDestino = new EmiRecepManagement().GetEmiRecepById(WorkCorreo.IDEMIRECEP);


                DataTable DocAdjuntar = new DataTable();

                proce.consultacamposcondicion("Documentos,Workflow", "documento,descripcion,camino", "documentos.iddocumentos = workflow.iddocumento and workflow.idcadena =" + WorkCorreo.IDCADENA.ToString() + " and documentos.documento != ' '  GROUP BY documento,descripcion,camino", DocAdjuntar);

                GridView1.DataSource = DocAdjuntar;
                GridView1.DataBind();
                
                // Obtenrmos el numr de radicado

                obtieneRadicado(receptor.ID, EmiDestino.ID);
                TxtEmirecep.Text = EmiDestino.DESCRIPCION;
                TxtCorreo.Text = EmiDestino.EMAIL;



            }
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Grabamos el registro en WorkFlow
             EmiRecep receptor = new EmiRecepManagement().GetEmiRecepByIdusuario(SessionDocumental.UsuarioInicioSession.CODIGO);
                int idente = Convert.ToInt32(receptor.IDENTE.ToString());

                Workflow WorkCorreo = new WorkFlowManagement().GetWorkflowByFirstRadicado(SessionDocumental.ObjRadicado.Radicado);
                EmiRecep EmiDestino = new EmiRecepManagement().GetEmiRecepById(WorkCorreo.IDEMIRECEP);

                obtieneRadicado(receptor.ID, EmiDestino.ID);

            Workflow WorkGrabar = new Workflow();

            WorkGrabar.CODIGOUSUARIO = SessionDocumental.UsuarioInicioSession.CODIGO;
            WorkGrabar.IDENTEORIGEN= receptor.IDENTE;
            WorkGrabar.IDENTEDESTINO = EmiDestino.IDENTE;
            WorkGrabar.IDEMIRECEP = receptor.ID;
            WorkGrabar.IDEMIDESTINO = EmiDestino.ID;
            
            WorkGrabar.FECHA = DateTime.Now;
            WorkGrabar.ESTADO = WorkCorreo.ESTADO;
            WorkGrabar.IDCADENA = WorkCorreo.IDCADENA;
            WorkGrabar.SEMAFORO = WorkCorreo.SEMAFORO;
            WorkGrabar.iddocumento = 0;
            WorkGrabar.idexpediente = WorkCorreo.idexpediente;
            WorkGrabar.RESPUESTA = WorkCorreo.RESPUESTA;
            WorkGrabar.OBSERVACION = "RESPUESTA RADICADA POR CORREO ELECTRONICO "+WorkCorreo.OBSERVACION;
            WorkGrabar.IDRADICADO =receptor.IDRADICADO;
            WorkGrabar.IDTAREA = 0;
            WorkGrabar.ESTADO = "5. FINALIZADO";
            WorkGrabar.IDTIPOCOM = WorkCorreo.IDTIPOCOM;
            WorkGrabar.TIPO = "C";
            
            // Obtener Radicado
          
            WorkGrabar.RADICADO = txtRadicado.Text;

            new WorkFlowManagement().InsertWorkflow(WorkGrabar);

            //Actualizamos los radicados dandoles la respuesta

            proce.editar("workflow","respuesta= '"+WorkCorreo.RESPUESTA+"',fecharespuesta='"+proce.formateafecha(DateTime.Now,0)+"',radicado2='"+txtRadicado.Text+"'","radicado = '"+WorkCorreo.RADICADO+"'");


            // Ahora enviamos correo electronico //


             
            string endereco = "";
            
            string endereco2 = "";
    
            if (GridView1.SelectedIndex >= 0)
            {


                endereco = proce.recuperaUbicacion() + "\\" + receptor.conficor.CAMINODESCARGA + "\\";
             
                DataTable DocAdjuntar = new DataTable();

                proce.consultacamposcondicion("Documentos,Workflow", "documento,descripcion,camino", "documentos.iddocumentos = workflow.iddocumento and workflow.idcadena =" + WorkCorreo.IDCADENA.ToString() + " and documentos.documento != ' '  GROUP BY documento,descripcion,camino", DocAdjuntar);
               


                endereco2 = endereco + DocAdjuntar.Rows[GridView1.SelectedIndex]["Documento"];


                if (!File.Exists(endereco2))
                {
                    Label7.Text = "No encuentro el archivo.." + endereco2;
                    return;
                }

                
            }


            Button1.Enabled = false;
            txtMensaje.Text = "\r\n" + "\r\n" + txtMensaje.Text + "\r\n" + "\r\n" + "\r\n" + "\r\n" + "\r\n" + "\r\n" + SessionDocumental.UsuarioInicioSession.NOMBRE;
            string lcMensaje = txtMensaje.Text.Trim() + "\r\n" + "\r\n" + " " + "\r\n" + "RADICADO DE CORREO: " + txtRadicado.Text + "\r\n" + "EMISOR :" + receptor.ente.DESCRIPCION + "-" + receptor.DESCRIPCION.Trim() + "\r\n" + "PARA :" + EmiDestino.DESCRIPCION;



            
            if (ManejoCorreo.enviarCorreo(receptor.conficor.EMAIL, receptor.conficor.CONTRASENA, lcMensaje, "Respuesta Radicado: "+WorkCorreo.RADICADO, EmiDestino.EMAIL, endereco2,receptor.conficor.SERVPOPSALIENTE) == "SI")
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Correo enviado con Exito');", true);
                //Response.Redirect("TramiteDocumento.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No se pudo enviar el Correo..'"+endereco2+"');", true);
            }
            


            


        }

        protected void obtieneRadicado(int tcIdDe,int tcIdPara)
        {
            EmiRecep Para = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(tcIdPara));
            EmiRecep De = new EmiRecepManagement().GetEmiRecepById(Convert.ToInt32(tcIdDe));
            Radicados radicado = new Radicados();
            SessionDocumental.ObjEmisorOrigen = De;
            SessionDocumental.ObjEmisorDestino = Para;

            if (Para.ID != 0 && De.ID != 0)
            {
                radicado = new RadicadosManagement().GetRadicadoActual(De, Para,false);
                txtRadicado.Text = radicado.Radicado;
                string lcPrefijo = "";
                if (radicado.PrefExtSal.Trim() == txtRadicado.Text.Substring(0, radicado.PrefExtSal.Trim().Length))
                {
                    lcPrefijo = radicado.PrefExtSal.Trim();
                }
                if (radicado.PrefExtEnt.Trim() == txtRadicado.Text.Substring(0, radicado.PrefExtEnt.Trim().Length))
                {
                    lcPrefijo = radicado.PrefExtEnt.Trim();
                }

                if (radicado.prefInter.Trim() == txtRadicado.Text.Substring(0, radicado.prefInter.Trim().Length))
                {
                    lcPrefijo = radicado.prefInter.Trim();
                }

                
                int lnRadicado = Convert.ToInt32(txtRadicado.Text.Substring(lcPrefijo.Length + 4));
                // Ahora miramos si el radicado ya existe
                bool llExiste = true;
                while (llExiste)
                {
                    Workflow ExisteRad = new Workflow();
                    ExisteRad = new WorkFlowManagement().GetWorkflowByRadicado(txtRadicado.Text);
                    if (ExisteRad.RADICADO == "")
                    {
                        llExiste = false;
                    }
                    else
                    {
                        lnRadicado = lnRadicado + 1;
                        txtRadicado.Text = lcPrefijo + Convert.ToDateTime(radicado.UltimaFecha).Year.ToString() + lnRadicado.ToString();
                    }
                }
                //
            }
        

           
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("TramiteDocumento.aspx");
        }
    }
}