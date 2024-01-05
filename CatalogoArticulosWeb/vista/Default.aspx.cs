using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio; //agregamos el dominio
using negocio; //y negocio


namespace vista
{
    public partial class Default : System.Web.UI.Page
    {

        
        //Creamos una propiedad publica para traer la lista
        public List<Articulo> ListaArticulos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Validamos que tenga una session abierta para que pueda ingresar a ver los productos
            if(Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar a esté campo.");
                Response.Redirect("/Error.aspx", false);
            }

            //Instanciamos la clase ArticuloNegocio para poder traernos la lista
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulos = negocio.listarConSP();


            //Validamos
            if (!IsPostBack)
            {

                repRepetidor.DataSource = ListaArticulos;
                repRepetidor.DataBind();

            }
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            //Capturamos el argumento que viene a través del btnVerDetalle con el Id.
            string id = ((Button)sender).CommandArgument;
            Response.Redirect("VerDetalle.aspx?id=" + Server.UrlEncode(id), false);//Server.UrlEncode para garantizar que el id se transmita de manera segura a través de la URL.
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}