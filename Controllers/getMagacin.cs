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
    public class getMagacin : ControllerBase
    {

        [HttpGet("{type}")]
        public IActionResult getTables(string type)
        {
            mydbaContext db = new mydbaContext();

            List<Magacin> magacin = db.Magacin.ToList();

            var query = from m in magacin

                        where m.KrvnaGrupaMagacin == type
                        select m;

            return Ok(query);
        }
    }
}
