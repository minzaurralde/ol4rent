using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.DTO
{
    public class OrigenDatosAltaDTO
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(64, ErrorMessage="El nombre del origen de datos puede contener como máximo {0} caracteres.")]
        [Display(Name="Nombre del origen de datos")]
        public string Nombre { get; set; }
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions="dll")]
        [Display(Name="DLL que contiene la clase que obtiene las novedades")]
        public byte[] Manejador { get; set; }
        [Display(Name = "Atributos configurables por sitio")]
        public virtual List<AtributoAltaDTO> Atributos { get; set; }
    }

    public class OrigenDatosEdicionDTO 
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(64, ErrorMessage = "El nombre del origen de datos puede contener como máximo {0} caracteres.")]
        [Display(Name = "Nombre del origen de datos")]
        public string Nombre { get; set; }
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "dll")]
        [Display(Name = "DLL que contiene la clase que obtiene las novedades")]
        public byte[] Manejador { get; set; }
        [Display(Name = "Atributos configurables por sitio")]
        public virtual List<AtributoEdicionDTO> Atributos { get; set; }
    }
}
