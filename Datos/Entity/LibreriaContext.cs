using Microsoft.EntityFrameworkCore;
using Negocio.Entidades;
using Negocio.EntidadesAuxiliares;

namespace Datos.Entity

{
    public class LibreriaContext : DbContext
    {
        
        public DbSet<Cabania> Cabania { get; set; }
        public DbSet<TipoCabania> TipoCabania { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Mantenimiento> Mantenimiento { get; set; }
        public DbSet<Parametro> Parametro { get; set; }

        public LibreriaContext(DbContextOptions<LibreriaContext> options) : base(options)
        {            
        }

        //EN ESTE LUGAR ES DONDE SE CONFIGURA EF USANDO FLUENT API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}
