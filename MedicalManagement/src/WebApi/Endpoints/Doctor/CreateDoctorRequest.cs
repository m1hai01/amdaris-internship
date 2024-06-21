namespace WebApi.Endpoints.Doctor
{
    public class CreateDoctorRequest
    {
        public string UserId { get; set; }
        public List<string> JobRoles { get; set; } = new List<string>();
        public List<DateTime> AvailableHours { get; set; } = new List<DateTime>();
    }
}