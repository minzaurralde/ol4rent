using Ol4RentAPI.DTO;
using Ol4RentAPI.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OL4RENTBackOffice.Controllers
{
    public class OrigenDatosController : Controller
    {
        //
        // GET: /OrigenDatos/Listar/5
        public ActionResult ListarPorSitio(int idSitio)
        {
            ViewBag.IdSitio = idSitio;
            List<OrigenDatosListaDTO> origenesDatos = ServiceFacadeFactory.Instance.OrigenDatosFacade.ObtenerPorSitio(idSitio);
            return View(origenesDatos);
        }

        //
        // GET: /OrigenDatos/Listar
        public ActionResult Listar()
        {
            List<OrigenDatosListaDTO> origenesDatos = ServiceFacadeFactory.Instance.OrigenDatosFacade.ObtenerTodos();
            return View(origenesDatos);
        }

        //
        // GET: /OrigenDatos/Crear
        public ActionResult Crear()
        {
            return View(new OrigenDatosAltaDTO());
        }

        //
        // POST: /OrigenDatos/Crear
        [HttpPost]
        public ActionResult Crear(int maxid, OrigenDatosAltaDTO dto, HttpPostedFileBase dll)
        {
            if (dto.Atributos == null)
            {
                dto.Atributos = new List<AtributoAltaDTO>();
            }
            for (int i = 0; i < maxid; i++)
            {
                if (Request["nombre" + i.ToString()] != null)
                {
                    dto.Atributos.Add(new AtributoAltaDTO() { Nombre = Request["nombre" + i.ToString()] });
                }
            }
            dto.Manejador = new byte[dll.ContentLength];
            dll.InputStream.Read(dto.Manejador, 0, dll.ContentLength);
            if (ModelState.IsValid)
            {
                if (ServiceFacadeFactory.Instance.OrigenDatosFacade.Crear(dto))
                {
                    return RedirectToAction("Listar", "OrigenDatos");
                }
            }
            return View(dto);
        }

        //
        // GET: /OrigenDatos/Editar
        public ActionResult Editar(int id)
        {
            OrigenDatosEdicionDTO dto = ServiceFacadeFactory.Instance.OrigenDatosFacade.ObtenerParaEdicion(id);
            return View(dto);
        }

        //
        // POST: /OrigenDatos/Crear
        [HttpPost]
        public ActionResult Editar(int maxid, OrigenDatosEdicionDTO dto, HttpPostedFileBase dll)
        {
            if (dto.Atributos == null)
            {
                dto.Atributos = new List<AtributoEdicionDTO>();
            }
            for (int i = 0; i < maxid; i++)
            {
                if (Request["nombre" + i.ToString()] != null)
                {
                    dto.Atributos.Add(new AtributoEdicionDTO() { Nombre = Request["nombre" + i.ToString()], Id = int.Parse(Request["id" + i.ToString()]) });
                }
            }
            if (dll != null)
            {
                dto.Manejador = new byte[dll.ContentLength];
                dll.InputStream.Read(dto.Manejador, 0, dll.ContentLength);
            }
            if (ModelState.IsValid)
            {
                if (ServiceFacadeFactory.Instance.OrigenDatosFacade.Editar(dto))
                {
                    return RedirectToAction("Listar", "OrigenDatos");
                }
            }
            return View(dto);
        }

        //
        // GET: /OrigenDatos/Eliminar
        public ActionResult Eliminar(int id)
        {
            ServiceFacadeFactory.Instance.OrigenDatosFacade.Eliminar(id);
            return RedirectToAction("Listar", "OrigenDatos");
        }

        //
        // POST: /OrigenDatos/Eliminar
        [HttpPost]
        [ActionName("Eliminar")]
        public ActionResult EliminarConfirm(int id)
        {
            ServiceFacadeFactory.Instance.OrigenDatosFacade.Eliminar(id);
            return RedirectToAction("Listar", "OrigenDatos");
        }

        //
        // GET: /OrigenDatos/Configurar
        public ActionResult Configurar(int idSitio)
        {
            ViewBag.Sitio = ServiceFacadeFactory.Instance.SitioFacade.Obtener(idSitio);
            ArmarComboOrigenesDatos();
            return View(new ConfiguracionOrigenDatosAltaDTO());
        }

        private void ArmarComboOrigenesDatos()
        {
            List<OrigenDatosListaDTO> origenesDatos = ServiceFacadeFactory.Instance.OrigenDatosFacade.ObtenerTodos();
            List<SelectListItem> items = new List<SelectListItem>();
            bool primero = true;
            foreach (OrigenDatosListaDTO od in origenesDatos)
            {
                items.Add(new SelectListItem() { Selected = primero, Text = od.Nombre, Value = od.Id.ToString() });
                if (primero)
                {
                    ArmarComboAtributos(od.Id);
                    primero = false;
                }
            }
            ViewBag.OrigenesDatos = items;            
        }

        //
        // POST: /OrigenDatos/Configurar
        [HttpPost]
        public ActionResult Configurar(int maxid, ConfiguracionOrigenDatosAltaDTO dto)
        {
            if (dto.ValoresAtributo == null)
            {
                dto.ValoresAtributo = new List<ValorAtributoAltaDTO>();
            }
            for (int i = 0; i < maxid; i++)
            {
                if (Request["nombre" + i.ToString()] != null)
                {
                    dto.ValoresAtributo.Add(new ValorAtributoAltaDTO() { IdAtributo = int.Parse(Request["id" + i.ToString()]), NombreAtributo = Request["nombre" + i.ToString()], Valor = Request["valor" + i.ToString()] });
                }
            }
            if (ServiceFacadeFactory.Instance.OrigenDatosFacade.Configurar(dto))
            {
                return RedirectToAction("ListarPorSitio", "OrigenDatos", new { idSitio = dto.IdSitio } );
            }
            ViewBag.Sitio = ServiceFacadeFactory.Instance.SitioFacade.Obtener(dto.IdSitio);
            ArmarComboOrigenesDatos();
            return View(dto);
        }

        //
        // GET: /OrigenDatos/ModificarConfiguracion
        public ActionResult ModificarConfiguracion(int idSitio, int idOrigenDatos)
        {
            ConfiguracionOrigenDatosEdicionDTO dto = ServiceFacadeFactory.Instance.OrigenDatosFacade.ObtenerConfiguracionParaEdicion(idSitio, idOrigenDatos);
            ArmarComboAtributos(dto.IdOrigenDatos);
            return View(dto);
        }

        //
        // POST: /OrigenDatos/ModificarConfiguracion
        [HttpPost]
        public ActionResult ModificarConfiguracion(int maxid, ConfiguracionOrigenDatosEdicionDTO dto)
        {
            if (dto.ValoresAtributo == null)
            {
                dto.ValoresAtributo = new List<ValorAtributoEdicionDTO>();
            }
            for (int i = 0; i < maxid; i++)
            {
                if (Request["nombre" + i.ToString()] != null)
                {
                    dto.ValoresAtributo.Add(new ValorAtributoEdicionDTO() { Id = int.Parse(Request["idValor" + i.ToString()]), IdAtributo = int.Parse(Request["id" + i.ToString()]), NombreAtributo = Request["nombre" + i.ToString()], Valor = Request["valor" + i.ToString()] });
                }
            }
            if (ServiceFacadeFactory.Instance.OrigenDatosFacade.EditarConfiguracion(dto))
            {
                return RedirectToAction("ListarPorSitio", "OrigenDatos");
            }
            ArmarComboAtributos(dto.IdOrigenDatos);
            return View(dto);
        }

        //
        // GET: /OrigenDatos/Configurar
        public ActionResult EliminarConfiguracion(int idSitio, int idOrigenDatos)
        {
            return View(ServiceFacadeFactory.Instance.OrigenDatosFacade.ObtenerConfiguracionParaEdicion(idSitio, idOrigenDatos));
        }

        //
        // POST: /OrigenDatos/Configurar
        [HttpPost]
        [ActionName("EliminarConfiguracion")]
        public ActionResult EliminarConfiguracionConfirm(int idSitio, int idOrigenDatos)
        {
            ServiceFacadeFactory.Instance.OrigenDatosFacade.EliminarConfiguracion(idSitio, idOrigenDatos);
            return RedirectToAction("ListarPorSitio", "OrigenDatos");
        }

        // GET: /OrigenDatos/Atributos/5
        public JsonResult Atributos(int idOrigenDatos)
        {
            List<AtributoEdicionDTO> atributos = ServiceFacadeFactory.Instance.OrigenDatosFacade.ObtenerAtributos(idOrigenDatos);
            return new JsonResult() { Data = atributos };
        }

        private void ArmarComboAtributos(int idOrigenDatos)
        {
            List<AtributoEdicionDTO> atributos = ServiceFacadeFactory.Instance.OrigenDatosFacade.ObtenerAtributos(idOrigenDatos);
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (AtributoEdicionDTO atributo in atributos)
            {
                items.Add(new SelectListItem() { Selected = false, Text = atributo.Nombre, Value = atributo.Id.ToString() });
            }
            ViewBag.Atributos = items;
        }
    }
}
