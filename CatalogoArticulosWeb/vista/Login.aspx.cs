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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario; //llamamos al constructor
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                usuario = new Usuario(txtEmail.Text, txtPass.Text, false); //le ponemos false, despúes si es diferente la DB lo pisa

                //si se logeo correctamente
                if (negocio.Loguear(usuario))
                {
                    Session.Add("usuario", usuario); //Agregamos un usuario a la Session
                    Response.Redirect("Bienvenida.aspx", false); //El false es para capturar una ex de .net
                }
                else
                {
                    Session.Add("error", "Usuario o Contraseña incorrectos!!");
                    Response.Redirect("/Error.aspx", false);
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("/Error.aspx", false);
            }
        }



    }
}