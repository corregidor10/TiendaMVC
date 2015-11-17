using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using TiendaMVC.Filtros;
using TiendaMVC.Models;

namespace TiendaMVC.Controllers
{
    public class AlmacenController : Controller
    {
        private Tienda11Entities db =
        new Tienda11Entities();
        
        // GET: Almacen
        public ActionResult Index()

        {
            var info = db.Etiqueta;

            ViewBag.lasetiquetas = info.ToList(); // el ViewBag crea una variable para ejecutar la peticion

            ViewData["Titulo"] = "Listado de Etiquetas"; // el ViewData es similar a ViewBag, pero definiendo la variable entre corchetes

            var data = db.Almacen;
            return View(data);
        }

        [FiltroId] //implementamos el filtro como atributo, en este caso solo en el get
        public ActionResult Modificar(int id)
        {
            var data = db.Almacen.Find(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificar(Almacen model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);



        }

        [FiltroId]
        public ActionResult Borrar(int id)
        {
            var data = db.Almacen.Find(id);

            if (data.ProductoAlmacen.Any())
                db.ProductoAlmacen.RemoveRange(data.ProductoAlmacen);

            db.Almacen.Remove(data);
            db.SaveChanges();

            return RedirectToAction("Index");

        }


        public ActionResult Alta()
        {
            return View(new Almacen());
        }

        [HttpPost]
        public ActionResult Alta(Almacen model)
        {
            if (ModelState.IsValid)
            {
                db.Almacen.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }
    }

}