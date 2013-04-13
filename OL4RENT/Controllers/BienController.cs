using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OL4RENT.Models;

namespace OL4RENT.Controllers
{
    public class BienController : Controller
    {
        private BienContext db = new BienContext();

        internal List<Bien> BienesPopulares
        {
            get
            {
                int maximaCantidadPopulares = 10;
                return db.Bienes.OrderByDescending(bien => bien.CantidadLikes).Take(maximaCantidadPopulares).ToList();
            }
        }

        //
        // GET: /Bien/
        public ActionResult Index()
        {
            return View(db.Bienes.ToList());
        }

        //
        // GET: /Bien/Details/5
        public ActionResult Details(long id = 0)
        {
            Bien bien = db.Bienes.Find(id);
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
        public ActionResult Create(Bien bien)
        {
            if (ModelState.IsValid)
            {
                db.Bienes.Add(bien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bien);
        }

        //
        // GET: /Bien/Edit/5
        public ActionResult Edit(long id = 0)
        {
            Bien bien = db.Bienes.Find(id);
            if (bien == null)
            {
                return HttpNotFound();
            }
            return View(bien);
        }

        //
        // POST: /Bien/Edit/5
        [HttpPost]
        public ActionResult Edit(Bien bien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bien);
        }

        //
        // GET: /Bien/Delete/5
        public ActionResult Delete(long id = 0)
        {
            Bien bien = db.Bienes.Find(id);
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
            return View(BienesPopulares);
        }

        //
        // GET: /Bien/Mapa
        public ActionResult Mapa()
        {
            // TODO Implementar la vista de Mapa
            return View();
        }

        //
        // POST: /Bien/Buscar
        [HttpPost]
        public ActionResult Buscar(string query)
        {
            return View();
        }

        //
        // POST: /Bien/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Bien bien = db.Bienes.Find(id);
            db.Bienes.Remove(bien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}