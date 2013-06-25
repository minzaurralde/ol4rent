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
using System.Collections;
using System.Web.UI.WebControls;
using System.IO;

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
            ChequearSiLePuedeGustar(id);
            return View(bien);
        }

        //
        // GET: /Bien/Create
        public ActionResult Create()
        {
            if (Session["sitio"] == null)
            {
                ViewBag.Click = false;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Click = false;
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
        public ActionResult Create(BienAltaDTO bienDTO, HttpPostedFileBase imagen, bool click)
        {
            ViewBag.Click = click;
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
                if (Path.GetExtension(imagen.FileName).ToLower().EndsWith("jpg"))
                {
                    bienDTO.Foto = new byte[imagen.ContentLength];
                    imagen.InputStream.Read(bienDTO.Foto, 0, imagen.ContentLength);
                }
                else
                {
                    ModelState.AddModelError("imagen", "La extensión de la imagen debe ser .jpg");
                }
            }
            bienDTO.Usuario = User.Identity.Name;
            SitioListadoDTO sitio = Session["sitio"] as SitioListadoDTO;
            bienDTO.TipoBien = ServiceFacadeFactory.Instance.SitioFacade.ObtenerIdTipoBien(sitio.Id);
            if (ViewBag.Click)
            {
                if (sitio != null && ModelState.IsValid && ViewBag.Click)
                {
                    if (ServiceFacadeFactory.Instance.BienFacade.Crear(bienDTO))
                    {
                        return RedirectToAction("MisBienes", "Bien");
                    }
                }
                ArmarListadoCaracteristicas();
                return View(bienDTO);
            }
            else
            {
                ModelState.AddModelError("click", "Debe seleccionar un punto del mapa o ingresar una dirección");
                ArmarListadoCaracteristicas();
                return View(bienDTO);
            }
        }

        //
        // GET: /Bien/Edit/5
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
        [HttpPost]
        public ActionResult Edit(BienEdicionDTO bienDTO, HttpPostedFileBase imagen)
        {
            if (bienDTO.ValoresCaracteristicas == null)
            {
                bienDTO.ValoresCaracteristicas = new List<ValorCaracteristicaListadoDTO>();
            }
            List<CaracteristicaEdicionDTO> caracteristicas = ObtenerListadoCaracteristicas();
            foreach (CaracteristicaEdicionDTO caracteristica in caracteristicas)
            {
                string id = "car-" + caracteristica.Id.ToString();
                int idValor;
                try
                {
                    idValor = Convert.ToInt32(Request["itemid-" + caracteristica.Id.ToString()]);
                }
                catch
                {
                    idValor = 0;
                }
                if (Request[id] == null)
                {
                    if (caracteristica.Tipo == TipoDato.BOOLEANO)
                    {
                        bienDTO.ValoresCaracteristicas.Add(new ValorCaracteristicaListadoDTO() { Valor = "false", IdCaracteristica = caracteristica.Id, Caracteristica = caracteristica, Id = idValor });
                    }
                    else
                    {
                        bienDTO.ValoresCaracteristicas.Add(new ValorCaracteristicaListadoDTO() { Valor = "", IdCaracteristica = caracteristica.Id, Caracteristica = caracteristica, Id = idValor });
                    }
                }
                else
                {
                    if (caracteristica.Tipo == TipoDato.BOOLEANO)
                    {
                        bool boolean = Request[id].ToString() != "false";
                        bienDTO.ValoresCaracteristicas.Add(new ValorCaracteristicaListadoDTO() { Valor = boolean.ToString(), IdCaracteristica = caracteristica.Id, Caracteristica = caracteristica, Id = idValor });
                    }
                    else
                    {
                        bienDTO.ValoresCaracteristicas.Add(new ValorCaracteristicaListadoDTO() { Valor = Request[id], IdCaracteristica = caracteristica.Id, Caracteristica = caracteristica, Id = idValor });
                    }
                }
            }
            if (imagen != null)
            {
                if (Path.GetExtension(imagen.FileName).ToLower().EndsWith("jpg"))
                {
                    bienDTO.Foto = new byte[imagen.ContentLength];
                    imagen.InputStream.Read(bienDTO.Foto, 0, imagen.ContentLength);
                }
                else
                {
                    ModelState.AddModelError("Foto", "La extensión de la imagen debe ser .jpg");
                }
            }
            if (ModelState.IsValid)
            {
                if (ServiceFacadeFactory.Instance.BienFacade.Editar(bienDTO))
                {
                    return RedirectToAction("MisBienes");
                }
            }
            ArmarListadoCaracteristicas();
            return View(bienDTO);
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
            return View(ServiceFacadeFactory.Instance.BienFacade.BienesPopulares());
        }

        //
        // POST: /Bien/Buscar
        [HttpPost]
        public ActionResult Buscar(string query)
        {
            List<BienListadoDTO> bienes = ServiceFacadeFactory.Instance.BienFacade.Buscar(query);
            return View(bienes);
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
            List<BienListadoDTO> bienes = ServiceFacadeFactory.Instance.BienFacade.BusquedaAvanzada(bienDTO);
            return View("Buscar", bienes);
        }

        //
        // POST: /Bien/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceFacadeFactory.Instance.BienFacade.Eliminar(id);
            return RedirectToAction("MisBienes");
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

        public ActionResult Arrendar(int id)
        {
            BienArrendarDTO bien = ServiceFacadeFactory.Instance.BienFacade.ObtenerArrendar(id);
            if (bien == null)
            {
                return HttpNotFound();
            }
            return View(bien);
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Arrendar(BienArrendarDTO bienDTO)
        {
            if (bienDTO.FechaAlquiler < DateTime.Today || bienDTO.FechaAlquiler > DateTime.MaxValue)
            {
                ModelState.AddModelError("FechaAlquiler", "Debe ingresar una fecha mayo o igual a hoy");
                return View(bienDTO);
            }
            else
            {
                if (ServiceFacadeFactory.Instance.BienFacade.Arrendar(bienDTO, User.Identity.Name))
                {
                    return RedirectToAction("PagoArriendo", bienDTO);
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
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

        public ActionResult PagoArriendo(BienArrendarDTO bienDTO)
        {
            return View(bienDTO);
        }
        [HttpPost]
        [ActionName("Like")]
        public JsonResult LikePost(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ServiceFacadeFactory.Instance.BienFacade.Like(User.Identity.Name, id);
            }

            return new JsonResult() { Data = "ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult ConfirmaPago()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        //
        // GET: /Bien/Foto
        [HttpGet]
        public ActionResult Foto(int idBien)
        {
            byte[] bytes = ServiceFacadeFactory.Instance.BienFacade.Foto(idBien);
            if (bytes != null)
            {
                return new FileContentResult(bytes, "image/jpeg");
            }
            else
            {
                return new FilePathResult("~/Images/sinfoto.png", "image/png");
            }
        }

        //
        // GET: /Bien/Comentarios/5
        public ActionResult Comentarios(int id)
        {
            ViewBag.IdBien = id;
            return PartialView(ServiceFacadeFactory.Instance.BienFacade.ObtenerComentariosBien(id));
        }

        [HttpPost]
        public RedirectResult AgregarComentario(int idBien, string texto, List<HttpPostedFileBase> adjuntos)
        {
            ComentarioAltaDTO dto = new ComentarioAltaDTO() { IdBien = idBien, Texto = texto, NombreUsuario = User.Identity.Name, Adjuntos = new List<AdjuntoDTO>() };
            if (adjuntos != null)
            {
                foreach (HttpPostedFileBase postedFile in adjuntos)
                {
                    if (postedFile != null)
                    {
                        byte[] buffer = new byte[postedFile.ContentLength];
                        postedFile.InputStream.Read(buffer, 0, postedFile.ContentLength);
                        dto.Adjuntos.Add(new AdjuntoDTO() { Nombre = postedFile.FileName, Contenido = buffer });
                    }
                }
            }
            ServiceFacadeFactory.Instance.ContenidoFacade.Agregar(dto);
            return new RedirectResult(Request.UrlReferrer.AbsoluteUri);
        }

        [HttpGet]
        public RedirectResult Inadecuado(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ServiceFacadeFactory.Instance.ContenidoFacade.MarcarInadecuado(id);
            }
            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        [HttpPost]
        [ActionName("Inadecuado")]
        public JsonResult InadecuadoPost(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ServiceFacadeFactory.Instance.ContenidoFacade.MarcarInadecuado(id);
            }
            return new JsonResult() { Data = "ok", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        private void ChequearSiLePuedeGustar(int idBien)
        {
            ViewBag.MostrarMeGusta = VerificarSiMuestroMeGusta(idBien);
        }

        private bool VerificarSiMuestroMeGusta(int idBien)
        {
            return User.Identity.IsAuthenticated && ServiceFacadeFactory.Instance.BienFacade.PuedeMostrarMeGusta(idBien);
        }

        // GET: /Bien/AdjuntoImagen
        [HttpGet]
        public ActionResult AdjuntoImagen(int idContenido, int nroAdjunto)
        {
            List<AdjuntoDTO> adjuntos = ServiceFacadeFactory.Instance.BienFacade.ObtenerAdjuntos(idContenido);
            AdjuntoDTO adj = adjuntos[nroAdjunto];
            if (adj != null)
            {
                byte[] bytes = adj.Contenido;
                if (bytes != null)
                {
                    return new FileContentResult(bytes, "image/jpeg");
                }
            }
            return null;
        }

        // GET: /Bien/AdjuntoImagen
        [HttpGet]
        public ActionResult AdjuntoURI(int idContenido, int nroAdjunto)
        {
            List<AdjuntoDTO> adjuntos = ServiceFacadeFactory.Instance.BienFacade.ObtenerAdjuntos(idContenido);
            AdjuntoDTO adj = adjuntos[nroAdjunto];
            if (adj != null)
            {
                String path = "Upload/" + (adj.Tipo == TipoAdjunto.IMAGEN ? "Image" : "Video/swf") + "/" + adj.Nombre;

                return Content(path);
            }
            return null;
        }

    }
}