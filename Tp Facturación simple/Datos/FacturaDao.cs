using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Tp_Facturación_simple.Entidades;

namespace Tp_Facturación_simple.Datos
{
    public class FacturaDao
    {

        public List<Factura> ObtenerFacturas(DateTime fechaDesde, DateTime fechaHasta, string cliente)
        {
            //lista donde vamos a guardar las facturas encontradas
            List<Factura> facturas = new List<Factura>();

            // creamos la conexion
            using SqlConnection conexion = Conexion.CrearConexion();

            // la fechaHasta se maneja como limite exclusivo del dia siguiente.
            // asi incluimos todas las facturas del dia seleccionado,
            // independientemente de la hora.
            DateTime fechaHastaExclusiva = fechaHasta.Date.AddDays(1);

            string sql = @"
            SELECT
            Id,
            Numero,
            Fecha,
            ClienteNombre,
            ClienteDocumento,
            Total
            FROM Facturas
            WHERE Fecha >= @FechaDesde
            AND Fecha < @FechaHasta
            AND ClienteNombre LIKE @Cliente
            ORDER BY Fecha DESC, Numero DESC";

            // creamos el comando
            using SqlCommand comando = new SqlCommand(sql, conexion);

            // agregamos los parametros
            comando.Parameters.AddWithValue(
                "@FechaDesde",
                fechaDesde.Date);

            comando.Parameters.AddWithValue(
                "@FechaHasta",
                fechaHastaExclusiva);

            comando.Parameters.AddWithValue(
                "@Cliente",
                "%" + cliente + "%");

            // abrimos la conexion
            conexion.Open();

            // ejecutamos la consulta
            using SqlDataReader reader = comando.ExecuteReader();

            // recorremos los resultados
            while (reader.Read())
            {
                // Creamos una factura con los datos obtenidos
                Factura factura = new Factura
                {
                    Id = reader.GetInt32(0),
                    Numero = reader.GetInt32(1),
                    Fecha = reader.GetDateTime(2),
                    ClienteNombre = reader.GetString(3),
                    ClienteDocumento = reader.GetString(4),
                    Total = reader.GetDecimal(5)
                };

                // Agregamos la factura a la lista
                facturas.Add(factura);
            }

            // Devolvemos todas las facturas encontradas
            return facturas;
        }

