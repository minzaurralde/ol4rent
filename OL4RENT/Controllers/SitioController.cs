using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ol4RentAPI.Model;

namespace OL4RENT.Controllers
{
    public class SitioController : Controller
    {
        private ModelContainer db = new ModelContainer();

        //
        // GET: /Sitio/

        public ActionResult Index()
        {
            return View(db.SitioSet1.ToList());
        }

        //
        // GET: /Sitio/Details/5

        public ActionResult Details(long id = 0)
        {
            Sitio sitio = db.SitioSet1.Find(id);
            if (sitio == null)
            {
                return HttpNotFound();
            }
            return View(sitio);
        }

        //
        // GET: /Sitio/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Sitio/Create

        [HttpPost]
        public ActionResult Create(Sitio sitio)
        {
            if (ModelState.IsValid)
            {
                db.SitioSet1.Add(sitio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sitio);
        }

        //
        // GET: /Sitio/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Sitio sitio = db.SitioSet1.Find(id);
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
            if (ModelState.IsValid)
            {
                db.Entry(sitio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sitio);
        }

        //
        // GET: /Sitio/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Sitio sitio = db.SitioSet1.Find(id);
            if (sitio == null)
            {
                return HttpNotFound();
            }
            return View(sitio);
        }

        //
        // POST: /Sitio/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Sitio sitio = db.SitioSet1.Find(id);
            db.SitioSet1.Remove(sitio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Sitio/Logo

        [HttpGet]
        public ActionResult Logo()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}