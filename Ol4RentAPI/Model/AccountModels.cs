using Ol4RentAPI.Model.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace Ol4RentAPI.Model
{
    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required(ErrorMessage = "El nombre de usuario es un campo obligatorio")]
        [Display(Name = "Nombre de usuario")]
        [StringLength(64, ErrorMessage = "El {0} debe tener como máximo {1} caracteres.", MinimumLength = 1)]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "La contraseña es un campo obligatorio")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "La {0} debe tener como máximo {1} caracteres.", MinimumLength = 6)]
        [Display(Name = "Contraseña")]
        public string Contraseña { get; set; }

        [Display(Name = "Recordar?")]
        public bool RememberMe { get; set; }

        public int IdSitio { get; set; }
    }

    public class RegisterModel
    {

        [Required(ErrorMessage="El Nombre es un campo obligatorio")]
        [Display(Name="Nombre")]
        [StringLength(64,ErrorMessage = "El {0} debe tener como máximo {1} caracteres.", MinimumLength = 1)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido es un campo obligatorio")]
        [Display(Name = "Apellido")]
        [StringLength(64, ErrorMessage = "El {0} debo tener como máximo {1} caracteres.", MinimumLength = 1)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El Mail es un campo obligatorio")]
        [Display(Name = "Mail")]
        [StringLength(64, ErrorMessage = "EL {0} debe tener como máximo {1} caracteres.", MinimumLength = 1)]
        public string Mail { get; set; }

        [Required(ErrorMessage="El Usuario es un campo obligatorio")]
        [Display(Name = "Usuario")]
        [StringLength(64, ErrorMessage = "El {0} debe tener como máximo {1} caracteres.", MinimumLength = 1)]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage="La Contraseña es un campo obligatorio")]
        [StringLength(100, ErrorMessage = "La {0} debe tener como máximo {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contraseña { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Contraseña", ErrorMessage = "La contraseña no coincide con su confirmación.")]
        public string ConfirmPassword { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
