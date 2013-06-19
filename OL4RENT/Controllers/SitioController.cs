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
using System.IO;

namespace OL4RENT.Controllers
{
    public class SitioController : Controller
    {

        //
        // GET: /Sitio/Logo
        [HttpGet]
        public FileContentResult Logo(int idSitio)
        {
            byte[] bytes = ServiceFacadeFactory.Instance.SitioFacade.Logo(idSitio);
            if (bytes != null)
            {
                return new FileContentResult(ServiceFacadeFactory.Instance.SitioFacade.Logo(idSitio), "image/jpeg");
            }
            return null;
        }

        //
        // GET: /Sitio/Css
        [HttpGet]
        public FileContentResult Css()
        {
            ///// Verificar si es un dispositivo mobil o no
            string userAgentActual = Request.UserAgent.ToLower();
            bool esDispositivoMovil = false;
            if (userAgentActual.Contains("iphone") || userAgentActual.Contains("android") || userAgentActual.Contains("windows phone") || userAgentActual.Contains("mobile"))
            {
                esDispositivoMovil = true;
            }
           
            byte[] bytes = null;

            if (!esDispositivoMovil)
            {
                SitioListadoDTO sitio = (SitioListadoDTO)Session["sitio"];
                if (sitio != null)
                {
                    bytes = ServiceFacadeFactory.Instance.SitioFacade.Css(sitio.Id);
                }
            }

            if (bytes == null)
            {
                FileStream stream = System.IO.File.OpenRead(Server.MapPath("/Content/Site.css"));
                int tam = Convert.ToInt32(stream.Length);
                bytes = new byte[tam];
                stream.Read(bytes, 0, tam);
                stream.Close();
            }

            return new FileContentResult(bytes, "text/css");

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

      
    }
}