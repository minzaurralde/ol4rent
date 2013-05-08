using Microsoft.Web.WebPages.OAuth;
using Ol4RentAPI.Model;
using OL4RENT.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OL4RENT.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IndexViewModel viewModel = new IndexViewModel();
            viewModel.BienesPopulares = new BienController().BienesPopulares;
            viewModel.ListaNovedades = new NovedadController().ListaNovedades;
            viewModel.ListaNovedadesRSS = new NovedadController().ListaNovedadesRSS;
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login(){
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password, string ReturnURL)
        {
            if (string.IsNullOrEmpty(username))
                username = "Unknown";
            //Default value that is set if nothing is entered
            if (Membership.ValidateUser(username, password))
            {
//                if (FormsAuthentication.Authenticate(username, password)) {
                    string[] roles = Roles.GetRolesForUser(username);
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, username,
                        DateTime.Now, DateTime.Now.AddMinutes(30), true,
                        string.Join(",", roles));
                    string cookieContents = FormsAuthentication.Encrypt(authTicket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieContents)
                    {
                        Expires = authTicket.Expiration,
                        Path = FormsAuthentication.FormsCookiePath
                    };
                    Response.Cookies.Add(cookie);
                
                    if (!string.IsNullOrEmpty(ReturnURL))
                        Response.Redirect(ReturnURL);
  /*              }
                else
                {
                    ViewBag.Message = "El usuario no es valido";
                }
    */        }
            else
            {
                ViewBag.Message = "El usuario no es valido";
            }
            return RedirectToAction("Index");
        }
    }
}
