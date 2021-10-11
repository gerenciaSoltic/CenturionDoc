using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestion_documental;
using GESTIONDOCUMENTAL;
using gestion_documental.codigo;
using gestion_documental.BusinessObjects;
using gestion_documental.DataAccessLayer;
using gestion_documental.Utils;


namespace gestion_documental
{
    public partial class camclave : System.Web.UI.Page
    {

      
        

        protected void Page_Load(object sender, EventArgs e)
        {

            Label4.Text = "USUARIO : "+SessionDocumental.UsuarioInicioSession.NOMBRE.ToString();


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!txtActual.Text.Equals(SessionDocumental.UsuarioInicioSession.CONTRASENA.ToString()))
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('La contraseña actual no corresponde');", true);
                return;
            }

            if (!TextBox1.Text.Equals(TextBox2.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('La nueva contraseña no corresponde a su confimarción');", true);
                return;
            }
            Usuarios myuser = new Usuarios();
            myuser = new UsuariosManagement().GetUsuariosById(SessionDocumental.UsuarioInicioSession.CODIGO);
            myuser.CONTRASENA = TextBox1.Text;
            myuser.PRIMERAVEZ = 1;
            new UsuariosManagement().UpdateUsuarios(myuser);
            Response.Redirect("docpendi.aspx");
    

        }
    }
}