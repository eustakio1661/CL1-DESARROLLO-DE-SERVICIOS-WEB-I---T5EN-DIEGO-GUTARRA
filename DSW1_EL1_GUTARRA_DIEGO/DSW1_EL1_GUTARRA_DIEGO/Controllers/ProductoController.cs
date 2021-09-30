using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DSW1_EL1_GUTARRA_DIEGO.Entity;
using DSW1_EL1_GUTARRA_DIEGO.Models;

namespace DSW1_EL1_GUTARRA_DIEGO.Controllers
{
    public class ProductoController : Controller
    {
        ProductoDAO objpro = new ProductoDAO();
        CategoriaDAO objcat = new CategoriaDAO();
        public ActionResult ConsultaProducto(string producto = null, int IdCategoria = 0)
        {
            ViewBag.categorias = new SelectList(objcat.ListarCategorias(), "IdCategoria", "nomCategoria",IdCategoria);
            if (producto == null && IdCategoria == 0)
            {
                return View(objpro.ListarProductos());
            }
            else if (producto == null && IdCategoria != 0)
            {
                return View(objpro.ListarProductos(producto,IdCategoria));
            }
            else{
                return View(objpro.ListarProductos(producto, IdCategoria));
                    
            }

 
        }
     
    }
}