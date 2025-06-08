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
    public class RegiaoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RegiaoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegiaoResponseDTO>>> GetAll()
        {
            var regioes = await _context.Regioes
                .Select(r => new RegiaoResponseDTO
                {
                    Id = r.Id,
                    Estado = r.Estado,
                    Distrito = r.Distrito
                })
                .ToListAsync();

            return Ok(regioes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RegiaoResponseDTO>> GetById(int id)
        {
            var regiao = await _context.Regioes.FindAsync(id);

            if (regiao == null)
                return NotFound(new { mensagem = "Região não encontrada." });

            var response = new RegiaoResponseDTO
            {
                Id = regiao.Id,
                Estado = regiao.Estado,
                Distrito = regiao.Distrito
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<RegiaoResponseDTO>> Create([FromBody] RegiaoRequestDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var regiao = new Regiao
            {
                Estado = dto.Estado,
                Distrito = dto.Distrito
            };

            _context.Regioes.Add(regiao);
            await _context.SaveChangesAsync();

            var response = new RegiaoResponseDTO
            {
                Id = regiao.Id,
                Estado = regiao.Estado,
                Distrito = regiao.Distrito
            };

            return CreatedAtAction(nameof(GetById), new { id = regiao.Id }, response);
        }
    }
}
