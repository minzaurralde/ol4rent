using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ol4RentAPI.Model;
using System.Collections;
using Ol4RentAPI.Facades;

namespace OL4RENT.Controllers
{
    public class NovedadController : Controller
    {
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        //
        // GET: /Novedad/ListarPorSitio
        public ActionResult ListarPorSitio(int idSitio)
        {
            // TODO Implementar
            return View();
        }
    }
}