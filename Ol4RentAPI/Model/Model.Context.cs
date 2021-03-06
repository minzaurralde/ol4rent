﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ModelContainer : DbContext
    {
        public ModelContainer()
            : base("name=ModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Sitio> Sitios { get; set; }
        public DbSet<OrigenDatos> OrigenesDatos { get; set; }
        public DbSet<Caracteristica> Caracteristicas { get; set; }
        public DbSet<Novedad> Novedades { get; set; }
        public DbSet<Bien> Bienes { get; set; }
        public DbSet<TipoBien> TiposBienes { get; set; }
        public DbSet<Contenido> Contenidos { get; set; }
        public DbSet<Adjunto> Adjuntos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ConfiguracionOrigenDatos> ConfiguracionesOrigenesDatos { get; set; }
        public DbSet<HabilitacionUsuario> HabilitacionesUsuarios { get; set; }
        public DbSet<BuzonMensajes> BuzonesMensajes { get; set; }
        public DbSet<Mensaje> Mensajes { get; set; }
        public DbSet<EspecificacionBien> EspecificacionesBienes { get; set; }
        public DbSet<ValorCaracteristica> ValoresCaracteristicas { get; set; }
        public DbSet<MeGusta> MeGusta { get; set; }
        public DbSet<Atributo> Atributos { get; set; }
        public DbSet<ValorAtributo> ValoresAtributos { get; set; }
        public DbSet<Sesion> Sesiones { get; set; }
        public DbSet<Dependencia> Dependencias { get; set; }
    }
}
