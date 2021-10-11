using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestion_documental.Utils;
using gestion_documental.DataAccessLayer;
using gestion_documental.BusinessObjects;

namespace gestion_documental
{
    public partial class ConsultaWorkflowReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EmiRecep emisorVentanilla = new EmiRecepManagement().GetEmiRecepByCodUsuario(SessionDocumental.UsuarioInicioSession.CODIGO);
            DataAccessLayer.WorkFlowManagement.Ventanilla = emisorVentanilla.ID;
        }
    }
}