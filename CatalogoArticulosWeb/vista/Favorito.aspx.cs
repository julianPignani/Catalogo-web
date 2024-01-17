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
        public string idArticulo;

        public int IdUsuario { get; internal set; }
        public string IdArticulo { get; internal set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                if (!IsPostBack)
                {
                    if (!IsPostBack)
                    {
                        List<string> favoritosIds = (List<string>)Session["listaFavoritos"];

                        if (favoritosIds != null && favoritosIds.Any())
                        {
                            ArticuloNegocio negocio = new ArticuloNegocio();
                            repFavorito.DataSource = negocio.listarFavorito(favoritosIds);
                            repFavorito.DataBind();
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
                if (sender is Button btnDeshacer)
                {
                    //Guardamos el id
                    idArticulo = btnDeshacer.CommandArgument;

                    //llamamos la session
                    List<string> favoritosIds = (List<string>)Session["listaFavoritos"];

                    // Eliminamos el IdArticulo de la lista de favoritos
                    favoritosIds.Remove(idArticulo);

                    // Vuelvemos a cargar la lista de favoritos
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    repFavorito.DataSource = negocio.listarFavorito(favoritosIds);
                    repFavorito.DataBind();

                    // Actualizamos la sesión con la nueva lista de favoritos
                    Session["listaFavoritos"] = favoritosIds;
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }

}
