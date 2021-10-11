using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gestion_documental
{
    public partial class configcertificado : System.Web.UI.Page
    {
        Class1 proce = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtTituloCertificado.Text = proce.recuperatitulocertificado();
            txtNombreFirmante.Text = proce.recuperafirmanombre();
            txtCargoFirmante.Text = proce.recuperafirmacargo();
            txtEstampillasCertificado.Text = proce.recuperatextoestampillas();
            Image1.ImageUrl = proce.recuperafirmacertificado();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string lcArchivo = proce.recuperaUbicacion()+"\\images\\" + FileUpload1.FileName;
            string lcarchivoweb = "~/images/"+FileUpload1.FileName;
            FileUpload1.SaveAs(lcArchivo);

            proce.seteawebconfig("firmacertificado", lcarchivoweb);
            proce.seteawebconfig("titulocertificado",txtTituloCertificado.Text);
            proce.seteawebconfig("firmanombre",txtNombreFirmante.Text);
            proce.seteawebconfig("firmacargo", txtCargoFirmante.Text);
            proce.seteawebconfig("textoestampillas", txtEstampillasCertificado.Text);

            Response.Redirect("docPendi.aspx");


        }
    }
}