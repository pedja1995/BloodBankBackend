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
    public class LjekarskiPregledController : ControllerBase
    {
        private readonly mydbaContext _context;

        public LjekarskiPregledController(mydbaContext context)
        {
            _context = context;
        }

        // GET: api/LjekarskiPregled
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LjekarskiPregled>>> GetLjekarskiPregled()
        {
            return await _context.LjekarskiPregled.ToListAsync();
        }

        // GET: api/LjekarskiPregled/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LjekarskiPregled>> GetLjekarskiPregled(int id)
        {
            var ljekarskiPregled = await _context.LjekarskiPregled.FindAsync(id);

            if (ljekarskiPregled == null)
            {
                return NotFound();
            }

            return ljekarskiPregled;
        }

        // PUT: api/LjekarskiPregled/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLjekarskiPregled(int id, LjekarskiPregled ljekarskiPregled)
        {
            if (id != ljekarskiPregled.LjekarskiPregledId)
            {
                return BadRequest();
            }

            _context.Entry(ljekarskiPregled).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LjekarskiPregledExists(id))
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

        // POST: api/LjekarskiPregled
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LjekarskiPregled>> PostLjekarskiPregled(LjekarskiPregled ljekarskiPregled)
        {
            _context.LjekarskiPregled.Add(ljekarskiPregled);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLjekarskiPregled", new { id = ljekarskiPregled.LjekarskiPregledId }, ljekarskiPregled);
        }

        // DELETE: api/LjekarskiPregled/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LjekarskiPregled>> DeleteLjekarskiPregled(int id)
        {
            var ljekarskiPregled = await _context.LjekarskiPregled.FindAsync(id);
            if (ljekarskiPregled == null)
            {
                return NotFound();
            }

            _context.LjekarskiPregled.Remove(ljekarskiPregled);
            await _context.SaveChangesAsync();

            return ljekarskiPregled;
        }

        private bool LjekarskiPregledExists(int id)
        {
            return _context.LjekarskiPregled.Any(e => e.LjekarskiPregledId == id);
        }
    }
}
