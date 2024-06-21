namespace WebApi.Endpoints.Patient
{
    public class CreatePatientResponse
    {
        public Guid Id { get; set; }

        public CreatePatientResponse(Guid id)
        {
            Id = id;
        }
    }
}