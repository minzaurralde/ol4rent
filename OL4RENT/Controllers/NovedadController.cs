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
        //
        // GET: /Novedad/List
        public ActionResult List()
        {
            return View(ServiceFacadeFactory.Instance.NovedadFacade.ListaNovedades());
        }

        //
        // GET: /Novedad/List
        public ActionResult NovedadesTwitter()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}