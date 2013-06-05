using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.DTO
{
    public class BienCercanoDTO
    {
        [Display(Name = "Identificador del bien")]
        public int Id { get; set; }
        [Display(Name = "Tipo de bien")]
        public string TipoDeBien { get; set; }
        [Display(Name = "Titulo del bien")]
        public string Titulo { get; set; }
        [Display(Name = "Latitud")]
        public decimal Latitud { get; set; }
        [Display(Name = "Logitud")]
        public decimal Longitud { get; set; }
    }
}
