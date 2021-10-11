using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Web
{
    public partial class Mensajes : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           //
        }

        public void ShowMessage(string Message)
        {
            lblMessage.Text = Message;
            lblMessage.ForeColor = System.Drawing.Color.Black;
            
            mpext.Show();
        }

        //public void ActivaBoton()
        //{
        //    BtnAceptar.Visible = true;

        //    mpext.CancelControlID = "";
        //    mpext.Show();
        //}

        public void Hide()
        {
            lblMessage.Text = "";
            
            mpext.Hide();
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            mpext.Hide();
        }

       //protected void BtnAceptar_Click(object sender, EventArgs e)
       //{
       //    mpext.Hide();
       //}

   

    }
}