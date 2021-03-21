using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendAPI.Models;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RadnikController : ControllerBase
    {
        private readonly mydbaContext _context;

        public RadnikController(mydbaContext context)
        {
            _context = context;
        }

        // GET: api/Radnik
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Radnik>>> GetRadnik()
        {
            return await _context.Radnik.ToListAsync();
        }

        // GET: api/Radnik/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Radnik>> GetRadnik(int id)
        {
            var radnik = await _context.Radnik.FindAsync(id);

            if (radnik == null)
            {
                return NotFound();
            }

            return radnik;
        }

        // PUT: api/Radnik/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRadnik(int id, Radnik radnik)
        {
            if (id != radnik.RadnikId)
            {
                return BadRequest();
            }

            _context.Entry(radnik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RadnikExists(id))
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

        // POST: api/Radnik
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Radnik>> PostRadnik(Radnik radnik)
        {
            _context.Radnik.Add(radnik);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRadnik", new { id = radnik.RadnikId }, radnik);
        }

        // DELETE: api/Radnik/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Radnik>> DeleteRadnik(int id)
        {
            var radnik = await _context.Radnik.FindAsync(id);
            if (radnik == null)
            {
                return NotFound();
            }

            _context.Radnik.Remove(radnik);
            await _context.SaveChangesAsync();

            return radnik;
        }

        private bool RadnikExists(int id)
        {
            return _context.Radnik.Any(e => e.RadnikId == id);
        }
    }
}
