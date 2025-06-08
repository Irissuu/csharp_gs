using Microsoft.EntityFrameworkCore;
using FlowGuard.Entity;

namespace FlowGuard.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Regiao> Regioes { get; set; }
        public DbSet<Ocorrencia> Ocorrencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("USUARIO");
            modelBuilder.Entity<Regiao>().ToTable("REGIAO");
            modelBuilder.Entity<Ocorrencia>().ToTable("OCORRENCIA");

            modelBuilder.Entity<Ocorrencia>()
                .HasOne(o => o.Usuario)
                .WithMany(u => u.Ocorrencias)
                .HasForeignKey(o => o.UsuarioId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
