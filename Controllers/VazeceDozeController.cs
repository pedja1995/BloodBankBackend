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
    public class VazeceDozeController : ControllerBase
    {
        private readonly mydbaContext _context;

        public VazeceDozeController(mydbaContext context)
        {
            _context = context;
        }

        // GET: api/VazeceDoze
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VazeceDoze>>> GetVazeceDoze()
        {
            return await _context.VazeceDoze.ToListAsync();
        }

        // GET: api/VazeceDoze/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VazeceDoze>> GetVazeceDoze(int id)
        {
            var vazeceDoze = await _context.VazeceDoze.FindAsync(id);

            if (vazeceDoze == null)
            {
                return NotFound();
            }

            return vazeceDoze;
        }

        // PUT: api/VazeceDoze/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVazeceDoze(int id, VazeceDoze vazeceDoze)
        {
            if (id != vazeceDoze.DozaKrviId)
            {
                return BadRequest();
            }

            _context.Entry(vazeceDoze).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VazeceDozeExists(id))
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

        // POST: api/VazeceDoze
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VazeceDoze>> PostVazeceDoze(VazeceDoze vazeceDoze)
        {
            _context.VazeceDoze.Add(vazeceDoze);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VazeceDozeExists(vazeceDoze.DozaKrviId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVazeceDoze", new { id = vazeceDoze.DozaKrviId }, vazeceDoze);
        }

        // DELETE: api/VazeceDoze/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VazeceDoze>> DeleteVazeceDoze(int id)
        {
            var vazeceDoze = await _context.VazeceDoze.FindAsync(id);
            if (vazeceDoze == null)
            {
                return NotFound();
            }

            _context.VazeceDoze.Remove(vazeceDoze);
            await _context.SaveChangesAsync();

            return vazeceDoze;
        }

        private bool VazeceDozeExists(int id)
        {
            return _context.VazeceDoze.Any(e => e.DozaKrviId == id);
        }
    }
}
