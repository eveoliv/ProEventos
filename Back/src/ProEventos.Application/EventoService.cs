using ProEventos.Domain;
using ProEventos.Application.Contratos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist persistence;
        private readonly IEventoPersist eventoPersistence;

        public EventoService(IGeralPersist persistence, IEventoPersist eventoPersistence)
        {
            this.persistence = persistence;
            this.eventoPersistence = eventoPersistence;
        }

        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                persistence.Add<Evento>(model);
                
                if (await persistence.SaveChangesAsync())
                 return await eventoPersistence.GetEventoByIdAsync(model.Id, false);

                return null;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message); 
            }
        }

        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                var evento =  await eventoPersistence.GetEventoByIdAsync(eventoId, false);
                if (evento == null) return null;

                model.Id = evento.Id;

                persistence.Update(model);
                if (await persistence.SaveChangesAsync())            
                    return await eventoPersistence.GetEventoByIdAsync(model.Id, false);
                
                return null;
            }
            catch (Exception ex)
            {            
                throw new Exception(ex.Message);
            }            
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento =  await eventoPersistence.GetEventoByIdAsync(eventoId, false);
                if (evento == null) throw new Exception("Evento não encontrado");

                persistence.Delete<Evento>(evento);
                return (await persistence.SaveChangesAsync());                              
            }
            catch (Exception ex)
            {            
                throw new Exception(ex.Message);
            }          
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await eventoPersistence.GetAllEventosAsync(includePalestrantes);
                if (eventos == null) return null;
                
                return eventos;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                 var eventos = await eventoPersistence.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if (eventos == null) return null;
                
                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                 var eventos = await eventoPersistence.GetEventoByIdAsync(eventoId, includePalestrantes);
                if (eventos == null) return null;
                
                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}