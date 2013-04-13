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
    public class BienContext : DbContext
    {
        public BienContext()
            : base(DBHelper.Connection)
        {
        }

        public DbSet<Bien> Bienes { get; set; }
    }

    [Table("Bien")]
    public class Bien
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [MaxLength(128)]
        public string Nombre { get; set; }
        [MaxLength(1024)]
        public string Descripcion { get; set; }
        public int CantidadLikes { get; set; }

        public Bien()
        {
            CantidadLikes = 0;
        }

        public Bien(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            CantidadLikes = 0;
        }
    }
}