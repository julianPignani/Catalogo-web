using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public static class Seguridad
    {
        // (user) es el usuario que recibo por parametro, al ser objet puede traer varias cosas
        //Esto va a validar si ya existe un usuario en session o no.
        public static bool sesionActiva(object user)
        {
            Usuario usuario = user != null ? (Usuario) user : null;
            if (usuario != null && usuario.Id != 0)
                return true;
            else
                return false;
        }

        //Metodo para validar si el usuario es Admin
        public static bool esAdmin(Usuario usuario)
        {
            return usuario != null && usuario.TipoUsarios == Usuario.TipoUsario.ADMIN;
        }
    }
}


