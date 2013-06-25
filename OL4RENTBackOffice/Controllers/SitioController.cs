using Ol4RentAPI.DTO;
using Ol4RentAPI.Facades;
using Ol4RentAPI.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OL4RENTBackOffice.Controllers
{
    public class SitioController : Controller
    {
        //
        // GET: /Sitio/
        [Authorize(Roles = "SUPER_ADMIN,SITE_ADMIN")]
        public ActionResult Index()
        {
            return RedirectToAction("Listar", "Sitio");
        }

        //
        // GET: /Sitio/Crear
        [Authorize(Roles = "SUPER_ADMIN,SITE_ADMIN")]
        public ActionResult Crear()
        {
            ArmarComboTipoDatos();
            return View(new SitioAltaDTO() { NombreUsuarioPropietario = User.Identity.Name });
        }

        //
        // POST: /Sitio/Crear
        [HttpPost]
        [ValidateInput(true)]
        [Authorize(Roles = "SUPER_ADMIN,SITE_ADMIN")]
        public ActionResult Crear(int maxid, SitioAltaDTO sitio, HttpPostedFileBase imagen, HttpPostedFileBase estilo)
        {
            if (sitio.Caracteristicas == null)
            {
                sitio.Caracteristicas = new List<CaracteristicaAltaDTO>();
            }
            for (int i = 0; i < maxid; i++)
            {
                if (Request["nombre" + i.ToString()] != null)
                {
                    sitio.Caracteristicas.Add(new CaracteristicaAltaDTO() { Nombre = Request["nombre" + i.ToString()], Tipo = (TipoDato)Enum.Parse(typeof(TipoDato), Request["tipo" + i.ToString()]) });
                }
            }
            if (sitio.Caracteristicas.Count < 1)
            {
                ModelState.AddModelError("caracteristicas", "Debe ingresar al menos una caracteristica para el bien.");
            }
            // estilo = Request.Files["estilo"];
            if (estilo == null)
            {
                sitio.CSS = null;
            }
            else
            {
                if (Path.GetExtension(estilo.FileName).ToLower().EndsWith("css"))
                {
                    sitio.CSS = new byte[estilo.ContentLength];
                    estilo.InputStream.Read(sitio.CSS, 0, estilo.ContentLength);
                }
                else
                {
                    ModelState.AddModelError("estilo", "La extensión del CSS debe ser .css");
                }
            }
            // imagen = Request.Files["imagen"];
            if (imagen == null)
            {
                sitio.Logo = null;
            }
            else
            {
                if (Path.GetExtension(imagen.FileName).ToLower().EndsWith("jpg") || Path.GetExtension(imagen.FileName).ToLower().EndsWith("gif") || Path.GetExtension(imagen.FileName).ToLower().EndsWith("png"))
                {
                    sitio.Logo = new byte[imagen.ContentLength];
                    imagen.InputStream.Read(sitio.Logo, 0, imagen.ContentLength);
                }
                else
                {
                    ModelState.AddModelError("imagen", "La extensión del logo debe ser .jpg, .gif o .png");
                }
            }
            if (ModelState.IsValid)
            {
                if (ServiceFacadeFactory.Instance.SitioFacade.Crear(sitio))
                {
                    return RedirectToAction("Listar", "Sitio");
                }
            }
            ArmarComboTipoDatos();
            return View(sitio);
        }

        //
        // GET: /Sitio/Listar
        [Authorize(Roles = "SUPER_ADMIN,SITE_ADMIN")]
        public ActionResult Listar()
        {
            if (User.IsInRole(RolEnum.SUPER_ADMIN.ToString()))
            {
                return View(ServiceFacadeFactory.Instance.SitioFacade.ObtenerTodos());
            }
            else if (User.IsInRole(RolEnum.SITE_ADMIN.ToString()))
            {
                return View(ServiceFacadeFactory.Instance.SitioFacade.ObtenerPorUsuario(User.Identity.Name));
            }
            else
            {
                return View(new List<SitioListadoDTO>());
            }
        }

        //
        // GET: /Sitio/Editar
        [Authorize(Roles = "SUPER_ADMIN,SITE_ADMIN")]
        public ActionResult Editar(int id)
        {
            ArmarComboTipoDatos();
            SitioEdicionDTO dto = ServiceFacadeFactory.Instance.SitioFacade.ObtenerParaEdicion(id);
            return View(dto);
        }

        //
        // POST: /Sitio/Editar
        [Authorize(Roles = "SUPER_ADMIN,SITE_ADMIN")]
        [HttpPost]
        public ActionResult Editar(int maxid, SitioEdicionDTO sitioDTO, HttpPostedFileBase imagen, HttpPostedFileBase estilo)
        {
            if (sitioDTO.Caracteristicas == null)
            {
                sitioDTO.Caracteristicas = new List<CaracteristicaEdicionDTO>();
            }
            for (int i = 0; i < maxid; i++)
            {
                if (Request["nombre" + i.ToString()] != null)
                {
                    int id = -1;
                    int.TryParse(Request["id" + i.ToString()], out id);
                    sitioDTO.Caracteristicas.Add(new CaracteristicaEdicionDTO() { Nombre = Request["nombre" + i.ToString()], Tipo = (TipoDato)Enum.Parse(typeof(TipoDato), Request["tipo" + i.ToString()]), Id = id });
                }
            }
            if (sitioDTO.Caracteristicas.Count < 1)
            {
                ModelState.AddModelError("caracteristicas", "Debe ingresar al menos una caracteristica para el bien.");
            }
            if (estilo != null)
            {
                if (Path.GetExtension(estilo.FileName).ToLower().EndsWith("css"))
                {
                    sitioDTO.CSS = new byte[estilo.ContentLength];
                    estilo.InputStream.Read(sitioDTO.CSS, 0, estilo.ContentLength);
                }
                else
                {
                    ModelState.AddModelError("estilo", "La extensión del CSS debe ser .css");
                }
            }
            if (imagen != null)
            {
                if (Path.GetExtension(imagen.FileName).ToLower().EndsWith("jpg") || Path.GetExtension(imagen.FileName).ToLower().EndsWith("gif") || Path.GetExtension(imagen.FileName).ToLower().EndsWith("png"))
                {
                    sitioDTO.Logo = new byte[imagen.ContentLength];
                    imagen.InputStream.Read(sitioDTO.Logo, 0, imagen.ContentLength);
                }
                else
                {
                    ModelState.AddModelError("imagen", "La extensión del logo debe ser .jpg, .gif o .png");
                }
            }
            if (ModelState.IsValid)
            {
                if (ServiceFacadeFactory.Instance.SitioFacade.Editar(sitioDTO))
                {
                    return RedirectToAction("Listar", "Sitio");
                }
            }
            ArmarComboTipoDatos();
            return View(sitioDTO);
        }

        //
        // GET: /Sitio/Eliminar
        [Authorize(Roles = "SUPER_ADMIN,SITE_ADMIN")]
        public ActionResult Eliminar(int id)
        {
            return View(ServiceFacadeFactory.Instance.SitioFacade.ObtenerParaEdicion(id));
        }

        //
        // POST: /Sitio/Eliminar
        [Authorize(Roles = "SUPER_ADMIN,SITE_ADMIN")]
        [HttpPost]
        [ActionName("Eliminar")]
        public ActionResult EliminarConfirm(int id)
        {
            ServiceFacadeFactory.Instance.SitioFacade.Eliminar(id);
            return RedirectToAction("Listar", "Sitio");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        private void ArmarComboTipoDatos()
        {
            List<SelectListItem> tipos = new List<SelectListItem>();
            tipos.Add(new SelectListItem() { Selected = false, Text = TipoDato.STRING.ToString(), Value = TipoDato.STRING.ToString() });
            tipos.Add(new SelectListItem() { Selected = false, Text = TipoDato.BOOLEANO.ToString(), Value = TipoDato.BOOLEANO.ToString() });
            tipos.Add(new SelectListItem() { Selected = false, Text = TipoDato.ENTERO.ToString(), Value = TipoDato.ENTERO.ToString() });
            tipos.Add(new SelectListItem() { Selected = false, Text = TipoDato.DECIMAL.ToString(), Value = TipoDato.DECIMAL.ToString() });
            tipos.Add(new SelectListItem() { Selected = false, Text = TipoDato.FECHA.ToString(), Value = TipoDato.FECHA.ToString() });
            tipos.Add(new SelectListItem() { Selected = false, Text = TipoDato.HORA.ToString(), Value = TipoDato.HORA.ToString() });
            ViewBag.TiposDatos = tipos;
        }
    }
}
