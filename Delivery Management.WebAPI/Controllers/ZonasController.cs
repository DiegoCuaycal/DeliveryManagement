using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeliveryManagement;

namespace Delivery_Management.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZonasController : ControllerBase
    {
        private readonly DeliveyAppDbContext _context;

        public ZonasController(DeliveyAppDbContext context)
        {
            _context = context;
        }

        // GET: api/Zonas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zona>>> GetZona()
        {
            return await _context
                .Zona
                .Include(z => z.Pedidos)
                .ToListAsync();
        }

        // GET: api/Zonas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Zona>> GetZona(int id)
        {
            var zona = await _context
                .Zona
                .Include(z => z.Pedidos)
                .FirstOrDefaultAsync(z => z.Id == id);

            if (zona == null)
            {
                return NotFound();
            }

            return zona;
        }

        // PUT: api/Zonas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZona(int id, Zona zona)
        {
            if (id != zona.Id)
            {
                return BadRequest();
            }

            _context.Entry(zona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZonaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        /*
        // POST: api/Zonas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Zona>> PostZona(Zona zona)
        {
            _context.Zona.Add(zona);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZona", new { id = zona.Id }, zona);
        }
        */
        [HttpPost]
        public async Task<ActionResult<Zona>> PostZona(Zona zona)
        {
            if (zona == null)
            {
                return BadRequest("Los datos enviados son nulos.");
            }

            Console.WriteLine($"Recibido: Id={zona.Id}, Nombre={zona.Nombre}");

            _context.Zona.Add(zona);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al guardar en la base de datos: {ex.Message}");
            }

            return CreatedAtAction("GetZona", new { id = zona.Id }, zona);
        }


        // DELETE: api/Zonas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZona(int id)
        {
            var zona = await _context.Zona.FindAsync(id);
            if (zona == null)
            {
                return NotFound();
            }

            _context.Zona.Remove(zona);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ZonaExists(int id)
        {
            return _context.Zona.Any(e => e.Id == id);
        }
    }
}
