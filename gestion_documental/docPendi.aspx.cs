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
    public partial class docPendi : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ConfigurarPadrePostBack(this.Msj, this.usuarioLabel);

            



        }
    }
}