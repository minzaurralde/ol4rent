using Ol4RentAPI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.DTO
{
    public class ContenidoDTO
    {
        public int Id { get; set; }
        [Display(Name = "Contenido")]
        public string Mensaje { get; set; }
        [Display(Name = "Cantidad de marcas")]
        public short CantMarcas { get; set; }
        [Display(Name = "Tiene adjuntos")]
        public int CantAdjuntos { get; set; }
        [Display(Name="Nombre de usuario")]
        public string NombreUsuario { get; set; }
        public BienEdicionDTO Bien { get; set; }
    }

    public class ComentarioAltaDTO
    {
        public int IdBien { get; set; }
        [Display(Name = "Nombre de usuario")]
        public string NombreUsuario { get; set; }
        public string Texto { get; set; }
        public List<AdjuntoDTO> Adjuntos { get; set; }
    }

    public class AdjuntoDTO
    {
        public string Nombre { get; set; }
        public byte[] Contenido { get; set; }
        public TipoAdjunto Tipo { get; set; }
    }

}
