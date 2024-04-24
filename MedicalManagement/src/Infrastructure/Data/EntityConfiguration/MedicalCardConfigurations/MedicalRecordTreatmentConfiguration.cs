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
    internal class MedicalRecordTreatmentConfiguration : IEntityTypeConfiguration<MedicalRecordTreatment>
    {
        public void Configure(EntityTypeBuilder<MedicalRecordTreatment> builder)
        {
            // Define relationships
            builder.HasOne(mrt => mrt.MedicalRecord)
                   .WithOne(mr => mr.Treatment)
                   .HasForeignKey<MedicalRecordTreatment>(mrt => mrt.MedicalRecordId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder
                .Property(entity => entity.DurationUnit)
                .HasConversion<string>();

            builder.HasMany(mrt => mrt.Medications)
                   .WithOne(mrm => mrm.Tratment)
                   .HasForeignKey(mrt => mrt.MedRecTreatId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}