using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Facturación_simple.Entidades
{
    public class Factura
    {
        public int Id { get; set; }

        public int Numero { get; set; }

        public DateTime Fecha { get; set; }

        public string ClienteNombre { get; set; } = "";

        public string ClienteDocumento { get; set; } = "";

        public decimal Total { get; set; }

        public List<FacturaDetalle> Detalles { get; set; } = new();
    }
}
