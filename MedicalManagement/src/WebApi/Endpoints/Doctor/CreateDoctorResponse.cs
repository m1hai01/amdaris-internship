namespace WebApi.Endpoints.Doctor
{
    public class CreateDoctorResponse
    {
        public Guid Id { get; set; }

        public CreateDoctorResponse(Guid id)
        {
            Id = id;
        }
    }
}