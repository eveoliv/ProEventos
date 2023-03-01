using ProEventos.Domain;
using Microsoft.EntityFrameworkCore;

namespace ProEventos.Persistence
{
    public class ProEventosPersistence : IProEventosPersistence
    {
        private readonly ProEventosContext context;

        public ProEventosPersistence(ProEventosContext context)
        {
            this.context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            context.Add(entity);
        }
        
        public void Update<T>(T entity) where T : class
        {
            context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entity) where T : class
        {
            context.RemoveRange(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await context.SaveChangesAsync()) > 0;
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = context.Eventos.Include(e => e.Lotes).Include(r => r.RedesSociais);

            if (includePalestrantes)        
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(p => p.Palestrante);            
            
            query = query.OrderBy(i => i.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = context.Eventos.Include(e => e.Lotes).Include(r => r.RedesSociais);

            if (includePalestrantes)        
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(p => p.Palestrante);            
            
            query = query.OrderBy(i => i.Id).Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
               IQueryable<Evento> query = context.Eventos.Include(e => e.Lotes).Include(r => r.RedesSociais);

            if (includePalestrantes)        
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(p => p.Palestrante);            
            
            query = query.OrderBy(i => i.Id).Where(e => e.Id == eventoId);

            return await query.FirstOrDefaultAsync();
        }

        public Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos)
        {
            throw new NotImplementedException();
        }

        public Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            throw new NotImplementedException();
        }


        public Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos)
        {
            throw new NotImplementedException();
        }
    }
}