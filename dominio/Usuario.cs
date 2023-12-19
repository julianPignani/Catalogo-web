using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Usuario
    {
        //Creamos un Enum para manejar el tipo de usuario (user o admin)
        public enum TipoUsario
        {
            NORMAL = 1,
            ADMIN = 2
        }

        public int Id { get; set; }
        public string Email { get; set; }

        public string Pass { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string ImagenPerfil { get; set; }

        public TipoUsario TipoUsarios { get; set; }

        //Creamos el constrctor
        public Usuario(string user, string pass, bool admin)
        {
            Email = user;
            Pass = pass;
            TipoUsarios = admin ? TipoUsario.ADMIN : TipoUsario.NORMAL;
        }
        //constructor vacio
        public Usuario() { }


    }
    

}
