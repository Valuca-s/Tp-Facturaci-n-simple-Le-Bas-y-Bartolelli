using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.SqlClient;

namespace Tp_Facturación_simple.Datos
{
    public static class Conexion
    {
        private static readonly string cadenaConexion =
            "Data Source=(localdb)\\MSSQLLocalDB;" +
            "Initial Catalog=FacturacionSimple;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";

        public static SqlConnection CrearConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
