using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using gestion_documental.Utils;
using gestion_documental.DataAccessLayer;
using gestion_documental.BusinessObjects;
using System.DirectoryServices;
using System.Text;
using System.Security.Principal;
using System.Management; 
using System.Threading;




namespace gestion_documental
{
    public partial class Inicio : System.Web.UI.Page
    {


         BasePage nuevabase = new BasePage();
        Class1 proce = new Class1();
        string UsuarioWindown, value;
        bool instituciones;
                    string us;

                    string sUserDominioRed; 


        protected void Page_Load(object sender, EventArgs e)
        {


            //----------------------------------------------
            //   <!-- Para Manejo de Directory Active -->
            //----------------------------------------------
            // 1- En el Web.config
            //<authentication mode="Windows"/>

            // 2- En el Forms
            //string UsuarioWindown = Environment.UserName;

            // 3- En el ISS
            // 3.1-Opcion de Autenticacion
            //  suplantacion basica = Habilitada
            //  Autenticacion Basica=
            //  Autenticacion de windonws

            // 3.2-Opcion Predeterminado
            // agregar Inicio.aspx y debe quedar de 1ro en la lista



            //this.MsjBase = this.Msj;
            DataTable datos1 = new DataTable();


            //value = Page.User.Identity.Name;
            //Char delimiter = '\\';
            //String[] substrings = value.Split(delimiter);
            //foreach (var substring in substrings)
            //    UsuarioWindown = substrings[1];

            if (!IsPostBack)
            {

                IniciaSesionAntenticacionWin();




            }



        }



        protected void IniciaSesionAntenticacionWin()
        {
            //WindowsIdentity user = WindowsIdentity.GetCurrent();
            //TxtUsuario.Text = user.Name;

            //HttpContext.Current.User.Identity.Name 




            //string sUserDominioRed = Thread.CurrentPrincipal.Identity.Name;
            //sUserDominioRed = sUserDominioRed.Split('\\')[1];

            //TxtUsuario.Text = sUserDominioRed;
            //UsuarioWindown = sUserDominioRed;
            
            // Gets the name if authenticated.
            if (User.Identity.IsAuthenticated)
            {

                sUserDominioRed = Thread.CurrentPrincipal.Identity.Name;
                sUserDominioRed = sUserDominioRed.Split('\\')[1];

                TxtUsuario.Text = sUserDominioRed;
                UsuarioWindown = sUserDominioRed;


                //TxtUsuario.Text = Thread.CurrentPrincipal.Identity.Name;
                //UsuarioWindown = Thread.CurrentPrincipal.Identity.Name;

                //TxtUsuario.Text = Environment.UserName;
                //UsuarioWindown = Environment.UserName;

              //string us = Page.User.Identity.Name;

              //string sUserDominioRed = HttpContext.Current.Request.ServerVariables["LOGON_USER"]; 
             
                
             //sUserDominioRed = sUserDominioRed.Split('\\')[1];

             //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('identidad del Usuario .config - ISS... XXX' " + UsuarioWindown + "  us: " + us + "  sUserDominioRed: " + sUserDominioRed + ");", true);
               
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('no se dispone de identidad del Usuario .config - ISS... XXX' " + UsuarioWindown + "  us: " + us + "  sUserDominioRed: " + sUserDominioRed + ");", true);
                ChkActiveDirectory.Checked = false;
                return;
            }


            try
            {


                int codigo = new UsuariosManagement().CheckLoginWin(UsuarioWindown.Trim());

                // ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('codigo... ');" + codigo, true);

                if (codigo != 0)
                {
                    Usuarios usuario = new UsuariosManagement().GetUsuariosById(codigo);
                    SessionDocumental.UsuarioInicioSession = usuario;
                    if (usuario.PRIMERAVEZ == 0)
                    {
                        string lcCamino = nuevabase.recuperaCamino();
                        Response.Redirect(lcCamino + "/camclave.aspx");
                    }
                    else
                    {
                        string lcCamino = nuevabase.recuperaCamino();
                        Response.Redirect(lcCamino + "/docPendi.aspx");
                        //Response.Redirect("docPendi.aspx");
                        //   string host = HttpContext.Current.Request.Url.Host;
                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('" + host + "');", true);
                    }
                }
                else
                {
                    SessionDocumental.UsuarioInicioSession = null;
                   // Response.Redirect("Inicio.aspx");
                    ChkActiveDirectory.Checked = false;
                    throw new Exception("No coincide usuario o contraseña");


                }



            }
            catch (Exception ex)
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No dispone de identidad Usuario Windows...' " + UsuarioWindown + " );", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No dispone de identidad Usuario Windows..." + UsuarioWindown + "  us: " + us + "  sUserDominioRed: " + sUserDominioRed + " Error: " + ex + " );", true);
               

                ChkActiveDirectory.Checked = false;
            }



        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string cClave = TxtClave.Text;
            string cUsuario = TxtUsuario.Text;

