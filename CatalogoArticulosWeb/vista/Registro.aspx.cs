using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vista
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                //cuando capturamos los datos, validamos que el email contenga @ y .
                string email = txtEmail.Text;

                //si no contiene @ o ., mostramos el error
                if (!email.Contains("@") || !email.Contains("."))
                {
                    lblError.Text = "El email debe contener '@' y '.'";
                    lblError.Visible = true;
                }
                else
                {
                    //si contiene decimos q esta lbl no se muestre
                    lblError.Visible = false;
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
    }
}