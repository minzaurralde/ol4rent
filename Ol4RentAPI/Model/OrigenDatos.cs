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
    
    public partial class OrigenDatos
    {
        public OrigenDatos()
        {
            this.Atributos = new HashSet<Atributo>();
            this.Dependencias = new HashSet<Dependencia>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public byte[] Manejador { get; set; }
    
        public virtual ICollection<Atributo> Atributos { get; set; }
        public virtual ICollection<Dependencia> Dependencias { get; set; }
    }
}
