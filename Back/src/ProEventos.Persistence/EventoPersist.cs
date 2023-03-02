using ProEventos.Domain;
using Microsoft.EntityFrameworkCore;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
       public class EventoPersist : IEventoPersist
    {
        private readonly ProEventosContext context;

        public EventoPersist(ProEventosContext context)
        {
            this.context = context;
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = context.Eventos.Include(l => l.Lotes).Include(r => r.RedesSociais);

            if (includePalestrantes)        
                query = query.Include(p => p.PalestrantesEventos).ThenInclude(p => p.Palestrante);            
            
            query = query.OrderBy(i => i.Id);

            return await query.AsNoTracking().ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = context.Eventos.Include(l => l.Lotes).Include(r => r.RedesSociais);

            if (includePalestrantes)        
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(p => p.Palestrante);            
            
            query = query.OrderBy(i => i.Id).Where(t => t.Tema.ToLower().Contains(tema.ToLower()));

            return await query.AsNoTracking().ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = context.Eventos.Include(l => l.Lotes).Include(r => r.RedesSociais);

            if (includePalestrantes)        
                query = query.Include(p => p.PalestrantesEventos).ThenInclude(p => p.Palestrante);            
            
            query = query.OrderBy(i => i.Id).Where(e => e.Id == eventoId);

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }
    }
}