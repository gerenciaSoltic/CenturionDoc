using System;
using System.IO;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace gestion_documental
{
    public partial class unirpdfs : System.Web.UI.Page
    {

        Class1 proce = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DataTable Datos1 = new DataTable();

                DataColumn DOCUMENTO = new DataColumn("DOCUMENTO");
                DOCUMENTO.DataType = System.Type.GetType("System.String");
                Datos1.Columns.Add(DOCUMENTO);

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

            DataRow Fila = Datos1.NewRow();
            Fila["DOCUMENTO"] = fileName;
            Datos1.Rows.Add(Fila);

            GridView1.DataSource = Datos1;
            GridView1.DataBind();
            Session["Datos1"] = Datos1;

}   
}
}

 protected void Button1_Click(object sender, EventArgs e)
 {

     
     /*DataTable Datos1 = Session["Datos1"] as DataTable;/*
     

     /* Armanos cursor con los archivos de salida final ***/
     ManejoPdfs UneArchivos = new ManejoPdfs();
     DataTable Datosfin = new DataTable();
     DataTable Datos1 = new DataTable();

     proce.consultacamposcondicion("unir", "final,dirsal", "archivo <> '' group by final,dirsal", Datosfin);

     if (Datosfin.Rows.Count > 0)
     {
        
         DataTable dtResultado = new DataTable();
         for(int ifinal= 0; ifinal < Datosfin.Rows.Count; ifinal++)
         {
             Datos1.Clear();
             proce.consultacamposcondicion("unir", "archivo,dir", "final ='" + Datosfin.Rows[ifinal][0].ToString() + "'", Datos1);
         if (Datos1.Rows.Count > 0)
         {
             string lcCaminoInicial = Datos1.Rows[0][1].ToString();



             string lcSarta = "";

             for (int i = 0; i < Datos1.Rows.Count; i++)
             {
                 lcSarta = lcSarta + "," + "F:\\RepositoriosGIT\\centurion_doc\\gestion_documental\\"+Datos1.Rows[i]["dir"].ToString()+Datos1.Rows[i]["archivo"].ToString();
             }
             lcSarta = lcSarta.Substring(1);
             string[] listaArchivos = lcSarta.Split(',');

 
             dtResultado.Clear();

             dtResultado = UneArchivos.Mezclar("F:\\RepositoriosGIT\\centurion_doc\\gestion_documental\\"+Datosfin.Rows[ifinal][1].ToString() + "\\" + Datosfin.Rows[ifinal][0].ToString(), listaArchivos);
         }
         }

     }
 }

 protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
 {

 }

 protected void Button2_Click(object sender, EventArgs e)
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



      }

    }
