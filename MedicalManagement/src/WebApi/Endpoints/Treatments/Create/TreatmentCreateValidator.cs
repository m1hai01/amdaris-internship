using FluentValidation;

namespace WebApi.Endpoints.Treatments.Create
{
    public class TreatmentCreateValidator : AbstractValidator<TreatmentCreateRequest>
    {
        public TreatmentCreateValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Duration).GreaterThan(0);
            RuleFor(x => x.DurationUnit).IsInEnum();
        }
    }
}