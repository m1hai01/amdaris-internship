using FluentValidation;

namespace WebApi.Endpoints.Users.Create
{
    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(request => request.Username).NotEmpty().WithMessage("User already exists");
        }
    }
}