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
    public class getDoza : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult getTables(int id)
        {
            mydbaContext db = new mydbaContext();

            List<DozaKrvi> doza = db.DozaKrvi.ToList();

            var query = from d in doza
                        where d.IsporukaId == id
                        select d;

            return Ok(query);
        }
    }
}
