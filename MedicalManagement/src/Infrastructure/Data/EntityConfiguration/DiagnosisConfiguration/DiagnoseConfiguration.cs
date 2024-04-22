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
    internal class DiagnoseConfiguration : IEntityTypeConfiguration<Diagnose>
    {
        public void Configure(EntityTypeBuilder<Diagnose> builder)
        {
            // Configure navigation properties
            builder.HasMany(d => d.Symptoms)
                   .WithOne(ds => ds.Diagnose)
                   .HasForeignKey(ds => ds.DiagnosisId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Treatment)
                   .WithOne(t => t.Diagnose)
                   .HasForeignKey<Treatment>(t => t.DiagnosisId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}