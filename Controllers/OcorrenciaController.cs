using FlowGuard.Application.Request;
using FlowGuard.Application.Response;
using FlowGuard.Entity;
using FlowGuard.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlowGuard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OcorrenciaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OcorrenciaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OcorrenciaResponseDTO>>> GetAll()
        {
            var ocorrencias = await _context.Ocorrencias
                .Select(o => new OcorrenciaResponseDTO
                {
                    Id = o.Id,
                    Descricao = o.Descricao,
                    Data = o.Data,
                    UsuarioId = o.UsuarioId
                })
                .ToListAsync();

            return Ok(ocorrencias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OcorrenciaResponseDTO>> GetById(int id)
        {
            var ocorrencia = await _context.Ocorrencias.FindAsync(id);
            if (ocorrencia == null)
                return NotFound(new { mensagem = "Ocorrência não encontrada." });

            var response = new OcorrenciaResponseDTO
            {
                Id = ocorrencia.Id,
                Descricao = ocorrencia.Descricao,
                Data = ocorrencia.Data,
                UsuarioId = ocorrencia.UsuarioId
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<OcorrenciaResponseDTO>> Create([FromBody] OcorrenciaRequestDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ocorrencia = new Ocorrencia
            {
                Descricao = dto.Descricao,
                Data = dto.Data,
                UsuarioId = dto.UsuarioId
            };

            _context.Ocorrencias.Add(ocorrencia);
            await _context.SaveChangesAsync();

            var response = new OcorrenciaResponseDTO
            {
                Id = ocorrencia.Id,
                Descricao = ocorrencia.Descricao,
                Data = ocorrencia.Data,
                UsuarioId = ocorrencia.UsuarioId
            };

            return CreatedAtAction(nameof(GetById), new { id = ocorrencia.Id }, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var ocorrencia = await _context.Ocorrencias.FindAsync(id);
            if (ocorrencia == null)
                return NotFound(new { mensagem = "Ocorrência não encontrada." });

            _context.Ocorrencias.Remove(ocorrencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
