using System.Net.Mime;
using Entity_Framework.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework.Database
{
    public class HeroeDbContext : DbContext
    {
        public HeroeDbContext(DbContextOptions<HeroeDbContext> options) : base(options)
        {}

        public DbSet<Heroe> Heroes { get; set; }
        public DbSet<Imagen> Imagenes { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<OrdenHeroe> OrdenesHeroes { get; set; }
        public DbSet<Universo> Universos { get; set; } 
    }
}