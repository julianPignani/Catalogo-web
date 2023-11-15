using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;//agregar
using System.Data.SqlClient;//agregar

namespace negocio
{
    public class ArticuloNegocio
    {
        //Creamos el metodo listar
        public List<Articulo> listar()
        {
            //Creamos la lista articulos y instanciamos la AccesoDatos para la conexion
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            //Configuramos
            try
            {
                conexion.ConnectionString = "server =.\\SQLEXPRESS01; database = CATALOGO_DB; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT A.Id, Codigo, Nombre, A.Descripcion, ImagenUrl, Precio, M.Descripcion as Marca, M.Id as IdMarca, C.Id as IdCategoria, C.Descripcion as Categoria FROM ARTICULOS A, MARCAS M, CATEGORIAS C WHERE M.Id = A.IdMarca AND C.Id = A.IdCategoria";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)lector["Id"];
                    aux.Codigo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)lector["IdMarca"];
                    aux.Marca.Descripcion = (string)lector["Marca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)lector["Categoria"];

                    //Validamos la urlImagen por si esta null (Sirve para cualquier columna que no puede ser null)
                    if (!(lector["ImagenUrl"] is DBNull)) //si no es null
                        aux.ImagenUrl = (string)lector["ImagenUrl"];

                    aux.Precio = (decimal)lector["Precio"];

                    lista.Add(aux);
                }
                

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }

        }

        //Metodo para agregar un Articulo
        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //Llamamos al metodo setearQuery para pasarle la consulta,SetearParametros y ejecutarAccion
                datos.setearQuery("INSERT INTO ARTICULOS(Codigo,Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio) VALUES (@codigo,@nombre,@descripcion,@idMarca,@idCategoria,@imagenUrl,@precio)");
                datos.setearParametros("@codigo", nuevo.Codigo);
                datos.setearParametros("@nombre", nuevo.Nombre);
                datos.setearParametros("@descripcion", nuevo.Descripcion);
                datos.setearParametros("@idMarca", nuevo.Marca.Id);
                datos.setearParametros("@idCategoria", nuevo.Categoria.Id);
                datos.setearParametros("@imagenUrl", nuevo.ImagenUrl);
                datos.setearParametros("@precio", nuevo.Precio);

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
        //Metodo para modificar
        public void modificar(Articulo existente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("UPDATE ARTICULOS SET Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, ImagenUrl = @imagenUrl, Precio = @precio where id = @id");
                datos.setearParametros("@codigo", existente.Codigo);
                datos.setearParametros("@nombre", existente.Nombre);
                datos.setearParametros("@descripcion", existente.Descripcion);
                datos.setearParametros("@idMarca", existente.Marca.Id);
                datos.setearParametros("@idCategoria", existente.Categoria.Id);
                datos.setearParametros("@imagenUrl", existente.ImagenUrl);
                datos.setearParametros("@precio", existente.Precio);
                datos.setearParametros("@id", existente.Id);

                datos.ejecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        //Creamos el metodo para Eliminar un Artículo
        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("DELETE FROM ARTICULOS where id = @id");
                datos.setearParametros("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex )
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
