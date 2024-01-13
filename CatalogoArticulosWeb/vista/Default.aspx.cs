﻿using System;
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
        //creo una lista para agregar los favoritos. (para el evento btnCorazon)
        List<string> favoritos;
        //Declaro el user acá para poder tomarlo afuera de los if.(para el evento btnCorazon)
        Usuario user;

        //Creamos una propiedad publica para traer la lista
        public List<Articulo> ListaArticulos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Validamos que tenga una session abierta para que pueda ingresar a ver los productos
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar a esté campo.");
                Response.Redirect("/Error.aspx", false);
            }

            try
            {

                //Instanciamos la clase ArticuloNegocio para poder traernos la lista
                //está modificacion de agregarlo en la Session me sirve para capturar la session en el filtro
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("listaArticulos", negocio.listarConSP());
                if (!IsPostBack)
                {
                    //mostramos los articulos
                    repRepetidor.DataSource = Session["listaArticulos"];
                    repRepetidor.DataBind();
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

        }

        //Evento para ver el articulo en un detalle mas grande.
        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            //Capturamos el argumento que viene a través del btnVerDetalle con el Id.
            string id = ((Button)sender).CommandArgument;
            Response.Redirect("VerDetalle.aspx?id=" + Server.UrlEncode(id), false);//Server.UrlEncode para garantizar que el id se transmita de manera segura a través de la URL.
        }

        //Metodo para filtrar
        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlCriterio.Items.Clear();
                if (ddlCampo.SelectedValue == "Nombre")
                {
                    ddlCriterio.Items.Add("Contiene");
                    ddlCriterio.Items.Add("Comienza con");
                }
                else
                {
                    ddlCriterio.Items.Add("Contiene");
                    ddlCriterio.Items.Add("Comienza con");
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        //Evento para filtrar
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //Llamamos a la funsion filtrarConImg y le pasamos los parametros.
                ArticuloNegocio negecio = new ArticuloNegocio();
                repRepetidor.DataSource = negecio.filtrarConImg(ddlCampo.SelectedItem.ToString(), ddlCriterio.SelectedItem.ToString(), txtFiltrar.Text);
                repRepetidor.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        //actualiza la pagina despues de filtrar
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                ddlCriterio.Items.Clear();
                txtFiltrar.Text = ""; //dejamos el campo vacio.

                ArticuloNegocio negocio = new ArticuloNegocio();
                repRepetidor.DataSource = negocio.listarConSP();
                repRepetidor.DataBind();

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        //Evento para manejar el color del corazón.
        protected void btnFavorito_Click(object sender, EventArgs e)
        {
            try
            {
                if (Seguridad.sesionActiva(Session["usuario"]))
                {
                    // Leemos el ID que viene por el btn
                    string IdFavorito = ((Button)sender).CommandArgument;

                    // Verificamos si la sesión del usuario existe
                    if (Session["usuario"] != null)
                    {
                        // Traemos la información del usuario (recuerda que 'user' está declarado como variable local)
                        user = (Usuario)Session["usuario"];

                        // Verificamos si existe una lista de favoritos en la sesión, si no la creamos
                        if (user.Favoritos == null)
                        {
                            user.Favoritos = new List<string>();
                        }

                        // Obtenemos la lista de favoritos del usuario
                        favoritos = user.Favoritos;

                        // Verificamos si el artículo está presente en la lista de favoritos
                        if (favoritos.Contains(IdFavorito))
                        {
                            // Si no está, removemos ese artículo y dejamos el corazón en blanco
                            favoritos.Remove(IdFavorito);
                            ((Button)sender).Text = "❤️";
                        }
                        else
                        {
                            // Agregamos el artículo a la lista de favoritos
                            favoritos.Add(IdFavorito);
                            ((Button)sender).Text = "💚";
                        }

                        // Actualizamos los datos en la sesión
                        Session["usuario"] = user;

                        // Asignamos la lista de favoritos a Session["listaFavoritos"]
                        Session["listaFavoritos"] = favoritos;
                    }

                    // Redireccionamos a Favorito.aspx
                    Response.Redirect("Favorito.aspx", false);
                    
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


