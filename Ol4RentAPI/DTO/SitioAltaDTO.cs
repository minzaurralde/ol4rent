using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.DTO
{
    public class SitioAltaDTO
    {
        // propiedades para el sitio
        [Required(ErrorMessage = "El nombre es un campo obligatorio")]
        [StringLength(64, ErrorMessage = "El nombre del sitio debe tener como máximo {0} caracteres")]
        [DataType(DataType.Text)]
        [Display(Name="Nombre del sitio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La descripción es un campo obligatorio")]
        [StringLength(128, ErrorMessage = "La descripción del sitio debe tener como máximo {0} caracteres")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El logo es un archivo obligatorio")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions="jpg", ErrorMessage="El logo del sitio debe ser un archivo en formato JPG")]
        [Display(Name = "Logo")]
        public byte[] Logo { get; set; }
        [Required(ErrorMessage = "El CSS es un archivo obligatorio")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "css", ErrorMessage = "La hoja de estilos del sitio debe ser un archivo CSS")]
        [Display(Name = "Hoja de estilos")]
        public byte[] CSS { get; set; }
        [Required(ErrorMessage = "El mail del administrador es un campo obligatorio")]
        [DataType(DataType.EmailAddress, ErrorMessage="La dirección de correo del administrador debe ser una dirección de correo válida")]
        [StringLength(128, ErrorMessage = "La dirección de correo del administrador del sitio debe tener como máximo {0} caracteres")]
        [Display(Name = "Correo electrónico del Administrador")]
        public string MailAdmin { get; set; }
        [Required(ErrorMessage = "El dominio es un campo obligatorio")]
        [DataType(DataType.Text)]
        [StringLength(128, ErrorMessage = "El dominio del sitio debe tener como máximo {0} caracteres")]
        [Display(Name = "Dominio")]
        public string URL { get; set; }
        [Required(ErrorMessage = "La cantidad de bienes populares es un campo obligatorio")]
        [DataType(DataType.Text)]
        [Display(Name = "Cantidad de bienes populares de la home")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad de bienes populares debe ser mayor que cero")]
        public short CantBienesPopulares { get; set; }
        [Required(ErrorMessage = "La cantidad de marcas inadecuadas máxima por contenido es un campo obligatorio")]
        [DataType(DataType.Text)]
        [Display(Name = "Cantidad máxima de marcas inadecuadas por contenido")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad de marcas inadecuadas máxima por contenido debe ser mayor que cero")]
        public short CantMarcasXCont { get; set; }
        [Required(ErrorMessage = "La cantidad máxima de contenidos bloqueados por usuario es un campo obligatorio")]
        [DataType(DataType.Text)]
        [Display(Name = "Cantidad máxima de contenidos bloqueados por usuario")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad máxima de contenidos bloqueados por usuario debe ser mayor que cero")]
        public short CantContBloqXUsu { get; set; }
        [Required(ErrorMessage = "La cantidad máxima de novedades de la home es un campo obligatorio")]
        [DataType(DataType.Text)]
        [Display(Name = "Cantidad máxima de novedades mostradas en la home")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad máxima de novedades de la home debe ser mayor que cero")]
        public short CantNovedadesHome { get; set; }
        [Required(ErrorMessage = "El porcentaje de aproximación de la wishlist es un campo obligatorio")]
        [DataType(DataType.Text)]
        [Display(Name = "Porcentaje de aproximación de un Wish")]
        [Range(0.1, double.MaxValue, ErrorMessage = "El porcentaje de aproximacion de la wishlist debe ser mayor que cero")]
        public short AproximacionWish { get; set; }
        // propiedades para el tipo de bien
        [Required(ErrorMessage = "El nombre del tipo de bien es un campo obligatorio")]
        [DataType(DataType.Text)]
        [StringLength(64, ErrorMessage = "El nombre del tipo de bien a arrendar en el sitio debe tener como máximo {0} caracteres")]
        [Display(Name = "Nombre del tipo de bien a arrendar")]
        public string NombreTipoBien { get; set; }
        [Display(Name = "Características específicas del bien")]
        public List<CaracteristicaAltaDTO> Caracteristicas { get; set; }
        // propiedad para determinar el usuario propietario del sitio
        [Required(ErrorMessage = "El nombre del usuario propietario del sitio es un campo obligatorio")]
        [DataType(DataType.Text)]
        [StringLength(64, ErrorMessage = "El nombre de usuario del propietario del sitio debe tener como máximo {0} caracteres")]
        [Display(Name = "Nombre de usuario del propietario")]
        public string NombreUsuarioPropietario { get; set; }
    }

    public class SitioEdicionDTO 
    {
        public int Id { get; set; }
        // propiedades para el sitio
        [Required(ErrorMessage = "El nombre es un campo obligatorio")]
        [StringLength(64, ErrorMessage = "El nombre del sitio debe tener como máximo {0} caracteres")]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre del sitio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La descripción es un campo obligatorio")]
        [StringLength(128, ErrorMessage = "La descripción del sitio debe tener como máximo {0} caracteres")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "jpg", ErrorMessage = "El logo del sitio debe ser un archivo en formato JPG")]
        [Display(Name = "Logo")]
        public byte[] Logo { get; set; }
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "css", ErrorMessage = "La hoja de estilos del sitio debe ser un archivo CSS")]
        [Display(Name = "Hoja de estilos")]
        public byte[] CSS { get; set; }
        [Required(ErrorMessage = "El mail del administrador es un campo obligatorio")]
        [DataType(DataType.EmailAddress, ErrorMessage = "La dirección de correo del administrador debe ser una dirección de correo válida")]
        [StringLength(128, ErrorMessage = "La dirección de correo del administrador del sitio debe tener como máximo {0} caracteres")]
        [Display(Name = "Correo electrónico del Administrador")]
        public string MailAdmin { get; set; }
        [Required(ErrorMessage = "El dominio es un campo obligatorio")]
        [DataType(DataType.Text)]
        [StringLength(128, ErrorMessage = "El dominio del sitio debe tener como máximo {0} caracteres")]
        [Display(Name = "Dominio")]
        public string URL { get; set; }
        [Required(ErrorMessage = "La cantidad de bienes populares es un campo obligatorio")]
        [DataType(DataType.Text)]
        [Display(Name = "Cantidad de bienes populares de la home")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad de bienes populares debe ser mayor que cero")]
        public short CantBienesPopulares { get; set; }
        [Required(ErrorMessage = "La cantidad de marcas inadecuadas máxima por contenido es un campo obligatorio")]
        [DataType(DataType.Text)]
        [Display(Name = "Cantidad máxima de marcas inadecuadas por contenido")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad de marcas inadecuadas máxima por contenido debe ser mayor que cero")]
        public short CantMarcasXCont { get; set; }
        [Required(ErrorMessage = "La cantidad máxima de contenidos bloqueados por usuario es un campo obligatorio")]
        [DataType(DataType.Text)]
        [Display(Name = "Cantidad máxima de contenidos bloqueados por usuario")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad máxima de contenidos bloqueados por usuario debe ser mayor que cero")]
        public short CantContBloqXUsu { get; set; }
        [Required(ErrorMessage = "La cantidad máxima de novedades de la home es un campo obligatorio")]
        [DataType(DataType.Text)]
        [Display(Name = "Cantidad máxima de novedades mostradas en la home")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad máxima de novedades de la home debe ser mayor que cero")]
        public short CantNovedadesHome { get; set; }
        [Required(ErrorMessage = "El porcentaje de aproximación de la wishlist es un campo obligatorio")]
        [DataType(DataType.Text)]
        [Display(Name = "Porcentaje de aproximación de un Wish")]
        [Range(0.1, double.MaxValue, ErrorMessage = "El porcentaje de aproximacion de la wishlist debe ser mayor que cero")]
        public short AproximacionWish { get; set; }
        // propiedades para el tipo de bien
        [Required(ErrorMessage = "El nombre del tipo de bien es un campo obligatorio")]
        [DataType(DataType.Text)]
        [StringLength(64, ErrorMessage = "El nombre del tipo de bien a arrendar en el sitio debe tener como máximo {0} caracteres")]
        [Display(Name = "Nombre del tipo de bien a arrendar")]
        public string NombreTipoBien { get; set; }
        [Display(Name = "Características específicas del bien")]
        public List<CaracteristicaEdicionDTO> Caracteristicas { get; set; }
        // propiedad para determinar el usuario propietario del sitio
        [Required(ErrorMessage = "El nombre del usuario propietario del sitio es un campo obligatorio")]
        [DataType(DataType.Text)]
        [StringLength(64, ErrorMessage = "El nombre de usuario del propietario del sitio debe tener como máximo {0} caracteres")]
        [Display(Name = "Nombre de usuario del propietario")]
        public string NombreUsuarioPropietario { get; set; }

    }
}
