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
                //Validamos,si el usuario ya tiene el perfil cargado, le mostramos los datos que guardó.
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["usuario"]))
                    {
                        Usuario user = (Usuario)Session["usuario"];
                        txtEmail.Text = user.Email;
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;
                        txtFechaNac.Text = user.FechaNacimiento.ToString("yyyy-MM-dd");
                        if (!string.IsNullOrEmpty(user.ImagenPerfil))
                            imgNuevoPerfil.ImageUrl = "~/Images/" + user.ImagenPerfil;

                        
                    }


                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }


            /* try
             {
                 //Validamos si ya hay un usuario conectado en session
                     if(!Seguridad.sesionActiva(Session["usuario"]))
                     Response.Redirect("Login.aspx", false);
             }
             catch (Exception)
             {

                 throw;
             }*/
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
                if (txtImagen.PostedFile.FileName != "") //(si no hay nada seleccionado significa que esta vacio, sino capturamos la ruta)
                {
                    string ruta = Server.MapPath("./Images/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");

                    //Guardamos la imagen en la DB
                    user.ImagenPerfil = "perfil-" + user.Id + ".jpg";

                }
                //Capturamos los demas datos y llamamos al método
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                negocio.actualizar(user);

                //LEER IMG
                //para poder acceder a la master y buscar el id de la imagen el el aspx
                Image img = (Image)Master.FindControl("imgPerfil");
                img.ImageUrl = "~/Images/" + user.ImagenPerfil;

                Response.Redirect("MiPerfil.aspx", false);
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