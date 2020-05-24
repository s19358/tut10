﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return Ok(_context.Doctor.Include(e => e.Prescriptions)                                                     
                                                       .Select(e => new {
                                                           e.IdDoctor,
                                                           e.FirstName,
                                                           e.LastName,
                                                           e.Email,
                                                           PrescriptionList = e.Prescriptions
                                                                                       .Select(e => e.IdPrescription)
                                                                                       .ToList()}));
        }
        
        [HttpGet("{id}")]
        public IActionResult getDoctor(int id)
        {
            var res = _context.Doctor.Any(e => e.IdDoctor == id);

            if (res == true)
            {
                var res2 = _context.Doctor.Include(e => e.Prescriptions)
                                                       .Where(e => e.IdDoctor == id)
                                                       .Select(e => new { e.IdDoctor, 
                                                                                    e.FirstName,
                                                                                    e.LastName, 
                                                                                    e.Email, 
                                                                                    PrescriptionList = e.Prescriptions
                                                                                                                .Select(e=> e.IdPrescription)
                                                                                                                .ToList() });
                                                   

                return Ok(res2);
            }
            else
            {
                return NotFound("There is no  such record!");
            }
        }
        [HttpPost]
        public IActionResult addDoctor(Doctor doctor)
        {
            var res = _context.Doctor.Any(e => e.IdDoctor == doctor.IdDoctor);
            if (res == true)
            {
                return BadRequest("There is a doctor with this id!");

            }
            else
            {

                _context.Doctor.Add(doctor);
                _context.SaveChanges();
                return Ok("Succesfully added!");
            }

        }
        [HttpPut]
        public IActionResult modifyDoctor(Doctor doctor)
        {
            var res = _context.Doctor.Any(e => e.IdDoctor == doctor.IdDoctor);

            if (res == true)
            {
                var res2 = _context.Doctor.Find(doctor.IdDoctor);
               // res2.FirstName = doctor.FirstName;
                res2.LastName = doctor.LastName;
                _context.SaveChanges();
                return Ok("Succesfully updated!");

            }
            else
            {
                return NotFound("There is no such doctor!");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult deleteDoctor(int id)
        {
            var res = _context.Doctor.Any(e => e.IdDoctor == id);
            if (res == true)
            {
                var res2 = _context.Doctor.Find(id); 
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