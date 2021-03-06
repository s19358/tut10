﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial10.Models
{
    public class DoctorDbContext : DbContext
    {
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Medicament> Medicament { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicament { get; set; }
        public DbSet<Prescription> Prescription { get; set; }




        public DoctorDbContext()
        {

        }
        public DoctorDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //FluentAPI

            modelBuilder.Entity<Prescription_Medicament>(en =>
            {
                en.HasKey(e => new { e.IdMedicament, e.IdPrescription });
                en.Property(e => e.Details).IsRequired();
            });


            modelBuilder.Entity<Doctor>(en =>
            {
                en.Property(e => e.FirstName).IsRequired();
                en.Property(e => e.LastName).IsRequired();
                en.Property(e => e.Email).IsRequired();

            });

            modelBuilder.Entity<Patient>(en =>
            {
                en.Property(e => e.IdPatient).ValueGeneratedOnAdd();
                en.Property(e => e.FirstName).IsRequired();
                en.Property(e => e.LastName).IsRequired();
                en.Property(e => e.Birthdate).HasColumnType("date");

            });

            modelBuilder.Entity<Prescription>(en =>
            {
                en.Property(e => e.IdPrescription).ValueGeneratedOnAdd();
                en.Property(e => e.Date).HasColumnType("date");
                en.Property(e => e.DueDate).HasColumnType("date");

                /*
                en.HasOne(d => d.Patient)
                        .WithMany(p => p.Prescriptions)
                        .HasForeignKey(d => d.IdPatient);
                        //.OnDelete(DeleteBehavior.ClientSetNull)
                        //.HasConstraintName("");
                 */

                en.HasOne(d => d.Doctor)
                        .WithMany(p => p.Prescriptions)
                        .HasForeignKey(d => d.IdDoctor)
                .OnDelete(DeleteBehavior.ClientSetNull);
                //.HasConstraintName("");
            });

            modelBuilder.Entity<Medicament>(en =>
            {
                en.Property(e => e.IdMedicament).ValueGeneratedOnAdd();
                en.Property(e => e.Name).IsRequired();
                en.Property(e => e.Description)
                                .HasDefaultValue("None")
                             //.HasMaxLength(100)
                                .IsRequired();
                en.Property(e => e.Type).IsRequired();

            });



            LoadData(modelBuilder);
          


        }



        public static void LoadData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
            new Models.Doctor {IdDoctor=1, FirstName = "Bilal", LastName = "Ozgur", Email = "bilal@gmail.com" },
            new Models.Doctor { IdDoctor = 2, FirstName = "Reyhan", LastName = "Ozgur", Email = "reyhan@gmail.com" },
            new Models.Doctor { IdDoctor = 3, FirstName = "Ali", LastName = "Yilmaz", Email = "ali@gmail.com" });

            modelBuilder.Entity<Patient>().HasData(
            new Models.Patient { IdPatient = 1, FirstName = "Busra", LastName = "Yildiz", Birthdate = new DateTime(1997, 8, 30) },
            new Models.Patient { IdPatient = 2, FirstName = "Berkay", LastName = "Koyuncu", Birthdate = new DateTime(1995, 3, 3) },
            new Models.Patient { IdPatient = 3, FirstName = "Merve", LastName = "Unal", Birthdate = new DateTime(1997, 5, 9) });


            modelBuilder.Entity<Medicament>().HasData(
            new Models.Medicament {IdMedicament=1,Name="Aspirin",Description="for pain",Type="type1"},
            new Models.Medicament { IdMedicament = 2, Name = "Parol", Description = "for pain", Type = "type2" },
            new Models.Medicament { IdMedicament = 3,Name = "Terraflu", Description = "for cold", Type = "type3" });

            modelBuilder.Entity<Prescription>().HasData(
            new Models.Prescription { IdPrescription=1,Date= new DateTime(2020, 5, 1) ,DueDate= new DateTime(2020, 5, 15) ,IdPatient=1,IdDoctor=1},
            new Models.Prescription { IdPrescription = 2, Date = new DateTime(2020,4, 2), DueDate = new DateTime(2020, 5, 2), IdPatient = 2, IdDoctor = 2 },
            new Models.Prescription { IdPrescription = 3, Date = new DateTime(2020, 5, 10), DueDate = new DateTime(2020, 6, 1), IdPatient = 3, IdDoctor = 3 });

            modelBuilder.Entity<Prescription_Medicament>().HasData(
            new Models.Prescription_Medicament {IdPrescription=1,IdMedicament=1,Dose=1,Details="once a week" },
            new Models.Prescription_Medicament { IdPrescription = 2, IdMedicament = 2, Dose = 2, Details = "twice a day" },
            new Models.Prescription_Medicament { IdPrescription = 3, IdMedicament = 3, Dose = 1, Details = "once a day" });
            

        }
    }
}
