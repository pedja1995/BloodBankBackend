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
    public class InstitutionCheck : ControllerBase
    {

        [HttpGet("{code}")]
        public IActionResult getTables(string code)
        {
            mydbaContext db = new mydbaContext();
           
            List<ZdravstvenaUstanova> institucija = db.ZdravstvenaUstanova.ToList();

            var query = from z in institucija
                       
                        where z.VerifikacioniKod == code
                        select z;

            return Ok(query);
        }
    }
}
