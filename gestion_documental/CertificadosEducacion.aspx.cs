using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GESTIONDOCUMENTAL;
using gestion_documental.Utils;
using gestion_documental.DataAccessLayer;
using gestion_documental.BusinessObjects;
using GESTIONDOCUMENTAL.Utils;

namespace gestion_documental
{
    public partial class CertificadosEducacion : System.Web.UI.Page
    {
        Class1 proce = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtfechaexpedicion.Text = DateTime.Now.ToString("dd") + " de " + DateTime.Now.ToString("MMMM") + " del " + DateTime.Now.ToString("yyyy");
                DataTable data = new DataTable();

                DataColumn asignatura = new DataColumn("asignatura");
                asignatura.DataType = System.Type.GetType("System.String");
                data.Columns.Add(asignatura);

                DataColumn calificacion = new DataColumn("calificacion");
                calificacion.DataType = System.Type.GetType("System.String");
                data.Columns.Add(calificacion);

                Session.Add("datacertificado", data);
                txtTextoEstampillas.Text = proce.recuperatextoestampillas();

            }
        }
        protected void txtyear_TextChanged(object sender, EventArgs e)
        {

        }
        protected void bt_buscar_Click(object sender, EventArgs e)
        {
            limpiar();
            llenardatagridprincipal();
        }
        public void llenardatagridprincipal()
        {
            string municipio = "";
            string year = "";
            string colegio = "";
            string grado = "";
            if (txtmunicipio.Text != "")
            {
                municipio = " and (municipio like '" + txtmunicipio.Text + "%')";
            }
            if (txtyear.Text != "")
            {
                year = " and (year like '" + txtyear.Text + "%')";
            }
            if (txtcolegio.Text != "")
            {
                colegio = " and (colegio like '" + txtcolegio.Text + "%')";
            }
            if (txtgrado.Text != "")
            {
                grado = " and (grado like '" + txtgrado.Text + "%')";
            }
            DataTable data =new DataTable();
            proce.consultacamposcondicion("indicecolegio i join documentos d on i.iddocumento=d.idDOCUMENTOS","d.*,i.colegio as colegio,i.municipio as municipio,i.year as year,i.grado as grado,i.libro as libro"," i.idserie='20' and i.idsubserie='10' "+municipio+year+colegio+grado+" limit 60",data);
            gvprincipal.DataSource = data;
            gvprincipal.DataBind();

        }
        public void limpiar()
        {
            txtnombre.Text = "";
            txtgradoimprimir.Text = "";
            txtcolegioimprimir.Text = "";
            txtjornada.Text = "";
            txtmunicipioimprimi.Text = "";
            txtlibro.Text = "";
            txtnumerofolios.Text = "";
            txtyearimprimir.Text = "";
        }
        protected void gvprincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtcolegioimprimir.Text =Convert.ToString( gvprincipal.SelectedDataKey.Values[1]);
            txtmunicipioimprimi.Text = Convert.ToString(gvprincipal.SelectedDataKey.Values[2]);
            txtyearimprimir.Text = Convert.ToString(gvprincipal.SelectedDataKey.Values[3]);
            txtgradoimprimir.Text = Convert.ToString(gvprincipal.SelectedDataKey.Values[4]);
            nombregrado();
            txtlibro.Text = Convert.ToString(gvprincipal.SelectedDataKey.Values[5]);
            DataTable data = new DataTable();
            proce.consultacamposcondicion("documentos", "*", "iddocumentos='" + gvprincipal.SelectedDataKey.Values[0] + "'", data);

            //Response.Redirect(data.Rows[0]["camino"] + "/" + data.Rows[0]["documento"], "_blank", "menubar=0,scrollbars=1,width=780,height=750,top=10");
       
           // Image1.Attributes.Add("src","~//"+data.Rows[0]["camino"] + "//" + data.Rows[0]["documento"]);
            Image1.Attributes["src"] = ResolveUrl("~//" + data.Rows[0]["camino"] + "//" + data.Rows[0]["documento"]);
            
        }
       
        public void nombregrado()
        {
            if (txtgradoimprimir.Text == "0")
            {
                txtgradoimprimir.Text = "CERO DE PRIMARIA";
            }
            else
            {
                if (txtgradoimprimir.Text == "1")
                {
                    txtgradoimprimir.Text = "PRIMERO DE PRIMARIA";
                }
                else
                {
                    if (txtgradoimprimir.Text == "2")
                    {
                        txtgradoimprimir.Text = "SEGUNDO DE PRIMARIA";
                    }
                    else
                    {
                        if (txtgradoimprimir.Text == "3")
                        {
                            txtgradoimprimir.Text = "TERCERO DE PRIMARIA";
                        }
                        else
                        {
                            if (txtgradoimprimir.Text == "4")
                            {
                                txtgradoimprimir.Text = "CUARTO DE PRIMARIA";
                            }
                            else
                            {
                                if (txtgradoimprimir.Text == "5")
                                {
                                    txtgradoimprimir.Text = "QUITO DE PRIMARIA";
                                }
                                else
                                {
                                    if (txtgradoimprimir.Text == "6")
                                    {
                                        txtgradoimprimir.Text = "SEXTO DE BACHILLERATO";
                                    }
                                    else
                                    {
                                        if (txtgradoimprimir.Text == "7")
                                        {
                                            txtgradoimprimir.Text = "SEPTIMO DE BACHILLERATO";
                                        }
                                        else
                                        {
                                            if (txtgradoimprimir.Text == "8")
                                            {
                                                txtgradoimprimir.Text = "OCTAVO DE BACHILLERATO";
                                            }
                                            else
                                            {
                                                if (txtgradoimprimir.Text == "9")
                                                {
                                                    txtgradoimprimir.Text = "NOVENO DE BACHILLERATO";
                                                }
                                                else
                                                {
                                                    if (txtgradoimprimir.Text == "10")
                                                    {
                                                        txtgradoimprimir.Text = "DECIMO DE BACHILLERATO";
                                                    }
                                                    else
                                                    {
                                                        if (txtgradoimprimir.Text == "11")
                                                        {
                                                            txtgradoimprimir.Text = "ONCE DE BACHILLERATO";
                                                        }
                                                        else
                                                        {

                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        protected void btgenerarcertificado_Click(object sender, EventArgs e)
        {
          DataTable _certificado= Session["datacertificado"] as DataTable;

          DataRow fila1 = _certificado.NewRow();
          fila1["asignatura"] = txtasignatura1.Text;
          fila1["calificacion"] = txtcalificacion1.Text;
          _certificado.Rows.Add(fila1);

          DataRow fila2 = _certificado.NewRow();
          fila2["asignatura"] = txtasignatura2.Text;
          fila2["calificacion"] = txtcalificacion2.Text;
          _certificado.Rows.Add(fila2);

          DataRow fila3 = _certificado.NewRow();
          fila3["asignatura"] = txtasignatura3.Text;
          fila3["calificacion"] = txtcalificacion3.Text;
          _certificado.Rows.Add(fila3);

          DataRow fila4 = _certificado.NewRow();
          fila4["asignatura"] = txtasignatura4.Text;
          fila4["calificacion"] = txtcalificacion4.Text;
          _certificado.Rows.Add(fila4);

          DataRow fila5 = _certificado.NewRow();
          fila5["asignatura"] = txtasignatura5.Text;
          fila5["calificacion"] = txtcalificacion5.Text;
          _certificado.Rows.Add(fila5);

          DataRow fila6 = _certificado.NewRow();
          fila6["asignatura"] = txtasignatura6.Text;
          fila6["calificacion"] = txtcalificacion6.Text;
          _certificado.Rows.Add(fila6);

          DataRow fila7 = _certificado.NewRow();
          fila7["asignatura"] = txtasignatura7.Text;
          fila7["calificacion"] = txtcalificacion7.Text;
          _certificado.Rows.Add(fila7);

          DataRow fila8 = _certificado.NewRow();
          fila8["asignatura"] = txtasignatura8.Text;
          fila8["calificacion"] = txtcalificacion8.Text;
          _certificado.Rows.Add(fila8);

          DataRow fila9 = _certificado.NewRow();
          fila9["asignatura"] = txtasignatura9.Text;
          fila9["calificacion"] = txtcalificacion9.Text;
          _certificado.Rows.Add(fila9);

          DataRow fila10 = _certificado.NewRow();
          fila10["asignatura"] = txtasignatura10.Text;
          fila10["calificacion"] = txtcalificacion10.Text;
          _certificado.Rows.Add(fila10);

          DataRow fila11 = _certificado.NewRow();
          fila11["asignatura"] = txtasignatura11.Text;
          fila11["calificacion"] = txtcalificacion11.Text;
          _certificado.Rows.Add(fila11);

          DataRow fila12 = _certificado.NewRow();
          fila12["asignatura"] = txtasignatura12.Text;
          fila12["calificacion"] = txtcalificacion12.Text;
          _certificado.Rows.Add(fila12);

          DataRow fila13 = _certificado.NewRow();
          fila13["asignatura"] = txtasignatura13.Text;
          fila13["calificacion"] = txtcalificacion13.Text;
          _certificado.Rows.Add(fila13);

          DataRow fila14 = _certificado.NewRow();
          fila14["asignatura"] = txtasignatura14.Text;
          fila14["calificacion"] = txtcalificacion14.Text;
          _certificado.Rows.Add(fila14);

          DataRow fila15 = _certificado.NewRow();
          fila15["asignatura"] = txtasignatura15.Text;
          fila15["calificacion"] = txtcalificacion15.Text;
          _certificado.Rows.Add(fila15);
            Session.Add("datacertificado", _certificado);
            Session["nombreimprimir"]=txtnombre.Text;
            Session["municipioimprimir"]=txtmunicipioimprimi.Text;
            Session["colegioimprimir"]=txtcolegioimprimir.Text;
            Session["yearimprimir"]=txtyearimprimir.Text;
            Session["gradoimprimir"]=txtgradoimprimir.Text;
            Session["libroimprimir"]=txtlibro.Text;
            Session["folioimprimir"]=txtnumerofolios.Text;
            Session["jornadaimprimir"]=txtjornada.Text;
            Session["fechaexpedicion"] = txtfechaexpedicion.Text;
            Session.Add("textoestampillas", txtTextoEstampillas.Text);
            
            Response.Redirect("~/reporting/ViewCertificado.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("docPendi.aspx");
        }
        protected void gvprincipal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            llenardatagridprincipal();
            gvprincipal.PageIndex = e.NewPageIndex;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            proce.consultacamposcondicion("documentos", "*", "iddocumentos='" + gvprincipal.SelectedDataKey.Values[0] + "'", data);

            Response.Redirect(data.Rows[0]["camino"] + "/" + data.Rows[0]["documento"], "_blank", "menubar=0,scrollbars=1,width=780,height=750,top=10");
        }
    }
}
   