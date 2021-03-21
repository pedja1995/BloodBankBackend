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
    public class JoinDonacijaDoza : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult getTables(int id)
        {
            mydbaContext db = new mydbaContext();
            List<Donacija> donacija = db.Donacija.ToList();
            List<DozaKrvi> doza = db.DozaKrvi.ToList();

            var query = from d in doza
                        join don in donacija on d.DonacijaId equals don.DonacijaId
                        where d.DonacijaId == id
                        select d;

            return Ok(query);
        }
    }
}
