using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMVC.Models;

namespace TiendaMVC.Controllers
{
    public class ProductoAjaxController : Controller
    {
        Tienda11Entities db= new Tienda11Entities();

        // GET: ProductoAjax
        public ActionResult Index()
        {
            return View(db.Producto);
        }

        public ActionResult Alta(Producto model)
        {
            db.Producto.Add(model);
            db.SaveChanges();
            return Json(model);
        }

        public ActionResult Buscar(String elnombre)
        {
            var data = db.Producto.Where(o => o.NombreProducto.Contains(elnombre));
            return PartialView("_ListadoProductos", data);
        }
    }
}