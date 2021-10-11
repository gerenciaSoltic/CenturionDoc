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

namespace gestion_documental
{
    public partial class ManageSubSerie : System.Web.UI.Page
    {
        #region Page Event

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGvrSubSeries();
            }

        }

        #endregion

        #region SubSeries

        protected void FillGvrSubSeries()
        {
            gvSubSerie.DataSource = new SubSerieManagement().GetAllSubSeries();

            gvSubSerie.DataBind();

            // para el list de serie
            ddlSerie.DataSource = new SerieManagement().GetAllSeries();
            ddlSerie.DataValueField = "ID";
            ddlSerie.DataTextField = "SERIE";

            ddlSerie.DataBind();

            ddlSerie.Items.Insert(0, new ListItem("Seleccionar", "0"));

            // para el list de disposicion final
            ddlDispofin.DataSource = new DispofinalManagement().GetAllDispoFinal();
            ddlDispofin.DataValueField = "IDDISPOFINAL";
            ddlDispofin.DataTextField = "DISPOSICION";

            ddlDispofin.DataBind();
            ddlDispofin.Items.Insert(0, new ListItem("Seleccionar","0"));

        }

        protected void gvSubSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SubSerieId = Convert.ToInt32(gvSubSerie.SelectedDataKey.Value);
            SubSerie Subserie = new SubSerieManagement().GetSubSerieById(SubSerieId);
            txtSubSerie.Text = Subserie.SUBSERIE;
            TxtoCodigo.Text = Subserie.CODIGO;
            TxtoTiempoGestion.Text = Subserie.TIEMPOGESTION.ToString();
            TxtoTiempoCentral.Text = Subserie.TIEMPOCENTRAL.ToString();
            TxtoTiempoHistorico.Text = Subserie.TIEMPOHISTORICO.ToString();

            ddlSerie.SelectedValue = Subserie.IDSERIE + "";
            ddlDispofin.SelectedValue = Subserie.IDDISPOFINAL + "";

            btnAddSubSerie.Text = "Editar";
            LblAtributos.Visible = true;
            LstAtributos.Visible = true;
            BtnAñadirAtributo.Visible = true;
            BtnQuitarAtributo.Visible = true;
            Txtatributo.Visible = true;
            //LstAtributos.InsertItemTemplate =;
            
            LstAtributos.DataSource=  new subserieIndiceManagement().GetAllsubserieIndice(Convert.ToInt32(Subserie.IDSERIE),SubSerieId);
            LstAtributos.DataTextField = "ATRIBUTO";
            LstAtributos.DataValueField = "id";
            LstAtributos.DataBind();
            if (LstAtributos.Items.Count == 0)
            {
                adicionaAtributogeneral(Subserie.IDSERIE, SubSerieId);
            }
        }

        protected void gvSubSerie_DeleteEventHandler(object sender, GridViewDeleteEventArgs e)
        {
            int idSubSerie = (int)gvSubSerie.DataKeys[Convert.ToInt32(e.RowIndex)].Value;

            if (!new SubSerieManagement().DeleteSubSerie(idSubSerie))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Ocurrio un problema al eliminar el registro, quizas este siendo usado');", true);
            }

            FillGvrSubSeries();
        }


        protected void gvShowSubSerie_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // reference the Delete LinkButton
                LinkButton db = (LinkButton)e.Row.Cells[4].Controls[0];

                db.OnClientClick = "return confirm('Esta seguro que desea eliminar ?');";
            }
        }

      

        #endregion

        protected void BtnAñadirAtributo_Click(object sender, EventArgs e)
        {
            if (Txtatributo.Text != "")
            {
                subserieIndice Subserieindice = new subserieIndice();
                Subserieindice.IDSERIE = Convert.ToInt32(ddlSerie.SelectedValue);
                Subserieindice.IDSUBSERIE = Convert.ToInt32(gvSubSerie.SelectedDataKey.Value.ToString());
                Subserieindice.ATRIBUTO = Txtatributo.Text;
                new subserieIndiceManagement().Insertsubserieindice(Subserieindice);
                LstAtributos.DataSource = new subserieIndiceManagement().GetAllsubserieIndice(Convert.ToInt32(Subserieindice.IDSERIE), Convert.ToInt32(Subserieindice.IDSUBSERIE));
                LstAtributos.DataTextField = "ATRIBUTO";
                LstAtributos.DataValueField = "id";
                LstAtributos.DataBind();
                //LstAtributos.Items.Add(Txtatributo.Text);



              }
        }

        protected void BtnQuitarAtributo_Click(object sender, EventArgs e)
        {
            subserieIndice Subserieindice = new subserieIndice();
            Subserieindice.IDSERIE = Convert.ToInt32(ddlSerie.SelectedValue);
            Subserieindice.IDSUBSERIE = Convert.ToInt32(gvSubSerie.SelectedDataKey.Value.ToString());
            Subserieindice.ATRIBUTO = Txtatributo.Text;
            
            new subserieIndiceManagement().DeletesubserieIndice(Convert.ToInt32(LstAtributos.SelectedValue.ToString()));
            LstAtributos.DataSource = new subserieIndiceManagement().GetAllsubserieIndice(Convert.ToInt32(Subserieindice.IDSERIE), Convert.ToInt32(Subserieindice.IDSUBSERIE));
            LstAtributos.DataTextField = "ATRIBUTO";
            LstAtributos.DataBind();

        }

        protected void adicionaAtributogeneral(int idSerie, int idSubserie)
        {
          ListBox listagral= new ListBox();
          listagral.DataSource = new AtributosManagement().GetAllAtributos();
          listagral.DataTextField = "ATRIBUTO";
          listagral.DataValueField = "ATRIBUTO";
          
          listagral.DataBind();
            
          foreach (ListItem item in listagral.Items)
          {
              subserieIndice Subserieindice = new subserieIndice();
              Subserieindice.IDSERIE = idSerie;
              Subserieindice.IDSUBSERIE = idSubserie;
              item.Selected = true;
              Subserieindice.ATRIBUTO = item.Text;
              new subserieIndiceManagement().Insertsubserieindice(Subserieindice);


          }

          LstAtributos.DataSource = new subserieIndiceManagement().GetAllsubserieIndice(idSerie,idSubserie);
          LstAtributos.DataTextField = "ATRIBUTO";
          LstAtributos.DataValueField = "id";
          LstAtributos.DataBind();
  
        }

        protected void btnAddSubSerie_Click(object sender, EventArgs e)
        {
            RgexpvlTgestion.Validate();
            RgexpvlTcentral.Validate();
            RgexpvlTHistorico.Validate();
            if (!RgexpvlTgestion.IsValid || !RgexpvlTcentral.IsValid || ! RgexpvlTHistorico.IsValid)
            {
                return;
            }
            if (btnAddSubSerie.Text == "Añadir")
            {

                SubSerie Subserie = new SubSerie();
                Subserie.IDSERIE = Convert.ToInt32(ddlSerie.SelectedValue);
                Subserie.SUBSERIE = txtSubSerie.Text;
                Subserie.CODIGO = TxtoCodigo.Text;
                Subserie.IDDISPOFINAL = Convert.ToInt32(ddlDispofin.SelectedValue);
                Subserie.TIEMPOGESTION = Convert.ToInt32(TxtoTiempoGestion.Text);
                Subserie.TIEMPOCENTRAL = Convert.ToInt32(TxtoTiempoCentral.Text);
                Subserie.TIEMPOHISTORICO = Convert.ToInt32(TxtoTiempoHistorico.Text);


                new SubSerieManagement().InsertSubSerie(Subserie);
                FillGvrSubSeries();
                btnClearSubSerie_Click(null, null);
            }
            else
            {
                SubSerie Subserie = new SubSerie();
                Subserie.ID = Convert.ToInt32(gvSubSerie.SelectedDataKey.Value);
                Subserie.IDSERIE = Convert.ToInt32(ddlSerie.SelectedValue.ToString());
                Subserie.SUBSERIE = txtSubSerie.Text;
                Subserie.CODIGO = TxtoCodigo.Text;

                Subserie.IDDISPOFINAL = Convert.ToInt32(ddlDispofin.SelectedValue);
                Subserie.TIEMPOGESTION = Convert.ToInt32(TxtoTiempoGestion.Text);
                Subserie.TIEMPOCENTRAL = Convert.ToInt32(TxtoTiempoCentral.Text);
                Subserie.TIEMPOHISTORICO = Convert.ToInt32(TxtoTiempoHistorico.Text);

                new SubSerieManagement().UpdateSubSerie(Subserie);
                FillGvrSubSeries();
                btnClearSubSerie_Click(null, null);
                LblAtributos.Visible = false;
                LstAtributos.Visible = false;
                BtnAñadirAtributo.Visible = false;
                BtnQuitarAtributo.Visible = false;
                Txtatributo.Visible = false;

            }
        }

        protected void btnClearSubSerie_Click(object sender, EventArgs e)
        {
            txtSubSerie.Text = string.Empty;
            btnAddSubSerie.Text = "Añadir";

            ddlSerie.SelectedValue = "0";
            ddlDispofin.SelectedValue = "0";

            TxtoTiempoCentral.Text = string.Empty;
            TxtoTiempoGestion.Text = string.Empty;
            TxtoTiempoHistorico.Text = string.Empty;

        }

       
        

    }
}