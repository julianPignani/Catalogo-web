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
                datos.setearQuery("Select id, email, pass ,urlImagenPerfil, nombre, apellido ,admin from USERS where email = @email AND pass = @pass");
                datos.setearParametros("@email", usuario.Email);
                datos.setearParametros("@pass", usuario.Pass);


                datos.ejecutarQuery();

                while (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["id"];

                    //Validamos la imagen, si es diferente a null, entonces guardamos la imagen, los demás los validamos porq son datos no requeridos y pueden generar error.
                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        usuario.ImagenPerfil = (string)datos.Lector["urlImagenPerfil"];
                    if(!(datos.Lector["nombre"] is DBNull))
                        usuario.Nombre = (string)datos.Lector["nombre"];
                    if(!(datos.Lector["apellido"] is DBNull))
                        usuario.Apellido = (string)datos.Lector["apellido"];

                    usuario.Admin = (bool)datos.Lector["admin"];




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
                datos.setearStoredProcedure("storedregistrarNuevo");
                datos.setearParametros("@email", user.Email);
                datos.setearParametros("@pass", user.Pass);
                datos.setearParametros("@admin", Seguridad.esAdmin(user) ? 1 : 0);  // 1 para admin, 0 para usuario normal

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

                datos.setearQuery("Update USERS set urlImagenPerfil = @imagen, Nombre = @nombre, Apellido = @apellido  where Id = @id");
                //datos.setearParametros("@imagen", user.ImagenPerfil != null ? user.ImagenPerfil : (object)DBNull.Value); //si no guarda una  img q guarde un null.
                datos.setearParametros("@imagen", (object)user.ImagenPerfil ?? DBNull.Value); //(Operador para nulls), podemos usar esta forma o la de arriba. 
                datos.setearParametros("@nombre", user.Nombre);
                datos.setearParametros("@apellido", user.Apellido);
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
