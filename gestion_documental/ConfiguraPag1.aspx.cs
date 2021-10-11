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
using gestion_documental;
using Microsoft.Reporting.WebForms;
namespace gestion_documental
{
    public partial class ConfiguraPag1 :  BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Class1 proce = new Class1();

            if (!this.IsPostBack)
            {
                if (Request["idworkflow"] != null)
                {
                    hiddIdworkflow.Value = Request["idworkflow"];
                }
            }
        }

        protected void clic_aceptar(object sender, EventArgs e)
        {
            string val = "0";
            if (rbtn1.Checked)
            {
                val = "1";
            }
            if (rbtn2.Checked)
            {
                val = "2";
            }
            if (rbtn3.Checked)
            {
                val = "3";
            }
            if (rbtn4.Checked)
            {
                val = "4";
            }
            if (rbtn5.Checked)
            {
                Workflow WorkFlow =  new WorkFlowManagement().GetWorkflowById(Convert.ToInt32(hiddIdworkflow.Value));
                DataAccessLayer.RadicadosManagement.lcRadicado = WorkFlow.RADICADO;
                //Response.Redirect("muestraRadicado.aspx", "_blank", "scrollbars=1,width=780,height=900,top=10");


               ///////////////////////////llamado ala clase impresion 
                impresion objImpresion = new impresion();


                // creacion de un local repor que se va a imprimir
                LocalReport mylocal = new LocalReport();

                // se deben crear los DataSource que utilice el reporte 
                ObjectDataSource _objDs = new ObjectDataSource();
                ObjectDataSource _objDs2 = new ObjectDataSource();

                //ubicacion del reporte
                mylocal.ReportPath = Server.MapPath("~/RepRadicado.rdlc");

                // llenar los DataSource  creados anteriormente
                // DataSource 1
                Microsoft.Reporting.WebForms.ReportDataSource repor = new Microsoft.Reporting.WebForms.ReportDataSource();
                repor.Name = "DataSet1";
                _objDs.SelectMethod = "GetRadicado";
                _objDs.TypeName = "gestion_documental.DataAccessLayer.RadicadosManagement";
                repor.Value = _objDs;
                mylocal.DataSources.Add(repor);


                // ubicacion donde se guardara los pdf
                impresion.direc = Server.MapPath("~\\guardarpdf\\");
                // llamar la clase imprimir para la descarga del pdf
                string url = objImpresion.Imprimir(mylocal);

                // visualizacion del pdf
                Response.Redirect("~/guardarpdf/" + url, "_blank", "menubar=0,scrollbars=1,width=780,height=900,top=10");
                //Response.Redirect("muestraRadicado.aspx", "_blank", "scrollbars=1,width=780,height=900,top=10");


            }
            else
            {
                Response.Redirect("PagImpresion_1.aspx?idworkflow=" + hiddIdworkflow.Value + "&formato="+val, "_blank", "scrollbars=1,width=780,height=900,top=10");
            }
            
        }

        protected void cancelar(object sender, EventArgs e)
        {
            Response.Redirect("ArchivoRecepcion.aspx");
        }

     
    }
}