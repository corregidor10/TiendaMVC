using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMVC.Filtros;
using TiendaMVC.Models;

namespace TiendaMVC.Controllers
{
    public class EtiquetaController : Controller
    {
        Tienda11Entities db= new Tienda11Entities();
        
        // GET: Etiqueta
        [FiltroTime]
        public ActionResult Index()
        {
            //var info = db.Almacen;
            //ViewBag.almas = info.ToList(); NO NECESITAMOS CARGARLO DE INICIO

            ViewBag.almas = db.Almacen;


            var data = db.Etiqueta;
            return View(data);
        }
    }
}