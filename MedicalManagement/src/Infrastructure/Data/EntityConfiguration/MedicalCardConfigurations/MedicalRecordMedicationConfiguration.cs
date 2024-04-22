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
    internal class MedicalRecordMedicationConfiguration : IEntityTypeConfiguration<MedicalRecordMedication>
    {
        public void Configure(EntityTypeBuilder<MedicalRecordMedication> builder)
        {
            // Define relationships
            builder.HasOne(mrm => mrm.Tratment)
                   .WithMany(mrt => mrt.Medications)
                   .HasForeignKey(mrm => mrm.MedRecTreatId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}