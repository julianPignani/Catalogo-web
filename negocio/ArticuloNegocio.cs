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
        //Agregando el parametro vacio, se agrega como opcional, entonces en la consulta podemos evaluar con un if si lleva un id o no y concatenar la consulta
        public List<Articulo> listar(string id = "")
        {
            //Creamos la lista articulos y instanciamos la AccesoDatos para la conexion
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            //Configuramos
            try
            {
                datos = new AccesoDatos();
                // Inicializar la consulta
                string consulta = "SELECT A.Id, Codigo, Nombre, A.Descripcion, ImagenUrl, Precio, M.Descripcion as Marca, M.Id as IdMarca, C.Id as IdCategoria, C.Descripcion as Categoria FROM ARTICULOS A, MARCAS M, CATEGORIAS C WHERE M.Id = A.IdMarca AND C.Id = A.IdCategoria ";

                // Validar si se proporciona un ID y agregar la condición correspondiente
                if (!string.IsNullOrEmpty(id))
                {
                    consulta += " AND A.Id = @Id";
                    // Setear el parámetro correspondiente al ID
                    datos.setearParametros("@Id", id);
                }

                // Establecer la consulta modificada
                datos.setearQuery(consulta);

                datos.ejecutarQuery();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    //Validamos la urlImagen por si esta null (Sirve para cualquier columna que no puede ser null)
                    if (!(datos.Lector["ImagenUrl"] is DBNull)) //si no es null
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    aux.Precio = (decimal)datos.Lector["Precio"];

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
                datos.cerrarConexion();
            }

        }

        public List<Articulo> listarFavorito(List<string> ids)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulo> lista = new List<Articulo>();

            try
            {
                // Suponiendo que ids es la lista de IDs,Convertir la lista de IDs a una cadena separada por comas
                string idsParam = string.Join(",", ids.Select(id => "@" + id)); // Transforma los IDs en parámetros, ej: "@id1,@id2,@id3"

                string consulta = $"SELECT A.Id, Nombre, A.Descripcion, ImagenUrl, M.Descripcion as Marca, A.IdMarca, C.Descripcion as Categoria, A.IdCategoria FROM ARTICULOS A JOIN MARCAS M ON M.Id = A.IdMarca JOIN CATEGORIAS C ON C.Id = A.IdCategoria WHERE A.Id IN ({string.Join(",", ids)})";

                // Configurar la consulta con los parámetros
                for (int i = 0; i < ids.Count; i++)
                {
                    //Reemplazamos los parametros en la consulta
                    consulta = consulta.Replace($"@id{i + 1}", ids[i]);
                }

                datos.setearQuery(consulta);
                datos.ejecutarQuery();

                while (datos.Lector.Read())
                {
                    // Construir objetos Articulo y agregar a la lista
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    //Validamos la urlImagen por si esta null (Sirve para cualquier columna que no puede ser null)
                    if (!(datos.Lector["ImagenUrl"] is DBNull)) //si no es null
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];



                    lista.Add(aux);
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones
                 ex.ToString();
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }

        public void agregarFavorito(Favorito favorito)
        {
            AccesoDatos datos = new AccesoDatos();
            
            try
            {
                // Llamamos al método setearQuery para pasarle la consulta, SetearParametros y ejecutarAccion
                datos.setearQuery("INSERT INTO FAVORITOS(IdUser, IdArticulo) VALUES (@idUser, @idArticulo)");
                datos.setearParametros("@idUser", favorito.IdUsuario);
                datos.setearParametros("@idArticulo", favorito.IdArticulo);
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


        //Metodo para listar con Stored Procedure
        public List<Articulo> listarConSP()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulo> lista = new List<Articulo>();

            try
            {

                datos.setearStoredProcedure("storedListar");
                datos.ejecutarQuery();


                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    //Validamos la urlImagen por si esta null (Sirve para cualquier columna que no puede ser null)
                    if (!(datos.Lector["ImagenUrl"] is DBNull)) //si no es null
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    aux.Precio = (decimal)datos.Lector["Precio"];

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
                datos.cerrarConexion();
            }

        }

        //Metodo para agregar un Articulo con StoredProdecedure
        public void agregarconSP(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //Llamamos al metodo setearQuery para pasarle la consulta,SetearParametros y ejecutarAccion
                datos.setearStoredProcedure("storedAltaArticulo");
                datos.setearParametros("@codigo", nuevo.Codigo);
                datos.setearParametros("@nombre", nuevo.Nombre);
                datos.setearParametros("@descripcion", nuevo.Descripcion);
                datos.setearParametros("@idMarca", nuevo.Marca.Id);
                datos.setearParametros("@idCategoria", nuevo.Categoria.Id);
                datos.setearParametros("@imagenUrl", nuevo.ImagenUrl);
                datos.setearParametros("@precio", nuevo.Precio);

                //ejecutarAccion va cuando le pasamos los parametros.
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

        public void modificarconSP(Articulo existente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearStoredProcedure("storedModificarArticulo");
                datos.setearParametros("@codigo", existente.Codigo);
                datos.setearParametros("@nombre", existente.Nombre);
                datos.setearParametros("@idMarca", existente.Marca.Id);
                datos.setearParametros("@idCategoria", existente.Categoria.Id);
                datos.setearParametros("@precio", existente.Precio);
                datos.setearParametros("@descripcion", existente.Descripcion);
                datos.setearParametros("@imagenUrl", existente.ImagenUrl);
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

        public void eliminarconSP(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearStoredProcedure("storedEliminarArticulo");
                datos.setearParametros("@id", id);
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

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "Select A.Id ,Codigo , Nombre , A.Descripcion , M.Descripcion Marca, C.Descripcion Categoria, A.IdMarca, A.IdCategoria, Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id = A.IdMarca and C.Id = A.IdCategoria And  ";
                if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%' ";
                            break;
                        case "contiene":
                            consulta += "Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Marca")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "M.Descripcion like '" + filtro + "%' ";
                            break;
                        case "contiene":
                            consulta += "M.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "M.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "C.Descripcion like '" + filtro + "%' ";
                            break;
                        case "contiene ":
                            consulta += "C.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "C.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }

                datos.setearQuery(consulta);
                datos.ejecutarQuery();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    aux.Precio = (decimal)datos.Lector["Precio"];
                    

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
                datos.cerrarConexion();
            }
        }
        public List<Articulo>filtrarConImg(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "Select A.Id ,ImagenUrl , Nombre , A.Descripcion , M.Descripcion Marca,C.Descripcion Categoria, A.IdMarca,A.IdCategoria from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id = A.IdMarca and C.Id = A.IdCategoria And ";
                if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%' ";
                            break;
                        case "contiene":
                            consulta += "Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Marca")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "M.Descripcion like '" + filtro + "%' ";
                            break;
                        case "contiene":
                            consulta += "M.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "M.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "C.Descripcion like '" + filtro + "%' ";
                            break;
                        case "contiene ":
                            consulta += "C.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "C.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }

                datos.setearQuery(consulta);
                datos.ejecutarQuery();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    //Validamos la urlImagen por si esta null (Sirve para cualquier columna que no puede ser null)
                    if (!(datos.Lector["ImagenUrl"] is DBNull)) //si no es null
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    

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
                datos.cerrarConexion();
            }
        }

        public List<Articulo> obtenerArticulosFavoritos(int idUsuario)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearQuery("SELECT A.Id, A.Nombre, M.Descripcion AS Marca, A.IdMarca , A.Descripcion, A.ImagenUrl " +
                  "FROM Favoritos F " +
                  "JOIN Articulos A ON F.IdArticulo = A.Id " +
                  "JOIN Marcas M ON A.IdMarca = M.Id " +
                  "WHERE F.IdUser = @IdUser");
                datos.setearParametros("@IdUser", idUsuario);
                datos.ejecutarQuery();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    // Validamos la urlImagen por si esta null(Sirve para cualquier columna que no puede ser null)
                    if (!(datos.Lector["ImagenUrl"] is DBNull)) //si no es null
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    lista.Add(aux);


                }
                return lista;
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

        //Creamos el metodo para Eliminar un articulo de favorito
        public void eliminarFavorito(string idFavorito)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("DELETE FROM FAVORITOS where IdArticulo = @idFavorito");
                datos.setearParametros("@idFavorito", idFavorito);
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

        //Metodo para agregar un Articulo
        /*public void agregar(Articulo nuevo)
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

                //ejecutarAccion va cuando le pasamos los parametros.
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
        }*/

        //Metodo para modificar
        /*public void modificar(Articulo existente)
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
        }*/
    }


}
