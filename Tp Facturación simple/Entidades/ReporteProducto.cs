using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Facturación_simple.Entidades
{
    public class ReporteProducto
    {
        public string ProductoNombre { get; set; } = string.Empty;

        public int CantidadVendida { get; set; }

        public decimal MontoFacturado { get; set; }
    }
}
