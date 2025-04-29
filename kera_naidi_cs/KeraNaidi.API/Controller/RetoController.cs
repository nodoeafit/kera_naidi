using KeraNaidi.Data;
using KeraNaidi.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Quetzalcoatl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RetoController : ControllerBase
    {
        private readonly KeraNaidiContext _context;

        public RetoController(KeraNaidiContext context)
        {
            _context = context;
        }

        // GET: api/reto/evento/5
        [HttpGet("evento/{eventoId}")]
        public async Task<IActionResult> GetRetosPorEvento(int eventoId)
        {
            var retos = await _context.Retos
                .Include(r => r.Preguntas)
                .Where(r => r.EventoId == eventoId)
                .ToListAsync();

            return Ok(retos);
        }

        // GET: api/reto/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReto(int id)
        {
            var reto = await _context.Retos
                .Include(r => r.Preguntas)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reto == null)
                return NotFound();
            return Ok(reto);
        }

        // POST: api/reto
        [HttpPost]
        public async Task<IActionResult> CrearReto([FromBody] Reto reto)
        {
            _context.Retos.Add(reto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetReto), new { id = reto.Id }, reto);
        }

        // PUT: api/reto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditarReto(int id, [FromBody] Reto reto)
        {
            var existente = await _context.Retos.Include(r => r.Preguntas).FirstOrDefaultAsync(r => r.Id == id);
            if (existente == null)
                return NotFound();

            existente.Nombre = reto.Nombre;
            existente.Descripcion = reto.Descripcion;
            existente.EventoId = reto.EventoId;
            existente.Preguntas = reto.Preguntas;

            await _context.SaveChangesAsync();
            return Ok(existente);
        }

        // DELETE: api/reto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarReto(int id)
        {
            var reto = await _context.Retos.FindAsync(id);
            if (reto == null)
                return NotFound();

            _context.Retos.Remove(reto);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
