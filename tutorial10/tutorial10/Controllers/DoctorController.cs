using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tutorial10.Models;

namespace tutorial10.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorDbContext _context; 
        public DoctorController(DoctorDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getDoctor()
        {
            return Ok(_context.Doctor.ToList());
        }
    }
}