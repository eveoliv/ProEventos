using ProEventos.Domain;
using Microsoft.EntityFrameworkCore;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
       public class PalestrantePersist : IPalestrantePersist
    {
        private readonly ProEventosContext context;

        public PalestrantePersist(ProEventosContext context)
        {
            this.context = context;
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = context.Palestrantes.Include(r => r.RedesSociais);

            if (includeEventos)        
                query = query.Include(p => p.PalestrantesEventos).ThenInclude(p => p.Evento);            
            
            query = query.OrderBy(i => i.Id);

            return await query.AsNoTracking().ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = context.Palestrantes.Include(r => r.RedesSociais);

            if (includeEventos)        
                query = query.Include(p => p.PalestrantesEventos).ThenInclude(e => e.Evento);            
            
            query = query.OrderBy(i => i.Id).Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.AsNoTracking().ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
                IQueryable<Palestrante> query = context.Palestrantes.Include(r => r.RedesSociais);

            if (includeEventos)        
                query = query.Include(p => p.PalestrantesEventos).ThenInclude(e => e.Evento);            
            
            query = query.OrderBy(i => i.Id).Where(p => p.Id == palestranteId);

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }
    }
}