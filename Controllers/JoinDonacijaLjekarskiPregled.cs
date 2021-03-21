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
    public class JoinDonacijaLjekarskiPregled : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult getTables(int id)
        {
            mydbaContext db = new mydbaContext();
            List<Donacija> donacija = db.Donacija.ToList();
            List<LjekarskiPregled> ljekarski = db.LjekarskiPregled.ToList();

            var query = from lj in ljekarski
                        join d in donacija on lj.DonacijaId equals d.DonacijaId
                        where lj.DonacijaId == id
                        select lj;

            return Ok(query);
        }

    }
}
