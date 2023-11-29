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
            //ponemos la caja de texto del id en Enabled para que no se pueda modificar
            txtId.Enabled = false;

            try
            {
                if (!IsPostBack)
                {
                    //Mostramos los elementos en el desplegable de categoria
                    CategoriaNegocio categoria = new CategoriaNegocio();
                    List<Categoria> listaCat = categoria.listar();
                    ddlCategoria.DataSource = listaCat;
                    ddlCategoria.DataValueField = "Id"; //el id seria el valor con el cúal lo vamos a capturar despúes
                    ddlCategoria.DataTextField = "Descripcion"; //Nombre de la propiedad de la clase
                    ddlCategoria.DataBind();

                    //mostramos los elementos en el desplegable de marca
                    MarcaNegocio marca = new MarcaNegocio();
                    List<Marca> listaMarca = marca.listar();
                    ddlMarca.DataSource = listaMarca;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex); //Capturamos el error y lo guardamos en una session
                throw;
                //redireccion pantalla error
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            //Leemos la imagen
            imgArticulos.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //Instanciamos la clase ArticuloNegocio para llamar al metodo agregar
                ArticuloNegocio negocio = new ArticuloNegocio();

                //Creamos un nuevo articulo y traemos los datos ingresados
                Articulo nuevo = new Articulo();
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Precio = int.Parse(txtPrecio.Text);
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.ImagenUrl = txtImagenUrl.Text;

                //traemos los datos seleccionados en el desplegable
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                negocio.agregarconSP(nuevo);
                Response.Redirect("ListaArticulo.aspx", false); //Lo enviamos a la ListaArticulo
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);//Capturamos el error y lo guardamos en una session
                throw;
                //redireccion pantalla error
            }
        }
    }
}