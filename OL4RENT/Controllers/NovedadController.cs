using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OL4RENT.Models;
using System.Collections;

namespace OL4RENT.Controllers
{
    public class NovedadController : Controller
    {
        private NovedadContext db = new NovedadContext();

        internal List<Novedad> ListaNovedades
        {
            get
            {
                int maximaCantidadNovedadesHome = 6;
                return db.Novedades.Take(maximaCantidadNovedadesHome).ToList();
            }
        }

        internal List<Novedad> ListaNovedadesRSS
        {            
            get
            {
                Funciones.ManejoRSS mj = new Funciones.ManejoRSS();
                return mj.LecturaRSS("http://blog.orcare.com/rss");
            }
        }  

        //
        // GET: /Novedad/
        public ActionResult Index()
        {
            return View(db.Novedades.ToList());
        }

        //
        // GET: /Novedad/List
        public ActionResult List()
        {
            return View(ListaNovedades);
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

            return View(ListaNovedadesRSS);
        }

        //
        // GET: /Novedad/Details/5
        public ActionResult Details(long id = 0)
        {
            Novedad novedad = db.Novedades.Find(id);
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
            if (ModelState.IsValid)
            {
                db.Novedades.Add(novedad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(novedad);
        }

        //
        // GET: /Novedad/Edit/5
        public ActionResult Edit(long id = 0)
        {
            Novedad novedad = db.Novedades.Find(id);
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
            if (ModelState.IsValid)
            {
                db.Entry(novedad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(novedad);
        }

        //
        // GET: /Novedad/Delete/5
        public ActionResult Delete(long id = 0)
        {
            Novedad novedad = db.Novedades.Find(id);
            if (novedad == null)
            {
                return HttpNotFound();
            }
            return View(novedad);
        }

        //
        // POST: /Novedad/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Novedad novedad = db.Novedades.Find(id);
            db.Novedades.Remove(novedad);
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