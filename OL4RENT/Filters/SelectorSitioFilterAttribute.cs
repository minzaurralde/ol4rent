using Ol4RentAPI.Facades;
using Ol4RentAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace OL4RENT.Filters
{
    public class SelectorSitioFilterAttribute : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            Uri uri = filterContext.HttpContext.Request.Url;
            string posiblehost = uri.Host;
            SitioListadoDTO sitio = ServiceFacadeFactory.Instance.SitioFacade.ObtenerPorDominio(uri.Host);
            if (sitio != null)
            {
                filterContext.HttpContext.Session["sitio"] = sitio;
                if (!ServiceFacadeFactory.Instance.AccountFacade.UsuarioHabilitadoEnSitio(filterContext.HttpContext.User.Identity.Name, sitio.Id))
                {
                    WebSecurity.Logout();
                    filterContext.HttpContext.Response.StatusCode = 403;
                    filterContext.HttpContext.Response.SuppressContent = true;
                    filterContext.HttpContext.ApplicationInstance.CompleteRequest();
                }
            }
            this.OnActionExecuting(filterContext);
        }
    }
}
