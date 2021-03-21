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
    public class JoinKontaktUstanova : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult getTables( int id)
        {
            mydbaContext db = new mydbaContext();
            List<Kontakt> kontakt = db.Kontakt.ToList();
            List<ZdravstvenaUstanova> ustanova = db.ZdravstvenaUstanova.ToList();
            List<Lokacija> lokacija = db.Lokacija.ToList();

            var query = from k in kontakt
                        join zu in ustanova on k.ZdravstvenaUstanovaId equals zu.ZdravstvenaUstanovaId where k.ZdravstvenaUstanovaId==id
                        join l in lokacija on k.LokacijaId equals l.LokacijaId
                        select k;

            return Ok(query);
        }


    }
}
