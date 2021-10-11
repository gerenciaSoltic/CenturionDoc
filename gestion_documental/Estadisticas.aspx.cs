using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestion_documental.Utils;
using gestion_documental.DataAccessLayer;
using gestion_documental.BusinessObjects;
using GESTIONDOCUMENTAL.Utils;
using System.Data;

namespace gestion_documental
{
    public partial class Estadisticas : System.Web.UI.Page
    {
        Class1 proce = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenaformulario();
            }

        }


        protected void llenaformulario()
        {
            DataTable datEnte = new DataTable();
            proce.consultacamposcondicion("ente", "idente,descripcion", "true", datEnte);
            ddlOficinas.DataSource = datEnte;
            ddlOficinas.DataTextField = "descripcion";
            ddlOficinas.DataValueField = "idente";
            ddlOficinas.DataBind();
            ddlOficinas.Items.Insert(0, new ListItem("Seleccionar", "0"));

            DataTable datFuncionario = new DataTable();
            proce.consultacamposcondicion("Emirecep", "id,descripcion", "true", datFuncionario);
            ddlFuncionario.DataSource = datFuncionario;
            ddlFuncionario.DataTextField = "descripcion";
            ddlFuncionario.DataValueField = "id";
            ddlFuncionario.DataBind();
            ddlFuncionario.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }

        protected void ddlOficinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lcCondicion = "";
            if (ddlOficinas.SelectedIndex == 0)
            {
                lcCondicion = "true";
            }
            else
            {
                lcCondicion = "idente = " + ddlOficinas.SelectedValue.ToString();
            }
            DataTable datFuncionario = new DataTable();
            proce.consultacamposcondicion("Emirecep", "id,descripcion", lcCondicion, datFuncionario);
            ddlFuncionario.DataSource = datFuncionario;
            ddlFuncionario.DataTextField = "descripcion";
            ddlFuncionario.DataValueField = "id";
            ddlFuncionario.DataBind();
            ddlFuncionario.Items.Insert(0, new ListItem("Seleccionar", "0"));




        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            if (txtFechadesde.Text == "" || txtFechaHasta.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Faltan fechas');", true);
                return;
            }
            string lcCondicionEnte = "";
            if (ddlOficinas.SelectedIndex != 0)
            {
                lcCondicionEnte = "idEnteDestino = " + ddlOficinas.SelectedValue.ToString();
            }

            string lcCondicionFuncionario = "";
            if (ddlFuncionario.SelectedIndex != 0)
            {
                lcCondicionFuncionario = "idemidestino=" + ddlFuncionario.SelectedValue.ToString();
            }

            string lcCampos = "";
            string lcgrupby = "";
            int cantidadSeries = 0;
            if (rdTotales.Checked == true)
            {
                lcCampos = "'' as oficina,' ' as funcionario,estado,count(*) as cantidad";
                lcgrupby = "group by '','',estado";
                cantidadSeries = 2;
            }
            if (rdPorOficina.Checked == true)
            {
                lcCampos = "ente.descripcion as oficina,' ' as funcionario,estado,count(*) as cantidad";
                lcgrupby = "group by ente.descripcion,'',estado";
                cantidadSeries = 3;
            }
            if (rdPorFuncionario.Checked == true)
            {
                lcCampos = "ente.descripcion as oficina,emirecep.descripcion as funcionario,estado,count(*) as cantidad";
                lcgrupby = "group by ente.descripcion,emirecep.descripcion,estado";
                cantidadSeries = 4;
            }
            
            string lcCondicionFinal = " workflow.identedestino = ente.idente and workflow.idemidestino = emirecep.id and workflow.fecha between '"+txtFechadesde.Text+"' and '"+txtFechaHasta.Text+"'";
            if (lcCondicionEnte != "")
            {
                lcCondicionFinal = lcCondicionFinal+" AND "+lcCondicionEnte;
                
            }
            if (lcCondicionFuncionario != "")
            {
                if (lcCondicionFinal!="")
                {
                   lcCondicionFinal = lcCondicionFinal+" AND ";
                }
                lcCondicionFinal= lcCondicionFinal+lcCondicionFuncionario;


            }
            if (lcCampos == "")
            {
                return;
            }

            DataTable DatConsulta=new DataTable();
            proce.consultacamposcondicion("workflow,ente,emirecep", lcCampos, lcCondicionFinal +" "+ lcgrupby, DatConsulta);
            grdEstadistica.DataSource = DatConsulta;
            grdEstadistica.DataBind();

            /*
            
            string[] Oficina = new string[DatConsulta.Rows.Count];
            string[] FuncionarioVec = new string[DatConsulta.Rows.Count];
            string[] Estados = new string[DatConsulta.Rows.Count];
            int[] CantidadVec = new int[DatConsulta.Rows.Count];
            int pos = 0;
            foreach (DataRow Fila in DatConsulta.Rows)
            {
                switch (cantidadSeries)
                {
                    case 2:
                        Estados[pos] = Fila["Estado"].ToString();
                       CantidadVec[pos] = Convert.ToInt32(Fila["Cantidad"]);
                       break;

                    case 3:
                       Oficina[pos] = Fila["Oficina"].ToString();
                       Estados[pos] = Fila["Estado"].ToString();
                       CantidadVec[pos] = Convert.ToInt32(Fila["Cantidad"]);
                       break;
                    case 4:
                  
                       Oficina[pos] = Fila["Oficina"].ToString();
                       FuncionarioVec[pos] = Fila["Funcionario"].ToString();
                       Estados[pos] = Fila["Estado"].ToString();
                       CantidadVec[pos] = Convert.ToInt32(Fila["Cantidad"]);
                        break;
                }
                pos++;

         

            }



            switch (cantidadSeries)
            {

                case 2:
                    Grafica.Series.Add("Estado");
                
                    Grafica.Series["Estado"].Points.DataBindXY(Estados, CantidadVec);


                    break;

                case 3:
                    Grafica.Series.Add("Oficina");
                    Grafica.Series.Add("Estado");
                    Grafica.Series["Oficina"].Points.DataBindXY(Oficina, CantidadVec);
                    Grafica.Series["Estado"].Points.DataBindXY(Estados, CantidadVec);
           
                    break;

                case 4:
                    Grafica.Series.Add("Oficina");
                    Grafica.Series.Add("Funcionario");
                    Grafica.Series.Add("Estado");
                    Grafica.Series["Oficina"].Points.DataBindXY(Oficina, CantidadVec);
                    Grafica.Series["Funcionario"].Points.DataBindXY(FuncionarioVec, CantidadVec);
                    Grafica.Series["Estado"].Points.DataBindXY(Estados, CantidadVec);

        
                    break;

            }

            */
            
            


        }

        




        



        
    }
}