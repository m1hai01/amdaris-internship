using FluentValidation;

namespace WebApi.Endpoints.Diagnoses.Create
{
    public class DiagnosesCreateValidator : AbstractValidator<DiagnosesRequest>
    {
        public DiagnosesCreateValidator()
        {
            RuleFor(request => request.Name).NotEmpty().WithMessage("Name for diagnosis is mandatory");
        }
    }
}