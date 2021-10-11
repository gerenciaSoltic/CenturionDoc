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
    public partial class ManageIndices : System.Web.UI.Page
    {
        #region Page Event

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGvrIndices();
            }

        }

        #endregion

        #region Indicess

        protected void FillGvrIndices()
        {
            gvIndices.DataSource = new IndicesManagement().GetAllIndices();

            gvIndices.DataBind();

            MySqlDataAdapter mda;
            MySqlConnection Con = new MySqlConnection();
            ConnectionClass conclass = new ConnectionClass();
            Con = conclass.Connection;

            if (Con.State == ConnectionState.Closed)
                Con.Open();
            mda = new MySqlDataAdapter(@"select * from documentos", Con);

            DataSet ds = new DataSet();

            mda.Fill(ds);

            ddlDocumentos.DataSource = ds.Tables[0];
            ddlDocumentos.DataValueField = "idDOCUMENTOS";
            ddlDocumentos.DataTextField = "DOCUMENTO";
            ddlDocumentos.DataBind();
            ddlDocumentos.Items.Insert(0, new ListItem("Seleccionar", "0"));

        }

        protected void gvIndices_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IndicesId = Convert.ToInt32(gvIndices.SelectedDataKey.Value);
            Indices Indices = new IndicesManagement().GetIndicesById(IndicesId);
            txtIndice.Text = Indices.INDICE;

            ddlDocumentos.SelectedValue = Indices.iddocumento + "";

            btnAddIndices.Text = "Editar";
        }

        protected void gvIndices_DeleteEventHandler(object sender, GridViewDeleteEventArgs e)
        {
            int idIndices = (int)gvIndices.DataKeys[Convert.ToInt32(e.RowIndex)].Value;

            if (!new IndicesManagement().DeleteIndices(idIndices))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Ocurrio un problema al eliminar el registro, quizas este siendo usado');", true);
            }

            FillGvrIndices();
        }


        protected void gvShowIndices_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // reference the Delete LinkButton
                LinkButton db = (LinkButton)e.Row.Cells[3].Controls[0];

                db.OnClientClick = "return confirm('Esta seguro que desea eliminar ?');";
            }
        }

        protected void btnClearIndices_Click(object sender, EventArgs e)
        {
            txtIndice.Text = string.Empty;
            btnAddIndices.Text = "Añadir";

            ddlDocumentos.SelectedValue = "0";
        }

        protected void btnAddIndices_Click(object sender, EventArgs e)
        {
            if (btnAddIndices.Text == "Añadir")
            {
                Indices Indices = new Indices();
                Indices.iddocumento = Convert.ToInt32(ddlDocumentos.SelectedValue);
                Indices.INDICE = txtIndice.Text;
                new IndicesManagement().InsertIndices(Indices);
                FillGvrIndices();
                btnClearIndices_Click(null, null);
            }
            else
            {
                Indices Indices = new Indices();
                Indices.idINDICES = Convert.ToInt32(gvIndices.SelectedDataKey.Value);
                Indices.iddocumento = Convert.ToInt32(ddlDocumentos.SelectedValue);
                Indices.INDICE = txtIndice.Text;
                new IndicesManagement().UpdateIndices(Indices);
                FillGvrIndices();
                btnClearIndices_Click(null, null);
            }
        }

        #endregion

    }
}