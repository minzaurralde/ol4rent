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
        [Required(ErrorMessage = "El nombre del origen de datos es un campo obligatorio")]
        [DataType(DataType.Text)]
        [StringLength(64, ErrorMessage="El nombre del origen de datos puede contener como máximo {0} caracteres.")]
        [Display(Name="Nombre del origen de datos")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La dll que contiene el manejador del origen de datos es un campo obligatorio")]
        [Display(Name="DLL que contiene la clase que obtiene las novedades")]
        public byte[] Manejador { get; set; }
        [Display(Name = "Atributos configurables por sitio")]
        public List<AtributoAltaDTO> Atributos { get; set; }
        [Display(Name = "DLLs de las dependencias de la DLL del manejador")]
        public List<DependenciaDTO> Dependencias { get; set; }
    }

    public class OrigenDatosEdicionDTO 
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del origen de datos es un campo obligatorio")]
        [DataType(DataType.Text)]
        [StringLength(64, ErrorMessage = "El nombre del origen de datos puede contener como máximo {0} caracteres.")]
        [Display(Name = "Nombre del origen de datos")]
        public string Nombre { get; set; }
        [FileExtensions(Extensions = "dll")]
        [Display(Name = "DLL que contiene la clase que obtiene las novedades")]
        public byte[] Manejador { get; set; }
        [Display(Name = "Atributos configurables por sitio")]
        public List<AtributoEdicionDTO> Atributos { get; set; }
        [Display(Name = "DLLs de las dependencias de la DLL del manejador")]
        public List<DependenciaDTO> Dependencias { get; set; }
    }

    public class DependenciaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public byte[] Dll { get; set; }
    }
}
