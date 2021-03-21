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
    public class getDozaZaIsporuku : ControllerBase
    {
        [HttpGet("{grupa}/{tip}")]
        public IActionResult getTables(string grupa, string tip)
        {
            mydbaContext db = new mydbaContext();

            List<DozaKrvi> doza = db.DozaKrvi.ToList();

            var query = from d in doza
                        where d.KrvnaGrupaDoza == grupa && d.TipKrvnogDerivata==tip && d.IstekaoRok==0 && d.IsporukaId==null
                        select d;

            return Ok(query);
        }
    }
}
