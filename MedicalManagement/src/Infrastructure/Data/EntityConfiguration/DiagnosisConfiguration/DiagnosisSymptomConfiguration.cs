using Domain.Models.Diagnosis;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.EntityConfiguration.DiagnosisConfiguration
{
    internal class DiagnosisSymptomConfiguration : IEntityTypeConfiguration<DiagnosisSymptom>
    {
        public void Configure(EntityTypeBuilder<DiagnosisSymptom> builder)
        {
            // Configure foreign keys
            builder.HasOne(ds => ds.Diagnose)
                   .WithMany(d => d.Symptoms)
                   .HasForeignKey(ds => ds.DiagnosisId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ds => ds.Symptom)
                   .WithMany()
                   .HasForeignKey(ds => ds.SymptomId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}