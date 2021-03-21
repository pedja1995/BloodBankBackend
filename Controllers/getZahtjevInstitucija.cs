using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class getZahtjevInstitucija : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult getTables(int id)
        {
            mydbaContext db = new mydbaContext();

            List<Zahtjev> zahtjev = db.Zahtjev.ToList();

            var query = from z in zahtjev

                        where z.ZdravstvenaUstanovaId == id
                        select z;

            return Ok(query);
        }
    }
}
