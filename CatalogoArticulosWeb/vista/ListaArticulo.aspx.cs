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
    public partial class ListaArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Session.Add("listaArticulo", negocio.listarConSP()); //está modificacion de agregarlo en la Session me sirve para capturar la session en el filtro
            dgvArticulos.DataSource = Session["listaArticulo"];
            dgvArticulos.DataBind();
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Capturamos el id que nos llega por el evento modificar
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            //Y lo enviamos al formulario para modificar
            Response.Redirect("FormularioArticulo.aspx?id=" + id);
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Manejamos el pageIndex para que cambie de pagina cuando hacemos click en los numeros
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

        //Evento para filtrar la busqueda
        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["listaArticulo"]; //Traigo la lista, que está guardada en Session
            List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper())); //lambda expression
            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.DataBind();
        }
    }
}