using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProEventos.Api.Models;

namespace ProEventos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {

        public IEnumerable<Evento> lista = new Evento[]{
            new Evento{
                    EventoId = 1,
                    Tema = "Dotnet e Angular",
                    Local = "São Paulo",
                    Lote="1º Lote",
                    QtdPessoas = 20,
                    DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
                    ImagemURL = "Foto.jpg"
                    },
            new Evento{
                    EventoId = 2,
                    Tema = "Dotnet e Angular 2",
                    Local = "São Paulo",
                    Lote="2º Lote",
                    QtdPessoas = 20,
                    DataEvento = DateTime.Now.AddDays(6).ToString("dd/MM/yyyy"),
                    ImagemURL = "Foto.jpg"
                    }            
        };    

        public EventoController()
        {            
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return lista;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> Get(int id)
        {
            return lista.Where(e => e.EventoId == id);
        }

        [HttpPost]
        public string Post()
        {
            return "Exemplo de Post";
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
