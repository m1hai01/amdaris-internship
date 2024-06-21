namespace WebApi.Endpoints.Treatments.Create
{
    public class TreatmentCreateResponse
    {
        public Guid Id { get; set; }

        public TreatmentCreateResponse(Guid id)
        {
            Id = id;
        }
    }
}