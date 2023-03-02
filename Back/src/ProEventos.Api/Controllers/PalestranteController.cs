using System;
using ProEventos.Domain;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ProEventos.Application.Contratos;

namespace ProEventos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PalestranteController : ControllerBase
    {
        private readonly IPalestranteService service;

        public PalestranteController(IPalestranteService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var palestrante = await service.GetAllPalestrantesAsync(true);
                if(palestrante == null) return NotFound("Nenhum palestrante encontrado.");

                return Ok(palestrante);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar palestrante. Erro {ex.Message}");
            }
        }
    
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var palestrante = await service.GetPalestranteByIdAsync(id, true);
                if(palestrante == null) return NotFound("Nenhum palestrante por id encontrado.");

                return Ok(palestrante);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar palestrante. Erro {ex.Message}");
            }
        }       
       
        [HttpGet("{nome}/nome")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            try
            {
                var palestrante = await service.GetAllPalestrantesByNomeAsync(nome, true);
                if(palestrante == null) return NotFound("Nenhum evento por tema encontrado.");

                return Ok(palestrante);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar palestrante por nome. Erro {ex.Message}");
            }
        }    

        [HttpPost]
        public async Task<IActionResult> Post(Palestrante model)
        {
         try
            {
                var palestrante = await service.AddPalestrantes(model);
                if(palestrante == null) return BadRequest("Erro ao adicionar palestrante.");

                return Ok(palestrante);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adicionar palestrante. Erro {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Palestrante model)
        {
            try
            {
                var palestrante = await service.UpdatePalestrante(id, model);
                if(palestrante == null) return BadRequest("Erro ao editar palestrante.");

                return Ok(palestrante);
            }
            catch (Exception ex)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar palestrante. Erro {ex.Message}");
            }
        }   

       [HttpDelete("{id}")]
       public async Task<IActionResult> Delete(int id)
       {
           try
           {
               return await service.DeletePalestrante(id) ? Ok("Deletato") : BadRequest("Palestrante não deletado");
           }
           catch (Exception ex)
           {                
               return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar excluir palestrante. Erro {ex.Message}");
           }
        }
    }
}