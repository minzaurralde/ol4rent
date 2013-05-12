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
        // GET: /Novedad/
        public ActionResult Index()
        {
            return View(ServiceFacadeFactory.Instance.NovedadFacade.Todas);
        }

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

        //
        // GET: /Novedad/List
        public ActionResult NovedadesRSS()
        {

            return View(ServiceFacadeFactory.Instance.NovedadFacade.ListaNovedades());
        }

        //
        // GET: /Novedad/Details/5
        public ActionResult Details(int id = 0)
        {
            Novedad novedad = ServiceFacadeFactory.Instance.NovedadFacade.Obtener(id);
            if (novedad == null)
            {
                return HttpNotFound();
            }
            return View(novedad);
        }

        //
        // GET: /Novedad/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Novedad/Create
        [HttpPost]
        public ActionResult Create(Novedad novedad)
        {
            if ((novedad = ServiceFacadeFactory.Instance.NovedadFacade.Crear(novedad)) != null)
            {
                return RedirectToAction("Index");
            }

            return View(novedad);
        }

        //
        // GET: /Novedad/Edit/5
        public ActionResult Edit(int id = 0)
        {
            Novedad novedad = ServiceFacadeFactory.Instance.NovedadFacade.Obtener(id);
            if (novedad == null)
            {
                return HttpNotFound();
            }
            return View(novedad);
        }

        //
        // POST: /Novedad/Edit/5
        [HttpPost]
        public ActionResult Edit(Novedad novedad)
        {
            if ((novedad = ServiceFacadeFactory.Instance.NovedadFacade.Editar(novedad)) != null)
            {
                return RedirectToAction("Index");
            }
            return View(novedad);
        }

        //
        // GET: /Novedad/Delete/5
        public ActionResult Delete(int id = 0)
        {
            Novedad novedad = ServiceFacadeFactory.Instance.NovedadFacade.Obtener(id);
            if (novedad == null)
            {
                return HttpNotFound();
            }
            return View(novedad);
        }

        //
        // POST: /Novedad/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceFacadeFactory.Instance.NovedadFacade.Eliminar(id);
            return RedirectToAction("Index");
        }

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