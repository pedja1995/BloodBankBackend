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
    public class MagacinController : ControllerBase
    {
        private readonly mydbaContext _context;

        public MagacinController(mydbaContext context)
        {
            _context = context;
        }

        // GET: api/Magacin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Magacin>>> GetMagacin()
        {
            return await _context.Magacin.ToListAsync();
        }

        // GET: api/Magacin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Magacin>> GetMagacin(int id)
        {
            var magacin = await _context.Magacin.FindAsync(id);

            if (magacin == null)
            {
                return NotFound();
            }

            return magacin;
        }

        // PUT: api/Magacin/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMagacin(int id, Magacin magacin)
        {
            if (id != magacin.MagacinId)
            {
                return BadRequest();
            }

            _context.Entry(magacin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MagacinExists(id))
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

        // POST: api/Magacin
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Magacin>> PostMagacin(Magacin magacin)
        {
            _context.Magacin.Add(magacin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMagacin", new { id = magacin.MagacinId }, magacin);
        }

        // DELETE: api/Magacin/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Magacin>> DeleteMagacin(int id)
        {
            var magacin = await _context.Magacin.FindAsync(id);
            if (magacin == null)
            {
                return NotFound();
            }

            _context.Magacin.Remove(magacin);
            await _context.SaveChangesAsync();

            return magacin;
        }

        private bool MagacinExists(int id)
        {
            return _context.Magacin.Any(e => e.MagacinId == id);
        }
    }
}
