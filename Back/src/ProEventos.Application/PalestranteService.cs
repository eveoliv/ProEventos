using ProEventos.Domain;
using ProEventos.Application.Contratos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class PalestranteService : IPalestranteService
    {
        private readonly IGeralPersist persistence;
       
        public PalestranteService(IGeralPersist persistence)
        {
            this.persistence = persistence;
           
        }

        public Task<Palestrante> AddPalestrantes(Palestrante model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePalestrante(int palestranteId)
        {
            throw new NotImplementedException();
        }

        public Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
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

        public Task<Palestrante> UpdatePalestrante(int palestranteId, Palestrante model)
        {
            throw new NotImplementedException();
        }
    }
}