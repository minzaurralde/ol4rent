using Ol4RentAPI.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace OL4RENT.Filters
{
    public class SesionRenewalFilterAttribute : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                string nombreUsuario = filterContext.HttpContext.User.Identity.Name;
                ServiceFacadeFactory.Instance.SesionManager.ActualizarSesion(nombreUsuario);
            }
            this.OnActionExecuting(filterContext);
        }
    }
}