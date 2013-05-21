using Ol4RentAPI.DTO;
using Ol4RentAPI.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OL4RENTBackOffice.Controllers
{
    public class ReporteController : Controller
    {
        //
        // GET: /Reporte/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContenidosInadecuadosPorSitio()
        {
            ArmarComboSitios(null);
            return View(new List<ContenidoDTO>());
        }

        [HttpPost]
        public ActionResult ContenidosInadecuadosPorSitio(int idSitio)
        {
            ArmarComboSitios(idSitio);
            List<ContenidoDTO> contenidos = ServiceFacadeFactory.Instance.BienFacade.ContenidosInadecuadosPorSitio(idSitio);
            return View(contenidos);
        }

        public ActionResult RegistroDeBienesEnTiempo()
        {
            ArmarFiltroFechas(null, null);
            ArmarComboSitios(null);
            return View(new RegistroBienDTO() { Cantidad = 0 });
        }

        [HttpPost]
        public ActionResult RegistroDeBienesEnTiempo(int idSitio, DateTime fechaInicio, DateTime fechaFin)
        {
            ArmarFiltroFechas(fechaInicio, fechaFin);
            ArmarComboSitios(idSitio);
            RegistroBienDTO reporte = ServiceFacadeFactory.Instance.BienFacade.RegistroDeBienesEnTiempo(idSitio, fechaInicio, fechaFin);
            return View(reporte);
        }

        private void ArmarFiltroFechas(DateTime? fechaInicio, DateTime? fechaFin)
        {
            ViewBag.FechaInicio = fechaInicio.HasValue ? fechaInicio.Value : DateTime.Now.AddMonths(-1);
            ViewBag.FechaFin = fechaFin.HasValue ? fechaFin.Value : DateTime.Now;
        }

        private void ArmarComboSitios(int? idSitio)
        {
            List<SitioListadoDTO> sitios = ServiceFacadeFactory.Instance.SitioFacade.ObtenerPorUsuario(User.Identity.Name);
            List<SelectListItem> comboSitios = sitios.Select(s => new SelectListItem() { Selected = idSitio.HasValue ? idSitio.Value == s.Id : false, Text = s.Nombre, Value = s.Id.ToString() }).ToList();
            ViewBag.Sitios = comboSitios;
        }
    }
}
