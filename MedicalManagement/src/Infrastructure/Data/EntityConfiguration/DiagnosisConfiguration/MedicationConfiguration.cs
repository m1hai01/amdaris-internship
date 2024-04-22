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
    internal class MedicationConfiguration : IEntityTypeConfiguration<Medication>
    {
        public void Configure(EntityTypeBuilder<Medication> builder)
        {
            // Configure foreign key
            builder.HasOne(m => m.Treatment)
                   .WithMany(t => t.Medications)
                   .HasForeignKey(m => m.TreatmentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}