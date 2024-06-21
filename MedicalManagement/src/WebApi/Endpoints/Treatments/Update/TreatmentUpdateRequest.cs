using Domain.Enums;

namespace WebApi.Endpoints.Treatments.Update
{
    public class TreatmentUpdateRequest
    {
        public string Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid? DiagnosisId { get; set; }
        public int Duration { get; set; }
        public DurationUnit DurationUnit { get; set; }
    }
}