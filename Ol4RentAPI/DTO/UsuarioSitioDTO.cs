using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.DTO
{
    public class UsuarioSitioDTO
    {
        [Display(Name = "Identificador del usuario")]
        public int Id { get; set; }
        [Display(Name = "Nombre de usuario")]
        public string NombreUsuario { get; set; }
        [Display(Name = "Nombre completo")]
        public string NombreCompleto { get; set; }
        [Display(Name = "Correo electrónico")]
        public string Correo { get; set; }
        [Display(Name = "Habilitado")]
        public bool Habilitado { get; set; }
        [Display(Name = "Cantidad de contenidos bloqueados")]
        public int CantidadContenidosBloqueados { get; set; }
    }
}
