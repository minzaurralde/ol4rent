﻿using Microsoft.Web.WebPages.OAuth;
using Ol4RentAPI.Model;
using Ol4RentAPI.DTO;
using OL4RENT.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Ol4RentAPI.Facades;

namespace OL4RENT.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IndexViewModel viewModel = new IndexViewModel();
            viewModel.BienesPopulares = ServiceFacadeFactory.Instance.BienFacade.BienesPopulares();
            viewModel.ListaNovedades = ServiceFacadeFactory.Instance.NovedadFacade.ListaNovedades();
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
            }
            else
            {
                ViewBag.Message = "El usuario no es valido";
            }
            return RedirectToAction("Index");
        }
    }
}
