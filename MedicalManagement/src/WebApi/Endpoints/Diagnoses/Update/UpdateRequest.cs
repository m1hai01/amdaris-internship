using System.ComponentModel.DataAnnotations;

namespace WebApi.Endpoints.Diagnoses.Update
{
    public class UpdateRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}