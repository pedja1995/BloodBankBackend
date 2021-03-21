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
    public class JoinKontaktDonor : ControllerBase
    {

        [HttpGet("{id}")]
        public IActionResult getTables(int id)
        {
            mydbaContext db = new mydbaContext();
            List<Kontakt> kontakt = db.Kontakt.ToList();
            List<Donor> donor = db.Donor.ToList();
            List<Lokacija> lokacija = db.Lokacija.ToList();

            var query = from k in kontakt
                        join d in donor on k.DonorId    equals d.DonorId
                        where k.DonorId == id
                        join l in lokacija on k.LokacijaId equals l.LokacijaId
                        select k;

            return Ok(query);
        }


    }
}
