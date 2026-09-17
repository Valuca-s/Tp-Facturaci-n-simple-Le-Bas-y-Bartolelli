using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Facturación_simple.Entidades
{
    public class Producto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }  = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public bool Activo { get; set; }  

    }
}
