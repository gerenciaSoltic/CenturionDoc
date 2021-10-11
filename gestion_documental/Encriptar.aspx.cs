using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestion_documental.DataAccessLayer;
using System.Data;
using MySql.Data.MySqlClient;
using gestion_documental.Utils;

namespace gestion_documental
{
    public partial class Encriptar : System.Web.UI.Page
    {
        string Usuario;
        int cont;
        Class1 proce = new Class1();


        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
                Usuario = SessionDocumental.UsuarioInicioSession.USUARIO.ToString();
                
            //}
        }



        #region FillGvrUsuario

        protected void FillGvrUsuario()
        {

            gvUsuario.DataSource = new UsuariosManagement().GetAllUsuarios();
            gvUsuario.DataBind();

        }

        #endregion



        protected void btnListar_Click(object sender, EventArgs e)
        {

            FillGvrUsuario();

        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            gvUsuario.DataSource = "";
            gvUsuario.DataBind();

        }

        protected void BtnEncriptar_Click(object sender, EventArgs e)
        {
            cont = 0;

            if(Usuario != "ADMIN")
            {
                omb.ShowMessage("Usuario No Autoizado ...");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Usuario No Autoizado ...');", true);
                return;   
            }
            else
            {

                //trae los usuarios de la aplicacion
                DataTable UsuariosAplicativo = new DataTable();
                proce.consultacampos("usuarios", "codigo,usuario,contrasena", UsuariosAplicativo);

                try
                {
                    if (UsuariosAplicativo.Rows.Count > 0)
                    {

                        foreach (DataRow record in UsuariosAplicativo.Rows)
                        {
                            string codigo = record["codigo"].ToString();
                            string usuario = record["usuario"].ToString();
                            string contrasena = record["contrasena"].ToString();
                            string resultado = new Encrypt().EncryptKey(contrasena);

                            if (usuario != "ADMIN")
                            {
                                cont = cont + 1;

                                ConnectionClass conectar = new ConnectionClass();
                                MySqlCommand comando;

                                conectar.Connection.Close();
                                conectar.conectar();

                                conectar.Connection.Open();
                                comando = new MySqlCommand("Update Usuarios set contrasena= '" + resultado + "' where codigo='" + codigo + "'", conectar.Connection);
                                comando.ExecuteNonQuery();
                                conectar.Connection.Close();
                            }
                            //else
                            //{
                            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Usuario Admin...');", true);

                            //}


                        }
                    }




                }
                catch(Exception ex)
                {
                    omb.ShowMessage("Error de Encriptamiento: '); [" + ex + "] ");
                    
                   // ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Error de Encriptamiento...');", true);
                    return;
                }





                //if (cont > 0)
                //{
                    omb.ShowMessage("El Proceso Termino Correctamente...  Usuarios Encriptados : '); [" + cont + "] ");
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('El Proceso Termino Correctamente ...  Usuarios Encriptados: '); [" + cont + "]  ", true);
                //}
                //else
                //{
                //    omb.ShowMessage("El Proceso Termino Correctamente ...");
                //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('El Proceso Termino Correctamente ... ", true);

                //}

                FillGvrUsuario();



            }

           

        }

        protected void gvShowUsuario_RowDataBound(object sender, GridViewRowEventArgs e)
        {


        }

        protected void gvUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}