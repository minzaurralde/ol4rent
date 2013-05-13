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
        private int ArmarComboSitios()
        {
            List<SitioListadoDTO> sitios = ServiceFacadeFactory.Instance.SitioFacade.ObtenerPorUsuario(User.Identity.Name);
            if (sitios.Count == 1)
            {
                ViewBag.AplicaFiltro = false;
                return sitios[0].Id;
            }
            else if (sitios.Count == 0)
            {
                ViewBag.AplicaFiltro = false;
                return -1;
            }
            else
            {
                List<SelectListItem> items = new List<SelectListItem>();
                foreach (SitioListadoDTO sitio in sitios)
                {
                    items.Add(new SelectListItem() { Selected = false, Text = sitio.Nombre, Value = sitio.Id.ToString() });
                }
                ViewBag.AplicaFiltro = true;
                ViewBag.Sitios = items;
                return 0;
            }
        }

        private List<UsuarioSitioDTO> ObtenerUsuarios(int idSitio)
        {
            int maximoCantidadContenidoBloqueadosPorUsuario = ServiceFacadeFactory.Instance.SitioFacade.Obtener(idSitio).CantContBloqXUsu;
            List<UsuarioSitioDTO> usuarios = ServiceFacadeFactory.Instance.AccountFacade.ObtenerPorSitio(idSitio);
            SitioEdicionDTO sitio = ServiceFacadeFactory.Instance.SitioFacade.ObtenerParaEdicion(idSitio);
            ViewBag.IdSitio = idSitio;
            ViewBag.NombreSitio = sitio.Nombre;
            ViewBag.CantContBloqXUsr = maximoCantidadContenidoBloqueadosPorUsuario;
            return usuarios;
        }

        //
        // GET: /Usuario/ListarPorSitio
        public ActionResult ListarPorSitio(int? idSitio)
        {
            int id = ArmarComboSitios();
            if (idSitio.HasValue)
            {
                return View(ObtenerUsuarios(idSitio.Value));
            }
            else if (id > 0)
            {
                return View(ObtenerUsuarios(id));
            }
            else
            {
                return View(new List<UsuarioSitioDTO>());
            }
        }

        //
        // POST: /Usuario/ListarPorSitio
        [HttpPost]
        [ActionName("ListarPorSitio")]
        public ActionResult ListarPorSitioFiltrado(int idSitio)
        {
            ArmarComboSitios();
            return View(ObtenerUsuarios(idSitio));
        }


        //
        // GET: /Usuario/DeshabilitarEnSitio
        public ActionResult DeshabilitarEnSitio(int idUsuario, int idSitio)
        {
            ServiceFacadeFactory.Instance.AccountFacade.DeshabilitarUsuarioEnSitio(idUsuario, idSitio);
            return RedirectToAction("ListarPorSitio", "Usuario", new { idSitio = idSitio });
        }

        //
        // GET: /Usuario/HabilitarEnSitio
        public ActionResult HabilitarEnSitio(int idUsuario, int idSitio)
        {
            ServiceFacadeFactory.Instance.AccountFacade.HabilitarUsuarioEnSitio(idUsuario, idSitio);
            return RedirectToAction("ListarPorSitio", "Usuario", new { idSitio = idSitio });
        }
        
        //
        // GET: /Usuario/ResetearEnSitio
        public ActionResult ResetearEnSitio(int idUsuario, int idSitio)
        {
            ServiceFacadeFactory.Instance.AccountFacade.ResetearUsuarioEnSitio(idUsuario, idSitio);
            return RedirectToAction("ListarPorSitio", "Usuario", new { idSitio = idSitio });
        }
    }
}
