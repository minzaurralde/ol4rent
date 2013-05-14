using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ol4RentAPI.Model;
using Ol4RentAPI.Facades;
using Ol4RentAPI.DTO;

namespace OL4RENT.Controllers
{
    public class BienController : Controller
    {
        //
        // GET: /Bien/
        public ActionResult Index()
        {
            return View(ServiceFacadeFactory.Instance.BienFacade.Todos);
        }

        //
        // GET: /Bien/Details/5
        public ActionResult Details(int id = 0)
        {
            Bien bien = ServiceFacadeFactory.Instance.BienFacade.Obtener(id);
            if (bien == null)
            {
                return HttpNotFound();
            }
            return View(bien);
        }

        //
        // GET: /Bien/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Bien/Create
        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Create(BienAltaDTO bienDTO)
        {
            Bien bien;
            if ((bien = ServiceFacadeFactory.Instance.BienFacade.Crear(bienDTO)) != null)
            {
                return RedirectToAction("Index");
            }
            return View(bien);
        }

        //
        // GET: /Bien/Edit/5
        [Authorize(Roles = "ADMIN")]
        public ActionResult Edit(int id = 0)
        {
            Bien bien = ServiceFacadeFactory.Instance.BienFacade.Obtener(id);
            if (bien == null)
            {
                return HttpNotFound();
            }
            return View(bien);
        }

        //
        // POST: /Bien/Edit/5
        [Authorize(Roles="ADMIN")]
        [HttpPost]
        public ActionResult Edit(Bien bien)
        {
            if ((bien = ServiceFacadeFactory.Instance.BienFacade.Editar(bien)) != null)
            {
                return RedirectToAction("Index");
            }
            return View(bien);
        }

        //
        // GET: /Bien/Delete/5
        public ActionResult Delete(int id = 0)
        {
            Bien bien = ServiceFacadeFactory.Instance.BienFacade.Obtener(id);
            if (bien == null)
            {
                return HttpNotFound();
            }
            return View(bien);
        }

        //
        // GET: /Bien/Populares
        public ActionResult Populares()
        {
            // TODO Mandar a Configuracion este valor
            return View(ServiceFacadeFactory.Instance.BienFacade.BienesPopulares);
        }


        //
        // GET: /Bien/Mapa
        public ActionResult Mapa()
        {
            // TODO Implementar la vista de Mapa
            return View(ServiceFacadeFactory.Instance.BienFacade.BienesPopulares);
        }

        //
        // POST: /Bien/Buscar
        [HttpPost]
        public ActionResult Buscar(string query)
        {
            return View(ServiceFacadeFactory.Instance.BienFacade.Buscar(query));
        }

        //
        // GET: /Bien/BusquedaAvanzada
        public ActionResult BusquedaAvanzada()
        {
            return View(new Bien());
        }

        //
        // POST: /Bien/BusquedaAvanzada/5
        [HttpPost]
        public ActionResult BusquedaAvanzada(Bien templateBien)
        {
            return View("Buscar", ServiceFacadeFactory.Instance.BienFacade.BusquedaAvanzada(templateBien));
        }

        //
        // POST: /Bien/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceFacadeFactory.Instance.BienFacade.Eliminar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Wishlist()
        {
            // TODO Implementar
            return View(ServiceFacadeFactory.Instance.BienFacade.BienesPopulares);
        }

        public ActionResult MisBienes()
        {
            // TODO Implementar
            return View(ServiceFacadeFactory.Instance.BienFacade.BienesPopulares);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}