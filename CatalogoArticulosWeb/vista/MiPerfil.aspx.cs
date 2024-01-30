using System;
using System.Collections.Generic;
using System.IO;
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
                        if (!string.IsNullOrEmpty(user.ImagenPerfil))
                            imgNuevoPerfil.ImageUrl = "~/Images/" + user.ImagenPerfil;

                    }
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Validamos que las validaciones del RequiredFieldValidator sean correctas, esto evita que corra toda la acción y luego muestre si está mal.
                Page.Validate();
                if (!Page.IsValid) //si no es valida, que nos muestre él error. Sino sigue con la carga de datos
                    return;

                //llamamos al usuario para guardar la foto con el nombre  el id del usuario
                Usuario user = (Usuario)Session["usuario"];

                //llamamos al usuarioNegocio para guardar los datos
                UsuarioNegocio negocio = new UsuarioNegocio();

                //ESCRIBIR IMG
                //Guardamos la ruta de la imagen en la carpeta con el nombre + el id del us. 
                if (txtImagen.PostedFile.FileName != "") //(si no hay nada seleccionado significa que esta vacio, sino capturamos la ruta)
                {
                    string nombreArchivo = "perfil-" + user.Id + "-" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";

                    // Obtener la ruta física del directorio raíz de la aplicación
                    string rutaRaiz = Server.MapPath("~/");

                    // Concatenar la carpeta "Images"
                    string rutaCarpeta = Path.Combine(rutaRaiz, "Images");

                    // Verificar si la carpeta existe, y crearla si es necesario
                    if (!Directory.Exists(rutaCarpeta))
                    {
                        Directory.CreateDirectory(rutaCarpeta);
                    }

                    // Combinar la ruta de la carpeta con el nombre del archivo
                    string rutaCompleta = Path.Combine(rutaCarpeta, nombreArchivo);

                    // Guardar el archivo en la ruta completa
                    txtImagen.PostedFile.SaveAs(rutaCompleta);

                    // Actualizamos la propiedad ImagenPerfil 
                    user.ImagenPerfil = nombreArchivo;
                }
                //Capturamos los demas datos y llamamos al método
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                negocio.actualizar(user);

                //LEER IMG
                //para poder acceder a la master y buscar el id de la imagen el el aspx
                Image img = (Image)Master.FindControl("imgPerfil");
                img.ImageUrl = "~/Images/" + user.ImagenPerfil + "?timestamp=" + DateTime.Now.Ticks;

                Response.Redirect("MiPerfil.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);

            }
        }
    }
}