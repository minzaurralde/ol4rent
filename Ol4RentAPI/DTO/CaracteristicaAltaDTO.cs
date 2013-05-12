using Ol4RentAPI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.DTO
{
    public class CaracteristicaAltaDTO
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(64, ErrorMessage="El nombre del atributo debe tener como máximo {0} caracteres")]
        [Display(Name = "Nombre del atributo")]
        public string Nombre { get; set; }
        [Required]
        [EnumDataType(typeof(TipoDato))]
        [Display(Name = "Tipo de datos del atributo")]
        public TipoDato Tipo { get; set; }
    }

    public class CaracteristicaEdicionDTO
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(64, ErrorMessage = "El nombre del atributo debe tener como máximo {0} caracteres")]
        [Display(Name = "Nombre del atributo")]
        public string Nombre { get; set; }
        [Required]
        [EnumDataType(typeof(TipoDato))]
        [Display(Name = "Tipo de datos del atributo")]
        public TipoDato Tipo { get; set; }
    }
}
