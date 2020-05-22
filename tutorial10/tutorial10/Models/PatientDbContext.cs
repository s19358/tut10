using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial10.Models
{
    public class PatientDbContext : DbContext
    {
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Medicament> Medicament { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicament { get; set; }
        public DbSet<Prescription> Prescription { get; set; }

        public PatientDbContext()
        {

        }
        public PatientDbContext(DbContextOptions options) : base(options)
        {

        }

    }
}
