using ProEventos.Domain;
using ProEventos.Application.Contratos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class PalestranteService : IPalestranteService
    {
        private readonly IGeralPersist persistence;
        private readonly IPalestrantePersist palestrantePersist;

        public PalestranteService(IGeralPersist persistence, IPalestrantePersist palestrantePersist)
        {
            this.persistence = persistence;
            this.palestrantePersist = palestrantePersist;
        }

        public async Task<Palestrante> AddPalestrantes(Palestrante model)
        {
              try
            {
                persistence.Add<Palestrante>(model);
                
                if (await persistence.SaveChangesAsync())
                 return await palestrantePersist.GetPalestranteByIdAsync(model.Id, false);

                return null;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message); 
            }
        }

        public async Task<Palestrante> UpdatePalestrante(int palestranteId, Palestrante model)
        {
            try
            {
                var palestrante =  await palestrantePersist.GetPalestranteByIdAsync(palestranteId, false);
                if (palestrante == null) return null;

                model.Id = palestrante.Id;

                persistence.Update(model);
                if (await persistence.SaveChangesAsync())            
                    return await palestrantePersist.GetPalestranteByIdAsync(model.Id, false);
                
                return null;
            }
            catch (Exception ex)
            {            
                throw new Exception(ex.Message);
            }   
        }

        public async Task<bool> DeletePalestrante(int palestranteId)
        {
             try
            {
                var palestrante =  await palestrantePersist.GetPalestranteByIdAsync(palestranteId, false);
                if (palestrante == null) throw new Exception("palestrante não encontrado");

                persistence.Delete<Palestrante>(palestrante);
                return (await persistence.SaveChangesAsync());                              
            }
            catch (Exception ex)
            {            
                throw new Exception(ex.Message);
            }          
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {           
            try
            {
                var palestrantes = await palestrantePersist.GetAllPalestrantesAsync(includeEventos);
                if (palestrantes == null) return null;
                
                return palestrantes;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            try
            {
                var palestrante = await palestrantePersist.GetAllPalestrantesByNomeAsync(nome, includeEventos);
                if (palestrante == null) return null;
                
                return palestrante;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            try
            {
                var palestrantes = await palestrantePersist.GetPalestranteByIdAsync(palestranteId, includeEventos);
                if (palestrantes == null) return null;
                
                return palestrantes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}