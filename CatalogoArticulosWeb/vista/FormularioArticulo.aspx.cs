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
        public bool ConfirmarEliminacion { get; set; }
        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //ponemos la caja de texto del id en Enabled para que no se pueda modificar
            txtId.Enabled = false;

            //Ponemos en false el confirmar eliminacion para que nos apareza la validacion si toca eliminar
            ConfirmarEliminacion = false;
            try
            {
                //configuración inicial de la pantalla
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


                    //Configuración si estamos modificando
                    //Capturamos el id que viene desde listaArticulos
                    string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : ""; //operar ternario, si viene id lo guardo, sino null
                    if (id != null && (!IsPostBack))
                    {
                        ArticuloNegocio negocio = new ArticuloNegocio();
                        //List<Articulo> lista = negocio.listar(id); 
                        //Articulo seleccionado = lista[0];estas dos lineas las podemos simplificar
                        Articulo seleccionado = (negocio.listar(id)[0]); //nosotros ya sabemos que devuelve una lista, entonces listamos y le pedimos el primer valor


                        //pre cargar datos
                        txtId.Text = id;
                        txtCodigo.Text = seleccionado.Codigo;
                        txtNombre.Text = seleccionado.Nombre;
                        txtDescripcion.Text = seleccionado.Descripcion;
                        txtImagenUrl.Text = seleccionado.ImagenUrl;
                        txtPrecio.Text = seleccionado.Precio.ToString();

                        ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                        ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                        imgArticulos.ImageUrl = txtImagenUrl.Text;
                    }
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

                //traemos los datos seleccionados en el desplegable
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.ImagenUrl = txtImagenUrl.Text;

                //Validamos si agregamos o modificamos el Articulo- si viene con un id modifica, sino agregamos
                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text); //le tengo que asignar el id para que sepa que articulo modificar
                    negocio.modificarconSP(nuevo);
                }
                else
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

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmarEliminacion = true;
        }

        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmaEliminar.Checked) //Si esta chekeado (o sea, tildo el cuadrado para borrar)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.eliminarconSP(int.Parse(txtId.Text));
                    Response.Redirect("ListaArticulo.aspx");
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                throw;
            }
        }
    }
}