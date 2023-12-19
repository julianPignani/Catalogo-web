using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

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
                Usuario user = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();
                
                user.Email = txtEmail.Text;
                //cuando capturamos los datos, validamos que el email contenga @ y .
                string email = user.Email;

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

                //capturo pass y llamo al metodo para insertar
                user.Pass = txtPass.Text;
                int id = negocio.Registrarse(user);
                Response.Redirect("Login.aspx", false); // si se registra bien lo enviamos al login
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}