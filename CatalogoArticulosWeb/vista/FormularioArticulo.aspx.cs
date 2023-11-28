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
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            
            try
            {
                if (!IsPostBack)
                {

                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulos.ImageUrl = txtImagenUrl.Text;
        }
    }
}