        public int Guardar(Factura factura)
        {
            {
                // creamos la conexion a SQL Server
                using SqlConnection conexion = Conexion.CrearConexion();

                // abrimos la conexion
                conexion.Open();

                // iniciamos una transaccion.
                // esto permite que cabecera y detalles se guarden juntos.
                using SqlTransaction transaccion = conexion.BeginTransaction();

                try
                {
                    //1 OBTENER EL PRÓXIMO NÚMERO DE FACTURA

                    string sqlNumero = @"
                    SELECT ISNULL(MAX(Numero), 0) + 1
                    FROM Facturas";

                    using SqlCommand comandoNumero = new SqlCommand(
                        sqlNumero,
                        conexion,
                        transaccion);

                    int numero = Convert.ToInt32(comandoNumero.ExecuteScalar());

                    // Guardamos el numero generado en el objeto factura
                    factura.Numero = numero;


                    //2 INSERTAR LA CABECERA DE LA FACTURA

                    string sqlFactura = @"
                    INSERT INTO Facturas
                    (
                        Numero,
                        Fecha,
                        ClienteNombre,
                        ClienteDocumento,
                        Total
                    )
                    VALUES
                    (
                        @Numero,
                        @Fecha,
                        @ClienteNombre,
                        @ClienteDocumento,
                        @Total
                    );

                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    using SqlCommand comandoFactura = new SqlCommand(
                        sqlFactura,
                        conexion,
                        transaccion);

                    // Agregamos los parametros
                    comandoFactura.Parameters.AddWithValue(
                        "@Numero",
                        factura.Numero);

                    comandoFactura.Parameters.AddWithValue(
                        "@Fecha",
                        factura.Fecha);

                    comandoFactura.Parameters.AddWithValue(
                        "@ClienteNombre",
                        factura.ClienteNombre);

                    comandoFactura.Parameters.AddWithValue(
                        "@ClienteDocumento",
                        factura.ClienteDocumento);

                    comandoFactura.Parameters.AddWithValue(
                        "@Total",
                        factura.Total);

                    // Ejecutamos el INSERT y obtenemos el Id generado
                    int facturaId = Convert.ToInt32(
                        comandoFactura.ExecuteScalar());

                    // Guardamos el Id en el objeto factura
                    factura.Id = facturaId;


                    //3 INSERTAR LOS DETALLES
                   

                    foreach (FacturaDetalle detalle in factura.Detalles)
                    {
                        string sqlDetalle = @"
                        INSERT INTO FacturaDetalle
                        (
                            FacturaId,
                            ProductoId,
                            Cantidad,
                            PrecioUnitario,
                            Subtotal
                        )
                        VALUES
                        (
                            @FacturaId,
                            @ProductoId,
                            @Cantidad,
                            @PrecioUnitario,
                            @Subtotal
                        )";

                        using SqlCommand comandoDetalle = new SqlCommand(
                            sqlDetalle,
                            conexion,
                            transaccion);

                        //Agregamos los parametros del detalle
                        comandoDetalle.Parameters.AddWithValue(
                            "@FacturaId",
                            factura.Id);

                        comandoDetalle.Parameters.AddWithValue(
                            "@ProductoId",
                            detalle.ProductoId);

                        comandoDetalle.Parameters.AddWithValue(
                            "@Cantidad",
                            detalle.Cantidad);

                        comandoDetalle.Parameters.AddWithValue(
                            "@PrecioUnitario",
                            detalle.PrecioUnitario);

                        comandoDetalle.Parameters.AddWithValue(
                            "@Subtotal",
                            detalle.Subtotal);

                        comandoDetalle.ExecuteNonQuery();
                    }


                    //4 CONFIRMAR LA TRANSACCION

                    transaccion.Commit();

                    return factura.Numero;
                }
                catch
                {
                    //si algo falla, deshacemos TODOS los cambios realizados
                    //durante esta transacción 
                    transaccion.Rollback();

                    //volvemos a lanzar la excepcion para que el formulario
                    // pueda mostrar el error al usuario
                    throw;
                }
            }
        }

        public List<FacturaDetalle> ObtenerDetalles(int facturaId)
        {
            // Lista donde vamos a guardar los detalles
            List<FacturaDetalle> detalles = new List<FacturaDetalle>();

            // Creamos la conexión
            using SqlConnection conexion = Conexion.CrearConexion();

            string sql = @"
                SELECT
                    fd.Id,
                    fd.FacturaId,
                    fd.ProductoId,
                    p.Nombre,
                    fd.Cantidad,
                    fd.PrecioUnitario,
                    fd.Subtotal
                    FROM FacturaDetalle fd
                    INNER JOIN Productos p
                    ON fd.ProductoId = p.Id
                    WHERE fd.FacturaId = @FacturaId
                    ORDER BY fd.Id";

            // Creamos el comando
            using SqlCommand comando = new SqlCommand(sql, conexion);

            // Parámetro de la factura que queremos consultar
            comando.Parameters.AddWithValue(
                "@FacturaId",
                facturaId);

            // Abrimos la conexion
            conexion.Open();

            // Ejecutamos la consulta
            using SqlDataReader reader = comando.ExecuteReader();

            // Recorremos los detalles
            while (reader.Read())
            {
                FacturaDetalle detalle = new FacturaDetalle
                {
                    Id = reader.GetInt32(0),
                    FacturaId = reader.GetInt32(1),
                    ProductoId = reader.GetInt32(2),

                    // Nombre obtenido mediante el INNER JOIN
                    ProductoNombre = reader.GetString(3),

                    Cantidad = reader.GetInt32(4),
                    PrecioUnitario = reader.GetDecimal(5),
                    Subtotal = reader.GetDecimal(6)
                };

                detalles.Add(detalle);
            }

            // Devolvemos los detalles
            return detalles;
        }
    }
}
