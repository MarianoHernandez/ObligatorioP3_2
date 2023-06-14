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
            modelBuilder.Entity<Cabania>().OwnsOne(C => C.Nombre).HasIndex(C => C.Value).IsUnique();
            modelBuilder.Entity<Cabania>().OwnsOne(C => C.Descripcion).HasIndex(C => C.Value);
            modelBuilder.Entity<Mantenimiento>().OwnsOne(M => M.descripcion).HasIndex(M => M.Value);
            modelBuilder.Entity<TipoCabania>().OwnsOne(T => T.Descripcion).HasIndex(T => T.Value);



            base.OnModelCreating(modelBuilder);
        }
    }

}
