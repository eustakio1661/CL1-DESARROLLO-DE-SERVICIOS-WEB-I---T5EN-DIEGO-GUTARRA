using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSW1_EL1_GUTARRA_DIEGO.Entity
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string nomProducto { get; set; }
        public int IdProveedor { get; set; }
        public int IdCategoria { get; set; }
        public string CantUnidad { get; set; }
        public decimal PrecioUnidad { get; set; }
        public int stock { get; set; }
    }
}