            try
            {

                //string resultado = new Encrypt().EncryptKey(cClave);

                //int codigo = new UsuariosManagement().CheckLogin(cUsuario, resultado);
                int codigo = new UsuariosManagement().CheckLogin(cUsuario, cClave);


                if (codigo != 0)
                {
                    Usuarios usuario = new UsuariosManagement().GetUsuariosById(codigo);

                    SessionDocumental.UsuarioInicioSession = usuario;
                    var Instituc = Convert.ToInt16(SessionDocumental.UsuarioInicioSession.IDINSTITUCION.ToString());

                    if (usuario.PRIMERAVEZ == 0)
                    {
                        string lcCamino = nuevabase.recuperaCamino();
                        Response.Redirect(lcCamino + "/camclave.aspx");
                    }
                    else
                    {
                        string lcCamino = nuevabase.recuperaCamino();
                        Response.Redirect(lcCamino + "/docPendi.aspx");
                        //Response.Redirect("docPendi.aspx");
                        //   string host = HttpContext.Current.Request.Url.Host;
                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('" + host + "');", true);
                    }
                }
                else
                {
                    SessionDocumental.UsuarioInicioSession = null;
                    throw new Exception("No coincide usuario o contraseña");
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No coincide usuario o contraseña...');", true);
            }


        }



        public void PintarMsjError(string err)
        {
            //MsjBase.Text = err;
            //MsjBase.ForeColor = System.Drawing.Color.Red;
        }

        protected void ChkActiveDirectory_CheckedChanged(object sender, EventArgs e)
        {





            //string us = Page.User.Identity.Name;

            //string sUserDominioRed = Context.Request.ServerVariables["AUTH_USER"];
            //sUserDominioRed = sUserDominioRed.Split('\\')[1];

           // TxtUsuario.Text = Environment.UserName;
           // UsuarioWindown = Environment.UserName;

           //string domin=  Environment.UserDomainName;

            //WindowsIdentity user = WindowsIdentity.GetCurrent();
            //sUserDominioRed = user.Name;
            //sUserDominioRed = System.Security.Principal.WindowsIdentity.GetCurrent().Name;


            TxtUsuario.Text = Thread.CurrentPrincipal.Identity.Name;
            UsuarioWindown = Thread.CurrentPrincipal.Identity.Name;
          
            //Console.WriteLine("Token number is: " + accountToken.ToString());

            //string sUserDominioRed = Thread.CurrentPrincipal.Identity.Name;
            //sUserDominioRed = sUserDominioRed.Split('\\')[1];

           // TxtUsuario.Text = sUserDominioRed;
           // UsuarioWindown = sUserDominioRed;

           //string a = Context.User.Identity.Name;
           //string b = Context.User.Identity.AuthenticationType;

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('identidad del Usuario .config - ISS... XXX' " + UsuarioWindown + "  us: " + us + "  sUserDominioRed: " + sUserDominioRed + ");", true);

            //Label2.Text = " UsuarioWindown: " + UsuarioWindown + "  us: " + us + "  sUserDominioRed: " + sUserDominioRed  + "  a= " + a  + "  b= " + b;


            if (ChkActiveDirectory.Checked == true)
            {
                Button1.Enabled = false;
                IniciaSesionAntenticacionWin();

            }
            else
            {
                Button1.Enabled = true;
            }

        }




    }
}