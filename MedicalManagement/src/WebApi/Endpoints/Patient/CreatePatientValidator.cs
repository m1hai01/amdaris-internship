using FluentValidation;

namespace WebApi.Endpoints.Patient
{
    public class CreatePatientValidator : AbstractValidator<CreatePatientRequest>
    {
        public CreatePatientValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            //RuleFor(x => x.MedicalCardId).NotEmpty();
        }
    }
}