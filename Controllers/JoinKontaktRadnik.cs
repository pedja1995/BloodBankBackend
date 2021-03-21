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
    public class JoinKontaktRadnik : ControllerBase
    {
        [HttpGet("{id}")]

        public IActionResult getTables(int id)
        {
            mydbaContext db = new mydbaContext();
            List<Kontakt> kontakt = db.Kontakt.ToList();
            List<Radnik> radnik = db.Radnik.ToList();
            List<Lokacija> lokacija = db.Lokacija.ToList();

            var query = from k in kontakt
                        join r in radnik on k.RadnikId equals r.RadnikId
                        where k.RadnikId == id
                        join l in lokacija on k.LokacijaId equals l.LokacijaId
                        select k;

            return Ok(query);
        }

    }
}
