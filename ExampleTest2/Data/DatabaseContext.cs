using ExampleTest2.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicament { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>
        {
            new Doctor
            {
                IdDoctor = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                Email = "jan@kowalski.com"
            },
            new Doctor
            {
                IdDoctor = 2,
                FirstName = "Anna",
                LastName = "Nowak",
                Email = "anna@nowak.com"
            }
        });

        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>
        {
            new Medicament
            {
                IdMedicament = 1,
                Name = "Adderal",
                Description = "for ADHD treatment",
                Type = "amphetamine"
            },
            new Medicament
            {
                IdMedicament = 2,
                Name = "APAP",
                Description = "headache medicine",
                Type = "over-the-counter"
            }
        });

        modelBuilder.Entity<Patient>().HasData(new List<Patient>
        {
            new Patient
            {
                IdPatient = 1,
                Birthdate = new DateTime(2003, 06, 19),
                FirstName = "Matthew",
                LastName = "Patrick"
            },
            new Patient
            {
                IdPatient = 2,
                Birthdate = new DateTime(2004, 05, 11),
                FirstName = "George",
                LastName = "Mallory"
            },
            new Patient
            {
                IdPatient = 3,
                Birthdate = new DateTime(2001, 02, 18),
                FirstName = "Richard",
                LastName = "Stallman"
            },
        });

        modelBuilder.Entity<Prescription>().HasData(new List<Prescription>
        {
            new Prescription
            {
                IdPrescription = 1,
                Date = new DateTime(2024, 06, 09),
                DueDate = new DateTime(2024, 06, 16),
                IdPatient = 1,
                IdDoctor = 1
            },
            new Prescription
            {
                IdPrescription = 2,
                Date = new DateTime(2024, 05, 12),
                DueDate = new DateTime(2024, 06, 03),
                IdPatient = 2,
                IdDoctor = 1
            },
            new Prescription
            {
                IdPrescription = 3,
                Date = new DateTime(2024, 06, 08),
                DueDate = new DateTime(2024, 09, 23),
                IdPatient = 3,
                IdDoctor = 2
            }
        });

        modelBuilder.Entity<PrescriptionMedicament>().HasData(new List<PrescriptionMedicament>
        {
            new PrescriptionMedicament
            {
                IdMedicament = 1,
                IdPrescription = 1,
                Dose = 2,
                Details = "Don't overdose",
            },
            new PrescriptionMedicament
            {
                IdMedicament = 2,
                IdPrescription = 2,
                Dose = null,
                Details = "awdadw",
            },
            new PrescriptionMedicament
            {
                IdMedicament = 2,
                IdPrescription = 3,
                Dose = 3,
                Details = "awdawdawd",
            },
            new PrescriptionMedicament
            {
                IdMedicament = 2,
                IdPrescription = 1,
                Dose = 2,
                Details = "Watch out",
            }
        });
    }
}