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
    public class RepartidoresController : ControllerBase
    {
        private readonly DeliveyAppDbContext _context;

        public RepartidoresController(DeliveyAppDbContext context)
        {
            _context = context;
        }

        // GET: api/Repartidores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Repartidor>>> GetRepartidor()
        {
            return await _context
                .Repartidor
                .Include(r => r.Pedidos)
                .Include(r => r.VehiculoRepartidores)
                .ToListAsync();
        }

        // GET: api/Repartidores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Repartidor>> GetRepartidor(int id)
        {
            var repartidor = await _context
                .Repartidor
                .Include(r => r.Pedidos)
                .Include(r => r.VehiculoRepartidores)
                .FirstOrDefaultAsync(r => r.Id == id);
            //   .FindAsync(id);

            if (repartidor == null)
            {
                return NotFound();
            }

            return repartidor;
        }

        // PUT: api/Repartidores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepartidor(int id, Repartidor repartidor)
        {
            if (id != repartidor.Id)
            {
                return BadRequest();
            }

            _context.Entry(repartidor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepartidorExists(id))
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

        // POST: api/Repartidores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Repartidor>> PostRepartidor(Repartidor repartidor)
        {
            _context.Repartidor.Add(repartidor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRepartidor", new { id = repartidor.Id }, repartidor);
        }

        // DELETE: api/Repartidores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepartidor(int id)
        {
            var repartidor = await _context.Repartidor.FindAsync(id);
            if (repartidor == null)
            {
                return NotFound();
            }

            _context.Repartidor.Remove(repartidor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RepartidorExists(int id)
        {
            return _context.Repartidor.Any(e => e.Id == id);
        }
    }
}
