using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiendaMVC.Filtros
{
    public class FiltroTime : ActionFilterAttribute // lo aplicamos solo sobre el controlador de la etiqueta
    {


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            int minutoactual = 0;
            minutoactual = DateTime.Now.Minute;

            if (minutoactual < 15 || minutoactual > 45)
            {

                filterContext.Result = new HttpUnauthorizedResult("No puedes pasar !!");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}