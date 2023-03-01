using System.Linq;
using ProEventos.Domain;
using ProEventos.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ProEventos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {

      private readonly ProEventosContext _context;

        public EventosController(ProEventosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }

        [HttpGet("{id}")]
        public Evento Get(int id)
        {
            return _context.Eventos.FirstOrDefault(e => e.Id == id);
        }

        [HttpPost]
        public Evento Post(Evento e)
        {
            var novo = new Evento(){
               Local = e.Local,
               DataEvento = e.DataEvento,
               Tema = e.Tema,
               QtdPessoas = e.QtdPessoas,        
               ImagemURL = e.ImagemURL    
            };

            _context.Add(novo);
            _context.SaveChanges();

            return novo;
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de Put id = {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Exemplo de Delete id = {id}";
        }
    }
}
