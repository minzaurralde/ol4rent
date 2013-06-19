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
        [Display(Name = "Titulo")]
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
        [DataType(DataType.Text)]
        public decimal Latitud { get; set; }
        [Display(Name = "Longitud")]
        [DataType(DataType.Text)]
        public decimal Longitud { get; set; }
        [StringLength(128, ErrorMessage = "Las normas deben tener como máximo {0} caracteres")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Normas")]
        public string Normas { get; set; }
        [Display(Name = "Capacidad")]
        [DataType(DataType.Text)]
        public short Capacidad { get; set; }
        [Display(Name = "Precio")]
        [DataType(DataType.Text)]
        public decimal Precio { get; set; }
        [StringLength(128, ErrorMessage = "La descripción debe tener como máximo {0} caracteres")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        //Usuario propietario
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }
        //TipoBien perteneciente
        [Display(Name = "Tipo bien")]
        public int TipoBien { get; set; }
        //Propiedades del Tipo de Bien
        [Display(Name = "Características esecíficas del bien")]
        public virtual List<ValorCaracteristicaAltaDTO> ValoresCaracteristicas { get; set; }
    }

    public class BienEdicionDTO
    {
        public int Id { get; set; }
        // propiedades para el bien
        [Required]
        [StringLength(64, ErrorMessage = "El titulo del bien debe tener como máximo {0} caracteres")]
        [DataType(DataType.Text)]
        [Display(Name = "Titulo")]
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
        [DataType(DataType.Text)]
        public decimal Latitud { get; set; }
        [Display(Name = "Longitud")]
        [DataType(DataType.Text)]
        public decimal Longitud { get; set; }
        [StringLength(128, ErrorMessage = "Las normas deben tener como máximo {0} caracteres")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Normas")]
        public string Normas { get; set; }
        [Display(Name = "Capacidad")]
        [DataType(DataType.Text)]
        public short Capacidad { get; set; }
        [Display(Name = "Precio")]
        [DataType(DataType.Text)]
        public decimal Precio { get; set; }
        [StringLength(128, ErrorMessage = "La descripción debe tener como máximo {0} caracteres")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        //Usuario propietario
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }
        //TipoBien perteneciente
        [Display(Name = "Tipo bien")]
        public int TipoBien { get; set; }
        //Propiedades del Tipo de Bien
        [Display(Name = "Características esecíficas del bien")]
        public virtual List<ValorCaracteristicaListadoDTO> ValoresCaracteristicas { get; set; }
        public int CantidadLikes { get; set; }
    }
    public class BienListadoDTO
    {
        [Display(Name = "Identificador de Bien")]
        public int Id { get; set; }
        [Display(Name = "Titulo")]
        public string Titulo { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        [Display(Name = "Latitud")]
        public decimal Latitud { get; set; }
        [Display(Name = "Longitud")]
        public decimal Longitud { get; set; }
        public bool MostrarMeGusta { get; set; }
        public int CantidadLikes { get; set; }
        public string Propietario { get; set; }
    }
    public class BienArrendarDTO
    {
        [Display(Name = "Identificador de Bien")]
        public int Id { get; set; }
        [Display(Name = "Titulo")]
        public string Titulo { get; set; }
        [Display(Name = "Fecha Alquilar")]
        public Nullable<System.DateTime> FechaAlquiler { get; set; }
        [Display(Name = "Duración Alquiler")]
        public short DuracionAlquiler { get; set; }
        [Display(Name = "Precio")]
        public decimal Precio { get; set; }
    }
}
