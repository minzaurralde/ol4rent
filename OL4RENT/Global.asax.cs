using Ol4RentAPI.DTO;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;
using System;

namespace OL4RENT
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            //////// Agregado deteccion

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("WindowsPhone")
            {
                ContextCondition = (context => context.GetOverriddenUserAgent().IndexOf
                    ("Windows Phone OS", StringComparison.OrdinalIgnoreCase) >= 0)
            });

            DisplayModeProvider.Instance.Modes.Insert(1, new DefaultDisplayMode("iPhone")
            {
                ContextCondition = (context => context.GetOverriddenUserAgent().IndexOf
                    ("iPhone", StringComparison.OrdinalIgnoreCase) >= 0)
            });

            DisplayModeProvider.Instance.Modes.Insert(2, new DefaultDisplayMode("Android")
            {
                ContextCondition = (context => context.GetOverriddenUserAgent().IndexOf
                    ("Android", StringComparison.OrdinalIgnoreCase) >= 0)
            });

            DisplayModeProvider.Instance.Modes.Insert(3, new DefaultDisplayMode("Mobile")
            {
                ContextCondition = (context => context.GetOverriddenUserAgent().IndexOf
                    ("Mobile", StringComparison.OrdinalIgnoreCase) >= 0)
            });
            /*
            DisplayModeProvider.Instance.Modes.Insert(5,
                 new DefaultDisplayMode("Phone")
                 {
                     ContextCondition = (context => (
                     (context.GetOverriddenUserAgent() != null) &&
                     (
                         (context.GetOverriddenUserAgent().IndexOf("iPhone",
                             StringComparison.OrdinalIgnoreCase) >= 0) ||
                         (context.GetOverriddenUserAgent().IndexOf("iPod",
                             StringComparison.OrdinalIgnoreCase) >= 0) ||
                         (context.GetOverriddenUserAgent().IndexOf("Droid",
                             StringComparison.OrdinalIgnoreCase) >= 0) ||
                         (context.GetOverriddenUserAgent().IndexOf("Blackberry",
                             StringComparison.OrdinalIgnoreCase) >= 0) ||
                         (context.GetOverriddenUserAgent().StartsWith("Blackberry",
                             StringComparison.OrdinalIgnoreCase))
                         )
                     ))
                 });

            DisplayModeProvider.Instance.Modes.Insert(6,
                new DefaultDisplayMode("Tablet")
                {
                    ContextCondition = (context => (
                    (context.GetOverriddenUserAgent() != null) &&
                    (
                        (context.GetOverriddenUserAgent().IndexOf("iPad",
                            StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (context.GetOverriddenUserAgent().IndexOf("Playbook",
                            StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (context.GetOverriddenUserAgent().IndexOf("Transformer",
                            StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (context.GetOverriddenUserAgent().IndexOf("Xoom",
                            StringComparison.OrdinalIgnoreCase) >= 0)
                        )
                    ))
                });*/

            //////// Fin Agregado deteccion

            AuthConfig.RegisterAuth();

            AutoMapperInitializer.Inicializar();
        }
    }
}