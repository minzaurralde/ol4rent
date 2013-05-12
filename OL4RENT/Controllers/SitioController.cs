using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ol4RentAPI.Model;
using Ol4RentAPI.Facades;

namespace OL4RENT.Controllers
{
    public class SitioController : Controller
    {

        //
        // GET: /Sitio/Logo
        [HttpGet]
        public FileContentResult Logo()
        {
            // TODO implementar la obtencion del sitio
            int idSitio = 1;
            return new FileContentResult(ServiceFacadeFactory.Instance.SitioFacade.Logo(idSitio), "image/jpeg");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}