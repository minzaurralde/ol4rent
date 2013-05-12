using Ol4RentAPI.DTO;
using Ol4RentAPI.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OL4RENTBackOffice.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/ListarPorSitio
        public ActionResult ListarPorSitio(int idSitio)
        {
            int maximoCantidadContenidoBloqueadosPorUsuario = ServiceFacadeFactory.Instance.SitioFacade.Obtener(idSitio).CantContBloqXUsu;
            List<UsuarioSitioDTO> usuarios = ServiceFacadeFactory.Instance.AccountFacade.ObtenerPorSitio(idSitio);
            ViewBag.IdSitio = idSitio;
            ViewBag.CantContBloqXUsr = maximoCantidadContenidoBloqueadosPorUsuario;
            return View(usuarios);
        }

        //
        // GET: /Usuario/DeshabilitarEnSitio
        public ActionResult DeshabilitarEnSitio(int idUsuario, int idSitio)
        {
            ServiceFacadeFactory.Instance.AccountFacade.DeshabilitarUsuarioEnSitio(idUsuario, idSitio);
            return RedirectToAction("ListarPorSitio", "Usuario");
        }

        //
        // GET: /Usuario/HabilitarEnSitio
        public ActionResult HabilitarEnSitio(int idUsuario, int idSitio)
        {
            ServiceFacadeFactory.Instance.AccountFacade.HabilitarUsuarioEnSitio(idUsuario, idSitio);
            return RedirectToAction("ListarPorSitio", "Usuario");
        }
        
        //
        // GET: /Usuario/ResetearEnSitio
        public ActionResult ResetearEnSitio(int idUsuario, int idSitio)
        {
            ServiceFacadeFactory.Instance.AccountFacade.ResetearUsuarioEnSitio(idUsuario, idSitio);
            return RedirectToAction("ListarPorSitio", "Usuario");
        }
    }
}
