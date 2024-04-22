using Domain.Models.MedicalCard;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.EntityConfiguration.MedicalCardConfigurations
{
    internal class MedicalRecordSymptomConfiguration : IEntityTypeConfiguration<MedicalRecordSymptom>
    {
        public void Configure(EntityTypeBuilder<MedicalRecordSymptom> builder)
        {
            // Define relationships
            builder.HasOne(mrs => mrs.MedicalRecord)
                   .WithMany(mr => mr.Symptoms)
                   .HasForeignKey(mrs => mrs.MedicalRecordId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(mrs => mrs.Symptom)
                   .WithMany()
                   .HasForeignKey(mrs => mrs.SymptomId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}