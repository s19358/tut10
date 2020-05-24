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
        public IActionResult getDoctors()
        {
            return Ok(_context.Doctor.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult getDoctor(int id)
        {
            var res = _context.Doctor.Any(e => e.IdDoctor == id);

            if (res == true)
            {
                var res2 = _context.Doctor.Find(id);

                return Ok(res2);
            }
            else
            {
                return NotFound("There is no  such record!");
            }
        }



        [HttpDelete("{id}")]
        public IActionResult deleteDoctor(int id)
        {
            var res = _context.Doctor.Any(e => e.IdDoctor == id);
            if (res == true)
            {
                var res2 = _context.Doctor.Find(id);  // get the object by the pk
                _context.Doctor.Remove(res2);
                _context.SaveChanges();
                return Ok("Succesfully deleted!");
            }
            else
            {
                return NotFound("There is no  such record!");
            }
        }
    }
}