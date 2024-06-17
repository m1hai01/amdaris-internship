using FluentValidation;

namespace WebApi.Endpoints.Users.Get
{
    public class Validator : AbstractValidator<GetAllUsersRequest>
    {
        public Validator()
        {
            RuleFor(x => x.Page).GreaterThan(0);
            RuleFor(x => x.PageSize).GreaterThan(0);
        }
    }
}