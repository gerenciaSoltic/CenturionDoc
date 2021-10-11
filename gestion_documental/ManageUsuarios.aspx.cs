using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestion_documental.Utils;
using gestion_documental.DataAccessLayer;
using gestion_documental.BusinessObjects;
using MySql.Data.MySqlClient;
using System.Data;
using System.DirectoryServices;
using System.Text;
using System.Collections;
using System.DirectoryServices.ActiveDirectory;
using System.ComponentModel;
using System.Security.Principal;
using System.Net.NetworkInformation;


namespace gestion_documental
{
    public partial class ManageUsuarios : System.Web.UI.Page
    {

        string busca, correoelectronico, contrasenacorreo;


        #region Page Event
        Class1 proce = new Class1();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGvrUsuario();
            }

        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SettingsMenu.aspx", false);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SettingsMenu.aspx", false);
        }

        #endregion




        #region FillGvrUsuario

        protected void FillGvrUsuario()
        {
            ddlActivo.Items.Clear();
            ddlActivo.DataValueField = "codigo";
            ddlActivo.DataTextField = "nombre";
            ddlActivo.DataBind();
            ddlActivo.Items.Insert(0, new ListItem("Seleccionar", "0"));
            ddlActivo.Items.Insert(1, new ListItem("Activo", "True"));
            ddlActivo.Items.Insert(2, new ListItem("Inactivo", "False"));
            correoelectronico = "";
            contrasenacorreo = "";
            txtCorreoElectronico.Text = "";
            txtContrasenaCorreo.Text = "";
            gvUsuario.DataSource = new UsuariosManagement().GetAllUsuarios();


            ddlRol.Items.Clear();
            DataTable rolpermiso = new DataTable();
            proce.consultacampos("rolpermisos", "DISTINCT(rol) as idrol,rol",rolpermiso);

            ddlRol.DataSource = rolpermiso;
            ddlRol.DataValueField = "idrol";
            ddlRol.DataTextField = "rol";
            ddlRol.DataBind();
            ddlRol.Items.Insert(0, new ListItem("Seleccionar", "0"));
           
            
            //ddlRol.Items.Insert(1, new ListItem("1", "1"));
            //ddlRol.Items.Insert(2, new ListItem("2", "2"));
            //ddlRol.Items.Insert(3, new ListItem("3", "3"));
            //ddlRol.Items.Insert(4, new ListItem("4", "4"));
            //ddlRol.Items.Insert(5, new ListItem("5", "5"));
            //ddlRol.Items.Insert(6, new ListItem("26", "26"));
            gvUsuario.DataBind();

            

        }

        protected void gvUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            int UsuarioId = Convert.ToInt32(gvUsuario.SelectedDataKey.Value);
            Usuarios Usuario = new UsuariosManagement().GetUsuariosById(UsuarioId);

            txtNombre.Text = Usuario.NOMBRE;
            txtUsuario.Text = Usuario.USUARIO;
            txtContrasena.Text = Usuario.CONTRASENA;

            //string Contrasenia = Usuario.CONTRASENA;
            //string Resultado = new Encrypt().DecryptKey(Contrasenia);
            //txtContrasena.Text = Resultado;

            ddlRol.SelectedValue = Convert.ToString( Usuario.ROL );

            TxtUsuarioWin.Text = Usuario.USUARIOWIN;
            txtCorreoElectronico.Text = Usuario.CORREOELECTRONICO;
            txtContrasenaCorreo.Text = Usuario.CONTRASENACORREO;
           

            try
            {
                ddlActivo.SelectedValue = Usuario.ACTIVO + "";
            }
            catch (Exception exc) { ddlActivo.SelectedValue = "0"; }


            btnAddUsuario.Text = "Edit";
        }

        protected void gvUsuario_DeleteEventHandler(object sender, GridViewDeleteEventArgs e)
        {
            int idUsuario = (int)gvUsuario.DataKeys[Convert.ToInt32(e.RowIndex)].Value;

            if (!new UsuariosManagement().DeleteUsuarios(idUsuario))
            {
                omb.ShowMessage("Ocurrio un problema al eliminar el registro, quizas este siendo usado ...");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Ocurrio un problema al eliminar el registro, quizas este siendo usado');", true);
            }

            FillGvrUsuario();
        }


        protected void gvShowUsuario_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // reference the Delete LinkButton
                LinkButton db = (LinkButton)e.Row.Cells[9].Controls[0];

                db.OnClientClick = "return confirm('Esta seguro que desea eliminar ?');";
            }
        }

        protected void btnClearUsuario_Click(object sender, EventArgs e)
        {
            txtNombre.Text = String.Empty;
            txtUsuario.Text = String.Empty;
            txtContrasena.Text = String.Empty;
            ddlActivo.SelectedValue = "0";
            ddlRol.SelectedValue = "0";
            TxtUsuarioWin.Text = String.Empty;
            txtCorreoElectronico.Text = String.Empty;
            txtContrasenaCorreo.Text = String.Empty;
            btnAddUsuario.Text = "Añadir";
        }

        protected void btnAddUsuario_Click(object sender, EventArgs e)
        {
  

            if (btnAddUsuario.Text == "Añadir")
            {
                Usuarios Usuario = new Usuarios();

                if (ChkActiveDirectory.Checked == true)
                {
                    if (TxtUsuarioWin.Text.Trim() == "")
                    {
                        omb.ShowMessage("No Se Encontraron Registros ...");

                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe Asignar el Usuario Active Directory...');", true);
                        TxtUsuarioWin.Focus();
                        return;
                    }
                }

                Usuario.NOMBRE = txtNombre.Text;
                Usuario.USUARIO = txtUsuario.Text;
                Usuario.CONTRASENA = txtContrasena.Text;

                //string Contrasenia = txtContrasena.Text;
                //string Resultado = new Encrypt().EncryptKey(Contrasenia);
                //Usuario.CONTRASENA = Resultado;

                Usuario.IDINSTITUCION = Convert.ToInt16( SessionDocumental.UsuarioInicioSession.IDINSTITUCION.ToString() );
                Usuario.ACTIVO = ddlActivo.SelectedValue;
                Usuario.ROL = Convert.ToInt32( ddlRol.SelectedValue );
                Usuario.USUARIOWIN = TxtUsuarioWin.Text;
                Usuario.CORREOELECTRONICO = txtCorreoElectronico.Text;
                Usuario.CONTRASENACORREO = txtContrasenaCorreo.Text;
                

                new UsuariosManagement().InsertUsuarios(Usuario);
                FillGvrUsuario();
                btnClearUsuario_Click(null, null);
            }
            else
            {
                Usuarios Usuario = new Usuarios();


                if (ChkActiveDirectory.Checked == true)
                {
                    if (TxtUsuarioWin.Text.Trim() == "")
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Debe Asignar el Usuario Active Directory...');", true);
                        omb.ShowMessage("Debe Asignar el Usuario Active Directory ...");
                        TxtUsuarioWin.Focus();
                        return;
                    }
                }

                Usuario.CODIGO = Convert.ToInt32(gvUsuario.SelectedDataKey.Value);
                Usuario.NOMBRE = txtNombre.Text;
                Usuario.USUARIO = txtUsuario.Text;
                Usuario.CONTRASENA = txtContrasena.Text; 
                Usuario.ROL = Convert.ToInt32(ddlRol.SelectedValue);
                //string Contrasenia = txtContrasena.Text;
                //string Resultado = new Encrypt().EncryptKey(Contrasenia);
                //Usuario.CONTRASENA = Resultado;

                //string ResultadoDesencriptar = new Encrypt().DecryptKey(Contrasenia);

                Usuario.ACTIVO = ddlActivo.SelectedValue;
                Usuario.USUARIOWIN = TxtUsuarioWin.Text;
                Usuario.CORREOELECTRONICO = txtCorreoElectronico.Text;
                Usuario.CONTRASENACORREO = txtContrasenaCorreo.Text;

                new UsuariosManagement().UpdateUsuarios(Usuario);

                FillGvrUsuario();
                btnClearUsuario_Click(null, null);
            }
        }

        #endregion



        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }




        public void gruposwindows()
        {
            ddlGruposWindows.Items.Clear();

           

            DataTable gruposwin = new DataTable();
            proce.consultacampos("gruposwin", "idgruposwin,descripcion", gruposwin);
            //proce.consultacampos("gruposwin", "idgruposwin,descripcion", "idinstitucion =" + SessionDocumental.UsuarioInicioSession.IDINSTITUCION, gruposwin);

            ddlGruposWindows.Items.Insert(0, new ListItem("Seleccionar", "0"));
            ddlGruposWindows.DataSource = gruposwin;

            //string dato;
            //int cont = 0;
            
            //foreach (DataRow record in gruposwin.Rows)
            //{
            //    cont = cont + 1;
            //    dato = record["descripcion"].ToString();
            //    ddlGruposWindows.Items.Insert(cont , new ListItem(dato, Convert.ToString(cont)));
              
            //}
           

            //ddlGruposWindows.DataSource = gruposwin;
            //ddlGruposWindows.DataValueField = "idgruposwin";
            //ddlGruposWindows.DataTextField = "descripcion";
            //ddlGruposWindows.DataBind();

            //ddlGruposWindows.Items.Insert(1, new ListItem("Todos", "1"));
            //ddlGruposWindows.Items.Insert(2, new ListItem("SOLTIC", "2"));

            ddlGruposWindows.DataTextField = "descripcion";
            ddlGruposWindows.DataValueField = "idgruposwin";
            ddlGruposWindows.DataBind();
        }




        protected void tablaTmp()
        {


            //Primero vamos a crear una instancia del objecto DataTable 
            DataTable DatosUsuariosDirectoryActivos = new DataTable();

            //Se crean las columnas para el objecto DataTable que se acaba de crear y se le agrega el nombreque le queremos dar a nuestras columnas     
            DatosUsuariosDirectoryActivos.Columns.Add("UserName");
            DatosUsuariosDirectoryActivos.Columns.Add("DisplayName");
            DatosUsuariosDirectoryActivos.Columns.Add("Company");
            DatosUsuariosDirectoryActivos.Columns.Add("Deparment");
            DatosUsuariosDirectoryActivos.Columns.Add("JobTitle");
            DatosUsuariosDirectoryActivos.Columns.Add("Email");
            DatosUsuariosDirectoryActivos.Columns.Add("Phone");
            DatosUsuariosDirectoryActivos.Columns.Add("Mobile");
            DatosUsuariosDirectoryActivos.Columns.Add("Opciones");
            //Por ultimo mostramos los datos en un GridView     
            GridView1.DataSource = DatosUsuariosDirectoryActivos;
            GridView1.DataBind();

        }

        protected void ChkActiveDirectory_CheckedChanged(object sender, EventArgs e)
        {

            if (ChkActiveDirectory.Checked == true)
            {
                PnlUsuariosAvtiveDirectory.Visible = true;
                TxtUsuarioWin.Visible = true;
                ImageButton1.Visible = true;
                btnSincroniza.Visible = true;
                ddlGruposWindows.Visible = true;
                LblGrupo.Visible = true;
                LblUsuario.Visible = true;
                // lleno el ddlGruposWin
                gruposwindows();

                tablaTmp();              

            }
            else
            {
                PnlUsuariosAvtiveDirectory.Visible = false;
                TxtUsuarioWin.Visible = false;
                ImageButton1.Visible = false;
                btnSincroniza.Visible = false;
                LblGrupo.Visible = false;
                LblUsuario.Visible = false;

                //Por ultimo mostramos los datos en un GridView     
                GridView1.DataSource = "";
                //GridView1.DataBind();

                ddlGruposWindows.Visible = false;
            }



        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string enlace = GridView1.DataKeys[GridView1.PageIndex].Value.ToString();


            TxtUsuarioWin.Text = GridView1.SelectedDataKey[0].ToString();
            txtCorreoElectronico.Text = GridView1.SelectedDataKey[5].ToString();
            txtContrasenaCorreo.Text = GridView1.SelectedDataKey[6].ToString();

            //string Contrasenia = GridView1.SelectedDataKey[6].ToString();
            //string Resultado = new Encrypt().DecryptKey(Contrasenia);
            //txtContrasenaCorreo.Text = Resultado;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (ddlGruposWindows.SelectedItem.ToString() == "Seleccionar")
            {
                //GridView1.DataSource = "";
                tablaTmp();
                omb.ShowMessage("Seleccione un grupo ...");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Seleccione un grupo ...');", true);                
                ddlGruposWindows.Focus();
                return;
            }
            else if ((ddlGruposWindows.SelectedItem.ToString() == "Todos") || (ddlGruposWindows.SelectedItem.ToString() == "TODOS"))
            {
                ListarTodosLosUsuariosWin();
            }
            else
            {
                ListarGrupoUsuariosWin();
            }
            GridView1.PageIndex = e.NewPageIndex;
        }

        protected void ListarTodosLosUsuariosWin()
        {
            List<User> rst = new List<User>();
            //string DomainPath = "LDAP://ISSO/CN=programador2,CN=Users,DC=ISSO,DC=LOCAL";

            //string DomainPath = "LDAP://DC=XXXXXX,DC=YYY";            
            //string DomainPath = "LDAP://DC=ISSO,DC=LOCAL";
           // string DomainPath = "LDAP://DC=ISSO,DC=LOCAL";
            //LDAP: //192.168.0.146/CN=USERS,DC=capp,DC=net

            string DomainPath = "LDAP://" + Environment.GetEnvironmentVariable("USERDOMAIN");
            //string DomainPath = "LDAP://" + "ISSO";
            //string DomainPath = "LDAP://CN=SOLTIC,CN=Users,DC=ISSO,DC=LOCAL";

            DirectoryEntry adSearchRoot = new DirectoryEntry(DomainPath);
            DirectorySearcher adSearcher = new DirectorySearcher(adSearchRoot);

            //string group = "SOLTIC";
            try
            {

                adSearcher.Filter = "(&(objectClass=user)(objectCategory=person))";

               // adSearcher.Filter = "(&(objectClass=group)(cn=" + group + "))";

                adSearcher.PropertiesToLoad.Add("samaccountname");
                adSearcher.PropertiesToLoad.Add("displayname");
                adSearcher.PropertiesToLoad.Add("company");
                adSearcher.PropertiesToLoad.Add("department");
                adSearcher.PropertiesToLoad.Add("title");
                adSearcher.PropertiesToLoad.Add("mail");
                adSearcher.PropertiesToLoad.Add("telephoneNumber");
                adSearcher.PropertiesToLoad.Add("mobile");
                adSearcher.PropertiesToLoad.Add("usergroup");
                //adSearcher.PropertiesToLoad.Add("groupType");
                //adSearcher.PropertiesToLoad.Add("primaryGroupToken");
                
                SearchResult result;
                SearchResultCollection iResult = adSearcher.FindAll();

                User item;
                if (iResult != null)
                {
                    for (int counter = 0; counter < iResult.Count; counter++)
                    {
                        result = iResult[counter];
                        if (result.Properties.Contains("samaccountname"))
                        {
                            item = new User();

                            item.UserName = (String)result.Properties["samaccountname"][0];

                            if (result.Properties.Contains("displayname"))
                            {
                                item.DisplayName = (String)result.Properties["displayname"][0];
                            }

                            if (result.Properties.Contains("mail"))
                            {
                                item.Email = (String)result.Properties["mail"][0];
                            }                           

                            if (result.Properties.Contains("company"))
                            {
                                item.Company = (String)result.Properties["company"][0];
                            }

                            if (result.Properties.Contains("title"))
                            {
                                item.JobTitle = (String)result.Properties["title"][0];
                            }

                            if (result.Properties.Contains("department"))
                            {
                                item.Deparment = (String)result.Properties["department"][0];
                            }

                            if (result.Properties.Contains("telephoneNumber"))
                            {
                                item.Phone = (String)result.Properties["telephoneNumber"][0];
                            }

                            if (result.Properties.Contains("mobile"))
                            {
                                item.Mobile = (String)result.Properties["mobile"][0];
                            }

                            if (result.Properties.Contains("usergroup"))
                            {
                                item.usergroup = (String)result.Properties["usergroup"][0];
                            }

                            rst.Add(item);
                        }
                    }
                }

                adSearcher.Dispose();
                adSearchRoot.Dispose();


                if (rst.Count > 0)
                {
                    DataTable DatosUsuariosDirectoryActivos = ConvertToDataTable(rst);
                    GridView1.DataSource = DatosUsuariosDirectoryActivos;
                    GridView1.DataBind();
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No se encuentra el Active Directory...');", true);
                return;
            }



        }

        protected void ListarGrupoUsuariosWin()
        {

        
            List<User> rst = new List<User>();
            //string DomainPath = "LDAP://ISSO/CN=programador2,CN=Users,DC=ISSO,DC=LOCAL";

            //string DomainPath = "LDAP://DC=XXXXXX,DC=YYY";            
            //string DomainPath = "LDAP://DC=ISSO,DC=LOCAL";

            string DomainPath = "LDAP://" + Environment.GetEnvironmentVariable("USERDOMAIN");
            //string DomainPath = "LDAP://CN=SOLTIC,CN=Users,DC=ISSO,DC=LOCAL";

            DirectoryEntry adSearchRoot = new DirectoryEntry(DomainPath);
            DirectorySearcher adSearcher = new DirectorySearcher(adSearchRoot);

            //string group = "SOLTIC";
            try
            {

                adSearcher.Filter = "(&(objectClass=user)(objectCategory=person))";

                // adSearcher.Filter = "(&(objectClass=group)(cn=" + group + "))";

                adSearcher.PropertiesToLoad.Add("samaccountname");
                adSearcher.PropertiesToLoad.Add("displayname");
                adSearcher.PropertiesToLoad.Add("company");
                adSearcher.PropertiesToLoad.Add("department");
                adSearcher.PropertiesToLoad.Add("title");
                adSearcher.PropertiesToLoad.Add("mail");                                
                adSearcher.PropertiesToLoad.Add("telephoneNumber");
                adSearcher.PropertiesToLoad.Add("mobile");
                adSearcher.PropertiesToLoad.Add("usergroup");
                
                SearchResult result;
                SearchResultCollection iResult = adSearcher.FindAll();

                User item;
                if (iResult != null)
                {
                    for (int counter = 0; counter < iResult.Count; counter++)
                    {
                        result = iResult[counter];
                        if (result.Properties.Contains("samaccountname"))
                        {
                            item = new User();

                            item.UserName = (String)result.Properties["samaccountname"][0];

                            if (result.Properties.Contains("displayname"))
                            {
                                item.DisplayName = (String)result.Properties["displayname"][0];
                            }

                            if (result.Properties.Contains("mail"))
                            {
                                item.Email = (String)result.Properties["mail"][0];
                            }

                            if (result.Properties.Contains("company"))
                            {
                                item.Company = (String)result.Properties["company"][0];
                            }

                            if (result.Properties.Contains("title"))
                            {
                                item.JobTitle = (String)result.Properties["title"][0];
                            }

                            if (result.Properties.Contains("department"))
                            {
                                item.Deparment = (String)result.Properties["department"][0];
                            }

                            if (result.Properties.Contains("telephoneNumber"))
                            {
                                item.Phone = (String)result.Properties["telephoneNumber"][0];
                            }

                            if (result.Properties.Contains("mobile"))
                            {
                                item.Mobile = (String)result.Properties["mobile"][0];
                            }

                            if (result.Properties.Contains("usergroup"))
                            {
                                item.Email = (String)result.Properties["usergroup"][0];
                            }
                            rst.Add(item);
                        }
                    }
                }

                adSearcher.Dispose();
                adSearchRoot.Dispose();


                if (rst.Count > 0)
                {


                            List<ADUsuaioWin> usu = new List<ADUsuaioWin>();

                            DataTable DatosUsuariosDirectoryActivos = ConvertToDataTable(rst);

                            //DataTable DatosUsuariosGrupo = new DataTable(); 
                            DataRow[] RenglonesEncontrados;

                   
                            ///Este codigo me trae un dt de los usuarios filtrados por grupo
                            string Grupo = ddlGruposWindows.SelectedItem.Text;
                            //string Grupo = "SOLTIC";
                            List<ADUser> users = ManageUsuarios.GetUsersInGroup(Grupo);
                            if (users.Count > 0)
                            {
                                
                                DataTable DatosUsuariosGrupo = ConvertToDataTable(users);

                                List<ADUsuarioWinGrupo> Ltusu = new List<ADUsuarioWinGrupo>();
                                ADUsuarioWinGrupo it;
                                
                                foreach (DataRow record in DatosUsuariosGrupo.Rows)
                                {
                                    busca = record["SAMAccountName"].ToString();

                                    //string busca = "programador2";
                                    RenglonesEncontrados = DatosUsuariosDirectoryActivos.Select("UserName = '" + busca + "'");


                                    foreach (DataRow row in RenglonesEncontrados)
                                    {                                        
                                        //Console.WriteLine("{0}, {1}", row[0], row[1]);                                                                                
                                        it = new ADUsuarioWinGrupo();
                                        
                                        it.UserName = row[0].ToString();
                                        it.DisplayName = row[1].ToString();
                                        it.Company = row[2].ToString();
                                        it.Deparment = row[3].ToString();
                                        it.JobTitle = row[4].ToString();
                                        it.Email = row[5].ToString();                                        
                                        it.Phone = row[6].ToString();
                                        it.Mobile = row[7].ToString();
                                        //.usergroup = row[8].ToString();

                                        Ltusu.Add(it);
                                    }

                                }

                                if (Ltusu.Count > 0)
                                {
                                    DataTable DatosUsuariosGrupoDirectoryActivos = ConvertToDataTable(Ltusu);
                                    GridView1.DataSource = DatosUsuariosGrupoDirectoryActivos;
                                    GridView1.DataBind();
                                }
                            }

                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No se encuentra el Active Directory...');", true);
                return;
            }

        

        }





        public class ADUser
        {
            public byte[] Sid { get; set; }
            public string Name { get; set; }
            public string DistinguishedName { get; set; }
            public string SAMAccountName { get; set; }
            public string DisplayName { get; set; }
            //public string Email { get; set; }

            //public string UserName { get; set; }
            //public string Company { get; set; }
            //public string Deparment { get; set; }
            //public string JobTitle { get; set; }

            //public string Phone { get; set; }
            //public string Mobile { get; set; }
            //public int RoleType { get; set; }

            public ADUser(byte[] sid, string name,
                string distinguishedName, string sAMAccountName, string displayname)  //, string email
            {
                Sid = sid;
                Name = name;
                DistinguishedName = distinguishedName;
                SAMAccountName = sAMAccountName;
                DisplayName = displayname;
               // Email = email;
            }

            public string sIDtoString()
            {
                SecurityIdentifier sid = new SecurityIdentifier(Sid, 0);
                return sid.ToString();
            }
        }


        public static string getDomainName()
        {
            return IPGlobalProperties.GetIPGlobalProperties().DomainName;
        }

        public static string getLDAPDomainName(string domainName)
        {
            StringBuilder sb = new StringBuilder();
            string[] dcItems = domainName.Split(".".ToCharArray());
            sb.Append("LDAP://");
            foreach (string item in dcItems)
            {
                sb.AppendFormat("DC={0},", item);
            }
            return sb.ToString().Substring(0, sb.ToString().Length - 1);
        }


        public static List<ADUser> GetUsersInGroup(string group)
        {
            //LDAP: //192.168.0.146/CN=USERS,DC=capp,DC=net
            List<ADUser> users = new List<ADUser>();
            string ldapDomainName = ManageUsuarios.getLDAPDomainName(ManageUsuarios.getDomainName());
            string domainName = ldapDomainName.Replace("LDAP://", string.Empty);
            List<string> groupMemebers = new List<string>();

            DirectoryEntry de = new DirectoryEntry(ldapDomainName); //LDAP://DC=ISSO,DC=LOCAL
            DirectorySearcher ds = new DirectorySearcher(de, "(objectClass=person)");
            ds.Filter = "(&(objectClass=group)(cn=" + group + "))";


            foreach (SearchResult result in ds.FindAll())
            {
                var dir = result.GetDirectoryEntry();
                var list = dir.Invoke("Members");
                IEnumerable entries = (IEnumerable)list;
                foreach (var entry in entries)
                {
                    DirectoryEntry member = new DirectoryEntry(entry);
                    if (member.SchemaClassName == "group")
                    {
                        List<ADUser> usersInGroup =
                            GetUsersInGroup(member.Properties["name"][0].ToString());
                        foreach (ADUser aduser in usersInGroup)
                        {
                            if (!users.ToDictionary(u => u.Name).ContainsKey(aduser.Name))
                            {
                                users.Add(aduser);
                            }
                        }
                    }
                    else
                    {
                        //string VAEMAIL = member.Properties["email"][0].ToString();
                        //if (VAEMAIL == null)
                        //{
                        //    VAEMAIL = "A@A";
                        //}
 
                        ADUser aduser = new ADUser(
                            (byte[])member.Properties["objectSid"][0],
                            member.Properties["name"][0].ToString(),
                            member.Properties["distinguishedName"][0].ToString(),
                            member.Properties["sAMAccountName"][0].ToString(),
                            member.Properties["displayname"][0].ToString());
                           // VAEMAIL);

                            //"A@A");
                            //member.Properties["email"][0].ToString());
                        //member.Properties["company"][0].ToString()),
                        //member.Properties["title"][0].ToString()),
                        //member.Properties["department"][0].ToString()),
                        //member.Properties["telephoneNumber"][0].ToString()),
                        //member.Properties["mobile"][0].ToString());

                        users.Add(aduser);



                    }
                }
            }

            //if (users.Count > 0)
            //{
            //    DataTable DatosUsuariosGrupo = ConvertToDataTable(users);
            //}

            return users;


        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

            //string Grupo = ddlGruposWindows.SelectedItem.Text;
            if (ddlGruposWindows.SelectedItem.ToString() =="Seleccionar")
            {
                //GridView1.DataSource = "";
                tablaTmp();
                omb.ShowMessage("Seleccione un grupo ...");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Seleccione un grupo ...');", true);                
                ddlGruposWindows.Focus();
                return;
            }
            else if ( (ddlGruposWindows.SelectedItem.ToString() == "Todos") || (ddlGruposWindows.SelectedItem.ToString() == "TODOS") )
            {
                ListarTodosLosUsuariosWin();                
            }
            else
            {
                ListarGrupoUsuariosWin();
            }

            

        }






        protected void SincronizaGrupo()
        {

           
            int cont = 0;

            List<User> rst = new List<User>();
            //string DomainPath = "LDAP://ISSO/CN=programador2,CN=Users,DC=ISSO,DC=LOCAL";

            //string DomainPath = "LDAP://DC=XXXXXX,DC=YYY";            
            //string DomainPath = "LDAP://DC=ISSO,DC=LOCAL";

            string DomainPath = "LDAP://" + Environment.GetEnvironmentVariable("USERDOMAIN");
            //string DomainPath = "LDAP://CN=SOLTIC,CN=Users,DC=ISSO,DC=LOCAL";

            DirectoryEntry adSearchRoot = new DirectoryEntry(DomainPath);
            DirectorySearcher adSearcher = new DirectorySearcher(adSearchRoot);

            //string group = "SOLTIC";
            try
            {

                adSearcher.Filter = "(&(objectClass=user)(objectCategory=person))";

                // adSearcher.Filter = "(&(objectClass=group)(cn=" + group + "))";

                adSearcher.PropertiesToLoad.Add("samaccountname");
                adSearcher.PropertiesToLoad.Add("displayname");
                adSearcher.PropertiesToLoad.Add("company");
                adSearcher.PropertiesToLoad.Add("department");
                adSearcher.PropertiesToLoad.Add("title");
                adSearcher.PropertiesToLoad.Add("mail");
                adSearcher.PropertiesToLoad.Add("telephoneNumber");
                adSearcher.PropertiesToLoad.Add("mobile");
                adSearcher.PropertiesToLoad.Add("usergroup");

                SearchResult result;
                SearchResultCollection iResult = adSearcher.FindAll();

                User item;
                if (iResult != null)
                {
                    for (int counter = 0; counter < iResult.Count; counter++)
                    {
                        result = iResult[counter];
                        if (result.Properties.Contains("samaccountname"))
                        {
                            item = new User();

                            item.UserName = (String)result.Properties["samaccountname"][0];

                            if (result.Properties.Contains("displayname"))
                            {
                                item.DisplayName = (String)result.Properties["displayname"][0];
                            }

                            if (result.Properties.Contains("mail"))
                            {
                                item.Email = (String)result.Properties["mail"][0];
                            }

                            if (result.Properties.Contains("company"))
                            {
                                item.Company = (String)result.Properties["company"][0];
                            }

                            if (result.Properties.Contains("title"))
                            {
                                item.JobTitle = (String)result.Properties["title"][0];
                            }

                            if (result.Properties.Contains("department"))
                            {
                                item.Deparment = (String)result.Properties["department"][0];
                            }

                            if (result.Properties.Contains("telephoneNumber"))
                            {
                                item.Phone = (String)result.Properties["telephoneNumber"][0];
                            }

                            if (result.Properties.Contains("mobile"))
                            {
                                item.Mobile = (String)result.Properties["mobile"][0];
                            }

                            if (result.Properties.Contains("usergroup"))
                            {
                                item.Email = (String)result.Properties["usergroup"][0];
                            }
                            rst.Add(item);
                        }
                    }
                }

                adSearcher.Dispose();
                adSearchRoot.Dispose();


                if (rst.Count > 0)
                {


                    List<ADUsuaioWin> usu = new List<ADUsuaioWin>();

                    DataTable DatosUsuariosDirectoryActivos = ConvertToDataTable(rst);

                    //DataTable DatosUsuariosGrupo = new DataTable(); 
                    DataRow[] RenglonesEncontrados;


                    ///Este codigo me trae un dt de los usuarios filtrados por grupo
                    string Grupo = ddlGruposWindows.SelectedItem.Text;
                    //string Grupo = "SOLTIC";
                    List<ADUser> users = ManageUsuarios.GetUsersInGroup(Grupo);
                    if (users.Count > 0)
                    {

                        DataTable DatosUsuariosGrupo = ConvertToDataTable(users);

                        List<ADUsuarioWinGrupo> Ltusu = new List<ADUsuarioWinGrupo>();
                        ADUsuarioWinGrupo it;

                        foreach (DataRow record in DatosUsuariosGrupo.Rows)
                        {
                            busca = record["SAMAccountName"].ToString();

                            //string busca = "programador2";
                            RenglonesEncontrados = DatosUsuariosDirectoryActivos.Select("UserName = '" + busca + "'");


                            foreach (DataRow row in RenglonesEncontrados)
                            {
                                //Console.WriteLine("{0}, {1}", row[0], row[1]);                                                                                
                                it = new ADUsuarioWinGrupo();

                                it.UserName = row[0].ToString();
                                it.DisplayName = row[1].ToString();
                                it.Company = row[2].ToString();
                                it.Deparment = row[3].ToString();
                                it.JobTitle = row[4].ToString();
                                it.Email = row[5].ToString();
                                it.Phone = row[6].ToString();
                                it.Mobile = row[7].ToString();
                                //.usergroup = row[8].ToString();

                                Ltusu.Add(it);
                            }

                        }

                        if (Ltusu.Count > 0)
                        {
                            DataTable DatosUsuariosGrupoDirectoryActivos = ConvertToDataTable(Ltusu);
                            GridView1.DataSource = DatosUsuariosGrupoDirectoryActivos;
                            GridView1.DataBind();

                            //---

                            //trae los usuarios de la aplicacion
                            DataTable UsuariosAplicativo = new DataTable();
                            proce.consultacampos("usuarios", "codigo,usuariowin", UsuariosAplicativo);

                            DataRow[] RenglonesEncontradosGrupo;
                            
                            foreach (DataRow record in DatosUsuariosGrupoDirectoryActivos.Rows)
                            {
                                
                                busca = record["UserName"].ToString();
                                correoelectronico = record["Email"].ToString();
                                if (correoelectronico == null)
                                {
                                    correoelectronico = "a@a.com";
                                }

                                RenglonesEncontradosGrupo = UsuariosAplicativo.Select("usuariowin = '" + busca + "'");

                                // Call Select.
                                DataRow[] rows = UsuariosAplicativo.Select("usuariowin = '" + busca + "'");

                                if (rows.Length > 0)
                                {
                                  
                                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Encontro');", true);
                                    ////FillGvrUsuario();
                                    //btnClearUsuario_Click(null, null);
         
                                    //string codigousuario = rows[0].ItemArray.ToString();
                                  
                                    ConnectionClass conectar = new ConnectionClass();
                                    MySqlCommand comando;

                                    conectar.Connection.Close();
                                    conectar.conectar();

                                    conectar.Connection.Open();
                                    comando = new MySqlCommand("Update Usuarios set correoelectronico= '" + correoelectronico + "' where usuariowin='" + busca.Trim() + "'", conectar.Connection);
                                    comando.ExecuteNonQuery();
                                    conectar.Connection.Close();

                                }
                                else
                                {
                                    cont= cont + 1;
                                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Falta Registar');", true);
                                    string clave;

                                    if (busca.Length > 20)
                                    {
                                        clave = busca.Substring(0, 19);
                                    }
                                    else
                                    {
                                        clave = busca;
                                    }
                                    
                                    //string resultado = new Encrypt().EncryptKey(clave);

                                    Usuarios Usuario = new Usuarios();
                                    Usuario.NOMBRE = busca;
                                    Usuario.USUARIO = busca;
                                    Usuario.CONTRASENA = busca;
                                   // Usuario.CONTRASENA = resultado;
                                    Usuario.IDINSTITUCION = Convert.ToInt16(SessionDocumental.UsuarioInicioSession.IDINSTITUCION.ToString());
                                    Usuario.ACTIVO = "True";
                                    Usuario.ROL = 1;
                                    Usuario.USUARIOWIN = busca;
                                    Usuario.CORREOELECTRONICO = correoelectronico;
                                    Usuario.CONTRASENACORREO = "";

                                    new UsuariosManagement().InsertUsuarios(Usuario);                                    
                                    //btnClearUsuario_Click(null, null);

                                }

                            }


                            //---
                        }
                



                    }

                }


                //FillGvrUsuario();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No se encuentra el Active Directory...');" + ex, true);
                omb.ShowMessage("No se encuentra el Active Directory ...");
                return;
            }




                if (cont > 0)
                {
                    omb.ShowMessage("Sincronización Exitosa...  Usuarios Creados: '); [" + cont + "]  Recuerde Asignar el Rol al Usuario. !");
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Sincronización Exitosa...  Usuarios Creados: '); [" + cont + "]  Recuerde Asignar el Rol al Usuario. !", true);
                }
                else
                {
                      omb.ShowMessage("El Proceso Termino Correctamente ...");
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('El Proceso Termino Correctamente ... ", true);

                }
               

       

        }




        protected void btnSincroniza_Click(object sender, EventArgs e)
        {


            if ((ddlGruposWindows.SelectedItem.ToString() == "Seleccionar") || (ddlGruposWindows.SelectedItem.ToString() == "Todos") || (ddlGruposWindows.SelectedItem.ToString() == "TODOS"))
            {

                 //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Seleccione un grupo ...');", true);
                 omb.ShowMessage("Seleccione un grupo...");

                ddlGruposWindows.Focus();
                return;
            }
            else
            {

                SincronizaGrupo();
                FillGvrUsuario();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('El Proceso Termino Correctamente ... ", true);
                omb.ShowMessage("El Proceso Termino Correctamente ...");
                return;

            }



        }



    }
}