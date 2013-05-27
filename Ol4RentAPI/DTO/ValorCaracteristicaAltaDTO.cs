using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.DTO
{
    public class ValorCaracteristicaAltaDTO
    {
        [Display(Name = "Valor de la caracteristica")]
        public string Valor { get; set; }
        public int IdCaracteristica { get; set; }
    }

    public class ValorCaracteristicaEdicionDTO: ValorCaracteristicaAltaDTO
    {
        public int Id { get; set; }
    }
    public class ValorCaracteristicaListadoDTO : ValorCaracteristicaEdicionDTO
    {
        public CaracteristicaEdicionDTO Caracteristica { get; set; }
    }
}
