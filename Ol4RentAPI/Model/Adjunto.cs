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
    
    public partial class Adjunto
    {
        public int Id { get; set; }
        public byte[] Data { get; set; }
        public string NombreArchivo { get; set; }
        public string Formato { get; set; }
        public TipoAdjunto Tipo { get; set; }
    }
}
