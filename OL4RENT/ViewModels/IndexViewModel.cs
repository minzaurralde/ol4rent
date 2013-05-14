using Ol4RentAPI.DTO;
using Ol4RentAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OL4RENT.ViewModels
{
    public class IndexViewModel
    {
        public List<Bien> BienesPopulares { get; set; }
        public List<NovedadDTO> ListaNovedades { get; set; }
    }
}