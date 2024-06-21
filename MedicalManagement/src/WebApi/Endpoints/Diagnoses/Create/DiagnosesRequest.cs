using System.ComponentModel.DataAnnotations;

namespace WebApi.Endpoints.Diagnoses.Create
{
    public class DiagnosesRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public Guid patientId { get; set; }
    }
}