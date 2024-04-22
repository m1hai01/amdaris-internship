﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(MedicalManagementDbContext))]
    partial class MedicalManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Domain.Models.Diagnosis.Diagnose", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Diagnoses");
                });

            modelBuilder.Entity("Domain.Models.Diagnosis.DiagnosisSymptom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DiagnosisId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SymptomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DiagnosisId");

                    b.HasIndex("SymptomId");

                    b.ToTable("DiagnosisSymptoms");
                });

            modelBuilder.Entity("Domain.Models.Diagnosis.Medication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Dosage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Frequency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TreatmentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TreatmentId");

                    b.ToTable("Medications");
                });

            modelBuilder.Entity("Domain.Models.Diagnosis.Treatment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DiagnosisId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("DurationUnit")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DiagnosisId")
                        .IsUnique();

                    b.ToTable("Treatments");
                });

            modelBuilder.Entity("Domain.Models.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AvailableHours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobRoles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Domain.Models.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MedicalRecordId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MedicalRecordId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Domain.Models.MedicalCard.Consume", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MedicalRecordMedicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicalRecordMedicationId")
                        .IsUnique();

                    b.ToTable("Consumes");
                });

            modelBuilder.Entity("Domain.Models.MedicalCard.MedicalCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("MedicalCards");
                });

            modelBuilder.Entity("Domain.Models.MedicalCard.MedicalRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MedicalCardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MedicalCardId");

                    b.ToTable("MedicalRecords");
                });

            modelBuilder.Entity("Domain.Models.MedicalCard.MedicalRecordDiagnosis", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DiagnoseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DiagnosisId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MedicalRecordId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DiagnoseId");

                    b.HasIndex("MedicalRecordId");

                    b.ToTable("MedicalRecordDiagnoses");
                });

            modelBuilder.Entity("Domain.Models.MedicalCard.MedicalRecordMedication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Dosage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Frequency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MedRecTreatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MedRecTreatId");

                    b.ToTable("MedicalRecordMedications");
                });

            modelBuilder.Entity("Domain.Models.MedicalCard.MedicalRecordSymptom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MedicalRecordId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SymptomId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MedicalRecordId");

                    b.HasIndex("SymptomId");

                    b.ToTable("MedicalRecordSymptoms");
                });

            modelBuilder.Entity("Domain.Models.MedicalCard.MedicalRecordTreatment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("DurationUnit")
                        .HasColumnType("int");

                    b.Property<Guid>("MedicalRecordId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MedicalRecordId")
                        .IsUnique();

                    b.ToTable("MedicalRecordTreatments");
                });

            modelBuilder.Entity("Domain.Models.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MedicalCardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Domain.Models.Symptom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Symptoms");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Models.Appointment", b =>
                {
                    b.HasOne("Domain.Models.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Models.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Domain.Models.Diagnosis.DiagnosisSymptom", b =>
                {
                    b.HasOne("Domain.Models.Diagnosis.Diagnose", "Diagnose")
                        .WithMany("Symptoms")
                        .HasForeignKey("DiagnosisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Symptom", "Symptom")
                        .WithMany()
                        .HasForeignKey("SymptomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diagnose");

                    b.Navigation("Symptom");
                });

            modelBuilder.Entity("Domain.Models.Diagnosis.Medication", b =>
                {
                    b.HasOne("Domain.Models.Diagnosis.Treatment", "Treatment")
                        .WithMany("Medications")
                        .HasForeignKey("TreatmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Treatment");
                });

            modelBuilder.Entity("Domain.Models.Diagnosis.Treatment", b =>
                {
                    b.HasOne("Domain.Models.Diagnosis.Diagnose", "Diagnose")
                        .WithOne("Treatment")
                        .HasForeignKey("Domain.Models.Diagnosis.Treatment", "DiagnosisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diagnose");
                });

            modelBuilder.Entity("Domain.Models.Doctor", b =>
                {
                    b.HasOne("Domain.Models.User", "User")
                        .WithOne()
                        .HasForeignKey("Domain.Models.Doctor", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Models.File", b =>
                {
                    b.HasOne("Domain.Models.MedicalCard.MedicalRecord", "MedicalRecord")
                        .WithMany("Files")
                        .HasForeignKey("MedicalRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalRecord");
                });

            modelBuilder.Entity("Domain.Models.MedicalCard.Consume", b =>
                {
                    b.HasOne("Domain.Models.MedicalCard.MedicalRecordMedication", "MedicalRecordMedication")
                        .WithOne()
                        .HasForeignKey("Domain.Models.MedicalCard.Consume", "MedicalRecordMedicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalRecordMedication");
                });

            modelBuilder.Entity("Domain.Models.MedicalCard.MedicalCard", b =>
                {
                    b.HasOne("Domain.Models.Patient", "Patient")
                        .WithOne("MedicalCard")
                        .HasForeignKey("Domain.Models.MedicalCard.MedicalCard", "PatientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Domain.Models.MedicalCard.MedicalRecord", b =>
                {
                    b.HasOne("Domain.Models.MedicalCard.MedicalCard", "MedicalCard")
                        .WithMany("MedicalRecords")
                        .HasForeignKey("MedicalCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalCard");
                });

            modelBuilder.Entity("Domain.Models.MedicalCard.MedicalRecordDiagnosis", b =>
                {
                    b.HasOne("Domain.Models.Diagnosis.Diagnose", "Diagnose")
                        .WithMany()
                        .HasForeignKey("DiagnoseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.MedicalCard.MedicalRecord", "MedicalRecord")
                        .WithMany("Diagnoses")
                        .HasForeignKey("MedicalRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diagnose");

                    b.Navigation("MedicalRecord");
                });

            modelBuilder.Entity("Domain.Models.MedicalCard.MedicalRecordMedication", b =>
                {
                    b.HasOne("Domain.Models.MedicalCard.MedicalRecordTreatment", "Tratment")
                        .WithMany("Medications")
                        .HasForeignKey("MedRecTreatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tratment");
                });

            modelBuilder.Entity("Domain.Models.MedicalCard.MedicalRecordSymptom", b =>
                {
                    b.HasOne("Domain.Models.MedicalCard.MedicalRecord", "MedicalRecord")
                        .WithMany("Symptoms")
                        .HasForeignKey("MedicalRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Symptom", "Symptom")
                        .WithMany()
                        .HasForeignKey("SymptomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalRecord");

                    b.Navigation("Symptom");
                });

            modelBuilder.Entity("Domain.Models.MedicalCard.MedicalRecordTreatment", b =>
                {
                    b.HasOne("Domain.Models.MedicalCard.MedicalRecord", "MedicalRecord")
                        .WithOne("Treatment")
                        .HasForeignKey("Domain.Models.MedicalCard.MedicalRecordTreatment", "MedicalRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalRecord");
                });

            modelBuilder.Entity("Domain.Models.Patient", b =>
                {
                    b.HasOne("Domain.Models.User", "User")
                        .WithOne()
                        .HasForeignKey("Domain.Models.Patient", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Models.Diagnosis.Diagnose", b =>
                {
                    b.Navigation("Symptoms");

                    b.Navigation("Treatment")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Diagnosis.Treatment", b =>
                {
                    b.Navigation("Medications");
                });

            modelBuilder.Entity("Domain.Models.Doctor", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Domain.Models.MedicalCard.MedicalCard", b =>
                {
                    b.Navigation("MedicalRecords");
                });

            modelBuilder.Entity("Domain.Models.MedicalCard.MedicalRecord", b =>
                {
                    b.Navigation("Diagnoses");

                    b.Navigation("Files");

                    b.Navigation("Symptoms");

                    b.Navigation("Treatment")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.MedicalCard.MedicalRecordTreatment", b =>
                {
                    b.Navigation("Medications");
                });

            modelBuilder.Entity("Domain.Models.Patient", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("MedicalCard")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
