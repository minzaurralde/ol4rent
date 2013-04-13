using OL4RENT.Models.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OL4RENT.Models
{
    public class NovedadContext : DbContext
    {
        public NovedadContext()
            : base(DBHelper.Connection)
        {
        }

        public DbSet<Novedad> Novedades { get; set; }
    }

    [Table("Novedad")]
    public class Novedad
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [MaxLength(128)]
        public string Nombre { get; set; }
    }
}