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
        //Propiedad para manejar el filtro avanzado
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validamos si es admin
            Usuario usuarioEnSesion = Session["usuario"] as Usuario;
            if (usuarioEnSesion != null && !Seguridad.esAdmin(usuarioEnSesion))
            {
                Session.Add("error", "No tienes permisos para ingresar a esta pantalla. Necesitas nivel administrador.");
                Response.Redirect("/Error.aspx");
            }


            FiltroAvanzado = chkAvanzado.Checked; //para no perder el valor de la variable a cuando recarga la pagina
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("listaArticulo", negocio.listarConSP()); //está modificacion de agregarlo en la Session me sirve para capturar la session en el filtro
                dgvArticulos.DataSource = Session["listaArticulo"];
                dgvArticulos.DataBind();

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow selectedRow = dgvArticulos.SelectedRow;

            if (selectedRow != null)
            {
                string id = dgvArticulos.DataKeys[selectedRow.RowIndex]["Id"].ToString();
                Response.Redirect("FormularioArticulo.aspx?id=" + Server.UrlEncode(id), false);
            }

            //string id = dgvArticulos.SelectedDataKey.Value.ToString();
            //Response.Redirect("FormularioArticulo.aspx?id=" + Server.UrlEncode(id), false);
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
            List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper())
            || x.Marca.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper())
            || x.Categoria.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper())); //lambda expression
            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.DataBind();
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            //Activamos el filtro avanzado y descativamos el filtro normal
            FiltroAvanzado = chkAvanzado.Checked;
            txtFiltro.Enabled = !FiltroAvanzado;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlCriterio.Items.Clear();
                if (ddlCampo.SelectedItem.ToString() == "Nombre")
                {
                    ddlCriterio.Items.Add("Contiene ");
                    ddlCriterio.Items.Add("Comienza con ");

                }
                else if (ddlCampo.SelectedItem.ToString() == "Marca")
                {
                    ddlCriterio.Items.Add("Contiene");
                    ddlCriterio.Items.Add("Comienza con ");


                }
                else
                {
                    ddlCriterio.Items.Add("Contiene");
                    ddlCriterio.Items.Add("Comienza con ");


                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);

            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                ArticuloNegocio negocio = new ArticuloNegocio();
                dgvArticulos.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(),
                    ddlCriterio.SelectedItem.ToString(),
                    txtFiltroAvanzado.Text);

                dgvArticulos.DataBind();

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);

            }
        }
    }
}