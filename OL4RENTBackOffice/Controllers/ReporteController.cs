using GoogleChartSharp;
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
            return View(new RegistroBienDTO() { Tipo = "", Valores = new List<ValorRegistroBienDTO>() });
        }

        [HttpPost]
        public ActionResult RegistroDeBienesEnTiempo(int idSitio, DateTime fechaInicio, DateTime fechaFin)
        {
            ArmarFiltroFechas(fechaInicio, fechaFin);
            ArmarComboSitios(idSitio);
            RegistroBienDTO reporte = ServiceFacadeFactory.Instance.BienFacade.RegistroDeBienesEnTiempo(idSitio, fechaInicio, fechaFin);
            ArmarGraficaRegistroDeBienesEnTiempo(reporte);
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

        private void ArmarGraficaRegistroDeBienesEnTiempo(RegistroBienDTO registro)
        {
            int maximo = registro.Valores.Select(v => v.Cantidad).Max();
            int[] eje = new int[maximo + 1];
            for (int i = 0; i <= maximo; i++)
            {
                eje[i] = i;
            }
            //LineChart chart = new LineChart(200, 150, LineChartType.SingleDataSet);
            BarChart chart = new BarChart(200, 150, BarChartOrientation.Vertical, BarChartStyle.Stacked);
            chart.AddAxis(new ChartAxis(ChartAxisType.Left, eje.Select(i => i.ToString()).ToArray()) { FontSize = 10 });
            chart.AddAxis(new ChartAxis(ChartAxisType.Bottom, registro.Valores.Select(val => val.Etiqueta).ToArray()) { FontSize = 10 });
            chart.SetData(registro.Valores.Select(val => Convert.ToSingle(val.Cantidad * 100 / maximo)).ToArray());
            string url = chart.GetUrl();
            ViewBag.ChartUrl = url;
        }
    }
}
