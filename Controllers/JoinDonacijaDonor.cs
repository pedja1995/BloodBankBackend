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
    public class JoinDonacijaDonor : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult getTables(int id)
        {
            mydbaContext db = new mydbaContext();
            List<Donacija> donacija = db.Donacija.ToList();
            List<Donor> donor = db.Donor.ToList();

            var query = from don in donacija
                        join d in donor on don.DonorId equals d.DonorId
                        where don.DonorId == id
                        select don;

            return Ok(query);
        }
    }
}
