namespace WebApi.Endpoints.Treatments.GetAll
{
    public class TreatmentGetAllRequest
    {
        public string? SearchTerm { get; set; }
        public string? SortColumn { get; set; }
        public string? SortOrder { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}