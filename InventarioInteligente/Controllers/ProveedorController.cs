using System.Collections.Generic;
using System.Web.Mvc;

using InventarioInteligente.Models;
using SmarketModels;

namespace InventarioInteligente.Controllers
{
    public class ProveedorController : Controller
    {
        private Market market = new Market();
        //
        // GET: /Proveedor/

        public ActionResult Index()
        {
            List<Proveedor> proveedores = market.Proveedores.ListarTodos();
            return View(proveedores);
        }

        //
        // GET: /Proveedor/Details/5

        public ActionResult Details(string NIT)
        {
            Proveedor proveedor = market.Proveedores.ListarPorNIT(NIT);
            return View(proveedor);
        }

        //
        // GET: /Proveedor/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Proveedor/Create

        [HttpPost]
        public ActionResult Create(Proveedor proveedor)
        {
            try
            {
                // TODO: Add insert logic here
                market.Proveedores.AgregarProveedor(proveedor);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Proveedor/Edit/5
 
        public ActionResult Edit(string NIT)
        {
            Proveedor proveedor = market.Proveedores.ListarPorNIT(NIT);
            return View(proveedor);
        }

        //
        // POST: /Proveedor/Edit/5

        [HttpPost]
        public ActionResult Edit(string NIT, Proveedor proveedor)
        {
            try
            {
                // TODO: Add update logic here
                market.Proveedores.ActualizarProveedor(NIT, proveedor);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Proveedor/Delete/5
 
        public ActionResult Delete(string NIT)
        {
            Proveedor proveedor = market.Proveedores.ListarPorNIT(NIT);
            return View(proveedor);
        }

        //
        // POST: /Proveedor/Delete/5

        [HttpPost]
        public ActionResult Delete(string NIT, Proveedor proveedor)
        {
            try
            {
                // TODO: Add delete logic here
                market.Proveedores.EliminarProveedorPorNIT(NIT);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
