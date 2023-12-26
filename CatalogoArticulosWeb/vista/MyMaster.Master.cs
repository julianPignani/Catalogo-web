using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace vista
{
    public partial class MyMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Validamos si ya existe un usuario en session o no, y validamos en que pantallas puede ver el usuario sin estar logueado.
                if (!(Page is Login || Page is Bienvenida || Page is Registro) && !Seguridad.sesionActiva(Session["usuario"]))
                {
                    if (!Seguridad.sesionActiva(Session["usuario"]))
                        Response.Redirect("Login.aspx", false);

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Clear();
                Response.Redirect("Login.aspx", false);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}