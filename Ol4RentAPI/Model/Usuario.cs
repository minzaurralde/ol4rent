//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ol4RentAPI.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
    {
        public Usuario()
        {
            this.SitiosAdministrados = new HashSet<Sitio>();
            this.BuzonesMensajes = new HashSet<BuzonMensajes>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string UsuarioFacebook { get; set; }
        public string UsuarioTwitter { get; set; }
    
        public virtual ICollection<Sitio> SitiosAdministrados { get; set; }
        public virtual ICollection<BuzonMensajes> BuzonesMensajes { get; set; }
    }
}
