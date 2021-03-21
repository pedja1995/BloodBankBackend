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
    public class EmailCheck : ControllerBase
    {
        [HttpGet("{email}")]
        public IActionResult getTables(string email)
        {
            mydbaContext db = new mydbaContext();
            List<Kontakt> kontakti = db.Kontakt.ToList();

            var query = from k in kontakti
                        where k.Email == email
                        select k;

            return Ok(query);
        }
    }
}
