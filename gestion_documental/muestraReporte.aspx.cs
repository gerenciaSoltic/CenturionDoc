using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gestion_documental
{
    public partial class muestraReporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string lcInforme = Request.QueryString["informe"];
                ReportViewer1.LocalReport.ReportPath = lcInforme;

            }
        }
    }
}