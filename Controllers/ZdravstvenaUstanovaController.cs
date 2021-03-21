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
    public class ZdravstvenaUstanovaController : ControllerBase
    {
        private readonly mydbaContext _context;

        public ZdravstvenaUstanovaController(mydbaContext context)
        {
            _context = context;
        }

        // GET: api/ZdravstvenaUstanova
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ZdravstvenaUstanova>>> GetZdravstvenaUstanova()
        {
            return await _context.ZdravstvenaUstanova.ToListAsync();
        }

        // GET: api/ZdravstvenaUstanova/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ZdravstvenaUstanova>> GetZdravstvenaUstanova(int id)
        {
            var zdravstvenaUstanova = await _context.ZdravstvenaUstanova.FindAsync(id);

            if (zdravstvenaUstanova == null)
            {
                return NotFound();
            }

            return zdravstvenaUstanova;
        }

        // PUT: api/ZdravstvenaUstanova/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZdravstvenaUstanova(int id, ZdravstvenaUstanova zdravstvenaUstanova)
        {
            if (id != zdravstvenaUstanova.ZdravstvenaUstanovaId)
            {
                return BadRequest();
            }

            _context.Entry(zdravstvenaUstanova).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZdravstvenaUstanovaExists(id))
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

        // POST: api/ZdravstvenaUstanova
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ZdravstvenaUstanova>> PostZdravstvenaUstanova(ZdravstvenaUstanova zdravstvenaUstanova)
        {
            _context.ZdravstvenaUstanova.Add(zdravstvenaUstanova);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZdravstvenaUstanova", new { id = zdravstvenaUstanova.ZdravstvenaUstanovaId }, zdravstvenaUstanova);
        }

        // DELETE: api/ZdravstvenaUstanova/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ZdravstvenaUstanova>> DeleteZdravstvenaUstanova(int id)
        {
            var zdravstvenaUstanova = await _context.ZdravstvenaUstanova.FindAsync(id);
            if (zdravstvenaUstanova == null)
            {
                return NotFound();
            }

            _context.ZdravstvenaUstanova.Remove(zdravstvenaUstanova);
            await _context.SaveChangesAsync();

            return zdravstvenaUstanova;
        }

        private bool ZdravstvenaUstanovaExists(int id)
        {
            return _context.ZdravstvenaUstanova.Any(e => e.ZdravstvenaUstanovaId == id);
        }
    }
}
