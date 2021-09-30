using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DSW1_EL1_GUTARRA_DIEGO.Entity;
using DSW1_EL1_GUTARRA_DIEGO.Models;

namespace DSW1_EL1_GUTARRA_DIEGO.Controllers
{
    public class EmpleadoController : Controller
    {
        CargoDAO objcar = new CargoDAO();
        DistritoDAO objdis = new DistritoDAO();
        EmpleadoDAO objem = new EmpleadoDAO();

        public ActionResult MantenimientoEmpleado()
        {
            return View(objem.ListarEmpleados().ToList());
        }

        public ActionResult Details(int id)
        {
            return View(objem.BuscarEmpleado(id));
        }
        public ActionResult Create()
        {
            ViewBag.distritos = new SelectList(objdis.ListarDistrito(), "idDistrito", "descripcion");
            ViewBag.cargos = new SelectList(objcar.ListarCargo(), "idCargo", "descripcion");
            return View(new Empleado());
        }

        [HttpPost]
        public ActionResult Create(Empleado reg)
        {
            ViewBag.distritos = new SelectList(objdis.ListarDistrito(), "idDistrito", "descripcion");
            ViewBag.cargos = new SelectList(objcar.ListarCargo(), "idCargo", "descripcion");
            try
            {
                if (ModelState.IsValid)
                {
                    objem.InsertarEmpleado(reg);
                    return RedirectToAction("MantenimientoEmpleado");
                }
                return RedirectToAction("MantenimientoEmpleado");
            }

            catch
            {
                return View();
            }

        }
        public ActionResult Edit(int id)
        {
            Empleado reg = objem.BuscarEmpleado(id);
            ViewBag.distritos = new SelectList(objdis.ListarDistrito(), "idDistrito", "descripcion",reg.idDistrito);
            ViewBag.cargos = new SelectList(objcar.ListarCargo(), "idCargo", "descripcion",reg.idCargo);

            return View(reg);
        }
        [HttpPost]
        public ActionResult Edit(Empleado reg)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objem.ActualizarEmpleado(reg);
                    return RedirectToAction("MantenimientoEmpleado");
                }
                return RedirectToAction("MantenimientoEmpleado");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            Empleado em = objem.BuscarEmpleado(id);
            return View(em);

        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado em = objem.BuscarEmpleado(id);
            objem.BajaEmpleado(em);
            return RedirectToAction("MantenimientoEmpleado");
        }
    }
}