using ProEventos.Domain;
using Microsoft.EntityFrameworkCore;

namespace ProEventos.Persistence
{
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options){}
        
        public DbSet<Lote>? Lotes { get; set; }
        public DbSet<Evento>? Eventos { get; set; }
        public DbSet<RedeSocial>? RedesSociais { get; set; }
        public DbSet<Palestrante>? Palestrantes { get; set; }
        public DbSet<PalestranteEvento>? PalestrantesEventos { get; set; }
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PalestranteEvento>().HasKey(p => new{p.EventoId, p.PalestranteId});
        }
    }
}