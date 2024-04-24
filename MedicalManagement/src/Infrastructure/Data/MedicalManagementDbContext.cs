using Domain.Models;
using Domain.Models.Diagnosis;
using Domain.Models.MedicalCard;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MedicalManagementDbContext : DbContext
    {
        //-o Data/Migrations
        public MedicalManagementDbContext(DbContextOptions<MedicalManagementDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Domain.Models.File> Files { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalRecordTreatment> MedicalRecordTreatments { get; set; }
        public DbSet<MedicalRecordSymptom> MedicalRecordSymptoms { get; set; }
        public DbSet<MedicalRecordMedication> MedicalRecordMedications { get; set; }
        public DbSet<MedicalRecordDiagnosis> MedicalRecordDiagnoses { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<MedicalCard> MedicalCards { get; set; }
        public DbSet<Consume> Consumes { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<DiagnosisSymptom> DiagnosisSymptoms { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //incorporating these default configurations into your model
            base.OnModelCreating(modelBuilder);

            // Configure entity relationships
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MedicalManagementDbContext).Assembly);
            //modelBuilder.ApplyConfiguration(new MedicalCardConfiguration());
        }
    }
}