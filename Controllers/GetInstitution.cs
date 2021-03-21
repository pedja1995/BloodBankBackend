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
    public class GetInstitution : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult getTables(int id)
        {
            mydbaContext db = new mydbaContext();

            List<ZdravstvenaUstanova> ustanova = db.ZdravstvenaUstanova.ToList();

            var query = from u in ustanova

                        where u.ZdravstvenaUstanovaId == id
                        select u;

            return Ok(query);
        }
    }
}
