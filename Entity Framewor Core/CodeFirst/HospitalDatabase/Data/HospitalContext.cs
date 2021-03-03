using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {

        }
        public HospitalContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments{ get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientMedicament> PatientMedicaments { get; set; }
        public DbSet<Visitation> Visitations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(@"Server =.; Database = HospitalDatabase; Integrated Security = True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                entity.HasKey(pm => new { pm.MedicamentId, pm.PatientId });
            });
        }
    }

}
