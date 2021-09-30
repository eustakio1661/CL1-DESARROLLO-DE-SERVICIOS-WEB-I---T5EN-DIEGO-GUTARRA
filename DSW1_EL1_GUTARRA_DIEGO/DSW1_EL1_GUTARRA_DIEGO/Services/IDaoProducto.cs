using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSW1_EL1_GUTARRA_DIEGO.Services
{
    public interface IDaProducto<T>
    {
        List<T> ListarProductos(string nombre, int idCategoria);
        List<T> ListarProductos();
    }
}