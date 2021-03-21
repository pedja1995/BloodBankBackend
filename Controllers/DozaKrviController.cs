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
    public class DozaKrviController : ControllerBase
    {
        private readonly mydbaContext _context;

        public DozaKrviController(mydbaContext context)
        {
            _context = context;
        }

        // GET: api/DozaKrvi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DozaKrvi>>> GetDozaKrvi()
        {
            return await _context.DozaKrvi.ToListAsync();
        }

        // GET: api/DozaKrvi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DozaKrvi>> GetDozaKrvi(int id)
        {
            var dozaKrvi = await _context.DozaKrvi.FindAsync(id);

            if (dozaKrvi == null)
            {
                return NotFound();
            }

            return dozaKrvi;
        }

        // PUT: api/DozaKrvi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDozaKrvi(int id, DozaKrvi dozaKrvi)
        {
            if (id != dozaKrvi.DozaKrviId)
            {
                return BadRequest();
            }

            _context.Entry(dozaKrvi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DozaKrviExists(id))
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

        // POST: api/DozaKrvi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DozaKrvi>> PostDozaKrvi(DozaKrvi dozaKrvi)
        {
            _context.DozaKrvi.Add(dozaKrvi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDozaKrvi", new { id = dozaKrvi.DozaKrviId }, dozaKrvi);
        }

        // DELETE: api/DozaKrvi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DozaKrvi>> DeleteDozaKrvi(int id)
        {
            var dozaKrvi = await _context.DozaKrvi.FindAsync(id);
            if (dozaKrvi == null)
            {
                return NotFound();
            }

            _context.DozaKrvi.Remove(dozaKrvi);
            await _context.SaveChangesAsync();

            return dozaKrvi;
        }

        private bool DozaKrviExists(int id)
        {
            return _context.DozaKrvi.Any(e => e.DozaKrviId == id);
        }
    }
}
