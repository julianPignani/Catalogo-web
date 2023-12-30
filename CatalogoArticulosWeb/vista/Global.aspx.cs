using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace vista
{
    public partial class Global : System.Web.UI.Page
    {
        protected void Application_Start(object sender, EventArgs e)
        {

        }

        //Capturamos cualquier Exception que pueda llegar a generar la aplicacion y no la estamos capturando en otra parte.
        //Error Genérico
        void Application_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();

            Session.Add("error", exc.ToString());
            //Response.Redirect("Error.aspx", false);
            Server.Transfer("Error.aspx");
        }
    }
}