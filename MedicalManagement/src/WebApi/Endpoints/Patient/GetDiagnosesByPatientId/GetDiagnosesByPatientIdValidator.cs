using FluentValidation;

namespace WebApi.Endpoints.Patient.GetDiagnosesByPatientId
{
    public class GetDiagnosesByPatientIdValidator : AbstractValidator<GetDiagnosesByPatientIdRequest>
    {
        public GetDiagnosesByPatientIdValidator()
        {
            RuleFor(x => x.PatientId).NotEmpty();
            //RuleFor(x => x.MedicalCardId).NotEmpty();
        }
    }
}