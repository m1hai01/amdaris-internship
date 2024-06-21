using Domain.Enums;
using Domain.Models.Diagnosis;

namespace WebApi.Endpoints.Treatments.GetAll
{
    public class TreatmentGetAllResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? DiagnosisId { get; set; }
        public int Duration { get; set; }
        public DurationUnit DurationUnit { get; set; }

        public TreatmentGetAllResponse(Treatment treatment)
        {
            Id = treatment.Id;
            Name = treatment.Name;
            DiagnosisId = treatment.DiagnosisId;
            Duration = treatment.Duration;
            DurationUnit = treatment.DurationUnit;
        }
    }
}