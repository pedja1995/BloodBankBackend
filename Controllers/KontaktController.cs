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
    public class KontaktController : ControllerBase
    {
        private readonly mydbaContext _context;

        public KontaktController(mydbaContext context)
        {
            _context = context;
        }

        // GET: api/Kontakt
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kontakt>>> GetKontakt()
        {
            return await _context.Kontakt.ToListAsync();
        }

        // GET: api/Kontakt/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kontakt>> GetKontakt(int id)
        {
            var kontakt = await _context.Kontakt.FindAsync(id);

            if (kontakt == null)
            {
                return NotFound();
            }

            return kontakt;
        }

        // PUT: api/Kontakt/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKontakt(int id, Kontakt kontakt)
        {
            if (id != kontakt.KontaktId)
            {
                return BadRequest();
            }

            _context.Entry(kontakt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KontaktExists(id))
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

        // POST: api/Kontakt
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Kontakt>> PostKontakt(Kontakt kontakt)
        {
            _context.Kontakt.Add(kontakt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKontakt", new { id = kontakt.KontaktId }, kontakt);
        }

        // DELETE: api/Kontakt/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Kontakt>> DeleteKontakt(int id)
        {
            var kontakt = await _context.Kontakt.FindAsync(id);
            if (kontakt == null)
            {
                return NotFound();
            }

            _context.Kontakt.Remove(kontakt);
            await _context.SaveChangesAsync();

            return kontakt;
        }

        private bool KontaktExists(int id)
        {
            return _context.Kontakt.Any(e => e.KontaktId == id);
        }
    }
}
