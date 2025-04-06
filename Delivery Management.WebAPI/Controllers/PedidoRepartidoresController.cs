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
    public class PedidoRepartidoresController : ControllerBase
    {
        private readonly DeliveyAppDbContext _context;

        public PedidoRepartidoresController(DeliveyAppDbContext context)
        {
            _context = context;
        }

        // GET: api/PedidoRepartidores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoRepartidor>>> GetPedidoRepartidor()
        {
            return await _context.PedidoRepartidor.ToListAsync();
        }

        // GET: api/PedidoRepartidores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoRepartidor>> GetPedidoRepartidor(int id)
        {
            var pedidoRepartidor = await _context.PedidoRepartidor.FindAsync(id);

            if (pedidoRepartidor == null)
            {
                return NotFound();
            }

            return pedidoRepartidor;
        }

        // PUT: api/PedidoRepartidores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedidoRepartidor(int id, PedidoRepartidor pedidoRepartidor)
        {
            if (id != pedidoRepartidor.Id)
            {
                return BadRequest();
            }

            _context.Entry(pedidoRepartidor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoRepartidorExists(id))
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

        // POST: api/PedidoRepartidores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PedidoRepartidor>> PostPedidoRepartidor(PedidoRepartidor pedidoRepartidor)
        {
            _context.PedidoRepartidor.Add(pedidoRepartidor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedidoRepartidor", new { id = pedidoRepartidor.Id }, pedidoRepartidor);
        }

        // DELETE: api/PedidoRepartidores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedidoRepartidor(int id)
        {
            var pedidoRepartidor = await _context.PedidoRepartidor.FindAsync(id);
            if (pedidoRepartidor == null)
            {
                return NotFound();
            }

            _context.PedidoRepartidor.Remove(pedidoRepartidor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedidoRepartidorExists(int id)
        {
            return _context.PedidoRepartidor.Any(e => e.Id == id);
        }
    }
}
