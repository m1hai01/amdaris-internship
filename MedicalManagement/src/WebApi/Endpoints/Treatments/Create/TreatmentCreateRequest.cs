using Domain.Enums;

namespace WebApi.Endpoints.Treatments.Create
{
    public class TreatmentCreateRequest
    {
        public string Name { get; set; } = null!;
        public Guid? DiagnosisId { get; set; }
        public int Duration { get; set; }
        public DurationUnit DurationUnit { get; set; }
    }
}