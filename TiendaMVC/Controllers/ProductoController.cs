using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMVC.Models;

namespace TiendaMVC.Controllers
{
    public class ProductoController : Controller 
    {

        Tienda11Entities db=new Tienda11Entities();

        public ActionResult Index()
        {
            var data = db.Producto;
            return View(data);
        }

        public ActionResult Borrar(int id)
        {
         Producto data = db.Producto.Find(id);
            return View(data);

        }

        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete (int id)
        {
            Producto data = db.Producto.Find(id);
            if (data==null)
            {
                return HttpNotFound();
            }
            
            db.Producto.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Detalle(int id)
        {
            var data = db.Producto.Find(id);
            return View(data);
        }
        // GET: Producto

        [HttpGet]
        public ActionResult Alta()
        {
            return View(new Producto());
        }

        [HttpPost]
        public ActionResult Alta(Producto model)
        {
            if (ModelState.IsValid) 
            {
                db.Producto.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index"); // y devuelve otra vez la vista en blanco
            }

            return RedirectToAction("Index");
        }

        public ActionResult Modificar(int id)
        {
            Producto pr = db.Producto.Find(id);
            if (pr==null)
            {
                return Index();
            }
            return View(pr);
        }

        [HttpPost]
        public ActionResult Modificar(Producto pr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pr).State=EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pr);
        }
    }
}