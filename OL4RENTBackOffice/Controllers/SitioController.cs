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
        // GET: /Sitio/Crear
        [Authorize(Roles = RolEnum.SUPER_ADMIN.ToString())]
        public ActionResult Crear()
        {
            return View(new SitioAltaDTO() { NombreUsuarioPropietario = User.Identity.Name } );
        }

        //
        // POST: /Sitio/Crear
        [HttpPost]
        [Authorize(Roles = RolEnum.SUPER_ADMIN.ToString())]
        public ActionResult Crear(SitioAltaDTO sitio)
        {
            if (ServiceFacadeFactory.Instance.SitioFacade.Crear(sitio))
            {
                return RedirectToAction("Listar", "Sitio");
            }
            return View(sitio);
        }
    }
}
