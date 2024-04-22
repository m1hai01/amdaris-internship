using Domain.Models.Diagnosis;
using Domain.Models.MedicalCard;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.EntityConfiguration.MedicalCardConfigurations
{
    internal class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            //builder.HasKey(mr => mr.Id);

            // MedicalRecord - MedicalRecordSymptom (one-to-many)
            builder.HasMany(mr => mr.Symptoms)
                .WithOne(mrs => mrs.MedicalRecord)
                .HasForeignKey(mrs => mrs.MedicalRecordId)
                .OnDelete(DeleteBehavior.Cascade);

            // MedicalRecord - MedicalRecordDiagnosis (one-to-many)
            builder.HasMany(mr => mr.Diagnoses)
                .WithOne(mrd => mrd.MedicalRecord)
                .HasForeignKey(mrd => mrd.MedicalRecordId)
                .OnDelete(DeleteBehavior.Cascade);

            // MedicalRecord - MedicalRecordTreatment (one-to-many)
            builder.HasOne(mr => mr.Treatment)
                .WithOne(mrt => mrt.MedicalRecord)
                .HasForeignKey<MedicalRecordTreatment>(mrt => mrt.MedicalRecordId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Configure the one-to-many relationship with File
            builder.HasMany(mr => mr.Files)
                .WithOne(f => f.MedicalRecord)
                .HasForeignKey(f => f.MedicalRecordId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}