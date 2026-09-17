using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Tp_Facturación_simple.Entidades;


namespace Tp_Facturación_simple.Datos
{
    public class ReporteDao
    {

        public List<ReporteProducto> ObtenerReportePorProducto(DateTime fechaDesde, DateTime fechaHasta, int? productoId)
        {
            // creamos la lista donde vamos a guardar los resultados
            List<ReporteProducto> reporte = new List<ReporteProducto>();

            // calculamos el limite exclusivo de la fecha hasta
            DateTime fechaHastaExclusiva = fechaHasta.Date.AddDays(1);

            // creamos la conexion
            using SqlConnection conexion = Conexion.CrearConexion();

            string sql = @"
                SELECT
                    p.Nombre,
                    SUM(fd.Cantidad) AS CantidadVendida,
                    SUM(fd.Subtotal) AS MontoFacturado
                FROM FacturaDetalle fd
                INNER JOIN Facturas f
                    ON fd.FacturaId = f.Id
                INNER JOIN Productos p
                    ON fd.ProductoId = p.Id
                WHERE f.Fecha >= @FechaDesde
                  AND f.Fecha < @FechaHasta
                  AND (@ProductoId IS NULL OR p.Id = @ProductoId)
                GROUP BY p.Id, p.Nombre
                ORDER BY p.Nombre";

            using SqlCommand comando = new SqlCommand(sql, conexion);

            // agregamos los parametros de fechas
            comando.Parameters.AddWithValue(
                "@FechaDesde",
                fechaDesde.Date);

            comando.Parameters.AddWithValue(
                "@FechaHasta",
                fechaHastaExclusiva);

            // agregamos el producto seleccionado
            comando.Parameters.AddWithValue(
                "@ProductoId",
                productoId.HasValue
                    ? productoId.Value
                    : DBNull.Value);

            // abrimos la conexion
            conexion.Open();

            // ejecutamos la consulta
            using SqlDataReader reader = comando.ExecuteReader();

            // recorremos los resultados
            while (reader.Read())
            {
                // creamos un objeto con los datos del reporte
                ReporteProducto resultado = new ReporteProducto
                {
                    ProductoNombre = reader.GetString(0),
                    CantidadVendida = reader.GetInt32(1),
                    MontoFacturado = reader.GetDecimal(2)
                };

                // agregamos el resultado a la lista
                reporte.Add(resultado);
            }

            // devolvemos los resultados
            return reporte;
        }
    }
}
