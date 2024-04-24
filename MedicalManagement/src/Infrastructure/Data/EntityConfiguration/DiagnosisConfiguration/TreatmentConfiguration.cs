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
    internal class TreatmentConfiguration : IEntityTypeConfiguration<Treatment>
    {
        public void Configure(EntityTypeBuilder<Treatment> builder)
        {
            builder.HasOne(t => t.Diagnose)
                   .WithOne(d => d.Treatment)
                   .HasForeignKey<Treatment>(t => t.DiagnosisId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(entity => entity.DurationUnit)
                .HasConversion<string>();
        }
    }
}