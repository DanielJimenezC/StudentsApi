using FluentValidation;
using Students.Domain.Entity;

namespace Students.Application.Validators
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(student => student.Name)
                .NotNull()
                .Length(2, 150);

            RuleFor(student => student.Email)
                .NotNull()
                .Length(2, 150)
                .EmailAddress();

            RuleFor(student => student.Phone)
                .NotNull()
                .InclusiveBetween(1000000, 999999999);
        }
    }
}
