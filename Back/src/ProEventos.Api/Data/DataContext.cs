using ProEventos.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ProEventos.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        
        public DbSet<Evento> Eventos { get; set; }
    }
}