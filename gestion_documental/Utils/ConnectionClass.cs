using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace gestion_documental.Utils
{
    public class ConnectionClass
    {
        #region Constructors

        public ConnectionClass()
        {
            this.Connection = new MySqlConnection(this.GetConnectionString());
            this.ConnectionLocal = new MySqlConnection(this.GetLocConnectionString());
        }

        public ConnectionClass(MySqlConnection conn)
        {
            this.Connection = conn;
            this.ConnectionLocal = conn;
        }

        public ConnectionClass(string connectionstring)
        {
            this.Connection = new MySqlConnection(connectionstring);
            this.ConnectionLocal = new MySqlConnection(connectionstring);
        }

        #endregion

        public MySqlConnection Connection { get; set; }

        public MySqlConnection ConnectionLocal { get; set; }

        public MySqlTransaction Transaction { get; set; }


        private string GetConnectionString()
        {
           
            //connection string 
            string lcSarta = conectar();

            return @lcSarta;

            
        }

        private string GetLocConnectionString()
        {

            //connection string 
            string lcSartaLocal = conectarLocal();

            return @lcSartaLocal;


        }
        public int aEntero(object obj)
        {
            int ret = 0;
            if (obj != System.DBNull.Value)
                ret = Convert.ToInt32(obj);
            return ret;
        }

        public string conectar()
        {
            string lcSarta = recuperacadena();
            return lcSarta;
           // conexion = new MySqlConnection(lcSarta);

        }

        public string conectarLocal()
        {
            string lcSartaLocal = recuperacadenaLocal();
            return lcSartaLocal;
            // conexion = new MySqlConnection(lcSarta);

        }

        public string recuperacadena()
        {
            string lcsarta = "";

            System.Configuration.Configuration rootWebConfig1 =
                   System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            if (0 < rootWebConfig1.AppSettings.Settings.Count)
            {
                System.Configuration.KeyValueConfigurationElement server = rootWebConfig1.AppSettings.Settings["server"];
                System.Configuration.KeyValueConfigurationElement puerto = rootWebConfig1.AppSettings.Settings["puerto"];
                System.Configuration.KeyValueConfigurationElement Basedatos = rootWebConfig1.AppSettings.Settings["Basedatos"];
                System.Configuration.KeyValueConfigurationElement usuario = rootWebConfig1.AppSettings.Settings["usuario"];
                System.Configuration.KeyValueConfigurationElement contrasena = rootWebConfig1.AppSettings.Settings["contrasena"];
                lcsarta = "server=" + server.Value.ToString() + "; port=" + puerto.Value.ToString() + ";User Id=" + usuario.Value.ToString() + ";password=" + contrasena.Value.ToString() + ";database=" + Basedatos.Value.ToString() + ";Persist Security Info=True";
            }
            return lcsarta;
        }

        public string recuperacadenaLocal()
        {
            string lcsartaLocal = "";

            System.Configuration.Configuration rootWebConfig1 =
                   System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            if (0 < rootWebConfig1.AppSettings.Settings.Count)
            {
                System.Configuration.KeyValueConfigurationElement server = rootWebConfig1.AppSettings.Settings["server1"];
                System.Configuration.KeyValueConfigurationElement puerto = rootWebConfig1.AppSettings.Settings["puerto1"];
                System.Configuration.KeyValueConfigurationElement Basedatos = rootWebConfig1.AppSettings.Settings["Basedatos1"];
                System.Configuration.KeyValueConfigurationElement usuario = rootWebConfig1.AppSettings.Settings["usuario1"];
                System.Configuration.KeyValueConfigurationElement contrasena = rootWebConfig1.AppSettings.Settings["contrasena1"];
                lcsartaLocal = "server=" + server.Value.ToString() + "; port=" + puerto.Value.ToString() + ";User Id=" + usuario.Value.ToString() + ";password=" + contrasena.Value.ToString() + ";database=" + Basedatos.Value.ToString() + ";Persist Security Info=True";
            }
            return lcsartaLocal;
        }

        //public string recuperacadena()
        //{
        //    string lcsarta = "";
        //    string host = HttpContext.Current.Request.Url.Host;
            
        //    //string nomconex = "";
        //    //if (host == "localhost")
        //    //{
        //    //    nomconex = "ConexLocal";
        //    //}
        //    //else
        //    //{
        //    //    nomconex = "ConexRemota";
        //    //}

        //    SqlConnection _cnn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConexRemota"].ToString());
        //    lcsarta = _cnn.ConnectionString;
        //    return lcsarta;
        //}

    }
}