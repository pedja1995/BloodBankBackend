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
    public class IsporukaController : ControllerBase
    {
        private readonly mydbaContext _context;

        public IsporukaController(mydbaContext context)
        {
            _context = context;
        }

        // GET: api/Isporuka
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Isporuka>>> GetIsporuka()
        {
            return await _context.Isporuka.ToListAsync();
        }

        // GET: api/Isporuka/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Isporuka>> GetIsporuka(int id)
        {
            var isporuka = await _context.Isporuka.FindAsync(id);

            if (isporuka == null)
            {
                return NotFound();
            }

            return isporuka;
        }

        // PUT: api/Isporuka/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIsporuka(int id, Isporuka isporuka)
        {
            if (id != isporuka.IsporukaId)
            {
                return BadRequest();
            }

            _context.Entry(isporuka).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IsporukaExists(id))
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

        // POST: api/Isporuka
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Isporuka>> PostIsporuka(Isporuka isporuka)
        {
            _context.Isporuka.Add(isporuka);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIsporuka", new { id = isporuka.IsporukaId }, isporuka);
        }

        // DELETE: api/Isporuka/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Isporuka>> DeleteIsporuka(int id)
        {
            var isporuka = await _context.Isporuka.FindAsync(id);
            if (isporuka == null)
            {
                return NotFound();
            }

            _context.Isporuka.Remove(isporuka);
            await _context.SaveChangesAsync();

            return isporuka;
        }

        private bool IsporukaExists(int id)
        {
            return _context.Isporuka.Any(e => e.IsporukaId == id);
        }
    }
}
