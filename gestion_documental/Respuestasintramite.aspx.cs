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
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;

namespace gestion_documental
{
    public partial class Respuestasintramite : System.Web.UI.Page
    {
        Class1 proce = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Workflow WorkRespuesta = new Workflow();
            WorkRespuesta = new WorkFlowManagement().GetWorkflowByRadicado(TextBox1.Text.Trim());
            Label3.Text = WorkRespuesta.OBSERVACION.Trim();
            TextBox2.Text = WorkRespuesta.RESPUESTA;
            GridView2.DataSource = new DocumentosManagement().GetDocumentosbyListaiD(WorkRespuesta.IDCADENA);;
            GridView2.DataBind();

            GridView1.DataSource = new WorkFlowManagement().GetWorkflowByRadicadoList(TextBox1.Text);
            GridView1.DataBind();



           
          
            
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("~/" + GridView2.SelectedDataKey.Values[0].ToString() + "/" + GridView2.SelectedDataKey.Values[1].ToString(), "_blank", "menubar=0,scrollbars=1,width=780,height=900,top=10");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           List<Workflow>  Workrespuestas = new List<Workflow>();
            
            Workrespuestas = new WorkFlowManagement().GetWorkflowByRadicadoList(TextBox1.Text);

            foreach (Workflow wf in Workrespuestas)
            {
                wf.FECHARESPUESTA = DateTime.Now;
                wf.RESPUESTA = TextBox2.Text;
                new WorkFlowManagement().UpdateWorkflow(wf);
                proce.editar("workflow", "estado ='5. FINALIZADO',respuesta ='" + TextBox2.Text + "',fecharespuesta='" + proce.formateafecha(System.DateTime.Now,0) + "'", "radicado = '" +TextBox1.Text + "' and estado <> '5. FINALIZADO'");
            }

            TextBox1.Text = "";
            TextBox2.Text = "";
            GridView1.DataSource = "";
            GridView1.DataBind();
            GridView2.DataSource = "";
            GridView2.DataBind();
            Label3.Text = "";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Respuesta Exitosa..');", true);

        }
    }
}