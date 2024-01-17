using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;//Agregamos para ejercutar los comandos SQL.

namespace negocio
{
    //Clase para conectarse a la base de datos para que sea reutilizable.
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        //Para leer el lector, creamos una pripiedad
        public SqlDataReader Lector { get { return lector; } }

        //Constructor a instanciar para empezar la conexion a la DB
        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS01; database= CATALOGO_WEB_DB; integrated security = true");
            comando = new SqlCommand();

        }
        //Seteamos la query y le creamos la consulta
        public void setearQuery(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
        //Seteamos la query u le creamos el stored procedure
        public void setearStoredProcedure(string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }

        //Metodo que ejecuta la lectura
        public void ejecutarQuery()
        {
            comando.Connection = conexion; //se conecta
            try
            {
                conexion.Open(); //abre la DB
                lector = comando.ExecuteReader(); //lee la Query
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //metodo que va a ejecutar la query del Insert
        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                cerrarConexion();
            }
        }

        //Metodo que va a ejecitar la query del insert pero que va a capturar el valor de un entero, en este caso el ID
        public int ejecutarAccionScalar()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                return int.Parse(comando.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                cerrarConexion();
            }
        }

        //Metodo para recibir los parametros de la consulta
        public void setearParametros(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        //Cerramos la conexion
        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }
    }
}
