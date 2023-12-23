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
                user.Pass = txtPass.Text;
                //cuando capturamos los datos, validamos que el email contenga @ y .
                string email = user.Email;

                //si no contiene @ o ., mostramos el error
                if (!email.Contains("@") || !email.Contains("."))
                {
                    lblErrorEmail.Text = "El email debe contener '@' y '.'";
                    lblErrorEmail.Visible = true;
                }
                else
                {
                    // Validar que la contraseña tenga al menos 8 caracteres
                    string pass = user.Pass;
                    if (pass.Length <= 8)
                    {
                        lblErrorPass.Text = "La contraseña debe contener 8 o más caracteres.";
                        lblErrorPass.Visible = true;
                    }
                    else
                    {
                        // Ocultar el mensaje de error si ambas validaciones pasan
                        lblErrorEmail.Visible = false;
                        lblErrorPass.Visible = false; 

                        // Llamo al método para insertar y lo guardo en la variable id
                        int id = negocio.Registrarse(user);

                        Response.Redirect("Login.aspx", false); // Si se registra bien, lo enviamos al login
                    }
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}