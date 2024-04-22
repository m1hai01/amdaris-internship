using Domain.Models.MedicalCard;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.EntityConfiguration.MedicalCardConfiguration.MedicalCardConfigurations
{
    internal class ConsumeConfiguration : IEntityTypeConfiguration<Consume>
    {
        public void Configure(EntityTypeBuilder<Consume> builder)
        {
            // Define relationships
            builder.HasOne(c => c.MedicalRecordMedication)
                   .WithOne()
                   .HasForeignKey<Consume>(c => c.MedicalRecordMedicationId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}