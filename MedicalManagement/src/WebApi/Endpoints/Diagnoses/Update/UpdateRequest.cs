using System.ComponentModel.DataAnnotations;

namespace WebApi.Endpoints.Update
{
    public class UpdateRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}