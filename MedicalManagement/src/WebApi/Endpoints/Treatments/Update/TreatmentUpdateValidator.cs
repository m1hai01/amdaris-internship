using FluentValidation;

namespace WebApi.Endpoints.Treatments.Update
{
    public class TreatmentUpdateValidator : AbstractValidator<TreatmentUpdateRequest>
    {
        public TreatmentUpdateValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Duration).GreaterThan(0);
            RuleFor(x => x.DurationUnit).IsInEnum();
        }
    }
}