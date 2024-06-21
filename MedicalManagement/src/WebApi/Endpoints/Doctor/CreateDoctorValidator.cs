using FluentValidation;

namespace WebApi.Endpoints.Doctor
{
    public class CreateDoctorValidator : AbstractValidator<CreateDoctorRequest>
    {
        public CreateDoctorValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.JobRoles).NotEmpty();
            RuleFor(x => x.AvailableHours).NotEmpty();
        }
    }
}