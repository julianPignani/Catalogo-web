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
                datos.setearQuery("Select id, email, pass ,ImagenPerfil, nombre, apellido ,fechaNacimiento ,tipouser from USERS where email = @email AND pass = @pass");
                datos.setearParametros("@email", usuario.Email);
                datos.setearParametros("@pass", usuario.Pass);


                datos.ejecutarQuery();

                while (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["id"];

                    //Validamos la imagen, si es diferente a null, entonces guardamos la imagen, los demás los validamos porq son datos no requeridos y pueden generar error.
                    if (!(datos.Lector["ImagenPerfil"] is DBNull))
                        usuario.ImagenPerfil = (string)datos.Lector["ImagenPerfil"];
                    if(!(datos.Lector["nombre"] is DBNull))
                        usuario.Nombre = (string)datos.Lector["nombre"];
                    if(!(datos.Lector["apellido"] is DBNull))
                        usuario.Apellido = (string)datos.Lector["apellido"];
                    if(!(datos.Lector["fechaNacimiento"] is DBNull))
                        usuario.FechaNacimiento = DateTime.Parse(datos.Lector["fechaNacimiento"].ToString());

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

        public int Registrarse(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //Esté storedProc. nos va a devovler un valor entero, en este caso el número de id con el que se guarda.
                datos.setearStoredProcedure("registrarNuevo");
                datos.setearParametros("@email", user.Email);
                datos.setearParametros("@pass", user.Pass);
                return datos.ejecutarAccionScalar();
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

        //actualizamos la imagen en la DB
        public void actualizar(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearQuery("Update USERS set ImagenPerfil = @imagen, Nombre = @nombre, Apellido = @apellido, FechaNacimiento = @fechaNac  where Id = @id");
                datos.setearParametros("@imagen", user.ImagenPerfil != null ? user.ImagenPerfil : ""); //si no guarda una  img q guarde una cadena vacia
                datos.setearParametros("@nombre", user.Nombre);
                datos.setearParametros("@apellido", user.Apellido);
                datos.setearParametros("@fechaNac", user.FechaNacimiento);
                datos.setearParametros("@id", user.Id);

                datos.ejecutarAccion();
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
