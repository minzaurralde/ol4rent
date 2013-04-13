using OL4RENT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OL4RENT.ViewModels
{
    public class IndexViewModel
    {
        public List<Bien> BienesPopulares { get; set; }
        public List<Novedad> ListaNovedades { get; set; }
    }
}