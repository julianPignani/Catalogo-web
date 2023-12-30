using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace vista
{
    public partial class MyMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                //Validamos si ya existe un usuario en session o no, y validamos en que pantallas puede ver el usuario sin estar logueado.
                if (!(Page is Login || Page is Bienvenida || Page is Registro || Page is Error) && !Seguridad.sesionActiva(Session["usuario"]))
                {
                    if (!Seguridad.sesionActiva(Session["usuario"]))
                        Response.Redirect("Login.aspx", false);

                }

                //Validamos para que la imagen quede guardada en el avatar  en todas las vistas mientras la session este abierta.
                if (Seguridad.sesionActiva(Session["usuario"]))
                {
                    //verificamos si la img en la DB es null.
                    imgPerfil.ImageUrl = "~/Images/" + ((Usuario)Session["usuario"]).ImagenPerfil;
                }
                else
                {
                    //Si la sesión no está activa, tambien asignamos la url por defecto.
                    imgPerfil.ImageUrl = "https://static.vecteezy.com/system/resources/previews/004/141/669/non_2x/no-photo-or-blank-image-icon-loading-images-or-missing-image-mark-image-not-available-or-image-coming-soon-sign-simple-nature-silhouette-in-frame-isolated-illustration-vector.jpg";
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Clear();
                Response.Redirect("Login.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}