using System;
using System.IO;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gestion_documental
{
    public partial class partirpdfs : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DataTable Datos1 = new DataTable();

                DataColumn DOCUMENTO = new DataColumn("DOCUMENTO");
                DOCUMENTO.DataType = System.Type.GetType("System.String");
                Datos1.Columns.Add(DOCUMENTO);

                DataColumn PAGDESDE = new DataColumn("PAGDESDE");
                PAGDESDE.DataType = System.Type.GetType("System.Int32");
                Datos1.Columns.Add(PAGDESDE);

                DataColumn PAGHASTA = new DataColumn("PAGHASTA");
                PAGHASTA.DataType = System.Type.GetType("System.Int32");
                Datos1.Columns.Add(PAGHASTA);


                Session.Add("Datos1", Datos1);



            }

        }

 protected void btnUpload_Click(object sender, EventArgs e)
{
    DataTable Datos1 = Session["Datos1"] as DataTable;
    HttpFileCollection fileCollection = Request.Files;
    for (int i = 0; i < fileCollection.Count; i++)
        {
    HttpPostedFile uploadfile = fileCollection[i];
    string fileName = Path.GetFileName(uploadfile.FileName);
    if (uploadfile.ContentLength > 0)
        {
            uploadfile.SaveAs(Server.MapPath("~/unirpdfs/") + fileName);
            txtverdoc.Text = fileName;
        
}   
}
}

 protected void Button1_Click(object sender, EventArgs e)
 {

     DataTable dtResultado = new DataTable();
     DataTable Datos1 = Session["Datos1"] as DataTable;

     string lcCaminoInicial = Server.MapPath("~/unirpdfs/");


     string lcSarta = "";

     for (int i = 0;i< Datos1.Rows.Count; i++)
     {
         lcSarta = lcSarta + "," + Datos1.Rows[i]["pagdesde"] + "-" + Datos1.Rows[i]["paghasta"];
     }
     lcSarta = lcSarta.Substring(1);
     string[] listaArchivos = lcSarta.Split(',');
       

     ManejoPdfs DivideArchivos = new ManejoPdfs();
     dtResultado.Clear();

     dtResultado = DivideArchivos.Dividir(lcCaminoInicial+"\\"+txtverdoc.Text, listaArchivos,"");

     GridView2.DataSource = dtResultado;
     GridView2.DataBind();
     if (dtResultado.Rows.Count > 0)
     {
         Label4.Visible = true;
         Label4.Text = "Errores durante el proceso";


     }
     else
     {
         Label4.Visible = true;
         Label4.Text = "Proceso Realizado con Exito";

         Button5.Visible = true;
         Session.Add("narc",Datos1.Rows.Count);
         Session.Add("Actual", 1);
         Button5.Text = "Descargar Archivo No..1";
     }

 }

 

 protected void Button4_Click(object sender, EventArgs e)
 {
     string _open = "window.open('unirpdfs/"+ txtverdoc.Text+"', '_blank');";
     ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
 }

 protected void Button2_Click(object sender, EventArgs e)
 {
     DataTable Datos1 = Session["Datos1"] as DataTable;
     DataRow Fila = Datos1.NewRow();
     
     Fila["PAGDESDE"] = Convert.ToInt32(txtpagdesde.Text);
     Fila["PAGHASTA"] = Convert.ToInt32(txtpaghasta.Text);
     Datos1.Rows.Add(Fila);
     GridView1.DataSource = Datos1;
     GridView1.DataBind();

    
     txtpagdesde.Text = "";
     txtpaghasta.Text = "";
     Session["Datos1"] = Datos1;


 }

 protected void Button3_Click(object sender, EventArgs e)
 {


     if (GridView1.SelectedIndex != -1)
     {
         DataTable Datos1 = Session["Datos1"] as DataTable;
         Datos1.Rows[GridView1.SelectedIndex].Delete();

         GridView1.DataSource = Datos1;
         GridView1.DataBind();

         Session["Datos1"] = Datos1;
     }
 }

 protected void Button5_Click(object sender, EventArgs e)
 {
      string lcArchivoInicial = txtverdoc.Text.Replace(".pdf","");
    string _open = "window.open('unirpdfs/" + lcArchivoInicial + "_" + Session["Actual"].ToString() + ".pdf" + "', '_blank');";
     ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
     Session["Actual"] = Convert.ToInt32(Session["Actual"]) + 1;
     if (Convert.ToInt32(Session["Actual"]) > Convert.ToInt32(Session["narc"]))
     {
         Button5.Visible = false;
     }
     else
     {
         Button5.Text = "Descargar Archivo No " + Session["Actual"].ToString();
     }



 }




      }

    }
