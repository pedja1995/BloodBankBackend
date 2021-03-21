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
    public class getIsporuka : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult getTables(int id)
        {
            mydbaContext db = new mydbaContext();

            List<Isporuka> isporuka = db.Isporuka.ToList();

            var query = from i in isporuka
                        where i.ZahtjevId == id
                        select i;

            return Ok(query);
        }
    }
}
