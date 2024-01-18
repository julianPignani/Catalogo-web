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
    public partial class Favorito : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Seguridad.sesionActiva(Session["usuario"]))
                {
                    if (Session["IdUsuario"] != null)
                    {
                        int idUsuario = (int)Session["IdUsuario"];

                        // Obtener la lista de artículos favoritos del usuario
                        ArticuloNegocio negocio = new ArticuloNegocio();
                        List<Articulo> favoritos = negocio.obtenerArticulosFavoritos(idUsuario);

                        if (favoritos != null && favoritos.Count > 0)
                        {
                            // Enlazar los datos al Repeater
                            repFavorito.DataSource = favoritos;
                            repFavorito.DataBind();
                        }
                        else
                        {
                            // Log: No hay favoritos para el usuario
                            System.Diagnostics.Debug.WriteLine("No hay favoritos para el usuario con Id: " + idUsuario);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnDeshacer_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }

}
