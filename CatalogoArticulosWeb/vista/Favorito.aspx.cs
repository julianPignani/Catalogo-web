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

            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}
