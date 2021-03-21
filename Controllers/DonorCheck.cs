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
    public class DonorCheck : ControllerBase
    {
        [HttpGet("{user}/{pass}")]
        public IActionResult getTables(string user, string pass)
        {
            mydbaContext db = new mydbaContext();
            List<Donor> donor = db.Donor.ToList();

            var query = from d in donor
                        where d.RegistarskiBroj == user && d.Lozinka==pass
                        select d;

            return Ok(query);
        }
    }
}
