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
        [Authorize(Roles = "SITE_ADMIN")]
        public ActionResult ListarPorSitio(int idSitio)
        {
            ViewBag.IdSitio = idSitio;
            List<ConfiguracionOrigenDatosEdicionDTO> origenesDatos = ServiceFacadeFactory.Instance.OrigenDatosFacade.ObtenerPorSitio(idSitio);
            return View(origenesDatos);
        }

        //
        // GET: /OrigenDatos/Listar
        [Authorize(Roles = "SUPER_ADMIN")]
        public ActionResult Listar()
        {
            List<OrigenDatosListaDTO> origenesDatos = ServiceFacadeFactory.Instance.OrigenDatosFacade.ObtenerTodos();
            return View(origenesDatos);
        }

        //
        // GET: /OrigenDatos/Crear
        [Authorize(Roles = "SUPER_ADMIN")]
        public ActionResult Crear()
        {
            return View(new OrigenDatosAltaDTO());
        }

        //
        // POST: /OrigenDatos/Crear
        [Authorize(Roles = "SUPER_ADMIN")]
        [HttpPost]
        public ActionResult Crear(int maxid, OrigenDatosAltaDTO dto, HttpPostedFileBase dll, IEnumerable<HttpPostedFileBase> dependencias)
        {
            // TODO crear origen de datos: falta probar todo lo que tiene que ver con las Dlls "Dependencias" de la dll del OD
            dto.Dependencias = new List<DependenciaDTO>();
            foreach (HttpPostedFileBase fileDepedencia in dependencias)
            {
                if (fileDepedencia != null)
                {
                    byte[] buffer = new byte[fileDepedencia.ContentLength];
                    fileDepedencia.InputStream.Read(buffer, 0, fileDepedencia.ContentLength);
                    dto.Dependencias.Add(new DependenciaDTO() { Id = -1, Nombre = fileDepedencia.FileName, Dll = buffer });
                }
            }
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
            //if (ModelState.IsValid)
            //{
                if (ServiceFacadeFactory.Instance.OrigenDatosFacade.Crear(dto))
                {
                    return RedirectToAction("Listar", "OrigenDatos");
                }
            //}
            return View(dto);
        }

        //
        // GET: /OrigenDatos/Editar
        [Authorize(Roles = "SUPER_ADMIN")]
        public ActionResult Editar(int id)
        {
            OrigenDatosEdicionDTO dto = ServiceFacadeFactory.Instance.OrigenDatosFacade.ObtenerParaEdicion(id);
            return View(dto);
        }

        //
        // POST: /OrigenDatos/Crear
        [Authorize(Roles = "SUPER_ADMIN")]
        [HttpPost]
        public ActionResult Editar(int maxid, OrigenDatosEdicionDTO dto, HttpPostedFileBase dll, IEnumerable<HttpPostedFileBase> dependencias)
        {
            // TODO editar origen de datos: falta probar todo lo que tiene que ver con las Dlls "Dependencias" de la dll del OD
            dto.Dependencias = new List<DependenciaDTO>();
            foreach (HttpPostedFileBase fileDepedencia in dependencias)
            {
                if (fileDepedencia != null)
                {
                    byte[] buffer = new byte[fileDepedencia.ContentLength];
                    fileDepedencia.InputStream.Read(buffer, 0, fileDepedencia.ContentLength);
                    dto.Dependencias.Add(new DependenciaDTO() { Id = -1, Nombre = fileDepedencia.FileName, Dll = buffer });
                }
            }
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
        [Authorize(Roles = "SUPER_ADMIN")]
        public ActionResult Eliminar(int id)
        {
            ServiceFacadeFactory.Instance.OrigenDatosFacade.Eliminar(id);
            return RedirectToAction("Listar", "OrigenDatos");
        }

        //
        // POST: /OrigenDatos/Eliminar
        [HttpPost]
        [ActionName("Eliminar")]
        [Authorize(Roles = "SUPER_ADMIN")]
        public ActionResult EliminarConfirm(int id)
        {
            ServiceFacadeFactory.Instance.OrigenDatosFacade.Eliminar(id);
            return RedirectToAction("Listar", "OrigenDatos");
        }

        //
        // GET: /OrigenDatos/Configurar
        [Authorize(Roles = "SITE_ADMIN")]
        public ActionResult Configurar(int idSitio)
        {
            ViewBag.Sitio = ServiceFacadeFactory.Instance.SitioFacade.Obtener(idSitio);
            ArmarComboOrigenesDatos(-1);
            return View(new ConfiguracionOrigenDatosAltaDTO());
        }

        //
        // POST: /OrigenDatos/Configurar
        [Authorize(Roles = "SITE_ADMIN")]
        [HttpPost]
        public ActionResult Configurar(ConfiguracionOrigenDatosAltaDTO dto)
        {
            if (dto.ValoresAtributo == null)
            {
                dto.ValoresAtributo = new List<ValorAtributoAltaDTO>();
            }
            List<AtributoEdicionDTO> atributos = ObtenerListaAtributos(dto.IdOrigenDatos);
            foreach (AtributoEdicionDTO atributo in atributos)
            {
                string valor = Request["val-" + atributo.Id.ToString()];
                dto.ValoresAtributo.Add(new ValorAtributoAltaDTO() { IdAtributo = atributo.Id, NombreAtributo = atributo.Nombre, Valor = valor });
            }
            if (ServiceFacadeFactory.Instance.OrigenDatosFacade.Configurar(dto))
            {
                return RedirectToAction("ListarPorSitio", "OrigenDatos", new { idSitio = dto.IdSitio } );
            }
            ViewBag.Sitio = ServiceFacadeFactory.Instance.SitioFacade.Obtener(dto.IdSitio);
            ArmarComboOrigenesDatos(dto.IdOrigenDatos);
            return View(dto);
        }

        //
        // GET: /OrigenDatos/ModificarConfiguracion
        [Authorize(Roles = "SITE_ADMIN")]
        public ActionResult ModificarConfiguracion(int id)
        {
            ConfiguracionOrigenDatosEdicionDTO dto = ServiceFacadeFactory.Instance.OrigenDatosFacade.ObtenerConfiguracionParaEdicion(id);
            ArmarListaAtributos(dto.IdOrigenDatos);
            return View(dto);
        }

        //
        // POST: /OrigenDatos/ModificarConfiguracion
        [Authorize(Roles = "SITE_ADMIN")]
        [HttpPost]
        public ActionResult ModificarConfiguracion(ConfiguracionOrigenDatosEdicionDTO dto)
        {
            if (dto.ValoresAtributo == null)
            {
                dto.ValoresAtributo = new List<ValorAtributoEdicionDTO>();
            }
            List<AtributoEdicionDTO> atributos = ObtenerListaAtributos(dto.IdOrigenDatos);
            foreach (AtributoEdicionDTO atributo in atributos)
            {
                string valor = Request["val-" + atributo.Id.ToString()];
                int id;
                if (!int.TryParse(Request["id-va-" + atributo.Id.ToString()], out id))
                {
                    id = -1;
                }
                dto.ValoresAtributo.Add(new ValorAtributoEdicionDTO() { Id = id, IdAtributo = atributo.Id, NombreAtributo = atributo.Nombre, Valor = valor });
            }
            if (ServiceFacadeFactory.Instance.OrigenDatosFacade.EditarConfiguracion(dto))
            {
                return RedirectToAction("ListarPorSitio", "OrigenDatos", new { idSitio = dto.IdSitio });
            }
            ArmarListaAtributos(dto.IdOrigenDatos);
            return View(dto);
        }

        //
        // GET: /OrigenDatos/Configurar
        [Authorize(Roles = "SITE_ADMIN")]
        public ActionResult EliminarConfiguracion(int id)
        {
            ConfiguracionOrigenDatosEdicionDTO config = ServiceFacadeFactory.Instance.OrigenDatosFacade.ObtenerConfiguracionParaEdicion(id);
            int siteid = config.IdSitio;
            ServiceFacadeFactory.Instance.OrigenDatosFacade.EliminarConfiguracion(id);
            return RedirectToAction("ListarPorSitio", "OrigenDatos", new { idSitio = siteid });
        }

        //
        // POST: /OrigenDatos/Configurar
        [Authorize(Roles = "SITE_ADMIN")]
        [HttpPost]
        [ActionName("EliminarConfiguracion")]
        public ActionResult EliminarConfiguracionConfirm(int id)
        {
            ConfiguracionOrigenDatosEdicionDTO config = ServiceFacadeFactory.Instance.OrigenDatosFacade.ObtenerConfiguracionParaEdicion(id);
            int siteid = config.IdSitio;
            ServiceFacadeFactory.Instance.OrigenDatosFacade.EliminarConfiguracion(id);
            return RedirectToAction("ListarPorSitio", "OrigenDatos", new { idSitio = siteid });
        }

        // GET: /OrigenDatos/Atributos/5
        [AllowAnonymous]
        public JsonResult Atributos(int id)
        {
            List<AtributoEdicionDTO> atributos = ObtenerListaAtributos(id);
            return new JsonResult() { Data = atributos , JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        private void ArmarComboOrigenesDatos(int idOrigenDatosSeleccionado)
        {
            List<OrigenDatosListaDTO> origenesDatos = ObtenerListaOrigenesDatos();
            List<SelectListItem> items = new List<SelectListItem>();
            bool primero = true;
            foreach (OrigenDatosListaDTO od in origenesDatos)
            {
                bool seleccionado = (idOrigenDatosSeleccionado <= 0 && primero) || (od.Id == idOrigenDatosSeleccionado);
                items.Add(new SelectListItem() { Selected = seleccionado, Text = od.Nombre, Value = od.Id.ToString() });
                if (seleccionado)
                {
                    ArmarListaAtributos(od.Id);
                    primero = false;
                }
            }
            ViewBag.OrigenesDatos = items;
        }

        private void ArmarListaAtributos(int idOrigenDatos)
        {
            ViewBag.Atributos = ObtenerListaAtributos(idOrigenDatos);
        }

        private static List<OrigenDatosListaDTO> ObtenerListaOrigenesDatos()
        {
            List<OrigenDatosListaDTO> origenesDatos = ServiceFacadeFactory.Instance.OrigenDatosFacade.ObtenerTodos();
            return origenesDatos;
        }

        private static List<AtributoEdicionDTO> ObtenerListaAtributos(int idOrigenDatos)
        {
            List<AtributoEdicionDTO> atributos = ServiceFacadeFactory.Instance.OrigenDatosFacade.ObtenerAtributos(idOrigenDatos);
            return atributos;
        }
    }
}
