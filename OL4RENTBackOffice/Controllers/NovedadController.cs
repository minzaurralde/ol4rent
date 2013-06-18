using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using Ol4RentAPI.Facades;
using Ol4RentAPI.DTO;

namespace OL4RENT.Controllers
{
    public class NovedadController : Controller
    {
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        //
        // GET: /Novedad/ListarPorSitio
        public ActionResult ListarPorSitio(int idSitio)
        {
            List<NovedadListadoDTO> novedades = ServiceFacadeFactory.Instance.NovedadFacade.ObtenerNovedadesParaBOPorSitio(idSitio);
            GuardarSitioView(idSitio);
            return View(novedades);
        }

        private void GuardarSitioView(int idSitio)
        {
            SitioEdicionDTO sitio = ServiceFacadeFactory.Instance.SitioFacade.ObtenerParaEdicion(idSitio);
            ViewBag.Sitio = sitio;
        }

        //
        // GET: /Novedad/Crear
        public ActionResult Crear(int idSitio)
        {
            GuardarSitioView(idSitio);
            ArmarComboConfiugracionesOrigienesDatos(idSitio, null);
            return View(new NovedadAltaDTO() { FechaHora = DateTime.Now });
        }

        private void ArmarComboConfiugracionesOrigienesDatos(int idSitio, int? idConfiguracion)
        {
            List<ConfiguracionOrigenDatosEdicionDTO> configuraciones = ServiceFacadeFactory.Instance.OrigenDatosFacade.ObtenerPorSitio(idSitio);
            List<SelectListItem> configuracionesSV = configuraciones.Select(c => new SelectListItem() { Selected = idConfiguracion.HasValue ? idConfiguracion.Value == c.Id : false, Text = c.NombreOrigenDatos, Value = c.Id.ToString() }).ToList();
            ViewBag.ConfiguracionesOrigenDeDatosDDL = configuracionesSV;
        }

        [HttpPost]
        public ActionResult Crear(int idSitio, NovedadAltaDTO dto, string Hora, string Fecha)
        {
            dto.FechaHora = DateTime.Parse(Fecha + " " + Hora);
            if (ModelState.IsValid)
            {
                ServiceFacadeFactory.Instance.NovedadFacade.Crear(dto);
                return RedirectToAction("ListarPorSitio", "Novedad", new { idSitio = idSitio });
            }
            else
            {
                GuardarSitioView(idSitio);
                ArmarComboConfiugracionesOrigienesDatos(idSitio, dto.IdConfiguracionOrigenDeDatos);
                return View(dto);
            }
        }

        //
        // GET: /Novedad/Eliminar
        public ActionResult Eliminar(int id, int idSitio)
        {
            ServiceFacadeFactory.Instance.NovedadFacade.Eliminar(id);
            return RedirectToAction("ListarPorSitio", "Novedad", new { idSitio = idSitio });
        }

        //
        // POST: /Novedad/Eliminar
        [HttpPost]
        [ActionName("Eliminar")]
        public ActionResult EliminarConfirm(int id, int idSitio)
        {
            ServiceFacadeFactory.Instance.NovedadFacade.Eliminar(id);
            return RedirectToAction("ListarPorSitio", "Novedad", new { idSitio = idSitio });
        }

        //
        // GET: /Novedad/Editar
        public ActionResult Editar(int id, int idSitio)
        {
            GuardarSitioView(idSitio);
            NovedadEdicionDTO novedad = ServiceFacadeFactory.Instance.NovedadFacade.ObtenerNovedadParaEdicion(id);
            ArmarComboConfiugracionesOrigienesDatos(idSitio, novedad.IdConfiguracionOrigenDeDatos);
            return View(novedad);
        }

        //
        // POST: /Novedad/Editar
        [HttpPost]
        public ActionResult Editar(int idSitio, NovedadEdicionDTO dto, string Hora, string Fecha)
        {
            dto.FechaHora = DateTime.Parse(Fecha + " " + Hora);
            if (ModelState.IsValid)
            {
                ServiceFacadeFactory.Instance.NovedadFacade.Editar(dto);
                return RedirectToAction("ListarPorSitio", "Novedad", new { idSitio = idSitio });
            }
            else
            {
                GuardarSitioView(idSitio);
                ArmarComboConfiugracionesOrigienesDatos(idSitio, dto.IdConfiguracionOrigenDeDatos);
                return View(dto);
            }
        }
    }
}