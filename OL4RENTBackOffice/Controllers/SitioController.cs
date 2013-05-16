using Ol4RentAPI.DTO;
using Ol4RentAPI.Facades;
using Ol4RentAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OL4RENTBackOffice.Controllers
{
    public class SitioController : Controller
    {
        //
        // GET: /Sitio/
        public ActionResult Index()
        {
            return RedirectToAction("Listar", "Sitio");
        }

        //
        // GET: /Sitio/Crear
//        [Authorize(Roles = "SUPER_ADMIN")]
        public ActionResult Crear()
        {
            ArmarComboTipoDatos();
            return View(new SitioAltaDTO() { NombreUsuarioPropietario = User.Identity.Name });
        }

        //
        // POST: /Sitio/Crear
        [HttpPost]
        [ValidateInput(true)]
  //      [Authorize(Roles = "SUPER_ADMIN")]
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
            // TODO validar los formatos de los archivos
            // estilo = Request.Files["estilo"];
            sitio.CSS = new byte[estilo.ContentLength];
            estilo.InputStream.Read(sitio.CSS, 0, estilo.ContentLength);
            // imagen = Request.Files["imagen"];
            sitio.Logo = new byte[imagen.ContentLength];
            imagen.InputStream.Read(sitio.Logo, 0, imagen.ContentLength);
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
        public ActionResult Listar()
        {
            if (User.IsInRole(RolEnum.SUPER_ADMIN.ToString()))
            {
                // return View(ServiceFacadeFactory.Instance.SitioFacade.Todos);
                // TODO Ver que pasa en este caso cuando debo retornar el listado para un superadmin
                return View(ServiceFacadeFactory.Instance.SitioFacade.ObtenerPorUsuario(User.Identity.Name));
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
        public ActionResult Editar(int id)
        {
            ArmarComboTipoDatos();
            SitioEdicionDTO dto = ServiceFacadeFactory.Instance.SitioFacade.ObtenerParaEdicion(id);
            return View(dto);
        }

        //
        // POST: /Sitio/Editar
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
                    sitioDTO.Caracteristicas.Add(new CaracteristicaEdicionDTO() { Nombre = Request["nombre" + i.ToString()], Tipo = (TipoDato)Enum.Parse(typeof(TipoDato), Request["tipo" + i.ToString()]) });
                }
            }
            // TODO validar los formatos de los archivos
            sitioDTO.CSS = new byte[estilo.ContentLength];
            estilo.InputStream.Read(sitioDTO.CSS, 0, estilo.ContentLength);
            sitioDTO.Logo = new byte[imagen.ContentLength];
            imagen.InputStream.Read(sitioDTO.Logo, 0, imagen.ContentLength);
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
        public ActionResult Eliminar(int id)
        {
            return View(ServiceFacadeFactory.Instance.SitioFacade.ObtenerParaEdicion(id));
        }

        //
        // POST: /Sitio/Eliminar
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
            tipos.Add(new SelectListItem() { Selected = false, Text = TipoDato.BOOLEANO.ToString(), Value = TipoDato.BOOLEANO.ToString() });
            tipos.Add(new SelectListItem() { Selected = false, Text = TipoDato.DECIMAL.ToString(), Value = TipoDato.DECIMAL.ToString() });
            tipos.Add(new SelectListItem() { Selected = false, Text = TipoDato.ENTERO.ToString(), Value = TipoDato.ENTERO.ToString() });
            tipos.Add(new SelectListItem() { Selected = false, Text = TipoDato.FECHA.ToString(), Value = TipoDato.FECHA.ToString() });
            tipos.Add(new SelectListItem() { Selected = false, Text = TipoDato.STRING.ToString(), Value = TipoDato.STRING.ToString() });
            ViewBag.TiposDatos = tipos;
        }
    }
}
