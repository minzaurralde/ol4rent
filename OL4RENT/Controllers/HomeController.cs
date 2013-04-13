using OL4RENT.Models;
using OL4RENT.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OL4RENT.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IndexViewModel viewModel = new IndexViewModel();
            viewModel.BienesPopulares = new BienController().BienesPopulares;
            viewModel.ListaNovedades = new NovedadController().ListaNovedades;
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
    }
}
