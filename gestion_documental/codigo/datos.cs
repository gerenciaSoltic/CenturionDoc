using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;


namespace gestion_documental.codigo
{
    public class datos
    {
        public MySqlConnection conexion;
        public MySqlCommand ejecutar;
        public MySqlDataReader registros1;
        public string sentencia;
        public string valor;


        public void conectar(ref string conecto)
        {

         string servidor = "localhost";
         string basedatos = "centurionbarranca";
         string usuario = "root";
         string password = "";
         string cadenaconexion = "SERVER="+servidor+"; DATABASE="+basedatos+";UID="+usuario+";PWD="+password;
         conexion = new MySqlConnection(cadenaconexion);
         
         conecto = "SI";
         try
         {
             conexion.Open();
             
             
         }
         catch (MySqlException ex)
         {
             //MessageBox.Show("No es posible conectar" + Convert.ToString(ex));
             conecto = "SI";
         }
        

         


        }

        public void Consultar(string consulta, ref MySqlDataReader registros)
        {
            string conecto1 = "SI";
            conectar(ref conecto1);
            if (conecto1=="SI")
            {

                MySqlCommand myCommand = new MySqlCommand(consulta, conexion);
                registros = myCommand.ExecuteReader();
                
            }
            

        }

        public void ValidarClave(string tcUsuario, string tcClave, ref Boolean exito)
        {

            string consulta1 = "SELECT contrasena FROM usuarios WHERE usuario='" + tcUsuario + "'";
           
            
            Consultar(consulta1, ref registros1);

            if (registros1.Read())
            {
                if (registros1.GetString(0) == tcClave)
                {
                      
                    //MessageBox.Show("Bienvenido.. " + tcUsuario);
                    
                    exito = true;
                }
                else
                {

                    //MessageBox.Show("Clave errada");
                }

            }
            else
            {
                //MessageBox.Show("Clave errada");

            }
            registros1.Close();
            conexion.Close();

        }

        public void sinDocumentosPendientes(string tcUsuario)
        {


        }
    }
}