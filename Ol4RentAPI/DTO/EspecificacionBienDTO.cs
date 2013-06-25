﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.DTO
{
    public class EspecificacionBienDTO
    {    
        public int Id { get; set; }
        // Propiedades para la EspecificacionBien
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Titulo")]
        public string Titulo { get; set; }
        [DataType(DataType.Text)]
        [Display(Name="Latitud")]
        public decimal Latitud { get; set; }
        [DataType(DataType.Text)]
        [Display(Name="Longitud")]
        public decimal Longitud { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name="Rango")]
        public short Rango { get; set; }
        //Usuario propietario
        [Display(Name="Usuario")]
        public string Usuario { get; set; }
        //TipoBien perteneciente
        [Display(Name="Tipo bien")]
        public int TipoBien { get; set; }
        //Propiedades del Tipo de Bien
        [Display(Name="Características esecíficas del bien")]
        public virtual List<ValorCaracteristicaListadoDTO> ValoresCaracteristicas { get; set; }
    }

    public class EspecificacionBienAltaDTO
    {
        // Propiedades para la EspecificacionBien
        [Required(ErrorMessage="Titulo obligatorio")]
        [DataType(DataType.Text)]
        [Display(Name = "Titulo")]
        public string Titulo { get; set; }
        [Required(ErrorMessage="Debe ingresar un punto en el mapa")]
        [DataType(DataType.Text)]
        [Display(Name = "Latitud")]
        public decimal Latitud { get; set; }
        [Required(ErrorMessage = "Debe ingresar un punto en el mapa")]
        [DataType(DataType.Text)]
        [Display(Name = "Longitud")]
        public decimal Longitud { get; set; }
        [Required(ErrorMessage="Debe ingresar un Rango")]
        [DataType(DataType.Text)]
        [Display(Name = "Rango")]
        public short Rango { get; set; }
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

    public class EspecificacionBienListadoDTO
    {
        [Display(Name = "Identificador de Wish")]
        public int Id { get; set; }
        [Display(Name = "Titulo")]
        public string Titulo { get; set; }
    }
}
