using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class UsuarioNegocio
    {
        public bool Loguear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Select id, tipouser from USERS where email = @email AND pass = @pass");
                datos.setearParametros("@email", usuario.Email);
                datos.setearParametros("@pass", usuario.Pass);

                datos.ejecutarQuery();

                while (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["id"];
                    usuario.TipoUsarios = (int)datos.Lector["TipoUser"] == 2 ? Usuario.TipoUsario.ADMIN : Usuario.TipoUsario.NORMAL;

                    return true; //si lee una sola vez , me devuelve tru para saber que valido.
                }

                return false; //si el while no lo lee, es porque no logeo.
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


    }
}
