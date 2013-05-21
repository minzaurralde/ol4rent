using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OL4RENTBackOffice.Controllers
{
    public class ReporteController : Controller
    {
        //
        // GET: /Reporte/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContenidosInadecuadosPorSitio()
        {
            return View();
        }

        public ActionResult RegistroDeBienesEnTiempo()
        {
            return View();
        }
    }
}
