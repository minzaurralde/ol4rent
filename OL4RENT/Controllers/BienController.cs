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
            return View(ServiceFacadeFactory.Instance.BienFacade.Todos());
        }

        //
        // GET: /Bien/Details/5
        public ActionResult Details(int id = 0)
        {
            BienEdicionDTO bien = ServiceFacadeFactory.Instance.BienFacade.Obtener(id);
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
            if (Session["sitio"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ArmarListadoCaracteristicas();
                return View(new BienAltaDTO());
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
        // POST: /Bien/Create
        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Create(BienAltaDTO bienDTO, HttpPostedFileBase imagen)
        {
            if (bienDTO.ValoresCaracteristicas == null)
            {
                bienDTO.ValoresCaracteristicas = new List<ValorCaracteristicaAltaDTO>();
            }
            List<CaracteristicaEdicionDTO> caracteristicas = ObtenerListadoCaracteristicas();
            foreach (CaracteristicaEdicionDTO caracteristica in caracteristicas)
            {
                string id = "car-" + caracteristica.Id.ToString();
                if (Request[id] == null)
                {
                    if (caracteristica.Tipo == TipoDato.BOOLEANO)
                    {
                        bienDTO.ValoresCaracteristicas.Add(new ValorCaracteristicaAltaDTO() { Valor = "false", IdCaracteristica = caracteristica.Id });
                    }
                    else
                    {
                        bienDTO.ValoresCaracteristicas.Add(new ValorCaracteristicaAltaDTO() { Valor = "", IdCaracteristica = caracteristica.Id });
                    }
                }
                else
                {
                    if (caracteristica.Tipo == TipoDato.BOOLEANO)
                    {
                        bool boolean = Request[id].ToString() != "false";
                        bienDTO.ValoresCaracteristicas.Add(new ValorCaracteristicaAltaDTO() { Valor = boolean.ToString(), IdCaracteristica = caracteristica.Id });
                    }
                    else
                    {
                        bienDTO.ValoresCaracteristicas.Add(new ValorCaracteristicaAltaDTO() { Valor = Request[id], IdCaracteristica = caracteristica.Id });
                    }
                }
            }
            if (imagen != null)
            {
                bienDTO.Foto = new byte[imagen.ContentLength];
                imagen.InputStream.Read(bienDTO.Foto, 0, imagen.ContentLength);
            }
            bienDTO.Usuario = User.Identity.Name;
            SitioListadoDTO sitio = Session["sitio"] as SitioListadoDTO;
            bienDTO.TipoBien = ServiceFacadeFactory.Instance.SitioFacade.ObtenerIdTipoBien(sitio.Id);
            if (sitio !=null && ModelState.IsValid)
            {
                if (ServiceFacadeFactory.Instance.BienFacade.Crear(bienDTO))
                {
                    return RedirectToAction("MisBienes", "Bien");
                }
            }
            ArmarListadoCaracteristicas();
            return View(bienDTO);
        }

        //
        // GET: /Bien/Edit/5
        [Authorize(Roles = "ADMIN")]
        public ActionResult Edit(int id = 0)
        {
            BienEdicionDTO bien = ServiceFacadeFactory.Instance.BienFacade.Obtener(id);
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
        public ActionResult Edit(BienEdicionDTO bien)
        {
            if (ServiceFacadeFactory.Instance.BienFacade.Editar(bien))
            {
                return RedirectToAction("Index");
            }
            return View(bien);
        }

        //
        // GET: /Bien/Delete/5
        public ActionResult Delete(int id = 0)
        {
            BienEdicionDTO bien = ServiceFacadeFactory.Instance.BienFacade.Obtener(id);
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
            return View(ServiceFacadeFactory.Instance.BienFacade.BienesPopulares());
        }


        //
        // GET: /Bien/Mapa
        public ActionResult Mapa()
        {
            // TODO Implementar la vista de Mapa
            return View(ServiceFacadeFactory.Instance.BienFacade.BienesPopulares());
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
            ArmarListadoCaracteristicas();
            return View(new BusquedaAvanzadaDTO());
        }

        //
        // POST: /Bien/BusquedaAvanzada/5
        [HttpPost]
        public ActionResult BusquedaAvanzada(BusquedaAvanzadaDTO bienDTO)
        {
            if (bienDTO.ValoresCaracteristicas == null)
            {
                bienDTO.ValoresCaracteristicas = new List<ValorCaracteristicaAltaDTO>();
            }
            List<CaracteristicaEdicionDTO> caracteristicas = ObtenerListadoCaracteristicas();
            foreach (CaracteristicaEdicionDTO caracteristica in caracteristicas)
            {
                string id = "car-" + caracteristica.Id.ToString();
                if (Request[id] == null)
                {
                    if (caracteristica.Tipo == TipoDato.BOOLEANO)
                    {
                        bienDTO.ValoresCaracteristicas.Add(new ValorCaracteristicaAltaDTO() { Valor = "false", IdCaracteristica = caracteristica.Id });
                    }
                    else
                    {
                        bienDTO.ValoresCaracteristicas.Add(new ValorCaracteristicaAltaDTO() { Valor = "", IdCaracteristica = caracteristica.Id });
                    }
                }
                else
                {
                    if (caracteristica.Tipo == TipoDato.BOOLEANO)
                    {
                        bool boolean = Request[id].ToString() != "false";
                        bienDTO.ValoresCaracteristicas.Add(new ValorCaracteristicaAltaDTO() { Valor = boolean.ToString(), IdCaracteristica = caracteristica.Id });
                    }
                    else
                    {
                        bienDTO.ValoresCaracteristicas.Add(new ValorCaracteristicaAltaDTO() { Valor = Request[id], IdCaracteristica = caracteristica.Id });
                    }
                }
            }
            return View("Buscar", ServiceFacadeFactory.Instance.BienFacade.BusquedaAvanzada(bienDTO));
        }

        //
        // POST: /Bien/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceFacadeFactory.Instance.BienFacade.Eliminar(id);
            return RedirectToAction("Index");
        }

        public ActionResult MisBienes()
        {
            // Verificar
            if (Session["sitio"] != null)
            {
                SitioListadoDTO sitio = Session["sitio"] as SitioListadoDTO;
                List<BienListadoDTO> bienes = ServiceFacadeFactory.Instance.BienFacade.MisBienes(User.Identity.Name, sitio.Id);
                return View(bienes);
            }
            else
            {
                return View(new List<BienListadoDTO>());
            }
        }

        [HttpGet]
        public RedirectResult Like(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ServiceFacadeFactory.Instance.BienFacade.Like(User.Identity.Name, id);
            }
            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        [HttpPost]
        [ActionName("Like")]
        public JsonResult LikePost(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ServiceFacadeFactory.Instance.BienFacade.Like(User.Identity.Name, id);
            }
            return new JsonResult() { Data = "ok" , JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        //
        // GET: /Bien/Foto
        [HttpGet]
        public FileContentResult Foto(int idBien)
        {
            byte[] bytes = ServiceFacadeFactory.Instance.BienFacade.Foto(idBien);
            if (bytes != null)
            {
                return new FileContentResult(ServiceFacadeFactory.Instance.BienFacade.Foto(idBien), "image/jpeg");
            }
            return null;
        }
    }
}