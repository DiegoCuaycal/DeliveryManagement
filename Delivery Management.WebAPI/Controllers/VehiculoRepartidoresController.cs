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
    public class VehiculoRepartidoresController : ControllerBase
    {
        private readonly DeliveyAppDbContext _context;

        public VehiculoRepartidoresController(DeliveyAppDbContext context)
        {
            _context = context;
        }

        // GET: api/VehiculoRepartidores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehiculoRepartidor>>> GetVehiculoRepartidor()
        {
            return await _context
                .VehiculoRepartidor
                .Include(vr => vr.Repartidor)
                .Include(vr => vr.Vehiculo)
                .ToListAsync();
        }

        // GET: api/VehiculoRepartidores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehiculoRepartidor>> GetVehiculoRepartidor(int id)
        {
            var vehiculoRepartidor = await _context
                .VehiculoRepartidor
                .Include(vr => vr.Repartidor)
                .Include(vr => vr.Vehiculo)
                .FirstOrDefaultAsync(vr => vr.Id == id);
            //.FindAsync(id);

            if (vehiculoRepartidor == null)
            {
                return NotFound();
            }

            return vehiculoRepartidor;
        }

        // PUT: api/VehiculoRepartidores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehiculoRepartidor(int id, VehiculoRepartidor vehiculoRepartidor)
        {
            if (id != vehiculoRepartidor.Id)
            {
                return BadRequest();
            }

            _context.Entry(vehiculoRepartidor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiculoRepartidorExists(id))
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

        // POST: api/VehiculoRepartidores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VehiculoRepartidor>> PostVehiculoRepartidor(VehiculoRepartidor vehiculoRepartidor)
        {
            _context.VehiculoRepartidor.Add(vehiculoRepartidor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehiculoRepartidor", new { id = vehiculoRepartidor.Id }, vehiculoRepartidor);
        }

        // DELETE: api/VehiculoRepartidores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiculoRepartidor(int id)
        {
            var vehiculoRepartidor = await _context.VehiculoRepartidor.FindAsync(id);
            if (vehiculoRepartidor == null)
            {
                return NotFound();
            }

            _context.VehiculoRepartidor.Remove(vehiculoRepartidor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehiculoRepartidorExists(int id)
        {
            return _context.VehiculoRepartidor.Any(e => e.Id == id);
        }
    }
}

