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
    public class PotraznjaController : ControllerBase
    {
        private readonly mydbaContext _context;

        public PotraznjaController(mydbaContext context)
        {
            _context = context;
        }

        // GET: api/Potraznja
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Potraznja>>> GetPotraznja()
        {
            return await _context.Potraznja.ToListAsync();
        }

        // GET: api/Potraznja/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Potraznja>> GetPotraznja(int id)
        {
            var potraznja = await _context.Potraznja.FindAsync(id);

            if (potraznja == null)
            {
                return NotFound();
            }

            return potraznja;
        }

        // PUT: api/Potraznja/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPotraznja(int id, Potraznja potraznja)
        {
            if (id != potraznja.PotraznjaId)
            {
                return BadRequest();
            }

            _context.Entry(potraznja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PotraznjaExists(id))
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

        // POST: api/Potraznja
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Potraznja>> PostPotraznja(Potraznja potraznja)
        {
            _context.Potraznja.Add(potraznja);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPotraznja", new { id = potraznja.PotraznjaId }, potraznja);
        }

        // DELETE: api/Potraznja/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Potraznja>> DeletePotraznja(int id)
        {
            var potraznja = await _context.Potraznja.FindAsync(id);
            if (potraznja == null)
            {
                return NotFound();
            }

            _context.Potraznja.Remove(potraznja);
            await _context.SaveChangesAsync();

            return potraznja;
        }

        private bool PotraznjaExists(int id)
        {
            return _context.Potraznja.Any(e => e.PotraznjaId == id);
        }
    }
}
