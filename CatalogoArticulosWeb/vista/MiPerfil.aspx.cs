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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            try
            {
                //Validamos si ya hay un usuario conectado en session
                    if(!Seguridad.sesionActiva(Session["usuario"]))
                    Response.Redirect("Login.aspx", false);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //llamamos al usuario para guardar la foto con el nombre  el id del usuario
                Usuario user = (Usuario)Session["usuario"];

                //llamamos al usuarioNegocio para guardar los datos
                UsuarioNegocio negocio = new UsuarioNegocio();

                //ESCRIBIR IMG
                //Guardamos la ruta de la imagen en la carpeta con el nombre + el id del us.
               
                string ruta = Server.MapPath("./Images/");
                txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");

                //Guardamos la imagen en la DB
                user.ImagenPerfil = "perfil-" + user.Id + ".jpg";
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                negocio.actualizar(user);

                //LEER IMG
                //para poder acceder a la master y buscar el id de la imagen el el aspx
                Image img =  (Image)Master.FindControl("imgPerfil");
                img.ImageUrl = "~/Images/" + user.ImagenPerfil;

                
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            // Habilitar los controles y mostrar los botones "Guardar" y "Cancelar"
            txtEmail.Enabled = false;
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtFechaNac.Enabled = true;
            txtImagen.Disabled = false;

            btnGuardar.Visible = true;
            btnModificar.Visible = false;
            
        }
    }
}