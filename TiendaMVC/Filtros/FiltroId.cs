using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TiendaMVC.Filtros
{
   public class FiltroId:ActionFilterAttribute // Hereda de ActionFilterAttribute para aplicarlo con sintaxis de atributo.
    {
        public override void OnActionExecuting
    (ActionExecutingContext filterContext)
        {

            String id = null;
            try
            {
                id = filterContext.ActionParameters["id"].ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            var pet = filterContext.ActionDescriptor.ActionName;

            if (id == null && pet != "Index")
            {
                filterContext.Result =
                    new RedirectResult(
                        "http://4.bp.blogspot.com/_kfs6enXtGqg/SnG8aSXPugI/AAAAAAAAC3U/iSVtRmsMJm4/s400/1.jpg");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
