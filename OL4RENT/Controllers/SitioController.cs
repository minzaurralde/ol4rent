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
        public FileContentResult Logo(int idSitio)
        {
            byte[] bytes = ServiceFacadeFactory.Instance.SitioFacade.Logo(idSitio);
            if (bytes != null)
            {
                return new FileContentResult(ServiceFacadeFactory.Instance.SitioFacade.Logo(idSitio), "image/jpeg");
            }
            return null;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

      
    }
}