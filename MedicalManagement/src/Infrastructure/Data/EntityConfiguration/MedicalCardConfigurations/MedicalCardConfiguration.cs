using Domain.Models;
using Domain.Models.MedicalCard;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.EntityConfiguration.MedicalCardConfigurations
{
    internal class MedicalCardConfiguration : IEntityTypeConfiguration<MedicalCard>
    {
        public void Configure(EntityTypeBuilder<MedicalCard> builder)
        {
            // Define relationships
            builder.HasOne(mc => mc.Patient)
                   .WithOne(p => p.MedicalCard)
                   .HasForeignKey<MedicalCard>(p => p.PatientId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(mc => mc.MedicalRecords)
                   .WithOne(mr => mr.MedicalCard)
                   .HasForeignKey(mr => mr.MedicalCardId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}