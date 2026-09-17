using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Tp_Facturación_simple.Entidades;

namespace Tp_Facturación_simple.Datos
{
    public class ProductoDao
    {
        public List<Producto> ObtenerTodos()
        {
            //creamos una lista para guardar todos los productos
            List<Producto> productos = new List<Producto>();

            //creamos la conexion con SQL Server
            using SqlConnection conexion = Conexion.CrearConexion();

            //consulta para obtener todos los productos
            string sql = @"
        SELECT Id, Codigo, Nombre, Precio, Activo
        FROM Productos
        ORDER BY Nombre";

            // creamos el comando SQL
            using SqlCommand comando = new SqlCommand(sql, conexion);

            // Abrimos la conexion
            conexion.Open();

            // ejecutamos la consulta
            using SqlDataReader reader = comando.ExecuteReader();

            // Recorremos los resultados
            while (reader.Read())
            {
                // creamos un objeto Producto con los datos obtenidos
                Producto producto = new Producto
                {
                    Id = reader.GetInt32(0),
                    Codigo = reader.GetString(1),
                    Nombre = reader.GetString(2),
                    Precio = reader.GetDecimal(3),
                    Activo = reader.GetBoolean(4)
                };

                // Agregamos el producto a la lista
                productos.Add(producto);
            }

            // devolvemos todos los productos
            return productos;
        }
        public List<Producto> ObtenerActivos()
        {
            // creamos una lista para guardar los productos activos
            List<Producto> productos = new List<Producto>();

            // creamos la conexion con SQL Server
            using SqlConnection conexion = Conexion.CrearConexion();

            // consulta  para obtener solamente productos activos
            string sql = @"
        SELECT Id, Codigo, Nombre, Precio, Activo
        FROM Productos
        WHERE Activo = 1
        ORDER BY Nombre";

            // Creamos el comando SQL
            using SqlCommand comando = new SqlCommand(sql, conexion);

            // Abrimos la conexion
            conexion.Open();

            // ejecutamos la consulta
            using SqlDataReader reader = comando.ExecuteReader();

            // Recorremos los resultados
            while (reader.Read())
            {
                // Creamos un objeto Producto con los datos de SQL Server
                Producto producto = new Producto
                {
                    Id = reader.GetInt32(0),
                    Codigo = reader.GetString(1),
                    Nombre = reader.GetString(2),
                    Precio = reader.GetDecimal(3),
                    Activo = reader.GetBoolean(4)
                };

                // Agregamos el producto a la lista
                productos.Add(producto);
            }

            // Devolvemos la lista
            return productos;
        }

        public void Agregar(Producto producto)
        {
            using SqlConnection conexion = Conexion.CrearConexion();

            string sql = @"INSERT INTO Productos (Codigo, Nombre, Precio, Activo) VALUES (@Codigo, @Nombre, @Precio, @Activo)";

            using SqlCommand comando = new SqlCommand(sql, conexion);

            comando.Parameters.AddWithValue("@Codigo", producto.Codigo);
            comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
            comando.Parameters.AddWithValue("@Precio", producto.Precio);
            comando.Parameters.AddWithValue("@Activo", producto.Activo);

            conexion.Open();
            comando.ExecuteNonQuery();
        }

        public List<Producto> Buscar(string texto)
        {
            List<Producto> productos = new List<Producto>();

            using SqlConnection conexion = Conexion.CrearConexion();

            string sql = @"
                SELECT Id, Codigo, Nombre, Precio, Activo
                FROM Productos
                WHERE Codigo LIKE @Texto
                OR Nombre LIKE @Texto
                ORDER BY Nombre";

            using SqlCommand comando = new SqlCommand(sql, conexion);

            comando.Parameters.AddWithValue("@Texto", "%" + texto + "%");

            conexion.Open();

            using SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Producto producto = new Producto
                {
                    Id = reader.GetInt32(0),
                    Codigo = reader.GetString(1),
                    Nombre = reader.GetString(2),
                    Precio = reader.GetDecimal(3),
                    Activo = reader.GetBoolean(4)
                };

                productos.Add(producto);
            }



            return productos;
        }

        public void Modificar(Producto producto)
        {
            using SqlConnection conexion = Conexion.CrearConexion();

            string sql = @"
                UPDATE Productos
                SET Codigo = @Codigo,
                Nombre = @Nombre,
                Precio = @Precio
                WHERE Id = @Id";

            using SqlCommand comando = new SqlCommand(sql, conexion);

            comando.Parameters.AddWithValue("@Codigo", producto.Codigo);
            comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
            comando.Parameters.AddWithValue("@Precio", producto.Precio);
            comando.Parameters.AddWithValue("@Id", producto.Id);

            conexion.Open();

            comando.ExecuteNonQuery();
        }

        public void DarDeBaja(int id)
        {
            using SqlConnection conexion = Conexion.CrearConexion();

            string sql = @"
                UPDATE Productos
                SET Activo = 0
                WHERE Id = @Id";

            using SqlCommand comando = new SqlCommand(sql, conexion);

            comando.Parameters.AddWithValue("@Id", id);

            conexion.Open();

            comando.ExecuteNonQuery();
        }
    }
}
