using FluentValidation;
using Students.Domain.Entity;

namespace Students.Application.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Username)
                .NotNull()
                .Length(6, 12);

            RuleFor(user => user.Password)
                .NotNull()
                .Length(24, 200);
        }
    }
}
