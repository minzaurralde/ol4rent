using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OL4RENT.Models
{
    public class BienContext : DbContext
    {
        public BienContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Bien> UserProfiles { get; set; }
    }

    [Table("Bien")]
    public class Bien
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Nombre { get; set; }
    }
}