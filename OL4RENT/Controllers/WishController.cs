﻿using System;
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
    public class WishController : Controller
    {
        private ModelContainer db = new ModelContainer();

        //
        // GET: /Wish/

        public ActionResult Index()
        {
            return View(db.EspecificacionesBienes.ToList());
        }

        //
        // GET: /Wish/Details/5

        public ActionResult Details(int id = 0)
        {
            EspecificacionBien especificacionbien = db.EspecificacionesBienes.Find(id);
            if (especificacionbien == null)
            {
                return HttpNotFound();
            }
            return View(especificacionbien);
        }

        //
        // GET: /Wish/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Wish/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EspecificacionBien especificacionbien)
        {
            if (ModelState.IsValid)
            {
                db.EspecificacionesBienes.Add(especificacionbien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(especificacionbien);
        }

        //
        // GET: /Wish/Edit/5

        public ActionResult Edit(int id = 0)
        {
            EspecificacionBien especificacionbien = db.EspecificacionesBienes.Find(id);
            if (especificacionbien == null)
            {
                return HttpNotFound();
            }
            return View(especificacionbien);
        }

        //
        // POST: /Wish/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EspecificacionBien especificacionbien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especificacionbien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(especificacionbien);
        }

        //
        // GET: /Wish/Delete/5

        public ActionResult Delete(int id = 0)
        {
            EspecificacionBien especificacionbien = db.EspecificacionesBienes.Find(id);
            if (especificacionbien == null)
            {
                return HttpNotFound();
            }
            return View(especificacionbien);
        }

        //
        // POST: /Wish/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EspecificacionBien especificacionbien = db.EspecificacionesBienes.Find(id);
            db.EspecificacionesBienes.Remove(especificacionbien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Wishlist()
        {
            // TODO Implementar
            //return View(ServiceFacadeFactory.Instance.EspecificacionBienFacade.Wishlist(User.Identity,);
            return View(new List<EspecificacionBienListadoDTO>());
        }
    }
}