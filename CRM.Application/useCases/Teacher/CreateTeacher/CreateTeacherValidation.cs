using FluentValidation;

namespace DemoCRM.Application.useCases.Teacher.CreateTeacher
{
    public class CreateTeacherValidation : AbstractValidator<CreateTeacherRequest>
    {
        public CreateTeacherValidation()
        {
            RuleFor(t => t.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(t => t.Surname)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(t => t.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(200);

            RuleFor(t => t.Branch)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(t => t.ContactValue)
                .MaximumLength(50)
                .When(t => !string.IsNullOrWhiteSpace(t.ContactValue));
        }
    }
}
