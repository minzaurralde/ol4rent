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
            filterContext.HttpContext.Response.Write("posiblehost=" + posiblehost);
            filterContext.HttpContext.Session["posiblehost"] = posiblehost;
            this.OnActionExecuting(filterContext);
        }
    }
}
