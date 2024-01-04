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
    public partial class VerDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //Capturo el id que viene por el btnVerDetalle
                    //operar ternario, si viene id lo guardo, sino null
                    string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : ""; 

                    if(id != null  && (!IsPostBack))
                    {
                        ArticuloNegocio negocio = new ArticuloNegocio();
                        Articulo seleccionado = (negocio.listar(id)[0]);//esto devuelve una lista, entonces listamos y le pedimos el primer valor

                        //Pre cargamos los datos
                        txtNombre.Text = seleccionado.Nombre;
                        txtMarca.Text = seleccionado.Marca.ToString();
                        txtDescripcion.Text = seleccionado.Descripcion;
                        // Formatear el precio con dos dígitos decimales y agregar el símbolo de dólar
                        txtPrecio.Text = $"${seleccionado.Precio:F2}";
                        imgDetalle.ImageUrl = seleccionado.ImagenUrl.ToString();
                    }
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