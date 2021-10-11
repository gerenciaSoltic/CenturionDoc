using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace gestion_documental.Utils
{
    public class BasePage : System.Web.UI.Page
    {
        #region propiedades
        protected Label MsjBase;
        protected Label usuarioBaseLabel;
        #endregion


        protected void ConfigurarPadrePostBack(Label Msj, Label usuarioLabel)
        {
            this.MsjBase = Msj;
            this.usuarioBaseLabel = usuarioLabel;

            if (SessionDocumental.UsuarioInicioSession == null)
            {
                Response.Redirect("Default.aspx");
            }
            this.PintarUsuario(usuarioBaseLabel);
            this.LlamarMetodoEvento();
        }
        protected void PintarUsuario(Label label)
        {

            label.Text = "Usuario: " +
            SessionDocumental.UsuarioInicioSession.USUARIO + ",   Nombre: " +
            SessionDocumental.UsuarioInicioSession.NOMBRE + ",   Hora Ingreso: " +
            SessionDocumental.UsuarioInicioSession.fechaIngreso.ToString("dd-MM-yyyy hh:mm:ss") + " ,  Usuario Windows: " + SessionDocumental.UsuarioInicioSession.USUARIOWIN;
       

        }
        public void LlamarMetodoEvento()
        {
            if (IsPostBack)
            {
                this.VerificarEventos();
            }
        }
        protected void VerificarEventos()
        {
            string controlID = Page.Request.Params["__EVENTTARGET"];
            if (!string.IsNullOrEmpty(controlID))
            {
                switch (controlID)
                {
                    case "BuscarButton":

                        break;
                }
            }
        }
        public void PintarMsjError(string err)
        {
            MsjBase.Text = err;
            MsjBase.ForeColor = System.Drawing.Color.Red;
        }


        public string recuperaCamino()
        {
            string lcsartaLocal = "";

            System.Configuration.Configuration rootWebConfig1 =
                   System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            if (0 < rootWebConfig1.AppSettings.Settings.Count)
            {
                System.Configuration.KeyValueConfigurationElement Camino = rootWebConfig1.AppSettings.Settings["Camino"];
                lcsartaLocal = Camino.Value.ToString();
            }
            return lcsartaLocal;
        }
    }
}