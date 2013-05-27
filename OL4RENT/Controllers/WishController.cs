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
            EspecificacionBienDTO especificacionbien = ServiceFacadeFactory.Instance.EspecificacionBienFacade.Obtener(id);
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
             if (Session["sitio"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ArmarListadoCaracteristicas();
                return View(new EspecificacionBienAltaDTO());
            }            
        }

        private List<CaracteristicaEdicionDTO> ObtenerListadoCaracteristicas()
        {
            if (Session["sitio"] != null)
            {
                SitioListadoDTO sitio = Session["sitio"] as SitioListadoDTO;
                List<CaracteristicaEdicionDTO> caracteristicas = ServiceFacadeFactory.Instance.SitioFacade.ObtenerCaracteristicasParaEdicion(sitio.Id);
                return caracteristicas;
            }
            else
            {
                return new List<CaracteristicaEdicionDTO>();
            }
        }

        private void ArmarListadoCaracteristicas()
        {
            List<CaracteristicaEdicionDTO> caracteristicas = ObtenerListadoCaracteristicas();
            ViewBag.Caracteristicas = caracteristicas;
        }

        //
        // POST: /Wish/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EspecificacionBienAltaDTO wishDTO)
        {
            if (wishDTO.ValoresCaracteristicas == null)
            {
                wishDTO.ValoresCaracteristicas = new List<ValorCaracteristicaListadoDTO>();
            }
            List<CaracteristicaEdicionDTO> caracteristicas = ObtenerListadoCaracteristicas();
            foreach (CaracteristicaEdicionDTO caracteristica in caracteristicas)
            {
                string id = "car-" + caracteristica.Id.ToString();
                if (Request[id] == null)
                {
                    if (caracteristica.Tipo == TipoDato.BOOLEANO)
                    {
                        wishDTO.ValoresCaracteristicas.Add(new ValorCaracteristicaListadoDTO() { Valor = "false", IdCaracteristica = caracteristica.Id });
                    }
                    else
                    {
                        wishDTO.ValoresCaracteristicas.Add(new ValorCaracteristicaListadoDTO() { Valor = "", IdCaracteristica = caracteristica.Id });
                    }
                }
                else
                {
                    if (caracteristica.Tipo == TipoDato.BOOLEANO)
                    {
                        wishDTO.ValoresCaracteristicas.Add(new ValorCaracteristicaListadoDTO() { Valor = "true", IdCaracteristica = caracteristica.Id });
                    }
                    else
                    {
                        wishDTO.ValoresCaracteristicas.Add(new ValorCaracteristicaListadoDTO() { Valor = Request[id], IdCaracteristica = caracteristica.Id });
                    }
                }
            }
            wishDTO.Usuario = User.Identity.Name;
            SitioListadoDTO sitio = Session["sitio"] as SitioListadoDTO;
            wishDTO.TipoBien = ServiceFacadeFactory.Instance.SitioFacade.ObtenerIdTipoBien(sitio.Id);
            if ((ServiceFacadeFactory.Instance.EspecificacionBienFacade.Crear(wishDTO)))
            {
                return RedirectToAction("Index");
            }
            ArmarListadoCaracteristicas();
            return View(wishDTO);
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

        //
        // POST: /Wish/Wishlist
        public ActionResult Wishlist()
        {
            // Verificar
            if (Session["sitio"] != null)
            {
                SitioListadoDTO sitio = Session["sitio"] as SitioListadoDTO;
                List<EspecificacionBienListadoDTO> wishlist = ServiceFacadeFactory.Instance.EspecificacionBienFacade.Wishlist(User.Identity.Name, sitio.Id);
                return View(wishlist);
            }
            else
            {
                return View(new List<EspecificacionBienListadoDTO>());
            }
        }

        //
        // GET: /Bien/Mapa
        public ActionResult Mapa()
        {
            return View();
        }
    }
}