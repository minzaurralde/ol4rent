using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.DTO
{
    public class BienAltaDTO
    {
        // propiedades para el bien
        [Required]
        [StringLength(64, ErrorMessage = "El titulo del bien debe tener como máximo {0} caracteres")]
        [DataType(DataType.Text)]
        [Display(Name = "Titulo del bien")]
        public string Titulo { get; set; }
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "jpg", ErrorMessage = "La foto del bien debe ser un archivo en formato JPG")]
        [Display(Name = "Foto")]
        public byte[] Foto { get; set; }
        [StringLength(512, ErrorMessage = "La direccion debe tener como máximo {0} caracteres")]
        [DataType(DataType.Text)]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        [Display(Name = "Latitud")]
        public decimal Latitud { get; set; }
        [Display(Name = "Longitud")]
        public decimal Longitud { get; set; }
        [StringLength(128, ErrorMessage = "Las normas deben tener como máximo {0} caracteres")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Normas")]
        public string Normas { get; set; }
        [Display(Name = "Capacidad")]
        public short Capacidad { get; set; }
        [Display(Name = "Precio")]
        public decimal Precio { get; set; }
        [StringLength(128, ErrorMessage = "La descripción debe tener como máximo {0} caracteres")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }

    public class BienEdicionDTO : BienAltaDTO
    {
        public int Id { get; set; }
    }
}
