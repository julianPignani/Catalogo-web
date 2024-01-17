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
        // Validar si ya existe un usuario en sesión o no.
        public static bool sesionActiva(object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            return usuario != null && usuario.Id != 0;
        }

        // Método para validar si el usuario es Admin, si es admin es true
        public static bool esAdmin(Usuario usuario)
        {
            // Ahora validamos directamente el valor del booleano Admin
            return usuario != null && usuario.Admin;
        }
    }
}


