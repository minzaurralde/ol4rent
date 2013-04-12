using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OL4RENT.Models
{
    public class SitioContext : DbContext
    {
        public SitioContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Sitio> Sitios { get; set; }
    }

    [Table("Sitio")]
    public class Sitio
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Nombre { get; set; }
    }
}