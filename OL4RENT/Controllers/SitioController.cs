using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ol4RentAPI.Model;
using Ol4RentAPI.Facades;

namespace OL4RENT.Controllers
{
    public class SitioController : Controller
    {
        //
        // GET: /Sitio/

        public ActionResult Index()
        {
            return View(ServiceFacadeFactory.Instance.SitioFacade.Todos);
        }

        //
        // GET: /Sitio/Details/5

        public ActionResult Details(int id = 0)
        {
            Sitio sitio = ServiceFacadeFactory.Instance.SitioFacade.Obtener(id);
            if (sitio == null)
            {
                return HttpNotFound();
            }
            return View(sitio);
        }

        //
        // GET: /Sitio/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Sitio sitio = ServiceFacadeFactory.Instance.SitioFacade.Obtener(id);
            if (sitio == null)
            {
                return HttpNotFound();
            }
            return View(sitio);
        }

        //
        // POST: /Sitio/Edit/5

        [HttpPost]
        public ActionResult Edit(Sitio sitio)
        {
            if ((sitio = ServiceFacadeFactory.Instance.SitioFacade.Editar(sitio)) != null)
            {
                return RedirectToAction("Index");
            }
            return View(sitio);
        }

        //
        // GET: /Sitio/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Sitio sitio = ServiceFacadeFactory.Instance.SitioFacade.Obtener(id);
            if (sitio == null)
            {
                return HttpNotFound();
            }
            return View(sitio);
        }

        //
        // POST: /Sitio/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceFacadeFactory.Instance.SitioFacade.Eliminar(id);
            return RedirectToAction("Index");
        }

        //
        // GET: /Sitio/Logo

        [HttpGet]
        public FileContentResult Logo()
        {
            // TODO implementar la obtencion del sitio
            int idSitio = 1;
            return new FileContentResult(ServiceFacadeFactory.Instance.SitioFacade.Logo(idSitio), "image/jpeg");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}