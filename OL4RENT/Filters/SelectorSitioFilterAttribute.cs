using Ol4RentAPI.Facades;
using Ol4RentAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            }
            this.OnActionExecuting(filterContext);
        }
    }
}
